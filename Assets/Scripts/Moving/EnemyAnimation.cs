using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


[RequireComponent(typeof(EnemyFollow))]
public class EnemyAnimation : MonoBehaviour
{
    [SerializeField]
    private Animator _animator;

    private EnemyFollow _enemyFollow;
    protected EnemyFollow EnemyFollow => _enemyFollow ??= GetComponent<EnemyFollow>();


    // Update is called once per frame
    void Update()
    {
       _animator.SetInteger("State", (int)EnemyFollow.CurrentAiState);
    }
}
