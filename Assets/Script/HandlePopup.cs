using UnityEngine;

public class HandlePopup : MonoBehaviour
{
    public GameObject popupText; // This should be the Canvas object

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            popupText.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            popupText.SetActive(false);
        }
    }
}
