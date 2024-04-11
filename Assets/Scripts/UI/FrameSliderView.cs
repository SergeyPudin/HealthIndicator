using UnityEngine;
using UnityEngine.UI;

public class FrameSliderView : AbstractIndicatorViewer
{
    [SerializeField] private Slider _slider;
       
    protected override void SetStartValues(int value, int maxValue)
    {
        MaxValue = maxValue;
        CurrentValue = value;

        _slider.maxValue = maxValue;
        _slider.value = value;
    }

    protected override void Display()
    {
        _slider.maxValue = MaxValue;
        _slider.value = CurrentValue;
    }
}