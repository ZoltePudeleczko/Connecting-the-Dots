using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Object linePrefab;

    private GameState gameState;
    private DotController activeDot = null;
    private DotController firstDot = null;

    private List<DotController> allDots = new List<DotController>();

    void Start()
    {
        CreateLevel("Elo");
        FindDots();
        gameState = GameState.Running;

        Debug.Log(allDots.Count);
    }

    void Update()
    {
        if (Input.GetKeyDown("p"))
        {
            PauseGame();
        }
        if (Input.GetKeyDown("r"))
        {
            ResetGame();
        }
    }

    private void CreateLevel(string levelData)
    {

    }

    public void DotClicked(DotController dot)
    {
        if (dot.Type == DotType.Idle && gameState == GameState.Running)
        {
            if (activeDot == null)
            {
                activeDot = dot;
                dot.SetDotType(DotType.Active);
            }
            else
            {
                CreateLine(dot);
            }
        }
    }

    private void FindDots()
    {
        allDots.AddRange(FindObjectsOfType<DotController>());
    }

    private void CreateLine(DotController secondDot)
    {
        if (firstDot is null)
        {
            firstDot = activeDot;
        }
        var dir = secondDot.transform.position - activeDot.transform.position;
        var mid = (dir) / 2.0f + activeDot.transform.position;

        GameObject line = Instantiate(linePrefab, mid, Quaternion.FromToRotation(Vector3.up, dir)) as GameObject;
        line.transform.localScale = new Vector3(0.2f, Vector3.Distance(activeDot.transform.position, secondDot.transform.position) - 2.0f);
        
        activeDot.SetDotType(DotType.Used);
        if (secondDot.Type != DotType.Used)
        {
            secondDot.SetDotType(DotType.Active);
        }
        activeDot = secondDot;

        CheckGameStatus();
    }

    private void CheckGameStatus()
    {
        if (allDots.Select(d => d.Type).Count(d => d == DotType.Idle) == 0) // Game finished
        {
            if (activeDot != firstDot)
            {
                CreateLine(firstDot);
            }
            gameState = GameState.Finished;
            Debug.Log("Game finished");
        }
    }

    public void ResetGame()
    {
        foreach (DotController dot in allDots)
        {
            dot.SetDotType(DotType.Idle);
        }
        foreach (LineController line in FindObjectsOfType<LineController>())
        {
            Destroy(line.gameObject);
        }
        activeDot = null;
        firstDot = null;
        gameState = GameState.Running;
    }

    private void PauseGame()
    {
        if (gameState == GameState.Running)
        {
            gameState = GameState.Paused;
            Debug.Log("paused");
        }
        else if (gameState == GameState.Paused)
        {
            gameState = GameState.Running;
            Debug.Log("running");
        }
    }
}

public enum GameState
{
    Running,
    Paused,
    Finished
}