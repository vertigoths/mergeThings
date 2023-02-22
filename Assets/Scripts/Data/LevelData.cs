using System.Collections.Generic;
using UnityEngine;

public class LevelData
{
    public static readonly List<Food>[] StartingItemList = new List<Food>[]
    {
        new List<Food>()
        {
            new Food(1, Vector3.zero),
            new Food(1, Vector3.left * 5),
            new Food(1, Vector3.forward * 5),
            new Food(1, Vector3.forward * 2.5f),
            new Food(3, Vector3.right * 5)
            
        },
        new List<Food>()
        {
            
        }
    };

    public static readonly List<Animal>[] StartingAnimalList = new List<Animal>[]
    {
        new List<Animal>()
        {
            new Animal(4, 2, new Vector3(5f, 0f, 15.5f)),
            new Animal(3, 1, new Vector3(2.5f, 0f, 13f)),
            new Animal(2, 3, new Vector3(-2.5f, 0f, 10.5f)),
        },
        new List<Animal>()
        {

        },
    };
}