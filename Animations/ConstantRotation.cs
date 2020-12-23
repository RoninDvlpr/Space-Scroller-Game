using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantRotation : MonoBehaviour
{
    [SerializeField] float minSpeed = 0f, maxSpeed = 10f;
    float rotationSpeed = 0f;
    float RotationSpeed
    {
        get
        {
            if (rotationSpeed == 0f)   //if rotation speed not set
            {
                rotationSpeed = Random.Range(minSpeed, maxSpeed);   //generate random rotation speed value within given boundaries
                
                if (Random.value < 0.5f)    //generating random rotation direction
                    rotationSpeed = -rotationSpeed;  //setting rotation speed sign according to that direction
            }
            
            return rotationSpeed;
        }
    }

    void Update()
    {
        transform.Rotate(0f, 0f, RotationSpeed * Time.deltaTime);
    }
}
