using System.Collections;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public float rotationAngle = 135;
    public float rotationSpeed = 45.0f; // Degrees per second
    public float openAngle = 90; // The angle at which the door should stay open
    public GameObject interactPrompt;
    private bool detectCollision = true;

    public timerScript timer;

    public AudioSource doorLockSound;
    public AudioSource doorUnlockSound;

    private bool playerInRange = false;
    private bool isRotating = false;

    public GameObject endingText;

    public Transform doorModel;

    public passcodeText passcode;

    private Quaternion initialRotation;

    void Start()
    {
        initialRotation = doorModel.rotation;
    }

    private void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E) && !isRotating)
        {
            if(passcode.doorUnlocked)
            {
                StartCoroutine(RotateDoor());
            }
            else
            {
                doorLockSound.Play();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && detectCollision)
        {
            interactPrompt.SetActive(true);
            playerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && detectCollision)
        {
            interactPrompt.SetActive(false);
            playerInRange = false;
        }
    }

    private IEnumerator RotateDoor()
    {

        doorUnlockSound.Play();
        detectCollision = false;
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
        endingText.SetActive(true);

        timer.StopTimer();

        Destroy(this);
    }
}
