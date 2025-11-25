using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SelectionBlock : MonoBehaviour
{
    public int amount;
    public TextMeshProUGUI tmpAmount;
    public Button buttonUI;
    public bool active;

    public GameObject cubePrefab;
    public GameObject cubePreview;
    public GameObject cubePreviewR;
    public GameObject buildCam;

    void Start()
    {
        active = false;
    }

    void Update()
    {
        tmpAmount.SetText(amount + "x");

        if (!active) return;

        if (amount > 0 && buildCam.activeSelf)
            if (cubePreview != null)
                cubePreview.SetActive(true);

        if (amount <= 0 && buildCam.activeSelf)
            if (cubePreviewR != null)
                cubePreviewR.SetActive(true);
    }

    public void WhenClicked()
    {
        var gp = FindObjectOfType<GridPlacement>();
        var camS = FindObjectOfType<CameraSwitch>();
        gp.selectBlock = this;

        GameObject[] slots = GameObject.FindGameObjectsWithTag("Slots");

        foreach (GameObject slot in slots)
        {
            SelectionBlock SelectBlock = slot.GetComponent<SelectionBlock>();

            if (SelectBlock != this)
            {
                SelectBlock.active = false;
                if (SelectBlock.cubePreview != null)
                    SelectBlock.cubePreview.SetActive(false);

                if (SelectBlock.cubePreviewR != null)
                    SelectBlock.cubePreviewR.SetActive(false);
            }
        }

        gp.cube = cubePreview;
        gp.cubeRED = cubePreviewR;
        gp.blockPrefab = cubePrefab;

        camS.cubePreview = cubePreview;
        camS.cubePreviewR = cubePreviewR;

        active = true;
    }

}
