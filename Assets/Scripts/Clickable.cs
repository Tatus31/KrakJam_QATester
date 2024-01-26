using UnityEngine;

public class Clickable : MonoBehaviour
{
    [SerializeField] public ClickableObject ObjectType;
    void Update()
    {
        OnInteractableClicked();
    }

    private void OnInteractableClicked()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider != null)
                {
                    InvManager.Clicked(ObjectType);
                }
            }
        }
    }
}
