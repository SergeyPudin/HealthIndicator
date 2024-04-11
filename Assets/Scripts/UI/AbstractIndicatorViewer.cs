using UnityEngine;

[RequireComponent(typeof(IChangeValue))]
public abstract class AbstractIndicatorViewer : MonoBehaviour
{
    protected int _maxValue;
    protected float _currentValue;
    protected IChangeValue _changeValue;

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

    protected abstract void SetStartValues(int value, int maxValue);

    protected abstract void Display();
   
    protected virtual void UpdateValue(int value, int maxValue)
    {
        _currentValue = value;
        _maxValue = maxValue;

        Display();
    }
}