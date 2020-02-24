using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block1Anim : MonoBehaviour
{
    public Vector3 startPos = Vector3.zero;
    public Vector3 endPos = new Vector3(14, 1, 12);
    public float duration = 10; //seconds

    private Quaternion startRot = Quaternion.identity;
    private Quaternion endRot = Quaternion.Euler(0, 0, 180);

    void Start()
    {
        //StartCoroutine("AnimateBlock");
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            StartCoroutine("AnimateBlock");
        }
    }

    IEnumerator AnimateBlock()
    {
        for (float time = 0; time < duration; time += Time.deltaTime)
        {
            float u = time / duration; // clamped to range [0,1]
            transform.position = Vector3.Lerp(startPos, endPos, u);
            Debug.Log(transform.position);
            transform.rotation = Quaternion.Slerp(startRot, endRot, u);
            yield return null;
        }
        transform.position = endPos;
        transform.rotation = endRot;
    }
}
