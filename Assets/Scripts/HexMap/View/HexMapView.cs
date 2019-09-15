using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using JsonFx;
using JsonFx.Json;
using JsonFx.Serialization;
using JsonFx.Serialization.Resolvers;

public class HexMapView : MonoBehaviour
{

    //TODO this should eventually be passed into the scene
    //and may not be a TextAsset but actual JSON or a link to the location of a map.
    //public TextAsset mapFile;

    public HexSpaceLibrary spaceLibrary;

    public float tileSize;
    private float lengthToEdge;
    private float xSpace;
    private float ySpace;

    private HexMapModel _mapModel;


    // Start is called before the first frame update
    void Start()
    {
        this.Initialize("testMap");
    }

    public void Initialize(string mapName)
    {
        TextAsset mapFile = Resources.Load<TextAsset>("Maps/" + mapName);

        xSpace =  tileSize * (float)Math.Sqrt(3);
        ySpace = tileSize * 2;

        //Attempt at explicit data parsing
        var reader = new JsonReader(new DataReaderSettings(new DataContractResolverStrategy()));
        var map = reader.Read<SerializableMap>(mapFile.text);
        Debug.Log(map);


        Debug.Log(map.tiles);
        Debug.Log("x size = " + map.tiles.Length + "   y size = " + map.tiles[0].Length);

        _mapModel = new HexMapModel(map.tiles.Length, map.tiles[0].Length);

        HexSpaceView curSpaceView;
        HexSpaceModel curSpaceModel;
        for(int x = 0; x < map.tiles.Length; x++)
        {
            for(int z = 0; z < map.tiles[x].Length; z++)
            {
                for(int h = 0; h < map.tiles[x][z].Length; h++)
                {
                    Debug.Log(map.tiles[x][z][h]);

                    Debug.Log(spaceLibrary.library[map.tiles[x][z][h]]);
                    curSpaceView = Instantiate<HexSpaceView>(spaceLibrary.library[map.tiles[x][z][h]], this.transform);
                    curSpaceView.transform.localPosition = new Vector3(x * xSpace, h * 0.5f, x * xSpace/2.0f + z * ySpace);
                    AxialCoordinate a = new AxialCoordinate(x, z, h);
                    _mapModel.AddSpace(a, map.tiles[x][z][h], curSpaceView);
                    //curSpaceView.transform.localPosition = new Vector3(x * 1.5f, h * 0.5f, x * .85f + z * 1.5f);
                }
            }
        }

        _mapModel.CalculateMoveDirections();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
