using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleAnimator : MonoBehaviour
{
    /*enum State
    {
        BEGIN,
        BLOCK1,
        BLOCK2,
        BLOCK3,
        BLOCK4,
        BLOCK5,
        BLOCK6,
        BLOCK7
    }*/

    public Vector3 p1, p2, p3, p4, p5, p6, p7; // end positions of 7 blocks
    public Vector3 r1, r2, r3, r4, r5, r6, r7; // end rotations of 7 blocks in euler angle
    public float duration = 5; // seconds

    private int numBlocks = 7;
    private Vector3[] startPos;
    private Vector3[] endPos;
    private Quaternion[] startRot;
    private Quaternion[] endRot;

    //private State _state = BEGIN;

    void Start()
    {
        startPos = new Vector3[numBlocks];
        startRot = new Quaternion[numBlocks];
        endRot = new Quaternion[numBlocks];
        endPos = new Vector3[] { p1, p2, p3, p4, p5, p6, p7 };
        Vector3[] endRotEuler = new Vector3[] { r1, r2, r3, r4, r5, r6, r7 };
        
        for (int i = 0; i < numBlocks; i++)
        {
            startPos[i] = new Vector3(i * 5, 0, 0);
            startRot[i] = Quaternion.identity;
            endRot[i] = Quaternion.Euler(endRotEuler[i]);
        }
    }

    void Update()
    {
    }

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

    public Quaternion[] getEndRot()
    {
        return endRot;
    }
}
