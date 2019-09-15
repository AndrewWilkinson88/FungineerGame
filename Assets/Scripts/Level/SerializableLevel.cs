using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization;


[DataContract]
public class SerializableLevel
{
    [DataMember(Name = "map")] public string map { get; set; }
    [DataMember(Name = "playerStart")] public AxialCoordinate playerStart { get; set; }
    [DataMember(Name = "enemies")] public SerializableLevelUnit[] enemies { get; set; }
}

