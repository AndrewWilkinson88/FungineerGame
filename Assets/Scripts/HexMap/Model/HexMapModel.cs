using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HexMapModel 
{
    public int mapXSize;
    public int mapYSize;
    public int mapHeight;
    private  List<HexSpaceModel>[,] _map;

    public HexMapModel(int mapXSize, int mapYSize, int mapHeight)
    {
        this.mapXSize = mapXSize;
        this.mapYSize = mapYSize;
        this.mapHeight = mapHeight;
        _map = new List<HexSpaceModel>[mapXSize, mapYSize];
    }    

    //TODO add way to load hex map model from file.

    public HexSpaceModel GetSpaceFromCube(CubeCoordinate c)
    {
        return GetSpaceFromAxial(c.toAxial());
    }

    public HexSpaceModel GetSpaceFromAxial(AxialCoordinate c)
    {
        return _map[c.x, c.z][c.h];
    }
}
