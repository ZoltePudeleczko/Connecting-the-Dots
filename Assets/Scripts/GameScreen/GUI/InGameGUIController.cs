using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameGUIController : MonoBehaviour
{
    public Button pauseGameButton;

    private GameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();

        pauseGameButton.onClick.AddListener(gameManager.PauseGame);
    }
}
