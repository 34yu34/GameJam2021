using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotManager : MonoBehaviour
{
    private static ShotManager _instance;

    public static ShotManager Instance
    {
        get
        {
            _instance ??= FindObjectOfType<ShotManager>();

            Debug.Assert(_instance != null, "there should be a spawn manger in scene");

            return _instance;
        }
    }

    [SerializeField] 
    [NaughtyAttributes.Required()]
    private ParticleSystem _basic_effect;
    public ParticleSystem BasicEffect => _basic_effect;
}
