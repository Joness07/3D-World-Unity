using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class passcodeText : MonoBehaviour
{
    private static string passcode = "________";
    private TMP_Text codeText;

    private int[] numbers;

    private void Start()
    {
        codeText = GetComponent<TMP_Text>();
        UpdateText(); 
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
    }

}
