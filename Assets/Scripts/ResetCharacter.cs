using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetCharacter : MonoBehaviour
{
    [Header("Reset Target")]
    public Transform targetPosition;
    public Quaternion targetRotation = Quaternion.identity;

    [Header("Reset Speed")]
    [Range(0.1f, 10f)]
    public float resetSpeed = 1f;

    [Header("Smoothness")]
    public AnimationCurve resetCurve;

    public bool isResetting = false;
    private float resetTime = 0f;

    private Vector3 startPos;
    private Quaternion startRot;

    [Header("Misc")]
    public CapsuleCollider playerCol;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && !isResetting)
        {
            StartReset();
        }

        if (isResetting)
        {
            ResetMovement();
            playerCol.enabled = false;
        }

        if (!isResetting)
        {
            playerCol.enabled = true;
        }
    }

    public void StartReset()
    {
        isResetting = true;
        resetTime = 0f;

        startPos = transform.position;
        startRot = transform.rotation;
    }

    void ResetMovement()
    {
        resetTime += Time.deltaTime * resetSpeed;

        float t = resetCurve != null ? resetCurve.Evaluate(resetTime) : resetTime;

        transform.position = Vector3.Lerp(startPos, targetPosition.position, t);
        transform.rotation = Quaternion.Slerp(startRot, targetRotation, t);

        if (resetTime >= 1f)
        {
            isResetting = false;
        }
    }
}
