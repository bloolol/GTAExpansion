// Decompiled with JetBrains decompiler
// Type: GTAExpansion.WeaponHolster
// Assembly: GTAExpansion, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 57B8053D-C566-4641-A84B-F5EB537251F0
// Assembly location: D:\SteamLibrary\steamapps\common\Grand Theft Auto V\scripts\GTAExpansion.dll

using GTA;
using GTA.Math;
using GTA.Native;
using GTA.UI;
using HTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;


namespace GTAExpansion
{
    public static class WeaponHolster
    {
        public static int weapon_menu_btn = ScriptSettings.Load("scripts\\Expansion\\Expansion.ini").GetValue<int>("WEAPON_MENU", "WEAPON_MENU_BTN", 244);
        public static bool holsted_big_weapons_module_active = ScriptSettings.Load("scripts\\Expansion\\Expansion.ini").GetValue<bool>("HOLSTED_BIG_WEAPONS", "HOLSTED_BIG_WEAPONS_MODULE_ACTIVE", true);
        public static int toggle_holsted_weapon_btn = ScriptSettings.Load("scripts\\Expansion\\Expansion.ini").GetValue<int>("HOLSTED_BIG_WEAPONS", "TOGGLE_VISIBILITY_HOLSTED_WEAPONS_BTN", 172);
        public static int toggle_holsted_weapon_position = ScriptSettings.Load("scripts\\Expansion\\Expansion.ini").GetValue<int>("HOLSTED_BIG_WEAPONS", "CHANGE_HOLSTED_WEAPON_POSITION", 173);
        public static int weaponPositionType = ScriptSettings.Load("scripts\\Expansion\\Expansion.ini").GetValue<int>("HOLSTED_BIG_WEAPONS", "HOLSTED_BIG_WEAPONS_DEFAULT_POSITION", 1);
        public static bool weaponNonPistolInHands = false;
        public static int worldNonPistolWeaponModel;
        public static string[] weaponSoundsFXArray = new string[2]
        {
      "Draw.wav",
      "Draw2.wav"
        };
        public static int weaponSoundFXIndex = 0;
        public static int weaponSoundFXTimer = 100;
        public static Model choosenNonPistolWeapon = (Model)0;
        public static Prop HolstedNonPistolWeapon;
        public static WeaponGroup[] _bigWeaponGroups = new WeaponGroup[6]
        {
      WeaponGroup.MG,
      WeaponGroup.Heavy,
      WeaponGroup.AssaultRifle,
      WeaponGroup.Shotgun,
      WeaponGroup.SMG,
      WeaponGroup.Sniper
        };
        public static Vector3 holstedWeaponAttachPos1 = new Vector3(0.25f, -0.17f, -0.2f);
        public static Vector3 holstedWeaponAttachRot1 = new Vector3(20f, -90f, -90f);
        public static int holstedWeaponAttachBone1 = 10706;
        public static Vector3 holstedWeaponAttachPos2 = new Vector3(0.02f, 0.2f, 0.1f);
        public static Vector3 holstedWeaponAttachRot2 = new Vector3(10f, 145f, 10f);
        public static int holstedWeaponAttachBone2 = 24818;
        public static Vector3 holstedWeaponAttachPos = new Vector3(0.02f, 0.2f, 0.1f);
        public static Vector3 holstedWeaponAttachRot = new Vector3(10f, 145f, 10f);
        public static int holstedWeaponAttachBone = 24818;
        public static bool holster_module_active = ScriptSettings.Load("scripts\\Expansion\\Expansion.ini").GetValue<bool>("HOLSTER_SETTINGS", "HOLSTER_MODULE_ACTIVE", true);
        public static int holster_toggle_btn = ScriptSettings.Load("scripts\\Expansion\\Expansion.ini").GetValue<int>("HOLSTER_SETTINGS", "TOGGLE_HOLSTER_BTN", 37);
        public static int intimidate_btn = ScriptSettings.Load("scripts\\Expansion\\Expansion.ini").GetValue<int>("HOLSTER_SETTINGS", "INTIMIDATE_BTN", 24);
        public static bool useHipHolster = ScriptSettings.Load("scripts\\Expansion\\Expansion.ini").GetValue<bool>("HOLSTER_SETTINGS", "USE_HIP_HOLSTER", false);
        public static bool drawHolsterIcon = ScriptSettings.Load("scripts\\Expansion\\Expansion.ini").GetValue<bool>("HOLSTER_SETTINGS", "ICON_DRAW", false);
        public static int holsterIconX = ScriptSettings.Load("scripts\\Expansion\\Expansion.ini").GetValue<int>("HOLSTER_SETTINGS", "X", 195);
        public static int holsterIconY = ScriptSettings.Load("scripts\\Expansion\\Expansion.ini").GetValue<int>("HOLSTER_SETTINGS", "Y", 620);
        public static int holsterIconW = ScriptSettings.Load("scripts\\Expansion\\Expansion.ini").GetValue<int>("HOLSTER_SETTINGS", "Width", 82);
        public static int holsterIconH = ScriptSettings.Load("scripts\\Expansion\\Expansion.ini").GetValue<int>("HOLSTER_SETTINGS", "Height", 85);
        public static bool customHolsterAnim = ScriptSettings.Load("scripts\\Expansion\\Expansion.ini").GetValue<bool>("HOLSTER_SETTINGS", "CUSTOM_HOLSTER_ANIMATION", false);
        public static int HolsterPrice = ScriptSettings.Load("scripts\\Expansion\\Expansion.ini").GetValue<int>("PRICES", "HOLSTER_PRICE", 50);
        public static bool holsterSet = false;
        public static bool check = false;
        public static bool goodToGo = false;
        public static Prop holster;
        public static Ped player;
        public static Ped prevPlayer;
        public static WeaponHash choosenPistol = (WeaponHash)0;
        public static bool pistolChanged = false;
        public static Prop HolstedPistolPrev;
        public static Prop HolstedPistol;
        public static bool weaponPistolInHands = false;
        public static int worldPistolModel;
        public static int holsterTimerCounterLong = 0;
        public static int holsterTimerCounterShort = 0;
        public static Prop[] holsterProp;
        public static Ped[] closestPeds;
        public static bool intimidation = false;
        public static Ped target;
        public static bool hasHolster = false;
        public static WeaponGroup[] _pistolWeaponGroup = new WeaponGroup[1]
        {
      WeaponGroup.Pistol
        };

        public static void checkHolsterAfterCharacterSwitch(Ped ped, bool useHipHolsterParam)
        {
            string str = "prop_holster_01";
            if (!useHipHolsterParam)
                str = "prop_pistol_holster";
            Prop[] allProps = World.GetAllProps((Model)str);
            for (int index = 0; index < allProps.Length; ++index)
            {
                if ((Entity)allProps[index] != (Entity)null && allProps[index].Exists())
                {
                    if (!allProps[index].IsAttached())
                    {
                        WeaponHolster.holster = allProps[index];
                        WeaponHolster.AttachHolster(ped);
                        WeaponHolster.holsterSet = true;
                        break;
                    }
                    if (allProps[index].IsAttachedTo((Entity)ped))
                    {
                        WeaponHolster.holster = allProps[index];
                        WeaponHolster.holsterSet = true;
                        break;
                    }
                }
                else
                {
                    Script.Wait(2000);
                    if ((Entity)allProps[index] != (Entity)null && !allProps[index].Exists())
                    {
                        WeaponHolster.holster = (Prop)null;
                        WeaponHolster.holsterSet = false;
                        break;
                    }
                    if ((Entity)allProps[index] == (Entity)null)
                    {
                        WeaponHolster.holster = (Prop)null;
                        WeaponHolster.holsterSet = false;
                        break;
                    }
                }
            }
        }

        public static void checkPistolAfterScriptReloadByModel(
          Ped ped,
          int model,
          Prop holsetdPistolParam,
          Prop holstedNonPistolWeaponParam)
        {
            if (!Function.Call<Prop>(Hash.GET_CLOSEST_OBJECT_OF_TYPE, (InputArgument)ped.Position.X, (InputArgument)ped.Position.Y, (InputArgument)ped.Position.Z, (InputArgument)3f, (InputArgument)model, (InputArgument)true, (InputArgument)false, (InputArgument)false).Exists())
                return;
            Prop prop = Function.Call<Prop>(Hash.GET_CLOSEST_OBJECT_OF_TYPE, (InputArgument)ped.Position.X, (InputArgument)ped.Position.Y, (InputArgument)ped.Position.Z, (InputArgument)3f, (InputArgument)model, (InputArgument)true, (InputArgument)false, (InputArgument)false);
            if (!Function.Call<bool>(Hash.IS_ENTITY_ATTACHED_TO_ENTITY, (InputArgument)(Entity)prop, (InputArgument)(Entity)ped) || !((Entity)prop != (Entity)holsetdPistolParam) || !((Entity)prop != (Entity)holstedNonPistolWeaponParam))
                return;
            prop.Delete();
        }

        public static Prop checkPistolFunc(
          Ped ped,
          Prop holster,
          bool weaponInHands,
          WeaponHash selectedPistol,
          int worldModel,
          Prop _holstedWeapon,
          bool useHipHolsterParam,
          bool nonPistol,
          Vector3 attachPos,
          Vector3 attachRot,
          int boneIndx,
          bool attachFlag = false,
          int positionTypeParam = 1)
        {
            WeaponHash weaponHash = Function.Call<WeaponHash>(Hash.GET_SELECTED_PED_WEAPON, (InputArgument)(Entity)ped);
            if (ped.Weapons.HasWeapon(selectedPistol) && weaponHash != selectedPistol && !weaponInHands)
            {
                Prop[] nearbyProps = World.GetNearbyProps(ped.Position, 5f, (Model)worldModel);
                if (nearbyProps.Length == 0)
                {
                    Function.Call(Hash.SET_CURRENT_PED_WEAPON, (InputArgument)(Entity)ped, (InputArgument)(Enum)selectedPistol, (InputArgument)true);
                    _holstedWeapon = Function.Call<Prop>(Hash.GET_WEAPON_OBJECT_FROM_PED, (InputArgument)(Entity)ped, (InputArgument)false);
                    Function.Call(Hash.SET_CURRENT_PED_WEAPON, (InputArgument)(Entity)ped, (InputArgument)(Enum)weaponHash, (InputArgument)true);
                }
                else
                    _holstedWeapon = nearbyProps[0];
                if ((Entity)_holstedWeapon != (Entity)null && (!_holstedWeapon.IsAttachedTo((Entity)ped) && !_holstedWeapon.IsAttached() || _holstedWeapon.IsAttachedTo((Entity)ped) && attachFlag))
                    WeaponHolster.AttachPistol(ped, _holstedWeapon, holster, selectedPistol, useHipHolsterParam, nonPistol, attachPos, attachRot, boneIndx, positionTypeParam);
            }
            return _holstedWeapon;
        }

        public static Prop removeHolstedPistolFunc(
          Ped ped,
          Prop holsted_pistol,
          WeaponHash selectedPistol,
          int worldPistolModel)
        {
            WeaponHash weaponHash = Function.Call<WeaponHash>(Hash.GET_SELECTED_PED_WEAPON, (InputArgument)(Entity)ped);
            if ((!ped.Weapons.HasWeapon(selectedPistol) || ped.Weapons.HasWeapon(selectedPistol) && weaponHash == selectedPistol) && (Entity)holsted_pistol != (Entity)null)
            {
                holsted_pistol.Delete();
                holsted_pistol = (Prop)null;
                Main.soundFX(ped, "draw2.wav", Common.assetFolder);
            }
            return holsted_pistol;
        }

        public static void AttackSpeech(Ped ped)
        {
            if (ped.Model.Hash == Main.GetHashKey("PLAYER_TWO"))
                Function.Call(Hash.PLAY_PED_AMBIENT_SPEECH_WITH_VOICE_NATIVE, (InputArgument)(Entity)ped, (InputArgument)"FIGHT", (InputArgument)"TREVOR_ANGRY", (InputArgument)"SPEECH_PARAMS_FORCE", (InputArgument)0);
            if (ped.Model.Hash == Main.GetHashKey("PLAYER_ONE"))
                Function.Call(Hash.PLAY_PED_AMBIENT_SPEECH_WITH_VOICE_NATIVE, (InputArgument)(Entity)ped, (InputArgument)"FIGHT", (InputArgument)"FRANKLIN_ANGRY", (InputArgument)"SPEECH_PARAMS_FORCE", (InputArgument)0);
            if (ped.Model.Hash == Main.GetHashKey("PLAYER_ZERO"))
                Function.Call(Hash.PLAY_PED_AMBIENT_SPEECH_WITH_VOICE_NATIVE, (InputArgument)(Entity)ped, (InputArgument)"FIGHT", (InputArgument)"MICHAEL_ANGRY", (InputArgument)"SPEECH_PARAMS_FORCE", (InputArgument)0);
            if (ped.Model.Hash == Main.GetHashKey("PLAYER_ZERO") || ped.Model.Hash == Main.GetHashKey("PLAYER_ONE") || ped.Model.Hash == Main.GetHashKey("PLAYER_TWO"))
                return;
            if (Function.Call<bool>(Hash.IS_PED_MALE, (InputArgument)(Entity)ped))
                Function.Call(Hash.PLAY_PED_AMBIENT_SPEECH_WITH_VOICE_NATIVE, (InputArgument)(Entity)ped, (InputArgument)"BLIND_RANGE", (InputArgument)"PACKIE", (InputArgument)"SPEECH_PARAMS_FORCE", (InputArgument)0);
            else
                Function.Call(Hash.PLAY_PED_AMBIENT_SPEECH_WITH_VOICE_NATIVE, (InputArgument)(Entity)ped, (InputArgument)"BLIND_RANGE", (InputArgument)"TALINA", (InputArgument)"SPEECH_PARAMS_FORCE", (InputArgument)0);
        }

        public static void GetHolsterPropFunction(Ped ped)
        {
            if (WeaponHolster.useHipHolster)
                WeaponHolster.holsterProp = World.GetAllProps((Model)"prop_pistol_holster");
            else
                WeaponHolster.holsterProp = World.GetAllProps((Model)"prop_holster_01");
            for (int index = 0; index < WeaponHolster.holsterProp.Length; ++index)
            {
                if (WeaponHolster.holsterProp[index].Exists() && (Entity)WeaponHolster.holsterProp[index] != (Entity)null)
                {
                    WeaponHolster.holsterProp[index].Delete();
                    WeaponHolster.holsterProp[index] = (Prop)null;
                    break;
                }
            }
        }

        public static void GetClosestPedDetectionFunction(Ped ped)
        {
            WeaponHolster.closestPeds = World.GetNearbyPeds(ped.Position, 10f);
            for (int index = 0; index < WeaponHolster.closestPeds.Length; ++index)
            {
                if (Function.Call<bool>(Hash.IS_PED_HUMAN, (InputArgument)(Entity)WeaponHolster.closestPeds[index]) && (Entity)WeaponHolster.closestPeds[index] != (Entity)null && WeaponHolster.closestPeds[index].Exists() && WeaponHolster.closestPeds[index].IsAlive && (double)WeaponHolster.closestPeds[index].Position.DistanceTo(ped.Position) < 15.0 && (Entity)WeaponHolster.closestPeds[index] != (Entity)ped && Function.Call<int>(Hash.GET_PED_GROUP_INDEX, (InputArgument)(Entity)WeaponHolster.closestPeds[index]) != Function.Call<int>(Hash.GET_PED_GROUP_INDEX, (InputArgument)(Entity)ped))
                {
                    if (Function.Call<int>(Hash.GET_PED_TYPE, (InputArgument)(Entity)WeaponHolster.closestPeds[index]) != 0 && Function.Call<int>(Hash.GET_PED_TYPE, (InputArgument)(Entity)WeaponHolster.closestPeds[index]) != 1 && Function.Call<int>(Hash.GET_PED_TYPE, (InputArgument)(Entity)WeaponHolster.closestPeds[index]) != 2 && Function.Call<int>(Hash.GET_PED_TYPE, (InputArgument)(Entity)WeaponHolster.closestPeds[index]) != 6 && Function.Call<int>(Hash.GET_PED_TYPE, (InputArgument)(Entity)WeaponHolster.closestPeds[index]) != 29 && Function.Call<int>(Hash.GET_PED_TYPE, (InputArgument)(Entity)WeaponHolster.closestPeds[index]) != 27 && Function.Call<int>(Hash.GET_PED_TYPE, (InputArgument)(Entity)WeaponHolster.closestPeds[index]) != 21)
                        Function.Call(Hash.TASK_REACT_AND_FLEE_PED, (InputArgument)(Entity)WeaponHolster.closestPeds[index], (InputArgument)(Entity)ped);
                    else if (Game.Player.WantedLevel < 1)
                        ++Game.Player.WantedLevel;
                }
            }
        }

        public static void AttachPistol(
          Ped ped,
          Prop holsted_pistol,
          Prop holster,
          WeaponHash selectedPistol,
          bool useHipHolsterParam,
          bool nonPistolParam,
          Vector3 attachPos,
          Vector3 attachRot,
          int attachBone,
          int PositionTypeParam = 1)
        {
            if (!((Entity)ped != (Entity)null) || !ped.Exists() || !((Entity)holsted_pistol != (Entity)null))
                return;
            Function.Call(Hash.SET_ENTITY_NO_COLLISION_ENTITY, (InputArgument)(Entity)holsted_pistol, (InputArgument)(Entity)ped, (InputArgument)true);
            if (!nonPistolParam)
            {
                if (!((Entity)holster != (Entity)null) || !holster.Exists())
                    return;
                Function.Call(Hash.SET_ENTITY_NO_COLLISION_ENTITY, (InputArgument)(Entity)holsted_pistol, (InputArgument)(Entity)holster, (InputArgument)true);
                if (!useHipHolsterParam)
                {
                    int num = Function.Call<int>(Hash.GET_PED_BONE_INDEX, (InputArgument)(Entity)ped, (InputArgument)24818);
                    Function.Call(Hash.ATTACH_ENTITY_TO_ENTITY, (InputArgument)(Entity)holsted_pistol, (InputArgument)(Entity)ped, (InputArgument)num, (InputArgument)(-0.09f), (InputArgument)0.07f, (InputArgument)(-0.21f), (InputArgument)110f, (InputArgument)(-190f), (InputArgument)13f, (InputArgument)true, (InputArgument)true, (InputArgument)false, (InputArgument)true, (InputArgument)2, (InputArgument)true);
                }
                else
                {
                    int num = Function.Call<int>(Hash.GET_PED_BONE_INDEX, (InputArgument)(Entity)ped, (InputArgument)57597);
                    if (selectedPistol == WeaponHash.Pistol50)
                        Function.Call(Hash.ATTACH_ENTITY_TO_ENTITY, (InputArgument)(Entity)holsted_pistol, (InputArgument)(Entity)ped, (InputArgument)num, (InputArgument)0.05f, (InputArgument)(-0.017f), (InputArgument)(-0.21f), (InputArgument)93f, (InputArgument)(-190f), (InputArgument)12.4f, (InputArgument)true, (InputArgument)true, (InputArgument)false, (InputArgument)true, (InputArgument)2, (InputArgument)true);
                    else
                        Function.Call(Hash.ATTACH_ENTITY_TO_ENTITY, (InputArgument)(Entity)holsted_pistol, (InputArgument)(Entity)ped, (InputArgument)num, (InputArgument)0.005f, (InputArgument)(-0.02f), (InputArgument)(-0.21f), (InputArgument)90f, (InputArgument)(-190f), (InputArgument)13f, (InputArgument)true, (InputArgument)true, (InputArgument)false, (InputArgument)true, (InputArgument)2, (InputArgument)true);
                }
            }
            else
            {
                int num = Function.Call<int>(Hash.GET_PED_BONE_INDEX, (InputArgument)(Entity)ped, (InputArgument)attachBone);
                Function.Call(Hash.ATTACH_ENTITY_TO_ENTITY, (InputArgument)(Entity)holsted_pistol, (InputArgument)(Entity)ped, (InputArgument)num, (InputArgument)attachPos.X, (InputArgument)attachPos.Y, (InputArgument)attachPos.Z, (InputArgument)attachRot.X, (InputArgument)attachRot.Y, (InputArgument)attachRot.Z, (InputArgument)true, (InputArgument)true, (InputArgument)false, (InputArgument)true, (InputArgument)2, (InputArgument)true);
                if (!Common.inMainMenu && !InventoryBag.inMenu && !Main.isOccupiedNative(ped))
                {
                    if (PositionTypeParam == 1)
                    {
                        if (!Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)ped, (InputArgument)"move_action@p_m_zero@holster", (InputArgument)"2h_melee_holster_2h_melee", (InputArgument)3) && !Common.isOccupied(ped) && !Main.isOccupiedNative(ped) && Common.curVehicleIsCar(ped))
                            ped.Task.PlayAnimation("move_action@p_m_zero@holster", "2h_melee_holster_2h_melee", 4f, 1000, AnimationFlags.UpperBodyOnly | AnimationFlags.Secondary);
                    }
                    else if (!Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)ped, (InputArgument)"mp_arrest_paired", (InputArgument)"cop_p1_rf_right_0", (InputArgument)3) && !Common.isOccupied(ped) && !Main.isOccupiedNative(ped) && Common.curVehicleIsCar(ped))
                        ped.Task.PlayAnimation("mp_arrest_paired", "cop_p1_rf_right_0", 4f, 1000, AnimationFlags.UpperBodyOnly | AnimationFlags.Secondary);
                }
                Main.soundFX(ped, "draw2.wav", Common.assetFolder);
            }
        }

        public static void AttachHolster(Ped ped)
        {
            Function.Call(Hash.SET_ENTITY_NO_COLLISION_ENTITY, (InputArgument)(Entity)WeaponHolster.holster, (InputArgument)(Entity)ped, (InputArgument)true);
            if (!WeaponHolster.useHipHolster)
            {
                int num = Function.Call<int>(Hash.GET_PED_BONE_INDEX, (InputArgument)(Entity)ped, (InputArgument)24818);
                Function.Call(Hash.ATTACH_ENTITY_TO_ENTITY, (InputArgument)(Entity)WeaponHolster.holster, (InputArgument)(Entity)ped, (InputArgument)num, (InputArgument)(-0.025f), (InputArgument)(-0.01f), (InputArgument)0.025f, (InputArgument)180f, (InputArgument)90f, (InputArgument)0.0f, (InputArgument)true, (InputArgument)true, (InputArgument)false, (InputArgument)true, (InputArgument)2, (InputArgument)true);
            }
            else
            {
                int num = Function.Call<int>(Hash.GET_PED_BONE_INDEX, (InputArgument)(Entity)ped, (InputArgument)57597);
                Function.Call(Hash.ATTACH_ENTITY_TO_ENTITY, (InputArgument)(Entity)WeaponHolster.holster, (InputArgument)(Entity)ped, (InputArgument)num, (InputArgument)0.0f, (InputArgument)(-0.013f), (InputArgument)(-0.215f), (InputArgument)90f, (InputArgument)0.0f, (InputArgument)90f, (InputArgument)true, (InputArgument)true, (InputArgument)false, (InputArgument)true, (InputArgument)2, (InputArgument)true);
            }
        }

        public static void IconHolsterDrawFunc(Ped ped, bool weaponInHands)
        {
            if (WeaponHolster.drawHolsterIcon && !Function.Call<bool>(Hash.IS_RADAR_HIDDEN) && !Function.Call<bool>(Hash.IS_HUD_HIDDEN) && !Function.Call<bool>(Hash.IS_CUTSCENE_PLAYING))
            {
                Common.iconDrawFunc(WeaponHolster.holsterIconX, WeaponHolster.holsterIconY, WeaponHolster.holsterIconW, WeaponHolster.holsterIconH, "holsterFull.png");
            }
            else
            {
                if (!weaponInHands || ped.IsInVehicle() || !WeaponHolster.drawHolsterIcon || Function.Call<bool>(Hash.IS_RADAR_HIDDEN) || Function.Call<bool>(Hash.IS_HUD_HIDDEN) || Function.Call<bool>(Hash.IS_CUTSCENE_PLAYING))
                    return;
                Common.iconDrawFunc(WeaponHolster.holsterIconX, WeaponHolster.holsterIconY, WeaponHolster.holsterIconW, WeaponHolster.holsterIconH, "holsterEmpty.png");
            }
        }

        public static void SaveHolster(Ped ped)
        {
            string name = ((PedHash)ped.Model).ToString();
            if (char.IsDigit(name[0]))
                name = "CustomPed_" + name;
            if (Common.doc.Element((XName)"WeaponList").Element((XName)name) == null)
                Common.doc.Element((XName)"WeaponList").Add((object)new XElement((XName)name));
            if (Common.doc.Element((XName)"WeaponList").Element((XName)name).Attribute((XName)"holster") == null)
            {
                Common.doc.Element((XName)"WeaponList").Element((XName)name).Add((object)new XAttribute((XName)"holster", (object)true));
                Common.saveDoc();
                Common.doc.Element((XName)"WeaponList").Element((XName)name).Attribute((XName)"holster").SetValue((object)true);
                Common.saveDoc();
            }
            else if (Common.doc.Element((XName)"WeaponList").Element((XName)name).Attribute((XName)"holster").Value == "false")
            {
                Common.doc.Element((XName)"WeaponList").Element((XName)name).Attribute((XName)"holster").SetValue((object)true);
                Common.saveDoc();
            }
        }
        public static bool doesPedWearingHolster(Ped ped)
        {
            return (Entity)WeaponHolster.Holster(ped) != (Entity)null;
        }
        public static Prop Holster(Ped ped)
        {
            Prop[] nearbyProps2 = World.GetNearbyProps(ped.Position, 2f, (Model)Main.GetHashKey(WeaponHolster.holster.ToString()));
            Prop prop1 = (Prop)null;
            if (((IEnumerable<Prop>)nearbyProps2).Count<Prop>() > 0)
            {
                foreach (Prop prop2 in nearbyProps2)
                {
                    if ((Entity)prop2 != (Entity)null && prop2.IsAttachedTo((Entity)ped))
                        prop1 = prop2;
                }
            }
            else
                prop1 = (Prop)null;
            return prop1;
        }

        public static bool doesPedHasHolster(Ped ped)
        {
            string name = ((PedHash)ped.Model).ToString();
            if (char.IsDigit(name[0]))
                name = "CustomPed_" + name;
            if (Common.doc.Element((XName)"WeaponList").Element((XName)name) == null)
                Common.doc.Element((XName)"WeaponList").Add((object)new XElement((XName)name));
            XElement xelement = Common.doc.Element((XName)"WeaponList").Element((XName)name);
            return xelement.Attribute((XName)"holster") != null && xelement.Attribute((XName)"holster").Value == "true";
        }

        public static void DeleteHolster(Ped ped)
        {
            if (ped == null || !ped.Exists()) return;

            // Normalize ped name
            string name = ((PedHash)ped.Model).ToString();
            if (char.IsDigit(name[0])) name = "CustomPed_" + name;

            // Ensure WeaponList exists
            var weaponList = Common.doc.Element("WeaponList");
            if (weaponList == null)
            {
                weaponList = new XElement("WeaponList");
                Common.doc.Add(weaponList);
            }

            // Ensure ped element exists
            var pedElement = weaponList.Element(name);
            if (pedElement == null)
            {
                pedElement = new XElement(name);
                weaponList.Add(pedElement);
            }

            // Safely set holster attribute to false
            var holsterAttr = pedElement.Attribute("holster");
            if (holsterAttr == null || (bool.TryParse(holsterAttr.Value, out var hasHolster) && hasHolster))
            {
                pedElement.SetAttributeValue("holster", false);
                Common.saveDoc();
            }
        }

        public static void SetHolster(Ped ped)
        {
            if (!((Entity)ped != (Entity)null) || !ped.Exists())
                return;
            if (!WeaponHolster.useHipHolster)
            {
                if (!Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)ped, (InputArgument)"oddjobs@basejump@ig_15", (InputArgument)"puton_parachute", (InputArgument)3))
                {
                    Function.Call(Hash.TASK_PLAY_ANIM, (InputArgument)(Entity)ped, (InputArgument)"oddjobs@basejump@ig_15", (InputArgument)"puton_parachute", (InputArgument)45f, (InputArgument)(-12.0), (InputArgument)(-1), (InputArgument)48, (InputArgument)0.0f, (InputArgument)0, (InputArgument)0, (InputArgument)0);
                    Script.Wait(700);
                    Function.Call(Hash.STOP_ENTITY_ANIM, (InputArgument)(Entity)ped, (InputArgument)"puton_parachute", (InputArgument)"oddjobs@basejump@ig_15", (InputArgument)3);
                }
            }
            else if (!Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)ped, (InputArgument)"mp_arrest_paired", (InputArgument)"cop_p1_rf_right_0", (InputArgument)3))
            {
                Function.Call(Hash.TASK_PLAY_ANIM, (InputArgument)(Entity)ped, (InputArgument)"mp_arrest_paired", (InputArgument)"cop_p1_rf_right_0", (InputArgument)7f, (InputArgument)(-12.0), (InputArgument)(-1), (InputArgument)48, (InputArgument)0.0f, (InputArgument)0, (InputArgument)0, (InputArgument)0);
                Script.Wait(700);
                Function.Call(Hash.STOP_ENTITY_ANIM, (InputArgument)(Entity)ped, (InputArgument)"cop_p1_rf_right_0", (InputArgument)"mp_arrest_paired", (InputArgument)3);
            }
            WeaponHolster.holsterSet = true;
            if (!WeaponHolster.useHipHolster)
            {
                if (Function.Call<bool>(Hash.DOES_OBJECT_OF_TYPE_EXIST_AT_COORDS, (InputArgument)ped.Position.X, (InputArgument)ped.Position.Y, (InputArgument)ped.Position.Z, (InputArgument)3f, (InputArgument)Main.GetHashKey("prop_pistol_holster"), (InputArgument)0))
                {
                    Prop prop = Function.Call<Prop>(Hash.GET_CLOSEST_OBJECT_OF_TYPE, (InputArgument)ped.Position.X, (InputArgument)ped.Position.Y, (InputArgument)ped.Position.Z, (InputArgument)3f, (InputArgument)Main.GetHashKey("prop_pistol_holster"), (InputArgument)true, (InputArgument)false, (InputArgument)false);
                    if (Function.Call<bool>(Hash.IS_ENTITY_ATTACHED_TO_ENTITY, (InputArgument)(Entity)prop, (InputArgument)(Entity)ped))
                    {
                        WeaponHolster.holster = prop;
                        int num = Function.Call<int>(Hash.GET_PED_BONE_INDEX, (InputArgument)(Entity)ped, (InputArgument)24818);
                        Function.Call(Hash.ATTACH_ENTITY_TO_ENTITY, (InputArgument)(Entity)WeaponHolster.holster, (InputArgument)(Entity)ped, (InputArgument)num, (InputArgument)(-0.025f), (InputArgument)(-0.01f), (InputArgument)0.025f, (InputArgument)180f, (InputArgument)90f, (InputArgument)0.0f, (InputArgument)true, (InputArgument)true, (InputArgument)false, (InputArgument)true, (InputArgument)2, (InputArgument)true);
                    }
                    else if (Function.Call<bool>(Hash.IS_MODEL_VALID, (InputArgument)Main.GetHashKey("prop_pistol_holster")))
                    {
                        if (Function.Call<bool>(Hash.HAS_MODEL_LOADED, (InputArgument)Main.GetHashKey("prop_pistol_holster")))
                        {
                            WeaponHolster.holster = World.CreateProp((Model)"prop_pistol_holster", ped.Position, true, false);
                            int num = Function.Call<int>(Hash.GET_PED_BONE_INDEX, (InputArgument)(Entity)ped, (InputArgument)24818);
                            Function.Call(Hash.ATTACH_ENTITY_TO_ENTITY, (InputArgument)(Entity)WeaponHolster.holster, (InputArgument)(Entity)ped, (InputArgument)num, (InputArgument)(-0.025f), (InputArgument)(-0.01f), (InputArgument)0.025f, (InputArgument)180f, (InputArgument)90f, (InputArgument)0.0f, (InputArgument)true, (InputArgument)true, (InputArgument)false, (InputArgument)true, (InputArgument)2, (InputArgument)true);
                        }
                        else
                            Notification.Show("holster model has not loaded yet");
                    }
                    else
                        Notification.Show("holster model is invalid");
                }
                else if (Function.Call<bool>(Hash.IS_MODEL_VALID, (InputArgument)Main.GetHashKey("prop_pistol_holster")))
                {
                    if (Function.Call<bool>(Hash.HAS_MODEL_LOADED, (InputArgument)Main.GetHashKey("prop_pistol_holster")))
                    {
                        WeaponHolster.holster = World.CreateProp((Model)"prop_pistol_holster", ped.Position, true, false);
                        int num = Function.Call<int>(Hash.GET_PED_BONE_INDEX, (InputArgument)(Entity)ped, (InputArgument)24818);
                        Function.Call(Hash.ATTACH_ENTITY_TO_ENTITY, (InputArgument)(Entity)WeaponHolster.holster, (InputArgument)(Entity)ped, (InputArgument)num, (InputArgument)(-0.025f), (InputArgument)(-0.01f), (InputArgument)0.025f, (InputArgument)180f, (InputArgument)90f, (InputArgument)0.0f, (InputArgument)true, (InputArgument)true, (InputArgument)false, (InputArgument)true, (InputArgument)2, (InputArgument)true);
                    }
                    else
                        Notification.Show("holster model has not loaded yet");
                }
                else
                    Notification.Show("holster model is invalid");
            }
            else if (Function.Call<bool>(Hash.DOES_OBJECT_OF_TYPE_EXIST_AT_COORDS, (InputArgument)ped.Position.X, (InputArgument)ped.Position.Y, (InputArgument)ped.Position.Z, (InputArgument)3f, (InputArgument)Main.GetHashKey("prop_holster_01"), (InputArgument)0))
            {
                Prop prop = Function.Call<Prop>(Hash.GET_CLOSEST_OBJECT_OF_TYPE, (InputArgument)ped.Position.X, (InputArgument)ped.Position.Y, (InputArgument)ped.Position.Z, (InputArgument)3f, (InputArgument)Main.GetHashKey("prop_holster_01"), (InputArgument)true, (InputArgument)false, (InputArgument)false);
                if (Function.Call<bool>(Hash.IS_ENTITY_ATTACHED_TO_ENTITY, (InputArgument)(Entity)prop, (InputArgument)(Entity)ped))
                {
                    WeaponHolster.holster = prop;
                    int num = Function.Call<int>(Hash.GET_PED_BONE_INDEX, (InputArgument)(Entity)ped, (InputArgument)57597);
                    Function.Call(Hash.ATTACH_ENTITY_TO_ENTITY, (InputArgument)(Entity)WeaponHolster.holster, (InputArgument)(Entity)ped, (InputArgument)num, (InputArgument)0.0f, (InputArgument)(-0.013f), (InputArgument)(-0.215f), (InputArgument)90f, (InputArgument)0.0f, (InputArgument)90f, (InputArgument)true, (InputArgument)true, (InputArgument)false, (InputArgument)true, (InputArgument)2, (InputArgument)true);
                }
                else if (Function.Call<bool>(Hash.IS_MODEL_VALID, (InputArgument)Main.GetHashKey("prop_holster_01")))
                {
                    if (Function.Call<bool>(Hash.HAS_MODEL_LOADED, (InputArgument)Main.GetHashKey("prop_holster_01")))
                    {
                        WeaponHolster.holster = World.CreateProp((Model)"prop_holster_01", ped.Position, true, false);
                        int num = Function.Call<int>(Hash.GET_PED_BONE_INDEX, (InputArgument)(Entity)ped, (InputArgument)57597);
                        Function.Call(Hash.ATTACH_ENTITY_TO_ENTITY, (InputArgument)(Entity)WeaponHolster.holster, (InputArgument)(Entity)ped, (InputArgument)num, (InputArgument)0.0f, (InputArgument)(-0.013f), (InputArgument)(-0.215f), (InputArgument)90f, (InputArgument)0.0f, (InputArgument)90f, (InputArgument)true, (InputArgument)true, (InputArgument)false, (InputArgument)true, (InputArgument)2, (InputArgument)true);
                    }
                    else
                        Notification.Show("holster model has not loaded yet");
                }
                else
                    Notification.Show("holster model is invalid");
            }
            else if (Function.Call<bool>(Hash.IS_MODEL_VALID, (InputArgument)Main.GetHashKey("prop_holster_01")))
            {
                if (Function.Call<bool>(Hash.HAS_MODEL_LOADED, (InputArgument)Main.GetHashKey("prop_holster_01")))
                {
                    WeaponHolster.holster = World.CreateProp((Model)"prop_holster_01", ped.Position, true, false);
                    int num = Function.Call<int>(Hash.GET_PED_BONE_INDEX, (InputArgument)(Entity)ped, (InputArgument)57597);
                    Function.Call(Hash.ATTACH_ENTITY_TO_ENTITY, (InputArgument)(Entity)WeaponHolster.holster, (InputArgument)(Entity)ped, (InputArgument)num, (InputArgument)0.0f, (InputArgument)(-0.013f), (InputArgument)(-0.215f), (InputArgument)90f, (InputArgument)0.0f, (InputArgument)90f, (InputArgument)true, (InputArgument)true, (InputArgument)false, (InputArgument)true, (InputArgument)2, (InputArgument)true);
                }
                else
                    Notification.Show("holster model has not loaded yet");
            }
            else
                Notification.Show("holster model is invalid");
        }

        public static void UnsetHolster(Ped ped, bool useHipHolsterParam)
        {
            if (!((Entity)ped != (Entity)null) || !ped.Exists())
                return;
            if (!useHipHolsterParam)
            {
                if (!Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)ped, (InputArgument)"skydive@parachute@", (InputArgument)"chute_off", (InputArgument)3))
                {
                    ped.Task.ClearAll();
                    Function.Call(Hash.TASK_PLAY_ANIM, (InputArgument)(Entity)ped, (InputArgument)"skydive@parachute@", (InputArgument)"chute_off", (InputArgument)12f, (InputArgument)(-12.0), (InputArgument)(-1), (InputArgument)48, (InputArgument)0.0f, (InputArgument)0, (InputArgument)0, (InputArgument)0);
                    Script.Wait(700);
                    Function.Call(Hash.STOP_ENTITY_ANIM, (InputArgument)(Entity)ped, (InputArgument)"chute_off", (InputArgument)"skydive@parachute@", (InputArgument)3);
                }
            }
            else if (!Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)ped, (InputArgument)"mp_arrest_paired", (InputArgument)"cop_p1_rf_right_0", (InputArgument)3))
            {
                Function.Call(Hash.TASK_PLAY_ANIM, (InputArgument)(Entity)ped, (InputArgument)"mp_arrest_paired", (InputArgument)"cop_p1_rf_right_0", (InputArgument)7f, (InputArgument)(-12.0), (InputArgument)(-1), (InputArgument)48, (InputArgument)0.0f, (InputArgument)0, (InputArgument)0, (InputArgument)0);
                Script.Wait(700);
                Function.Call(Hash.STOP_ENTITY_ANIM, (InputArgument)(Entity)ped, (InputArgument)"cop_p1_rf_right_0", (InputArgument)"mp_arrest_paired", (InputArgument)3);
            }
            WeaponHolster.holsterSet = false;
            if ((Entity)WeaponHolster.holster != (Entity)null && WeaponHolster.holster.Exists())
            {
                WeaponHolster.holster.Delete();
                WeaponHolster.holster = (Prop)null;
            }
            if ((Entity)WeaponHolster.HolstedPistol != (Entity)null && WeaponHolster.HolstedPistol.Exists())
            {
                WeaponHolster.HolstedPistol = (Prop)null;
                Function.Call(Hash.REMOVE_WEAPON_FROM_PED, (InputArgument)(Entity)ped, (InputArgument)(Enum)WeaponHolster.choosenPistol);
            }
            for (int index = 0; index < Common.allWeaponModels.Length; ++index)
                WeaponHolster.checkPistolAfterScriptReloadByModel(Game.Player.Character, Common.allWeaponModels[index].Hash, WeaponHolster.HolstedPistol, WeaponHolster.HolstedNonPistolWeapon);
        }
    }
}
