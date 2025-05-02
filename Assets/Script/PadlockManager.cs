using TMPro;
using UnityEngine;

public class PadlockManager : MonoBehaviour
{
    public int[] correctCode = { 7, 9, 4, 2 };

    public TextMeshProUGUI[] buttonTexts = new TextMeshProUGUI[4];
    public GameObject doorToOpen;
    public GameObject padlockObject;
    public GameObject popupText; // Assign the popup canvas in Inspector

    public void CheckCodeFromText()
    {
        string enteredCode = "";
        for (int i = 0; i < 4; i++)
        {
            enteredCode += buttonTexts[i].text;
        }

        string correctCodeStr = string.Join("", correctCode);

        if (enteredCode == correctCodeStr)
        {
            OpenDoor();
        }
    }

    private void OpenDoor()
    {
        if (doorToOpen != null)
        {
            Vector3 euler = doorToOpen.transform.eulerAngles;
            doorToOpen.transform.eulerAngles = new Vector3(euler.x, 90f, euler.z);
        }

        if (padlockObject != null)
        {
            Destroy(padlockObject);
        }

        if (popupText != null)
        {
            popupText.SetActive(true);
            Invoke(nameof(HidePopup), 3f); // Hide after 3 seconds
        }
    }

    private void HidePopup()
    {
        if (popupText != null)
        {
            popupText.SetActive(false);
        }
    }
}
