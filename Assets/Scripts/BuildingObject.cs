using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public enum Category
{
    Wall,
    Grass,
    Dirt
}


[CreateAssetMenu (fileName = "Buildable", menuName = "BuildingObjects/Create Buildable")]
public class BuildingObject : ScriptableObject
{
    [SerializeField] Category category;
    [SerializeField] TileBase tilebase;

    public TileBase TileBase
    {
        get
        {
            return tilebase;
        }
    }

    public Category Category
    {
        get
        {
            return category;
        }
    }
}
