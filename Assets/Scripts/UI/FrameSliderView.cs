using UnityEngine;
using UnityEngine.UI;

public class FrameSliderView : AbstractSliderViewer
{
    [SerializeField] private Slider _slider;
       
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
        _slider.value = _currentValue;
    }
}