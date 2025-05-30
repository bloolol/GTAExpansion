
using GTA;

namespace GTAExpansion
{
    public static class AimingStyle
    {
        public static bool aimingStyleModeActive = ScriptSettings.Load("scripts\\Expansion\\Expansion.ini").GetValue<bool>("AIMING_STYLE", "AIMING_STYLE_MODE_ACTIVE", true);
        public static int aiming_style_btn = ScriptSettings.Load("scripts\\Expansion\\Expansion.ini").GetValue<int>("AIMING_STYLE", "AIMING_STYLE_BUTTON", 80);
        public static int aiming_style_indx = 0;
        public static int aiming_style_indx_max = 2;
        public static bool isReloading = false;
        public static bool canSwitchAimingStyle = false;
    }
}