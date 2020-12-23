using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Scaler
{
    static float defaultAspectRatio = 0.6f;
    static float scaleCoefficient = 0f;
    public static float ScaleCoefficient
    {
        get
        {
            if (scaleCoefficient == 0f)
                CalculateScaleCoefficient();

            return scaleCoefficient;
        }
    }

    static void CalculateScaleCoefficient()
    {
        scaleCoefficient = Camera.main.aspect / defaultAspectRatio;
    }

    public static void ScaleGameObject(GameObject objectToScale)
    {
        objectToScale.transform.localScale *= ScaleCoefficient;
    }

    public static void ScaleMovingObject(MovingObject objectToScale)
    {
        ScaleGameObject(objectToScale.gameObject);
        objectToScale.movementSpeed *= Scaler.ScaleCoefficient;
    }

}
