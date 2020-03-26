
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SolutionPlayer : MonoBehaviour
{
    public Dropdown dropdown;
    public Button pauseButton;
    public Text status;
    public float duration; // in seconds

    //private string prevSoln; // stores the previous solution name
    private GameObject solution;

    private Vector3[] startPos;
    private Vector3[] endPos;
    private Quaternion[] startRot;
    private Quaternion[] endRot;
    private int numBlocks;
    private bool isPaused; // if animation is in progress
    private bool isPrevDone; // if the previous animation is finished

    void Start()
    {
        if (duration == 0) duration = 3; // set 3 seconds by default
        isPaused = false;
        isPrevDone = true;

    }

    void Update()
    {
        if (chooseSolution())
        {
            initializeSolution();
        }
    }

    // get the solution choice from the Dropdown
    bool chooseSolution()
    {
        string name = dropdown.GetComponent<DropdownButton>().solutionName();
        string dropdownLabel = dropdown.options[0].text;
        // check if the current option is the dropdown label
        if (!(name.Equals(dropdownLabel)))
        {
            solution = GameObject.Find(name);
            return !(solution == null);
        }
        return false;
    }

    // initialize and get pos & ori of a solution
    void initializeSolution()
    {
        // check if a real solution is selected
        if (isPrevDone)
        {
            // fetch the script on the PuzzleSolution
            PuzzleAnimator animator = solution.gameObject.GetComponent<PuzzleAnimator>();

            // initialize the PuzzleAnimator
            animator.initialize();

            // get all the pos & ori info of that solution
            numBlocks = animator.getNumPieces();
            startPos = animator.getStartPos();
            endPos = animator.endPos;

            /*Vector3 offset = new Vector3(1.0f, 10.0f, 5.0f);
            for (int i = 0; i < numBlocks; i++)
            {
                endPos[i] = endPos[i] + offset;
            }*/

            startRot = animator.getStartRot();
            endRot = animator.getEndRotQuat();
        }
        
    }

    /* TODO: clear the animated solution
    void clear()
    {
        solution.gameObject.SetActive(false);
    }*/

    // stop and clear the animation on screen
    public void onPauseButtonClick()
    {
        Text pauseButtonText = pauseButton.gameObject.GetComponentInChildren<Text>();

        if (!isPaused && !(pauseButtonText.text.Equals("Resume")))
        {
            isPaused = true;
        }
        if (isPaused && pauseButtonText.text.Equals("Resume"))
        { 
            isPaused = false;
        }
    }

    // run animation on startButton click
    public void onStartButtonClick()
    {
        //clear();
        
        // sync PauseButton label
        Text pauseButtonText = pauseButton.gameObject.GetComponentInChildren<Text>();
        ChangePauseButton change = pauseButton.gameObject.GetComponent<ChangePauseButton>();

        if (solution != null && isPrevDone)
        {
            // For debugging
            Debug.Log("Start " + solution.gameObject.name);

            isPaused = false;
            change.clearCounter();

            StartCoroutine(AnimateSolution());
        }
    }

    IEnumerator AnimateSolution()
    {
        isPrevDone = false;
        for (int i = 0; i < numBlocks; i++)
        {
            Transform child = solution.gameObject.transform.GetChild(i);
            // show on screen which block is being animated
            float percentage = (float)(i + 1) / numBlocks * 100;
            status.text = "Status: Animating " + child.name + 
                            ", Completeness: " + percentage.ToString("0.00") + " %";

            for (float time = 0; time < duration; time += Time.deltaTime)
            {
                while (isPaused)
                {
                    yield return null;
                }

                float u = time / duration; // clamped to range [0,1]
                child.position = Vector3.Lerp(startPos[i], endPos[i], u);
                child.rotation = Quaternion.Slerp(startRot[i], endRot[i], u);
                yield return null;
            }

            child.position = endPos[i];
            child.rotation = endRot[i];
        }
        isPrevDone = true;
    }
}
