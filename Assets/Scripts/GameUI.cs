using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour {

    private int health;
    private int score;
    private string gameInfo = "";
    public static float timeLeft = 60.0f;
    private Rect boxRect = new Rect(10, 10, 300, 90);
    void OnEnable()
    {
        PlayerBehaviour.OnUpdateHealth += HandleonUpdateHealth;
        AddScore.OnSendScore += HandleonSendScore;
    }
    void OnDisable()
    {
        PlayerBehaviour.OnUpdateHealth -= HandleonUpdateHealth;
        AddScore.OnSendScore -= HandleonSendScore;
    }
    void Start()
    {
        UpdateUI();
        Invoke("PlayerDieTimer", timeLeft);
    }
    void HandleonUpdateHealth(int newHealth)
    {
        health = newHealth;
        UpdateUI();
    }
    void HandleonSendScore(int theScore)
    {
        score += theScore;
        UpdateUI();
    }
    void UpdateUI()
    {
    }
    void OnGUI()
    {
        GUI.Box(boxRect, gameInfo);
    }

    void Update()
    {
        timeLeft -= Time.deltaTime;
        if (WeaponsManager.pistol == true)
        {
            gameInfo = "Score: " + score.ToString() + "\nHealth: " + health.ToString() + "\nTime: " + Mathf.Round(timeLeft) + "\nCurrent Clip: " + ShootBullet.currentClip.ToString();
        }

        else if (WeaponsManager.SMG == true)
        {
            gameInfo = "Score: " + score.ToString() + "\nHealth: " + health.ToString() + "\nTime: " + Mathf.Round(timeLeft) + "\nCurrent Clip: " + ShootBullet.currentClip1.ToString() + "\nSpare Ammo Left: " + ShootBullet.maxAmmo1.ToString();
        }

        else if (WeaponsManager.rifle == true)
        {
            gameInfo = "Score: " + score.ToString() + "\nHealth: " + health.ToString() + "\nTime: " + Mathf.Round(timeLeft) + "\nCurrent Clip: " + ShootBullet.currentClip2.ToString() + "\nSpare Ammo Left: " + ShootBullet.maxAmmo2.ToString();
        }
    }

    void PlayerDieTimer()
    {
        if (timeLeft <= 0)
            SceneManager.LoadScene("Game Over");

    }


}
