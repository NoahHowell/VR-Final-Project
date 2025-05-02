using UnityEngine;

public class KeyDoorUnlock : MonoBehaviour
{
    public Transform doorTransform;
    public float openSpeed = 2f;
    public GameObject padlockObject;

    private Quaternion targetRotation;
    private bool isOpening = false;

    void Start()
    {
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

            if (padlockObject != null)
            {
                Destroy(padlockObject);
            }

            Destroy(other.gameObject);
        }
    }
}
