using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization;

[DataContract]
public class SerializableMap 
{
    [DataMember(Name = "tiles")] public int[][][] tiles { get; set; }
}
