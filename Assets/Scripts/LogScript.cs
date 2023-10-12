using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogScript : MonoBehaviour
{
    public int orderNumber;
    public int logNumber;

    public bool playerInRange = false;

    public passcodeText passcodeScript;

    public InteractPrompt prompt;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            playerInRange = true;
            prompt.gameObject.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            prompt.gameObject.SetActive(false);
        }
    }
    private void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            collectLog();
        }
    }
    private void collectLog()
    {
        prompt.gameObject.SetActive(false);
        passcodeScript.logFound(orderNumber, logNumber);
        gameObject.SetActive(false);
    }
}
