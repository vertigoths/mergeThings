using System.Collections.Generic;
using UnityEngine;

public static class Data
{
    private static readonly Dictionary<CellType, Material> CellMaterials = new Dictionary<CellType, Material>()
    {
        {
            CellType.EmptyCell, Resources.Load<Material>("Materials/EmptyCell")
        },
        {
            CellType.HoveredCell, Resources.Load<Material>("Materials/HoveredCell")
        },
        {
            CellType.OccupiedCell, Resources.Load<Material>("Materials/OccupiedCell")
        },
    };

    private static readonly Dictionary<int, GameObject> Items = new Dictionary<int, GameObject>()
    {
        {
            1, Resources.Load<GameObject>("Prefabs/Foods/apple")
        },
        {
            2, Resources.Load<GameObject>("Prefabs/Foods/banana")
        },
        {
            3, Resources.Load<GameObject>("Prefabs/Foods/cherry")
        },
        {
            4, Resources.Load<GameObject>("Prefabs/Foods/garlic")
        },
        {
            5, Resources.Load<GameObject>("Prefabs/Foods/grape")
        },
        {
            6, Resources.Load<GameObject>("Prefabs/Foods/lemon")
        },
        {
            7, Resources.Load<GameObject>("Prefabs/Foods/mushroom")
        },
        {
            8, Resources.Load<GameObject>("Prefabs/Foods/pumpkin")
        },
        {
            9, Resources.Load<GameObject>("Prefabs/Foods/watermelon")
        },
    };

    public static Material GetMaterialByCell(CellType cellType)
    {
        return CellMaterials[cellType];
    }
    
    public static GameObject GetFoodById(int id)
    {
        return Items[id];
    }
}