using System;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DeathScreen : MonoBehaviour
{
    [SerializeField]
    private TMPro.TextMeshProUGUI _text_time;

    private float _time;

    [SerializeField]
    private TMPro.TextMeshProUGUI _text_kills;

    private float _kills;

    [SerializeField]
    private TMPro.TextMeshProUGUI _text_score;

    private int _score = -1;

    [SerializeField]
    private float _time_score_weight = 1;

    [SerializeField]
    private float _kill_score_weight = 7;

    [SerializeField]
    private int _min_score_for_medium_result = 80;

    [SerializeField]
    private int _min_score_for_expert_result = 190;

    void Start()
    {
        Cursor.lockState = CursorLockMode.None;

        set_timer();
        set_kills();
        set_score();
        Debug.Log(GetScoreBracket());
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }

    private void set_timer()
    {
        var game_timer = GameObject.Find("GameTimer").GetComponent<GameTimer>();
        _time = game_timer.TimestampEnd - game_timer.TimestampBegin;
        _text_time.text = TimeSpan.FromSeconds(_time).ToString("mm\\:ss");
        Destroy(game_timer.gameObject);
    }

    private void set_kills()
    {
        var killCounter = GameObject.Find("KillCounter").GetComponent<KillCount>();
        _text_kills.text = killCounter.DisplayCurrent;
        _kills = killCounter.Kills;
        Destroy(killCounter.gameObject);
    }

    private void set_score()
    {
        _score = Mathf.FloorToInt(_kill_score_weight * _kills + _time_score_weight * _time);
        _text_score.text = "Overall score: " + _score.ToString() + " points";
    }

    public int GetScoreBracket()
    {
        if (_score == -1)
        {
            AkSoundEngine.SetState("Score", "Low");
            return -1;
        }

        if (_score < _min_score_for_medium_result)
        {
            AkSoundEngine.SetState("Score", "Medium");
            return 0;
        }

        if (_score < _min_score_for_expert_result)
        {
            AkSoundEngine.SetState("Score", "High");
            return 1;
        }

        return 2;
    }
}
