using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScript : MonoBehaviour
{
    // Menu status
    public enum MenuStates { Welcome, Main };
    public MenuStates currentState;

    // Menu panel objects
    public GameObject welcomeMenu;
    public GameObject mainMenu;

    void Awake()
    {
        // set to welcome screen when script first starts
        currentState = MenuStates.Welcome;
    }

    void Update()
    {
        // checks current menu state
        switch (currentState)
        {
            case MenuStates.Welcome:
                welcomeMenu.SetActive(true);
                mainMenu.SetActive(false);
                break;
            case MenuStates.Main:
                mainMenu.SetActive(true);
                welcomeMenu.SetActive(false);
                break;
        }
    }

    public void onWelcome()
    {
        Debug.Log("go back to welcome!");
        currentState = MenuStates.Welcome;
        // add load level for new scene here
    }

    public void onMainMenu()
    {
        Debug.Log("go to main menu!");
        currentState = MenuStates.Main;
    }
}
