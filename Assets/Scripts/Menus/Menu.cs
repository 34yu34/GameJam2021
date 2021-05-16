using UnityEngine;
using UnityEngine.SceneManagement;


public class Menu : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("Intro");
    }

    public void Quit()
    {
        Application.Quit();
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
    }
}
