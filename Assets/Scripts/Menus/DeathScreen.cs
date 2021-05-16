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
        var min = (int)(time / 60f);
        var sec = Mathf.Floor(time - 60*min);
        _time.text = min + ":" + sec;
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
