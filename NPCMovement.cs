using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class NPCMovement : MonoBehaviour
{
    public float moveSpeed = 2f; 
    public List<Vector2> movementDirections; 
    private int currentDirectionIndex = 0; 
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        
        if (movementDirections.Count == 0)
        {
            Debug.LogWarning("No directions");
        }
    }

   private void Update()
    {
       
        if (!DialogueManager.GetInstance().DialogueIsPlaying && movementDirections.Count > 0)
        {
            Vector2 moveDirection = movementDirections[currentDirectionIndex];
            transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
            UpdateAnimation(moveDirection); 
        }
        else
        {
            
            PlayIdleAnimation();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log($"Collision detected with: {collision.gameObject.name}");
            ChangeDirection();
        }
    }

    private void ChangeDirection()
    {
      
        currentDirectionIndex = (currentDirectionIndex + 1) % movementDirections.Count; 
    
    }
    private void UpdateAnimation(Vector2 moveDirection)
    {

        if (moveDirection != Vector2.zero)
        {
           
            if (moveDirection.y > 0)
            {
                animator.Play("NPC_walkB"); 
            }
            else if (moveDirection.y < 0)
            {
                animator.Play("NPC_walk"); 
            }
            else if (moveDirection.x > 0) 
            {
                animator.Play("NPC_walkR"); 
            }
            else if (moveDirection.x < 0) 
            {
                animator.Play("NPC_walkL"); 
            }
        }
        else
        {
           
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("NPC_walkB"))
            {
                animator.Play("NPC_idleB");
            }
            else if (animator.GetCurrentAnimatorStateInfo(0).IsName("NPC_walk"))
            {
                animator.Play("NPC_idle"); 
            }
            else if (animator.GetCurrentAnimatorStateInfo(0).IsName("NPC_walkR"))
            {
                animator.Play("NPC_idleR"); 
            }
            else if (animator.GetCurrentAnimatorStateInfo(0).IsName("NPC_walkL"))
            {
                animator.Play("NPC_idleL");
            }
        }
    }
    private void PlayIdleAnimation()
    {
       
        Vector2 moveDirection = movementDirections[currentDirectionIndex];

        if (moveDirection != Vector2.zero)
        {
            if (moveDirection.y > 0)
            {
                animator.Play("NPC_idleB");
            }
            else if (moveDirection.y < 0) 
            {
                animator.Play("NPC_idle");
            }
            else if (moveDirection.x > 0)
            {
                animator.Play("NPC_idleR");
            }
            else if (moveDirection.x < 0)
            {
                animator.Play("NPC_idleL");
            }
        }
    }
}
