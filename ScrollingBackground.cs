using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    [SerializeField] float scrollSpeed = 1f;
    [SerializeField] SpriteRenderer spriteRenderer;
    bool scrollEnabled = true;

    void Start()
    {
        Scaler.ScaleGameObject(gameObject);

        SetRandomTextureOffset();
    }

    void Update()
    {
        if (scrollEnabled)
            ScrollTextrure(Time.deltaTime);
    }

    void SetRandomTextureOffset()
    {
        spriteRenderer.material.mainTextureOffset = new Vector2(0, Random.value);
    }

    void ScrollTextrure(float scrollAmount)
    {
        spriteRenderer.material.mainTextureOffset += new Vector2(0, scrollSpeed * scrollAmount);
    }
}
