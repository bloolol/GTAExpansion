// Decompiled with JetBrains decompiler
// Type: GTAExpansion.Silencer
// Assembly: GTAExpansion, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 57B8053D-C566-4641-A84B-F5EB537251F0
// Assembly location: D:\SteamLibrary\steamapps\common\Grand Theft Auto V\scripts\GTAExpansion.dll

using GTA;


namespace GTAExpansion
{
    public static class Silencer
    {
        public static bool silencerModeActive = ScriptSettings.Load("scripts\\Expansion\\Expansion.ini").GetValue<bool>("SILENCER_MODE", "SILENCER_MODE_ACTIVE", true);
        public static int silencer_toggle_btn = ScriptSettings.Load("scripts\\Expansion\\Expansion.ini").GetValue<int>("SILENCER_MODE", "SILENCER_TOGGLE_BTN", 52);
        public static bool toggleSilencer = false;
        public static WeaponComponentHash[] silencers = new WeaponComponentHash[7]
        {
      WeaponComponentHash.AtArSupp,
      WeaponComponentHash.AtArSupp02,
      WeaponComponentHash.AtPiSupp,
      WeaponComponentHash.AtPiSupp02,
      WeaponComponentHash.AtSrSupp,
      WeaponComponentHash.AtSrSupp03,
      WeaponComponentHash.CeramicPistolSupp
        };
    }
}
