using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InversKinetic : MonoBehaviour
{
    //private bool printed = false;
    List<InversKineticChain> chains = new List<InversKineticChain>();

    // Create as many chains needed for the skeleton
    void createChainsFrom(Transform startPoint, Transform parentPoint = null){
        Transform actualT = startPoint; 
        do {
            actualT = actualT.GetChild(0);
        } while(actualT.childCount==1 && actualT.GetChild(0).name != "Target");
        if(parentPoint == null) {
            //Debug.Log("Creating chain from "+startPoint.name+" to "+actualT.name);
            chains.Add(new InversKineticChain(actualT, startPoint));
        } else {
            //Debug.Log("Creating chain from "+parentPoint.name+" to "+actualT.name);
            chains.Add(new InversKineticChain(actualT, parentPoint));
        }
        for(int i=0;i<actualT.childCount;++i){
            if(actualT.GetChild(0).name != "Target"){
                createChainsFrom(actualT.GetChild(i), actualT);
            }
        }
    }
    void Start()
    {   
        createChainsFrom(this.transform);
    }

    // 
    List<Transform> frabrik(List<Transform> positions, Transform target){
        return null;
    }

    // Update is called once per frame
    void Update()
    {
        foreach (InversKineticChain chain in chains) {
            chain.update();
        }
    }
}
