using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{
    
    public GameObject gameOverText;
    public bool gameOver = false;
    public static GameControl instance;
    public float scrollSpeed = -1.5f;
    public Text scoreText;

    private int score = 0;

    void Awake()
    {
        if(instance == null)
        {
           instance = this;
        }
        else if( instance != this)
                 {
                   Destroy(gameObject);
                 }
    }

    void Update()
    {
      if (gameOver == true && Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    // эта функция прибавлят плюс одно очко
    public void BirdScored()
    {
       if(gameOver == true)// проверка жива ли птичка
        {
            return;
        }
        score++; // за слешаи - это коменты,  score = score + 1;
        scoreText.text = "Score: " + score.ToString(); // выводим очки на экран, пользуемся ui текстом
    } 


    public void BirdDied()
    {
        gameOver = true;
        gameOverText.SetActive (true);
    }
}
