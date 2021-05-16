using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    public int _numberMaxOfEnemy = 2;

    [SerializeField]
    public float _radiusSpawnable = 2f;

    [SerializeField]
    public float _frequence = 5f;


    private Timestamp _timestamp;

    [SerializeField]
    public GameObject _enemy;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_timestamp == null)
        {
            _timestamp = Timestamp.In(_frequence);
        }

        if (_timestamp.HasPassed() && transform.childCount <= _numberMaxOfEnemy)
        {
            for(int i = 0; i < 100; i++)
            {
                Debug.DrawLine(transform.position, transform.position 
                    + new Vector3(Random.Range(-_radiusSpawnable, _radiusSpawnable), 0f, Random.Range(-_radiusSpawnable, _radiusSpawnable)), 
                    Color.red, 1f);
            }

            var spawn_position = transform.position + new Vector3(Random.Range(-_radiusSpawnable, _radiusSpawnable), 0f ,Random.Range(-_radiusSpawnable, _radiusSpawnable));

            if (!Physics.Raycast(spawn_position, Vector3.down, out var hit))
            {
                Debug.Log("spawner didn't see any ground!");
                return;
            }
            
            spawn_position += Vector3.up * hit.point.y;

            if (NavMesh.SamplePosition(spawn_position, out var navmesh_hit, 100f, NavMesh.AllAreas))
            {
                Instantiate(_enemy, navmesh_hit.position, Quaternion.identity,transform);
                _timestamp = null;
            }
        }
    }
}
