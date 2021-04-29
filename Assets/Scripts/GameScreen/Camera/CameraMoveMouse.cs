using UnityEngine;

public class CameraMoveMouse : MonoBehaviour
{
    public float moveSpeed;

    private GameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        if (gameManager.IsRunning())
        {
            if (Input.GetMouseButton(0))
            {
                if (Input.GetAxis("Mouse X") > 0 || Input.GetAxis("Mouse X") < 0)
                {
                    transform.position -= new Vector3(Input.GetAxisRaw("Mouse X") * Time.deltaTime * moveSpeed,
                                                      Input.GetAxisRaw("Mouse Y") * Time.deltaTime * moveSpeed);
                }
            }
        }
    }
}
