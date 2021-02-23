using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    public void Reset()
    {
        transform.position = startPosition;
    }
}
