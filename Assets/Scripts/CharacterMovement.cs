using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] float movementSpeed = 50f;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        MovePlayer();
    }

    // private void MovePlatform()
    // {
    //     if (Input.touchCount > 0)
    //     {
    //         Touch touch = Input.GetTouch(0);

    //         if (touch.phase == TouchPhase.Moved)
    //         {
    //             Vector2 pos = touch.position;
    //             pos.x = (pos.x - width) / width;
    //             pos.y = (pos.y - height) / height;
    //             position = new Vector2(-pos.x, pos.y);

    //             transform.position = position;
    //         }
    //     }
    // }

    void MovePlayer()
    {
        float move = Input.GetAxis("Horizontal") * movementSpeed * Time.deltaTime;

        transform.position = new Vector2(transform.position.x + move, transform.position.y);
    }
}
