using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField]
    private RectTransform _max_health; 

    [SerializeField]
    private RectTransform _current_health;

    private Damageable _damageable;

    private Damageable Damageable => _damageable ??= GetComponentInParent<Damageable>();

    private float _last_health_known_to_human_kind = 0;

    // Start is called before the first frame update
    void Start()
    {
        check_health_bar();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        check_health_bar();
    }

    private void check_health_bar()
    {
        if (Damageable.CurrentHealth == _last_health_known_to_human_kind)
        {
            return;
        }

        resize_health_bar();

        _last_health_known_to_human_kind = Damageable.CurrentHealth;

        AkSoundEngine.SetRTPCValue("PlayerHealth", Damageable.CurrentHealth);
    }

    private void resize_health_bar()
    {
        var rect = new Vector2(_current_health.rect.width, _current_health.rect.height);

        rect.x = Damageable.CurrentHealth * _max_health.rect.width / Damageable.MaxHealth;

        _current_health.sizeDelta = rect;
    }
}
