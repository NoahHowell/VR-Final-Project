using TMPro;
using UnityEngine;

public class PadlockButton : MonoBehaviour
{
    public int buttonIndex; // 0 = first button, 1 = second, etc.
    public PadlockManager manager; // Assign in Inspector
    public TextMeshProUGUI numberText; // Assign in Inspector

    private int currentValue = 0;

    public void OnPressed()
    {
        currentValue = (currentValue + 1) % 10;

        if (numberText != null)
            numberText.text = currentValue.ToString();

        if (manager != null)
            manager.CheckCodeFromText();
    }
}
