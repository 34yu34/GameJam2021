using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BombEvent : Event
{
    private CratterCoverManager _cratter_manager;
    private CratterCoverManager CratterManager => _cratter_manager ??= FindObjectOfType<CratterCoverManager>();
    
    private Player _player;
    private Player PlayerInstance => _player ??= FindObjectOfType<Player>();
    public override bool IsMajor => true;

    private GameObject _furthest_crater;

    [SerializeField]
    private GameObject _explosion_prefab;

    [SerializeField]
    private float _explosion_radius_knockback = 200f;

    [SerializeField]
    private float _explosion_knockback_power = 5f;

    public override void DoEvent()
    {

        _furthest_crater = CratterManager.GetFurthestCratterFrom(PlayerInstance.transform.position);

        Invoke("explode_furthest_crater", 5);
    }

    private void explode_furthest_crater()
    {

        if (_furthest_crater == null)
        {
            return;
        }

        _furthest_crater.GetComponent<Collider>().isTrigger = true;
        _furthest_crater.GetComponent<Renderer>().enabled = false;

        var explosion = Instantiate(_explosion_prefab, _furthest_crater.transform);

        explosion.transform.position += Vector3.up * _furthest_crater.transform.localScale.y / 2;

        Knock_back_player(explosion);

    }

    private void Knock_back_player(GameObject explosion)
    {
        var distance_to_player = PlayerInstance.transform.position - explosion.transform.position;
        if (distance_to_player.magnitude <= _explosion_radius_knockback)
        {
            PlayerInstance.GetComponent<Rigidbody>().AddForce(distance_to_player.normalized * _explosion_knockback_power);
        }
    }

    public override void UndoEvent()
    {

    }

    public override bool CanHappen()
    {
        return CratterManager.HasCraterLeft();
    }

    public override void ResetEvent() { }
}
