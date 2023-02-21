using UnityEngine;

public class Food
{
    private readonly int _id;
    private readonly Vector3 _spawnPosition;

    public Food(int id, Vector3 spawnPosition)
    {
        _id = id;
        _spawnPosition = spawnPosition;
    }

    public int GetId()
    {
        return _id;
    }

    public Vector3 GetSpawnPosition()
    {
        return _spawnPosition;
    }
}