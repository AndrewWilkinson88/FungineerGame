using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexMapModel 
{
    public int mapXSize;
    public int mapYSize;
    public int mapHeight;
    private  List<HexSpaceModel>[,] _map;

    public HexMapModel(int mapXSize, int mapYSize)
    {
        this.mapXSize = mapXSize;
        this.mapYSize = mapYSize;
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

    public void AddSpace(AxialCoordinate axialCoordinate, int tileType, HexSpaceView view)
    {
        if(_map[axialCoordinate.x, axialCoordinate.z] == null)
            _map[axialCoordinate.x, axialCoordinate.z] = new List<HexSpaceModel>();
        _map[axialCoordinate.x, axialCoordinate.z].Add( new HexSpaceModel(this, axialCoordinate, tileType, view) );
    }

    public void CalculateMoveDirections()
    {
        for(int x = 0; x < _map.GetLength(0); x++)
        {
            for(int z = 0; z < _map.GetLength(1); z++)
            {
                if (_map[x, z] != null)
                {
                    for (int h = 0; h < _map[x, z].Count; h++)
                    {
                        _map[x, z][h].CalculateMoveDirections();
                    }
                }
            }
        }
    }

    public AxialCoordinate GetMovementSpaceFromAxial(AxialCoordinate a)
    {
        //First do the obvious out of bounds checks
        if (a.x < 0 || a.x >= _map.GetLength(0)
            || a.z < 0 || a.z >= _map.GetLength(1)
            || a.h < 0 || _map[a.x, a.z] == null)
        {
            return null;
        }
        //Next, if we're above the ground significantly in that direction, 
        //skip to the top of that stack to start the search for a valid square
        if(a.h >= _map[a.x, a.z].Count)
        {
            a.h = _map[a.x, a.z].Count - 1;
        }
        

        return a;
    }
}
