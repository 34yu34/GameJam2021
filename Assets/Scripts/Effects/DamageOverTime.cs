using UnityEngine;

public class DamageOverTime : MonoBehaviour
{
    [SerializeField]
    private float _seconds_between_hits = 2;

    [SerializeField]
    private int _damage_dealt = 20;

    private Timestamp _next_damage_timestamp = null;

    private void OnTriggerStay(Collider other)
    {
        var player = other.GetComponent<Player>();

        if (player == null) return;

        if (_next_damage_timestamp == null)
        {
            CreateNextTimestamp();
        }

        if (!_next_damage_timestamp.HasPassed()) return;

        player.GetComponent<Damageable>().TakeDamage(_damage_dealt);

        CreateNextTimestamp();
    }

    private void CreateNextTimestamp()
    {
        _next_damage_timestamp = Timestamp.In(_seconds_between_hits);
    }
}
