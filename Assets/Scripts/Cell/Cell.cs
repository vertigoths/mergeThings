using UnityEngine;

namespace Cell
{
    public class Cell : MonoBehaviour
    {
        private CellType _currentCellType;
        private MeshRenderer _meshRenderer;
        private Item _item;

        private void Awake()
        {
            _meshRenderer = transform.GetChild(0).GetComponent<MeshRenderer>();
        }

        public void OnHover()
        {
            _currentCellType = CellType.HoveredCell;
            _meshRenderer.material = Data.GetMaterialByCell(_currentCellType);
        }

        public void OnDrop(Item item)
        {
            _currentCellType = CellType.OccupiedCell;
            _meshRenderer.material = Data.GetMaterialByCell(_currentCellType);
            _item = item;
        }

        public void OnPick()
        {
            _currentCellType = CellType.EmptyCell;
            _meshRenderer.material = Data.GetMaterialByCell(_currentCellType);
            _item = null;
        }

        public bool CanPlace()
        {
            return _currentCellType == CellType.EmptyCell;
        }

        public int GetItemRank()
        {
            return _item.Rank;
        }

        public void RemoveItem()
        {
            _item.gameObject.SetActive(false);
            OnPick();
        }
    }
}