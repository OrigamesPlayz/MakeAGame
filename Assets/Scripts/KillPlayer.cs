using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    public Transform checkpoint;
    public Transform player;
    public ResetCharacter resetChar;
    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !resetChar.isResetting)
        {
            resetChar.StartReset();
        }
    }
}
