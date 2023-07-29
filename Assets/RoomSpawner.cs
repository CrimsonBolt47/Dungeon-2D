using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;


public class RoomSpawner : MonoBehaviour
{
    private RoomTemplate templates;
    private int rand;
    private bool spawned = false;
    Grid g;
    GameObject block;

    public int i;
    public int j;

    public int surroundingopeingss;

    private void Start()
    {
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplate>();
        i = (int)transform.position.x/10;
        j = (int)transform.position.y/10;
        g = FindObjectOfType<Grid>();
        if(spawned==false)
        {
            if(g.grid[i,j].isocuppied==false)
            Invoke("CheckSurrounding", 2f);
        }
     

    }
    public void CheckSurrounding()
    {
        if(i==0||j==0||i==19||j==19)
        {
            Debug.Log("stopped");
            return;
        }

        Debug.Log(g.grid[10, 10].isocuppied +" "+ g.grid[10,10].topopen + " " + g.grid[10, 10].bottomopen + " " + g.grid[10, 10].leftopen + " " + g.grid[10, 10].rightopen);

        if(i==11&&j==11)
        {
            Debug.Log(g.grid[10, 11].leftopen + " " + g.grid[11, 10].topopen);
        }

            if (g.grid[i, j - 1].topopen == true)
            {
                g.grid[i, j].bottomopen = true;
                g.grid[i, j].numberofopenings++;
                Debug.Log(g.grid[i, j - 1].isocuppied +" " + i + (j-1) + " botton open " + i + (j));
            }
            if (g.grid[i, j + 1].bottomopen == true)
            {
                g.grid[i, j].topopen = true;
                g.grid[i, j].numberofopenings++;
                Debug.Log(g.grid[i, j + 1].isocuppied + " top open" + i + (j));
            }   
            if (g.grid[i + 1, j].leftopen == true)
            {
                g.grid[i, j].rightopen = true;
                g.grid[i, j].numberofopenings++;
                Debug.Log(g.grid[i+1, j].isocuppied  + " rightopen" + i + (j));
            }
            if (g.grid[i - 1, j].rightopen == true)
            {
                g.grid[i, j].leftopen = true;
                g.grid[i, j].numberofopenings++;
                Debug.Log(g.grid[i-1, j].isocuppied + " leftopen" + i + (j));
            }
            Spawn();

     

    }

    private void Spawn()
    {
        surroundingopeingss = g.grid[i, j].numberofopenings;
        if(g.grid[i,j].numberofopenings==1)
        {
            if(g.grid[i,j].topopen==true)
            {
                rand = UnityEngine.Random.Range(0, templates.topRooms.Length);
                block = Instantiate(templates.topRooms[rand], transform.position, Quaternion.identity);
                block.GetComponent<FindOpenings>().SetDoors(i,j);
                Debug.Log(transform.position + "/ "+ i + j);
                Destroy(gameObject);
            }
            else if (g.grid[i,j].bottomopen == true)
            {
                rand = UnityEngine.Random.Range(0, templates.bottomRooms.Length);
                block = Instantiate(templates.bottomRooms[rand], transform.position, Quaternion.identity);
                block.GetComponent<FindOpenings>().SetDoors(i,j);
                Debug.Log(transform.position + "/ " + i + j);
                Destroy(gameObject);
            }
            else if (g.grid[i,j].leftopen == true)
            {
                rand = UnityEngine.Random.Range(0, templates.leftRooms.Length);
                block = Instantiate(templates.leftRooms[rand], transform.position, Quaternion.identity);
                block.GetComponent<FindOpenings>().SetDoors(i, j);
                Debug.Log(transform.position + "/ " + i + j);
                Destroy(gameObject);
            }
            else if (g.grid[i,j].rightopen == true)
            {
                rand = UnityEngine.Random.Range(0, templates.rightRooms.Length);
                block = Instantiate(templates.rightRooms[rand], transform.position, Quaternion.identity);
                block.GetComponent<FindOpenings>().SetDoors(i, j);
                Debug.Log(transform.position + "/ " + i + j);
                Destroy(gameObject);
            }
            g.grid[i, j].isocuppied = true;
            spawned = true;
        }
       
    }
}
