using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotController : MonoBehaviour
{
    public DotType Type { get; set; }

    private GameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();

        SetDotType();
    }

    void OnMouseDown()
    {
        gameManager.DotClicked(this);
    }

    public void SetDotType(DotType newType = DotType.Idle)
    {
        Type = newType;
        switch (Type)
        {
            case DotType.Idle:
                GetComponent<SpriteRenderer>().color = Color.blue;
                break;
            case DotType.Active:
                GetComponent<SpriteRenderer>().color = Color.red;
                break;
            case DotType.Used:
                GetComponent<SpriteRenderer>().color = Color.yellow;
                break;
        }
    }
}

public enum DotType
{
    Idle,
    Active,
    Used
}