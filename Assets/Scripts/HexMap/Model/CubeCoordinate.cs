using System.Collections;
using System.Collections.Generic;

public class CubeCoordinate {
    //cube x,y,z
    public int x;
    public int y;
    public int z;
    //height
    public int h;

    public CubeCoordinate(int x, int y, int z, int h)
    {
        this.x = x;
        this.y = y;
        this.z = z;
        this.h = h;
    }

    public AxialCoordinate toAxial()
    {
        return new AxialCoordinate(
            this.x, this.z, this.h
            );
    }
}