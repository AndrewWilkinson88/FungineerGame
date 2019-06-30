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
    public TextAsset mapFile;

    public TileLibrary tiles;

    private HexMapModel _map;

    // Start is called before the first frame update
    void Start()
    {
        //Example of generic JSON parsing
        /*var reader = new JsonReader();
        dynamic output = reader.Read(mapFile.text);
        foreach (string key in output.Keys)
        {
            Debug.Log("key: " + key);
        }
        Debug.Log(output["tiles"][0][0][0]);*/


        //Attempt at explicit data parsing
        var reader = new JsonReader(new DataReaderSettings(new DataContractResolverStrategy()));
        var map = reader.Read<SerializableMap>(mapFile.text);
        Debug.Log(map);


        Debug.Log(map.tiles);
        Debug.Log("x size = " + map.tiles.Length + "   y size = " + map.tiles[0].Length);

        _map = new HexMapModel(map.tiles.Length, map.tiles[0].Length);

        HexSpaceView curSpaceView;
        
        for(int x = 0; x < map.tiles.Length; x++)
        {
            for(int y = 0; y < map.tiles[x].Length; y++)
            {
                for(int h = 0; h < map.tiles[x][y].Length; h++)
                {
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
