using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMenuController : MonoBehaviour
{
    public Button pauseGameButton;
    public Button resetGameButton;

    private GameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();

        pauseGameButton.onClick.AddListener(gameManager.PauseGame);
        resetGameButton.onClick.AddListener(gameManager.ResetGame);
    }

    void Update()
    {
        
    }
}
