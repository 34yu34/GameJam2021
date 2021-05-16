using UnityEngine;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour
{

    private Timestamp _load_scene_timestamp;

    public void Skip()
    {
        LoadNextScene();
    }

    private static void LoadNextScene()
    {
        SceneManager.LoadScene("Map");
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        _load_scene_timestamp = Timestamp.In(15f);
    }

    private void Update()
    {
        if(_load_scene_timestamp.HasPassed())
        {
            LoadNextScene();
        }
    }
}
