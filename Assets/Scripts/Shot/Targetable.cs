using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Damageable))]
public class Targetable : MonoBehaviour
{
    private Damageable _damageable;
    public Damageable Damageable => _damageable ??= GetComponent<Damageable>();
}
