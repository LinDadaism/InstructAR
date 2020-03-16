
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SolutionPlayer : MonoBehaviour
{
    public GameObject solution = null;
    public Dropdown dropdown;
    public Text status;

    //private string prevSoln; // stores the previous solution name
    private Vector3[] startPos;
    private Vector3[] endPos;
    private Quaternion[] startRot;
    private Quaternion[] endRot;
    private string dropdownLabel;
    private int numBlocks;
    private float duration;
    private bool isPaused;

    private Vector3 camStartPos;

    void Start()
    {
        dropdownLabel = dropdown.options[0].text;
        isPaused = false;

        chooseSolution();
        initializeSolution();
    }

    void Update()
    {
    }

    // get the solution choice from the Dropdown
    void chooseSolution()
    {
        name = dropdown.GetComponent<DropdownButton>().solutionName();

        if (!name.Equals(dropdownLabel))
        {
            solution = GameObject.Find(name);
        }
    }

    // initialize and get pos & ori of a solution
    void initializeSolution()
    {
        if (solution != null)
        {
            // fetch the script on the PuzzleSolution
            PuzzleAnimator animator = solution.gameObject.GetComponent<PuzzleAnimator>();

            // initialize the PuzzleAnimator
            animator.initialize();

            // get all the pos & ori info of that solution
            numBlocks = animator.getNumPieces();
            duration = animator.duration;
            startPos = animator.getStartPos();
            endPos = animator.endPos;

            Vector3 offset = new Vector3(1.0f, 10.0f, 5.0f);
            for (int i = 0; i < numBlocks; i++)
            {
                endPos[i] = endPos[i] + offset;
            }

            startRot = animator.getStartRot();
            endRot = animator.getEndRotQuat();
        }
        
    }

    void clear()
    {
        solution.gameObject.SetActive(false);
    }

    // stop and clear the animation on screen
    public void onPauseButtonClick()
    {
        if (isPaused == false)
        {
            isPaused = true;
        }
        else
        { 
            isPaused = false;
        }
    }

    // run animation on startButton click
    public void onStartButtonClick()
    {
        //clear();

        // For debugging
        Debug.Log("Start " + solution.gameObject.name);

        if (solution != null)
        {
            isPaused = false;
            StartCoroutine(AnimateSolution());
        }
    }

    IEnumerator AnimateSolution()
    {
        for (int i = 0; i < numBlocks; i++)
        {
            Transform child = solution.gameObject.transform.GetChild(i);
            // show on screen which block is being animated
            float percentage = (float)(i + 1) / numBlocks * 100;
            status.text = "Status: Animating " + child.name + 
                            ", Completeness: " + percentage.ToString("0.00") + " %";

            //float time = 0;
            //while (time < duration)
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

                //time += Time.deltaTime;
            }

            child.position = endPos[i];
            child.rotation = endRot[i];
        }
    }
}
