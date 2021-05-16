using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    [SerializeField] int mainMenuBuildIndex = 0;
    [SerializeField] int gameplayBuildIndex = 1;

    int lastSceneIndex = -1;

    void Start()
    {
        SceneManager.sceneLoaded += CheckToChangeMusic;

        AkSoundEngine.PostEvent("Music_Start", gameObject);

        CheckToChangeMusic(SceneManager.GetActiveScene(), LoadSceneMode.Single);
    }

    private void CheckToChangeMusic(Scene newScene, LoadSceneMode arg1) //Called by event on LoadScene (to modify music according to scene)
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        if (currentSceneIndex == mainMenuBuildIndex)
            AkSoundEngine.SetState("Music", "MainMenu");
        else if (currentSceneIndex == gameplayBuildIndex)
            AkSoundEngine.SetState("Music", "Gameplay");

        if (currentSceneIndex != lastSceneIndex)
        {
            if (currentSceneIndex == gameplayBuildIndex)
                AkSoundEngine.PostEvent("Music_Gameplay_Danger_Start", gameObject);
            else
                AkSoundEngine.PostEvent("Music_Gameplay_Danger_Stop", gameObject);
        }

        lastSceneIndex = currentSceneIndex;
    }
}
