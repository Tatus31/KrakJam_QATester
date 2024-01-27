using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            InvManager.SetSelectedItem(InvItem.DoorFixCode);
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            InvManager.SetSelectedItem(InvItem.HoleFixCode);
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            InvManager.SetSelectedItem(InvItem.BarrierCrates);
        }
        else if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider != null)
                {
                    BugBase bugObject = hit.collider.GetComponent<BugBase>();
                    if (bugObject != null)
                    {
                        Debug.Log("Bug Object clicked");
                        bugObject.OnClick();
                    }
                    else
                    {
                        Debug.Log("Object Clicked: " + hit.collider.gameObject.name);
                    }
                }
            }
        }
    }
}
