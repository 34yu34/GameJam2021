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
        static const AkUniqueID MUSIC_ENDGAME_START = 2469185595U;
        static const AkUniqueID MUSIC_GAMEPLAY_DANGER_START = 2528424500U;
        static const AkUniqueID MUSIC_GAMEPLAY_DANGER_STOP = 532737960U;
        static const AkUniqueID MUSIC_START = 3725903807U;
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

    namespace GAME_PARAMETERS
    {
        static const AkUniqueID PLAYERHEALTH = 151362964U;
    } // namespace GAME_PARAMETERS

    namespace BANKS
    {
        static const AkUniqueID INIT = 1355168291U;
        static const AkUniqueID MAIN = 3161908922U;
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
