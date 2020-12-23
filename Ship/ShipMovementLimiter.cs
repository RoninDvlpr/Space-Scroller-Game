using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovementLimiter : MonoBehaviour
{
    [SerializeField] bool isLeft = true;

    void Awake()
    {
        SetLimiterPosition();
    }

    void SetLimiterPosition()
    {
        transform.localPosition = new Vector3( Camera.main.orthographicSize * Camera.main.aspect * (isLeft ? -1 : 1),
            0, 0 );
    }
}
