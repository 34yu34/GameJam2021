using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantSpawn : MonoBehaviour
{

    [SerializeField]
    private Spawn _spawn;

    [SerializeField]
    private float _delay;

    Timestamp _timestamp;

    [NaughtyAttributes.ShowNonSerializedField]
    private Spawn _current_spawn;

    private void Start()
    {
        _current_spawn = Instantiate(_spawn);
        _current_spawn.transform.position = transform.position;
        _timestamp = Timestamp.In(_delay);
    }

    private void Update()
    {
        if (_timestamp.HasPassed())
        {
            _timestamp = Timestamp.In(_delay);

            if(_current_spawn == null)
            {
                _current_spawn = Instantiate(_spawn);
                _current_spawn.transform.position = transform.position;
            }
        }
        
    }

}
