using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCreator : MonoBehaviour
{
    public int nbWallX = 5;
    public int nbWallY = 5;
    // Start is called before the first frame update
    void Start()
    {
        GameObject brick;
        for(int i=0;i<nbWallX;++i){
            for(int j=0;j<nbWallX;++j){
                brick = GameObject.CreatePrimitive(PrimitiveType.Cube);
                Rigidbody a = brick.AddComponent<Rigidbody>();
                a.useGravity = true;
                brick.transform.position = transform.position + new Vector3(2*i, 2*j, 0);
            }  
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
