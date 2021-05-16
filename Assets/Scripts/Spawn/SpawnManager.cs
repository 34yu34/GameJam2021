using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SpawnManager : MonoBehaviour
{
    private static SpawnManager _instance;

    public static SpawnManager Instance
    {
        get
        {
            _instance ??= FindObjectOfType<SpawnManager>();

            Debug.Assert(_instance != null, "there should be a spawn manger in scene");

            return _instance;
        }
    }

    [SerializeField]
    private int _nothing_weight;

    [SerializeField] 
    private List<Spawn> _spawnables;

    private int _total_weight;

    private void Start()
    {
        _total_weight = _nothing_weight + _spawnables
                                                .Sum(x => x.Weight);
    }

    public void TrySpawnObject(Vector3 position)
    {
        int choosen_weigth = Random.Range(0, _total_weight);
        var weigth_accumulator = _nothing_weight;

        if (choosen_weigth < weigth_accumulator)
        {
            return;
        }

        foreach (var spawn in _spawnables)
        {
            weigth_accumulator += spawn.Weight;
            
            if (choosen_weigth < weigth_accumulator)
            {
                var obj = Instantiate(spawn);
                obj.transform.position = position;
                return;
            }
        }




    }

}
