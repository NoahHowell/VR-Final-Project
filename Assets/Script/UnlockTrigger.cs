using UnityEngine;

public class UnlockTrigger : MonoBehaviour
{
    public DoorUnlock doorScript;      // Assign your DoorUnlock script in the Inspector
    public GameObject popupText;       // Assign the popup canvas here

    private bool hasActivated = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!hasActivated && other.CompareTag("Hourglass"))
        {
            hasActivated = true;

            if (doorScript != null)
            {
                doorScript.Unlock();
            }

            if (popupText != null)
            {
                popupText.SetActive(true);
                Invoke(nameof(HidePopup), 3f); // Hide after 3 seconds
            }
        }
    }

    private void HidePopup()
    {
        popupText.SetActive(false);
    }
}
