using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BinaryCode : MonoBehaviour
{
    public DoorScript doorScript;
    public TextMeshProUGUI originalText;
    public TextMeshProUGUI binaryText;
    public TMP_InputField enterText;
    public TextMeshProUGUI uiText;
    public GameObject Laptop2;
    private string originalMessage = "GET OUT";

    void Start()
    {
        //// Display the original message
        //originalText.text = "Original: " + originalMessage;

        //// Convert the original message to binary
        string binaryMessage = StringToBinary(originalMessage);
        binaryText.text = "Binary: " + binaryMessage;
    }

    public void CheckBinary()
    {
        if(enterText.text==originalMessage)
        {
            Laptop2.tag = "Untagged";
            this.gameObject.SetActive(false);
            doorScript.OpenDoor();
            uiText.text = "The main gate is open.";
        }
    }
    string StringToBinary(string text)
    {
        string binaryResult = "";

        foreach (char c in text)
        {
            // Convert each character to its ASCII value and then to binary
            string binaryChar = System.Convert.ToString(c, 2).PadLeft(8, '0');
            binaryResult += binaryChar + " "; // Separate each binary representation
        }

        return binaryResult.Trim();
    }
}

