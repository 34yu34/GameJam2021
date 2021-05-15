using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


[RequireComponent(typeof(EnemyBehaviour))]
public class EnemyAnimation : MonoBehaviour
{
    [SerializeField]
    private Animator _animator;

    private EnemyBehaviour _enemyBehaviour;
    protected EnemyBehaviour EnemyBehaviour => _enemyBehaviour ??= GetComponent<EnemyBehaviour>();


    // Update is called once per frame
    void Update()
    {
       _animator.SetInteger("State", (int)EnemyBehaviour.CurrentAiState.StateId);
    }
}
