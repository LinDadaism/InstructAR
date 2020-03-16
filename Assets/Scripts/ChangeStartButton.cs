using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeStartButton : MonoBehaviour
{
    //public Button startButton;
    public string label; // text to change

    // change button text
    public void changeLabel()
    {
        Text buttonText = gameObject.GetComponentInChildren<Text>();
        buttonText.text = label;
    }
}
