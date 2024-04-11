using TMPro;
using UnityEngine;

[RequireComponent(typeof(IChangeValue))]
public class TextValueView : AbstractIndicatorViewer
{
    [SerializeField] private TMP_Text _text;

    protected override void SetStartValues(int value, int maxValue)
    {
        MaxValue = maxValue;
        CurrentValue = value;

        Display();
    }

    protected override void Display()
    {
        _text.text = $"{CurrentValue} / {MaxValue}";
    }
}