using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public float rotationAngle = 90.0f;
    public GameObject interactPrompt;

    public bool playerInRange = false;

    private void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            RotateDoor();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            interactPrompt.SetActive(true);
            playerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            interactPrompt.SetActive(false);
            playerInRange = false;
        }
    }

    private void RotateDoor()
    {
        transform.Rotate(0, rotationAngle, 0);
        interactPrompt.SetActive(false);
        Destroy(this);
    }
}
