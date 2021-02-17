using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineController : MonoBehaviour
{
    public int interpolationFramesCount = 45;
    int elapsedFrames = 0;

    private GameManager gameManager;
    private Vector3 wantedScale;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        wantedScale = transform.localScale;
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
            yield return new WaitForSeconds(0.005f);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.GetComponent<LineController>())
        {
            gameManager.ResetGame();
        }
    }
}
