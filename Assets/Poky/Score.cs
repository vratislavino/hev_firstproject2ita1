using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    public event Action<int> ScoreChanged;

    [SerializeField]
    TMPro.TMP_Text scoreText;

    [SerializeField]
    GameObject deathScreen;
    
    [SerializeField]
    TMPro.TMP_Text finalScoreText;

    int currentScore = 0;
    int bestScore = 0;

    void Start()
    {
        scoreText = GetComponent<TMPro.TMP_Text>();
    }

    public void ChangeScore(int amount) {
        currentScore += amount;
        scoreText.text = currentScore.ToString();

        ScoreChanged?.Invoke(currentScore);

        if (currentScore > bestScore) {
            bestScore = currentScore;
        }

        if(currentScore < 0) {
            Die();
        }
    }

    private void Die() {
        deathScreen.SetActive(true);
        finalScoreText.text = bestScore.ToString();
        scoreText.gameObject.SetActive(false);
        Time.timeScale = 0;
    }

    public void Restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }
}
