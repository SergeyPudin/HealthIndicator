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
    }

    private void OnDisable()
    {
        _changeValue.OnValueChanged -= UpdateValue;
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