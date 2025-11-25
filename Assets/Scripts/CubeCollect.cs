using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CubeCollect : MonoBehaviour
{
    public OutlinerScript outliner;

    public SelectionBlock[] slots;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && outliner.CurrentOutlinedObject != null)
        {
            GameObject obj = outliner.CurrentOutlinedObject.gameObject;

            foreach (SelectionBlock slot in slots)
            {
                if (slot == null || slot.cubePrefab == null)
                    continue;

                if (obj.name.StartsWith(slot.cubePrefab.name + "C") && obj.CompareTag("CubeCollectable"))
                {
                    slot.amount++;
                    Destroy(obj);
                    break;
                }
            }
        }
    }

}
