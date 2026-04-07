using UnityEngine;

public class Door : MonoBehaviour
{
    private bool isOpen = false;

    public void Interact()
    {
        if (isOpen)
        {
            transform.Rotate(0f, -90f, 0f);
            isOpen = false;
        }
        else
        {
            transform.Rotate(0f, 90f, 0f);
            isOpen = true;
        }
    }
}