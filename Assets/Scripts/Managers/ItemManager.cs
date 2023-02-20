using UnityEngine;

namespace Managers
{
    public class ItemManager : MonoBehaviour
    {
        private Camera _camera;
        private CellManager _cellManager;
    
        private void Awake()
        {
            _camera = Camera.main;
            _cellManager = FindObjectOfType<CellManager>();
        }

        private void Start()
        {
            SpawnItem(1, Vector3.zero);
            SpawnItem(1, Vector3.left * 5);
            SpawnItem(3, Vector3.right * 5);
        }

        private void SpawnItem(int id, Vector3 spawnPosition)
        {
            var itemPrefab = Data.GetFoodById(id);

            var itemObject = Instantiate(itemPrefab, spawnPosition, itemPrefab.transform.rotation);
            var item = itemObject.GetComponent<Item>();
        
            item.Camera = _camera;
            item.CellManager = _cellManager;
            item.SetRank(id);
            _cellManager.OnItemDrop(item.transform, spawnPosition, spawnPosition);
        }
    }
}
