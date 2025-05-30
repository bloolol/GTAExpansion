// Decompiled with JetBrains decompiler
// Type: GTAExpansion.OnFootRadio
// Assembly: GTAExpansion, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 57B8053D-C566-4641-A84B-F5EB537251F0
// Assembly location: D:\SteamLibrary\steamapps\common\Grand Theft Auto V\scripts\GTAExpansion.dll

using GTA;


namespace GTAExpansion
{
    public static class OnFootRadio
    {
        public static int earphone_toggle_btn = ScriptSettings.Load("scripts\\Expansion\\Expansion.ini").GetValue<int>("EAR_RADIO_SETTINGS", "EARPHONE_TOGGLE_KEY", 249);
        public static int readio_off_btn = ScriptSettings.Load("scripts\\Expansion\\Expansion.ini").GetValue<int>("EAR_RADIO_SETTINGS", "TURN_OFF_RADIO", 174);
        public static int prevStation = (int)byte.MaxValue;
        public static bool headset;
        public static int earRadioTimer = 0;
    }
}
