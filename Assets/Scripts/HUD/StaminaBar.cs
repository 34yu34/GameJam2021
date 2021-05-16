using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaminaBar : MonoBehaviour
{
    [SerializeField]
    private RectTransform _max_stamina;

    [SerializeField]
    private RectTransform _current_stamina;

    private StaminaComponent _stamina;

    private StaminaComponent Stamina => _stamina ??= GetComponentInParent<StaminaComponent>();

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
        if (Stamina.CurrentStamina == _last_health_known_to_human_kind)
        {
            return;
        }

        resize_health_bar();

        _last_health_known_to_human_kind = Stamina.CurrentStamina;
    }

    private void resize_health_bar()
    {
        var rect = new Vector2(_current_stamina.rect.width, _current_stamina.rect.height);

        rect.x = Stamina.CurrentStamina * _max_stamina.rect.width / Stamina.MaxStamina;

        _current_stamina.sizeDelta = rect;
    }
}
