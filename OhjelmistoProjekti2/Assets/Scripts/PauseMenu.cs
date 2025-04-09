using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;

    void Start()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1.0f;
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            OpenImage();
        }
    }

    void OpenImage()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;

        // Unlock and show cursor
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        // Disable camera look
        PlayerMovement.Instance.allowCameraMovement = false;
    }

    public void CloseImage()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;

        // Lock and hide cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        // Re-enable camera look
        PlayerMovement.Instance.allowCameraMovement = true;
    }

    public void NewGame()
    {
        SceneManager.LoadScene("GameOne", LoadSceneMode.Single);
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
}