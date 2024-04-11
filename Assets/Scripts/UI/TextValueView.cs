using TMPro;
using UnityEngine;

[RequireComponent(typeof(IChangeValue))]
public class TextValueView : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private float _maxValue;

    private float _currentValue;
    private IChangeValue _changeValue;

    private void Awake()
    {
        _changeValue = GetComponent<IChangeValue>();
    }

    private void OnEnable()
    {
        _changeValue.OnValueChanged += UpdateValue;
        _changeValue.Reset += SetStartValues;
    }

    private void OnDisable()
    {
        _changeValue.OnValueChanged -= UpdateValue;
        _changeValue.Reset -= SetStartValues;
    }

    private void SetStartValues(int value, int maxValue)
    {
        _maxValue = maxValue;
        _currentValue = value;

        Display();
    }

    public void UpdateValue(int value, int maxValue)
    {
        _currentValue = value;
        _maxValue = maxValue;

        Display();
    }

    private void Display()
    {
        _text.text = $"{_currentValue} / {_maxValue}";
    }
}