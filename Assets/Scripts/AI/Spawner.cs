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

    [SerializeField]
    private float _min_linear_distance_from_player = 50;

    private Transform _player_transform;

    // Start is called before the first frame update
    void Start()
    {
        _player_transform = FindObjectOfType<Player>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (_timestamp == null)
        {
            reset_timestamp();
        }

        if (_timestamp.HasPassed() && transform.childCount <= _numberMaxOfEnemy)
        {
            if((transform.position - _player_transform.position).magnitude < _min_linear_distance_from_player)
            {
                reset_timestamp();
            }

            _timestamp = Timestamp.In(_frequence);

            var spawn_position = transform.position + new Vector3(Random.Range(-_radiusSpawnable, _radiusSpawnable), 0f ,Random.Range(-_radiusSpawnable, _radiusSpawnable));

            if (!Physics.Raycast(spawn_position, Vector3.down, out var hit))
            {
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

    private void reset_timestamp()
    {
        _timestamp = Timestamp.In(_frequence);
    }
}
