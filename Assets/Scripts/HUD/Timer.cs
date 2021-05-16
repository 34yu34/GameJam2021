using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField]
    private Text _time_text;

    private GameTimer _game_timer;

    private void Start()
    {
        _game_timer = GameObject.Find("GameTimer").GetComponent<GameTimer>();
    }

    void Update()
    {
        _time_text.text = _game_timer.DisplayCurrent;
    }
}
