using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour
{
    public float movementSpeed;    

    void Start()
    {
        Scaler.ScaleMovingObject(this);
    }

}
