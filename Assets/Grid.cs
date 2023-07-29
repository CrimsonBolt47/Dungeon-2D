using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    private static Grid _instance = null;

    public GridRoom[,] grid = new GridRoom[20, 20];
    public static Grid SharedInstance
    {
        get
        {
            if (_instance == null)
                _instance = GameObject.FindObjectOfType(typeof(Grid)) as Grid;
            return _instance;
        }
    }

    void Awake()
    {
        _instance = this;
        for(int i=0;i<20;i++)
        {
            for(int j=0;j<20;j++)
            {
                grid[i, j] = new GridRoom();
            }
        }
        grid[10, 10] = new GridRoom(true, true, true, true, true, 4);
    }
}
