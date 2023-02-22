using System;
using System.Collections.Generic;
using UnityEngine;

namespace Managers
{
    public class AnimalManager : MonoBehaviour
    {
        private int _currentLevel;
        private List<Enemy> _enemies;
        private int _remainingEnemies;

        private void Awake()
        {
            _currentLevel = PlayerPrefs.GetInt("CurrentLevel");
            _enemies = new List<Enemy>();
        }

        private void Start()
        {
            var animals = LevelData.StartingAnimalList[_currentLevel];
            _remainingEnemies = animals.Count;

            foreach (var animal in animals)
            {
                SpawnAnimal(animal.GetId(), animal.GetItemId(), animal.GetSpawnPosition());
            }
        }

        private void SpawnAnimal(int animalId, int itemId, Vector3 spawnPosition)
        {
            var animalPrefab = Data.GetAnimalById(animalId);
            var itemPrefab = Data.GetAnimalFoodById(itemId);

            var animalObject = Instantiate(animalPrefab, spawnPosition, animalPrefab.transform.rotation);
            var itemObject = Instantiate(itemPrefab, animalObject.transform);

            var enemy = animalObject.GetComponent<Enemy>();
            enemy.SetItem(itemObject);
            enemy.SetItemId(itemId);
            enemy.SetAnimalManager(this);
            
            _enemies.Add(enemy);
        }

        public void StartHorde()
        {
            foreach (var enemy in _enemies)
            {
                enemy.MoveTowards();
            }
        }

        public void OnEnemyDefeat()
        {
            _remainingEnemies -= 1;

            if (_remainingEnemies <= 0)
            {
                FindObjectOfType<UIManager>().OnWin();
            }
        }
    }
}
