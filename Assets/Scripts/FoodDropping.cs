using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoodDropping : MonoBehaviour
{
    [SerializeField] float startForce = 50f;
    [SerializeField] float minGravScale = 5f;
    [SerializeField] float maxGravScale = 15f;
    [SerializeField] GameObject wordPrefab;

    Rigidbody2D rb;

    void Start() 
    {
        float gravScale = Random.Range(minGravScale, maxGravScale);
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up * startForce, ForceMode2D.Impulse);
        rb.gravityScale = gravScale;

        Text prefabText = wordPrefab.GetComponentInChildren<Text>();
        prefabText.text = GetRandomCharA2Z().ToString();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player") 
        {
            Debug.Log("You caught a food");
            Destroy(gameObject);
        }
        else if (other.tag == "AreaDestroyer")
        {
            Destroy(gameObject);
        }
    }

    char GetRandomCharA2Z()
    {
        return (char)Random.Range('A', 'Z');
    }
}
