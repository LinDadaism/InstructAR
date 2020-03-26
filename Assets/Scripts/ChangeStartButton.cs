using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeStartButton : MonoBehaviour
{
    // change button text after clicks
    public void changeLabel()
    {
        Text buttonText = gameObject.GetComponentInChildren<Text>();
        buttonText.text = "Restart";
    }
}
