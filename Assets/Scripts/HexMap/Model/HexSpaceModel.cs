using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class HexSpaceModel
{
    public static Dictionary<Direction, AxialCoordinate> DIRECTION_VECTORS = new Dictionary<Direction, AxialCoordinate> {
            { Direction.NORTH_WEST, new AxialCoordinate(0,-1,0 ) },
            { Direction.NORTH_EAST, new AxialCoordinate(1,-1,0 ) },
            { Direction.EAST, new AxialCoordinate(1,0,0 ) },
            { Direction.SOUTH_EAST, new AxialCoordinate(0,1,0 ) },
            { Direction.SOUTH_WEST, new AxialCoordinate(-1,1,0 ) },
            { Direction.WEST, new AxialCoordinate(-1,0,0 ) },
            { Direction.UP, new AxialCoordinate(0,0,1 ) },
            { Direction.DOWN, new AxialCoordinate(0,0,-1 ) },
        };

    private Dictionary<Direction, AxialCoordinate> _moveDirections = new Dictionary<Direction, AxialCoordinate>();

    private HexMapModel _hexMap;
    private CubeCoordinate _cubeCoordinate;
    private AxialCoordinate _axialCoordinate;
    private HexSpaceView _view;
    private int _tileType;

    public HexSpaceModel(HexMapModel map, AxialCoordinate coordinates, int tileType, HexSpaceView view)
    {
        _hexMap = map;
        _axialCoordinate = coordinates;
        _cubeCoordinate = _axialCoordinate.toCubeCoordinate();
        _view = view;
    }

    public void CalculateMoveDirections()
    {
        _moveDirections[Direction.NORTH_WEST] = _hexMap.GetMovementSpaceFromAxial(_axialCoordinate + DIRECTION_VECTORS[Direction.NORTH_WEST]);
    }
}

public enum Direction
{
    NORTH_WEST,
    NORTH_EAST,
    EAST,
    SOUTH_EAST,
    SOUTH_WEST,
    WEST,
    UP,
    DOWN
}


//TODO tile type is too loosely linked right now, types of tiles should be read in from a JSON
//Separate from map since they will likely be reused.
/*public enum TileType
{
    WATER,
    DIRT,
    GRASS
}*/