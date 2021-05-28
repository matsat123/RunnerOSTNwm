using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameHandler : MonoBehaviour
{
	public GameObject RestartMenuPanel;
	public GameObject Player;
    public static float GameSpeed;
    public int MaxValue = 2000;



    int score = 0;
    bool gameOver = false;

    public static bool slowTime;
    public static bool immortalityBonus;

    public float slowTimeDelay;
    float timeFromSlow;
    public float immortalityDelay;
    float timeFromimmortality;

    public GameObject[] healPointsArray;
    public static bool healthGained;
    public int healthPoints = 3;
    public static bool trapTriggered;



    public void HealthGained()
    {
        if (healthPoints < 3)
        {
            healthPoints++;
            if (healthPoints == 3)
            {
                healPointsArray[2].SetActive(true);
            }
            if (healthPoints == 2)
            {
                healPointsArray[1].SetActive(true);
            }
        }
        healthGained = false;
    }

    public void TrapTriggered()
    {
        healthPoints--;
        if (healthPoints == 2)
        {
            healPointsArray[2].SetActive(false);
        }
        if (healthPoints == 1)
        {
            healPointsArray[1].SetActive(false);
        }
        if (healthPoints == 0)
        {
            healPointsArray[0].SetActive(false);
            gameOver = true;
            Player.SetActive(false);
        }
        trapTriggered = false;
    }

    public void SlowTimeActivated()
    {
        GameSpeed = 2;
        if (timeFromSlow >= slowTimeDelay)
        {
            slowTime = false;
            GameSpeed = 4;
            timeFromSlow = 0;
        }
        timeFromSlow += Time.deltaTime;
    }

    void Start()
    {
		RestartMenuPanel.gameObject.SetActive(false);
		GameSpeed = 4;

        healthGained = false;
        trapTriggered = false;
        slowTime = false;
        immortalityBonus = false;

	}

    
    void Update()
    {
        score++;
        if (score == MaxValue)
        {
            gameOver = true;
        }
        if (gameOver)
		{
			RestartMenuPanel.gameObject.SetActive(true);
            Player.gameObject.SetActive(false);
		}
        if (trapTriggered)
        {
            if (immortalityBonus = false)
            {
                TrapTriggered();
            }
        }
        if (healthGained)
        {
            HealthGained();
        }
    }

	public void RestartButtonClick()
	{
		SceneManager.LoadScene("SampleScene");
	}
    public void ExitButtonClick()
    {
        Application.Quit();
    }

    
}
