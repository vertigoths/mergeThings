using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        SpawnItem();
    }

    private void SpawnItem()
    {
        var itemPrefab = Resources.Load<GameObject>("Prefabs/Item");

        var itemObject = Instantiate(itemPrefab, Vector3.zero, Quaternion.identity);
        var item = itemObject.GetComponent<Item>();
        
        item.Camera = _camera;
        item.CellManager = _cellManager;
    }
}
