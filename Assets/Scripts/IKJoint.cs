using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class IKJoint
{
    // la position modifiée par l'algo : en fait la somme des positions des sous-branches. 
    // _weight comptera le nombre de sous-branches ayant touchées cette articulation.
    private Vector3 _position;      
    
    // un lien vers le Transform de l'arbre d'Unity
    private Transform _transform;
    
    // un poids qui indique combien de fois ce point a été bougé par l'algo.
    private float _weight = 0.0f;   

    private float _distanceParent = 0.0f;

    public float distanceParent{
        get {
            return _distanceParent;
        }
    }

    public string name
    {
        get
        {
            return _transform.name;
        }
    }
    public Vector3 position     // la position moyenne
    {
        get
        {
            if (_weight == 0.0f) return _position;
            else return _position / _weight;
        }
    }

    public Vector3 positionT
    {
        get
        {
            return _transform.position;
        }
    }

    public Transform transform
    {
        get
        {
            return _transform;
        }
    }

    public Vector3 positionOrigParent
    {
        get
        {
            return _transform.parent.position;
        }
    }

    public IKJoint(Transform t)
    {
        _transform = t;
        _position = t.position;
        _weight = 0;
        if(t.parent!=null){
            _distanceParent = Vector3.Distance(t.position, t.parent.position);
        }
    }

    public void SetPosition(Vector3 p)
    {
        _position = p;
    }

    public void SetRPosition(Vector3 p){
        _transform.position = p;
    }

    public void AddPosition(Vector3 p)
    {
        _position += p;
        _weight++;
    }


    public void ToTransform()
    {
        _position = position/_weight;
        // Est-ce bien l'application de la _position au transform
        _position = _transform.TransformPoint(position);
        _weight = 0;
    }

    public void Solve(IKJoint anchor, float l)
    {
        // TODO : ajoute une position (avec AddPosition) qui repositionne _position à la distance l
        // en restant sur l'axe entre la position et la position de anchor
    }
}