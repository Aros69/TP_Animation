using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBasicController : MonoBehaviour
{
    private float movementSpeed = 3.0f;
    public float minMovementSpeed = 3.0f;
    public float maxMovementSpeed = 5.0f;
    private float rotationSpeed = 2.0f;
    public float MaxRotationSpeed = 2.0f;

    // Start is called before the first frame update
    void Start() {
        
    }

    public float getMovementSpeed(){
        return movementSpeed;
    }
    public float getRotationSpeed(){
        return rotationSpeed;
    }

    // Update is called once per frame
    void Update() {
        // Recuperation de l'input souris
        //Vector2 mouseInput = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        // Rotation en fonction de la souris
        //transform.Rotate(Vector3.up, mouseInput.x * rotationSpeed);

        
        if(Input.GetKey(KeyCode.Z) || Input.GetKey(KeyCode.W)||Input.GetKey(KeyCode.S)){
            if(Input.GetKey(KeyCode.Space)){
                movementSpeed = maxMovementSpeed;
            } else {
                movementSpeed = minMovementSpeed;
            }
            if(Input.GetKey(KeyCode.Z) || Input.GetKey(KeyCode.W)){
                Vector3 forward_world = transform.TransformDirection(Vector3.forward);
                if(movementSpeed <0){movementSpeed = -movementSpeed;}
                gameObject.GetComponent<CharacterController>().Move(forward_world * movementSpeed * Time.deltaTime);
            }
            if(Input.GetKey(KeyCode.S)){
                Vector3 forward_world = transform.TransformDirection(Vector3.forward);
                if(movementSpeed >0){movementSpeed = -movementSpeed;}
                gameObject.GetComponent<CharacterController>().Move(forward_world * movementSpeed * Time.deltaTime);
            }
        } else {
            movementSpeed = 0.0f;
        }
        if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.A)){
            if(Input.GetKey(KeyCode.D)){
                rotationSpeed = MaxRotationSpeed;
                transform.Rotate(Vector3.up, rotationSpeed);
            }
            if(Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.A)){
                rotationSpeed = -MaxRotationSpeed;
                transform.Rotate(Vector3.up, rotationSpeed);
            }
        } else {
            rotationSpeed = 0.0f;
        }
        
        //gameObject.GetComponent<CharacterController>().Move(forward_world * speed * taTime);
    }
}
