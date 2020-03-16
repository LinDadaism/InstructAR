using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleAnimator : MonoBehaviour
{
    public Vector3[] endPos = new Vector3[7]; // end positions of 7 blocks
    public Vector3[] endRot = new Vector3[7]; // end orientations of 7 blocks in euler angle
    public float duration = 1; // in seconds
    
    private int numBlocks = 7;
    private Vector3[] startPos = new Vector3[0];
    private Quaternion[] startRot = new Quaternion[0];
    private Quaternion[] endRotQuat = new Quaternion[0];

    // initialize start positions and orientations and
    // convert end orientation in euler angers to quaternions
    public void initialize()
    {
        startPos = new Vector3[numBlocks];
        startRot = new Quaternion[numBlocks];
        endRotQuat = new Quaternion[numBlocks];

        for (int i = 0; i < numBlocks; i++)
        {
            startPos[i] = new Vector3(i * 5, 0, 0);
            startRot[i] = Quaternion.identity;
            endRotQuat[i] = Quaternion.Euler(endRot[i]);
        }
    }

    // getter methods
    public int getNumPieces()
    {
        return numBlocks;
    }

    public Vector3[] getStartPos()
    {
        return startPos;
    }

    public Vector3[] getEndPos()
    {
        return endPos;
    }

    public Quaternion[] getStartRot()
    {
        return startRot;
    }

    public Vector3[] getEndRot()
    {
        return endRot;
    }

    public Quaternion[] getEndRotQuat()
    {
        return endRotQuat;
    }
}
