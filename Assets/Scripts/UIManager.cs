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

}
