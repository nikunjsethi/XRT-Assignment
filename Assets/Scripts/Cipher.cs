using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Cipher : MonoBehaviour
{
    public DoorScript doorScript;
    public TextMeshProUGUI hintText;
    public TextMeshProUGUI reversedText;
    public TMP_InputField EnterText;
    public TextMeshProUGUI uiText;
    public GameObject Laptop;
    private string originalMessage = "HELLO ESCAPE";

    void Start()
    {
        DisplayOriginalAndReversed();
    }

    public void DisplayOriginalAndReversed()
    {
        hintText.text = "Hmmm, things seem a bit backward here. Maybe you should try reading things in the opposite direction?";

        // Reverse the message and display the reversed version
        string reversedMessage = ReverseString(originalMessage);
        reversedText.text = reversedMessage;
    }

    public void CheckText()
    {
        if(EnterText.text == originalMessage)
        {
            Debug.Log("Its working");
            Laptop.tag = "Untagged";
            this.gameObject.SetActive(false);
            doorScript.OpenDoor();
            uiText.text = "Go downstairs and look for another laptop.\nThat will unlock the main door";
        }
        else
        {
            Debug.Log("Not working");
        }
    }
    string ReverseString(string input)
    {
        char[] charArray = input.ToCharArray();
        System.Array.Reverse(charArray);
        return new string(charArray);
    }
}
