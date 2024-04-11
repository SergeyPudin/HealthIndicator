using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SmoothSliderView : AbstractSliderViewer
{
    [SerializeField] private Slider _slider;
    [SerializeField] private float _slideDuration;
     
    private Coroutine _moveCoroutine;
    private float _target;
        
    protected override void UpdateValue(int value, int maxValue)
    {
        _target = value;
        _maxValue = maxValue;

        Display();
    }

    protected override void SetStartValues(int value, int maxValue)
    {
        _maxValue = maxValue;
        _currentValue = value;

        _slider.maxValue = maxValue;
        _slider.value = value;
    }

    protected override void Display()
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