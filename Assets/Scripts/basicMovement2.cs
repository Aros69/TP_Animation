using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basicMovement2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() {
        float movementSpeed = 1.5f;
        if(Input.GetKey(KeyCode.K)){
            transform.position += new Vector3(1 * movementSpeed * Time.deltaTime, 0, 0);
            //print("To the right !");
        }
        if(Input.GetKey(KeyCode.H)){
            transform.position +=  new Vector3(-1 * movementSpeed * Time.deltaTime, 0, 0);
            //print("To the left !");
        }
        if(Input.GetKey(KeyCode.U)){
            transform.position += new Vector3(0, 1 * movementSpeed * Time.deltaTime, 0);
            //print("And we go up !");
        }
        if(Input.GetKey(KeyCode.J)){
            transform.position += new Vector3(0, -1 * movementSpeed * Time.deltaTime, 0);
            //print("And we go down !");
        }
        if(Input.GetKey(KeyCode.O)){
            transform.position += new Vector3(0, 0, 1 * movementSpeed * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.L)){
            transform.position += new Vector3(0, 0, -1 * movementSpeed * Time.deltaTime);
        }
    }
}
