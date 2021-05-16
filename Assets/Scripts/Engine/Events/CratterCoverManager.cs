using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CratterCoverManager : MonoBehaviour
{
    private List<GameObject> _cratter_cover_list = new List<GameObject>();
    
    void Start()
    {
        foreach(var transform in GetComponentsInChildren<Transform>())
        {
            _cratter_cover_list.Add(transform.gameObject);
        }
    }

    public bool HasCratterLeft()
    {
        return _cratter_cover_list.Count > 0;
    }

    public GameObject GetFurthestCratterFrom(Vector3 position)
    {
        var furthest = _cratter_cover_list[0];
        var furthest_dist = Vector3.Distance(position, furthest.transform.position + Vector3.up * furthest.transform.localScale.y / 2);

        for(int i = 1; i < _cratter_cover_list.Count; i++)
        {
            var cratter = _cratter_cover_list[i];
            var dist = Vector3.Distance(position, cratter.transform.position + Vector3.up * cratter.transform.localScale.y / 2);

            if(dist > furthest_dist)
            {
                furthest = cratter;
                furthest_dist = dist;
            }
        }

        return furthest;
    }
}
