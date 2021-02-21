using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    public Button startGameButton;

    void Start()
    {
        startGameButton.onClick.AddListener(NewGame);
    }

    void Update()
    {
        
    }

    public void NewGame()
    {
        SceneManager.LoadScene("GameScreen");
    }
}
