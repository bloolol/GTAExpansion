// Decompiled with JetBrains decompiler
// Type: GTAExpansion.WeaponSwing
// Assembly: GTAExpansion, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 57B8053D-C566-4641-A84B-F5EB537251F0
// Assembly location: D:\SteamLibrary\steamapps\common\Grand Theft Auto V\scripts\GTAExpansion.dll

using GTA;


namespace GTAExpansion
{
    public static class WeaponSwing
    {
        public static bool swingGunModuleActive = ScriptSettings.Load("scripts\\Expansion\\Expansion.ini").GetValue<bool>("SWING_GUN", "SWING_GUN_MODE_ACTIVE", true);
        public static int swing_gun_btn = ScriptSettings.Load("scripts\\Expansion\\Expansion.ini").GetValue<int>("SWING_GUN", "SWING_GUN_BTN", 20);
        public static int swingGunTimeRef = 0;
        public static int swingGunBtnCounter = 0;
        public static int swingGunButtonPressedHintCounter = 0;
        public static bool swingGunAnim = false;
        public static bool canSwingGun = false;
    }
}
