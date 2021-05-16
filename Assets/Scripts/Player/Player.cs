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
    // Start is called before the first frame update
    void Start()
    {
        add_death_listener();
    }

    private void add_death_listener()
    {
        _damageable_component = GetComponent<Damageable>();
        _damageable_component.OnDeath.AddListener(death);
    }

    private void death()
    {
        GameObject.Find("GameTimer").GetComponent<GameTimer>().StopTimer();
        SceneManager.LoadScene("Death");
        return;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
