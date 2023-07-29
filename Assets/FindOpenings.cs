using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindOpenings : MonoBehaviour
{
    int numberofspawns;
    Transform[] childs;
    Grid g;
    public bool top;
    public bool bottom;
    public bool left;
    public bool right;
    public int number=0;
    float offsetx;
    float offsety;
    public void SetDoors(int i,int j)
    {
        childs = gameObject.GetComponentsInChildren<Transform>();
        g = FindObjectOfType<Grid>();
        foreach (Transform child in childs)
        {
            if (child.tag == "SpawnPoint")
            {
                number++;
                float offsetx = transform.position.x - child.transform.position.x;
                float offsety = transform.position.y - child.transform.position.y;
                if (offsetx <0)
                {
                    g.grid[i, j].rightopen = true;
                    right = true;
                }
                else if (offsetx >0)
                {
                    g.grid[i, j].leftopen = true;
                    left = true;
                }
                if (offsety <0)
                {
                    g.grid[i, j].topopen = true;
                    top = true;
                }
                else if (offsety >0)
                {
                    g.grid[i, j].bottomopen = true;
                    bottom = true;
                }
            }
        }
    }
}
