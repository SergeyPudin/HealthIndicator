using UnityEngine.Events;

public interface IChangeValue
{
    event UnityAction<int, int> OnValueChanged;
}