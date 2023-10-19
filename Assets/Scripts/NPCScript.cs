using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NPCScript : MonoBehaviour
{
    public TextMeshPro npcText;
    public string[] dialog;
    public float dialogSpeed;
    public float pause = 2;
    public int index;

    public AudioSource speakingSound;

    public Animator anim;

    private Coroutine currentCoroutine;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OpenDialog();
            anim.SetBool("IsTalking", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CloseDialog();
            anim.SetBool("IsTalking", false);
            speakingSound.Stop();
        }
    }

    private void OpenDialog()
    {

        speakingSound.Play();

        index = 0;
        npcText.text = string.Empty;
        npcText.gameObject.SetActive(true);
        currentCoroutine = StartCoroutine(Speak());
    }
    private void CloseDialog()
    {
        npcText.gameObject.SetActive(false);
        StopCoroutine(currentCoroutine);
    }
    private IEnumerator Speak()
    {
        foreach (char c in dialog[index].ToCharArray())
        {
            npcText.text += c;
            yield return new WaitForSeconds(dialogSpeed);
        }

        yield return new WaitForSeconds(pause);
        NextLine();
    }
    private void NextLine()
    {
        index++;

        if (index < dialog.Length)
        {
            npcText.text = string.Empty;
            currentCoroutine = StartCoroutine(Speak());
        }
        else
        {
            speakingSound.Stop();
        }
    }
}
