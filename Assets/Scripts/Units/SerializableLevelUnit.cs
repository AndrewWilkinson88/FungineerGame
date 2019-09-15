using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization;

/// <summary>
/// A class that represents a serializable defenition of a Unit
/// On a specific Level / Map
/// </summary>

[DataContract]
public class SerializableLevelUnit 
{
    [DataMember(Name = "unit")] public string unit { get; set; }
    [DataMember(Name = "position")] public AxialCoordinate position { get; set; }
}
