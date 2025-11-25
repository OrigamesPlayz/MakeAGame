using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class END : MonoBehaviour
{
    public Animator endAnim;
    public GameObject quitButton;
    public PlayerMovement playerMove;
    public CameraSwitch camSwitch;
    public ResetCharacter resetCh;
    public PlayerCam playerCam;
    public StopWatch stopwatch;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            endAnim.SetTrigger("END");
            stopwatch.stopwatchActive = false;
            StartCoroutine(ENDBUTTON());
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            playerMove.enabled = false;
            camSwitch.enabled = false;
            resetCh.enabled = false;
            playerCam.enabled = false;
        }
    }

    IEnumerator ENDBUTTON()
    {
        yield return new WaitForSeconds(0.67f);
        quitButton.SetActive(true);
    }
}
