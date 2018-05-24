using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour {

    private int score;
    private string gameInfo1 = "";
    private Rect boxRect = new Rect(600, 400, 300, 90);

    private void Start()
    {
        ShootBullet.currentClip = 10;
        ShootBullet.currentClip1 = 30;
        ShootBullet.currentClip2 = 1;
        ShootBullet.maxAmmo1 = 0;
        ShootBullet.maxAmmo2 = 0;
        PlayerBehaviour.health = 100;
    }
    void OnEnable()
    {
        AddScore.OnSendScore += HandleonSendScore;
    }
    void OnDisable()
    {
        AddScore.OnSendScore -= HandleonSendScore;
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
        GUI.Box(boxRect, gameInfo1);
    }

    void Update()
    {
        gameInfo1 = "Score: " + score.ToString();
    }


}
