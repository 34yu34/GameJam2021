using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CratterCoverManager : MonoBehaviour
{
    private List<GameObject> _cratter_cover_list = new List<GameObject>();
    
    void Start()
    {
        foreach(var sphere_collider in GetComponentsInChildren<SphereCollider>())
        {
            _cratter_cover_list.Add(sphere_collider.gameObject);
        }
    }

    public bool HasCraterLeft()
    {
        return _cratter_cover_list.Any();
    }

    public GameObject GetFurthestCratterFrom(Vector3 position)
    {
        if (!HasCraterLeft())
        {
            return null;
        }

        var furthest = _cratter_cover_list.First();
        float furthest_dist = find_distance_between(position, furthest.transform);

        foreach (var crater in _cratter_cover_list.Skip(1))
        {
            var dist = find_distance_between(position, crater.transform);

            if (dist > furthest_dist)
            {
                furthest = crater;
                furthest_dist = dist;
            }
        }

        _cratter_cover_list.Remove(furthest);

        return furthest;
    }

    private float find_distance_between(Vector3 position, Transform furthest)
    {
        return Vector3.Distance(position, furthest.position + Vector3.up * furthest.localScale.y / 2);
    }
}
