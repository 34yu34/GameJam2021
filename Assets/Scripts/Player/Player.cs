using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Targetable))]
[RequireComponent(typeof(Damageable))]
[RequireComponent(typeof(InputMove))]
[RequireComponent(typeof(MouseView))]
[RequireComponent(typeof(ShootInput))]
public class Player : MonoBehaviour
{
    private Damageable _damageable_component;
    public Damageable Damageable => _damageable_component ??= GetComponent<Damageable>();

    private ShootInput _shoot_input;
    public ShootInput ShootInput => _shoot_input ??= GetComponent<ShootInput>();


    // Start is called before the first frame update
    void Start()
    {
        add_death_listener();
    }

    private void add_death_listener()
    {
        Damageable.OnDeath.AddListener(death);
    }

    private void death()
    {
        GameObject.Find("GameTimer").GetComponent<GameTimer>().StopTimer();

        AkSoundEngine.SetRTPCValue("PlayerHealth", Damageable.MaxHealth);

        SceneManager.LoadScene("Death");
        return;
    }
}
