using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MovingObject
{
    //refferences    
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] Animator animator;
    [SerializeField] GameObject destructionParticlesPrefab;

    //params
    [SerializeField] float delayAfterSpawn = 0f, destroyAnimationDuration = 0f;
    public float DelayAfterSpawn
    {
        get
        {
            return delayAfterSpawn;
        }
    }

    void Update()
    {
        transform.Translate(Vector2.down * movementSpeed * Time.deltaTime, Space.World);
    }

    public void DestroyProjectile()
    {
        if (spriteRenderer.isVisible)  //start animation and vfx
        {
            if (destructionParticlesPrefab != null)
                Instantiate(destructionParticlesPrefab, transform.position, Quaternion.identity);   //spawning particles
            
            if (animator != null)   //if animator was set, triggering destroy animation
                animator.SetTrigger("Destroy");
        }
        
        Destroy(gameObject, destroyAnimationDuration);  //destroying game object with delay to show destroy animation
    }

    void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if (GameManager.State == GameState.Playing)
            DestroyProjectile();
    }
}
