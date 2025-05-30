// Decompiled with JetBrains decompiler
// Type: GTAExpansion.LaserSight
// Assembly: GTAExpansion, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 57B8053D-C566-4641-A84B-F5EB537251F0
// Assembly location: D:\SteamLibrary\steamapps\common\Grand Theft Auto V\scripts\GTAExpansion.dll

using GTA;


namespace GTAExpansion
{
    public static class LaserSight
    {
        public static bool laserSightModeActive = ScriptSettings.Load("scripts\\Expansion\\Expansion.ini").GetValue<bool>("LASER_SIGHT_MODE", "LASER_SIGHT_MODE_ACTIVE", true);
        public static int laser_sight_toggle_btn = ScriptSettings.Load("scripts\\Expansion\\Expansion.ini").GetValue<int>("LASER_SIGHT_MODE", "LASER_SIGHT_TOGGLE_BTN", 249);
        public static int LSredColor = ScriptSettings.Load("scripts\\Expansion\\Expansion.ini").GetValue<int>("LASER_SIGHT_MODE", "LASER_SIGHT_COLOR_RED", (int)byte.MaxValue);
        public static int LSgreenColor = ScriptSettings.Load("scripts\\Expansion\\Expansion.ini").GetValue<int>("LASER_SIGHT_MODE", "LASER_SIGHT_COLOR_GREEN", 0);
        public static int LSblueColor = ScriptSettings.Load("scripts\\Expansion\\Expansion.ini").GetValue<int>("LASER_SIGHT_MODE", "LASER_SIGHT_COLOR_BLUE", 0);
        public static bool laserSightMode = false;
        public static bool canUseLaserSight = false;
        public static int laserSightActivationTimer = 0;
        public static WeaponComponentHash[] flashlights = new WeaponComponentHash[5]
        {
      WeaponComponentHash.AtArFlsh,
      WeaponComponentHash.AtPiFlsh,
      WeaponComponentHash.AtPiFlsh02,
      WeaponComponentHash.AtPiFlsh03,
      WeaponComponentHash.AtArFlshReh
        };
        public static WeaponHash laseredWeapon = (WeaponHash)0;
    }
}
