using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CollisionManager : MonoBehaviour
{
    [SerializeField] UnityEvent starPickedEvent, rocketHitEvent;
    
    void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if (GameManager.State == GameState.Playing)
            if (otherCollider.tag == "Star")
                starPickedEvent?.Invoke();
            else if (otherCollider.tag == "Rocket")
                rocketHitEvent?.Invoke();
    }
}
