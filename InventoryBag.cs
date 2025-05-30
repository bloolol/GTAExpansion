// Decompiled with JetBrains decompiler
// Type: GTAExpansion.InventoryBag
// Assembly: GTAExpansion, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 57B8053D-C566-4641-A84B-F5EB537251F0
// Assembly location: D:\SteamLibrary\steamapps\common\Grand Theft Auto V\scripts\GTAExpansion.dll

using ExpansionEnums;
using GTA;
using GTA.Math;
using GTA.Native;
using GTA.UI;
using HTools;
using NativeUI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Xml.Linq;


namespace GTAExpansion
{
    public static class InventoryBag
    {
        public static bool bag_module_active = ScriptSettings.Load("scripts\\Expansion\\Expansion.ini").GetValue<bool>("DUFFLEBAG_SETTINGS", "DUFFLEBAG_MODULE_ACTIVE", true);
        public static int bag_menu_btn = ScriptSettings.Load("scripts\\Expansion\\Expansion.ini").GetValue<int>("DUFFLEBAG_SETTINGS", "BAG_MENU_BTN", 27);
        public static int bag_coords_update_btn = ScriptSettings.Load("scripts\\Expansion\\Expansion.ini").GetValue<int>("DUFFLEBAG_SETTINGS", "BAG_UPDATE_ATTACH_POS_BTN", 45);
        public static bool drawStrap = ScriptSettings.Load("scripts\\Expansion\\Expansion.ini").GetValue<bool>("DUFFLEBAG_SETTINGS", "DRAW_STRAP", true);
        public static bool can_loose_bag = ScriptSettings.Load("scripts\\Expansion\\Expansion.ini").GetValue<bool>("DUFFLEBAG_SETTINGS", "CAN_LOOSE_BAG_ON_RAGDOLL", true);
        public static int bag_attach_bone;
        public static string bag_attach_bone_s = ScriptSettings.Load("scripts\\Expansion\\Expansion.ini").GetValue<string>("DUFFLEBAG_SETTINGS", "BAG_ATTACH_BONE", "64729");
        public static float xd;
        public static float yd;
        public static float zd;
        public static float xrd;
        public static float yrd;
        public static float zrd;
        public static string xds = ScriptSettings.Load("scripts\\Expansion\\Expansion.ini").GetValue<string>("DUFFLEBAG_SETTINGS", "x_default", "0.2100");
        public static string yds = ScriptSettings.Load("scripts\\Expansion\\Expansion.ini").GetValue<string>("DUFFLEBAG_SETTINGS", "y_default", "-0.3000");
        public static string zds = ScriptSettings.Load("scripts\\Expansion\\Expansion.ini").GetValue<string>("DUFFLEBAG_SETTINGS", "z_default", "-0.2000");
        public static string xrds = ScriptSettings.Load("scripts\\Expansion\\Expansion.ini").GetValue<string>("DUFFLEBAG_SETTINGS", "x_rot_default", "45.8999");
        public static string yrds = ScriptSettings.Load("scripts\\Expansion\\Expansion.ini").GetValue<string>("DUFFLEBAG_SETTINGS", "y_rot_default", "84.6992");
        public static string zrds = ScriptSettings.Load("scripts\\Expansion\\Expansion.ini").GetValue<string>("DUFFLEBAG_SETTINGS", "z_rot_default", "114.1992");
        public static float xsdg;
        public static float ysdg;
        public static float zsdg;
        public static float xrsdg;
        public static float yrsdg;
        public static float zrsdg;
        public static string xsdgs = ScriptSettings.Load("scripts\\Expansion\\Expansion.ini").GetValue<string>("DUFFLEBAG_SETTINGS", "x_sky_diving_gear", "-0.45");
        public static string ysdgs = ScriptSettings.Load("scripts\\Expansion\\Expansion.ini").GetValue<string>("DUFFLEBAG_SETTINGS", "y_sky_diving_gear", "-0.05");
        public static string zsdgs = ScriptSettings.Load("scripts\\Expansion\\Expansion.ini").GetValue<string>("DUFFLEBAG_SETTINGS", "z_sky_diving_gear", "-0.45");
        public static string xrsdgs = ScriptSettings.Load("scripts\\Expansion\\Expansion.ini").GetValue<string>("DUFFLEBAG_SETTINGS", "x_rot_sky_diving_gear", "0.0");
        public static string yrsdgs = ScriptSettings.Load("scripts\\Expansion\\Expansion.ini").GetValue<string>("DUFFLEBAG_SETTINGS", "y_rot_sky_diving_gear", "40.0");
        public static string zrsdgs = ScriptSettings.Load("scripts\\Expansion\\Expansion.ini").GetValue<string>("DUFFLEBAG_SETTINGS", "z_rot_sky_diving_gear", "-45.0");
        public static float xdg;
        public static float ydg;
        public static float zdg;
        public static float xrdg;
        public static float yrdg;
        public static float zrdg;
        public static string xdgs = ScriptSettings.Load("scripts\\Expansion\\Expansion.ini").GetValue<string>("DUFFLEBAG_SETTINGS", "x_diving_gear", "-0.10");
        public static string ydgs = ScriptSettings.Load("scripts\\Expansion\\Expansion.ini").GetValue<string>("DUFFLEBAG_SETTINGS", "y_diving_gear", "-0.35");
        public static string zdgs = ScriptSettings.Load("scripts\\Expansion\\Expansion.ini").GetValue<string>("DUFFLEBAG_SETTINGS", "z_diving_gear", "-0.07");
        public static string xrdgs = ScriptSettings.Load("scripts\\Expansion\\Expansion.ini").GetValue<string>("DUFFLEBAG_SETTINGS", "x_rot_diving_gear", "25.0");
        public static string yrdgs = ScriptSettings.Load("scripts\\Expansion\\Expansion.ini").GetValue<string>("DUFFLEBAG_SETTINGS", "y_rot_diving_gear", "25.0");
        public static string zrdgs = ScriptSettings.Load("scripts\\Expansion\\Expansion.ini").GetValue<string>("DUFFLEBAG_SETTINGS", "z_rot_diving_gear", "0.0");
        public static float xh;
        public static float yh;
        public static float zh;
        public static float xrh;
        public static float yrh;
        public static float zrh;
        public static string xhs = ScriptSettings.Load("scripts\\Expansion\\Expansion.ini").GetValue<string>("DUFFLEBAG_SETTINGS", "x_in_hands", "0.3500");
        public static string yhs = ScriptSettings.Load("scripts\\Expansion\\Expansion.ini").GetValue<string>("DUFFLEBAG_SETTINGS", "y_in_hands", "0.1300");
        public static string zhs = ScriptSettings.Load("scripts\\Expansion\\Expansion.ini").GetValue<string>("DUFFLEBAG_SETTINGS", "z_in_hands", "-0.1800f");
        public static string xrhs = ScriptSettings.Load("scripts\\Expansion\\Expansion.ini").GetValue<string>("DUFFLEBAG_SETTINGS", "x_r_in_hands", "45.8999");
        public static string yrhs = ScriptSettings.Load("scripts\\Expansion\\Expansion.ini").GetValue<string>("DUFFLEBAG_SETTINGS", "y_r_in_hands", "84.6992");
        public static string zrhs = ScriptSettings.Load("scripts\\Expansion\\Expansion.ini").GetValue<string>("DUFFLEBAG_SETTINGS", "z_r_in_hands", "180.1992");
        public static float xg;
        public static float yg;
        public static float zg;
        public static float xrg;
        public static float yrg;
        public static float zrg;
        public static string xgs = ScriptSettings.Load("scripts\\Expansion\\Expansion.ini").GetValue<string>("DUFFLEBAG_SETTINGS", "x_on_the_ground", "0.3500");
        public static string ygs = ScriptSettings.Load("scripts\\Expansion\\Expansion.ini").GetValue<string>("DUFFLEBAG_SETTINGS", "y_on_the_ground", "0.03");
        public static string zgs = ScriptSettings.Load("scripts\\Expansion\\Expansion.ini").GetValue<string>("DUFFLEBAG_SETTINGS", "z_on_the_ground", "-0.1800");
        public static string xrgs = ScriptSettings.Load("scripts\\Expansion\\Expansion.ini").GetValue<string>("DUFFLEBAG_SETTINGS", "x_r_on_the_ground", "0.0");
        public static string yrgs = ScriptSettings.Load("scripts\\Expansion\\Expansion.ini").GetValue<string>("DUFFLEBAG_SETTINGS", "y_r_on_the_ground", "80.6992");
        public static string zrgs = ScriptSettings.Load("scripts\\Expansion\\Expansion.ini").GetValue<string>("DUFFLEBAG_SETTINGS", "z_r_on_the_ground", "90");
        public static string bagModel = ScriptSettings.Load("scripts\\Expansion\\Expansion.ini").GetValue<string>("DUFFLEBAG_SETTINGS", "BAG", "p_ld_heist_bag_s_pro_o");
        public static string bagModelFull = ScriptSettings.Load("scripts\\Expansion\\Expansion.ini").GetValue<string>("DUFFLEBAG_SETTINGS", "BAG_FULL", "p_ld_heist_bag_s_pro");
        public static string stashedBagModel = ScriptSettings.Load("scripts\\Expansion\\Expansion.ini").GetValue<string>("DUFFLEBAG_SETTINGS", "BAG_STASHED", "p_ld_heist_bag_s_pro2_s");
        public static bool skyDiving = false;
        public static bool wearingGear = false;
        public static bool changedPosition = false;
        public static bool bagPickUp = false;
        public static bool notifed = false;
        public static bool canTakeBagFromVehicle = false;
        public static bool canPutOnBagOnExit = false;
        public static uint prevWeapon;
        public static int BagPrice = ScriptSettings.Load("scripts\\Expansion\\Expansion.ini").GetValue<int>("PRICES", "BAG_PRICE", 100);
        public static int DufflebagTimeCounter = 0;
        public static Prop cur_bag = (Prop)null;
        public static Prop prev_bag = (Prop)null;
        public static Entity droped_bag;
        public static bool hasBag = false;
        public static bool isBagBought = false;
        public static bool isBagDropped = false;
        public static bool _isBuyingGear = false;
        public static bool DropChanceCounted = false;
        public static bool stuckTimerActive = false;
        public static int stuckTimer = 0;
        public static int timeReference = 0;
        public static int hours_to_advance = 0;
        public static bool reattached = false;
        public static bool inMenu = false;
        public static MenuPool modMenuPool;
        public static UIMenu mainMenu;
        public static List<WeaponHash> stashedWeapons = new List<WeaponHash>();
        public static List<WeaponHash> characterWeapons = new List<WeaponHash>();
        public static List<object> mainMenuListString = new List<object>();
        public static Color btnColor1 = Color.Transparent;
        public static Color btnColor2 = Color.GhostWhite;
        public static Color btnTextColor1 = Color.White;
        public static Color btnTextColor2 = Color.Black;

        public static void updateDuffleBagAttachPos(Ped ped, bool showNotification = true)
        {
            InventoryBag.xds = ScriptSettings.Load("scripts\\Expansion\\Expansion.ini").GetValue<string>("DUFFLEBAG_SETTINGS", "x_default", "0.2100");
            InventoryBag.yds = ScriptSettings.Load("scripts\\Expansion\\Expansion.ini").GetValue<string>("DUFFLEBAG_SETTINGS", "y_default", "-0.3000");
            InventoryBag.zds = ScriptSettings.Load("scripts\\Expansion\\Expansion.ini").GetValue<string>("DUFFLEBAG_SETTINGS", "z_default", "-0.2000");
            InventoryBag.xrds = ScriptSettings.Load("scripts\\Expansion\\Expansion.ini").GetValue<string>("DUFFLEBAG_SETTINGS", "x_rot_default", "45.8999");
            InventoryBag.yrds = ScriptSettings.Load("scripts\\Expansion\\Expansion.ini").GetValue<string>("DUFFLEBAG_SETTINGS", "y_rot_default", "84.6992");
            InventoryBag.zrds = ScriptSettings.Load("scripts\\Expansion\\Expansion.ini").GetValue<string>("DUFFLEBAG_SETTINGS", "z_rot_default", "114.1992");
            InventoryBag.xsdgs = ScriptSettings.Load("scripts\\Expansion\\Expansion.ini").GetValue<string>("DUFFLEBAG_SETTINGS", "x_sky_diving_gear", "-0.45");
            InventoryBag.ysdgs = ScriptSettings.Load("scripts\\Expansion\\Expansion.ini").GetValue<string>("DUFFLEBAG_SETTINGS", "y_sky_diving_gear", "-0.05");
            InventoryBag.zsdgs = ScriptSettings.Load("scripts\\Expansion\\Expansion.ini").GetValue<string>("DUFFLEBAG_SETTINGS", "z_sky_diving_gear", "-0.45");
            InventoryBag.xrsdgs = ScriptSettings.Load("scripts\\Expansion\\Expansion.ini").GetValue<string>("DUFFLEBAG_SETTINGS", "x_rot_sky_diving_gear", "0.0");
            InventoryBag.yrsdgs = ScriptSettings.Load("scripts\\Expansion\\Expansion.ini").GetValue<string>("DUFFLEBAG_SETTINGS", "y_rot_sky_diving_gear", "40.0");
            InventoryBag.zrsdgs = ScriptSettings.Load("scripts\\Expansion\\Expansion.ini").GetValue<string>("DUFFLEBAG_SETTINGS", "z_rot_sky_diving_gear", "-45.0");
            InventoryBag.xdgs = ScriptSettings.Load("scripts\\Expansion\\Expansion.ini").GetValue<string>("DUFFLEBAG_SETTINGS", "x_diving_gear", "-0.10");
            InventoryBag.ydgs = ScriptSettings.Load("scripts\\Expansion\\Expansion.ini").GetValue<string>("DUFFLEBAG_SETTINGS", "y_diving_gear", "-0.35");
            InventoryBag.zdgs = ScriptSettings.Load("scripts\\Expansion\\Expansion.ini").GetValue<string>("DUFFLEBAG_SETTINGS", "z_diving_gear", "-0.07");
            InventoryBag.xrdgs = ScriptSettings.Load("scripts\\Expansion\\Expansion.ini").GetValue<string>("DUFFLEBAG_SETTINGS", "x_rot_diving_gear", "25.0");
            InventoryBag.yrdgs = ScriptSettings.Load("scripts\\Expansion\\Expansion.ini").GetValue<string>("DUFFLEBAG_SETTINGS", "y_rot_diving_gear", "25.0");
            InventoryBag.zrdgs = ScriptSettings.Load("scripts\\Expansion\\Expansion.ini").GetValue<string>("DUFFLEBAG_SETTINGS", "z_rot_diving_gear", "0.0");
            InventoryBag.xhs = ScriptSettings.Load("scripts\\Expansion\\Expansion.ini").GetValue<string>("DUFFLEBAG_SETTINGS", "x_in_hands", "0.3500");
            InventoryBag.yhs = ScriptSettings.Load("scripts\\Expansion\\Expansion.ini").GetValue<string>("DUFFLEBAG_SETTINGS", "y_in_hands", "0.1300");
            InventoryBag.zhs = ScriptSettings.Load("scripts\\Expansion\\Expansion.ini").GetValue<string>("DUFFLEBAG_SETTINGS", "z_in_hands", "-0.1800f");
            InventoryBag.xrhs = ScriptSettings.Load("scripts\\Expansion\\Expansion.ini").GetValue<string>("DUFFLEBAG_SETTINGS", "x_r_in_hands", "45.8999");
            InventoryBag.yrhs = ScriptSettings.Load("scripts\\Expansion\\Expansion.ini").GetValue<string>("DUFFLEBAG_SETTINGS", "y_r_in_hands", "84.6992");
            InventoryBag.zrhs = ScriptSettings.Load("scripts\\Expansion\\Expansion.ini").GetValue<string>("DUFFLEBAG_SETTINGS", "z_r_in_hands", "180.1992");
            InventoryBag.xgs = ScriptSettings.Load("scripts\\Expansion\\Expansion.ini").GetValue<string>("DUFFLEBAG_SETTINGS", "x_on_the_ground", "0.3500");
            InventoryBag.ygs = ScriptSettings.Load("scripts\\Expansion\\Expansion.ini").GetValue<string>("DUFFLEBAG_SETTINGS", "y_on_the_ground", "0.03");
            InventoryBag.zgs = ScriptSettings.Load("scripts\\Expansion\\Expansion.ini").GetValue<string>("DUFFLEBAG_SETTINGS", "z_on_the_ground", "-0.1800");
            InventoryBag.xrgs = ScriptSettings.Load("scripts\\Expansion\\Expansion.ini").GetValue<string>("DUFFLEBAG_SETTINGS", "x_r_on_the_ground", "0.0");
            InventoryBag.yrgs = ScriptSettings.Load("scripts\\Expansion\\Expansion.ini").GetValue<string>("DUFFLEBAG_SETTINGS", "y_r_on_the_ground", "80.6992");
            InventoryBag.zrgs = ScriptSettings.Load("scripts\\Expansion\\Expansion.ini").GetValue<string>("DUFFLEBAG_SETTINGS", "z_r_on_the_ground", "90");
            int.TryParse(InventoryBag.bag_attach_bone_s, NumberStyles.Integer, (IFormatProvider)new CultureInfo("en-US"), out InventoryBag.bag_attach_bone);
            float.TryParse(InventoryBag.xds, NumberStyles.Float, (IFormatProvider)new CultureInfo("en-US"), out InventoryBag.xd);
            float.TryParse(InventoryBag.yds, NumberStyles.Float, (IFormatProvider)new CultureInfo("en-US"), out InventoryBag.yd);
            float.TryParse(InventoryBag.zds, NumberStyles.Float, (IFormatProvider)new CultureInfo("en-US"), out InventoryBag.zd);
            float.TryParse(InventoryBag.xrds, NumberStyles.Float, (IFormatProvider)new CultureInfo("en-US"), out InventoryBag.xrd);
            float.TryParse(InventoryBag.yrds, NumberStyles.Float, (IFormatProvider)new CultureInfo("en-US"), out InventoryBag.yrd);
            float.TryParse(InventoryBag.zrds, NumberStyles.Float, (IFormatProvider)new CultureInfo("en-US"), out InventoryBag.zrd);
            float.TryParse(InventoryBag.xdgs, NumberStyles.Float, (IFormatProvider)new CultureInfo("en-US"), out InventoryBag.xdg);
            float.TryParse(InventoryBag.ydgs, NumberStyles.Float, (IFormatProvider)new CultureInfo("en-US"), out InventoryBag.ydg);
            float.TryParse(InventoryBag.zdgs, NumberStyles.Float, (IFormatProvider)new CultureInfo("en-US"), out InventoryBag.zdg);
            float.TryParse(InventoryBag.xrdgs, NumberStyles.Float, (IFormatProvider)new CultureInfo("en-US"), out InventoryBag.xrdg);
            float.TryParse(InventoryBag.yrdgs, NumberStyles.Float, (IFormatProvider)new CultureInfo("en-US"), out InventoryBag.yrdg);
            float.TryParse(InventoryBag.zrdgs, NumberStyles.Float, (IFormatProvider)new CultureInfo("en-US"), out InventoryBag.zrdg);
            float.TryParse(InventoryBag.xsdgs, NumberStyles.Float, (IFormatProvider)new CultureInfo("en-US"), out InventoryBag.xsdg);
            float.TryParse(InventoryBag.ysdgs, NumberStyles.Float, (IFormatProvider)new CultureInfo("en-US"), out InventoryBag.ysdg);
            float.TryParse(InventoryBag.zsdgs, NumberStyles.Float, (IFormatProvider)new CultureInfo("en-US"), out InventoryBag.zsdg);
            float.TryParse(InventoryBag.xrsdgs, NumberStyles.Float, (IFormatProvider)new CultureInfo("en-US"), out InventoryBag.xrsdg);
            float.TryParse(InventoryBag.yrsdgs, NumberStyles.Float, (IFormatProvider)new CultureInfo("en-US"), out InventoryBag.yrsdg);
            float.TryParse(InventoryBag.zrsdgs, NumberStyles.Float, (IFormatProvider)new CultureInfo("en-US"), out InventoryBag.zrsdg);
            float.TryParse(InventoryBag.xhs, NumberStyles.Float, (IFormatProvider)new CultureInfo("en-US"), out InventoryBag.xh);
            float.TryParse(InventoryBag.yhs, NumberStyles.Float, (IFormatProvider)new CultureInfo("en-US"), out InventoryBag.yh);
            float.TryParse(InventoryBag.zhs, NumberStyles.Float, (IFormatProvider)new CultureInfo("en-US"), out InventoryBag.zh);
            float.TryParse(InventoryBag.xrhs, NumberStyles.Float, (IFormatProvider)new CultureInfo("en-US"), out InventoryBag.xrh);
            float.TryParse(InventoryBag.yrhs, NumberStyles.Float, (IFormatProvider)new CultureInfo("en-US"), out InventoryBag.yrh);
            float.TryParse(InventoryBag.zrhs, NumberStyles.Float, (IFormatProvider)new CultureInfo("en-US"), out InventoryBag.zrh);
            float.TryParse(InventoryBag.xgs, NumberStyles.Float, (IFormatProvider)new CultureInfo("en-US"), out InventoryBag.xg);
            float.TryParse(InventoryBag.ygs, NumberStyles.Float, (IFormatProvider)new CultureInfo("en-US"), out InventoryBag.yg);
            float.TryParse(InventoryBag.zgs, NumberStyles.Float, (IFormatProvider)new CultureInfo("en-US"), out InventoryBag.zg);
            float.TryParse(InventoryBag.xrgs, NumberStyles.Float, (IFormatProvider)new CultureInfo("en-US"), out InventoryBag.xrg);
            float.TryParse(InventoryBag.yrgs, NumberStyles.Float, (IFormatProvider)new CultureInfo("en-US"), out InventoryBag.yrg);
            float.TryParse(InventoryBag.zrgs, NumberStyles.Float, (IFormatProvider)new CultureInfo("en-US"), out InventoryBag.zrg);
            if (InventoryBag.doesPedHasInventoryBag(ped) && !ped.IsSittingInVehicle() && !Function.Call<bool>(Hash.IS_CUTSCENE_PLAYING) && Screen.IsFadedIn && ped.IsStopped && (Entity)InventoryBag.bagModelReturn(ped) == (Entity)null)
            {
                InventoryBag.bagSet(InventoryBag.bagModelCheck(ped), ped);
                Common.clearTrash();
            }
            if (showNotification)
                Notification.Show("GTAExpansion: Dufflebag attach positions ~g~updated~s~");
            Function.Call(Hash.PLAY_SOUND_FRONTEND, (InputArgument) (- 1), (InputArgument)"OTHER_TEXT", (InputArgument)"HUD_AWARDS");
        }

        public static void Setup(Ped ped)
        {
            InventoryBag.modMenuPool = new MenuPool();
            InventoryBag.mainMenu = new UIMenu("Inventory Menu", "Select option");
            InventoryBag.modMenuPool.Add(InventoryBag.mainMenu);
            InventoryBag.mainMenu.OnMenuClose += new MenuCloseEvent(InventoryBag.onMenuClose);
            UIMenu uiMenu1 = new UIMenu("Stash weapon", "Select Weapon");
            UIMenu uiMenu2 = new UIMenu("Take weapon", "Select Weapon");
            UIMenuColoredItem StashItem = new UIMenuColoredItem("Stash", InventoryBag.btnColor1, InventoryBag.btnColor2);
            StashItem.SetRightBadge(UIMenuItem.BadgeStyle.Ammo);
            StashItem.TextColor = InventoryBag.btnTextColor1;
            StashItem.HighlightedTextColor = InventoryBag.btnTextColor2;
            UIMenuColoredItem TakeItem = new UIMenuColoredItem("Take", InventoryBag.btnColor1, InventoryBag.btnColor2);
            TakeItem.SetRightBadge(UIMenuItem.BadgeStyle.Ammo);
            TakeItem.TextColor = InventoryBag.btnTextColor1;
            TakeItem.HighlightedTextColor = InventoryBag.btnTextColor2;
            UIMenuColoredItem RemoveBag = new UIMenuColoredItem("Take Bag off", InventoryBag.btnColor1, InventoryBag.btnColor2);
            UIMenuColoredItem ChangeBagPosition = new UIMenuColoredItem("Change Bag Position", InventoryBag.btnColor1, InventoryBag.btnColor2);
            UIMenuColoredItem SaveOutfit = new UIMenuColoredItem("Save outfit", InventoryBag.btnColor1, InventoryBag.btnColor2);
            UIMenuColoredItem LoadOutfit = new UIMenuColoredItem("Load outfit", InventoryBag.btnColor1, InventoryBag.btnColor2);
            UIMenuColoredItem CloseMenu = new UIMenuColoredItem("Exit", Color.Transparent, Color.GhostWhite);
            SaveOutfit.SetRightBadge(UIMenuItem.BadgeStyle.Clothes);
            SaveOutfit.TextColor = InventoryBag.btnTextColor1;
            SaveOutfit.HighlightedTextColor = InventoryBag.btnTextColor2;
            LoadOutfit.SetRightBadge(UIMenuItem.BadgeStyle.Clothes);
            LoadOutfit.TextColor = InventoryBag.btnTextColor1;
            LoadOutfit.HighlightedTextColor = InventoryBag.btnTextColor2;
            RemoveBag.SetRightBadge(UIMenuItem.BadgeStyle.Tick);
            CloseMenu.SetRightBadge(UIMenuItem.BadgeStyle.Lock);
            CloseMenu.TextColor = InventoryBag.btnTextColor1;
            CloseMenu.HighlightedTextColor = InventoryBag.btnTextColor2;
            ChangeBagPosition.SetRightBadge(UIMenuItem.BadgeStyle.Makeup);
            ChangeBagPosition.TextColor = InventoryBag.btnTextColor1;
            ChangeBagPosition.HighlightedTextColor = InventoryBag.btnTextColor2;
            RemoveBag.SetRightBadge(UIMenuItem.BadgeStyle.Clothes);
            RemoveBag.TextColor = InventoryBag.btnTextColor1;
            RemoveBag.HighlightedTextColor = InventoryBag.btnTextColor2;
            string character = ((PedHash)ped.Model).ToString();
            if (char.IsDigit(character[0]))
                character = "CustomPed_" + character;
            if (Common.doc.Element((XName)"WeaponList").Element((XName)character) == null)
                Common.doc.Element((XName)"WeaponList").Add((object)new XElement((XName)character));
            if (!InventoryBag.mainMenuListString.Contains((object)uiMenu2))
            {
                InventoryBag.mainMenuListString.Add((object)uiMenu2);
                UIMenu uiMenu3 = InventoryBag.modMenuPool.AddSubMenu(InventoryBag.mainMenu, "Take Weapons");
                InventoryBag.mainMenu.CurrentSelection = 0;
                if (Common.doc.Element((XName)"WeaponList").Element((XName)character) != null && Common.doc.Element((XName)"WeaponList").Element((XName)character).Element((XName)"Weapons") != null && Common.doc.Element((XName)"WeaponList").Element((XName)character).Element((XName)"Weapons").Elements() != null)
                {
                    foreach (XElement element in Common.doc.Element((XName)"WeaponList").Element((XName)character).Element((XName)"Weapons").Elements())
                    {
                        foreach (WeaponHash allWeaponHash in Common.allWeaponHashes)
                        {
                            if (element.Name.ToString() == allWeaponHash.ToString())
                            {
                                XName name1 = element.Name;
                                WeaponHash weaponHash = WeaponHash.Unarmed;
                                XName xname1 = (XName)weaponHash.ToString();
                                if (name1 != xname1)
                                {
                                    XName name2 = element.Name;
                                    weaponHash = WeaponHash.Parachute;
                                    XName xname2 = (XName)weaponHash.ToString();
                                    if (name2 != xname2)
                                    {
                                        UIMenuCheckboxItem menuCheckboxItem = new UIMenuCheckboxItem(element.Name.ToString(), false);
                                        if (!uiMenu3.MenuItems.Contains((UIMenuItem)menuCheckboxItem))
                                            uiMenu3.AddItem((UIMenuItem)menuCheckboxItem);
                                    }
                                }
                            }
                        }
                    }
                }
                if (!uiMenu3.MenuItems.Contains((UIMenuItem)TakeItem))
                    uiMenu3.AddItem((UIMenuItem)TakeItem);
                uiMenu3.OnItemSelect += (ItemSelectEvent)((sender, item, index) =>
                {
                    if (item != TakeItem)
                        return;
                    if (Common.doc.Element((XName)"WeaponList").Element((XName)character) != null)
                    {
                        if (Common.doc.Element((XName)"WeaponList").Element((XName)character).Element((XName)"Ammo").Elements() != null)
                        {
                            object[] names = (object[])Enum.GetNames(typeof(eAmmoType));
                            Array values = Enum.GetValues(typeof(eAmmoType));
                            for (int index1 = 0; index1 < names.Length; ++index1)
                            {
                                string name = names[index1].ToString();
                                uint num1 = (uint)values.GetValue(index1);
                                XElement xelement = Common.doc.Element((XName)"WeaponList").Element((XName)character).Element((XName)"Ammo").Element((XName)name);
                                if (xelement != null && Main.TryToConvertInt32(xelement.Value) > 0)
                                {
                                    int num2 = (int)Function.Call<uint>(Hash.SET_PED_AMMO_BY_TYPE, (InputArgument)(Entity)ped, (InputArgument)num1, (InputArgument)Main.TryToConvertInt32(xelement.Value));
                                    xelement.Remove();
                                }
                            }
                        }
                        if (Common.doc.Element((XName)"WeaponList").Element((XName)character).Element((XName)"Weapons") != null)
                        {
                            foreach (WeaponHash stashedWeapon in InventoryBag.stashedWeapons)
                            {
                                foreach (XElement element in Common.doc.Element((XName)"WeaponList").Element((XName)character).Element((XName)"Weapons").Elements())
                                {
                                    if (element.Element((XName)"AMMO") != null)
                                    {
                                        if (element.Name == (XName)stashedWeapon.ToString())
                                        {
                                            ped.Weapons.Give(stashedWeapon, (int)element.Element((XName)"AMMO"), false, false);
                                            foreach (WeaponComponentHash allComponentsHash in Common.allComponentsHashes)
                                            {
                                                bool flag = Function.Call<bool>(Hash.DOES_WEAPON_TAKE_WEAPON_COMPONENT, (InputArgument)(int)stashedWeapon, (InputArgument)(int)allComponentsHash);
                                                if (element.Element((XName)allComponentsHash.ToString()) != null & flag)
                                                    Function.Call(Hash.GIVE_WEAPON_COMPONENT_TO_PED, (InputArgument)(Entity)ped, (InputArgument)(int)stashedWeapon, (InputArgument)(int)allComponentsHash);
                                            }
                                            foreach (WeaponTint allTintHash in Common.allTintHashes)
                                            {
                                                if (element.Attribute((XName)"tint") != null && element.Attribute((XName)"tint").Value == allTintHash.ToString())
                                                    Function.Call(Hash.SET_PED_WEAPON_TINT_INDEX, (InputArgument)(Entity)ped, (InputArgument)(int)stashedWeapon, (InputArgument)(int)allTintHash);
                                            }
                                            element.Remove();
                                        }
                                    }
                                    else if (element.Name == (XName)stashedWeapon.ToString())
                                    {
                                        ped.Weapons.Give(stashedWeapon, 0, false, false);
                                        foreach (WeaponComponentHash allComponentsHash in Common.allComponentsHashes)
                                        {
                                            bool flag = Function.Call<bool>(Hash.DOES_WEAPON_TAKE_WEAPON_COMPONENT, (InputArgument)(int)stashedWeapon, (InputArgument)(int)allComponentsHash);
                                            if (element.Element((XName)allComponentsHash.ToString()) != null & flag)
                                                Function.Call(Hash.GIVE_WEAPON_COMPONENT_TO_PED, (InputArgument)(Entity)ped, (InputArgument)(int)stashedWeapon, (InputArgument)(int)allComponentsHash);
                                        }
                                        foreach (WeaponTint allTintHash in Common.allTintHashes)
                                        {
                                            if (element.Attribute((XName)"tint") != null && element.Attribute((XName)"tint").Value == allTintHash.ToString())
                                                Function.Call(Hash.SET_PED_WEAPON_TINT_INDEX, (InputArgument)(Entity)ped, (InputArgument)(int)stashedWeapon, (InputArgument)(int)allTintHash);
                                        }
                                        element.Remove();
                                    }
                                }
                            }
                        }
                        Common.saveDoc();
                    }
                    InventoryBag.modMenuPool.CloseAllMenus();
                    InventoryBag.inMenu = false;
                    if (!((Entity)InventoryBag.bagModelReturn(ped) != (Entity)null))
                        return;
                    InventoryBag.weaponInventoryAnim(InventoryBag.bagModelReturn(ped), ped);
                });
                uiMenu3.OnCheckboxChange += (CheckboxChangeEvent)((sender, item, index) =>
                {
                    if (item.Checked)
                    {
                        foreach (WeaponHash allWeaponHash in Common.allWeaponHashes)
                        {
                            if (item.Text.ToString() == allWeaponHash.ToString() && !InventoryBag.stashedWeapons.Contains(allWeaponHash))
                                InventoryBag.stashedWeapons.Add(allWeaponHash);
                        }
                    }
                    else
                    {
                        foreach (WeaponHash allWeaponHash in Common.allWeaponHashes)
                        {
                            if (item.Text.ToString() == allWeaponHash.ToString() && InventoryBag.stashedWeapons.Contains(allWeaponHash))
                                InventoryBag.stashedWeapons.Remove(allWeaponHash);
                        }
                    }
                });
            }
            if (!InventoryBag.mainMenuListString.Contains((object)uiMenu1))
            {
                InventoryBag.mainMenuListString.Add((object)uiMenu1);
                UIMenu uiMenu4 = InventoryBag.modMenuPool.AddSubMenu(InventoryBag.mainMenu, "Stash Weapons");
                InventoryBag.mainMenu.CurrentSelection = 0;
                foreach (WeaponHash allWeaponHash in Common.allWeaponHashes)
                {
                    if (ped.Weapons.HasWeapon(allWeaponHash))
                    {
                        UIMenuCheckboxItem menuCheckboxItem = new UIMenuCheckboxItem(allWeaponHash.ToString(), false);
                        if (!uiMenu4.MenuItems.Contains((UIMenuItem)menuCheckboxItem) && allWeaponHash != WeaponHash.Unarmed && allWeaponHash != WeaponHash.Parachute)
                            uiMenu4.AddItem((UIMenuItem)menuCheckboxItem);
                    }
                }
                if (!uiMenu4.MenuItems.Contains((UIMenuItem)StashItem))
                    uiMenu4.AddItem((UIMenuItem)StashItem);
                uiMenu4.OnItemSelect += (ItemSelectEvent)((sender, item, index) =>
                {
                    if (item != StashItem)
                        return;
                    XElement xelement1 = Common.doc.Element((XName)"WeaponList").Element((XName)character);
                    if (xelement1.Element((XName)"Ammo") == null)
                        xelement1.Add((object)new XElement((XName)"Ammo"));
                    object[] names = (object[])Enum.GetNames(typeof(eAmmoType));
                    Array values = Enum.GetValues(typeof(eAmmoType));
                    for (int index2 = 0; index2 < names.Length; ++index2)
                    {
                        string name = names[index2].ToString();
                        int content = Function.Call<int>(Hash.GET_PED_AMMO_BY_TYPE, (InputArgument)(Entity)ped, (InputArgument)(uint)values.GetValue(index2));
                        if (content > 0)
                        {
                            if (xelement1.Element((XName)"Ammo").Element((XName)name) == null)
                                xelement1.Element((XName)"Ammo").Add((object)new XElement((XName)name, (object)content));
                            else
                                xelement1.Element((XName)"Ammo").Element((XName)name).Value = content.ToString();
                        }
                    }
                    if (xelement1.Element((XName)"Weapons") == null)
                        xelement1.Add((object)new XElement((XName)"Weapons"));
                    XElement xelement2 = xelement1.Element((XName)"Weapons");
                    foreach (WeaponHash characterWeapon in InventoryBag.characterWeapons)
                    {
                        int content = Function.Call<int>(Hash.GET_AMMO_IN_PED_WEAPON, (InputArgument)(Entity)ped, (InputArgument)(int)characterWeapon);
                        if (Function.Call<uint>(Hash.GET_WEAPONTYPE_GROUP, (InputArgument)(int)characterWeapon) != 2685387236U && Function.Call<uint>(Hash.GET_WEAPONTYPE_GROUP, (InputArgument)(int)characterWeapon) != 3566412244U)
                        {
                            if (xelement2.Element((XName)characterWeapon.ToString()) == null)
                            {
                                if (characterWeapon != WeaponHash.Unarmed)
                                {
                                    xelement2.Add((object)new XElement((XName)characterWeapon.ToString(), (object)new XElement((XName)"AMMO", (object)content)));
                                    foreach (WeaponComponentHash allComponentsHash in Common.allComponentsHashes)
                                    {
                                        bool flag = Function.Call<bool>(Hash.HAS_PED_GOT_WEAPON_COMPONENT, (InputArgument)(Entity)ped, (InputArgument)(int)characterWeapon, (InputArgument)(int)allComponentsHash);
                                        if (xelement2.Element((XName)characterWeapon.ToString()).Element((XName)allComponentsHash.ToString()) == null & flag)
                                            xelement2.Element((XName)characterWeapon.ToString()).Add((object)new XElement((XName)allComponentsHash.ToString()));
                                    }
                                    foreach (WeaponTint allTintHash in Common.allTintHashes)
                                    {
                                        int num = Function.Call<int>(Hash.GET_PED_WEAPON_TINT_INDEX, (InputArgument)(Entity)ped, (InputArgument)(int)characterWeapon);
                                        if (allTintHash == (WeaponTint)num)
                                        {
                                            if (xelement2.Element((XName)characterWeapon.ToString()).Attribute((XName)"tint") == null)
                                                xelement2.Element((XName)characterWeapon.ToString()).Add((object)new XAttribute((XName)"tint", (object)allTintHash.ToString()));
                                            else
                                                xelement2.Element((XName)characterWeapon.ToString()).Attribute((XName)"tint").Value = allTintHash.ToString();
                                        }
                                    }
                                    if (characterWeapon != WeaponHash.Unarmed)
                                        Function.Call(Hash.REMOVE_WEAPON_FROM_PED, (InputArgument)(Entity)ped, (InputArgument)(int)characterWeapon);
                                }
                            }
                            else if (xelement2.Element((XName)characterWeapon.ToString()).Element((XName)"AMMO") == null)
                            {
                                xelement2.Element((XName)characterWeapon.ToString()).Add((object)new XElement((XName)"AMMO", (object)content));
                                foreach (WeaponComponentHash allComponentsHash in Common.allComponentsHashes)
                                {
                                    bool flag = Function.Call<bool>(Hash.HAS_PED_GOT_WEAPON_COMPONENT, (InputArgument)(Entity)ped, (InputArgument)(int)characterWeapon, (InputArgument)(int)allComponentsHash);
                                    if (xelement2.Element((XName)characterWeapon.ToString()).Element((XName)allComponentsHash.ToString()) == null & flag)
                                        xelement2.Element((XName)characterWeapon.ToString()).Add((object)new XElement((XName)allComponentsHash.ToString()));
                                }
                                foreach (WeaponTint allTintHash in Common.allTintHashes)
                                {
                                    int num = Function.Call<int>(Hash.GET_PED_WEAPON_TINT_INDEX, (InputArgument)(Entity)ped, (InputArgument)(int)characterWeapon);
                                    if (allTintHash == (WeaponTint)num)
                                    {
                                        if (xelement2.Element((XName)characterWeapon.ToString()).Attribute((XName)"tint") == null)
                                            xelement2.Element((XName)characterWeapon.ToString()).Add((object)new XAttribute((XName)"tint", (object)allTintHash.ToString()));
                                        else
                                            xelement2.Element((XName)characterWeapon.ToString()).Attribute((XName)"tint").Value = allTintHash.ToString();
                                    }
                                }
                                if (characterWeapon != WeaponHash.Unarmed)
                                    Function.Call(Hash.REMOVE_WEAPON_FROM_PED, (InputArgument)(Entity)ped, (InputArgument)(int)characterWeapon);
                            }
                            else
                            {
                                int num3 = int.Parse(xelement2.Element((XName)characterWeapon.ToString()).Element((XName)"AMMO").Value) + content;
                                xelement2.Element((XName)characterWeapon.ToString()).Element((XName)"AMMO").Value = num3.ToString();
                                foreach (WeaponComponentHash allComponentsHash in Common.allComponentsHashes)
                                {
                                    bool flag = Function.Call<bool>(Hash.HAS_PED_GOT_WEAPON_COMPONENT, (InputArgument)(Entity)ped, (InputArgument)(int)characterWeapon, (InputArgument)(int)allComponentsHash);
                                    if (xelement2.Element((XName)characterWeapon.ToString()).Element((XName)allComponentsHash.ToString()) == null & flag)
                                        xelement2.Element((XName)characterWeapon.ToString()).Add((object)new XElement((XName)allComponentsHash.ToString()));
                                }
                                foreach (WeaponTint allTintHash in Common.allTintHashes)
                                {
                                    int num4 = Function.Call<int>(Hash.GET_PED_WEAPON_TINT_INDEX, (InputArgument)(Entity)ped, (InputArgument)(int)characterWeapon);
                                    if (allTintHash == (WeaponTint)num4)
                                    {
                                        if (xelement2.Element((XName)characterWeapon.ToString()).Attribute((XName)"tint") == null)
                                            xelement2.Element((XName)characterWeapon.ToString()).Add((object)new XAttribute((XName)"tint", (object)allTintHash.ToString()));
                                        else
                                            xelement2.Element((XName)characterWeapon.ToString()).Attribute((XName)"tint").Value = allTintHash.ToString();
                                    }
                                }
                                if (characterWeapon != WeaponHash.Unarmed)
                                    Function.Call(Hash.REMOVE_WEAPON_FROM_PED, (InputArgument)(Entity)ped, (InputArgument)(int)characterWeapon);
                            }
                        }
                        else
                        {
                            if (xelement2.Element((XName)characterWeapon.ToString()) == null)
                                xelement2.Add((object)new XElement((XName)characterWeapon.ToString()));
                            foreach (WeaponTint allTintHash in Common.allTintHashes)
                            {
                                int num = Function.Call<int>(Hash.GET_PED_WEAPON_TINT_INDEX, (InputArgument)(Entity)ped, (InputArgument)(int)characterWeapon);
                                if (allTintHash == (WeaponTint)num)
                                {
                                    if (xelement2.Element((XName)characterWeapon.ToString()).Attribute((XName)"tint") == null)
                                        xelement2.Element((XName)characterWeapon.ToString()).Add((object)new XAttribute((XName)"tint", (object)allTintHash.ToString()));
                                    else
                                        xelement2.Element((XName)characterWeapon.ToString()).Attribute((XName)"tint").Value = allTintHash.ToString();
                                }
                            }
                            if (characterWeapon != WeaponHash.Unarmed)
                                Function.Call(Hash.REMOVE_WEAPON_FROM_PED, (InputArgument)(Entity)ped, (InputArgument)(int)characterWeapon);
                        }
                    }
                    Common.saveDoc();
                    InventoryBag.modMenuPool.CloseAllMenus();
                    InventoryBag.inMenu = false;
                    if (!((Entity)InventoryBag.bagModelReturn(ped) != (Entity)null))
                        return;
                    InventoryBag.weaponInventoryAnim(InventoryBag.bagModelReturn(ped), ped);
                });
                uiMenu4.OnCheckboxChange += (CheckboxChangeEvent)((sender, item, index) =>
                {
                    if (item.Checked)
                    {
                        foreach (WeaponHash allWeaponHash in Common.allWeaponHashes)
                        {
                            if (ped.Weapons.HasWeapon(allWeaponHash) && item.Text.ToString() == allWeaponHash.ToString() && !InventoryBag.characterWeapons.Contains(allWeaponHash))
                                InventoryBag.characterWeapons.Add(allWeaponHash);
                        }
                    }
                    else
                    {
                        foreach (WeaponHash allWeaponHash in Common.allWeaponHashes)
                        {
                            if (ped.Weapons.HasWeapon(allWeaponHash) && item.Text.ToString() == allWeaponHash.ToString() && InventoryBag.characterWeapons.Contains(allWeaponHash))
                                InventoryBag.characterWeapons.Remove(allWeaponHash);
                        }
                    }
                });
            }
            if ((Entity)InventoryBag.bagModelReturn(ped) != (Entity)null)
            {
                if (!InventoryBag.mainMenu.MenuItems.Contains((UIMenuItem)RemoveBag))
                    InventoryBag.mainMenu.AddItem((UIMenuItem)RemoveBag);
                if (!InventoryBag.mainMenu.MenuItems.Contains((UIMenuItem)SaveOutfit))
                    InventoryBag.mainMenu.AddItem((UIMenuItem)SaveOutfit);
                if (!InventoryBag.mainMenu.MenuItems.Contains((UIMenuItem)LoadOutfit) && Common.doc.Element((XName)"WeaponList").Element((XName)character).Element((XName)"Outfit") != null)
                    InventoryBag.mainMenu.AddItem((UIMenuItem)LoadOutfit);
                if (!InventoryBag.mainMenu.MenuItems.Contains((UIMenuItem)ChangeBagPosition))
                    InventoryBag.mainMenu.AddItem((UIMenuItem)ChangeBagPosition);
                if (!InventoryBag.mainMenu.MenuItems.Contains((UIMenuItem)CloseMenu))
                    InventoryBag.mainMenu.AddItem((UIMenuItem)CloseMenu);
            }
            InventoryBag.mainMenu.OnItemSelect += (ItemSelectEvent)((sender, item, index) =>
            {
                if (item == RemoveBag && (Entity)InventoryBag.bagModelReturn(ped) != (Entity)null)
                {
                    if (!ped.IsSittingInVehicle() || ped.IsSittingInVehicle() && !ped.CurrentVehicle.IsBicycle && !ped.CurrentVehicle.IsBike && !ped.CurrentVehicle.IsQuadBike)
                    {
                        InventoryBag.inMenu = false;
                        Game.Player.Character.Task.ClearAll();
                        InventoryBag.bagRemove(InventoryBag.bagModelReturn(ped), ped);
                    }
                    else
                        Main.Notify("~r~You cant stash your bag here", "IBAG", (int)byte.MaxValue, 0, 0, NotificationIcon.Ammunation);
                }
                if (item == SaveOutfit && (Entity)InventoryBag.bagModelReturn(ped) != (Entity)null)
                {
                    InventoryBag.modMenuPool.CloseAllMenus();
                    InventoryBag.inMenu = false;
                    InventoryBag.SaveOutfitFunc(ped);
                }
                if (item == LoadOutfit && (Entity)InventoryBag.bagModelReturn(ped) != (Entity)null)
                {
                    InventoryBag.modMenuPool.CloseAllMenus();
                    InventoryBag.inMenu = false;
                    InventoryBag.LoadOutfitFunc(ped);
                }
                if (item == ChangeBagPosition && (Entity)InventoryBag.bagModelReturn(ped) != (Entity)null)
                {
                    InventoryBag.changedPosition = !InventoryBag.changedPosition;
                    InventoryBag.modMenuPool.CloseAllMenus();
                    InventoryBag.inMenu = false;
                }
                if (item != CloseMenu || !((Entity)InventoryBag.bagModelReturn(ped) != (Entity)null))
                    return;
                InventoryBag.mainMenuListString.Clear();
                InventoryBag.stashedWeapons.Clear();
                InventoryBag.inMenu = false;
                InventoryBag.weaponInventoryAnim(InventoryBag.bagModelReturn(Game.Player.Character), Game.Player.Character);
            });
        }

        public static void onMenuClose(UIMenu sender)
        {
            if (InventoryBag.modMenuPool.IsAnyMenuOpen())
                return;
            InventoryBag.modMenuPool.CloseAllMenus();
            InventoryBag.inMenu = false;
        }

        public static void checkEquipedGear(Ped ped)
        {
            if (Function.Call<int>(Hash.GET_PED_PARACHUTE_STATE, (InputArgument)(Entity)ped) != -1 || Function.Call<bool>(Hash.IS_PED_IN_PARACHUTE_FREE_FALL, (InputArgument)(Entity)ped) || Function.Call<bool>(Hash.GET_IS_PED_GADGET_EQUIPPED, (InputArgument)(Entity)ped, (InputArgument)4222310262U))
            {
                if (InventoryBag.skyDiving)
                    return;
                if ((Entity)InventoryBag.bagModelReturn(ped) != (Entity)null)
                    InventoryBag.skydive(ped, InventoryBag.bagModelReturn(ped), true);
                InventoryBag.skyDiving = true;
            }
            else
            {
                if (InventoryBag.skyDiving && !InventoryBag.changedPosition)
                {
                    if ((Entity)InventoryBag.bagModelReturn(ped) != (Entity)null)
                        InventoryBag.skydive(ped, InventoryBag.bagModelReturn(ped), false);
                    InventoryBag.skyDiving = false;
                }
                else if (!Game.Player.Character.IsSittingInVehicle() && !InventoryBag.inMenu && !Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)ped, (InputArgument)"anim@heists@money_grab@duffel", (InputArgument)"exit", (InputArgument)3) || Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)ped, (InputArgument)"anim@heists@money_grab@duffel", (InputArgument)"exit", (InputArgument)3) && (double)Function.Call<float>(Hash.GET_ENTITY_ANIM_CURRENT_TIME, (InputArgument)(Entity)ped, (InputArgument)"anim@heists@money_grab@duffel", (InputArgument)"exit") >= 0.5)
                    InventoryBag.AttachBag(InventoryBag.bagModelReturn(ped), ped);
                if (ped.Model == (Model)PedHash.Michael)
                {
                    if (Function.Call<int>(Hash.GET_PED_DRAWABLE_VARIATION, (InputArgument)(Entity)ped, (InputArgument)8) == 1 || Function.Call<int>(Hash.GET_PED_DRAWABLE_VARIATION, (InputArgument)(Entity)ped, (InputArgument)8) == 3 || Function.Call<int>(Hash.GET_PED_DRAWABLE_VARIATION, (InputArgument)(Entity)ped, (InputArgument)8) == 12 || Function.Call<int>(Hash.GET_PED_DRAWABLE_VARIATION, (InputArgument)(Entity)ped, (InputArgument)8) == 3 || Function.Call<int>(Hash.GET_PED_DRAWABLE_VARIATION, (InputArgument)(Entity)ped, (InputArgument)8) == 15 || Function.Call<int>(Hash.GET_PED_DRAWABLE_VARIATION, (InputArgument)(Entity)ped, (InputArgument)8) == 21 || Function.Call<int>(Hash.GET_PED_DRAWABLE_VARIATION, (InputArgument)(Entity)ped, (InputArgument)8) == 22 || Function.Call<int>(Hash.GET_PED_DRAWABLE_VARIATION, (InputArgument)(Entity)ped, (InputArgument)9) == 5 || Function.Call<int>(Hash.GET_PED_DRAWABLE_VARIATION, (InputArgument)(Entity)ped, (InputArgument)9) == 9)
                    {
                        if (!InventoryBag.wearingGear)
                        {
                            if ((Entity)InventoryBag.bagModelReturn(ped) != (Entity)null)
                                InventoryBag.diving(ped, InventoryBag.bagModelReturn(ped), true);
                            InventoryBag.wearingGear = true;
                        }
                    }
                    else if (InventoryBag.wearingGear && !InventoryBag.changedPosition)
                    {
                        if ((Entity)InventoryBag.bagModelReturn(ped) != (Entity)null)
                            InventoryBag.diving(ped, InventoryBag.bagModelReturn(ped), false);
                        InventoryBag.wearingGear = false;
                    }
                }
                if (ped.Model == (Model)PedHash.Franklin)
                {
                    if (Function.Call<int>(Hash.GET_PED_DRAWABLE_VARIATION, (InputArgument)(Entity)ped, (InputArgument)8) == 1 || Function.Call<int>(Hash.GET_PED_DRAWABLE_VARIATION, (InputArgument)(Entity)ped, (InputArgument)8) == 2 || Function.Call<int>(Hash.GET_PED_DRAWABLE_VARIATION, (InputArgument)(Entity)ped, (InputArgument)8) == 8 || Function.Call<int>(Hash.GET_PED_DRAWABLE_VARIATION, (InputArgument)(Entity)ped, (InputArgument)8) == 10 || Function.Call<int>(Hash.GET_PED_DRAWABLE_VARIATION, (InputArgument)(Entity)ped, (InputArgument)8) == 18 || Function.Call<int>(Hash.GET_PED_DRAWABLE_VARIATION, (InputArgument)(Entity)ped, (InputArgument)8) == 19)
                    {
                        if (!InventoryBag.wearingGear)
                        {
                            if ((Entity)InventoryBag.bagModelReturn(ped) != (Entity)null)
                                InventoryBag.diving(ped, InventoryBag.bagModelReturn(ped), true);
                            InventoryBag.wearingGear = true;
                        }
                    }
                    else if (InventoryBag.wearingGear && !InventoryBag.changedPosition)
                    {
                        if ((Entity)InventoryBag.bagModelReturn(ped) != (Entity)null)
                            InventoryBag.diving(ped, InventoryBag.bagModelReturn(ped), false);
                        InventoryBag.wearingGear = false;
                    }
                }
                if (ped.Model == (Model)PedHash.Trevor)
                {
                    if (Function.Call<int>(Hash.GET_PED_DRAWABLE_VARIATION, (InputArgument)(Entity)ped, (InputArgument)8) == 1 || Function.Call<int>(Hash.GET_PED_DRAWABLE_VARIATION, (InputArgument)(Entity)ped, (InputArgument)8) == 3 || Function.Call<int>(Hash.GET_PED_DRAWABLE_VARIATION, (InputArgument)(Entity)ped, (InputArgument)8) == 5 || Function.Call<int>(Hash.GET_PED_DRAWABLE_VARIATION, (InputArgument)(Entity)ped, (InputArgument)8) == 15 || Function.Call<int>(Hash.GET_PED_DRAWABLE_VARIATION, (InputArgument)(Entity)ped, (InputArgument)8) == 16)
                    {
                        if (!InventoryBag.wearingGear)
                        {
                            if ((Entity)InventoryBag.bagModelReturn(ped) != (Entity)null)
                                InventoryBag.diving(ped, InventoryBag.bagModelReturn(ped), true);
                            InventoryBag.wearingGear = true;
                        }
                    }
                    else if (InventoryBag.wearingGear && !InventoryBag.changedPosition)
                    {
                        if ((Entity)InventoryBag.bagModelReturn(ped) != (Entity)null)
                            InventoryBag.diving(ped, InventoryBag.bagModelReturn(ped), false);
                        InventoryBag.wearingGear = false;
                    }
                }
                if (!(ped.Model == (Model)PedHash.FreemodeMale01) && !(ped.Model == (Model)PedHash.FreemodeFemale01))
                    return;
                if (Function.Call<int>(Hash.GET_PED_DRAWABLE_VARIATION, (InputArgument)(Entity)ped, (InputArgument)5) == 1 || Function.Call<int>(Hash.GET_PED_DRAWABLE_VARIATION, (InputArgument)(Entity)ped, (InputArgument)5) == 2 || Function.Call<int>(Hash.GET_PED_DRAWABLE_VARIATION, (InputArgument)(Entity)ped, (InputArgument)5) == 3 || Function.Call<int>(Hash.GET_PED_DRAWABLE_VARIATION, (InputArgument)(Entity)ped, (InputArgument)5) == 4 || Function.Call<int>(Hash.GET_PED_DRAWABLE_VARIATION, (InputArgument)(Entity)ped, (InputArgument)5) == 5 || Function.Call<int>(Hash.GET_PED_DRAWABLE_VARIATION, (InputArgument)(Entity)ped, (InputArgument)5) == 6 || Function.Call<int>(Hash.GET_PED_DRAWABLE_VARIATION, (InputArgument)(Entity)ped, (InputArgument)5) == 7 || Function.Call<int>(Hash.GET_PED_DRAWABLE_VARIATION, (InputArgument)(Entity)ped, (InputArgument)5) == 8)
                {
                    if (InventoryBag.wearingGear)
                        return;
                    if ((Entity)InventoryBag.bagModelReturn(ped) != (Entity)null)
                        InventoryBag.diving(ped, InventoryBag.bagModelReturn(ped), true);
                    InventoryBag.wearingGear = true;
                }
                else
                {
                    if (!InventoryBag.wearingGear || InventoryBag.changedPosition)
                        return;
                    if ((Entity)InventoryBag.bagModelReturn(ped) != (Entity)null)
                        InventoryBag.diving(ped, InventoryBag.bagModelReturn(ped), false);
                    InventoryBag.wearingGear = false;
                }
            }
        }

        public static void checkBagVisibility(Ped ped)
        {
            if (!((Entity)InventoryBag.bagModelReturn(ped) != (Entity)null))
                return;
            if (ped.IsVisible)
            {
                if (InventoryBag.bagModelReturn(ped).IsVisible)
                    return;
                InventoryBag.bagModelReturn(ped).IsVisible = true;
                Prop prop1 = InventoryBag.bagModelReturn(ped);
                if (!InventoryBag.drawStrap)
                    return;
                Prop[] nearbyProps = World.GetNearbyProps(ped.Position, 2f, (Model)Main.GetHashKey("prop_cs_heist_bag_strap_01"));
                if (((IEnumerable<Prop>)nearbyProps).Count<Prop>() <= 0)
                    return;
                foreach (Prop prop2 in nearbyProps)
                {
                    if ((Entity)prop2 != (Entity)null && prop2.IsAttachedTo((Entity)prop1))
                        prop2.IsVisible = true;
                }
            }
            else
            {
                if (!InventoryBag.bagModelReturn(ped).IsVisible)
                    return;
                InventoryBag.bagModelReturn(ped).IsVisible = false;
                Prop prop3 = InventoryBag.bagModelReturn(ped);
                if (!InventoryBag.drawStrap)
                    return;
                Prop[] nearbyProps = World.GetNearbyProps(ped.Position, 2f, (Model)Main.GetHashKey("prop_cs_heist_bag_strap_01"));
                if (((IEnumerable<Prop>)nearbyProps).Count<Prop>() <= 0)
                    return;
                foreach (Prop prop4 in nearbyProps)
                {
                    if ((Entity)prop4 != (Entity)null && prop4.IsAttachedTo((Entity)prop3))
                        prop4.IsVisible = false;
                }
            }
        }

        public static bool IsCurrentWeaponBig(WeaponHash weapon)
        {
            return Function.Call<uint>(Hash.GET_WEAPONTYPE_GROUP, (InputArgument)(int)weapon) == 970310034U || Function.Call<uint>(Hash.GET_WEAPONTYPE_GROUP, (InputArgument)(int)weapon) == 2725924767U || Function.Call<uint>(Hash.GET_WEAPONTYPE_GROUP, (InputArgument)(int)weapon) == 1159398588U || Function.Call<uint>(Hash.GET_WEAPONTYPE_GROUP, (InputArgument)(int)weapon) == 1595662460U || Function.Call<uint>(Hash.GET_WEAPONTYPE_GROUP, (InputArgument)(int)weapon) == 860033945U || Function.Call<uint>(Hash.GET_WEAPONTYPE_GROUP, (InputArgument)(int)weapon) == 3337201093U || Function.Call<uint>(Hash.GET_WEAPONTYPE_GROUP, (InputArgument)(int)weapon) == 3082541095U || Function.Call<uint>(Hash.GET_WEAPONTYPE_GROUP, (InputArgument)(int)weapon) == 1548507267U;
        }

        public static bool DoesPedHasBigWeapons(Ped ped)
        {
            bool flag = false;
            foreach (WeaponHash allWeaponHash in Common.allWeaponHashes)
            {
                if (ped.Weapons.HasWeapon(allWeaponHash) && InventoryBag.IsCurrentWeaponBig(allWeaponHash))
                    flag = true;
            }
            return flag;
        }

        public static bool DoesDroppedBagExist(Ped ped)
        {
            bool flag = false;
            if (InventoryBag.getDroppedBag(ped) != (Entity)null)
            {
                flag = true;
            }
            else
            {
                string name = ((PedHash)ped.Model).ToString();
                if (char.IsDigit(name[0]))
                    name = "CustomPed_" + name;
                if (Common.doc.Element((XName)"WeaponList").Element((XName)name) == null)
                    Common.doc.Element((XName)"WeaponList").Add((object)new XElement((XName)name));
                if (Common.doc.Element((XName)"WeaponList").Element((XName)name).Attribute((XName)"bag") != null && Common.doc.Element((XName)"WeaponList").Element((XName)name).Element((XName)"place") != null && Common.doc.Element((XName)"WeaponList").Element((XName)name).Element((XName)"place").Element((XName)"Vehicle") != null)
                {
                    XElement xelement = Common.doc.Element((XName)"WeaponList").Element((XName)name).Element((XName)"place").Element((XName)"Vehicle");
                    foreach (Vehicle allVehicle in World.GetAllVehicles())
                    {
                        string str = Function.Call<string>(Hash.GET_VEHICLE_NUMBER_PLATE_TEXT, (InputArgument)(Entity)allVehicle);
                        Function.Call<string>(Hash.GET_DISPLAY_NAME_FROM_VEHICLE_MODEL, (InputArgument)(Entity)allVehicle);
                        VehicleHash model = (VehicleHash)allVehicle.Model;
                        if ((allVehicle.DisplayName == xelement.Attribute((XName)"Name").Value || model.ToString() == xelement.Attribute((XName)"Model").Value.ToString()) && str == xelement.Attribute((XName)"Plate").Value)
                        {
                            Common.blipHandle(true, (Entity)allVehicle, BlipSprite.Information, "Dufflebag", 0.85f, 200, true, false);
                            flag = true;
                            break;
                        }
                    }
                }
            }
            return flag;
        }

        public static Entity getDroppedBag(Ped ped)
        {
            Entity droppedBag = (Entity)null;
            string name = ((PedHash)ped.Model).ToString();
            if (char.IsDigit(name[0]))
                name = "CustomPed_" + name;
            if (Common.doc.Element((XName)"WeaponList").Element((XName)name) == null)
                Common.doc.Element((XName)"WeaponList").Add((object)new XElement((XName)name));
            XElement xelement = Common.doc.Element((XName)"WeaponList").Element((XName)name);
            if (xelement.Attribute((XName)"bag") != null && xelement.Element((XName)"place") != null)
            {
                if (xelement.Element((XName)"place").Element((XName)"Location") != null)
                {
                    if (xelement.Element((XName)"place").Element((XName)"Location").Attribute((XName)"X") != null && xelement.Element((XName)"place").Element((XName)"Location").Attribute((XName)"Y") != null && xelement.Element((XName)"place").Element((XName)"Location").Attribute((XName)"Z") != null)
                    {
                        float result1;
                        float.TryParse(xelement.Element((XName)"place").Element((XName)"Location").Attribute((XName)"X").Value, NumberStyles.Float, (IFormatProvider)new CultureInfo("en-US"), out result1);
                        float result2;
                        float.TryParse(xelement.Element((XName)"place").Element((XName)"Location").Attribute((XName)"Y").Value, NumberStyles.Float, (IFormatProvider)new CultureInfo("en-US"), out result2);
                        float result3;
                        float.TryParse(xelement.Element((XName)"place").Element((XName)"Location").Attribute((XName)"Z").Value, NumberStyles.Float, (IFormatProvider)new CultureInfo("en-US"), out result3);
                        Vector3 position1 = new Vector3(result1, result2, result3);
                        double groundHeight = (double)World.GetGroundHeight(new Vector2(position1.X, position1.Y));
                        Model[] modelArray = new Model[1]
                        {
              (Model) InventoryBag.stashedBagModel
                        };
                        Vector3 position2;
                        foreach (Prop nearbyProp in World.GetNearbyProps(position1, 100f, modelArray))
                        {
                            if (!nearbyProp.IsAttached())
                            {
                                droppedBag = (Entity)nearbyProp;
                                if (droppedBag.IsInAir || (double)droppedBag.HeightAboveGround < 0.0)
                                {
                                    Function.Call(Hash.PLACE_OBJECT_ON_GROUND_PROPERLY, (InputArgument)droppedBag);
                                    xelement.Element((XName)"place").Element((XName)"Location").Attribute((XName)"X").Value = droppedBag.Position.X.ToString();
                                    XAttribute xattribute1 = xelement.Element((XName)"place").Element((XName)"Location").Attribute((XName)"Y");
                                    position2 = droppedBag.Position;
                                    string str1 = position2.Y.ToString();
                                    xattribute1.Value = str1;
                                    XAttribute xattribute2 = xelement.Element((XName)"place").Element((XName)"Location").Attribute((XName)"Z");
                                    position2 = droppedBag.Position;
                                    string str2 = position2.Z.ToString();
                                    xattribute2.Value = str2;
                                    Common.saveDoc(Common.doc);
                                    break;
                                }
                                break;
                            }
                        }
                        if (droppedBag == (Entity)null)
                        {
                            droppedBag = (Entity)World.CreateProp((Model)InventoryBag.stashedBagModel, position1, true, true);
                            if (droppedBag != (Entity)null)
                            {
                                droppedBag.HasGravity = true;
                                if (droppedBag.IsInAir || (double)droppedBag.HeightAboveGround < 0.0)
                                {
                                    Function.Call(Hash.PLACE_OBJECT_ON_GROUND_PROPERLY, (InputArgument)droppedBag);
                                    XAttribute xattribute3 = xelement.Element((XName)"place").Element((XName)"Location").Attribute((XName)"X");
                                    position2 = droppedBag.Position;
                                    string str3 = position2.X.ToString();
                                    xattribute3.SetValue((object)str3);
                                    XAttribute xattribute4 = xelement.Element((XName)"place").Element((XName)"Location").Attribute((XName)"Y");
                                    position2 = droppedBag.Position;
                                    string str4 = position2.Y.ToString();
                                    xattribute4.SetValue((object)str4);
                                    XAttribute xattribute5 = xelement.Element((XName)"place").Element((XName)"Location").Attribute((XName)"Z");
                                    position2 = droppedBag.Position;
                                    string str5 = position2.Z.ToString();
                                    xattribute5.SetValue((object)str5);
                                    Common.saveDoc(Common.doc);
                                }
                            }
                        }
                    }
                }
                else if (xelement.Element((XName)"place").Element((XName)"Vehicle") != null)
                {
                    foreach (Vehicle allVehicle in World.GetAllVehicles())
                    {
                        Function.Call<string>(Hash.GET_VEHICLE_NUMBER_PLATE_TEXT, (InputArgument)(Entity)allVehicle);
                        Function.Call<string>(Hash.GET_DISPLAY_NAME_FROM_VEHICLE_MODEL, (InputArgument)(Entity)allVehicle);
                        VehicleHash model = (VehicleHash)allVehicle.Model;
                        if ((allVehicle.DisplayName == xelement.Element((XName)"place").Element((XName)"Vehicle").Attribute((XName)"Name").Value || model.ToString() == xelement.Element((XName)"place").Element((XName)"Vehicle").Attribute((XName)"Model").Value) && Function.Call<string>(Hash.GET_VEHICLE_NUMBER_PLATE_TEXT, (InputArgument)(Entity)allVehicle) == xelement.Element((XName)"place").Element((XName)"Vehicle").Attribute((XName)"Plate").Value)
                        {
                            droppedBag = (Entity)allVehicle;
                            break;
                        }
                    }
                }
            }
            return droppedBag;
        }

        public static void ClearInventoryData(Ped ped)
        {
            string name = ((PedHash)ped.Model).ToString();
            if (char.IsDigit(name[0]))
                name = "CustomPed_" + name;
            if (Common.doc.Element((XName)"WeaponList").Element((XName)name) == null)
                return;
            Common.doc.Element((XName)"WeaponList").Element((XName)name).Descendants().Remove<XElement>();
        }

        public static bool doesPedHasInventoryBag(Ped ped)
        {
            string name = ((PedHash)ped.Model).ToString();
            if (char.IsDigit(name[0]))
                name = "CustomPed_" + name;
            if (Common.doc.Element((XName)"WeaponList").Element((XName)name) == null)
                Common.doc.Element((XName)"WeaponList").Add((object)new XElement((XName)name));
            XElement xelement = Common.doc.Element((XName)"WeaponList").Element((XName)name);
            return xelement.Attribute((XName)"bag") != null && xelement.Attribute((XName)"bag").Value == "true";
        }

        public static string bagModelCheck(Ped ped)
        {
            List<WeaponHash> weaponHashList = new List<WeaponHash>();
            string name = ((PedHash)ped.Model).ToString();
            if (char.IsDigit(name[0]))
                name = "CustomPed_" + name;
            if (Common.doc.Element((XName)"WeaponList").Element((XName)name) == null)
                Common.doc.Element((XName)"WeaponList").Add((object)new XElement((XName)name));
            XElement xelement = Common.doc.Element((XName)"WeaponList").Element((XName)name);
            if (xelement.Elements() != null)
            {
                foreach (XElement element in xelement.Elements())
                {
                    foreach (WeaponHash allWeaponHash in Common.allWeaponHashes)
                    {
                        if (allWeaponHash.ToString() == element.Name.ToString() && InventoryBag.IsCurrentWeaponBig(allWeaponHash) && !weaponHashList.Contains(allWeaponHash))
                            weaponHashList.Add(allWeaponHash);
                    }
                }
            }
            return weaponHashList.Count <= 3 ? InventoryBag.bagModel : InventoryBag.bagModelFull;
        }

        public static bool doesPedWearingBag(Ped ped)
        {
            return (Entity)InventoryBag.bagModelReturn(ped) != (Entity)null;
        }

        public static void outfit_XML_Element_Handle_Func(
          Ped ped,
          string elem,
          uint id,
          int model,
          int texture,
          bool isProp)
        {
            XElement xelement = (XElement)null;
            string name = ((PedHash)ped.Model).ToString();
            if (char.IsDigit(name[0]))
                name = "CustomPed_" + name;
            if (Common.doc.Element((XName)"WeaponList").Element((XName)name) == null)
            {
                Common.doc.Element((XName)"WeaponList").Add((object)new XElement((XName)name));
                Common.saveDoc();
            }
            if (Common.doc.Element((XName)"WeaponList").Element((XName)name) != null)
            {
                if (Common.doc.Element((XName)"WeaponList").Element((XName)name).Element((XName)"Outfit") == null)
                {
                    Common.doc.Element((XName)"WeaponList").Element((XName)name).Add((object)new XElement((XName)"Outfit"));
                    Common.saveDoc();
                    xelement = Common.doc.Element((XName)"WeaponList").Element((XName)name).Element((XName)"Outfit");
                }
                if (Common.doc.Element((XName)"WeaponList").Element((XName)name).Element((XName)"Outfit") != null)
                    xelement = Common.doc.Element((XName)"WeaponList").Element((XName)name).Element((XName)"Outfit");
            }
            if (xelement == null)
                return;
            if (xelement.Element((XName)elem) == null)
            {
                xelement.Add((object)new XElement((XName)elem, (object)new XElement((XName)"ID", (object)id)));
                xelement.Element((XName)elem).Add((object)new XElement((XName)"Model", (object)model));
                xelement.Element((XName)elem).Add((object)new XElement((XName)"Variation", (object)texture));
                if (xelement.Element((XName)elem).Attribute((XName)nameof(isProp)) == null)
                {
                    xelement.Element((XName)elem).Add((object)new XAttribute((XName)nameof(isProp), (object)isProp));
                    Common.saveDoc();
                }
                else
                {
                    xelement.Element((XName)elem).Attribute((XName)nameof(isProp)).SetValue((object)isProp);
                    Common.saveDoc();
                }
                Common.saveDoc();
            }
            else
            {
                if (xelement.Element((XName)elem).Attribute((XName)nameof(isProp)) == null)
                {
                    xelement.Element((XName)elem).Add((object)new XAttribute((XName)nameof(isProp), (object)isProp));
                    Common.saveDoc();
                }
                else
                {
                    xelement.Element((XName)elem).Attribute((XName)nameof(isProp)).SetValue((object)isProp);
                    Common.saveDoc();
                }
                if (xelement.Element((XName)elem).Element((XName)"ID") == null)
                {
                    xelement.Element((XName)elem).Add((object)new XElement((XName)"ID", (object)id));
                    Common.saveDoc();
                }
                else
                {
                    xelement.Element((XName)elem).Element((XName)"Model").SetValue((object)model);
                    Common.saveDoc();
                }
                if (xelement.Element((XName)elem).Element((XName)"Model") == null)
                {
                    xelement.Element((XName)elem).Add((object)new XElement((XName)"Model", (object)model));
                    Common.saveDoc();
                }
                else
                {
                    xelement.Element((XName)elem).Element((XName)"Variation").SetValue((object)texture);
                    Common.saveDoc();
                }
                if (xelement.Element((XName)elem).Element((XName)"Variation") == null)
                {
                    xelement.Element((XName)elem).Add((object)new XElement((XName)"Variation", (object)texture));
                    Common.saveDoc();
                }
                else
                {
                    xelement.Element((XName)elem).Element((XName)"Variation").SetValue((object)texture);
                    Common.saveDoc();
                }
            }
        }

        public static void read_XML_element_outfit_func(Ped ped, string elem, uint id, bool isProp)
        {
            XElement xelement = (XElement)null;
            string name = ((PedHash)ped.Model).ToString();
            if (char.IsDigit(name[0]))
                name = "CustomPed_" + name;
            if (Common.doc.Element((XName)"WeaponList").Element((XName)name) == null)
            {
                Common.doc.Element((XName)"WeaponList").Add((object)new XElement((XName)name));
                Common.saveDoc();
            }
            if (Common.doc.Element((XName)"WeaponList").Element((XName)name) != null)
            {
                if (Common.doc.Element((XName)"WeaponList").Element((XName)name).Element((XName)"Outfit") == null)
                {
                    Common.doc.Element((XName)"WeaponList").Element((XName)name).Add((object)new XElement((XName)"Outfit"));
                    Common.saveDoc();
                    xelement = Common.doc.Element((XName)"WeaponList").Element((XName)name).Element((XName)"Outfit");
                }
                if (Common.doc.Element((XName)"WeaponList").Element((XName)name).Element((XName)"Outfit") != null)
                    xelement = Common.doc.Element((XName)"WeaponList").Element((XName)name).Element((XName)"Outfit");
            }
            if (xelement == null || xelement.Element((XName)elem) == null || xelement.Element((XName)elem).Element((XName)"Model") == null || xelement.Element((XName)elem).Element((XName)"Variation") == null)
                return;
            int int32_1 = Convert.ToInt32(xelement.Element((XName)elem).Element((XName)"Model").Value);
            int int32_2 = Convert.ToInt32(xelement.Element((XName)elem).Element((XName)"Variation").Value);
            if (!isProp)
            {
                if (!Function.Call<bool>(Hash.IS_PED_COMPONENT_VARIATION_VALID, (InputArgument)(Entity)ped, (InputArgument)id, (InputArgument)int32_1, (InputArgument)int32_2))
                    return;
                Function.Call(Hash.SET_PED_COMPONENT_VARIATION, (InputArgument)(Entity)ped, (InputArgument)id, (InputArgument)int32_1, (InputArgument)int32_2);
            }
            else
            {
                try
                {
                    Function.Call(Hash.SET_PED_PROP_INDEX, (InputArgument)(Entity)ped, (InputArgument)id, (InputArgument)int32_1, (InputArgument)int32_2);
                }
                catch
                {
                }
            }
        }

        public static void LoadOutfitFunc(Ped ped)
        {
            Game.Player.CanControlCharacter = true;
            PedComponent[] allComponents = ped.Style.GetAllComponents();
            for (int index = 0; index < allComponents.Length; ++index)
                InventoryBag.read_XML_element_outfit_func(ped, allComponents[index].Name, (uint)allComponents[index].Type, false);
            PedProp[] allProps = ped.Style.GetAllProps();
            ped.Style.ClearProps();
            for (int index = 0; index < allProps.Length; ++index)
                InventoryBag.read_XML_element_outfit_func(ped, allProps[index].Name, (uint)allProps[index].Type, true);
            Main.soundFX(ped, "noise.wav", Common.assetFolder);
            Screen.ShowHelpText("~BLIP_INFO_ICON~ Outfit has been ~g~Successfully~w~ Loaded", 3000);
            string animDict = "anim_heist@hs3f@ig12_change_clothes@";
            string animName = "action_01_male";
            if (ped.Gender == Gender.Female)
                animName = "change_fire_female";
            if (!Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)ped, (InputArgument)animDict, (InputArgument)animName, (InputArgument)3))
                ped.Task.PlayAnimation(animDict, animName, 4f, -1, AnimationFlags.None);
            Prop prop = InventoryBag.bagModelReturn(ped);
            if ((Entity)prop != (Entity)null && prop.IsAttachedTo((Entity)ped))
                prop.Detach();
            Script.Wait(100);
        }

        public static void SaveOutfitFunc(Ped ped)
        {
            PedComponent[] allComponents = ped.Style.GetAllComponents();
            for (int index = 0; index < allComponents.Length; ++index)
                InventoryBag.outfit_XML_Element_Handle_Func(ped, allComponents[index].Name, (uint)allComponents[index].Type, Function.Call<int>(Hash.GET_PED_DRAWABLE_VARIATION, (InputArgument)(Entity)ped, (InputArgument)(uint)allComponents[index].Type), Function.Call<int>(Hash.GET_PED_TEXTURE_VARIATION, (InputArgument)(Entity)ped, (InputArgument)(uint)allComponents[index].Type), false);
            PedProp[] allProps = ped.Style.GetAllProps();
            for (int index = 0; index < allProps.Length; ++index)
                InventoryBag.outfit_XML_Element_Handle_Func(ped, allProps[index].Name, (uint)allComponents[index].Type, Function.Call<int>(Hash.GET_PED_PROP_INDEX, (InputArgument)(Entity)ped, (InputArgument)(uint)allProps[index].Type), Function.Call<int>(Hash.GET_PED_PROP_TEXTURE_INDEX, (InputArgument)(Entity)ped, (InputArgument)(uint)allProps[index].Type), true);
            Function.Call(Hash.SET_TEXT_COLOUR, (InputArgument)0, (InputArgument)(int)byte.MaxValue, (InputArgument)0, (InputArgument)100);
            Screen.ShowHelpText("~BLIP_INFO_ICON~ Outfit has been ~g~Successfully~w~ Saved", 3000);
        }

        public static Prop bagModelReturn(Ped ped)
        {
            Prop[] nearbyProps1 = World.GetNearbyProps(ped.Position, 2f, (Model)Main.GetHashKey(InventoryBag.bagModel));
            Prop[] nearbyProps2 = World.GetNearbyProps(ped.Position, 2f, (Model)Main.GetHashKey(InventoryBag.bagModelFull));
            Prop prop1 = (Prop)null;
            if (((IEnumerable<Prop>)nearbyProps1).Count<Prop>() > 0)
            {
                foreach (Prop prop2 in nearbyProps1)
                {
                    if ((Entity)prop2 != (Entity)null && prop2.IsAttachedTo((Entity)ped))
                        prop1 = prop2;
                }
            }
            else if (((IEnumerable<Prop>)nearbyProps2).Count<Prop>() > 0)
            {
                foreach (Prop prop3 in nearbyProps2)
                {
                    if ((Entity)prop3 != (Entity)null && prop3.IsAttachedTo((Entity)ped))
                        prop1 = prop3;
                }
            }
            else
                prop1 = (Prop)null;
            return prop1;
        }

        public static bool VehicleWithBag(Ped ped)
        {
            bool flag = false;
            string name = ((PedHash)ped.Model).ToString();
            if (char.IsDigit(name[0]))
                name = "CustomPed_" + name;
            if (Common.doc.Element((XName)"WeaponList").Element((XName)name) == null)
                Common.doc.Element((XName)"WeaponList").Add((object)new XElement((XName)name));
            XElement xelement = Common.doc.Element((XName)"WeaponList").Element((XName)name);
            if ((Entity)ped.CurrentVehicle != (Entity)null)
            {
                Function.Call<string>(Hash.GET_VEHICLE_NUMBER_PLATE_TEXT, (InputArgument)(Entity)ped.CurrentVehicle);
                Function.Call<string>(Hash.GET_DISPLAY_NAME_FROM_VEHICLE_MODEL, (InputArgument)ped.CurrentVehicle.Model);
                VehicleHash model = (VehicleHash)ped.CurrentVehicle.Model;
                if (xelement.Element((XName)"place") != null && xelement.Element((XName)"place").Element((XName)"Vehicle") != null && xelement.Element((XName)"place").Element((XName)"Vehicle").Attribute((XName)"Name") != null && xelement.Element((XName)"place").Element((XName)"Vehicle").Attribute((XName)"Plate") != null && xelement.Element((XName)"place").Element((XName)"Vehicle").Attribute((XName)"Model") != null && (ped.CurrentVehicle.DisplayName == xelement.Element((XName)"place").Element((XName)"Vehicle").Attribute((XName)"Name").Value || model.ToString() == xelement.Element((XName)"place").Element((XName)"Vehicle").Attribute((XName)"Model").Value) && Function.Call<string>(Hash.GET_VEHICLE_NUMBER_PLATE_TEXT, (InputArgument)(Entity)ped.CurrentVehicle) == xelement.Element((XName)"place").Element((XName)"Vehicle").Attribute((XName)"Plate").Value)
                    flag = true;
            }
            return flag;
        }

        public static bool isStrapAttachedToPed(Prop bag, Ped ped)
        {
            bool ped1 = false;
            Prop[] nearbyProps = World.GetNearbyProps(ped.Position, 2f, (Model)Main.GetHashKey("prop_cs_heist_bag_strap_01"));
            if (((IEnumerable<Prop>)nearbyProps).Count<Prop>() > 0)
            {
                foreach (Prop prop in nearbyProps)
                {
                    if ((Entity)prop != (Entity)null && prop.IsAttachedTo((Entity)bag))
                        ped1 = true;
                }
            }
            return ped1;
        }

        public static void strapSet(Prop bag, Ped ped)
        {
            float num1 = -0.15f;
            float num2 = 0.14f;
            float num3 = 0.37f;
            float num4 = 60f;
            float num5 = -170f;
            float num6 = -60f;
            bool flag = false;
            Prop[] nearbyProps = World.GetNearbyProps(ped.Position, 2f, (Model)Main.GetHashKey("prop_cs_heist_bag_strap_01"));
            if (!InventoryBag.changedPosition)
            {
                if (((IEnumerable<Prop>)nearbyProps).Count<Prop>() > 0)
                {
                    foreach (Prop prop in nearbyProps)
                    {
                        if ((Entity)prop != (Entity)null && !prop.IsAttachedTo((Entity)bag) && !prop.IsAttached())
                        {
                            int num7 = Function.Call<int>(Hash.GET_PED_BONE_INDEX, (InputArgument)(Entity)bag, (InputArgument)0);
                            bag.SetNoCollision((Entity)prop, false);
                            Function.Call(Hash.ATTACH_ENTITY_TO_ENTITY, (InputArgument)(Entity)prop, (InputArgument)(Entity)bag, (InputArgument)num7, (InputArgument)num1, (InputArgument)num2, (InputArgument)num3, (InputArgument)num4, (InputArgument)num5, (InputArgument)num6, (InputArgument)true, (InputArgument)true, (InputArgument)false, (InputArgument)false, (InputArgument)0, (InputArgument)true);
                            flag = true;
                        }
                    }
                    if (flag)
                        return;
                    int num8 = Function.Call<int>(Hash.GET_PED_BONE_INDEX, (InputArgument)(Entity)bag, (InputArgument)0);
                    Prop prop1 = World.CreateProp((Model)Main.GetHashKey("prop_cs_heist_bag_strap_01"), bag.Position, bag.Rotation, true, true);
                    bag.SetNoCollision((Entity)prop1, false);
                    Function.Call(Hash.ATTACH_ENTITY_TO_ENTITY, (InputArgument)(Entity)prop1, (InputArgument)(Entity)bag, (InputArgument)num8, (InputArgument)num1, (InputArgument)num2, (InputArgument)num3, (InputArgument)num4, (InputArgument)num5, (InputArgument)num6, (InputArgument)true, (InputArgument)true, (InputArgument)false, (InputArgument)false, (InputArgument)0, (InputArgument)true);
                }
                else
                {
                    int num9 = Function.Call<int>(Hash.GET_PED_BONE_INDEX, (InputArgument)(Entity)bag, (InputArgument)0);
                    Prop prop = World.CreateProp((Model)Main.GetHashKey("prop_cs_heist_bag_strap_01"), bag.Position, bag.Rotation, true, true);
                    bag.SetNoCollision((Entity)prop, false);
                    Function.Call(Hash.ATTACH_ENTITY_TO_ENTITY, (InputArgument)(Entity)prop, (InputArgument)(Entity)bag, (InputArgument)num9, (InputArgument)num1, (InputArgument)num2, (InputArgument)num3, (InputArgument)num4, (InputArgument)num5, (InputArgument)num6, (InputArgument)true, (InputArgument)true, (InputArgument)false, (InputArgument)false, (InputArgument)0, (InputArgument)true);
                }
            }
            else
            {
                foreach (Prop prop in nearbyProps)
                {
                    if ((Entity)prop != (Entity)null && prop.IsAttachedTo((Entity)bag))
                        prop.Delete();
                }
            }
        }

        public static void bagSet(string bagModelSend, Ped ped)
        {
            Prop[] nearbyProps = World.GetNearbyProps(ped.Position, 2f, (Model)Main.GetHashKey(bagModelSend));
            InventoryBag.cur_bag = InventoryBag.bagModelReturn(ped);
            if (!((Entity)ped != (Entity)null))
                return;
            if (!Common.isOccupied(ped) && !Main.isOccupiedNative(ped) && !Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)ped, (InputArgument)"oddjobs@basejump@ig_15", (InputArgument)"puton_parachute", (InputArgument)3))
            {
                Function.Call(Hash.TASK_PLAY_ANIM, (InputArgument)(Entity)ped, (InputArgument)"oddjobs@basejump@ig_15", (InputArgument)"puton_parachute", (InputArgument)45f, (InputArgument)(-12.0), (InputArgument)1000, (InputArgument)48, (InputArgument)0.0f, (InputArgument)0, (InputArgument)0, (InputArgument)0);
                Main.soundFX(ped, "holdStrap.wav", Common.assetFolder);
                int num = Function.Call<int>(Hash.GET_PED_BONE_INDEX, (InputArgument)(Entity)ped, (InputArgument)57005);
                if ((Entity)InventoryBag.bagModelReturn(ped) != (Entity)null)
                    Function.Call(Hash.ATTACH_ENTITY_TO_ENTITY, (InputArgument)(Entity)InventoryBag.cur_bag, (InputArgument)(Entity)ped, (InputArgument)num, (InputArgument)0.35f, (InputArgument)0.13f, (InputArgument)(-0.18f), (InputArgument)45.8999f, (InputArgument)84.6992f, (InputArgument)180.1992f, (InputArgument)true, (InputArgument)true, (InputArgument)false, (InputArgument)false, (InputArgument)2, (InputArgument)true);
            }
            Script.Wait(1000);
            if (Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)ped, (InputArgument)"oddjobs@basejump@ig_15", (InputArgument)"puton_parachute", (InputArgument)3) && (double)Function.Call<float>(Hash.GET_ENTITY_ANIM_CURRENT_TIME, (InputArgument)(Entity)ped, (InputArgument)"oddjobs@basejump@ig_15", (InputArgument)"puton_parachute") == 0.30000001192092896)
                Function.Call(Hash.STOP_ENTITY_ANIM, (InputArgument)(Entity)ped, (InputArgument)"puton_parachute", (InputArgument)"oddjobs@basejump@ig_15", (InputArgument)3);
            if ((Entity)InventoryBag.cur_bag == (Entity)null)
            {
                if (((IEnumerable<Prop>)nearbyProps).Count<Prop>() > 0)
                {
                    foreach (Prop bag in nearbyProps)
                    {
                        if ((Entity)bag != (Entity)null && !bag.IsAttached())
                        {
                            InventoryBag.cur_bag = bag;
                            bag.SetNoCollision((Entity)ped, false);
                            InventoryBag.AttachBag(bag, ped);
                            if (InventoryBag.drawStrap)
                                InventoryBag.strapSet(bag, ped);
                            Common.clearTrash();
                            break;
                        }
                    }
                }
                else
                {
                    Prop prop = World.CreateProp((Model)Main.GetHashKey(bagModelSend), ped.Position, ped.Rotation, true, true);
                    if ((Entity)prop != (Entity)null)
                    {
                        prop.SetNoCollision((Entity)ped, false);
                        InventoryBag.AttachBag(prop, ped);
                        if (InventoryBag.drawStrap)
                            InventoryBag.strapSet(prop, ped);
                    }
                    InventoryBag.cur_bag = prop;
                }
            }
            else
                InventoryBag.AttachBag(InventoryBag.cur_bag, ped);
            string name = ((PedHash)ped.Model).ToString();
            if (char.IsDigit(name[0]))
                name = "CustomPed_" + name;
            if (Common.doc.Element((XName)"WeaponList").Element((XName)name) == null)
                Common.doc.Element((XName)"WeaponList").Add((object)new XElement((XName)name));
            if (Common.doc.Element((XName)"WeaponList").Element((XName)name).Attribute((XName)"bag") == null)
            {
                Common.doc.Element((XName)"WeaponList").Element((XName)name).Add((object)new XAttribute((XName)"bag", (object)true));
                Common.saveDoc();
                Common.doc.Element((XName)"WeaponList").Element((XName)name).Attribute((XName)"bag").SetValue((object)true);
                Common.saveDoc();
            }
            else
            {
                Common.doc.Element((XName)"WeaponList").Element((XName)name).Attribute((XName)"bag").SetValue((object)true);
                Common.saveDoc();
            }
            if (Common.doc.Element((XName)"WeaponList").Element((XName)name).Element((XName)"place") == null)
                return;
            Common.doc.Element((XName)"WeaponList").Element((XName)name).Element((XName)"place").RemoveAll();
            Common.saveDoc();
        }

        public static void TakeOffBagInCar(Prop bag, Ped ped)
        {
            World.GetNearbyProps(ped.Position, 2f, bag.Model);
            if (!Common.isOccupied(ped) && !Main.isOccupiedNative(ped) && !Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)ped, (InputArgument)"anim@heists@money_grab@duffel", (InputArgument)"enter", (InputArgument)3))
            {
                if (!ped.IsSittingInVehicle())
                    ped.Task.PlayAnimation("anim@heists@money_grab@duffel", "enter", 8f, 2000, AnimationFlags.None);
                else
                    ped.Task.PlayAnimation("anim@heists@money_grab@duffel", "enter", 8f, 1000, AnimationFlags.UpperBodyOnly);
                Main.soundFX(ped, "holdStrap.wav", Common.assetFolder);
                int num1 = Function.Call<int>(Hash.GET_PED_BONE_INDEX, (InputArgument)(Entity)ped, (InputArgument)57005);
                bag = InventoryBag.bagModelReturn(ped);
                if ((Entity)InventoryBag.bagModelReturn(ped) != (Entity)null)
                {
                    Function.Call(Hash.ATTACH_ENTITY_TO_ENTITY, (InputArgument)(Entity)bag, (InputArgument)(Entity)ped, (InputArgument)num1, (InputArgument)0.35f, (InputArgument)0.13f, (InputArgument)(-0.18f), (InputArgument)45.8999f, (InputArgument)84.6992f, (InputArgument)180.1992f, (InputArgument)true, (InputArgument)true, (InputArgument)false, (InputArgument)false, (InputArgument)2, (InputArgument)true);
                    if (InventoryBag.drawStrap)
                    {
                        Prop[] nearbyProps = World.GetNearbyProps(ped.Position, 2f, (Model)Main.GetHashKey("prop_cs_heist_bag_strap_01"));
                        if (((IEnumerable<Prop>)nearbyProps).Count<Prop>() > 0)
                        {
                            foreach (Prop prop in nearbyProps)
                            {
                                if ((Entity)prop != (Entity)null && prop.IsAttachedTo((Entity)bag))
                                    prop.IsVisible = false;
                            }
                        }
                    }
                }
                Script.Wait(700);
                if (ped.IsSittingInVehicle())
                {
                    bag.IsVisible = false;
                    int num2 = Function.Call<int>(Hash.GET_PED_BONE_INDEX, (InputArgument)(Entity)ped, (InputArgument)InventoryBag.bag_attach_bone);
                    if (InventoryBag.changedPosition)
                    {
                        InventoryBag.changedPosition = true;
                        Function.Call(Hash.ATTACH_ENTITY_TO_ENTITY, (InputArgument)(Entity)bag, (InputArgument)(Entity)ped, (InputArgument)num2, (InputArgument)InventoryBag.xdg, (InputArgument)InventoryBag.ydg, (InputArgument)InventoryBag.zdg, (InputArgument)InventoryBag.xrdg, (InputArgument)InventoryBag.yrdg, (InputArgument)InventoryBag.zrdg, (InputArgument)true, (InputArgument)true, (InputArgument)false, (InputArgument)false, (InputArgument)0, (InputArgument)true);
                    }
                    else
                        Function.Call(Hash.ATTACH_ENTITY_TO_ENTITY, (InputArgument)(Entity)bag, (InputArgument)(Entity)ped, (InputArgument)num2, (InputArgument)InventoryBag.xd, (InputArgument)InventoryBag.yd, (InputArgument)InventoryBag.zd, (InputArgument)InventoryBag.xrd, (InputArgument)InventoryBag.yrd, (InputArgument)InventoryBag.zrd, (InputArgument)true, (InputArgument)true, (InputArgument)false, (InputArgument)false, (InputArgument)2, (InputArgument)true);
                }
            }
            InventoryBag.canPutOnBagOnExit = true;
        }

        public static void looseBagFunc(Ped ped, Prop bag)
        {
            string name = ((PedHash)ped.Model).ToString();
            if (char.IsDigit(name[0]))
                name = "CustomPed_" + name;
            if (Common.doc.Element((XName)"WeaponList").Element((XName)name) == null)
                Common.doc.Element((XName)"WeaponList").Add((object)new XElement((XName)name));
            if (Common.doc.Element((XName)"WeaponList").Element((XName)name).Attribute((XName)nameof(bag)) == null)
            {
                Common.doc.Element((XName)"WeaponList").Element((XName)name).Add((object)new XAttribute((XName)nameof(bag), (object)false));
                Common.saveDoc();
                Common.doc.Element((XName)"WeaponList").Element((XName)name).Attribute((XName)nameof(bag)).SetValue((object)false);
                Common.saveDoc();
            }
            else
            {
                Common.doc.Element((XName)"WeaponList").Element((XName)name).Attribute((XName)nameof(bag)).SetValue((object)false);
                Common.saveDoc();
            }
            if (Common.doc.Element((XName)"WeaponList").Element((XName)name).Element((XName)"place") != null)
            {
                Common.doc.Element((XName)"WeaponList").Element((XName)name).Element((XName)"place").RemoveAll();
                Common.saveDoc();
            }
            if (Common.doc.Element((XName)"WeaponList").Element((XName)name).Attribute((XName)"holster") == null)
            {
                Common.doc.Element((XName)"WeaponList").Element((XName)name).Add((object)new XAttribute((XName)"holster", (object)false));
                Common.saveDoc();
                Common.doc.Element((XName)"WeaponList").Element((XName)name).Attribute((XName)"holster").SetValue((object)false);
                Common.saveDoc();
            }
            else
            {
                Common.doc.Element((XName)"WeaponList").Element((XName)name).Attribute((XName)"holster").SetValue((object)false);
                Common.saveDoc();
            }
            InventoryBag.ClearInventoryData(ped);
            Screen.ShowHelpTextThisFrame("~BLIP_INFO_ICON~ ~r~You've lost~w~ your gear");
            Function.Call(Hash.SET_TEXT_COLOUR, (InputArgument)(int)byte.MaxValue, (InputArgument)0, (InputArgument)0, (InputArgument)100);
            Main.Notify("~r~You've lost your gear", "IBAG", (int)byte.MaxValue, 0, 0, NotificationIcon.Ammunation);
            if (!((Entity)bag != (Entity)null) || !bag.IsAttachedTo((Entity)Game.Player.Character))
                return;
            bag.MarkAsNoLongerNeeded();
            bag.Detach();
        }

        public static void DropBagFunc(Ped ped, Prop bag)
        {
            Prop[] nearbyProps1 = World.GetNearbyProps(ped.Position, 5f, bag.Model);
            if (((IEnumerable<Prop>)nearbyProps1).Count<Prop>() > 0)
            {
                foreach (Prop prop1 in nearbyProps1)
                {
                    if ((Entity)prop1 != (Entity)null && prop1.IsAttachedTo((Entity)ped))
                    {
                        if (InventoryBag.drawStrap)
                        {
                            Prop[] nearbyProps2 = World.GetNearbyProps(ped.Position, 2f, (Model)Main.GetHashKey("prop_cs_heist_bag_strap_01"));
                            if (((IEnumerable<Prop>)nearbyProps2).Count<Prop>() > 0)
                            {
                                foreach (Prop prop2 in nearbyProps2)
                                {
                                    if ((Entity)prop2 != (Entity)null && prop2.IsAttachedTo((Entity)bag))
                                        prop2.Delete();
                                }
                            }
                        }
                        prop1.Delete();
                    }
                }
            }
            Vector3 position = new Vector3(ped.Position.X, ped.Position.Y, ped.Position.Z + 3f);
            float num = World.GetGroundHeight(new Vector2(position.X, position.Y)) + 0.5f;
            position.Z = (double)position.Z < (double)num ? num : position.Z;
            Prop prop = World.CreateProp((Model)InventoryBag.stashedBagModel, position, true, true);
            string name = ((PedHash)ped.Model).ToString();
            if (char.IsDigit(name[0]))
                name = "CustomPed_" + name;
            if (Common.doc.Element((XName)"WeaponList").Element((XName)name) == null)
                Common.doc.Element((XName)"WeaponList").Add((object)new XElement((XName)name));
            if (Common.doc.Element((XName)"WeaponList").Element((XName)name).Attribute((XName)nameof(bag)) == null)
            {
                Common.doc.Element((XName)"WeaponList").Element((XName)name).Add((object)new XAttribute((XName)nameof(bag), (object)false));
                Common.saveDoc();
                Common.doc.Element((XName)"WeaponList").Element((XName)name).Attribute((XName)nameof(bag)).SetValue((object)false);
                Common.saveDoc();
            }
            else
            {
                Common.doc.Element((XName)"WeaponList").Element((XName)name).Attribute((XName)nameof(bag)).SetValue((object)false);
                Common.saveDoc();
            }
            if (Common.doc.Element((XName)"WeaponList").Element((XName)name).Element((XName)"place") == null)
            {
                Common.doc.Element((XName)"WeaponList").Element((XName)name).Add((object)new XElement((XName)"place"));
                Common.saveDoc();
            }
            if (ped.IsSittingInVehicle())
            {
                string str1 = Function.Call<string>(Hash.GET_VEHICLE_NUMBER_PLATE_TEXT, (InputArgument)(Entity)ped.CurrentVehicle);
                string str2 = Function.Call<string>(Hash.GET_DISPLAY_NAME_FROM_VEHICLE_MODEL, (InputArgument)ped.CurrentVehicle.Model);
                VehicleHash model = (VehicleHash)ped.CurrentVehicle.Model;
                if (Common.doc.Element((XName)"WeaponList").Element((XName)name).Element((XName)"place").Element((XName)"Location") != null)
                {
                    Common.doc.Element((XName)"WeaponList").Element((XName)name).Element((XName)"place").Element((XName)"Location").Remove();
                    Common.saveDoc();
                }
                if (Common.doc.Element((XName)"WeaponList").Element((XName)name).Element((XName)"place").Element((XName)"Vehicle") == null)
                {
                    Common.doc.Element((XName)"WeaponList").Element((XName)name).Element((XName)"place").Add((object)new XElement((XName)"Vehicle"));
                    Common.saveDoc();
                }
                if (Common.doc.Element((XName)"WeaponList").Element((XName)name).Element((XName)"place").Element((XName)"Vehicle").Attribute((XName)"Name") == null)
                {
                    Common.doc.Element((XName)"WeaponList").Element((XName)name).Element((XName)"place").Element((XName)"Vehicle").Add((object)new XAttribute((XName)"Name", (object)str2));
                    Common.saveDoc();
                }
                else
                {
                    Common.doc.Element((XName)"WeaponList").Element((XName)name).Element((XName)"place").Element((XName)"Vehicle").Attribute((XName)"Name").SetValue((object)str2);
                    Common.saveDoc();
                }
                if (Common.doc.Element((XName)"WeaponList").Element((XName)name).Element((XName)"place").Element((XName)"Vehicle").Attribute((XName)"Model") == null)
                {
                    Common.doc.Element((XName)"WeaponList").Element((XName)name).Element((XName)"place").Element((XName)"Vehicle").Add((object)new XAttribute((XName)"Model", (object)model));
                    Common.saveDoc();
                }
                else
                {
                    Common.doc.Element((XName)"WeaponList").Element((XName)name).Element((XName)"place").Element((XName)"Vehicle").Attribute((XName)"Plate").SetValue((object)str1);
                    Common.saveDoc();
                }
                if (Common.doc.Element((XName)"WeaponList").Element((XName)name).Element((XName)"place").Element((XName)"Vehicle").Attribute((XName)"Plate") == null)
                {
                    Common.doc.Element((XName)"WeaponList").Element((XName)name).Element((XName)"place").Element((XName)"Vehicle").Add((object)new XAttribute((XName)"Plate", (object)str1));
                    Common.saveDoc();
                }
                else
                {
                    Common.doc.Element((XName)"WeaponList").Element((XName)name).Element((XName)"place").Element((XName)"Vehicle").Attribute((XName)"Plate").SetValue((object)str1);
                    Common.saveDoc();
                }
                if (!((Entity)prop != (Entity)null))
                    return;
                Common.blipHandle(true, (Entity)ped.CurrentVehicle, BlipSprite.Information, "DuffleBag", 0.85f, 200, false, false);
            }
            else
            {
                if (Common.doc.Element((XName)"WeaponList").Element((XName)name).Element((XName)"place").Element((XName)"Vehicle") != null)
                {
                    Common.doc.Element((XName)"WeaponList").Element((XName)name).Element((XName)"place").Element((XName)"Vehicle").RemoveAll();
                    Common.saveDoc();
                }
                if (Common.doc.Element((XName)"WeaponList").Element((XName)name).Element((XName)"place").Element((XName)"Location") == null)
                {
                    Common.doc.Element((XName)"WeaponList").Element((XName)name).Element((XName)"place").Add((object)new XElement((XName)"Location"));
                    Common.saveDoc();
                }
                if (Common.doc.Element((XName)"WeaponList").Element((XName)name).Element((XName)"place").Element((XName)"Location").Attribute((XName)"X") == null)
                {
                    Common.doc.Element((XName)"WeaponList").Element((XName)name).Element((XName)"place").Element((XName)"Location").Add((object)new XAttribute((XName)"X", (object)position.X));
                    Common.saveDoc();
                }
                else
                {
                    Common.doc.Element((XName)"WeaponList").Element((XName)name).Element((XName)"place").Element((XName)"Location").Attribute((XName)"X").SetValue((object)position.X);
                    Common.saveDoc();
                }
                if (Common.doc.Element((XName)"WeaponList").Element((XName)name).Element((XName)"place").Element((XName)"Location").Attribute((XName)"Y") == null)
                {
                    Common.doc.Element((XName)"WeaponList").Element((XName)name).Element((XName)"place").Element((XName)"Location").Add((object)new XAttribute((XName)"Y", (object)position.Y));
                    Common.saveDoc();
                }
                else
                {
                    Common.doc.Element((XName)"WeaponList").Element((XName)name).Element((XName)"place").Element((XName)"Location").Attribute((XName)"Y").SetValue((object)position.Y);
                    Common.saveDoc();
                }
                if (Common.doc.Element((XName)"WeaponList").Element((XName)name).Element((XName)"place").Element((XName)"Location").Attribute((XName)"Z") == null)
                {
                    Common.doc.Element((XName)"WeaponList").Element((XName)name).Element((XName)"place").Element((XName)"Location").Add((object)new XAttribute((XName)"Z", (object)position.Z));
                    Common.saveDoc();
                }
                else
                {
                    Common.doc.Element((XName)"WeaponList").Element((XName)name).Element((XName)"place").Element((XName)"Location").Attribute((XName)"Z").SetValue((object)position.Z);
                    Common.saveDoc();
                }
                if (!((Entity)prop != (Entity)null))
                    return;
                Common.blipHandle(true, (Entity)prop, BlipSprite.Information, "DuffleBag", 0.85f, 200, false, false);
            }
        }

        public static void bagRemove(Prop bag, Ped ped)
        {
            Prop[] nearbyProps1 = World.GetNearbyProps(ped.Position, 2f, bag.Model);
            if (!Common.isOccupied(ped) && !Main.isOccupiedNative(ped) && !Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)ped, (InputArgument)"anim@heists@money_grab@duffel", (InputArgument)"enter", (InputArgument)3))
            {
                if (ped.IsSittingInVehicle())
                {
                    if (InventoryBag.bagModelReturn(ped).IsVisible)
                        ped.Task.PlayAnimation("anim@heists@money_grab@duffel", "enter", 8f, 1000, AnimationFlags.UpperBodyOnly);
                    else if (!Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)ped, (InputArgument)"veh@driveby@first_person@passenger_rear_right_handed@smg", (InputArgument)"outro_0", (InputArgument)3))
                        ped.Task.PlayAnimation("veh@driveby@first_person@passenger_rear_right_handed@smg", "outro_0", 8f, 1000, AnimationFlags.UpperBodyOnly);
                }
                Main.soundFX(ped, "holdStrap.wav", Common.assetFolder);
                int num = Function.Call<int>(Hash.GET_PED_BONE_INDEX, (InputArgument)(Entity)ped, (InputArgument)57005);
                if ((Entity)InventoryBag.bagModelReturn(ped) != (Entity)null)
                    Function.Call(Hash.ATTACH_ENTITY_TO_ENTITY, (InputArgument)(Entity)InventoryBag.bagModelReturn(ped), (InputArgument)(Entity)ped, (InputArgument)num, (InputArgument)0.35f, (InputArgument)0.13f, (InputArgument)(-0.18f), (InputArgument)45.8999f, (InputArgument)84.6992f, (InputArgument)180.1992f, (InputArgument)true, (InputArgument)true, (InputArgument)false, (InputArgument)false, (InputArgument)2, (InputArgument)true);
            }
            if (((IEnumerable<Prop>)nearbyProps1).Count<Prop>() > 0)
            {
                foreach (Prop prop1 in nearbyProps1)
                {
                    if ((Entity)prop1 != (Entity)null && prop1.IsAttachedTo((Entity)ped))
                    {
                        if (InventoryBag.drawStrap)
                        {
                            Prop[] nearbyProps2 = World.GetNearbyProps(ped.Position, 2f, (Model)Main.GetHashKey("prop_cs_heist_bag_strap_01"));
                            if (((IEnumerable<Prop>)nearbyProps2).Count<Prop>() > 0)
                            {
                                foreach (Prop prop2 in nearbyProps2)
                                {
                                    if ((Entity)prop2 != (Entity)null && prop2.IsAttachedTo((Entity)bag))
                                        prop2.Delete();
                                }
                            }
                        }
                        prop1.Delete();
                    }
                }
            }
            Vector3 position = new Vector3(ped.Position.X, ped.Position.Y, ped.Position.Z - 1f);
            Prop prop = World.CreateProp((Model)InventoryBag.stashedBagModel, position, true, false);
            string name = ((PedHash)ped.Model).ToString();
            if (char.IsDigit(name[0]))
                name = "CustomPed_" + name;
            if (Common.doc.Element((XName)"WeaponList").Element((XName)name) == null)
                Common.doc.Element((XName)"WeaponList").Add((object)new XElement((XName)name));
            if (Common.doc.Element((XName)"WeaponList").Element((XName)name).Attribute((XName)nameof(bag)) == null)
            {
                Common.doc.Element((XName)"WeaponList").Element((XName)name).Add((object)new XAttribute((XName)nameof(bag), (object)false));
                Common.saveDoc();
                Common.doc.Element((XName)"WeaponList").Element((XName)name).Attribute((XName)nameof(bag)).SetValue((object)false);
                Common.saveDoc();
            }
            else
            {
                Common.doc.Element((XName)"WeaponList").Element((XName)name).Attribute((XName)nameof(bag)).SetValue((object)false);
                Common.saveDoc();
            }
            if (Common.doc.Element((XName)"WeaponList").Element((XName)name).Element((XName)"place") == null)
            {
                Common.doc.Element((XName)"WeaponList").Element((XName)name).Add((object)new XElement((XName)"place"));
                Common.saveDoc();
            }
            if (ped.IsSittingInVehicle())
            {
                string str1 = Function.Call<string>(Hash.GET_VEHICLE_NUMBER_PLATE_TEXT, (InputArgument)(Entity)ped.CurrentVehicle);
                string str2 = Function.Call<string>(Hash.GET_DISPLAY_NAME_FROM_VEHICLE_MODEL, (InputArgument)ped.CurrentVehicle.Model);
                VehicleHash model = (VehicleHash)ped.CurrentVehicle.Model;
                if (Common.doc.Element((XName)"WeaponList").Element((XName)name).Element((XName)"place").Element((XName)"Location") != null)
                {
                    Common.doc.Element((XName)"WeaponList").Element((XName)name).Element((XName)"place").Element((XName)"Location").Remove();
                    Common.saveDoc();
                }
                if (Common.doc.Element((XName)"WeaponList").Element((XName)name).Element((XName)"place").Element((XName)"Vehicle") == null)
                {
                    Common.doc.Element((XName)"WeaponList").Element((XName)name).Element((XName)"place").Add((object)new XElement((XName)"Vehicle"));
                    Common.saveDoc();
                }
                if (Common.doc.Element((XName)"WeaponList").Element((XName)name).Element((XName)"place").Element((XName)"Vehicle").Attribute((XName)"Name") == null)
                {
                    Common.doc.Element((XName)"WeaponList").Element((XName)name).Element((XName)"place").Element((XName)"Vehicle").Add((object)new XAttribute((XName)"Name", (object)str2));
                    Common.saveDoc();
                }
                else
                {
                    Common.doc.Element((XName)"WeaponList").Element((XName)name).Element((XName)"place").Element((XName)"Vehicle").Attribute((XName)"Name").SetValue((object)str2);
                    Common.saveDoc();
                }
                if (Common.doc.Element((XName)"WeaponList").Element((XName)name).Element((XName)"place").Element((XName)"Vehicle").Attribute((XName)"Model") == null)
                {
                    Common.doc.Element((XName)"WeaponList").Element((XName)name).Element((XName)"place").Element((XName)"Vehicle").Add((object)new XAttribute((XName)"Model", (object)model));
                    Common.saveDoc();
                }
                else
                {
                    Common.doc.Element((XName)"WeaponList").Element((XName)name).Element((XName)"place").Element((XName)"Vehicle").Attribute((XName)"Model").SetValue((object)model);
                    Common.saveDoc();
                }
                if (Common.doc.Element((XName)"WeaponList").Element((XName)name).Element((XName)"place").Element((XName)"Vehicle").Attribute((XName)"Plate") == null)
                {
                    Common.doc.Element((XName)"WeaponList").Element((XName)name).Element((XName)"place").Element((XName)"Vehicle").Add((object)new XAttribute((XName)"Plate", (object)str1));
                    Common.saveDoc();
                }
                else
                {
                    Common.doc.Element((XName)"WeaponList").Element((XName)name).Element((XName)"place").Element((XName)"Vehicle").Attribute((XName)"Plate").SetValue((object)str1);
                    Common.saveDoc();
                }
                if (!((Entity)prop != (Entity)null))
                    return;
                Common.blipHandle(true, (Entity)ped.CurrentVehicle, BlipSprite.Information, "DuffleBag", 0.85f, 200, false, false);
            }
            else
            {
                if (Common.doc.Element((XName)"WeaponList").Element((XName)name).Element((XName)"place").Element((XName)"Vehicle") != null)
                {
                    Common.doc.Element((XName)"WeaponList").Element((XName)name).Element((XName)"place").Element((XName)"Vehicle").RemoveAll();
                    Common.saveDoc();
                }
                if (Common.doc.Element((XName)"WeaponList").Element((XName)name).Element((XName)"place").Element((XName)"Location") == null)
                {
                    Common.doc.Element((XName)"WeaponList").Element((XName)name).Element((XName)"place").Add((object)new XElement((XName)"Location"));
                    Common.saveDoc();
                }
                if (Common.doc.Element((XName)"WeaponList").Element((XName)name).Element((XName)"place").Element((XName)"Location").Attribute((XName)"X") == null)
                {
                    Common.doc.Element((XName)"WeaponList").Element((XName)name).Element((XName)"place").Element((XName)"Location").Add((object)new XAttribute((XName)"X", (object)ped.Position.X));
                    Common.saveDoc();
                }
                else
                {
                    Common.doc.Element((XName)"WeaponList").Element((XName)name).Element((XName)"place").Element((XName)"Location").Attribute((XName)"X").SetValue((object)ped.Position.X);
                    Common.saveDoc();
                }
                if (Common.doc.Element((XName)"WeaponList").Element((XName)name).Element((XName)"place").Element((XName)"Location").Attribute((XName)"Y") == null)
                {
                    Common.doc.Element((XName)"WeaponList").Element((XName)name).Element((XName)"place").Element((XName)"Location").Add((object)new XAttribute((XName)"Y", (object)ped.Position.Y));
                    Common.saveDoc();
                }
                else
                {
                    Common.doc.Element((XName)"WeaponList").Element((XName)name).Element((XName)"place").Element((XName)"Location").Attribute((XName)"Y").SetValue((object)ped.Position.Y);
                    Common.saveDoc();
                }
                if (Common.doc.Element((XName)"WeaponList").Element((XName)name).Element((XName)"place").Element((XName)"Location").Attribute((XName)"Z") == null)
                {
                    Common.doc.Element((XName)"WeaponList").Element((XName)name).Element((XName)"place").Element((XName)"Location").Add((object)new XAttribute((XName)"Z", (object)ped.Position.Z));
                    Common.saveDoc();
                }
                else
                {
                    Common.doc.Element((XName)"WeaponList").Element((XName)name).Element((XName)"place").Element((XName)"Location").Attribute((XName)"Z").SetValue((object)ped.Position.Z);
                    Common.saveDoc();
                }
                if (!((Entity)prop != (Entity)null))
                    return;
                Common.blipHandle(true, (Entity)prop, BlipSprite.Information, "DuffleBag", 0.85f, 200, false, false);
            }
        }

        public static void AttachBag(Prop bag, Ped ped)
        {
            InventoryBag.checkBagVisibility(ped);
            if (!((Entity)bag != (Entity)null) || !bag.Exists() || !((Entity)ped != (Entity)null) || !ped.Exists())
                return;
            if ((Entity)ped.CurrentVehicle != (Entity)null)
                Function.Call(Hash.SET_ENTITY_NO_COLLISION_ENTITY, (InputArgument)(Entity)bag, (InputArgument)(Entity)ped.CurrentVehicle, (InputArgument)true);
            int num = Function.Call<int>(Hash.GET_PED_BONE_INDEX, (InputArgument)(Entity)ped, (InputArgument)InventoryBag.bag_attach_bone);
            if (InventoryBag.changedPosition)
                Function.Call(Hash.ATTACH_ENTITY_TO_ENTITY, (InputArgument)(Entity)bag, (InputArgument)(Entity)ped, (InputArgument)num, (InputArgument)InventoryBag.xdg, (InputArgument)InventoryBag.ydg, (InputArgument)InventoryBag.zdg, (InputArgument)InventoryBag.xrdg, (InputArgument)InventoryBag.yrdg, (InputArgument)InventoryBag.zrdg, (InputArgument)true, (InputArgument)true, (InputArgument)false, (InputArgument)false, (InputArgument)0, (InputArgument)true);
            else
                Function.Call(Hash.ATTACH_ENTITY_TO_ENTITY, (InputArgument)(Entity)bag, (InputArgument)(Entity)ped, (InputArgument)num, (InputArgument)InventoryBag.xd, (InputArgument)InventoryBag.yd, (InputArgument)InventoryBag.zd, (InputArgument)InventoryBag.xrd, (InputArgument)InventoryBag.yrd, (InputArgument)InventoryBag.zrd, (InputArgument)true, (InputArgument)true, (InputArgument)false, (InputArgument)false, (InputArgument)2, (InputArgument)true);
        }

        public static void skydive(Ped ped, Prop bag, bool skyDiving)
        {
            if (!((Entity)bag != (Entity)null) || !bag.Exists() || !bag.IsAttachedTo((Entity)ped))
                return;
            if (skyDiving)
            {
                if (InventoryBag.drawStrap)
                {
                    Vector3 position = ped.Position;
                    Model[] modelArray = new Model[1]
                    {
            (Model) Main.GetHashKey("prop_cs_heist_bag_strap_01")
                    };
                    foreach (Prop nearbyProp in World.GetNearbyProps(position, 10f, modelArray))
                    {
                        if ((Entity)nearbyProp != (Entity)null && nearbyProp.IsAttachedTo((Entity)bag))
                            nearbyProp.IsVisible = false;
                    }
                }
                if (ped.IsOnFoot && !ped.IsRagdoll && !ped.IsInAir && !ped.IsInParachuteFreeFall && !Common.isOccupied(ped) && !Main.isOccupiedNative(ped) && !Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)ped, (InputArgument)"anim@heists@money_grab@duffel", (InputArgument)"enter", (InputArgument)3))
                {
                    AnimationFlags flags = AnimationFlags.UpperBodyOnly | AnimationFlags.Secondary | AnimationFlags.AbortOnPedMovement;
                    ped.Task.PlayAnimation("anim@heists@money_grab@duffel", "enter", 8f, 500, flags);
                    Main.soundFX(ped, "holdStrap.wav", Common.assetFolder);
                }
                int num = Function.Call<int>(Hash.GET_PED_BONE_INDEX, (InputArgument)(Entity)ped, (InputArgument)InventoryBag.bag_attach_bone);
                Function.Call(Hash.ATTACH_ENTITY_TO_ENTITY, (InputArgument)(Entity)bag, (InputArgument)(Entity)ped, (InputArgument)num, (InputArgument)InventoryBag.xsdg, (InputArgument)InventoryBag.ysdg, (InputArgument)InventoryBag.zsdg, (InputArgument)InventoryBag.xrsdg, (InputArgument)InventoryBag.yrsdg, (InputArgument)InventoryBag.zrsdg, (InputArgument)true, (InputArgument)true, (InputArgument)false, (InputArgument)false, (InputArgument)0, (InputArgument)true);
            }
            else
            {
                if (!ped.IsOnFoot || ped.IsRagdoll || ped.IsInAir || ped.IsInParachuteFreeFall || Common.isOccupied(ped) || Main.isOccupiedNative(ped))
                    return;
                if (InventoryBag.drawStrap)
                {
                    Vector3 position = ped.Position;
                    Model[] modelArray = new Model[1]
                    {
            (Model) Main.GetHashKey("prop_cs_heist_bag_strap_01")
                    };
                    foreach (Prop nearbyProp in World.GetNearbyProps(position, 10f, modelArray))
                    {
                        if ((Entity)nearbyProp != (Entity)null && nearbyProp.IsAttachedTo((Entity)bag))
                            nearbyProp.IsVisible = true;
                    }
                }
                if (!Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)ped, (InputArgument)"anim@heists@money_grab@duffel", (InputArgument)"enter", (InputArgument)3))
                {
                    ped.Task.PlayAnimation("anim@heists@money_grab@duffel", "enter", 8f, 500, AnimationFlags.UpperBodyOnly | AnimationFlags.Secondary | AnimationFlags.AbortOnPedMovement);
                    Main.soundFX(ped, "holdStrap.wav", Common.assetFolder);
                }
                InventoryBag.AttachBag(bag, ped);
            }
        }

        public static void diving(Ped ped, Prop bag, bool wearingGear)
        {
            if (!((Entity)bag != (Entity)null) || !bag.Exists() || !bag.IsAttachedTo((Entity)ped))
                return;
            if (wearingGear)
            {
                if (InventoryBag.drawStrap)
                {
                    Vector3 position = ped.Position;
                    Model[] modelArray = new Model[1]
                    {
            (Model) Main.GetHashKey("prop_cs_heist_bag_strap_01")
                    };
                    foreach (Prop nearbyProp in World.GetNearbyProps(position, 10f, modelArray))
                    {
                        if ((Entity)nearbyProp != (Entity)null && nearbyProp.IsAttachedTo((Entity)bag))
                            nearbyProp.IsVisible = false;
                    }
                }
                if (ped.IsOnFoot && !ped.IsRagdoll && !ped.IsInAir && !ped.IsInParachuteFreeFall && !Common.isOccupied(ped) && !Main.isOccupiedNative(ped) && !Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)ped, (InputArgument)"anim@heists@money_grab@duffel", (InputArgument)"enter", (InputArgument)3))
                {
                    AnimationFlags flags = AnimationFlags.UpperBodyOnly | AnimationFlags.Secondary | AnimationFlags.AbortOnPedMovement;
                    ped.Task.PlayAnimation("anim@heists@money_grab@duffel", "enter", 8f, 500, flags);
                    Main.soundFX(ped, "holdStrap.wav", Common.assetFolder);
                }
                int num = Function.Call<int>(Hash.GET_PED_BONE_INDEX, (InputArgument)(Entity)ped, (InputArgument)InventoryBag.bag_attach_bone);
                Function.Call(Hash.ATTACH_ENTITY_TO_ENTITY, (InputArgument)(Entity)bag, (InputArgument)(Entity)ped, (InputArgument)num, (InputArgument)InventoryBag.xdg, (InputArgument)InventoryBag.ydg, (InputArgument)InventoryBag.zdg, (InputArgument)InventoryBag.xrdg, (InputArgument)InventoryBag.yrdg, (InputArgument)InventoryBag.zrdg, (InputArgument)true, (InputArgument)true, (InputArgument)false, (InputArgument)false, (InputArgument)0, (InputArgument)true);
            }
            else
            {
                if (!ped.IsOnFoot || ped.IsRagdoll || ped.IsInAir || ped.IsInParachuteFreeFall || Common.isOccupied(ped) || Main.isOccupiedNative(ped))
                    return;
                if (InventoryBag.drawStrap)
                {
                    Vector3 position = ped.Position;
                    Model[] modelArray = new Model[1]
                    {
            (Model) Main.GetHashKey("prop_cs_heist_bag_strap_01")
                    };
                    foreach (Prop nearbyProp in World.GetNearbyProps(position, 10f, modelArray))
                    {
                        if ((Entity)nearbyProp != (Entity)null && nearbyProp.IsAttachedTo((Entity)bag))
                            nearbyProp.IsVisible = true;
                    }
                }
                if (!Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)ped, (InputArgument)"anim@heists@money_grab@duffel", (InputArgument)"enter", (InputArgument)3))
                {
                    AnimationFlags flags = AnimationFlags.UpperBodyOnly | AnimationFlags.Secondary | AnimationFlags.AbortOnPedMovement;
                    ped.Task.PlayAnimation("anim@heists@money_grab@duffel", "enter", 8f, 500, flags);
                    Main.soundFX(ped, "holdStrap.wav", Common.assetFolder);
                }
                InventoryBag.AttachBag(bag, ped);
            }
        }

        public static void WeaponSwitchAnim(Ped ped)
        {
            if ((int)InventoryBag.prevWeapon == (int)Function.Call<uint>(Hash.GET_SELECTED_PED_WEAPON, (InputArgument)(Entity)ped))
                return;
            InventoryBag.prevWeapon = Function.Call<uint>(Hash.GET_SELECTED_PED_WEAPON, (InputArgument)(Entity)ped);
            ped.Task.PlayAnimation("mp_arrest_paired", "cop_p1_rf_right_0", 8f, 500, AnimationFlags.UpperBodyOnly | AnimationFlags.Secondary);
            Main.soundFX(ped, "holdStrap.wav", Common.assetFolder);
        }

        public static void weaponInventoryAnim(Prop bag, Ped ped)
        {
            Prop prop = (Prop)null;
            if (!((Entity)bag != (Entity)null) || !bag.Exists() || !bag.IsAttachedTo((Entity)ped))
                return;
            if (ped.IsOnFoot && InventoryBag.drawStrap)
            {
                Vector3 position = ped.Position;
                Model[] modelArray = new Model[1]
                {
          (Model) Main.GetHashKey("prop_cs_heist_bag_strap_01")
                };
                foreach (Prop nearbyProp in World.GetNearbyProps(position, 10f, modelArray))
                {
                    if ((Entity)nearbyProp != (Entity)null && nearbyProp.IsAttachedTo((Entity)bag))
                        prop = nearbyProp;
                }
            }
            if (InventoryBag.inMenu)
            {
                InventoryBag.reattached = false;
                if (InventoryBag.drawStrap && (Entity)prop != (Entity)null && prop.IsVisible)
                    prop.IsVisible = false;
                if (ped.IsOnFoot)
                {
                    if (!Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)ped, (InputArgument)"anim@heists@money_grab@duffel", (InputArgument)"enter", (InputArgument)3))
                    {
                        ped.Task.PlayAnimation("anim@heists@money_grab@duffel", "enter", 8f, -1, AnimationFlags.StayInEndFrame);
                        Main.soundFX(ped, "holdStrap.wav", Common.assetFolder);
                        int num = Function.Call<int>(Hash.GET_PED_BONE_INDEX, (InputArgument)(Entity)ped, (InputArgument)57005);
                        Function.Call(Hash.ATTACH_ENTITY_TO_ENTITY, (InputArgument)(Entity)bag, (InputArgument)(Entity)ped, (InputArgument)num, (InputArgument)InventoryBag.xh, (InputArgument)InventoryBag.yh, (InputArgument)InventoryBag.zh, (InputArgument)InventoryBag.xrh, (InputArgument)InventoryBag.yrh, (InputArgument)InventoryBag.zrh, (InputArgument)true, (InputArgument)true, (InputArgument)false, (InputArgument)false, (InputArgument)2, (InputArgument)true);
                    }
                }
                else if (!Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)ped, (InputArgument)"veh@driveby@first_person@passenger_rear_right_handed@smg", (InputArgument)"outro_0", (InputArgument)3))
                {
                    ped.Task.PlayAnimation("veh@driveby@first_person@passenger_rear_right_handed@smg", "outro_0", 8f, -1, AnimationFlags.UpperBodyOnly);
                    Main.soundFX(ped, "holdStrap.wav", Common.assetFolder);
                }
            }
            if (InventoryBag.inMenu)
                return;
            if (Common.followCamera)
                Common.followCamera = false;
            if (ped.IsOnFoot)
            {
                if (!Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)ped, (InputArgument)"anim@heists@money_grab@duffel", (InputArgument)"exit", (InputArgument)3))
                {
                    ped.Task.PlayAnimation("anim@heists@money_grab@duffel", "exit", 8f, -1, AnimationFlags.None);
                    Main.soundFX(ped, "holdStrap.wav", Common.assetFolder);
                    if (InventoryBag.drawStrap && (Entity)prop != (Entity)null && !prop.IsVisible)
                        prop.IsVisible = true;
                    Script.Wait(2000);
                    if (!InventoryBag.changedPosition)
                        InventoryBag.checkEquipedGear(ped);
                    else
                        InventoryBag.diving(ped, InventoryBag.bagModelReturn(ped), InventoryBag.changedPosition);
                    ped.CanSwitchWeapons = true;
                }
                if (Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)ped, (InputArgument)"anim@heists@money_grab@duffel", (InputArgument)"loop", (InputArgument)3))
                    ped.Task.ClearAnimation("anim@heists@money_grab@duffel", "loop");
            }
            else if (!Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)ped, (InputArgument)"veh@driveby@first_person@passenger_rear_right_handed@smg", (InputArgument)"outro_0", (InputArgument)3))
            {
                ped.Task.PlayAnimation("veh@driveby@first_person@passenger_rear_right_handed@smg", "outro_0", 8f, -1, AnimationFlags.UpperBodyOnly);
                Main.soundFX(ped, "holdStrap.wav", Common.assetFolder);
            }
            ped.CanSwitchWeapons = true;
        }
    }
}
