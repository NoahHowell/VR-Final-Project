using UnityEngine;

public class WinTrigger : MonoBehaviour
{
    public EscapeRoomTimer timer;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            timer.StopTimer();
        }
    }
}