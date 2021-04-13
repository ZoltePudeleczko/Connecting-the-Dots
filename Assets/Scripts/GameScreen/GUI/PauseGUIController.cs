using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseGUIController : MonoBehaviour
{
    public Button resetButton;
    public Button resumeButton;
    public Button quitButton;

    private GameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();

        resetButton.onClick.AddListener(gameManager.ResetGame);
        resumeButton.onClick.AddListener(gameManager.PauseGame);
        quitButton.onClick.AddListener(gameManager.QuitGame);
    }
}
