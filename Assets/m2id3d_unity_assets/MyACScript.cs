using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyACScript : MonoBehaviour
{
    public Transform headTarget;
    public Transform headOrigin;
    private Animator myAnimator;
    // Start is called before the first frame update
    void Start () {
        myAnimator = GetComponent<Animator>();
        Debug.Log("MyAniConScript: start => Animator");
    }
	
    void OnAnimatorIK() {
        if(headTarget!=null && headOrigin!=null) {
            myAnimator.SetLookAtWeight(1);
            myAnimator.SetLookAtPosition(headTarget.position);

        }
    }
	// Update is called once per frame
	void Update () {
        //Debug.Log(GetComponent<CharacterBasicController>().getRotationSpeed()/2);
        myAnimator.SetFloat("VSpeed", GetComponent<CharacterBasicController>().getMovementSpeed()/2);
        myAnimator.SetFloat("RSpeed", GetComponent<CharacterBasicController>().getRotationSpeed()/2);
        //Debug.Log("vSpeed = " + Input.GetAxis("Vertical"));        
    }
}
