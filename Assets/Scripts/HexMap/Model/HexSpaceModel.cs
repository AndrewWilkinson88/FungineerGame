using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class HexSpaceModel
{
    private HexMapModel _hexMap;
    private CubeCoordinate _cubeCoordinates;
    public int tileType;

    public HexSpaceModel(HexMapModel map, CubeCoordinate coordinates)
    {
        _hexMap = map;
        _cubeCoordinates = coordinates;
    }
}
