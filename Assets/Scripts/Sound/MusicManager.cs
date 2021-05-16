using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    [SerializeField] int mainMenuBuildIndex = 0;
    [SerializeField] int gameplayBuildIndex = 1;
    [SerializeField] int deathScreenBuildIndex = 2;

    int lastSceneIndex = -1;

    bool shouldCallMusicStart = false;

    void Start()
    {
        SceneManager.sceneLoaded += CheckToChangeMusic;

        CheckToChangeMusic(SceneManager.GetActiveScene(), LoadSceneMode.Single);
    }

    private void CheckToChangeMusic(Scene newScene, LoadSceneMode arg1) //Called by event on LoadScene (to modify music according to scene)
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        if (currentSceneIndex == mainMenuBuildIndex)
        {
            AkSoundEngine.SetState("Music", "MainMenu");

            if (lastSceneIndex != gameplayBuildIndex)
                shouldCallMusicStart = true;
            else
                shouldCallMusicStart = false;
        }
        else if (currentSceneIndex == gameplayBuildIndex)
        {
            AkSoundEngine.SetState("Music", "Gameplay");

            if (lastSceneIndex != mainMenuBuildIndex)
                shouldCallMusicStart = true;
            else
                shouldCallMusicStart = false;
        }
        else if (currentSceneIndex == deathScreenBuildIndex)
        {
            AkSoundEngine.PostEvent("Music_EndGame_Start", gameObject);
            shouldCallMusicStart = false;
        }

        if (currentSceneIndex != lastSceneIndex)
        {
            if (currentSceneIndex == gameplayBuildIndex)
            {
                AkSoundEngine.PostEvent("Music_Gameplay_Danger_Start", gameObject);
                AkSoundEngine.PostEvent("SFX_Environment_Wind_Start", gameObject);
            }
            else
            {
                AkSoundEngine.PostEvent("Music_Gameplay_Danger_Stop", gameObject);
                AkSoundEngine.PostEvent("SFX_Environment_Wind_Stop", gameObject);
            }
        }

        if (shouldCallMusicStart)
            AkSoundEngine.PostEvent("Music_Start", gameObject);

        lastSceneIndex = currentSceneIndex;
    }
}
