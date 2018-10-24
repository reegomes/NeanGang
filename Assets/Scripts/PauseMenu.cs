using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{
    public GameObject pausePanel;
    [SerializeField]
    public bool onPause;

    public void Pause()
    {
        Time.timeScale = 0.0f;
        pausePanel.SetActive(true);
        onPause = true;
    }
    public void GoToLobby()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }
    public void MainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
    public void ContinueGame()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
		onPause = false;
    }
    private void FixedUpdate()
    {
        if(onPause == true)
        {
            Pause();
        }
        if(onPause == false)
        {
            ContinueGame();
        }
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Joystick1Button7) || Input.GetKeyDown(KeyCode.Joystick2Button7) || Input.GetKeyDown(KeyCode.Joystick3Button7) || Input.GetKeyDown(KeyCode.Joystick4Button7))
        {
            onPause = !onPause;
        }
    }
}