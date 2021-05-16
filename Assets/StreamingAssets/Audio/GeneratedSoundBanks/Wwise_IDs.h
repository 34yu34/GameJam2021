/////////////////////////////////////////////////////////////////////////////////////////////////////
//
// Audiokinetic Wwise generated include file. Do not edit.
//
/////////////////////////////////////////////////////////////////////////////////////////////////////

#ifndef __WWISE_IDS_H__
#define __WWISE_IDS_H__

#include <AK/SoundEngine/Common/AkTypes.h>

namespace AK
{
    namespace EVENTS
    {
        static const AkUniqueID BULLET_IMPACT_METAL = 1321907086U;
        static const AkUniqueID BULLET_IMPACT_MUD = 3328773773U;
        static const AkUniqueID BULLET_IMPACT_WOOD = 988755994U;
        static const AkUniqueID EVENT_MAJOR = 448103969U;
        static const AkUniqueID EVENT_MINOR = 2704182005U;
        static const AkUniqueID MUSIC_ENDGAME_START = 2469185595U;
        static const AkUniqueID MUSIC_GAMEPLAY_DANGER_START = 2528424500U;
        static const AkUniqueID MUSIC_GAMEPLAY_DANGER_STOP = 532737960U;
        static const AkUniqueID MUSIC_START = 3725903807U;
        static const AkUniqueID PLAYER_HEAL = 780312891U;
        static const AkUniqueID PLAYER_HURT = 1068092414U;
        static const AkUniqueID PLAYER_JUMP = 1305133589U;
        static const AkUniqueID PLAYER_LAND = 3629196698U;
        static const AkUniqueID PLAYER_RELOAD = 1650679582U;
        static const AkUniqueID PLAYER_SHOOT = 4004702906U;
        static const AkUniqueID PLAYER_WALK = 2147561130U;
        static const AkUniqueID ROBOT_DIE = 3481114272U;
        static const AkUniqueID ROBOT_HURT = 2770458161U;
        static const AkUniqueID ROBOT_SHOOT = 2130607615U;
        static const AkUniqueID ROBOT_WALK = 825506301U;
        static const AkUniqueID SFX_ENVIRONMENT_WIND_START = 3555070956U;
        static const AkUniqueID SFX_ENVIRONMENT_WIND_STOP = 3290572544U;
        static const AkUniqueID SFX_UI_CLICK = 1452887354U;
    } // namespace EVENTS

    namespace STATES
    {
        namespace MUSIC
        {
            static const AkUniqueID GROUP = 3991942870U;

            namespace STATE
            {
                static const AkUniqueID GAMEPLAY = 89505537U;
                static const AkUniqueID MAINMENU = 3604647259U;
            } // namespace STATE
        } // namespace MUSIC

        namespace SCORE
        {
            static const AkUniqueID GROUP = 2398231425U;

            namespace STATE
            {
                static const AkUniqueID HIGH = 3550808449U;
                static const AkUniqueID LOW = 545371365U;
                static const AkUniqueID MEDIUM = 2849147824U;
            } // namespace STATE
        } // namespace SCORE

    } // namespace STATES

    namespace SWITCHES
    {
        namespace EVENT
        {
            static const AkUniqueID GROUP = 3161415855U;

            namespace SWITCH
            {
                static const AkUniqueID EARTHQUAKE = 1245902094U;
                static const AkUniqueID LAVA = 540301611U;
                static const AkUniqueID METEORSWARM = 3147235103U;
                static const AkUniqueID NUCLEAREXPLOSION = 1632032310U;
                static const AkUniqueID SANDSTORM = 2225901618U;
            } // namespace SWITCH
        } // namespace EVENT

        namespace PLAYERGUN
        {
            static const AkUniqueID GROUP = 6936164U;

            namespace SWITCH
            {
                static const AkUniqueID ASSAULTRIFLE = 467854164U;
                static const AkUniqueID PISTOL = 324443136U;
            } // namespace SWITCH
        } // namespace PLAYERGUN

    } // namespace SWITCHES

    namespace GAME_PARAMETERS
    {
        static const AkUniqueID PLAYERHEALTH = 151362964U;
    } // namespace GAME_PARAMETERS

    namespace BANKS
    {
        static const AkUniqueID INIT = 1355168291U;
        static const AkUniqueID MUSIC = 3991942870U;
        static const AkUniqueID SFX = 393239870U;
    } // namespace BANKS

    namespace BUSSES
    {
        static const AkUniqueID MASTER_AUDIO_BUS = 3803692087U;
    } // namespace BUSSES

    namespace AUDIO_DEVICES
    {
        static const AkUniqueID NO_OUTPUT = 2317455096U;
        static const AkUniqueID SYSTEM = 3859886410U;
    } // namespace AUDIO_DEVICES

}// namespace AK

#endif // __WWISE_IDS_H__
