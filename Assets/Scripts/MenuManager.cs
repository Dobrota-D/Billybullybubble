using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject howToPlayPanel;
    [SerializeField] private GameObject creditsPanel;
    [SerializeField] private GameObject menuPanel;

    public void PlayGame()
    {
        SceneManager.LoadScene("LVL1");
    }

    public void HowToPlay()
    {
        howToPlayPanel.SetActive(true);
        menuPanel.SetActive(false);

    }

    public void CloseHowToPlay()
    {
        howToPlayPanel.SetActive(false);
        menuPanel.SetActive(true);
    }

    public void Credits()
    {
        creditsPanel.SetActive(true);
        menuPanel.SetActive(false);
    }

    public void CloseCredits()
    {
        creditsPanel.SetActive(false);
        menuPanel.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
