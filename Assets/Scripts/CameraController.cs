using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float moveSpeed;

    private GameManager gameManager;

    private Vector3 startPosition;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();

        startPosition = transform.position;
    }

    void Update()
    {
        if (gameManager.IsRunning() || gameManager.IsFinished())
        {
            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            {
                transform.Translate(new Vector3(moveSpeed * Time.deltaTime, 0, 0));
            }
            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            {
                transform.Translate(new Vector3(-moveSpeed * Time.deltaTime, 0, 0));
            }
            if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
            {
                transform.Translate(new Vector3(0, -moveSpeed * Time.deltaTime, 0));
            }
            if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
            {
                transform.Translate(new Vector3(0, moveSpeed * Time.deltaTime, 0));
            }
        }
    }

    public void Reset()
    {
        transform.position = startPosition;
    }
}
