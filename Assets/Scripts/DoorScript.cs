using System.Collections;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public float rotationAngle = 135;
    public float rotationSpeed = 90.0f; 
    public GameObject interactPrompt;

    private bool playerInRange = false;
    private bool isRotating = false;

    public Transform doorModel;

    public passcodeText passcode;

    private void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E) && !isRotating && passcode.doorUnlocked)
        {
            StartCoroutine(RotateDoor());
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

    private IEnumerator RotateDoor()
    {
        interactPrompt.SetActive(false);
        isRotating = true;
        float currentRotation = doorModel.rotation.eulerAngles.y;
        float targetRotation = currentRotation + rotationAngle;

        while (doorModel.rotation.eulerAngles.y < targetRotation)
        {
            float step = rotationSpeed * Time.deltaTime;
            doorModel.Rotate(Vector3.up, step);
            yield return null;
        }

        isRotating = false;
        Destroy(this);
    }
}
