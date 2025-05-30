// Decompiled with JetBrains decompiler
// Type: GTAExpansion.Crouch
// Assembly: GTAExpansion, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 57B8053D-C566-4641-A84B-F5EB537251F0
// Assembly location: D:\SteamLibrary\steamapps\common\Grand Theft Auto V\scripts\GTAExpansion.dll

using GTA;
using System.Diagnostics;


namespace GTAExpansion
{
    internal class Crouch
    {
        public static bool CrouchModeActive = ScriptSettings.Load("scripts\\Expansion\\Expansion.ini").GetValue<bool>("CROUCH", "CROUCH_MODE_ACTIVE", true);
        public static bool crouched = false;
        public static Stopwatch crouchBtnPressTimer = new Stopwatch();
    }
}
