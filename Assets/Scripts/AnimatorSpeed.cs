using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorSpeed : MonoBehaviour
{
    Animator anim;
    public float sliderValue; // controls speed level

    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    void OnGUI()
    {
        // create a label in Game view for the slider
        GUI.Label(new Rect(0, 25, 45, 60), "Speed");

        // create a horizontal slider to control the speed of the animator
        sliderValue = GUI.HorizontalSlider(new Rect(45, 25, 200, 60), sliderValue, 0.0F, 1.0F);

        // make the animator speed match sliderValue
        anim.speed = sliderValue;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
