using UnityEngine;

public class Cell : MonoBehaviour
{
    private CellType _currentCellType;

    public void SetType(CellType type)
    {
        _currentCellType = type;
    }
}