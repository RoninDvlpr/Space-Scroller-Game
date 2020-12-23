using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    //UI objects
    [SerializeField] GameObject mainMenuUI, scoreUI, planetUI, playButton, restartButton, gameOverMenu;
    [SerializeField] UIPlanet planetUIController;
    [SerializeField] float gameOverUIDelay = 0f;

    delegate void MenuToggler();

    public void GameplayUI()
    {
        mainMenuUI.SetActive(false);
        gameOverMenu.SetActive(false);
        scoreUI.SetActive(true);
        planetUIController.Hide();
    }

    public void GameOver()
    {
        StartCoroutine( ToggleMenuWithDelay(GameOverUI, gameOverUIDelay) );
    }

    IEnumerator ToggleMenuWithDelay(MenuToggler menuToToggle, float delay)
    {
        yield return new WaitForSeconds(delay);
        menuToToggle?.Invoke();
    }

    void GameOverUI()
    {
        gameOverMenu.SetActive(true);
        scoreUI.SetActive(false);
        planetUIController.ShowRetryButton();
    }

    public void MenuUI()
    {
        mainMenuUI.SetActive(true);
        scoreUI.SetActive(false);
        planetUIController.ShowPlayButton();
    }
}
