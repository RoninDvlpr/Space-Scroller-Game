using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXController : MonoBehaviour
{
    [SerializeField] GameObject[] VFXGameObjects;
    [SerializeField] float fvxDisableTime;
    Coroutine disableCoroutine;

    public void EnableVFX(bool enable)
    {
        if (VFXGameObjects != null)
            foreach (GameObject obj in VFXGameObjects)
                obj.SetActive(enable);
        
        if (enable)
            disableCoroutine = StartCoroutine( VFXDisableTimer(fvxDisableTime) );
    }

    IEnumerator VFXDisableTimer(float disableTIme)
    {
        yield return new WaitForSeconds(disableTIme);

        EnableVFX(false);
    }
}
