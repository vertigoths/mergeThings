using System.Collections.Generic;
using UnityEngine;

public class Data
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

    public static Material GetMaterialByCell(CellType cellType)
    {
        return CellMaterials[cellType];
    }
}
