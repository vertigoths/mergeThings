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
    
    private static readonly Dictionary<int, GameObject> AnimalItems = new Dictionary<int, GameObject>()
    {
        {
            1, Resources.Load<GameObject>("Prefabs/FoodsForAnimals/apple")
        },
        {
            2, Resources.Load<GameObject>("Prefabs/FoodsForAnimals/banana")
        },
        {
            3, Resources.Load<GameObject>("Prefabs/FoodsForAnimals/cherry")
        },
        {
            4, Resources.Load<GameObject>("Prefabs/FoodsForAnimals/garlic")
        },
        {
            5, Resources.Load<GameObject>("Prefabs/FoodsForAnimals/grape")
        },
        {
            6, Resources.Load<GameObject>("Prefabs/FoodsForAnimals/lemon")
        },
        {
            7, Resources.Load<GameObject>("Prefabs/FoodsForAnimals/mushroom")
        },
        {
            8, Resources.Load<GameObject>("Prefabs/FoodsForAnimals/pumpkin")
        },
        {
            9, Resources.Load<GameObject>("Prefabs/FoodsForAnimals/watermelon")
        },
    };
    
    private static readonly GameObject[] Animals = new GameObject[]
    {
        Resources.Load<GameObject>("Prefabs/Animals/Cow"),
        Resources.Load<GameObject>("Prefabs/Animals/Horse"),
        Resources.Load<GameObject>("Prefabs/Animals/Llama"),
        Resources.Load<GameObject>("Prefabs/Animals/Pig"),
        Resources.Load<GameObject>("Prefabs/Animals/Pug"),
        Resources.Load<GameObject>("Prefabs/Animals/Sheep")
    };

    private static readonly GameObject[] Effects = new[]
    {
        Resources.Load<GameObject>("Pickup Items/Diamond"),
        Resources.Load<GameObject>("Pickup Items/Heart"),
        Resources.Load<GameObject>("Pickup Items/Smiley"),
        Resources.Load<GameObject>("Pickup Items/Star"),
    };

    public static Material GetMaterialByCell(CellType cellType)
    {
        return CellMaterials[cellType];
    }
    
    public static GameObject GetFoodById(int id)
    {
        return Items[id];
    }

    public static GameObject GetAnimalFoodById(int id)
    {
        return AnimalItems[id];
    }

    public static GameObject GetAnimalById(int id)
    {
        return Animals[id];
    }

    public static GameObject GetRandomEffectPrefab()
    {
        var rand = Random.Range(0, Effects.Length);
        return Effects[rand];
    }
}