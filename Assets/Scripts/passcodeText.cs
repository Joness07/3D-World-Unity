using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class passcodeText : MonoBehaviour
{
    private static string passcode = "________";
    private TMP_Text codeText;

    private int logsRemaining = 8;
    public bool doorUnlocked;

    private bool hintsVisable = false;


    public GameObject[] hintObjects;

    private void Start()
    {
        codeText = GetComponent<TMP_Text>();
        UpdateText();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.H) && !hintsVisable)
        {
            StartCoroutine(ShowHints());
        }
    }

    private void UpdateText()
    {
        codeText.text = "Passcode:" + passcode;
    }

    public void logFound(int logOrder, int logNumber)
    {
        char[] passcodeArray = passcode.ToCharArray();
        passcodeArray[logOrder - 1] = (char)(logNumber + '0');
        passcode = new string(passcodeArray);
        UpdateText();
        logsRemaining--;
        if (logsRemaining == 0)
        {
            doorUnlocked = true;
        }
    }
    private IEnumerator ShowHints()
    {
        hintsVisable = true;

        for (int i = 0; i < hintObjects.Length; i++)
        {
            hintObjects[i].SetActive(true);
        }

        yield return new WaitForSeconds(3);

        for (int i = 0; i < hintObjects.Length; i++)
        {
            hintObjects[i].SetActive(false);
        }

        hintsVisable = false;
    }

}
