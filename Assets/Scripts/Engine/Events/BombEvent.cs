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

    public override void DoEvent()
    {
        Debug.Log($"{this.GetType().Name} on DoEvent");

        _furthest_crater = CratterManager.GetFurthestCratterFrom(PlayerInstance.transform.position);

        Invoke("explode_furthest_crater", 5);
    }

    private void explode_furthest_crater()
    {
        Debug.Log($"{this.GetType().Name} on explode");

        if (_furthest_crater != null)
        {
            _furthest_crater.GetComponent<Collider>().isTrigger = true;
            _furthest_crater.GetComponent<Renderer>().enabled = false;
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
