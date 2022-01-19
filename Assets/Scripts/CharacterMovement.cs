using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class CharacterMovement : MonoBehaviour
{
    Rigidbody2D rb;

    [SerializeField] float movementSpeed;
    [SerializeField] GameObject player;

    bool rightPointerDown;
    bool leftPointerDown;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        movementSpeed = movementSpeed * Time.fixedDeltaTime;
    }

    void FixedUpdate()
    {
        MoveRight();
        MoveLeft();
    }

    public void MoveCharacterRight(bool _rightPointerDown)
    {
        rightPointerDown = _rightPointerDown;
    }

    public void MoveCharacterLeft(bool _leftPointerDown)
    {
        leftPointerDown = _leftPointerDown;
    }

    void MoveRight()
    {
        if (!rightPointerDown)
        {
            player.transform.Translate(Vector2.left * movementSpeed);
        }
    }

    void MoveLeft()
    {
        if (!leftPointerDown)
        {
            player.transform.Translate(Vector2.right * movementSpeed);
        }
    }
}
