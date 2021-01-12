using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotController : MonoBehaviour
{
    public DotType Type;

    private GameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    void Update()
    {

    }

    void OnMouseDown()
    {
        gameManager.DotClicked(this);
    }
}

public enum DotType
{
    Normal,
    Start,
    End
}