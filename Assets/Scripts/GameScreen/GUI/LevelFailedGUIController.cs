using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelFailedGUIController : MonoBehaviour
{
    public Button resetButton;
    public Button quitButton;

    private GameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();

        resetButton.onClick.AddListener(gameManager.ResetGame);
        quitButton.onClick.AddListener(gameManager.QuitGame);
    }
}
