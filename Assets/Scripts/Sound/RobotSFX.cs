using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotSFX : MonoBehaviour
{
    public void PlayRobotWalkSFX()
    {
        AkSoundEngine.PostEvent("Robot_Walk", gameObject);
    }

    public void PlayRobotDieSFX()
    {
        AkSoundEngine.PostEvent("Robot_Die", gameObject);
    }
}
