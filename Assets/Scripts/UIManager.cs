using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class UIManager : MonoBehaviour
{
    //Game
    [SerializeField] Image healthImage;
    [SerializeField] Sprite[] healthSprites;
    [SerializeField] TMP_Text scoreText;
    [SerializeField] TMP_Text highScoreText;
    [SerializeField] GameObject pausePanel;
    [SerializeField] GameObject gameOverPanel;
    public void LoadScene(int sceneNumer)
    {
        SceneManager.LoadScene(sceneNumer);
    }

    public void UpldateHealthUI(int currentHealth)
    {
        healthImage.sprite = healthSprites[currentHealth];
    }


    public void UpdateScore(int currentScore)
    {
        scoreText.text = "Score: " + currentScore;
    }

    public void UpdateHighScore(int currentScore)
    {
        highScoreText.text = "High Score: " + currentScore;
    }

    public void DisplayPausePanel(bool value)
    {
        pausePanel.SetActive(value);
    }

    public void DisplayGameOverPanle(bool value) {
        gameOverPanel.SetActive(value);
    }


}