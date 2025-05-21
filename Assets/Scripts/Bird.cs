using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Bird : MonoBehaviour
{
    public float jumpForce = 5f;
    public float maxY = 4.5f; // Maximum Y position for the bird
    public float minY = -3.3f; // Minimum Y position for the bird
    private Rigidbody2D rb;
    private bool isDead;
    private bool isGameStarted;
    public GameObject gameController;
    public GameObject gameStartUi;

    private void Awake()
    {
        // Get the Rigidbody2D component 
        rb = GetComponent<Rigidbody2D>();
        isDead = false;
        isGameStarted = false;
        rb.gravityScale = 0; // Disable gravity at the start
    }

    void Update()
    {
        // Check if the bird is dead
        if (isDead) return;

        // Check if the bird goes above the maximum Y position
        if (transform.position.y > maxY)
        {
            Vector3 clampedPos = transform.position;
            clampedPos.y = maxY;
            transform.position = clampedPos;
        }

        // Check if the bird goes below the minimum Y position
        if (transform.position.y < minY && !GameManager.Instance.IsGameOver)
        {
            GameManager.Instance.GameOver();
        }

        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            if (EventSystem.current != null && EventSystem.current.IsPointerOverGameObject())
            {
                return;
            }

            if (!isGameStarted)
            {
                GameManager.Instance.scoreText.enabled = true;
                isGameStarted = true;
                rb.gravityScale = 1;
                gameController.GetComponent<PipeSpawner>().enableSpawn = true;
                gameStartUi.SetActive(false);
            }

            GameManager.Instance.highScoresButton.SetActive(false);
            SoundController.instance.PLaySound("wing", 1f);
            rb.linearVelocity = Vector2.up * jumpForce;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the bird collides with a pipe or the ground
        isDead = true;
        rb.linearVelocity = Vector2.zero;
        rb.gravityScale = 0f;
        rb.bodyType = RigidbodyType2D.Kinematic;
        SoundController.instance.PLaySound("score", 1f);
        GameManager.Instance.GameOver();
    }
}
