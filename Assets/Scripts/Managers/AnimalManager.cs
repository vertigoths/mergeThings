using System;
using UnityEngine;

namespace Managers
{
    public class AnimalManager : MonoBehaviour
    {
        private int _currentLevel;

        private void Awake()
        {
            _currentLevel = PlayerPrefs.GetInt("CurrentLevel");
        }

        private void Start()
        {
            var animals = LevelData.StartingAnimalList[_currentLevel];

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
        }
    }
}
