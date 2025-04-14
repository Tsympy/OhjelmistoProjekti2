using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject settingsMenu;
    public GameObject creditsMenu;
    public GameObject levelSelectMenu;
    public TextMeshProUGUI level1BestTimeText;
    public TextMeshProUGUI level2BestTimeText;
    public TextMeshProUGUI level3BestTimeText;

    void Start()
    {
        settingsMenu.SetActive(false);
        creditsMenu.SetActive(false);
        levelSelectMenu.SetActive(false);

        ShowBestTime("Level1", level1BestTimeText);
        ShowBestTime("Level2", level2BestTimeText);
        ShowBestTime("Level3", level3BestTimeText);
    }
    void ShowBestTime(string levelName, TextMeshProUGUI targetText)
    {
        string key = "BestTime_" + levelName;
        float bestTime = PlayerPrefs.GetFloat(key, float.MaxValue);
        if (bestTime != float.MaxValue)
        {
            int minutes = Mathf.FloorToInt(bestTime / 60F);
            int seconds = Mathf.FloorToInt(bestTime % 60F);
            int milliseconds = Mathf.FloorToInt((bestTime * 1000f) % 1000f);
            targetText.text = $"{levelName} Best: {minutes:00}:{seconds:00}:{milliseconds:000}";
        }
        else
        {
            targetText.text = $"{levelName} Best: N/A";
        }
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