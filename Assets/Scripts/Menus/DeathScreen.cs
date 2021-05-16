using System;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DeathScreen : MonoBehaviour
{
    [SerializeField]
    private TMPro.TextMeshProUGUI _time;

    [SerializeField]
    private TMPro.TextMeshProUGUI _kills;
    // Start is called before the first frame update
    void Start()
    {
        var game_timer = GameObject.Find("GameTimer").GetComponent<GameTimer>();
        var time = game_timer.TimestampEnd - game_timer.TimestampBegin;
        _time.text = TimeSpan.FromSeconds(time).ToString("mm\\:ss");
        Destroy(game_timer.gameObject);

        var killCounter = GameObject.Find("KillCounter").GetComponent<KillCount>();
        _kills.text = killCounter.Kills + " Kills";
        Destroy(killCounter.gameObject);
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }
}
