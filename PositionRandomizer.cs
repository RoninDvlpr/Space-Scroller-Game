using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionRandomizer : MonoBehaviour
{
    [SerializeField] float minXPos, maxXPos, minYPos, maxYPos;

    public void RandomizePosition()
    {
        transform.Translate( new Vector2(Random.Range(minXPos, maxXPos), Random.Range(minYPos, maxYPos)) );
    }
}
