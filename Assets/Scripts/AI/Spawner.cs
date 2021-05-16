using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            var spawnPosition = transform.position + new Vector3(Random.Range(-_radiusSpawnable, _radiusSpawnable),transform.position.y,Random.Range(-_radiusSpawnable, _radiusSpawnable));
            Instantiate(_enemy,spawnPosition,Quaternion.identity,transform);
            _timestamp = null;
        }
    }
}
