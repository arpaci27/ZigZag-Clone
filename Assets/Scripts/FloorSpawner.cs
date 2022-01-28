using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorSpawner : MonoBehaviour
{
    public GameObject last_floor;
    void Start()
    {
         for (int i = 0; i < 10; i++)
        {
            create_floor();
            
        }
    }

    internal void create_floor(){
        Vector3 direction;
        if(Random.Range(0,2)== 0){
            direction = Vector3.forward;
        }else{
            direction = Vector3.left;
        }

        last_floor = Instantiate(last_floor, last_floor.transform.position+ direction, last_floor.transform.rotation);
    }
}
