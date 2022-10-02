using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    private float pipeGapMin = 1.5f;
    private float pipeGapMax = 1.8f;
    private float pipeGap;

    private float upPipeYPosMax = 1.1f;
    private float upPipeYPos;

    private float downPipeYPosMin = -1.0f;
    private float downPipeYPosMax = -0.4f;
    private float downPipeYPos;
    // Start is called before the first frame update
    void Start()
    {
        setPipePos();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x <= -10.0f)
        {
            transform.Translate(Vector3.right * 40);
            setPipePos();
        }
    }

    private void setPipePos()
    {
        pipeGap = Random.Range(pipeGapMin, pipeGapMax);
        downPipeYPos = Random.Range(downPipeYPosMin, downPipeYPosMax);
        upPipeYPos = downPipeYPos + pipeGap;
        if (upPipeYPos > upPipeYPosMax) upPipeYPos = upPipeYPosMax;

        transform.Find("DownPipe").localPosition = Vector3.up * downPipeYPos;
        transform.Find("UpPipe").localPosition = Vector3.up * upPipeYPos;
    }
}
