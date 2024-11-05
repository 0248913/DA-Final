using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Steal : MonoBehaviour
{
    public Transform player; 
    public float detectionRadius = 5f; 
    public GameObject interactionImage; 
    public float holdDuration = 3f; 
    public PlayerStealth playerStealth; 

    public Item keycardItem;
    private float holdTimer = 0f; 
    private bool isHoldingE = false; 
    private bool isAlerted = false; 

    private void Update()
    {
        float distance = Vector2.Distance(transform.position, player.position);

        
        if (distance <= detectionRadius)
        {
            interactionImage.SetActive(true); 

          
            if (!isAlerted)
            {
               
                if (Input.GetKey(KeyCode.E))
                {
                    isHoldingE = true;
                    holdTimer += Time.deltaTime;

                    if (holdTimer >= holdDuration)
                    {
                        Debug.Log("Success! You held E for 3 seconds.");
                       
                        Inventory.instance.Add(keycardItem);
                        ResetHoldTimer();
                    }
                }
                else
                {
                    ResetHoldTimer(); 
                }
            }
        }
        else
        {
            interactionImage.SetActive(false);
            ResetHoldTimer(); 
        }

        
        if (playerStealth.currentStealthPoints < 5) 
        {
            isAlerted = true;
        }
        else
        {
            isAlerted = false;
        }
    }

    private void ResetHoldTimer()
    {
        holdTimer = 0f; 
        isHoldingE = false;
        
    }
}
