using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharDropping : MonoBehaviour
{
    Rigidbody2D rb;
    Text prefabText;
    GameController gameController;

    [SerializeField] float startForce = 50f;
    [SerializeField] float minGravScale = 5f;
    [SerializeField] float maxGravScale = 15f;
    [SerializeField] GameObject wordPrefab;

    void Start()
    {
        InitiateGravity();

        gameController = FindObjectOfType<GameController>();

        Debug.Log("Chosen word: " + gameController.chosenWord);
        SetSymbol();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player") 
        {
            CharCollision();
            
            Destroy(gameObject);
        }
        else if (other.tag == "AreaDestroyer")
        {
            Destroy(gameObject);
        }
    }

    void InitiateGravity()
    {
        float gravScale = Random.Range(minGravScale, maxGravScale);
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up * startForce, ForceMode2D.Impulse);
        rb.gravityScale = gravScale;
    }

    void SetSymbol()
    {
        prefabText = wordPrefab.GetComponentInChildren<Text>();
        prefabText.text = GetRandomCharA2Z().ToString();
    }

    void CharCollision()
    {
        Debug.Log("PrefabText: " + prefabText.text);
        
        if (gameController.chosenWord.Contains(prefabText.text))
        {
            Debug.Log("You caught a proper word");
            
            int i = gameController.chosenWord.IndexOf(prefabText.text);
            if (i != -1)
            {
                // Set new hidden word to everything before the i,
                // change the i to the letter picked up, and everything after the i
                gameController.hiddenWord = gameController.hiddenWord.Substring(0, i) + prefabText.text + gameController.hiddenWord.Substring(i + 1);

                gameController.chosenWord = gameController.chosenWord.Substring(0, i) + "*" + gameController.chosenWord.Substring(i + 1);
            }
            
            gameController.wordToFindField.text = gameController.hiddenWord;
        }
        else 
        {
            gameController.healthIcons[gameController.fails].SetActive(false);
            gameController.fails++;
            Debug.Log("You caught wrong word!");

            if (gameController.fails > 2)
            {
                GameLost();
            }
        }

        if (!gameController.hiddenWord.Contains("*"))
        {
            GameWon();
        }
    }

    void GameLost()
    {
        Debug.Log("You lost the game. :(");
        gameController.lostGame.SetActive(true);
        GlobalValues.foodSliderValue -= 30;

        if (GlobalValues.foodSliderValue < 0)
        {
            GlobalValues.foodSliderValue = 0;
        }

        Time.timeScale = 0;
    }

    void GameWon()
    {
        Debug.Log("Gz! You won the game!");
        gameController.wonGame.SetActive(true);
        GlobalValues.foodSliderValue += 50;

        if (GlobalValues.foodSliderValue > 100)
        {
            GlobalValues.foodSliderValue = 100;
        }

        Time.timeScale = 0;
    }

    char GetRandomCharA2Z()
    {
        return (char)Random.Range('A', 'Z');
    }
}
