using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropdownButton : MonoBehaviour
{
    public GameObject library;
    public Text choice;

    private Dropdown dropdown; // a dropdown list of solutions
    private int dropdownValue;
    private string message;
    private string label = "Choose Puzzle";

    // Start is called before the first frame update
    void Start()
    {
        // Fetch the Dropdown GameObject
        dropdown = GetComponent<Dropdown>();

        // Populate the Dropdown list
        PopulateList();

        if (dropdown != null) {
            // Add listener for when the value of the Dropdown changes, to take action
            dropdown.onValueChanged.AddListener(delegate
            {
                DropdownValueChanged(dropdown);
            });

            // Initialize the choice GameObject to the first value of the Dropdown
            dropdownValue = dropdown.value;
            message = dropdown.options[dropdownValue].text;
            choice.text = "Choice: " + message;
            // For debugging
            Debug.Log(message);
        } else {
            Debug.Log("The Dropdown is null.");
        }
    }

    void PopulateList()
    {
        List<string> choices = new List<string>();
        
        // check to ensure there is a placeholder for the button label
        if (dropdown.options.Capacity == 0)
        {
            choices.Add(label);
        } 
        else 
        {
            choices.Add(dropdown.options[0].text);
        }

        // add all the puzzle solutions into dropdown's options
        int numSolutions = library.gameObject.transform.childCount;
        for (int i = 0; i < numSolutions; i++)
        {
            Transform child = library.gameObject.transform.GetChild(i);
            choices.Add(child.name);
        }
        dropdown.AddOptions(choices);
    }

    // Output the new value of the Dropdown into choice
    void DropdownValueChanged(Dropdown change)
    {
        dropdownValue = dropdown.value;
        message = change.options[dropdownValue].text;
        choice.text = "Choice: " + message;
        // For debugging
        Debug.Log(message);
    }

    // return the current option
    public string solutionName()
    {
        message = dropdown.options[dropdownValue].text;
        return message;
    }
}
