using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Speed")]
    public float startSpeed = 8f;
    public float maxSpeed = 25f;
    public float speedIncrement = 0.5f;

    [Header("UI")]
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    public TextMeshProUGUI speedText;
    public GameObject mainMenuPanel;
    public GameObject gameOverPanel;
    public TextMeshProUGUI finalScoreText;

    [HideInInspector] public bool isPlaying = false;
    [HideInInspector] public float currentSpeed;

    private float score = 0f;
    private float highScore = 0f;

    void Awake()
    {
        Instance = this;
        highScore = PlayerPrefs.GetFloat("HighScore", 0f);
    }

    void Start()
    {
        ShowMainMenu();
    }

    void Update()
    {
        if (!isPlaying) return;

        score += Time.deltaTime * currentSpeed * 0.1f;
        scoreText.text = "Score: " + Mathf.FloorToInt(score);
        currentSpeed = Mathf.MoveTowards(currentSpeed, maxSpeed, speedIncrement * Time.deltaTime);
        speedText.text = "Speed: " + Mathf.FloorToInt(currentSpeed);
    }

    public void StartGame()
    {
        isPlaying = true;
        score = 0f;
        currentSpeed = startSpeed;
        mainMenuPanel.SetActive(false);
        gameOverPanel.SetActive(false);
        scoreText.gameObject.SetActive(true);
        speedText.gameObject.SetActive(true);
    }

    public void GameOver()
    {
        isPlaying = false;
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetFloat("HighScore", highScore);
        }
        finalScoreText.text = "Score: " + Mathf.FloorToInt(score) + "\nBest: " + Mathf.FloorToInt(highScore);
        gameOverPanel.SetActive(true);
        scoreText.gameObject.SetActive(false);
        speedText.gameObject.SetActive(false);
    }

    public void ShowMainMenu()
    {
        isPlaying = false;
        mainMenuPanel.SetActive(true);
        gameOverPanel.SetActive(false);
        scoreText.gameObject.SetActive(false);
        speedText.gameObject.SetActive(false);
        highScoreText.text = "Best: " + Mathf.FloorToInt(highScore);
    }

    public void RestartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}