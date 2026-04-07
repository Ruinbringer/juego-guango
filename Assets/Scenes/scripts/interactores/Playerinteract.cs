using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public float interactDistance = 3f;
    public LayerMask interactLayer;
    public GameObject interactText;

    void Update()
    {
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactDistance, interactLayer))
        {
            interactText.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E))
            {
                Door door = hit.collider.GetComponent<Door>();

                if (door != null)
                {
                    door.Interact();
                }
            }
        }
        else
        {
            interactText.SetActive(false);
        }
    }
}