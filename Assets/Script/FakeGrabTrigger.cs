using UnityEngine;
using TMPro;
using UnityEngine.XR;

public class FakeGrabTrigger : MonoBehaviour
{
    public TextMeshProUGUI messageText;
    public float messageDuration = 2f;
    private bool hasShownMessage = false;

    private void OnTriggerStay(Collider other)
    {
        // Optional: filter by left/right controller name
        if (!hasShownMessage && (other.name.Contains("Left") || other.name.Contains("Right")))
        {
            // Try both left and right hands
            if (IsGripPressed(XRNode.LeftHand) || IsGripPressed(XRNode.RightHand))
            {
                ShowMessage();
            }
        }
    }

    private bool IsGripPressed(XRNode hand)
    {
        InputDevice device = InputDevices.GetDeviceAtXRNode(hand);
        if (device.isValid && device.TryGetFeatureValue(CommonUsages.gripButton, out bool isPressed))
        {
            return isPressed;
        }
        return false;
    }

    private void ShowMessage()
    {
        hasShownMessage = true;
        if (messageText != null)
        {
            messageText.gameObject.SetActive(true);
            Invoke(nameof(HideMessage), messageDuration);
        }
    }

    private void HideMessage()
    {
        if (messageText != null)
        {
            messageText.gameObject.SetActive(false);
        }
        hasShownMessage = false;
    }
}
