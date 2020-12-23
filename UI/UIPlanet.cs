using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPlanet : MonoBehaviour
{
    [SerializeField] GameObject playButton, retryButton;

    public void ShowPlayButton()
    {
        gameObject.SetActive(true);
        playButton.SetActive(true);
        retryButton.SetActive(false);
    }

    public void ShowRetryButton()
    {
        gameObject.SetActive(true);
        playButton.SetActive(false);
        retryButton.SetActive(true);        
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
