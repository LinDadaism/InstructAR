using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangePauseButton : MonoBehaviour
{
    private int count = 0;

    // click counter
    public void counter()
    {
        count++;
    }

    // change button text
    public void changeLabel()
    {
        Text buttonText = gameObject.GetComponentInChildren<Text>();
        if (count % 2 == 0)
        {
            buttonText.text = "Pause";
        }
        else
        {
            buttonText.text = "Resume";
        }

    }
}
