using UnityEngine;

public class Animal
{
    private readonly int _id;
    private readonly int _itemId;
    private readonly Vector3 _spawnPosition;

    public Animal(int id, int itemId, Vector3 spawnPosition)
    {
        _id = id;
        _itemId = itemId;
        _spawnPosition = spawnPosition;
    }

    public int GetId()
    {
        return _id;
    }

    public int GetItemId()
    {
        return _itemId;
    }

    public Vector3 GetSpawnPosition()
    {
        return _spawnPosition;
    }
}