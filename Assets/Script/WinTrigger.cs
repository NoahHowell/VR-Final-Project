using UnityEngine;

public class WinTrigger : MonoBehaviour
{
    public GameObject winScreen; // Assign in Inspector

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            winScreen.SetActive(true);
        }
    }
}