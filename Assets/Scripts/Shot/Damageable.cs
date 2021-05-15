using NaughtyAttributes;
using UnityEngine.Events;
using UnityEngine;

public class Damageable : MonoBehaviour
{
    private UnityEvent _on_death = new UnityEvent();

    public UnityEvent OnDeath => _on_death;

    [SerializeField]
    private int _max_health;

    public int MaxHealth => _max_health;

    [ShowNonSerializedField]
    private int _currentHealth;

    public int CurrentHealth
    {
        get => _currentHealth;

        private set => _currentHealth = Mathf.Clamp(value, 0, _max_health);
    }

    private void Start()
    {
        this.CurrentHealth = this.MaxHealth;
    }

    public void TakeDamage(int damage)
    {
        this.CurrentHealth -= damage;
        CheckAlive();
    }

    private void CheckAlive()
    {
        if (this.CurrentHealth != 0)
        {
            return;
        }

        _on_death.Invoke();
    }

}
