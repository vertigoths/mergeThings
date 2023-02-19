using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using UnityEngine;

public class CellManager : MonoBehaviour
{
    [SerializeField] private Cell[] cells;

    public void OnItemDrop(Transform itemTransform, Vector3 position)
    {
        var closestCell = GetClosestCell(position);

        itemTransform.DOMove(closestCell.transform.position, 0.1f);
    }

    public void OnItemPick()
    {
        
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