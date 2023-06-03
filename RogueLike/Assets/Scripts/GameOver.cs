using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverPanel;

    PauseManager pauseManager;

    private void Start()
    {
        pauseManager = FindObjectOfType<PauseManager>();
    }

    public void PlayerGameOver()
    {
        gameOverPanel.SetActive(true);
        pauseManager.PauseGame();
    }
}
