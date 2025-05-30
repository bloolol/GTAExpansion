// Decompiled with JetBrains decompiler
// Type: GTAExpansion.FocusMode
// Assembly: GTAExpansion, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 57B8053D-C566-4641-A84B-F5EB537251F0
// Assembly location: D:\SteamLibrary\steamapps\common\Grand Theft Auto V\scripts\GTAExpansion.dll

using GTA;
using GTA.Math;

namespace GTAExpansion
{
    public static class FocusMode
    {
        public static bool focusModeActive = ScriptSettings.Load("scripts\\Expansion\\Expansion.ini").GetValue<bool>("FOCUS_MODE_SETTINGS", "FOCUS_MODE_ACTIVE", true);
        public static bool focusUseCamera = ScriptSettings.Load("scripts\\Expansion\\Expansion.ini").GetValue<bool>("FOCUS_MODE_SETTINGS", "USE_CAMERA_EFFECT", true);
        public static int focus_mode_btn = ScriptSettings.Load("scripts\\Expansion\\Expansion.ini").GetValue<int>("FOCUS_MODE_SETTINGS", "MODE_ACTIVATE_BUTTON", 246);
        public static int focusMaxTimer = ScriptSettings.Load("scripts\\Expansion\\Expansion.ini").GetValue<int>("FOCUS_MODE_SETTINGS", "FOCUS_TARGETS_MARK_TIMER", 500);
        public static bool isFocused = false;
        public static int focusButtonPressedCounter = 0;
        public static int focusButtonPressedHintCounter = 0;
        public static int focusTargetingTimer = 0;
        public static int focusPedfacingTime = 5;
        public static bool focusTargetFacing = false;
        public static bool focusTargetAimingInProcess = false;
        public static int focusTimer = 0;
        public static int focusModeTimeRef = 0;
        public static Ped[] focusTargetedPeds = new Ped[0];
        public static bool focusEffectsStoped = false;
        public static bool targetsPicked = false;
        public static bool shootingTarget = false;
        public static Vector3 shootingCoords = new Vector3(0.0f, 0.0f, 0.0f);
        public static Ped focusTarget = (Ped)null;
        public static Camera targetCam = (Camera)null;
        public static bool targetCamSet = false;
        public static int rndTargetCamera = 0;
    }
}
