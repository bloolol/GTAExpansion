// Decompiled with JetBrains decompiler
// Type: GTAExpansion.WoundsSystem
// Assembly: GTAExpansion, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 57B8053D-C566-4641-A84B-F5EB537251F0
// Assembly location: D:\SteamLibrary\steamapps\common\Grand Theft Auto V\scripts\GTAExpansion.dll

using GTA;


namespace GTAExpansion
{
    public static class WoundsSystem
    {
        public static bool woundsModuleActive = ScriptSettings.Load("scripts\\Expansion\\Expansion.ini").GetValue<bool>("WOUNDS_SETTINGS", "WOUNDS_MODE_ACTIVE", true);
        public static int woundsTimer = 0;
        public static int bleedTimer = 0;
        public static Ped curWoundPlayer = Game.Player.Character;
        public static bool isWounded = false;
    }
}
