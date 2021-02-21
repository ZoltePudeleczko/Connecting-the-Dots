using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineController : MonoBehaviour
{
    public int interpolationFramesCount = 45;

    private GameManager gameManager;

    private int elapsedFrames = 0;
    private Vector3 wantedScale;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();

        wantedScale = transform.localScale;

        GetComponent<BoxCollider2D>().enabled = false;
        StartCoroutine(ScaleLineCoroutine());
    }

    void Update()
    {

    }

    IEnumerator ScaleLineCoroutine()
    {
        for (int i = 0; i <= interpolationFramesCount; i++)
        {
            Vector3 interpolatedScale = Vector3.Lerp(
                new Vector3(wantedScale.x, 0.0f, wantedScale.z),
                wantedScale,
                (float)elapsedFrames / interpolationFramesCount);
            elapsedFrames++;
            transform.localScale = interpolatedScale;
            yield return new WaitForSeconds(0.001f);
        }
        GetComponent<BoxCollider2D>().enabled = true;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.GetComponent<LineController>())
        {
            gameManager.ResetGame();
        }
    }
}
