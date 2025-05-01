using UnityEngine;

public class KeyDoorUnlock : MonoBehaviour
{
    public Transform doorTransform;   // The door to rotate
    public float openSpeed = 2f;      // Rotation speed
    private Quaternion targetRotation;
    private bool isOpening = false;

    void Start()
    {
        // Rotate to Y = 180, keep current X and Z
        Vector3 euler = doorTransform.eulerAngles;
        targetRotation = Quaternion.Euler(euler.x, 180f, euler.z);
    }

    void Update()
    {
        if (isOpening)
        {
            doorTransform.rotation = Quaternion.Slerp(doorTransform.rotation, targetRotation, Time.deltaTime * openSpeed);

            if (Quaternion.Angle(doorTransform.rotation, targetRotation) < 0.5f)
            {
                doorTransform.rotation = targetRotation;
                isOpening = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Key"))
        {
            isOpening = true;
            Destroy(other.gameObject); // Remove the key from the scene
        }
    }
}
