using System;
using System.Linq;
using DG.Tweening;
using UnityEngine;

namespace Managers
{
    public class CellManager : MonoBehaviour
    {
        private MergeManager _mergeManager;
        [SerializeField] private Cell[] cells;

        private void Awake()
        {
            _mergeManager = FindObjectOfType<MergeManager>();
        }

        public void OnItemDrop(Transform itemTransform, Vector3 position, Vector3 positionBeforeDrag)
        {
            var closestCell = GetClosestCell(position);
            var item = itemTransform.GetComponent<Item>();

            if (closestCell.CanPlace())
            {
                itemTransform.DOMove(closestCell.transform.position, 0.1f);
        
                closestCell.OnDrop(item);
            }
            else
            {
                if (closestCell.GetItemRank() == item.Rank)
                {
                    _mergeManager.MergeItems(closestCell.transform.position, item.Rank);
                }
                else
                {
                    itemTransform.DOMove(positionBeforeDrag, 0.1f);
                    var previousCell = GetCellFromPosition(positionBeforeDrag);
            
                    previousCell.OnDrop(item);
                }
            }
        }

        public void OnItemPick(Vector3 position)
        {
            var cell = GetCellFromPosition(position);
        
            cell.OnPick();
        }

        private Cell GetClosestCell(Vector3 position)
        {
            var minDifference = Mathf.Infinity;
            var closestCell = cells[0];
        
            foreach (var cell in cells)
            {
                var difference = (cell.transform.position - position).magnitude;

                if (difference < minDifference)
                {
                    minDifference = difference;
                    closestCell = cell;
                }
            }

            return closestCell;
        }

        private Cell GetCellFromPosition(Vector3 position)
        {
            return cells.FirstOrDefault(cell => cell.transform.position.Equals(position));
        }
    }
}