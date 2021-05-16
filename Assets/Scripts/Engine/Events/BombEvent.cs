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

    public override void DoEvent()
    {
        Debug.Log($"{this.GetType().Name} on DoEvent");

        var furthest_crater = CratterManager.GetFurthestCratterFrom(PlayerInstance.transform.position);

        if(furthest_crater != null)
        {
            Destroy(furthest_crater);
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
