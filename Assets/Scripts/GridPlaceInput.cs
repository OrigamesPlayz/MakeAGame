using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridPlaceInput : MonoBehaviour
{
    public Camera buildCam;
    private Vector3 m_lastPos;
    public LayerMask groundLayer;

    public Vector3 GetSelectedMapPosition()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = buildCam.nearClipPlane;
        Ray ray = buildCam.ScreenPointToRay(mousePos);
        RaycastHit hit;
        Debug.DrawRay(ray.origin, ray.direction * 100, Color.red);
        if (Physics.Raycast(ray, out hit, 100, groundLayer))
        {
            m_lastPos = hit.point;
        }
        return m_lastPos;
    }

    public bool GetPlacementInput()
        => Input.GetMouseButtonDown(0);
}
