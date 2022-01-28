using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallMovement : MonoBehaviour
{
    private Vector3 direction;
    public float moveSPeed;
    private FloorSpawner floorSpawner;
    public static bool hasFallen;
    public float addingSpeed;
    void Start()
    {
       direction = Vector3.forward; 
       floorSpawner = GetComponent<FloorSpawner>();
       
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y <= 0.5f){
           hasFallen = true;
        }
        if(hasFallen == true){
            SceneManager.LoadScene(0);
            return;
            }
        if(Input.GetMouseButtonDown(0)){
             
            if(direction.x ==0){
            direction = Vector3.left;
          }
          else{
            direction = Vector3.forward;
        }
        moveSPeed += addingSpeed*Time.deltaTime;
        }
        
    }

    private void FixedUpdate() {
        Vector3 movement = direction*Time.deltaTime*moveSPeed;
        transform.position += movement;
    }

    private void OnCollisionExit(Collision collision) {
        collision.gameObject.AddComponent<Rigidbody>();
         if(collision.gameObject.tag == "Floor"){
             Score.score++;
          floorSpawner.create_floor();
          StartCoroutine(RemoveFloor(collision.gameObject));
         }
    }

    IEnumerator RemoveFloor(GameObject RemoveFloor){
        yield return new WaitForSeconds(3f);
        Destroy(RemoveFloor);

    }
}
