using UnityEngine;

public class Pipe:MonoBehaviour
{
    public float speed = 2.5f;
    public float leftBound = -10f;

    private void Update()
    {
        if (GameManager.Instance == null || GameManager.Instance.IsGameOver) return;
        // Move the pipe to the left
        transform.position += Vector3.left * speed * Time.deltaTime;
        // Check if the pipe has gone out of bounds
        if (transform.position.x < leftBound)
        {
            Destroy(gameObject);
        }
    }
} 
