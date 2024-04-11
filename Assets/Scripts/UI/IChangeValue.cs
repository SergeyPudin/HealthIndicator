using UnityEngine.Events;

public interface IChangeValue
{
    event UnityAction<int, int> OnValueChanged;
    public event UnityAction<int, int> Reset;
}