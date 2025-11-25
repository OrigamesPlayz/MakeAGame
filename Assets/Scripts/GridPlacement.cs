using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridPlacement : MonoBehaviour
{
    public GameObject cube, cubeRED, blockPrefab;
    public Grid grid;
    public GridPlaceInput gridInput;
    public SelectionBlock selectBlock;

    void Update()
    {
        if (selectBlock.active || selectBlock.amount > 0)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Vector3 rot = cube.transform.eulerAngles;
                rot.y += 90f;
                cube.transform.rotation = Quaternion.Euler(rot);
            }

            if (Input.GetKeyDown(KeyCode.Q))
            {
                Vector3 rot = cube.transform.eulerAngles;
                rot.y -= 90f;
                cube.transform.rotation = Quaternion.Euler(rot);
            }
        }

        if (!selectBlock.active || selectBlock.amount <= 0)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Vector3 rot = cubeRED.transform.eulerAngles;
                rot.y += 90f;
                cubeRED.transform.rotation = Quaternion.Euler(rot);
            }

            if (Input.GetKeyDown(KeyCode.Q) && !Input.GetKeyDown(KeyCode.LeftControl))
            {
                Vector3 rot = cubeRED.transform.eulerAngles;
                rot.y -= 90f;
                cubeRED.transform.rotation = Quaternion.Euler(rot);
            }
        }

        Vector3 selectedPosition
            = gridInput.GetSelectedMapPosition();
        Vector3Int cellPosition
            = grid.WorldToCell(selectedPosition);
        if (selectBlock.active && selectBlock.amount > 0)
        {
            cube.transform.position = grid.GetCellCenterWorld(cellPosition);
            cubeRED.SetActive(false);
        }

        else if (selectBlock.active && selectBlock.amount <= 0)
        {
            cubeRED.transform.position = grid.GetCellCenterWorld(cellPosition);
            cube.SetActive(false);
        }

        if (gridInput.GetPlacementInput() && selectBlock != null && selectBlock.active && selectBlock.amount > 0)
        {
            Instantiate(blockPrefab, cube.transform.position, cube.transform.rotation);
            selectBlock.amount--;
        }
    }
}
