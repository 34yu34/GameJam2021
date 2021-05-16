using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    [NaughtyAttributes.MinMaxSlider(0, 1f)]
    private float _spawn_chances;

    [SerializeField] 
    private List<Spawn> _spawnables;


    private void TrySpawnObject(Vector3 position)
    {
        if (Random.value >= _spawn_chances)
        {
            return;
        }

        var index = Random.Range(0, _spawnables.Count);

        var obj = Instantiate(_spawnables[index]);

        obj.transform.position = position;
    }

}
