using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovementController : MovingObject
{
    //refferences
    [SerializeField] Rigidbody2D shipRigidbody;

    //gameplay movement params
    [SerializeField] float mobileSpeedMultiplier;
    Vector2 previousTouchPosition;
    int touchId;

    //animation movement params
    [SerializeField] float yConcealedPosition, yExposedPosition, appearanceAnimationDuration, disappearanceAnimationDelay;
    Coroutine appearanceCoroutine;    
    
    
    void FixedUpdate()
    {
        #if UNITY_EDITOR            
            if (Input.GetKey(KeyCode.LeftArrow))
                AccelerateShipHorizontally(-1f);
            if (Input.GetKey(KeyCode.RightArrow))
                AccelerateShipHorizontally(1f);
        #elif UNITY_ANDROID || UNITY_IOS
            if (Input.touchCount > 0)
                if (Input.touches[0].phase == TouchPhase.Began)
                {
                    previousTouchPosition = Camera.main.ScreenToWorldPoint(Input.touches[0].position);  //if touch began, storing position and id
                    touchId = Input.touches[0].fingerId;
                }
                else if (Input.touches[0].phase == TouchPhase.Moved)
                {
                    Vector2 currentTouchPosition = Camera.main.ScreenToWorldPoint(Input.touches[0].position);
                    if (Input.touches[0].fingerId == touchId)   //if stored previous position belongs to this touch
                        AccelerateShipHorizontally((currentTouchPosition - previousTouchPosition) * mobileSpeedMultiplier); //moving ship
                    else
                        touchId = Input.touches[0].fingerId;    //else just storing this touch position 
                    
                    previousTouchPosition = currentTouchPosition;
                }        
        #endif
    }

    void AccelerateShipHorizontally(float xOffset)
    {
        shipRigidbody.AddForce(new Vector2(xOffset, 0) * movementSpeed);
    }

    void AccelerateShipHorizontally(Vector2 movementVector)
    {
        movementVector.y = 0;
        shipRigidbody.AddForce(movementVector * movementSpeed);
    }

    public void ShowShip(bool show)
    {
        if (appearanceCoroutine != null)
            StopCoroutine(appearanceCoroutine);

        appearanceCoroutine = StartCoroutine( AnimateShipVerticalMovement(show ? yExposedPosition : yConcealedPosition, show ? 0f : disappearanceAnimationDelay) );
    }

    IEnumerator AnimateShipVerticalMovement(float targetYPosition, float movementDelay)
    {
        yield return new WaitForSeconds(movementDelay);

        float startYPosition = transform.position.y;
        float startTime = Time.time;

        while (transform.position.y != targetYPosition)
        {
            float newYPosition = Mathf.Lerp(startYPosition, targetYPosition, (Time.time - startTime) / appearanceAnimationDuration);
            shipRigidbody.MovePosition(new Vector2(transform.position.x, newYPosition));
            yield return new WaitForFixedUpdate();
        }
    }

    IEnumerator AnimateShipMovement(Vector2 targetPosition)
    {
        Vector2 startPosition = transform.position;
        float startTime = Time.time;

        while ((Vector2) transform.position != targetPosition)
        {
            Vector2 newPosition = Vector2.Lerp(startPosition, targetPosition, (Time.time - startTime) / appearanceAnimationDuration);
            shipRigidbody.MovePosition(newPosition);
            yield return new WaitForFixedUpdate();
        }
    }
}
