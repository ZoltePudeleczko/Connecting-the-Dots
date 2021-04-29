using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelFinishedGUIController : MonoBehaviour
{
    public Button continueButton;
    public Button quitButton;

    private GameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();

        continueButton.onClick.AddListener(gameManager.QuitGame);
        quitButton.onClick.AddListener(gameManager.QuitGame);
    }
}
