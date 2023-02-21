using UnityEngine;

namespace Managers
{
    public class ItemManager : MonoBehaviour
    {
        private Camera _camera;
        private CellManager _cellManager;
        private int _currentLevel;
    
        private void Awake()
        {
            _camera = Camera.main;
            _cellManager = FindObjectOfType<CellManager>();
            _currentLevel = PlayerPrefs.GetInt("CurrentLevel");
        }

        private void Start()
        {
            var items = LevelData.StartingItemList[_currentLevel];

            foreach (var item in items)
            {
                SpawnItem(item.GetId(), item.GetSpawnPosition());
            }
        }

        public void SpawnItem(int id, Vector3 spawnPosition)
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
