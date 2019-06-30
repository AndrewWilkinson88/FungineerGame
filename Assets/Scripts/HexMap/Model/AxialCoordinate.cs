
using System.Runtime.Serialization;

[DataContract]
public class AxialCoordinate
{
    //axial
    [DataMember(Name = "x")] public int x { get; set; }
    [DataMember(Name = "z")] public int z { get; set; }
    //height
    [DataMember(Name = "h")] public int h { get; set; }

    public AxialCoordinate(int x, int z, int h)
    {
        this.x = x;
        this.z = z;
        this.h = h;
    }

    public CubeCoordinate toCubeCoordinate()
    {
        return new CubeCoordinate(
                this.x,
                this.z,
                -this.x - this.z,
                this.h
            );
    }
}