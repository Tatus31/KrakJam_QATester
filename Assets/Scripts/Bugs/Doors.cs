using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : BugBase
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider != null || AcceptedItems.Contains(InvManager.SelectedItem))
                {

                }
            }
        }
    }
}
