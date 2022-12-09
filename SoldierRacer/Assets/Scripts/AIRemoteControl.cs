using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIRemoteControl : MonoBehaviour
{

    [Header("Input Variables")]
    BasicCarController basicCarController;
    public float forwards = 1;
    public float turn = -1;

    void Awake()
    {
        basicCarController = GetComponent<BasicCarController>();
    }

    void FixedUpdate()
    {
        basicCarController.ChangeSpeed(forwards);
        basicCarController.Turn(turn);
    }
}
