using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorTrigger : MonoBehaviour
{
    private bool isColliding = false;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isColliding = true;
            Debug.Log("Player collided with trigger.");
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isColliding = false;
            Debug.Log("Player exited collision with trigger.");
        }
    }

    void Update()
    {
        if (isColliding && Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("Changing scene...");
            SceneManager.LoadScene("StationInside");
        }
    }
}
