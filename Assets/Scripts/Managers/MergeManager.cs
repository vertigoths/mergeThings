using System;
using System.Collections.Generic;
using UnityEngine;

namespace Managers
{
    public class MergeManager : MonoBehaviour
    {
        private ItemManager _itemManager;
        private LinkedList<GameObject> _effects;

        private void Awake()
        {
            _itemManager = FindObjectOfType<ItemManager>();
            _effects = new LinkedList<GameObject>();
        }

        private void Start()
        {
            CreateEffects(10);
        }

        public void MergeItems(Vector3 mergePosition, int id)
        {
            if (id != 9)
            {
                _itemManager.SpawnItem(id + 1, mergePosition);
                DisplayEffect(mergePosition);
            }

            if (_effects.Count == 0)
            {
                CreateEffects(5);
            }
        }

        private void CreateEffects(int amount)
        {
            for (var i = 0; i < amount; i++)
            {
                var effectPrefab = Data.GetRandomEffectPrefab();

                var effectObject = Instantiate(effectPrefab, effectPrefab.transform.position, Quaternion.identity);
                effectObject.SetActive(false);
                _effects.AddLast(effectObject);
            }
        }

        private void DisplayEffect(Vector3 mergePosition)
        {
            var effect = _effects.Last.Value;
            _effects.RemoveLast();
            
            effect.SetActive(true);
            effect.transform.position = mergePosition + Vector3.up;
        }
    }
}