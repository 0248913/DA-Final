using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerStealth : MonoBehaviour
{
    [Header("Stealth Points")]
    public int currentStealthPoints = 2;
    public int maxStealthPoints = 10; 

    [Header("UI Elements")]
    public UnityEngine.UI.Slider stealthBar; 

    private float holdDuration = 3f; 
    private float holdTimer = 0f;
    private bool isHoldingF = false; 

    private void Start()
    {

        if (stealthBar != null)
        {
            stealthBar.maxValue = maxStealthPoints;
            stealthBar.value = currentStealthPoints;
        }
    }

    private void Update()
    {
       
        if (Input.GetKey(KeyCode.F) && currentStealthPoints >= 2)
        {
            isHoldingF = true;
            holdTimer += Time.deltaTime;

            if (holdTimer >= holdDuration)
            {
                Debug.Log("Win condition achieved!");
                ResetHoldTimer(); 
            }
        }
        else if (Input.GetKeyUp(KeyCode.F) || currentStealthPoints < 2)
        {
         
            ResetHoldTimer();
        }
    }

    private void ResetHoldTimer()
    {
        holdTimer = 0f;
        isHoldingF = false;
    }
}
