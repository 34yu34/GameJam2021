using NaughtyAttributes;
using UnityEngine;

public class Damageable : MonoBehaviour
{
    [SerializeField]
    private int _maxHealth;

    public int MaxHealth => _maxHealth;

    [ShowNonSerializedField]
    private int _currentHealth;

    private int CurrentHealth
    {
        get => _currentHealth;

        set => _currentHealth = Mathf.Clamp(value, 0, _maxHealth);
    }

    private void Start()
    {
        this.CurrentHealth = this.MaxHealth;
    }

    public void TakeDamage(int damage)
    {
        this.CurrentHealth -= damage;
    }

    private void CheckAlive()
    {
        if (this.CurrentHealth != 0)
        {
            return;
        }

        Kill();
    }

    private void Kill()
    {
        Destroy(gameObject);
    }
}
