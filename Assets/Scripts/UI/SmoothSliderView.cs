using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SmoothSliderView : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private float _slideDuration;

    private int _maxValue;
    private float _currentValue;
    private IChangeValue _changeValue;
    private Coroutine _moveCoroutine;
    private float _target;

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

    public void UpdateValue(int value, int maxValue)
    {
        _target = value;
        _maxValue = maxValue;

        Display();
    }

    private void SetStartValues(int value, int maxValue)
    {
        _maxValue = maxValue;
        _currentValue = value;

        _slider.maxValue = maxValue;
        _slider.value = value;
    }

    private void Display()
    {
        _slider.maxValue = _maxValue;

        _moveCoroutine = StartCoroutine(SmoothSlide());
    }

    private IEnumerator SmoothSlide()
    {
        float elapsed = 0;

        while (elapsed < _slideDuration)
        {
            _slider.value = Mathf.MoveTowards(_currentValue, _target, elapsed / _slideDuration);
            elapsed += Time.deltaTime;

        yield return null;
        }

        _currentValue = _target;
        _moveCoroutine = null;
    }
}