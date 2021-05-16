using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Kills : MonoBehaviour
{
    [SerializeField]
    private Text _time_text;

    private KillCount _kill_counter;

    private void Start()
    {
        _kill_counter = GameObject.Find("KillCounter").GetComponent<KillCount>();
    }

    void Update()
    {
        _time_text.text = _kill_counter.DisplayCurrent;
    }
}
