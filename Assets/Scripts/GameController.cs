using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] Text timeField;
    [SerializeField] Text wordToFindField;
    public Text WordToFindField
    {
        get => wordToFindField;
        set => wordToFindField = value;
    }

    float time;
    string[] wordsLocal = { "MATT", "JOANNE", "ROBERT", "MARRY JANE" };
    string chosenWord;
    public string ChosenWord 
    { 
        get => chosenWord;
        set => chosenWord = value; 
    }
    string hiddenWord;
    public string HiddenWord 
    { 
        get => hiddenWord; 
        set => hiddenWord = value;
    }
    int wordIndex;
    // public int WordIndex 
    // { 
    //     get { return wordIndex; } 
    //     set { wordIndex = value; }
    // }
    CharDropping charDropping;

    void Awake()
    {
        charDropping = FindObjectOfType<CharDropping>();
        chosenWord = wordsLocal[Random.Range(0, wordsLocal.Length)];
        HideWord();
    }

    void Update()
    {
        ElapseTime();
    }

    void ElapseTime()
    {
        time += Time.deltaTime;
        timeField.text = time.ToString();
    }

    void HideWord()
    {
        for (int i = 0; i < chosenWord.Length; i++)
        {
            char letter = chosenWord[i];

            if (char.IsWhiteSpace(letter))
            {
                hiddenWord += " ";
            }
            else
            {
                hiddenWord += "_ ";
            }
        }

        wordToFindField.text = hiddenWord;
    }
}
