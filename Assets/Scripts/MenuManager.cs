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
        SwitchScene("LVL1");
    }

    public static void SwitchScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
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
