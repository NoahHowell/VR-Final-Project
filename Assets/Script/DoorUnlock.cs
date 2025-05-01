using UnityEngine;

public class DoorUnlock : MonoBehaviour
{
    public float openSpeed = 2f;          // Rotation speed
    private Quaternion targetRotation;
    private bool isOpening = false;

    void Start()
    {
        // Target is y=0, keep current x and z
        Vector3 currentEuler = transform.eulerAngles;
        targetRotation = Quaternion.Euler(currentEuler.x, 0f, currentEuler.z);
    }

    void Update()
    {
        if (isOpening)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * openSpeed);

            // Stop once we're close enough
            if (Quaternion.Angle(transform.rotation, targetRotation) < 0.5f)
            {
                transform.rotation = targetRotation;
                isOpening = false;
            }
        }
    }

    public void Unlock()
    {
        isOpening = true;
    }
}
