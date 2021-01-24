using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private DotController activeDot = null;

    // Start is called before the first frame update
    void Start()
    {
        CreateLevel("Elo");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void CreateLevel(string levelData)
    {

    }

    public void DotClicked(DotController dot)
    {
        if (activeDot == null)
        {
            activeDot = dot;
        }
        else
        {
            CreateLine(dot);
        }
    }

    public void CreateLine(DotController secondDot)
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
        activeDot = null;
    }
}
