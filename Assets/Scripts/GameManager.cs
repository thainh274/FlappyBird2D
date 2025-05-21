using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private bool isGameOver = false;
    public bool IsGameOver => isGameOver; // public getter

    private int score;
    public Text scoreText;

    public GameObject gameOverUi;
    public GameObject playButton;
    public GameObject highScoresButton;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
        scoreText.enabled = false;
        score = 0;
        scoreText.text = score.ToString();
        gameOverUi.SetActive(false);
        playButton.SetActive(false);
        highScoresButton.SetActive(true);
    }

    [System.Obsolete]
    public void GameOver()
    {
        isGameOver = true;
        FindObjectOfType<PipeSpawner>().enableSpawn = false;
        gameOverUi.SetActive(true);
        playButton.SetActive(true);
        //Invoke(nameof(ReloadScene), 2f);
        playButton.GetComponent<Button>().onClick.AddListener(() =>
        {
            ReloadScene();
        });
        HighScoreManager.instance.AddNewScore(score);
    }

    private void ReloadScene()  
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        score = 0; // Reset score
        scoreText.text = score.ToString(); // Update score text
    }

    public void AddScore()
    {
        if (isGameOver) return;
        score++;
        scoreText.text = score.ToString();
    }
}
