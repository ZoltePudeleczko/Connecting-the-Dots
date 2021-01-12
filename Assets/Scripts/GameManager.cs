using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject linePrefab;

    private DotController dotFirst;
    private DotController dotSecond;

    // Start is called before the first frame update
    void Start()
    {
        CreateLevel("Elo");

        dotFirst = dotSecond = null;
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
        if (dotFirst == null)
        {
            dotFirst = dot;
        }
        else
        {
            dotSecond = dot;
            CreateLine();
        }
    }

    public void CreateLine()
    {
        Instantiate(linePrefab, new Vector3(0, 0, -5f), Quaternion.identity);
        dotFirst = dotSecond = null;
    }
}
