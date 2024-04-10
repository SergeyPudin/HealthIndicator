using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour, IChangeValue
{
    [SerializeField] private int _currentHealth;
    [SerializeField] private int _maxHealthValue;

    private int _minHealthValue = 0;
    private bool _isDead = false;

    public event UnityAction<int, int> OnValueChanged;

    private void Start()
    {
        OnValueChanged?.Invoke(_currentHealth, _maxHealthValue);
    }

    public void TakeDamage(int damage)
    {
        if (_isDead == false)
        {
            _currentHealth = Mathf.Clamp(_currentHealth - damage, _minHealthValue, _maxHealthValue);
            OnValueChanged?.Invoke(_currentHealth, _maxHealthValue );
            
            if (_currentHealth <= 0)            
                Die();
        }
    }

    public void Heal(int healthPoint)
    {
        if (_isDead == false)
            _currentHealth = Mathf.Clamp(_currentHealth + healthPoint, _minHealthValue, _maxHealthValue);

        OnValueChanged?.Invoke(_currentHealth, _maxHealthValue);
    }

    private void Die()
    {
        _isDead = true;

        Destroy(gameObject);
    }
}