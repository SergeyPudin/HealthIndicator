using TMPro;
using UnityEngine;

[RequireComponent(typeof(IChangeValue))]
public class TextValueView : AbstractIndicatorViewer
{
    [SerializeField] private TMP_Text _text;

    protected override void SetStartValues(int value, int maxValue)
    {
        _maxValue = maxValue;
        _currentValue = value;

        Display();
    }

    protected override void Display()
    {
        _text.text = $"{_currentValue} / {_maxValue}";
    }
}