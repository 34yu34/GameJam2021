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
        Cursor.lockState = CursorLockMode.None;

        set_timer();
        set_kills();
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }

    private void set_timer()
    {
        var game_timer = GameObject.Find("GameTimer").GetComponent<GameTimer>();
        var time = game_timer.TimestampEnd - game_timer.TimestampBegin;
        _time.text = TimeSpan.FromSeconds(time).ToString("mm\\:ss");
        Destroy(game_timer.gameObject);
    }

    private void set_kills()
    {
        var killCounter = GameObject.Find("KillCounter").GetComponent<KillCount>();
        _kills.text = killCounter.Kills + " Kills";
        Destroy(killCounter.gameObject);
    }
}
