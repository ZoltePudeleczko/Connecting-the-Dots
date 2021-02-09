using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private GameState gameState;
    private DotController activeDot = null;

    private List<DotController> allDots = new List<DotController>();

    // Start is called before the first frame update
    void Start()
    {
        CreateLevel("Elo");
        FindDots();
        gameState = GameState.Running;

        Debug.Log(allDots.Count);
    }

    // Update is called once per frame
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
        var lineRenderer = new GameObject("Line").AddComponent<LineRenderer>();
        lineRenderer.startColor = Color.black;
        lineRenderer.endColor = Color.black;
        lineRenderer.startWidth = 0.01f;
        lineRenderer.endWidth = 0.01f;
        lineRenderer.positionCount = 2;
        lineRenderer.useWorldSpace = true;

        lineRenderer.SetPosition(0, activeDot.transform.position);
        lineRenderer.SetPosition(1, secondDot.transform.position);

        activeDot.SetDotType(DotType.Used);
        secondDot.SetDotType(DotType.Active);
        activeDot = secondDot;

        CheckGameStatus();
    }

    private void CheckGameStatus()
    {
        if (allDots.Select(d => d.Type).Count(d => d == DotType.Idle) == 0) // Game finished
        {
            activeDot.SetDotType(DotType.Used);
            gameState = GameState.Finished;
            Debug.Log("Game finished");
        }
    }

    private void ResetGame()
    {
        foreach (DotController dot in allDots)
        {
            dot.SetDotType(DotType.Idle);
        }
        foreach (LineRenderer line in FindObjectsOfType<LineRenderer>())
        {
            Destroy(line);
        }
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