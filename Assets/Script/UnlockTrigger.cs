using UnityEngine;

public class UnlockTrigger : MonoBehaviour
{
    public DoorUnlock doorScript; // Drag your door object (with DoorUnlock.cs) into this field

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hourglass"))
        {
            doorScript.Unlock();
        }
    }
}
