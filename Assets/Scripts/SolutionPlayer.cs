using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolutionPlayer : MonoBehaviour
{
    public GameObject solution;

    private int numBlocks;
    private float duration;
    private Vector3[] startPos;
    private Vector3[] endPos;
    private Quaternion[] startRot;
    private Quaternion[] endRot;

    // Get the positions and rotations of 7 pieces
    void Start()
    {
        numBlocks = solution.gameObject.GetComponent<PuzzleAnimator>().getNumPieces();
        duration = solution.gameObject.GetComponent<PuzzleAnimator>().duration;
        startPos = solution.gameObject.GetComponent<PuzzleAnimator>().getStartPos();
        endPos = solution.gameObject.GetComponent<PuzzleAnimator>().getEndPos();
        startRot = solution.gameObject.GetComponent<PuzzleAnimator>().getStartRot();
        endRot = solution.gameObject.GetComponent<PuzzleAnimator>().getEndRot();

        if (startPos != null)
        {
            for (int i = 0; i < numBlocks; i++)
            {
                Debug.Log(endPos[i]);
            }
        }
        else { Debug.Log(solution.gameObject.GetComponent<PuzzleAnimator>()); }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log("start simulation");
            StartCoroutine("AnimateSolution");
        }
    }

    IEnumerator AnimateSolution()
    {
        for (int i = 0; i < numBlocks; i++)
        {
            Transform child = solution.gameObject.transform.GetChild(i);
            Debug.Log(child.name);

            for (float time = 0; time < duration; time += Time.deltaTime)
            {
                float u = time / duration; // clamped to range [0,1]
                child.position = Vector3.Lerp(startPos[i], endPos[i], u);
                child.rotation = Quaternion.Slerp(startRot[i], endRot[i], u);
                yield return null;
            }

            child.position = endPos[i];
            child.rotation = endRot[i];
        }
    }
}
