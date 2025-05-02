using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using Unity.XR.CoreUtils; // For XROrigin
using TMPro;

public class EscapeRoomTimer : MonoBehaviour
{
    [Header("Timer Settings")]
    public float countdownTime = 600f; // Time in seconds (e.g. 60 = 1 min)

    [Header("XR Player Rig")]
    public XROrigin xrOrigin; // Assign XR Origin here

    [Header("Teleport Target")]
    public Transform loseTeleportPoint; // Where to send the player on timeout

    [Header("UI Clock")]
    public TextMeshProUGUI clockText; // Reference to wall-mounted digital clock

    private float remainingTime;
    private bool isTimerRunning = true;

    void Start()
    {
        remainingTime = countdownTime;
    }

    void Update()
    {
        if (!isTimerRunning) return;

        remainingTime -= Time.deltaTime;
        remainingTime = Mathf.Max(0f, remainingTime);

        // Update the on-wall clock text
        if (clockText != null)
        {
            int minutes = Mathf.FloorToInt(remainingTime / 60f);
            int seconds = Mathf.FloorToInt(remainingTime % 60f);
            clockText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }

        if (remainingTime <= 0f)
        {
            TeleportToLoseRoom();
        }
    }

    void TeleportToLoseRoom()
    {
        if (xrOrigin != null && loseTeleportPoint != null)
        {
            xrOrigin.MoveCameraToWorldLocation(loseTeleportPoint.position);
        }
        isTimerRunning = false;
    }

    public void StopTimer()
    {
        isTimerRunning = false;
    }
}
