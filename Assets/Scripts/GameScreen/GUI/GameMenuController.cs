using UnityEngine;

public class GameMenuController : MonoBehaviour
{
    public GameObject inGameGUI;
    public GameObject pauseGUI;
    public GameObject levelFinishedGUI;
    public GameObject levelFailedGUI;

    private GameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    public void GameStart()
    {
        inGameGUI.SetActive(true);
        pauseGUI.SetActive(false);
        levelFinishedGUI.SetActive(false);
        levelFailedGUI.SetActive(false);
    }

    public void GamePause()
    {
        inGameGUI.SetActive(false);
        pauseGUI.SetActive(true);
        levelFinishedGUI.SetActive(false);
        levelFailedGUI.SetActive(false);
    }

    public void GameFinished()
    {
        inGameGUI.SetActive(false);
        pauseGUI.SetActive(false);
        levelFinishedGUI.SetActive(true);
        levelFailedGUI.SetActive(false);
    }

    public void GameFailed()
    {
        inGameGUI.SetActive(false);
        pauseGUI.SetActive(false);
        levelFinishedGUI.SetActive(false);
        levelFailedGUI.SetActive(true);
    }
}
