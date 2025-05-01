using TMPro;
using UnityEngine;

public class PadlockManager : MonoBehaviour
{
    public int[] correctCode = { 1, 1, 1, 1 };

    // Assign these in Inspector
    public TextMeshProUGUI[] buttonTexts = new TextMeshProUGUI[4];
    public GameObject doorToOpen;

    public void CheckCodeFromText()
    {
        string enteredCode = "";
        for (int i = 0; i < 4; i++)
        {
            enteredCode += buttonTexts[i].text;
        }

        string correctCodeStr = string.Join("", correctCode);

        Debug.Log($"Entered: {enteredCode} | Expected: {correctCodeStr}");

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
}

}
