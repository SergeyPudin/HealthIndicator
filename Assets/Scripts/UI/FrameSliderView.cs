using UnityEngine;
using UnityEngine.UI;

public class FrameSliderView : MonoBehaviour
{
    [SerializeField] private Slider _slider;

    private int _maxValue;
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
        _changeValue.Reset += SetStartValues;
    }

    private void SetStartValues(int value, int maxValue)
    {
        _maxValue = maxValue;
        _currentValue = value;

        _slider.maxValue = maxValue;
        _slider.value = value;
    }

    public void UpdateValue(int value, int maxValue)
    {
        _currentValue = value;
        _maxValue = maxValue;

        Display();
    }

    private void Display()
    {
        _slider.maxValue = _maxValue;
        _slider.value = _currentValue;
    }
}