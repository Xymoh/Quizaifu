using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] float movementSpeed;
    [SerializeField] GameObject player;
    [SerializeField] Transform character;

    bool rightPointerDown;
    bool leftPointerDown;
    float panelWidth;

    RectTransform parentCanvas;
    Rigidbody2D rb;
    Animator anim;

    void Start()
    {
        InitiateValues();
    }

    void InitiateValues()
    {
        rb = GetComponent<Rigidbody2D>();
        movementSpeed = movementSpeed * Time.fixedDeltaTime;
        parentCanvas = GetComponentInParent<Canvas>().GetComponent<RectTransform>();
        panelWidth = parentCanvas.rect.width;
        anim = GetComponent<Animator>();
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

    public void PlayWaifuAnimation(string animation)
    {
        anim.Play(animation);
    }
}
