// Decompiled with JetBrains decompiler
// Type: GTAExpansion.Helmet
// Assembly: GTAExpansion, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 57B8053D-C566-4641-A84B-F5EB537251F0
// Assembly location: D:\SteamLibrary\steamapps\common\Grand Theft Auto V\scripts\GTAExpansion.dll

using GTA;


namespace GTAExpansion
{
    public static class Helmet
    {
        public static int helmet_on_btn = ScriptSettings.Load("scripts\\Expansion\\Expansion.ini").GetValue<int>("HELMET_SETTINGS", "HELMET_ON_BTN", 20);
    }
}
