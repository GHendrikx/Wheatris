using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : Singleton<ScoreManager>
{
    [SerializeField]
    private Text playerScoreText;
    private int playerScore;
    public int PlayerScore
    {
        get
        {
            return playerScore;
        }
        set
        {
            playerScore = value;
        }
    }

    [SerializeField]
    private Text aiScoreText;
    private int aiScore;

    [SerializeField]
    private GameObject endPanel;
    [SerializeField]
    private GameObject aiWin;
    [SerializeField]
    private GameObject playerWin;
    [SerializeField]
    private Button restartButton;

    private void Start()
    {
        restartButton.onClick.AddListener(() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex));
    }

    /// <summary>
    /// Updating the score for the player and the AI.
    /// </summary>
    public void UpdateScore(int _playerScore, int _aiScore)
    {
        playerScore += _playerScore;
        aiScore += _aiScore;
        UpdateGUI();
    }

    private void UpdateGUI()
    {
        playerScoreText.text = string.Format("Player Blocks:\n {0}", playerScore);
        aiScoreText.text = string.Format("AI Blocks:\n {0}", aiScore);
    }

    /// <summary>
    /// If the AI wins the game or the player wins the game this function will be called.
    /// </summary>
    public void ShowEndScreen()
    {
        bool _aiWon = (aiScore > playerScore) ? false : true;
        
        //Setting panel on true 
        endPanel.SetActive(true);

        if (_aiWon)
            aiWin.SetActive(true);
        else
            playerWin.SetActive(true);
    }
}

