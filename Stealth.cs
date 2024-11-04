using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stealth : MonoBehaviour

{
    public Transform player; 
    public float detectionRadius = 5f; 
    public GameObject alertImage; 
    public float alertDurationThreshold = 5f; 
    private float alertTimer = 0f; 

    public PlayerStealth playerStealth;
    public int alertThreshold = 5; 

    private bool isAlerted = false;

    private void Update()
    {
        float distance = Vector2.Distance(transform.position, player.position);

        if (distance <= detectionRadius && playerStealth.currentStealthPoints < playerStealth.maxStealthPoints)
        {
            
            alertImage.SetActive(true);
            float alertRateMultiplier = Mathf.Clamp((playerStealth.maxStealthPoints - playerStealth.currentStealthPoints) / (float)playerStealth.maxStealthPoints, 0.1f, 1f);
            alertTimer += Time.deltaTime * alertRateMultiplier;

            if (alertTimer >= alertDurationThreshold)
            {
                Debug.Log("Player lost! Alert was active too long.");
                alertTimer = 0f; 
            }
        }
        else
        {
            alertImage.SetActive(false);
            alertTimer = 0f; 
        }
    }
}
