using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GeneralScript : MonoBehaviour
{
    public Text scoreText;
    public static bool freezeGame;
    public GameObject gameOver;
    public GameObject youWin;
    public static float top;
    public static float bottom;
    public static float left;
    public static float right;

    public Transform invaderPrefab;
    public int invaderCount = 5;
    public int invaderLeft = 5;
    public int score = 0;


    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Score: " + score;
        freezeGame = false;
        gameOver.GetComponent<SpriteRenderer>().enabled = false;
        youWin.GetComponent<SpriteRenderer>().enabled = false;
        top = Camera.main.orthographicSize;
        bottom = -top;
        right = top*Camera.main.aspect;
        left = -right;

        for (int i = 0; i < invaderCount; i++)
        {
            Instantiate(invaderPrefab, transform.position, transform.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + score;
    }
    public void GameOver()
    {
        gameOver.GetComponent<SpriteRenderer>().enabled = true;
        freezeGame = true;
    }
    public void Shot()
    {
        invaderLeft--;
        score++;
        if (invaderLeft <= 0)
        {
            youWin.GetComponent<SpriteRenderer>().enabled = true;
            freezeGame = true;
        }
    }
}
