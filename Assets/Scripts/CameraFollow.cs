using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform place;
    Vector3 difference;

    void Start()
    {
        difference = transform.position - place.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(BallMovement.hasFallen == false){
             transform.position = place.position + difference;
        }
         
    }
}
