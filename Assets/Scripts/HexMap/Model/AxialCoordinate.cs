using System.Collections;
using System.Collections.Generic;
public class AxialCoordinate
{
    //axial
    public  int x;
    public int z;
    //height
    public int h;

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