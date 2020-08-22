using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private int decisionClock = 0;
    private int decisionTime = 220;

    private float speed = 64f;
    private Vector2 direction = Vector2.zero;

    private CharacterAnimator animator;
    private Rigidbody2D rigidBody;


    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<CharacterAnimator>();
    }


    void Update()
    {
        Tick();
        Move();
    }


    private void Tick()
    {
        decisionClock++;

        if (decisionClock >= decisionTime) {
            decisionClock -= decisionTime;

            direction = GetDirection();
            animator.SetAnimation(direction);
        }    
    }


    private void Move() 
    {
        rigidBody.velocity = Time.deltaTime * speed * direction; 
    }


    private Vector2 GetDirection()
    {
        System.Random random = new System.Random();

        Vector3 newDirection = new Vector3(random.Next(-1, 2), random.Next(-1, 2), 0);
        newDirection = ToIso(newDirection.normalized);

        return newDirection;
    }


    private Vector3 ToIso(Vector3 cartesianVector)
    {
        return new Vector3(
            cartesianVector.x - cartesianVector.y,
            (cartesianVector.x + cartesianVector.y) / 2,
            0
        );
    }
}
