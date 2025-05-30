// Decompiled with JetBrains decompiler
// Type: GTAExpansion.Wallet
// Assembly: GTAExpansion, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 57B8053D-C566-4641-A84B-F5EB537251F0
// Assembly location: D:\SteamLibrary\steamapps\common\Grand Theft Auto V\scripts\GTAExpansion.dll

using GTA;


namespace GTAExpansion
{
    public static class Wallet
    {
        public static int wallet_btn = ScriptSettings.Load("scripts\\Expansion\\Expansion.ini").GetValue<int>("WALLET_SETTINGS", "WALLET_CHECK_BTN", 157);
        public static Prop wallet;
        public static Prop walletOpened;
        public static bool inProcessWallet = false;
        public static bool walletCount = false;
        public static float animSpeed = 0.0f;
    }
}
