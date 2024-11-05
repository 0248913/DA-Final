using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Vector2 movement;
    private Animator animator;
    private Rigidbody2D rb;
    private Characterselection selection; 

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>(); 
        selection = GetComponent<Characterselection>(); 

        
        selection.LoadCharacterSelection();
        int CharacterNum = selection.GetSelectedCharacterNum();

       
        ChangeSprite(CharacterNum);

       
        TriggerIdleAnimation(CharacterNum);
    }

    void Update()
    {
        
        if (!DialogueManager.GetInstance().DialogueIsPlaying)
        {
           
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");

           
            UpdateAnimation();
        }
        else
        {
           
            movement = Vector2.zero; 
        }
    }

    void UpdateAnimation()
    {
        int CharacterNum = selection.GetSelectedCharacterNum(); 

       
        if (movement != Vector2.zero)
        {
          
            if (movement.y > 0) // u
            {
                animator.Play("player" + CharacterNum + "_walkB"); 
            }
            else if (movement.y < 0) // d
            {
                animator.Play("player" + CharacterNum + "_walk"); 
            }
            else if (movement.x > 0) // r
            {
                animator.Play("player" + CharacterNum + "_walkR"); 
            }
            else if (movement.x < 0) // l
            {
                animator.Play("player" + CharacterNum + "_walkL"); 
            }
        }
        else
        {
           
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("player" + CharacterNum + "_walkB"))
            {
                animator.Play("player" + CharacterNum + "_idleB");
            }
            else if (animator.GetCurrentAnimatorStateInfo(0).IsName("player" + CharacterNum + "_walk"))
            {
                animator.Play("player" + CharacterNum + "_idle");
            }
            else if (animator.GetCurrentAnimatorStateInfo(0).IsName("player" + CharacterNum + "_walkR"))
            {
                animator.Play("player" + CharacterNum + "_idleR"); 
            }
            else if (animator.GetCurrentAnimatorStateInfo(0).IsName("player" + CharacterNum + "_walkL"))
            {
                animator.Play("player" + CharacterNum + "_idleL"); 
            }
        }
    }

    void FixedUpdate()
    {
      
        if (!DialogueManager.GetInstance().DialogueIsPlaying)
        {
            Vector2 newPosition = rb.position + movement * moveSpeed * Time.fixedDeltaTime;
            rb.MovePosition(newPosition);
        }
    }

   
    private void ChangeSprite(int CharacterNum)
    {
    
    }

    private void TriggerIdleAnimation(int CharacterNum)
    {
      
        animator.Play("player" + CharacterNum + "_idle"); 
        Debug.Log("Idle animation triggered for character: " + CharacterNum);
    }
}
