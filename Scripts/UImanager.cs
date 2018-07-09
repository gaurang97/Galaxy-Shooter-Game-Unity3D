using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UImanager : MonoBehaviour {

    public Sprite[] lives;
    public Image LivesImage;
    public int score;
    public GameObject screenTitle;
    public Text scoretext;
    public void UpdateLives(int currentLives)
    {

        LivesImage.sprite = lives[currentLives];
    }
    public void UpdateScore()
    {
        score = score + 1;
        scoretext.text = "Score: " + score;
    }
    public void show()
    {
        screenTitle.SetActive(true);
    }
    public void hide()
    {
        screenTitle.SetActive(false);
        scoretext.text = "Score: ";
        score = 0;
    }
}
