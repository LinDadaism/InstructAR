using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangePauseButton : MonoBehaviour
{
    private Text buttonText;
    private int count = 0;

    void Update()
    {
        buttonText = gameObject.GetComponentInChildren<Text>();
    }

    // increase counter
    public void increaseCounter()
    {
        count++;
    }

    // clear counter
    public void clearCounter()
    {
        count = 0;
        buttonText.text = "Pause Animation";
    }

    // change button text
    public void changeLabel()
    {
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
