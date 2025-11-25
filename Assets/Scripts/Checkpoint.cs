using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public ResetCharacter resetChar;
    public Transform buildCam;
    public Vector3 offset = new Vector3(9.5f, 10.5f, -2.5f);
    private bool complete;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !complete)
        {
            resetChar.targetPosition.position = transform.position;

            KillPlayer[] allKillPlayers = FindObjectsOfType<KillPlayer>();
            foreach (KillPlayer kp in allKillPlayers)
            {
                kp.checkpoint.position = transform.position;
            }

            buildCam.position = transform.position + offset;

            complete = true;
        }
    }
}
