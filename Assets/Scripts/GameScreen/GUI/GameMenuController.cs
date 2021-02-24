using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMenuController : MonoBehaviour
{
    private GameManager gameManager;

    private InGameGUIController inGameGUI;
    private PauseGUIController pauseGUI;
    private LevelFinishedGUIController levelFinishedGUI;
    private LevelFailedGUIController levelFailedGUI;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();

        inGameGUI = FindObjectOfType<InGameGUIController>();
        pauseGUI = FindObjectOfType<PauseGUIController>();
        levelFinishedGUI = FindObjectOfType<LevelFinishedGUIController>();
        levelFailedGUI = FindObjectOfType<LevelFailedGUIController>();
    }

    public void GameStart()
    {
        inGameGUI.gameObject.SetActive(true);
        pauseGUI.gameObject.SetActive(false);
        levelFinishedGUI.gameObject.SetActive(false);
        levelFailedGUI.gameObject.SetActive(false);
    }

    public void GamePause()
    {
        inGameGUI.gameObject.SetActive(false);
        pauseGUI.gameObject.SetActive(true);
        levelFinishedGUI.gameObject.SetActive(false);
        levelFailedGUI.gameObject.SetActive(false);
    }

    public void GameFinished()
    {
        inGameGUI.gameObject.SetActive(false);
        pauseGUI.gameObject.SetActive(false);
        levelFinishedGUI.gameObject.SetActive(true);
        levelFailedGUI.gameObject.SetActive(false);
    }

    public void GameFailed()
    {
        inGameGUI.gameObject.SetActive(false);
        pauseGUI.gameObject.SetActive(false);
        levelFinishedGUI.gameObject.SetActive(false);
        levelFailedGUI.gameObject.SetActive(true);
    }
}
