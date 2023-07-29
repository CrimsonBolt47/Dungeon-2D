using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GridRoom
{
    public bool isocuppied;
    public bool topopen;
    public bool bottomopen;
    public bool leftopen;
    public bool rightopen;
    public int numberofopenings;

    public GridRoom()
    {
        isocuppied = false;
        topopen = false;
        bottomopen = false;
        leftopen = false;
        rightopen = false;
        numberofopenings = 0;
    }
    public GridRoom(bool a,bool b,bool c,bool d,bool e,int f)
    {
        isocuppied = a;
        topopen = b;
        bottomopen = c;
        leftopen = d;
        rightopen = e;
        numberofopenings = f;
    }
}
