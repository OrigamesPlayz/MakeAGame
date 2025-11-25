using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    [Header("Cams")]
    public GameObject buildCam;
    public GameObject playerCam;
    private int buildMode;

    [Header("Transition")]
    public Animator camTransitionAnim;
    private bool cooldownOver;

    [Header("Misc")]
    public GameObject invBG;
    public GameObject crosshair;
    public GameObject gridCol;
    public GameObject cubePreview;
    public GameObject cubePreviewR;
    public PlayerMovement playerMove;
    public ResetCharacter resetChar;

    void Start()
    {
        buildCam.SetActive(false);
        playerCam.SetActive(true);
        invBG.SetActive(false);
        crosshair.SetActive(true);
        gridCol.SetActive(false);
        cubePreview.SetActive(false);
        cubePreviewR.SetActive(false);
        buildMode = 1;
        cooldownOver = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B) && cooldownOver)
        {
            buildMode = buildMode * -1;
            camTransitionAnim.SetTrigger("BPressed");
            StartCoroutine(Cooldown());
        }
    }

    IEnumerator Cooldown()
    {
        cooldownOver = false;
        yield return new WaitForSeconds(0.5f);
        if (buildMode == 1)
        {
            buildCam.SetActive(false);
            playerCam.SetActive(true);
            invBG.SetActive(false);
            crosshair.SetActive(true);
            gridCol.SetActive(false);
            cubePreview.SetActive(false);
            cubePreviewR.SetActive(false);
            playerMove.enabled = true;
            resetChar.enabled = true;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        if (buildMode == -1)
        {
            buildCam.SetActive(true);
            playerCam.SetActive(false);
            invBG.SetActive(true);
            crosshair.SetActive(false);
            gridCol.SetActive(true);
            playerMove.enabled = false;
            resetChar.enabled = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        yield return new WaitForSeconds(0.5f);
        cooldownOver = true;
    }
}
