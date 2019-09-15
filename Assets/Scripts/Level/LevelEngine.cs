using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using JsonFx;
using JsonFx.Json;
using JsonFx.Serialization;
using JsonFx.Serialization.Resolvers;

public class LevelEngine : MonoBehaviour
{
    public HexMapView map;
    
    // Start is called before the first frame update
    void Start()
    {
        string levelName = LevelLaunchData.levelName;

        TextAsset levelFile = Resources.Load<TextAsset>("Levels/" + levelName);
        var reader = new JsonReader(new DataReaderSettings(new DataContractResolverStrategy()));
        var level = reader.Read<SerializableLevel>(levelFile.text);
        Debug.Log(map);
        string mapName = level.map;

        map.Initialize(mapName);

        //LaunchData.Army;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
