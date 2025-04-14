using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class TimerManager : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public Transform player;
    private float timer;
    private bool isTiming;
    public GameObject finishPanel;
    public TextMeshProUGUI finalTimeText;
    public string levelName = "Level1";

    private void Update()
    {
        if (isTiming)
        {
            timer += Time.deltaTime;
            UpdateTimerText();
        }
    }

    public void StartTimer()
    {
        timer = 0f;
        isTiming = true;
    }

    public void StopTimer()
    {
        isTiming = false;
        finalTimeText.text = "Final Time: " + timerText.text;
        finishPanel.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        PlayerMovement.Instance.allowCameraMovement = false;


        string bestTimeKey = "BestTime_" + levelName;
        float bestTime = PlayerPrefs.GetFloat(bestTimeKey, float.MaxValue);

        if (timer < bestTime)
        {
            PlayerPrefs.SetFloat(bestTimeKey, timer);
            PlayerPrefs.Save();
            Debug.Log("New Best Time for " + levelName + ": " + timerText.text);
        }
    }

    public void NewGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
        Debug.Log("Uusi peli");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Suljettu");
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

    void UpdateTimerText()
    {
        int minutes = Mathf.FloorToInt(timer / 60F);
        int seconds = Mathf.FloorToInt(timer % 60F);
        int milliseconds = Mathf.FloorToInt((timer * 1000f) % 1000f);
        timerText.text = string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliseconds);
    }
}