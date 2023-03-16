using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float worldSizeHight;
    public float worldSizeWidth;
    [SerializeField] private int score;
    [SerializeField] int highScore;
    UIManager uIManager;

    private void Awake()
    {
        worldSizeHight = Camera.main.orthographicSize;
        worldSizeWidth = Camera.main.orthographicSize * Camera.main.aspect;
    }

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("HighScore")) {
            highScore = PlayerPrefs.GetInt("HighScore");
        } else {
            PlayerPrefs.SetInt("HighScore", 0);
            highScore = 0;
        }
        uIManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        uIManager.UpdateHighScore(highScore);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            PauseGame();
        }
    }

    void PauseGame() {
        uIManager.DisplayPausePanel(true);
        Time.timeScale = 0f;
    }

    public void ResumeGame() {
        uIManager.DisplayPausePanel(false);
        Time.timeScale = 1f;
    }


    public void UpdateScore()
    {
        score++;
        uIManager.UpdateScore(score);
        if (score > highScore)
        {
            UpdateHighScore();
        }
    }

    public void UpdateHighScore() {
        PlayerPrefs.SetInt("HighScore", score);
        uIManager.UpdateHighScore(score);
    }

    public void OnQuitButtonClick()
    {
        Application.Quit();
    }
}
