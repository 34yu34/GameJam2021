using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillCount : MonoBehaviour
{
    private int _kills;
    public int Kills => _kills;

    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        _kills = 0;
    }

    public void AddKill()
    {
        _kills++;
    }
}
