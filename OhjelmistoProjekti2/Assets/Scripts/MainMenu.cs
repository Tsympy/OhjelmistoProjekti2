using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class MainMenu : MonoBehaviour
{
    public GameObject settingsMenu;
    public GameObject creditsMenu;
    public GameObject levelSelectMenu;
   
    void Start()
    {
        settingsMenu.SetActive(false);
        creditsMenu.SetActive(false);
        levelSelectMenu.SetActive(false);
    }

    public void LevelMenuOpen()
    {
        levelSelectMenu.SetActive(true);
    }

    public void LevelMenuClose()
    {
        levelSelectMenu.SetActive(false);
    }

    public void PlayGameOne()
    {
        SceneManager.LoadScene("GameOne", LoadSceneMode.Single);
    }
    public void PlayGameTwo()
    {
        SceneManager.LoadScene("GameTwo", LoadSceneMode.Single);
    }
    public void PlayGameThree()
    {
        SceneManager.LoadScene("GameThree", LoadSceneMode.Single);
    }

    public void SettingsOpen()
    {
        settingsMenu.SetActive(true);
    }

    public void SettingsClose()
    {
        settingsMenu.SetActive(false);
    }

    public void CreditsOpen()
    {
        creditsMenu.SetActive(true);
    }

    public void CreditsClose()
    {
        creditsMenu.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Suljettu");
    }
}