
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

    public static AxialCoordinate operator +(AxialCoordinate a)
    {
        return new AxialCoordinate(-a.x, -a.z, -a.h);
    }

    public static AxialCoordinate operator -(AxialCoordinate a1, AxialCoordinate a2)
    {
        return new AxialCoordinate(a1.x - a2.x, a1.z - a2.z, a1.h - a2.h);
    }

    public static AxialCoordinate operator + (AxialCoordinate a1, AxialCoordinate a2)
    {
        AxialCoordinate a3 = new AxialCoordinate(a1.x+a2.x, a1.z+a2.z, a1.h+a2.h);
        return a3;
    }
}