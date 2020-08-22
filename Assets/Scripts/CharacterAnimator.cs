using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimator : MonoBehaviour
{
    public Sprite[] idleUpFrames;
    public Sprite[] idleDownFrames;
    public Sprite[] idleLeftFrames;
    public Sprite[] idleRightFrames;

    public Sprite[] walkUpFrames;
    public Sprite[] walkDownFrames;
    public Sprite[] walkLeftFrames;
    public Sprite[] walkRightFrames;

    private Sprite[] currentFrames;

    private SpriteRenderer spriteRenderer;

    private float timer = 0f;
    private int frameNumber = 0;
    private float frameRate = 1 / 10f;

    private CharacterAnimationType currentAnimationType;


    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        PlayAnimation(CharacterAnimationType.IdleDown);
    }


    void Update()
    {
        UpdateFrame();    
    }


    private void UpdateFrame()
    {
        timer += Time.deltaTime;    

        if (timer >= frameRate) {
            timer -= frameRate;

            frameNumber = (frameNumber + 1) % currentFrames.Length;

            spriteRenderer.sprite = currentFrames[frameNumber];
        }
    }


    public void PlayAnimation(CharacterAnimationType animationType)
    {
        timer = 0;
        frameNumber = 0;
        currentAnimationType = animationType;

        switch (animationType) {
            case CharacterAnimationType.IdleUp: {
                currentFrames = idleUpFrames;
                break;
            }
            case CharacterAnimationType.IdleDown: {
                currentFrames = idleDownFrames;
                break;
            }
            case CharacterAnimationType.IdleLeft: {
                currentFrames = idleLeftFrames;
                break;
            }
            case CharacterAnimationType.IdleRight: {
                currentFrames = idleRightFrames;
                break;
            }
            case CharacterAnimationType.WalkUp: {
                currentFrames = walkUpFrames;
                break;
            }
            case CharacterAnimationType.WalkDown: {
                currentFrames = walkDownFrames;
                break;
            }
            case CharacterAnimationType.WalkLeft: {
                currentFrames = walkLeftFrames;
                break;
            }
            case CharacterAnimationType.WalkRight: {
                currentFrames = walkRightFrames;
                break;
            }
        }
    }


    public void SetAnimation(Vector3 direction)
    {
        if (direction.x == 0 && direction.y == 0) {
            if (currentAnimationType == CharacterAnimationType.WalkUp) {
                PlayAnimation(CharacterAnimationType.IdleUp);
            } else if (currentAnimationType == CharacterAnimationType.WalkDown) {
                PlayAnimation(CharacterAnimationType.IdleDown);
            } else if (currentAnimationType == CharacterAnimationType.WalkLeft) {
                PlayAnimation(CharacterAnimationType.IdleLeft);
            } else if (currentAnimationType == CharacterAnimationType.WalkRight) {
                PlayAnimation(CharacterAnimationType.IdleRight);
            }
        } else if (direction.x > 0) {
            PlayAnimation(CharacterAnimationType.WalkRight);
        } else if (direction.x < 0) {
            PlayAnimation(CharacterAnimationType.WalkLeft);
        } else if (direction.y > 0) {
            PlayAnimation(CharacterAnimationType.WalkUp);
        } else if (direction.y < 0) {
            PlayAnimation(CharacterAnimationType.WalkDown);
        }
    }
}
