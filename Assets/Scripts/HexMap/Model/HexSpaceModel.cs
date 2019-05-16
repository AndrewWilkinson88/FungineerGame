using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexSpaceModel : MonoBehaviour
{
    private HexMapModel _hexMap;
    private CubeCoordinate _cubeCoordinates;

    public HexSpaceModel(HexMapModel map, CubeCoordinate coordinates)
    {
        _hexMap = map;
        _cubeCoordinates = coordinates;
    }
}
