using TMPro;
using UnityEngine;

public abstract class HealthDisplay : MonoBehaviour
{
    public abstract void SetValue(float value);
}
public class HealthPercentageDisplay : HealthDisplay
{
    [SerializeField] private TMP_Text percentageDisplay;
    [SerializeField] private Color full;
    [SerializeField] private Color low;

    public override void SetValue(float percentage)
    {
        percentageDisplay.text = percentage.ToString("P0");
        percentageDisplay.color = Color.Lerp(low, full, percentage);
    }
}