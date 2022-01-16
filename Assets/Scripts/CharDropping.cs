using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharDropping : MonoBehaviour
{
    [SerializeField] float startForce = 50f;
    [SerializeField] float minGravScale = 5f;
    [SerializeField] float maxGravScale = 15f;
    [SerializeField] GameObject wordPrefab;

    Rigidbody2D rb;
    Text prefabText;
    GameController gameController;

    void Start() 
    {
        InitiateGravity();

        gameController = FindObjectOfType<GameController>();

        Debug.Log("Chosen word: " + gameController.ChosenWord);

        prefabText = wordPrefab.GetComponentInChildren<Text>();
        prefabText.text = GetRandomCharA2Z().ToString();
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

    void CharCollision()
    {
        Debug.Log("PrefabText: " + prefabText.text);
        
        if (gameController.ChosenWord.Contains(prefabText.text))
        {
            Debug.Log("You caught a proper word");
            
            int i = gameController.ChosenWord.IndexOf(prefabText.text);
            if (i != -1)
            {
                // Set new hidden word to everything before the i,
                // change the i to the letter picked up, and everything after the i
                gameController.HiddenWord = gameController.HiddenWord.Substring(0, i) + prefabText.text + gameController.HiddenWord.Substring(i + 1);
                // Debug.Log("HiddenWord: " + gameController.HiddenWord);

                gameController.ChosenWord = gameController.ChosenWord.Substring(0, i) + "*" + gameController.ChosenWord.Substring(i + 1);
                // Debug.Log("ChosenWord: " + gameController.ChosenWord);

                // i = gameController.ChosenWord.IndexOf(prefabText.text);
            }
            
            gameController.WordToFindField.text = gameController.HiddenWord;
        }
        else 
        {
            Debug.Log("You caught wrong word!");
        }

        if (!gameController.HiddenWord.Contains("_"))
        {
        //     wintext.SetActive(true);
        //     gameEnd = true;
        }
    }

    char GetRandomCharA2Z()
    {
        return (char)Random.Range('A', 'Z');
    }
}
