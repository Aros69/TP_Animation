using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basicMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() {
        float movementSpeed = 1.5f;
            if(Input.GetKey(KeyCode.D)){
                transform.position += new Vector3(1 * movementSpeed * Time.deltaTime, 0, 0);
                //print("To the right !");
            }
            if(Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.A)){
                transform.position +=  new Vector3(-1 * movementSpeed * Time.deltaTime, 0, 0);
                //print("To the left !");
            }
        if(Input.GetKey(KeyCode.Z) || Input.GetKey(KeyCode.W)){
            transform.position += new Vector3(0, 1 * movementSpeed * Time.deltaTime, 0);
            //print("And we go up !");
        }
        if(Input.GetKey(KeyCode.S)){
            transform.position += new Vector3(0, -1 * movementSpeed * Time.deltaTime, 0);
            //print("And we go down !");
        }
        if(Input.GetKey(KeyCode.R)){
            transform.position += new Vector3(0, 0, 1 * movementSpeed * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.F)){
            transform.position += new Vector3(0, 0, -1 * movementSpeed * Time.deltaTime);
        }
    }
}
