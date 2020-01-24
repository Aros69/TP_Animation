using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InversKineticChain
{
    // Target of the first node and target of the last node 
    private Transform rootTarget, lastTarget;
    private Transform target;

    // List of all points, first one is the one who try to reach the target,
    // last one is the root of the chain
    private List<IKJoint> points = new List<IKJoint>();
    // List of all cylinders created to create a nice skeleton
    private List<GameObject> cylinders = new List<GameObject>();


    public InversKineticChain(Transform _lastJoint, Transform _rootJoint) {
        int nbNode = 0;
        Transform actualNode = _lastJoint;
        if(_lastJoint != null){lastTarget = _lastJoint;}
        if(_rootJoint != null){rootTarget = _rootJoint;}
        if(_lastJoint.childCount!=0){target = _lastJoint.GetChild(0);}
        while (actualNode != _rootJoint) {
            points.Add(new IKJoint(actualNode));
            actualNode = actualNode.parent;
            nbNode++;
        }
        points.Add(new IKJoint(actualNode));
        // Creer des cylindres entre les sphere pour obtenir un aspect squelette
        GameObject cylinder;
        for(int i = 0; i < nbNode; ++i){
            cylinder = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            cylinder.transform.localScale = new Vector3(cylinder.transform.localScale.x,
                Vector3.Distance(points[i+1].positionT, points[i].positionT)/2, 
                cylinder.transform.localScale.z);
            cylinder.name = points[i+1].name + "->" + points[i].name;
            cylinders.Add(cylinder);
        }

    }

    private void updateCylinder(){
        for(int i = 0; i < cylinders.Count; ++i){
            cylinders[i].transform.position = (points[i+1].positionT + points[i].positionT)/2;
            cylinders[i].transform.up = points[i+1].positionT - points[i].positionT;
            cylinders[i].transform.localScale = new Vector3(cylinders[i].transform.localScale.x,
                Vector3.Distance(points[i+1].positionT, points[i].positionT)/2, 
                cylinders[i].transform.localScale.z);
        }
    }

    private void fabrik(){
        double lambda, r;
        if(target!=null){
            double dist = Vector3.Distance(points[points.Count-1].positionT, target.position);
            double distMax = 0;
            foreach(IKJoint joint in points){distMax+=joint.distanceParent;}
            //Debug.Log("Distance Target = "+dist+", Distance Max = "+distMax);
            if(dist > distMax){
                //Debug.Log("Position impossible a atteindre");
                for(int i=points.Count-1;i>0;--i){
                    r = Vector3.Distance(target.position, points[i].positionT);
                    lambda = points[i-1].distanceParent/r;
                    points[i-1].SetPosition((float)(1-lambda)*points[i].positionT+(float)lambda*target.position);
                }
            } else {
                //Debug.Log("Position accessible");
                Vector3 intialPosRoot = points[points.Count-1].positionT;
                // On peux ajouter une tolerance de distance pour ne pas recalculer tout le temps
                double difDist = Vector3.Distance(target.position, points[0].position);
                double tolerance = 0.01f;
                int nbIteMax = 1000, nbIte = 0; 
                while(difDist>tolerance && nbIte<nbIteMax){
                    points[0].SetPosition(target.position);
                    for(int i=1;i<points.Count;++i){
                        r = Vector3.Distance(points[i-1].position, points[i].position);
                        lambda = points[i-1].distanceParent/r;
                        points[i].SetPosition((float)(1-lambda)*points[i-1].position+(float)lambda*points[i].position);
                    }
                    points[points.Count-1].SetPosition(intialPosRoot);
                    for(int i=points.Count-1;i>0;--i){
                        r = Vector3.Distance(points[i-1].position, points[i].position);
                        lambda = points[i-1].distanceParent/r;
                        points[i-1].SetPosition((float)(1-lambda)*points[i].position+(float)lambda*points[i-1].position);
                    }
                    difDist = Vector3.Distance(target.position, points[0].position);
                    nbIte++;
                }
                /*if(nbIteMax==nbIte){
                    Debug.LogWarning("On sorts après"+nbIte+" iterations."); 
                }*/
            }

            // On mets les points au bon endroit reelement
            for(int i=0;i<points.Count-1;++i){
                if(i!=0){
                    Vector3 oldP = points[i-1].positionT;
                    points[i].SetRPosition(points[i].position);
                    points[i-1].SetRPosition(oldP);
                } else {
                    Vector3 oldP = target.position;
                    points[i].SetRPosition(points[i].position);
                    target.position = oldP;
                }
            }
        }
    }

    public void update(){
        fabrik();
        updateCylinder();
    }
}
