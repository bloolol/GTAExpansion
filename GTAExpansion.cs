// Decompiled with JetBrains decompiler
// Type: GTAExpansion.GTAExpansion
// Assembly: GTAExpansion, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2A8F9920-188B-4EED-A081-9078B93D2DDF
// Assembly location: D:\SteamLibrary\steamapps\common\Grand Theft Auto V\scripts\GTAExpansion.dll

using GTA;
using GTA.Math;
using GTA.Native;
using GTA.UI;
using HTools;
using HTools.hphone;
using HTools.hphone.Image_Types;
using NativeUI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace GTAExpansion
{
    public class GTAExpansion : Script
    {
        public GTAExpansion() => this.Tick += new EventHandler(this.OnTick);

        private void OnTick(object sender, EventArgs e)
        {
            if (Game.IsPaused)
                return;
            while (Game.IsLoading)
                Script.Wait(10000);
            if (!Common.loaded)
            {
                Function.Call(Hash.REQUEST_ANIM_DICT, (InputArgument)"skydive@parachute@");
                Function.Call(Hash.REQUEST_ANIM_DICT, (InputArgument)"mp_arrest_paired");
                Function.Call(Hash.REQUEST_ANIM_DICT, (InputArgument)"veh@driveby@first_person@passenger_rear_right_handed@smg");
                Function.Call(Hash.REQUEST_ANIM_DICT, (InputArgument)"anim@heists@money_grab@duffel");
                Function.Call(Hash.REQUEST_ANIM_DICT, (InputArgument)"oddjobs@basejump@ig_15");
                Function.Call(Hash.REQUEST_ANIM_DICT, (InputArgument)"oddjobs@assassinate@construction@");
                Function.Call(Hash.REQUEST_ANIM_DICT, (InputArgument)"friends@frl@ig_1");
                Function.Call(Hash.REQUEST_ANIM_DICT, (InputArgument)"amb@world_human_smoking@male@male_b@idle_a");
                Function.Call(Hash.REQUEST_ANIM_DICT, (InputArgument)"amb@world_human_smoking@female@idle_a");
                Function.Call(Hash.REQUEST_ANIM_DICT, (InputArgument)"amb@world_human_leaning@female@smoke@idle_a");
                Function.Call(Hash.REQUEST_ANIM_DICT, (InputArgument)"amb@world_human_smoking@male@male_b@idle_a");
                Function.Call(Hash.REQUEST_ANIM_DICT, (InputArgument)"amb@world_human_smoking@male@male_a@exit");
                Function.Call(Hash.REQUEST_ANIM_DICT, (InputArgument)"amb@world_human_leaning@female@smoke@exit");
                Function.Call(Hash.REQUEST_ANIM_DICT, (InputArgument)"amb@world_human_smoking@male@male_a@enter");
                Function.Call(Hash.REQUEST_ANIM_DICT, (InputArgument)"amb@code_human_in_car_mp_actions@first_person@smoke@std@ps@base");
                Function.Call(Hash.REQUEST_ANIM_DICT, (InputArgument)"mp_arrest_paired");
                Function.Call(Hash.REQUEST_ANIM_DICT, (InputArgument)"amb@code_human_in_car_mp_actions@first_person@smoke@std@ds@base");
                Function.Call(Hash.REQUEST_ANIM_DICT, (InputArgument)"amb@code_human_in_car_mp_actions@first_person@smoke@std@ds@base");
                Function.Call(Hash.REQUEST_ANIM_DICT, (InputArgument)"anim@amb@board_room@supervising@");
                Function.Call(Hash.REQUEST_ANIM_DICT, (InputArgument)"anim@cellphone@in_car@ds");
                Function.Call(Hash.REQUEST_ANIM_DICT, (InputArgument)"clothingspecs");
                Function.Call(Hash.REQUEST_ANIM_DICT, (InputArgument)"anim@mp_player_intupperface_palm");
                Function.Call(Hash.REQUEST_ANIM_DICT, (InputArgument)"oddjobs@basejump@ig_15");
                Function.Call(Hash.REQUEST_ANIM_DICT, (InputArgument)"move_m@intimidation@cop@unarmed");
                Function.Call(Hash.REQUEST_ANIM_DICT, (InputArgument)"reaction@intimidation@cop@unarmed");
                Function.Call(Hash.REQUEST_ANIM_DICT, (InputArgument)"move_m@intimidation@cop@unarmed");
                Function.Call(Hash.REQUEST_ANIM_DICT, (InputArgument)"mp_arrest_paired");
                Function.Call(Hash.REQUEST_ANIM_DICT, (InputArgument)"combat@aim_variations@pistol");
                Function.Call(Hash.REQUEST_ANIM_DICT, (InputArgument)"anim@amb@range@assemble_guns@");
                Function.Call(Hash.REQUEST_ANIM_DICT, (InputArgument)"anim@heists@money_grab@briefcase");
                Function.Call(Hash.REQUEST_ANIM_DICT, (InputArgument)"anim@scripted@heist@ig1_table_grab@cash@male@");
                Function.Call(Hash.REQUEST_ANIM_DICT, (InputArgument)"anim@scripted@heist@ig1_table_grab@gold@male@");
                Function.Call(Hash.REQUEST_ANIM_DICT, (InputArgument)"amb@medic@standing@kneel@base");
                Function.Call(Hash.REQUEST_ANIM_DICT, (InputArgument)"move_action@p_m_zero@holster");
                Function.Call(Hash.REQUEST_ANIM_DICT, (InputArgument)"cover@weapon@2h");
                Function.Call(Hash.REQUEST_ANIM_DICT, (InputArgument)"mp_weapon_drop");
                Function.Call(Hash.REQUEST_ANIM_DICT, (InputArgument)"weapons@first_person@aim_idle@generic@melee@unarmed@");
                Function.Call(Hash.REQUEST_ANIM_DICT, (InputArgument)"anim@weapons@pistol@doubleaction_holster");
                Function.Call(Hash.REQUEST_ANIM_DICT, (InputArgument)"move_action@p_m_one@armed@2h_short@trans@a");
                Function.Call(Hash.REQUEST_ANIM_DICT, (InputArgument)"amb@code_human_wander_eating_donut@male@idle_a");
                Function.Call(Hash.REQUEST_ANIM_DICT, (InputArgument)"switch@trevor@garbage_food");
                Function.Call(Hash.REQUEST_ANIM_DICT, (InputArgument)"melee@unarmed@streamed_taunts");
                Function.Call(Hash.REQUEST_ANIM_DICT, (InputArgument)"amb@world_human_drinking@beer@idle_a");
                Function.Call(Hash.REQUEST_ANIM_DICT, (InputArgument)"amb@world_human_drinking@beer@exit");
                Function.Call(Hash.REQUEST_ANIM_DICT, (InputArgument)"amb@world_human_drinking@beer@female@idle_a");
                Function.Call(Hash.REQUEST_ANIM_DICT, (InputArgument)"anim_heist@hs3f@ig12_change_clothes@");
                Function.Call(Hash.REQUEST_CLIP_SET, (InputArgument)"weapon@rifle@riflecrouch");
                Function.Call(Hash.REQUEST_CLIP_SET, (InputArgument)"move_ped_crouched");
                Function.Call(Hash.REQUEST_CLIP_SET, (InputArgument)"move_ped_crouched_strafing");
                Function.Call(Hash.REQUEST_CLIP_SET, (InputArgument)"move_weapon@rifle@generic");
                Function.Call(Hash.REQUEST_ANIM_DICT, (InputArgument)"move_weapon@rifle@generic");
                Function.Call(Hash.REQUEST_CLIP_SET, (InputArgument)"misscommon@rifle_crouch");
                Function.Call(Hash.REQUEST_ANIM_DICT, (InputArgument)"misscommon@rifle_crouch");
                Common.blipsRemove(BlipSprite.Information);
                if ((Entity)Game.Player.Character != (Entity)null)
                    InventoryBag.prevWeapon = Function.Call<uint>(Hash.GET_SELECTED_PED_WEAPON, (InputArgument)(Entity)Game.Player.Character);
                if (InventoryBag.doesPedHasInventoryBag(Game.Player.Character) && !Game.Player.Character.IsSittingInVehicle() && !Function.Call<bool>(Hash.IS_CUTSCENE_PLAYING) && Screen.IsFadedIn && Game.Player.Character.IsStopped && (Entity)InventoryBag.bagModelReturn(Game.Player.Character) == (Entity)null)
                {
                    InventoryBag.bagSet(InventoryBag.bagModelCheck(Game.Player.Character), Game.Player.Character);
                    Common.clearTrash();
                }
                InventoryBag.updateDuffleBagAttachPos(Game.Player.Character, false);
                if (WeaponHolster.weaponPositionType == 0)
                {
                    WeaponHolster.holstedWeaponAttachPos = WeaponHolster.holstedWeaponAttachPos1;
                    WeaponHolster.holstedWeaponAttachRot = WeaponHolster.holstedWeaponAttachRot1;
                    WeaponHolster.holstedWeaponAttachBone = WeaponHolster.holstedWeaponAttachBone1;
                }
                else
                {
                    WeaponHolster.holstedWeaponAttachPos = WeaponHolster.holstedWeaponAttachPos2;
                    WeaponHolster.holstedWeaponAttachRot = WeaponHolster.holstedWeaponAttachRot2;
                    WeaponHolster.holstedWeaponAttachBone = WeaponHolster.holstedWeaponAttachBone2;
                }
                if (WeaponHolster.holster_module_active)
                {
                    if (!WeaponHolster.useHipHolster)
                    {
                        if (Function.Call<bool>(Hash.IS_MODEL_VALID, (InputArgument)HTools.Main.GetHashKey("prop_pistol_holster")) && !Function.Call<bool>(Hash.HAS_MODEL_LOADED, (InputArgument)HTools.Main.GetHashKey("prop_pistol_holster")))
                            Function.Call(Hash.REQUEST_MODEL, (InputArgument)HTools.Main.GetHashKey("prop_pistol_holster"));
                    }
                    else if (Function.Call<bool>(Hash.IS_MODEL_VALID, (InputArgument)HTools.Main.GetHashKey("prop_holster_01")) && !Function.Call<bool>(Hash.HAS_MODEL_LOADED, (InputArgument)HTools.Main.GetHashKey("prop_holster_01")))
                        Function.Call(Hash.REQUEST_MODEL, (InputArgument)HTools.Main.GetHashKey("prop_holster_01"));
                }
                Game.Player.Character.CanWearHelmet = false;
                if (HungerSystem.hungerModuleActive)
                {
                    HungerSystem.foodLeft = HungerSystem.getPedFoodCount(Game.Player.Character, "", Common.doc);
                    HungerSystem.drinksLeft = HungerSystem.getPedDrinksCount(Game.Player.Character, "", Common.doc);
                    Common.Store_Locations.Add(new Vector3(1735.83f, 6419.51f, 35.0373f));
                    Common.Store_Locations.Add(new Vector3(1960.42f, 3748.89f, 32.3438f));
                    Common.Store_Locations.Add(new Vector3(2682.55f, 3282.32f, 55.24f));
                    Common.Store_Locations.Add(new Vector3(1700.17f, 4927.65f, 46.93f));
                    Common.Store_Locations.Add(new Vector3(-2974.73f, 390.8f, 22.5f));
                    Common.Store_Locations.Add(new Vector3(1138.54f, -951.4f, 50.16f));
                    Common.Store_Locations.Add(new Vector3(29.15f, -1344.53f, 36.23f));
                    Common.Store_Locations.Add(new Vector3(-1224.34f, -905.99f, 19.47f));
                    Common.Store_Locations.Add(new Vector3(1394.16919f, 3599.86f, 34.0121f));
                    Common.Store_Locations.Add(new Vector3(-3038.9082f, 589.5187f, 6.9048f));
                    Common.Store_Locations.Add(new Vector3(-3240.317f, 1004.43341f, 11.8307f));
                    Common.Store_Locations.Add(new Vector3(544.2802f, 2672.81128f, 41.1566f));
                    Common.Store_Locations.Add(new Vector3(2559.247f, 385.5266f, 107.623f));
                    Common.Store_Locations.Add(new Vector3(376.6533f, 323.6471f, 102.5664f));
                    Common.Store_Locations.Add(new Vector3(1166.392f, 2703.50415f, 37.1573f));
                    Common.Store_Locations.Add(new Vector3(-2973.26172f, 390.8184f, 14.0433f));
                    Common.Store_Locations.Add(new Vector3(-1491.05652f, -383.5728f, 39.1706f));
                    Common.Store_Locations.Add(new Vector3(1698.80847f, 4929.19775f, 41.0783f));
                    Common.Store_Locations.Add(new Vector3(-711.721f, -916.6965f, 18.2145f));
                    Common.Store_Locations.Add(new Vector3(-53.124f, -1756.4054f, 28.421f));
                    Common.Store_Locations.Add(new Vector3(1159.54211f, -326.6986f, 67.923f));
                    Common.Store_Locations.Add(new Vector3(-1822.28662f, 788.006f, 137.1859f));
                    Blip[] allBlips = World.GetAllBlips(BlipSprite.Store);
                    if (((IEnumerable<Blip>)allBlips).Count<Blip>() > 0)
                    {
                        for (int index1 = 0; index1 < ((IEnumerable<Blip>)allBlips).Count<Blip>(); ++index1)
                        {
                            for (int index2 = 0; index2 < Common.Store_Locations.Count; ++index2)
                            {
                                if (allBlips[index1].Position == Common.Store_Locations[index2])
                                    allBlips[index1].Delete();
                            }
                        }
                    }
                    if (Common.showBlips)
                    {
                        for (int index = 0; index < Common.Store_Locations.Count; ++index)
                        {
                            Blip blip = World.CreateBlip(Common.Store_Locations[index]);
                            blip.Sprite = BlipSprite.Store;
                            blip.Color = BlipColor.Green;
                            blip.IsShortRange = true;
                            blip.Name = "24/7 Store";
                        }
                    }
                }
                if (Common.showHints)
                    Screen.ShowHelpText("To use ~y~focus mode~w~ you need to select firearms (pistols, smgs, shotguns, assaultrifles, sniperrifles) and make sure your ~y~special abillity~w~ bar is full.~n~Press ~" + ((IEnumerable<string>)Enum.GetNames(typeof(Inputs))).ElementAt<string>(FocusMode.focus_mode_btn) + "~ button rapidly ~o~x5 times~w~ to enter focus mode. If your special abilities bar is not filled yet, pressing this button rapidly will fill it up.~n~If your ~y~special abilities~w~ bar is not filled yet, pressing ~" + ((IEnumerable<string>)Enum.GetNames(typeof(Inputs))).ElementAt<string>(FocusMode.focus_mode_btn) + "~ button rapidly will fill it up.", 10000);
                int num = 0;
                while (Common.IFruit == null)
                {
                    ++num;
                    if (num <= 1000)
                        Script.Wait(10);
                    else
                        break;
                }
                if (Common.IFruit != null)
                {
                    Common.callContact = new HPhoneContact("Richard");
                    Common.callContact.Answered += new ContactAnsweredEvent(Common.ContactAnsweredDate);
                    Common.callContact.DialTimeout = 3;
                    Common.callContact.Active = true;
                    Common.callContact.Icon = ContactIcon.Ammunation;
                    Common.callContact.Bold = false;
                    Common.IFruit.Contacts.Add(Common.callContact);
                }
                HungerSystem.hungerBar.BackgroundColor = Color.Black;
                HungerSystem.hungerBar.ForegroundColor = Color.WhiteSmoke;
                HungerSystem.thirstBar.BackgroundColor = Color.Black;
                HungerSystem.thirstBar.ForegroundColor = Color.WhiteSmoke;
                Common.loaded = true;
                WeaponJamming.createWeaponConditionStructure(Game.Player.Character, Common.doc);
            }
            if (CigsAndPills.smoke == 0 || CigsAndPills.smoke == 1)
            {
                if (CigsAndPills.startSmoke)
                {
                    if (!HTools.Main.isOccupiedNative(Game.Player.Character) && (WeaponHash)Game.Player.Character.Weapons.Current == WeaponHash.Unarmed && !Common.inMainMenu && !InventoryBag.inMenu && Game.Player.CanControlCharacter)
                        CigsAndPills.StartSmokeFunc(Game.Player.Character, 0);
                }
                else if (CigsAndPills.smoke == 1 && !HTools.Main.isOccupiedNative(Game.Player.Character) && (WeaponHash)Game.Player.Character.Weapons.Current == WeaponHash.Unarmed && !Common.inMainMenu && !InventoryBag.inMenu && !WeaponJamming.isCleaningJammedGun && !Game.Player.Character.IsSprinting && !Game.Player.Character.IsWalking && !Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Game.Player.Character, (InputArgument)"amb@code_human_in_car_mp_actions@first_person@smoke@std@ds@base", (InputArgument)"exit", (InputArgument)3) && !Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Game.Player.Character, (InputArgument)"amb@world_human_smoking@male@male_a@exit", (InputArgument)"exit", (InputArgument)3) && !Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Game.Player.Character, (InputArgument)"amb@world_human_leaning@female@smoke@exit", (InputArgument)"exit", (InputArgument)3))
                {
                    Common.Draw(9);
                    Game.DisableControlThisFrame(Control.Cover);
                    Game.DisableControlThisFrame(Control.ContextSecondary);
                    if (Function.Call<bool>(Hash.IS_DISABLED_CONTROL_JUST_PRESSED, (InputArgument)0, (InputArgument)44))
                    {
                        Function.Call(Hash.PLAY_SOUND_FRONTEND, (InputArgument) (- 1), (InputArgument)"FocusOut", (InputArgument)"HintCamSounds");
                        CigsAndPills.smoke = 0;
                    }
                }
            }
            Common.IFruit.Update();
            if (Common.GameTimeRef < Game.GameTime)
            {
                Common.GameTimeRef = Game.GameTime + 1000;
                HTools.Main.is_busy = Common.inMainMenu || CigsAndPills.smoking || WeaponJamming.isCleaningJammedGun || WeaponJamming.isFixingJammedGun;
                if (Game.Player.Character.IsSittingInVehicle())
                {
                    Common.main_menu_btn = Common.main_menu_btn_in_vehicle;
                }
                else
                {
                    Common.main_menu_btn = Common.main_menu_btn_on_foot;
                    Game.Player.Character.CanWearHelmet = false;
                }
                if ((Entity)Game.Player.Character != (Entity)null)
                {
                    CigsAndPills.cigsCount = Common.getSupplies(Game.Player.Character, "ciggaretes");
                    CigsAndPills.pillsCount = Common.getSupplies(Game.Player.Character, "painkillers");
                }
                if (CigsAndPills.inProcessCigsAndPills)
                {
                    if (CigsAndPills.cigsAndPillsCounter > 0)
                    {
                        CigsAndPills.play_swallow_pills_anim = true;
                        --CigsAndPills.cigsAndPillsCounter;
                    }
                    else
                    {
                        CigsAndPills.play_swallow_pills_anim = false;
                        CigsAndPills.cigsAndPillsCounter = 0;
                    }
                }
                else if (CigsAndPills.cigsAndPillsCountDown)
                {
                    if (CigsAndPills.cigsAndPillsCounter > 0)
                        --CigsAndPills.cigsAndPillsCounter;
                    else
                        CigsAndPills.cigsAndPillsCounter = 0;
                }
                if ((Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Game.Player.Character, (InputArgument)"amb@world_human_smoking@male@male_a@idle_a", (InputArgument)"idle_c", (InputArgument)3) || Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Game.Player.Character, (InputArgument)"amb@world_human_leaning@female@smoke@idle_a", (InputArgument)"idle_b", (InputArgument)3) || Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Game.Player.Character, (InputArgument)"amb@world_human_smoking@male@male_b@idle_a", (InputArgument)"idle_a", (InputArgument)3) || Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Game.Player.Character, (InputArgument)"amb@world_human_smoking@female@idle_a", (InputArgument)"idle_b", (InputArgument)3) || Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Game.Player.Character, (InputArgument)"amb@code_human_in_car_mp_actions@first_person@smoke@std@ds@base", (InputArgument)"idle_a", (InputArgument)3) || CigsAndPills.smoke == -1 || CigsAndPills.startSmoke) && false)
                {
                    CigsAndPills.smoke = -1;
                    CigsAndPills.startSmoke = true;
                    if ((Entity)CigsAndPills.cig != (Entity)null)
                    {
                        CigsAndPills.cig.MarkAsNoLongerNeeded();
                        CigsAndPills.cig = (Prop)null;
                    }
                }
                if (CigsAndPills.smoke != 1 && (Entity)CigsAndPills.cig == (Entity)null && Function.Call<bool>(Hash.DOES_OBJECT_OF_TYPE_EXIST_AT_COORDS, (InputArgument)Game.Player.Character.Position.X, (InputArgument)Game.Player.Character.Position.Y, (InputArgument)Game.Player.Character.Position.Z, (InputArgument)3f, (InputArgument)HTools.Main.GetHashKey(CigsAndPills.smokeType), (InputArgument)0))
                {
                    Prop prop = Function.Call<Prop>(Hash.GET_CLOSEST_OBJECT_OF_TYPE, (InputArgument)Game.Player.Character.Position.X, (InputArgument)Game.Player.Character.Position.Y, (InputArgument)Game.Player.Character.Position.Z, (InputArgument)3f, (InputArgument)HTools.Main.GetHashKey(CigsAndPills.smokeType), (InputArgument)true, (InputArgument)false, (InputArgument)false);
                    if (Function.Call<bool>(Hash.IS_ENTITY_ATTACHED_TO_ENTITY, (InputArgument)(Entity)prop, (InputArgument)(Entity)Game.Player.Character))
                    {
                        if ((Entity)CigsAndPills.cig == (Entity)null)
                            CigsAndPills.cig = prop;
                        CigsAndPills.smoke = 1;
                        CigsAndPills.startSmoke = false;
                    }
                }
                if (Function.Call<Prop>(Hash.GET_CLOSEST_OBJECT_OF_TYPE, (InputArgument)Game.Player.Character.Position.X, (InputArgument)Game.Player.Character.Position.Y, (InputArgument)Game.Player.Character.Position.Z, (InputArgument)3f, (InputArgument)HTools.Main.GetHashKey(CigsAndPills.smokeType), (InputArgument)true, (InputArgument)false, (InputArgument)false).Exists())
                {
                    Prop prop = Function.Call<Prop>(Hash.GET_CLOSEST_OBJECT_OF_TYPE, (InputArgument)Game.Player.Character.Position.X, (InputArgument)Game.Player.Character.Position.Y, (InputArgument)Game.Player.Character.Position.Z, (InputArgument)3f, (InputArgument)HTools.Main.GetHashKey(CigsAndPills.smokeType), (InputArgument)true, (InputArgument)false, (InputArgument)false);
                    if ((Entity)prop != (Entity)CigsAndPills.cig && Function.Call<bool>(Hash.IS_ENTITY_ATTACHED_TO_ENTITY, (InputArgument)(Entity)prop, (InputArgument)(Entity)Game.Player.Character) && prop.Exists())
                        prop.Delete();
                }
                if ((CigsAndPills.smoke == 1 || CigsAndPills.smoke == 0) && Common.curVehicleIsCar(Game.Player.Character))
                {
                    int type = Game.Player.Character.IsSittingInVehicle() ? 2 : 1;
                    switch (CigsAndPills.smoke)
                    {
                        case 0:
                            if (!HTools.Main.isOccupiedNative(Game.Player.Character) && (Game.Player.Character.IsSittingInVehicle() || !Game.Player.Character.IsSittingInVehicle() && (WeaponHash)Game.Player.Character.Weapons.Current == WeaponHash.Unarmed) && !Common.inMainMenu && Game.Player.CanControlCharacter)
                            {
                                CigsAndPills.StopSmokeFunc(Game.Player.Character, type);
                                break;
                            }
                            break;
                        case 1:
                            if ((Entity)CigsAndPills.cig == (Entity)null)
                            {
                                CigsAndPills.cig = World.CreateProp((Model)CigsAndPills.smokeType, Game.Player.Character.Position, true, false);
                                if ((Entity)CigsAndPills.cig != (Entity)null)
                                    CigsAndPills.cig.IsVisible = false;
                                Function.Call(Hash.SET_ENTITY_NO_COLLISION_ENTITY, (InputArgument)(Entity)CigsAndPills.cig, (InputArgument)(Entity)Game.Player.Character, (InputArgument)true);
                                if (Game.Player.Character.IsSittingInVehicle() && (Entity)Game.Player.Character.CurrentVehicle != (Entity)null)
                                {
                                    Function.Call(Hash.SET_ENTITY_NO_COLLISION_ENTITY, (InputArgument)(Entity)CigsAndPills.cig, (InputArgument)(Entity)Game.Player.Character.CurrentVehicle, (InputArgument)true);
                                    if (!Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Game.Player.Character, (InputArgument)"mp_arrest_paired", (InputArgument)"cop_p1_rf_right_0", (InputArgument)3))
                                        Function.Call(Hash.TASK_PLAY_ANIM, (InputArgument)(Entity)Game.Player.Character, (InputArgument)"mp_arrest_paired", (InputArgument)"cop_p1_rf_right_0", (InputArgument)7f, (InputArgument)(-12.0), (InputArgument)(-1), (InputArgument)48, (InputArgument)0.0f, (InputArgument)0, (InputArgument)0, (InputArgument)0);
                                }
                                int num = Function.Call<int>(Hash.GET_PED_BONE_INDEX, (InputArgument)(Entity)Game.Player.Character, (InputArgument)64017);
                                if (Function.Call<bool>(Hash.IS_PED_MALE, (InputArgument)(Entity)Game.Player.Character))
                                    Function.Call(Hash.ATTACH_ENTITY_TO_ENTITY, (InputArgument)(Entity)CigsAndPills.cig, (InputArgument)(Entity)Game.Player.Character, (InputArgument)num, (InputArgument)0.017, (InputArgument)(-0.01), (InputArgument)0.0, (InputArgument)0.0, (InputArgument)(-120.0), (InputArgument)(-90.0), (InputArgument)false, (InputArgument)false, (InputArgument)false, (InputArgument)false, (InputArgument)2, (InputArgument)true);
                                else
                                    Function.Call(Hash.ATTACH_ENTITY_TO_ENTITY, (InputArgument)(Entity)CigsAndPills.cig, (InputArgument)(Entity)Game.Player.Character, (InputArgument)num, (InputArgument)0.017, (InputArgument)(-0.01), (InputArgument)0.0, (InputArgument)0.0, (InputArgument)0.0, (InputArgument)(-90.0), (InputArgument)false, (InputArgument)false, (InputArgument)false, (InputArgument)false, (InputArgument)2, (InputArgument)true);
                            }
                            if ((Entity)CigsAndPills.cig != (Entity)null && !CigsAndPills.startSmoke)
                            {
                                if (!HTools.Main.isOccupiedNative(Game.Player.Character) && (Game.Player.Character.IsSittingInVehicle() || !Game.Player.Character.IsSittingInVehicle() && (WeaponHash)Game.Player.Character.Weapons.Current == WeaponHash.Unarmed) && !Game.IsControlJustPressed(Control.VehicleHandbrake) && !Game.IsControlJustPressed(Control.VehicleHorn) && !Game.IsControlJustPressed(Control.VehicleHeadlight) && !Game.IsControlJustPressed(Control.Enter) && !Game.IsControlJustPressed(Control.VehicleExit) && Game.Player.CanControlCharacter && !Common.inMainMenu && !InventoryBag.inMenu && !HungerSystem.isEating && !HungerSystem.isDrinking && !Game.Player.Character.IsSprinting && !Game.Player.Character.IsWalking)
                                {
                                    if (CigsAndPills.cig_durability > 0)
                                        CigsAndPills.SmokeLoopFunc(Game.Player.Character, type);
                                    else
                                        CigsAndPills.StopSmokeFunc(Game.Player.Character, type);
                                }
                                else
                                    CigsAndPills.PauseSmokeFunc(Game.Player.Character, type);
                                if ((Entity)CigsAndPills.cig != (Entity)null)
                                {
                                    CigsAndPills.SmokeProceEffectsFunc(Game.Player.Character, type, CigsAndPills.cig);
                                    break;
                                }
                                break;
                            }
                            break;
                    }
                }
                if (InventoryBag.stuckTimerActive)
                {
                    if (InventoryBag.stuckTimer < 1000)
                        ++InventoryBag.stuckTimer;
                    else
                        InventoryBag.stuckTimer = 0;
                }
                else
                    InventoryBag.stuckTimer = 0;
                if (Common.sellerDialogCounter > 0)
                    --Common.sellerDialogCounter;
                if (InventoryBag.bag_module_active)
                {
                    if (Function.Call<bool>(Hash.IS_PLAYER_BEING_ARRESTED, (InputArgument)(Entity)Game.Player.Character, (InputArgument)0) && !Game.IsMissionActive)
                    {
                        if (InventoryBag.doesPedHasInventoryBag(Game.Player.Character))
                            InventoryBag.looseBagFunc(Game.Player.Character, InventoryBag.bagModelReturn(Game.Player.Character));
                    }
                    else if (InventoryBag.can_loose_bag)
                    {
                        if (Game.Player.Character.IsRagdoll && !Game.Player.Character.IsDead && Game.Player.Character.Health > 0)
                        {
                            if (InventoryBag.doesPedWearingBag(Game.Player.Character))
                            {
                                Prop bag = InventoryBag.bagModelReturn(Game.Player.Character);
                                if ((Entity)bag != (Entity)null)
                                {
                                    int num = Common.rnd.Next(1, 4);
                                    if (!InventoryBag.DropChanceCounted && num == 1)
                                    {
                                        InventoryBag.DropChanceCounted = true;
                                        InventoryBag.DropBagFunc(Game.Player.Character, bag);
                                    }
                                }
                            }
                        }
                        else
                            InventoryBag.DropChanceCounted = false;
                    }
                }
                if (Game.IsCutsceneActive || !Game.Player.CanControlCharacter || Function.Call<bool>(Hash.IS_PLAYER_SWITCH_IN_PROGRESS) || Game.Player.Character.IsDead || !Game.Player.Character.IsOnFoot)
                    Crouch.crouched = false;
            }
            if (Function.Call<bool>(Hash.IS_DISABLED_CONTROL_PRESSED, (InputArgument)0, (InputArgument)Common.main_menu_btn) && !Common.inMainMenu && !InventoryBag.inMenu && !FocusMode.targetsPicked && !WeaponJamming.isCleaningJammedGun && !Wallet.inProcessWallet && !WeaponHolster.intimidation && !Common.deal && !Common.findSellerOption && !Common.pedIsNearShopkeeper)
                Common.Draw(5);
            if (Function.Call<bool>(Hash.IS_DISABLED_CONTROL_PRESSED, (InputArgument)0, (InputArgument)Common.main_menu_btn) && Function.Call<bool>(Hash.IS_DISABLED_CONTROL_JUST_PRESSED, (InputArgument)0, (InputArgument)Common.main_menu_sec_btn) && !FocusMode.targetsPicked && !Common.inMainMenu && !InventoryBag.inMenu && !Wallet.inProcessWallet && !WeaponHolster.intimidation && !Common.deal && !Common.findSellerOption && !Common.pedIsNearShopkeeper)
            {
                Common.update_inventory_status(Game.Player.Character);
                if (HungerSystem.hungerModuleActive)
                {
                    HungerSystem.foodLeft = HungerSystem.getPedFoodCount(Game.Player.Character, "", Common.doc);
                    HungerSystem.drinksLeft = HungerSystem.getPedDrinksCount(Game.Player.Character, "", Common.doc);
                }
                Function.Call(Hash.PLAY_SOUND_FRONTEND, (InputArgument)(-1), (InputArgument)"FocusIn", (InputArgument)"HintCamSounds");
                Common.inMainMenu = true;
                Game.Player.Character.Weapons.Select(WeaponHash.Unarmed);
                if (!HTools.Main.barPool.ToList().Contains(HungerSystem.thirstBar))
                    HTools.Main.barPool.Add(HungerSystem.thirstBar);
                if (!HTools.Main.barPool.ToList().Contains(HungerSystem.hungerBar))
                    HTools.Main.barPool.Add(HungerSystem.hungerBar);


            }
            Model model;
            if (Common.inMainMenu)
            {
                HTools.Main.DisableControlsFunc(true);
                if (Common.curVehicleIsCar(Game.Player.Character) && !Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Game.Player.Character, (InputArgument)"anim@scripted@heist@ig1_table_grab@gold@male@", (InputArgument)"enter", (InputArgument)3))
                {
                    Prop prop = InventoryBag.bagModelReturn(Game.Player.Character);
                    if ((Entity)prop != (Entity)null)
                    {
                        int num = Function.Call<int>(Hash.GET_PED_BONE_INDEX, (InputArgument)(Entity)Game.Player.Character, (InputArgument)11816);
                        Function.Call(Hash.ATTACH_ENTITY_TO_ENTITY, (InputArgument)(Entity)prop, (InputArgument)(Entity)Game.Player.Character, (InputArgument)num, (InputArgument)0.2f, (InputArgument)(-0.35f), (InputArgument)0.1f, (InputArgument)(-20f), (InputArgument)110f, (InputArgument)90f, (InputArgument)true, (InputArgument)true, (InputArgument)false, (InputArgument)false, (InputArgument)2, (InputArgument)true);
                    }
                    Game.Player.Character.Task.PlayAnimation("anim@scripted@heist@ig1_table_grab@gold@male@", "enter", 8f, -1, AnimationFlags.StayInEndFrame | AnimationFlags.UpperBodyOnly | AnimationFlags.Secondary);
                }
                Common.Draw(4, InventoryBag.hasBag, InventoryBag.canTakeBagFromVehicle, WeaponHolster.hasHolster, InventoryBag.isBagBought, InventoryBag.isBagDropped, action_page: Common.cur_action_page);
                if ((WeaponHash)Game.Player.Character.Weapons.Current != WeaponHash.Unarmed)
                    Game.Player.Character.Weapons.Select(WeaponHash.Unarmed);
                if (Function.Call<bool>(Hash.IS_DISABLED_CONTROL_JUST_PRESSED, (InputArgument)0, (InputArgument)Common.next_menu_btn))
                {
                    Function.Call(Hash.PLAY_SOUND_FRONTEND, (InputArgument)(-1), (InputArgument)"FocusIn", (InputArgument)"HintCamSounds");
                    if (Common.cur_action_page < Common.max_action_page)
                        ++Common.cur_action_page;
                    else
                        Common.cur_action_page = 0;
                }
                if (Function.Call<bool>(Hash.IS_DISABLED_CONTROL_JUST_PRESSED, (InputArgument)0, (InputArgument)Common.exit_menu_btn))
                {
                    Function.Call(Hash.PLAY_SOUND_FRONTEND, (InputArgument)(-1), (InputArgument)"FocusOut", (InputArgument)"HintCamSounds");
                    Common.inMainMenu = false;
                    Game.Player.Character.Task.ClearAll();
                    InventoryBag.checkEquipedGear(Game.Player.Character);
                    if (HTools.Main.barPool.ToList().Contains(HungerSystem.thirstBar))
                        HTools.Main.barPool.Remove(HungerSystem.thirstBar);
                    if (HTools.Main.barPool.ToList().Contains(HungerSystem.hungerBar))
                        HTools.Main.barPool.Remove(HungerSystem.hungerBar);
                }
                if (Common.cur_action_page == 0)
                {
                    if (!Game.Player.Character.IsWearingHelmet && Function.Call<bool>(Hash.IS_DISABLED_CONTROL_JUST_PRESSED, (InputArgument)0, (InputArgument)Helmet.helmet_on_btn))
                    {
                        Function.Call(Hash.SET_PED_HELMET_TEXTURE_INDEX, (InputArgument)(Entity)Game.Player.Character, (InputArgument)0);
                        Function.Call(Hash.SET_PED_HELMET, (InputArgument)(Entity)Game.Player.Character, (InputArgument)true);
                    }
                    if (InventoryBag.bag_module_active)
                    {
                        if (Function.Call<bool>(Hash.IS_DISABLED_CONTROL_JUST_PRESSED, (InputArgument)0, (InputArgument)InventoryBag.bag_coords_update_btn))
                        {
                            Common.inMainMenu = false;
                            InventoryBag.checkEquipedGear(Game.Player.Character);
                            InventoryBag.updateDuffleBagAttachPos(Game.Player.Character);
                            Game.Player.Character.Task.ClearAll();
                        }
                        if (InventoryBag.hasBag)
                        {
                            if (Function.Call<bool>(Hash.IS_DISABLED_CONTROL_JUST_PRESSED, (InputArgument)0, (InputArgument)InventoryBag.bag_menu_btn))
                            {
                                Common.inMainMenu = false;
                                Game.Player.Character.Task.ClearAll();
                                InventoryBag.inMenu = true;
                                InventoryBag.reattached = false;
                            }
                        }
                        else if (InventoryBag.canTakeBagFromVehicle && Function.Call<bool>(Hash.IS_DISABLED_CONTROL_JUST_PRESSED, (InputArgument)0, (InputArgument)InventoryBag.bag_menu_btn))
                            InventoryBag.bagSet(InventoryBag.bagModelCheck(Game.Player.Character), Game.Player.Character);
                    }
                    if (Vest.vest_module_active)
                    {
                        if (Function.Call<bool>(Hash.IS_DISABLED_CONTROL_JUST_PRESSED, (InputArgument)0, (InputArgument)Vest.vest_menu_btn) && Vest.HasPedBoughtVest(Game.Player.Character))
                        {
                            Common.inMainMenu = false;
                            Game.Player.Character.Task.ClearAll();
                            Vest.inMenu = true;
                        }
                        

                    }
                    if (WeaponHolster.holster_module_active && !Function.Call<bool>(Hash.IS_PED_RUNNING_MOBILE_PHONE_TASK, (InputArgument)(Entity)Game.Player.Character) && !Function.Call<bool>(Hash.IS_PED_RUNNING_RAGDOLL_TASK, (InputArgument)(Entity)Game.Player.Character) && !Function.Call<bool>(Hash.IS_PLAYER_FREE_AIMING, (InputArgument)Game.Player) && Game.Player.Character.IsOnFoot)
                    {
                        if (Function.Call<bool>(Hash.IS_DISABLED_CONTROL_JUST_PRESSED, (InputArgument)0, (InputArgument)WeaponHolster.intimidate_btn))
                        {
                            Common.inMainMenu = false;
                            InventoryBag.checkEquipedGear(Game.Player.Character);
                            Game.Player.Character.Task.ClearAll();
                            if (WeaponHolster.hasHolster && (Entity)WeaponHolster.holster != (Entity)null && WeaponHolster.holster.Exists() && Function.Call<uint>(Hash.GET_SELECTED_PED_WEAPON, (InputArgument)(Entity)Game.Player.Character) == 2725352035U)
                            {
                                if (WeaponHolster.intimidation)
                                {
                                    Array.Clear((Array)WeaponHolster.closestPeds, 0, WeaponHolster.closestPeds.Length);
                                    if (Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Game.Player.Character, (InputArgument)"move_m@intimidation@cop@unarmed", (InputArgument)"idle", (InputArgument)3) || Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Game.Player.Character, (InputArgument)"reaction@intimidation@cop@unarmed", (InputArgument)"intro", (InputArgument)3) || Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Game.Player.Character, (InputArgument)"reaction@intimidation@cop@unarmed", (InputArgument)"outro", (InputArgument)3))
                                    {
                                        Function.Call(Hash.STOP_ENTITY_ANIM, (InputArgument)(Entity)Game.Player.Character, (InputArgument)"idle", (InputArgument)"move_m@intimidation@cop@unarmed", (InputArgument)3);
                                        Function.Call(Hash.STOP_ENTITY_ANIM, (InputArgument)(Entity)Game.Player.Character, (InputArgument)"intro", (InputArgument)"reaction@intimidation@cop@unarmed", (InputArgument)3);
                                        Function.Call(Hash.STOP_ENTITY_ANIM, (InputArgument)(Entity)Game.Player.Character, (InputArgument)"outro", (InputArgument)"reaction@intimidation@cop@unarmed", (InputArgument)3);
                                    }
                                }
                                else if (!Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Game.Player.Character, (InputArgument)"move_m@intimidation@cop@unarmed", (InputArgument)"idle", (InputArgument)3) && !Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Game.Player.Character, (InputArgument)"reaction@intimidation@cop@unarmed", (InputArgument)"intro", (InputArgument)3) && !Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Game.Player.Character, (InputArgument)"reaction@intimidation@cop@unarmed", (InputArgument)"outro", (InputArgument)3))
                                {
                                    WeaponHolster.AttackSpeech(Game.Player.Character);
                                    Game.Player.Character.CanPlayGestures = false;
                                    WeaponHolster.GetClosestPedDetectionFunction(Game.Player.Character);
                                    Game.Player.Character.Task.PlayAnimation("move_m@intimidation@cop@unarmed", "idle", 12f, -1, AnimationFlags.StayInEndFrame | AnimationFlags.Secondary | AnimationFlags.AbortOnPedMovement);
                                    WeaponHolster.intimidation = true;
                                }
                            }
                        }
                        if (Function.Call<bool>(Hash.IS_DISABLED_CONTROL_JUST_PRESSED, (InputArgument)0, (InputArgument)WeaponHolster.holster_toggle_btn))
                        {
                            Common.inMainMenu = false;
                            InventoryBag.checkEquipedGear(Game.Player.Character);
                            Game.Player.Character.Task.ClearAll();
                            if (WeaponHolster.hasHolster)
                            {
                                string str = "prop_holster_01";
                                if (!WeaponHolster.useHipHolster)
                                    str = "prop_pistol_holster";
                                if (Function.Call<Prop>(Hash.GET_CLOSEST_OBJECT_OF_TYPE, (InputArgument)Game.Player.Character.Position.X, (InputArgument)Game.Player.Character.Position.Y, (InputArgument)Game.Player.Character.Position.Z, (InputArgument)3f, (InputArgument)HTools.Main.GetHashKey(str), (InputArgument)true, (InputArgument)false, (InputArgument)false).Exists())
                                {
                                    Prop prop = Function.Call<Prop>(Hash.GET_CLOSEST_OBJECT_OF_TYPE, (InputArgument)Game.Player.Character.Position.X, (InputArgument)Game.Player.Character.Position.Y, (InputArgument)Game.Player.Character.Position.Z, (InputArgument)3f, (InputArgument)HTools.Main.GetHashKey(str), (InputArgument)true, (InputArgument)false, (InputArgument)false);
                                    if (Function.Call<bool>(Hash.IS_ENTITY_ATTACHED_TO_ENTITY, (InputArgument)(Entity)prop, (InputArgument)(Entity)Game.Player.Character))
                                    {
                                        WeaponHolster.holster = prop;
                                        WeaponHolster.UnsetHolster(Game.Player.Character, WeaponHolster.useHipHolster);
                                    }
                                    else
                                        WeaponHolster.SetHolster(Game.Player.Character);
                                }
                                else
                                    WeaponHolster.SetHolster(Game.Player.Character);
                            }
                        }
                    }
                }
                if (Common.cur_action_page == 1)
                {
                    if (!Function.Call<bool>(Hash.IS_PED_RUNNING_MOBILE_PHONE_TASK, (InputArgument)(Entity)Game.Player.Character) && !Function.Call<bool>(Hash.IS_PED_RUNNING_RAGDOLL_TASK, (InputArgument)(Entity)Game.Player.Character) && !Function.Call<bool>(Hash.IS_PED_DOING_DRIVEBY, (InputArgument)(Entity)Game.Player.Character) && !Function.Call<bool>(Hash.IS_PLAYER_FREE_AIMING, (InputArgument)Game.Player))
                    {
                        model = Game.Player.Character.Model;
                        if (model.Hash != HTools.Main.GetHashKey("mp_m_freemode_01"))
                        {
                            model = Game.Player.Character.Model;
                            if (model.Hash != HTools.Main.GetHashKey("mp_f_freemode_01"))
                            {
                                model = Game.Player.Character.Model;
                                if (model.Hash != HTools.Main.GetHashKey("PLAYER_ZERO"))
                                {
                                    model = Game.Player.Character.Model;
                                    if (model.Hash != HTools.Main.GetHashKey("PLAYER_ONE"))
                                    {
                                        model = Game.Player.Character.Model;
                                        if (model.Hash != HTools.Main.GetHashKey("PLAYER_TWO"))
                                            goto label_195;
                                    }
                                }
                            }
                        }
                        OnFootRadio.headset = Function.Call<int>(Hash.GET_PED_PROP_INDEX, (InputArgument)(Entity)Game.Player.Character, (InputArgument)2) == 0;
                    label_195:
                        if (Function.Call<bool>(Hash.IS_DISABLED_CONTROL_JUST_PRESSED, (InputArgument)0, (InputArgument)OnFootRadio.earphone_toggle_btn))
                        {
                            Common.inMainMenu = false;
                            InventoryBag.checkEquipedGear(Game.Player.Character);
                            Game.Player.Character.Task.ClearAll();
                            Function.Call(Hash.SET_CURRENT_PED_WEAPON, (InputArgument)(Entity)Game.Player.Character, (InputArgument)2725352035U, (InputArgument)true);
                            Script.Wait(100);
                            if (Game.Player.Character.IsSittingInVehicle() && !Function.Call<bool>(Hash.IS_THIS_MODEL_A_QUADBIKE, (InputArgument)Function.Call<int>(Hash.GET_ENTITY_MODEL, (InputArgument)(Entity)Game.Player.Character.CurrentVehicle)) && !Function.Call<bool>(Hash.IS_THIS_MODEL_A_BICYCLE, (InputArgument)Function.Call<int>(Hash.GET_ENTITY_MODEL, (InputArgument)(Entity)Game.Player.Character.CurrentVehicle)) && !Function.Call<bool>(Hash.IS_PED_ON_ANY_BIKE, (InputArgument)(Entity)Game.Player.Character))
                            {
                                Game.Player.Character.Task.ClearAll();
                                Function.Call(Hash.TASK_PLAY_ANIM, (InputArgument)(Entity)Game.Player.Character, (InputArgument)"anim@cellphone@in_car@ds", (InputArgument)"cellphone_text_to_call", (InputArgument)45f, (InputArgument)(-12.0), (InputArgument)(-1), (InputArgument)48, (InputArgument)0.0f, (InputArgument)0, (InputArgument)0, (InputArgument)0);
                            }
                            else if (!Game.Player.Character.IsSittingInVehicle() && !Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Game.Player.Character, (InputArgument)"anim@cellphone@in_car@ds", (InputArgument)"cellphone_text_to_call", (InputArgument)3))
                                Function.Call(Hash.TASK_PLAY_ANIM, (InputArgument)(Entity)Game.Player.Character, (InputArgument)"anim@cellphone@in_car@ds", (InputArgument)"cellphone_text_to_call", (InputArgument)45f, (InputArgument)(-12.0), (InputArgument)(-1), (InputArgument)48, (InputArgument)0.0f, (InputArgument)0, (InputArgument)0, (InputArgument)0);
                            HTools.Main.soundFX(Game.Player.Character, "beep.wav", Common.assetFolder);
                            if (!OnFootRadio.headset)
                            {
                                Function.Call(Hash.SET_TEXT_COLOUR, (InputArgument)0, (InputArgument)(int)byte.MaxValue, (InputArgument)0, (InputArgument)100);
                                Notification.Show("Mobile radio is ~g~available", true);
                                try
                                {
                                    Function.Call(Hash.SET_PED_PROP_INDEX, (InputArgument)(Entity)Game.Player.Character, (InputArgument)2, (InputArgument)0, (InputArgument)0);
                                }
                                catch
                                {
                                    Notification.Show("Invalid Prop number", true);
                                }
                                OnFootRadio.headset = true;
                                if (OnFootRadio.headset && !Function.Call<bool>(Hash.IS_MOBILE_PHONE_RADIO_ACTIVE))
                                {
                                    Function.Call(Hash.SET_MOBILE_RADIO_ENABLED_DURING_GAMEPLAY, (InputArgument)true);
                                    Function.Call(Hash.SET_RADIO_TO_STATION_INDEX, (InputArgument)(int)byte.MaxValue);
                                }
                            }
                            else
                            {
                                Function.Call(Hash.SET_TEXT_COLOUR, (InputArgument)(int)byte.MaxValue, (InputArgument)0, (InputArgument)0, (InputArgument)100);
                                Notification.Show("Mobile radio is ~o~unavailable", true);
                                Function.Call(Hash.CLEAR_PED_PROP, (InputArgument)(Entity)Game.Player.Character, (InputArgument)2);
                                OnFootRadio.headset = false;
                                Function.Call(Hash.SET_RADIO_TO_STATION_NAME, (InputArgument)"OFF");
                                Function.Call(Hash.SET_MOBILE_RADIO_ENABLED_DURING_GAMEPLAY, (InputArgument)false);
                            }
                        }
                        if (OnFootRadio.headset && Function.Call<bool>(Hash.IS_DISABLED_CONTROL_JUST_PRESSED, (InputArgument)0, (InputArgument)OnFootRadio.readio_off_btn) && !Function.Call<bool>(Hash.IS_PED_RUNNING_MOBILE_PHONE_TASK, (InputArgument)(Entity)Game.Player.Character) && !Function.Call<bool>(Hash.IS_PED_RUNNING_RAGDOLL_TASK, (InputArgument)(Entity)Game.Player.Character) && !Function.Call<bool>(Hash.IS_PED_DOING_DRIVEBY, (InputArgument)(Entity)Game.Player.Character) && !Function.Call<bool>(Hash.IS_PLAYER_FREE_AIMING, (InputArgument)Game.Player))
                        {
                            Common.inMainMenu = false;
                            InventoryBag.checkEquipedGear(Game.Player.Character);
                            Game.Player.Character.Task.ClearAll();
                            if (Game.Player.Character.IsSittingInVehicle() && !Function.Call<bool>(Hash.IS_THIS_MODEL_A_QUADBIKE, (InputArgument)Function.Call<int>(Hash.GET_ENTITY_MODEL, (InputArgument)(Entity)Game.Player.Character.CurrentVehicle)) && !Function.Call<bool>(Hash.IS_THIS_MODEL_A_BICYCLE, (InputArgument)Function.Call<int>(Hash.GET_ENTITY_MODEL, (InputArgument)(Entity)Game.Player.Character.CurrentVehicle)) && !Function.Call<bool>(Hash.IS_PED_ON_ANY_BIKE, (InputArgument)(Entity)Game.Player.Character))
                            {
                                Game.Player.Character.Task.ClearAll();
                                Function.Call(Hash.TASK_PLAY_ANIM, (InputArgument)(Entity)Game.Player.Character, (InputArgument)"anim@cellphone@in_car@ds", (InputArgument)"cellphone_text_to_call", (InputArgument)45f, (InputArgument)(-12.0), (InputArgument)(-1), (InputArgument)48, (InputArgument)0.0f, (InputArgument)0, (InputArgument)0, (InputArgument)0);
                            }
                            else if (!Game.Player.Character.IsSittingInVehicle() && !Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Game.Player.Character, (InputArgument)"anim@cellphone@in_car@ds", (InputArgument)"cellphone_text_to_call", (InputArgument)3))
                                Function.Call(Hash.TASK_PLAY_ANIM, (InputArgument)(Entity)Game.Player.Character, (InputArgument)"anim@cellphone@in_car@ds", (InputArgument)"cellphone_text_to_call", (InputArgument)45f, (InputArgument)(-12.0), (InputArgument)(-1), (InputArgument)48, (InputArgument)0.0f, (InputArgument)0, (InputArgument)0, (InputArgument)0);
                            if (!Function.Call<bool>(Hash.IS_MOBILE_PHONE_RADIO_ACTIVE))
                            {
                                Function.Call(Hash.SET_MOBILE_RADIO_ENABLED_DURING_GAMEPLAY, (InputArgument)true);
                                if (OnFootRadio.prevStation != (int)byte.MaxValue)
                                    Function.Call(Hash.SET_RADIO_TO_STATION_INDEX, (InputArgument)OnFootRadio.prevStation);
                                else
                                    Function.Call(Hash.SET_RADIO_TO_STATION_INDEX, (InputArgument)0);
                                HTools.Main.soundFX(Game.Player.Character, "beep.wav", Common.assetFolder);
                            }
                            else
                            {
                                HTools.Main.soundFX(Game.Player.Character, "beep.wav", Common.assetFolder);
                                OnFootRadio.prevStation = Function.Call<int>(Hash.GET_PLAYER_RADIO_STATION_INDEX);
                                Function.Call(Hash.SET_RADIO_TO_STATION_INDEX, (InputArgument)(int)byte.MaxValue);
                                Function.Call(Hash.SET_MOBILE_RADIO_ENABLED_DURING_GAMEPLAY, (InputArgument)false);
                            }
                        }
                    }
                    if (Function.Call<bool>(Hash.IS_DISABLED_CONTROL_PRESSED, (InputArgument)0, (InputArgument)Wallet.wallet_btn) && !Function.Call<bool>(Hash.IS_PED_RUNNING_MOBILE_PHONE_TASK, (InputArgument)(Entity)Game.Player.Character) && Game.Player.Character.IsOnFoot && !Game.Player.Character.IsRagdoll && !CigsAndPills.smoking)
                    {
                        Common.inMainMenu = false;
                        InventoryBag.checkEquipedGear(Game.Player.Character);
                        Game.Player.Character.Task.ClearAll();
                        if (!Function.Call<bool>(Hash.IS_PED_RUNNING_MOBILE_PHONE_TASK, (InputArgument)(Entity)Game.Player.Character) && !Function.Call<bool>(Hash.IS_PLAYER_FREE_AIMING, (InputArgument)(Entity)Game.Player.Character) && !Function.Call<bool>(Hash.IS_CUTSCENE_PLAYING) && !Game.Player.Character.IsSittingInVehicle() && !Game.Player.Character.IsSwimming && !Game.Player.Character.IsSwimmingUnderWater && !Game.Player.Character.IsJumping && !Game.Player.Character.IsRagdoll && !Game.Player.Character.IsBeingStunned && !Game.Player.Character.IsClimbing && !Game.Player.Character.IsDiving && !Game.Player.Character.IsFalling && !Game.Player.Character.IsGettingIntoVehicle && !Game.Player.Character.IsInAir && Game.Player.Character.IsOnFoot && Game.Player.Character.IsIdle)
                        {
                            Wallet.inProcessWallet = true;
                            Wallet.walletCount = false;
                            Function.Call(Hash.SET_CURRENT_PED_WEAPON, (InputArgument)(Entity)Game.Player.Character, (InputArgument)2725352035U, (InputArgument)true);
                            Function.Call(Hash.SET_PED_CAN_PLAY_GESTURE_ANIMS, (InputArgument)(Entity)Game.Player.Character, (InputArgument)false);
                            if (!Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Game.Player.Character, (InputArgument)"amb@world_human_smoking@male@male_a@idle_a", (InputArgument)"idle_c", (InputArgument)3) && !Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Game.Player.Character, (InputArgument)"amb@world_human_leaning@female@smoke@idle_a", (InputArgument)"idle_b", (InputArgument)3) && !Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Game.Player.Character, (InputArgument)"amb@world_human_smoking@male@male_b@idle_a", (InputArgument)"idle_a", (InputArgument)3) && !Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Game.Player.Character, (InputArgument)"mp_player_inteat@pnq", (InputArgument)"loop_fp", (InputArgument)3) && !Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Game.Player.Character, (InputArgument)"amb@world_human_smoking@female@idle_a", (InputArgument)"idle_b", (InputArgument)3))
                            {
                                if (!Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Game.Player.Character, (InputArgument)"mp_arrest_paired", (InputArgument)"cop_p1_rf_right_0", (InputArgument)3))
                                {
                                    Function.Call(Hash.TASK_PLAY_ANIM, (InputArgument)(Entity)Game.Player.Character, (InputArgument)"mp_arrest_paired", (InputArgument)"cop_p1_rf_right_0", (InputArgument)4f, (InputArgument)(-4f), (InputArgument)(-1), (InputArgument)50, (InputArgument)0.0f, (InputArgument)0, (InputArgument)0, (InputArgument)0);
                                    Script.Wait(500);
                                    if (Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Game.Player.Character, (InputArgument)"mp_arrest_paired", (InputArgument)"cop_p1_rf_right_0", (InputArgument)3))
                                        Game.Player.Character.Task.ClearAnimation("mp_arrest_paired", "cop_p1_rf_right_0");
                                }
                                HTools.Main.soundFX(Game.Player.Character, "grab.wav", Common.assetFolder);
                                Wallet.wallet = World.CreateProp((Model)"prop_ld_wallet_02", Game.Player.Character.Position, true, false);
                                Wallet.walletOpened = World.CreateProp((Model)"prop_ld_wallet_pickup", Game.Player.Character.Position, true, false);
                                Function.Call(Hash.SET_ENTITY_NO_COLLISION_ENTITY, (InputArgument)(Entity)Wallet.wallet, (InputArgument)(Entity)Game.Player.Character, (InputArgument)true);
                                int num1 = Function.Call<int>(Hash.GET_PED_BONE_INDEX, (InputArgument)(Entity)Game.Player.Character, (InputArgument)36029);
                                int num2 = Function.Call<int>(Hash.GET_PED_BONE_INDEX, (InputArgument)(Entity)Game.Player.Character, (InputArgument)6286);
                                if ((Entity)Wallet.wallet == (Entity)null && Function.Call<bool>(Hash.DOES_OBJECT_OF_TYPE_EXIST_AT_COORDS, (InputArgument)Game.Player.Character.Position.X, (InputArgument)Game.Player.Character.Position.Y, (InputArgument)Game.Player.Character.Position.Z, (InputArgument)3f, (InputArgument)HTools.Main.GetHashKey("prop_ld_wallet_02"), (InputArgument)0))
                                {
                                    Prop prop = Function.Call<Prop>(Hash.GET_CLOSEST_OBJECT_OF_TYPE, (InputArgument)Game.Player.Character.Position.X, (InputArgument)Game.Player.Character.Position.Y, (InputArgument)Game.Player.Character.Position.Z, (InputArgument)3f, (InputArgument)HTools.Main.GetHashKey("prop_ld_wallet_02"), (InputArgument)true, (InputArgument)false, (InputArgument)false);
                                    if (Function.Call<bool>(Hash.IS_ENTITY_ATTACHED_TO_ENTITY, (InputArgument)(Entity)prop, (InputArgument)(Entity)Game.Player.Character) && (Entity)Wallet.wallet == (Entity)null)
                                        Wallet.wallet = prop;
                                }
                                if ((Entity)Wallet.walletOpened == (Entity)null && Function.Call<bool>(Hash.DOES_OBJECT_OF_TYPE_EXIST_AT_COORDS, (InputArgument)Game.Player.Character.Position.X, (InputArgument)Game.Player.Character.Position.Y, (InputArgument)Game.Player.Character.Position.Z, (InputArgument)3f, (InputArgument)HTools.Main.GetHashKey("prop_ld_wallet_pickup"), (InputArgument)0))
                                {
                                    Prop prop = Function.Call<Prop>(Hash.GET_CLOSEST_OBJECT_OF_TYPE, (InputArgument)Game.Player.Character.Position.X, (InputArgument)Game.Player.Character.Position.Y, (InputArgument)Game.Player.Character.Position.Z, (InputArgument)3f, (InputArgument)HTools.Main.GetHashKey("prop_ld_wallet_pickup"), (InputArgument)true, (InputArgument)false, (InputArgument)false);
                                    if (Function.Call<bool>(Hash.IS_ENTITY_ATTACHED_TO_ENTITY, (InputArgument)(Entity)prop, (InputArgument)(Entity)Game.Player.Character) && (Entity)Wallet.walletOpened == (Entity)null)
                                        Wallet.walletOpened = prop;
                                }
                                if (Function.Call<Prop>(Hash.GET_CLOSEST_OBJECT_OF_TYPE, (InputArgument)Game.Player.Character.Position.X, (InputArgument)Game.Player.Character.Position.Y, (InputArgument)Game.Player.Character.Position.Z, (InputArgument)3f, (InputArgument)HTools.Main.GetHashKey("prop_ld_wallet_02"), (InputArgument)true, (InputArgument)false, (InputArgument)false).Exists())
                                {
                                    Prop prop = Function.Call<Prop>(Hash.GET_CLOSEST_OBJECT_OF_TYPE, (InputArgument)Game.Player.Character.Position.X, (InputArgument)Game.Player.Character.Position.Y, (InputArgument)Game.Player.Character.Position.Z, (InputArgument)3f, (InputArgument)HTools.Main.GetHashKey("prop_ld_wallet_02"), (InputArgument)true, (InputArgument)false, (InputArgument)false);
                                    if ((Entity)prop != (Entity)Wallet.wallet && Function.Call<bool>(Hash.IS_ENTITY_ATTACHED_TO_ENTITY, (InputArgument)(Entity)prop, (InputArgument)(Entity)Game.Player.Character) && prop.Exists())
                                        prop.Delete();
                                }
                                if (Function.Call<Prop>(Hash.GET_CLOSEST_OBJECT_OF_TYPE, (InputArgument)Game.Player.Character.Position.X, (InputArgument)Game.Player.Character.Position.Y, (InputArgument)Game.Player.Character.Position.Z, (InputArgument)3f, (InputArgument)HTools.Main.GetHashKey("prop_ld_wallet_pickup"), (InputArgument)true, (InputArgument)false, (InputArgument)false).Exists())
                                {
                                    Prop prop = Function.Call<Prop>(Hash.GET_CLOSEST_OBJECT_OF_TYPE, (InputArgument)Game.Player.Character.Position.X, (InputArgument)Game.Player.Character.Position.Y, (InputArgument)Game.Player.Character.Position.Z, (InputArgument)3f, (InputArgument)HTools.Main.GetHashKey("prop_ld_wallet_pickup"), (InputArgument)true, (InputArgument)false, (InputArgument)false);
                                    if ((Entity)prop != (Entity)Wallet.walletOpened && Function.Call<bool>(Hash.IS_ENTITY_ATTACHED_TO_ENTITY, (InputArgument)(Entity)prop, (InputArgument)(Entity)Game.Player.Character) && prop.Exists())
                                        prop.Delete();
                                }
                                if ((Entity)Wallet.wallet != (Entity)null && Wallet.wallet.Exists())
                                {
                                    Function.Call(Hash.ATTACH_ENTITY_TO_ENTITY, (InputArgument)(Entity)Wallet.wallet, (InputArgument)(Entity)Game.Player.Character, (InputArgument)num2, (InputArgument)0.1, (InputArgument)0.015, (InputArgument)(-0.025), (InputArgument)115.0, (InputArgument)20.0, (InputArgument)0.0, (InputArgument)false, (InputArgument)false, (InputArgument)false, (InputArgument)false, (InputArgument)0, (InputArgument)true);
                                    Wallet.wallet.IsVisible = true;
                                }
                                if ((Entity)Wallet.walletOpened != (Entity)null && Wallet.wallet.Exists())
                                {
                                    Function.Call(Hash.ATTACH_ENTITY_TO_ENTITY, (InputArgument)(Entity)Wallet.walletOpened, (InputArgument)(Entity)Game.Player.Character, (InputArgument)num1, (InputArgument)0.15, (InputArgument)0.025, (InputArgument)0.1, (InputArgument)(-85.0), (InputArgument)(-45.0), (InputArgument)(-10.0), (InputArgument)false, (InputArgument)false, (InputArgument)false, (InputArgument)false, (InputArgument)0, (InputArgument)true);
                                    Wallet.walletOpened.IsVisible = false;
                                }
                                Script.Wait(700);
                                Wallet.walletCount = true;
                            }
                        }
                    }
                    if (Function.Call<bool>(Hash.IS_DISABLED_CONTROL_JUST_PRESSED, (InputArgument)0, (InputArgument)CigsAndPills.smokeBTN) && !CigsAndPills.inProcessCigsAndPills)
                    {
                        Common.inMainMenu = false;
                        InventoryBag.checkEquipedGear(Game.Player.Character);
                        Game.Player.Character.Task.ClearAll();
                        if (CigsAndPills.cigsCount > 0)
                        {
                            Common.checkMask(Game.Player.Character);
                            if (!Common.MaskIsOn && !Game.Player.Character.IsWearingHelmet)
                            {
                                Game.Player.Character.Task.ClearAll();
                                Function.Call(Hash.SET_CURRENT_PED_WEAPON, (InputArgument)(Entity)Game.Player.Character, (InputArgument)2725352035U, (InputArgument)true);
                                switch (CigsAndPills.smoke)
                                {
                                    case -1:
                                    case 0:
                                        Function.Call(Hash.SET_CURRENT_PED_WEAPON, (InputArgument)(Entity)Game.Player.Character, (InputArgument)2725352035U, (InputArgument)true);
                                        if (Function.Call<bool>(Hash.IS_ENTITY_ATTACHED_TO_ENTITY, (InputArgument)(Entity)Function.Call<Prop>(Hash.GET_CLOSEST_OBJECT_OF_TYPE, (InputArgument)Game.Player.Character.Position.X, (InputArgument)Game.Player.Character.Position.Y, (InputArgument)Game.Player.Character.Position.Z, (InputArgument)3f, (InputArgument)HTools.Main.GetHashKey(CigsAndPills.smokeType), (InputArgument)true, (InputArgument)false, (InputArgument)false)))
                                            Function.Call<Prop>(Hash.GET_CLOSEST_OBJECT_OF_TYPE, (InputArgument)Game.Player.Character.Position.X, (InputArgument)Game.Player.Character.Position.Y, (InputArgument)Game.Player.Character.Position.Z, (InputArgument)3f, (InputArgument)HTools.Main.GetHashKey(CigsAndPills.smokeType), (InputArgument)true, (InputArgument)false, (InputArgument)false).Delete();
                                        if (!Common.MaskIsOn)
                                        {
                                            CigsAndPills.cigReady = false;
                                            CigsAndPills.ignitingCig = false;
                                            CigsAndPills.readyToIgnite = false;
                                            CigsAndPills.cigIgnited = false;
                                            CigsAndPills.smoke = 1;
                                            CigsAndPills.startSmoke = true;
                                            CigsAndPills.cigsAndPillsCounter = 9;
                                            if (!CigsAndPills.playCigAndSmokeAnim)
                                            {
                                                CigsAndPills.playCigAndSmokeAnim = true;
                                                break;
                                            }
                                            break;
                                        }
                                        break;
                                    case 1:
                                        CigsAndPills.smoke = 0;
                                        CigsAndPills.startSmoke = false;
                                        CigsAndPills.cigReady = false;
                                        CigsAndPills.ignitingCig = false;
                                        CigsAndPills.readyToIgnite = false;
                                        CigsAndPills.cigIgnited = false;
                                        break;
                                }
                            }
                            else
                            {
                                Function.Call(Hash.SET_TEXT_COLOUR, (InputArgument)(int)byte.MaxValue, (InputArgument)0, (InputArgument)0, (InputArgument)100);
                                Screen.ShowHelpText("~BLIP_INFO_ICON~ ~o~Put off your mask or helmet first", 3000);
                            }
                        }
                        else
                        {
                            Function.Call(Hash.SET_TEXT_COLOUR, (InputArgument)(int)byte.MaxValue, (InputArgument)0, (InputArgument)0, (InputArgument)100);
                            Screen.ShowHelpText("~BLIP_INFO_ICON~ You dont have any ~o~cigs~w~. Call ~p~Dealer~w~ to buy some", 7000);
                        }
                    }
                    if (Function.Call<bool>(Hash.IS_DISABLED_CONTROL_JUST_PRESSED, (InputArgument)0, (InputArgument)CigsAndPills.swallowBTN) && !CigsAndPills.inProcessCigsAndPills)
                    {
                        Common.inMainMenu = false;
                        InventoryBag.checkEquipedGear(Game.Player.Character);
                        Game.Player.Character.Task.ClearAll();
                        if (CigsAndPills.pillsCount > 0)
                        {
                            Common.checkMask(Game.Player.Character);
                            if (!Common.MaskIsOn && !Game.Player.Character.IsWearingHelmet)
                            {
                                if (!Function.Call<bool>(Hash.IS_PED_RUNNING_MOBILE_PHONE_TASK, (InputArgument)(Entity)Game.Player.Character) && !Function.Call<bool>(Hash.IS_PLAYER_FREE_AIMING, (InputArgument)(Entity)Game.Player.Character) && !Function.Call<bool>(Hash.IS_CUTSCENE_PLAYING) && !Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Game.Player.Character, (InputArgument)"amb@world_human_smoking@male@male_a@idle_a", (InputArgument)"idle_c", (InputArgument)3) && !Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Game.Player.Character, (InputArgument)"amb@world_human_leaning@female@smoke@idle_a", (InputArgument)"idle_b", (InputArgument)3) && !Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Game.Player.Character, (InputArgument)"amb@world_human_smoking@male@male_b@idle_a", (InputArgument)"idle_a", (InputArgument)3) && !Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Game.Player.Character, (InputArgument)"amb@world_human_smoking@female@idle_a", (InputArgument)"idle_b", (InputArgument)3) && !Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Game.Player.Character, (InputArgument)"mp_player_inteat@pnq", (InputArgument)"loop_fp", (InputArgument)3))
                                {
                                    Function.Call(Hash.SET_PED_CAN_PLAY_GESTURE_ANIMS, (InputArgument)(Entity)Game.Player.Character, (InputArgument)false);
                                    Function.Call(Hash.SET_CURRENT_PED_WEAPON, (InputArgument)(Entity)Game.Player.Character, (InputArgument)2725352035U, (InputArgument)true);
                                    if (Game.Player.Character.IsSittingInVehicle())
                                    {
                                        if (Game.Player.Character.IsSittingInVehicle() && Function.Call<bool>(Hash.IS_THIS_MODEL_A_CAR, (InputArgument)Game.Player.Character.CurrentVehicle.Model) && !Game.Player.Character.IsDoingDriveBy)
                                        {
                                            Game.Player.Character.Task.ClearAll();
                                            CigsAndPills.inProcessCigsAndPills = true;
                                            CigsAndPills.cigsAndPillsCounter = 15;
                                            CigsAndPills.swallo_anim_current_time = 0.0f;
                                            CigsAndPills.swallow_in_process = false;
                                        }
                                    }
                                    else
                                    {
                                        Game.Player.Character.Task.ClearAll();
                                        CigsAndPills.inProcessCigsAndPills = true;
                                        CigsAndPills.cigsAndPillsCounter = 15;
                                        CigsAndPills.swallo_anim_current_time = 0.0f;
                                        CigsAndPills.swallow_in_process = false;
                                    }
                                }
                            }
                            else
                            {
                                Function.Call(Hash.SET_TEXT_COLOUR, (InputArgument)(int)byte.MaxValue, (InputArgument)0, (InputArgument)0, (InputArgument)100);
                                Screen.ShowHelpText("~BLIP_INFO_ICON~ ~o~Put off your mask or helmet first", 7000);
                            }
                        }
                        else
                        {
                            Function.Call(Hash.SET_TEXT_COLOUR, (InputArgument)(int)byte.MaxValue, (InputArgument)0, (InputArgument)0, (InputArgument)100);
                            Screen.ShowHelpText("~BLIP_INFO_ICON~ You dont have any ~o~painkillers~w~. Call ~p~Dealer~w~ to buy some", 7000);
                        }
                    }
                }
                if (Common.cur_action_page == 2 && FastWardrobe.mask_module_active)
                {
                    if (Function.Call<bool>(Hash.IS_DISABLED_CONTROL_JUST_PRESSED, (InputArgument)0, (InputArgument)FastWardrobe.glasses_toggle_btn))
                    {
                        Common.inMainMenu = false;
                        InventoryBag.checkEquipedGear(Game.Player.Character);
                        Game.Player.Character.Task.ClearAll();
                        Function.Call(Hash.SET_CURRENT_PED_WEAPON, (InputArgument)(Entity)Game.Player.Character, (InputArgument)2725352035U, (InputArgument)true);
                        Script.Wait(100);
                        HTools.Main.soundFX(Game.Player.Character, "noise.wav", Common.assetFolder);
                        string animDic = "anim@mp_player_intupperface_palm";
                        string animName = "exit";
                        if (!Game.Player.Character.IsSittingInVehicle())
                        {
                            animDic = "clothingspecs";
                            animName = "try_glasses_positive_a";
                        }
                        model = Game.Player.Character.Model;
                        if (model.Hash == HTools.Main.GetHashKey("PLAYER_ZERO"))
                            FastWardrobe.PropsControlFunc(Game.Player.Character, "MICHAELES GLASSES", 2, animDic, animName, 1000);
                        model = Game.Player.Character.Model;
                        if (model.Hash == HTools.Main.GetHashKey("PLAYER_ONE"))
                            FastWardrobe.PropsControlFunc(Game.Player.Character, "FRANKLINS GLASSES", 2, animDic, animName, 1000);
                        model = Game.Player.Character.Model;
                        if (model.Hash == HTools.Main.GetHashKey("PLAYER_TWO"))
                            FastWardrobe.PropsControlFunc(Game.Player.Character, "TREVORS GLASSES", 2, animDic, animName, 1000);
                        model = Game.Player.Character.Model;
                        if (model.Hash != HTools.Main.GetHashKey("mp_m_freemode_01"))
                        {
                            model = Game.Player.Character.Model;
                            if (model.Hash != HTools.Main.GetHashKey("mp_f_freemode_01"))
                                goto label_290;
                        }
                        FastWardrobe.PropsControlFunc(Game.Player.Character, "MPS GLASSES", 2, animDic, animName, 1000);
                    }
                label_290:
                    if (Function.Call<bool>(Hash.IS_DISABLED_CONTROL_JUST_PRESSED, (InputArgument)0, (InputArgument)FastWardrobe.gloves_toggle_btn))
                    {
                        Common.inMainMenu = false;
                        InventoryBag.checkEquipedGear(Game.Player.Character);
                        Game.Player.Character.Task.ClearAll();
                        Function.Call(Hash.SET_CURRENT_PED_WEAPON, (InputArgument)(Entity)Game.Player.Character, (InputArgument)2725352035U, (InputArgument)true);
                        Script.Wait(100);
                        HTools.Main.soundFX(Game.Player.Character, "noise.wav", Common.assetFolder);
                        string animDic = "switch@michael@closet";
                        string animName = "closet_c";
                        model = Game.Player.Character.Model;
                        if (model.Hash == HTools.Main.GetHashKey("PLAYER_ZERO"))
                            FastWardrobe.PropsControlFunc(Game.Player.Character, "MICHAELES GLOVES", 1, animDic, animName, 2000);
                        model = Game.Player.Character.Model;
                        if (model.Hash == HTools.Main.GetHashKey("PLAYER_ONE"))
                            FastWardrobe.PropsControlFunc(Game.Player.Character, "FRANKLINS GLOVES", 1, animDic, animName, 2000);
                        model = Game.Player.Character.Model;
                        if (model.Hash == HTools.Main.GetHashKey("PLAYER_TWO"))
                            FastWardrobe.PropsControlFunc(Game.Player.Character, "TREVORS GLOVES", 1, animDic, animName, 2000);
                        model = Game.Player.Character.Model;
                        if (model.Hash != HTools.Main.GetHashKey("mp_m_freemode_01"))
                        {
                            model = Game.Player.Character.Model;
                            if (model.Hash != HTools.Main.GetHashKey("mp_f_freemode_01"))
                                goto label_300;
                        }
                        FastWardrobe.PropsControlFunc(Game.Player.Character, "MPS GLOVES", 1, animDic, animName, 2000);
                    }
                label_300:
                    if (Function.Call<bool>(Hash.IS_DISABLED_CONTROL_JUST_PRESSED, (InputArgument)0, (InputArgument)FastWardrobe.hat_toggle_btn))
                    {
                        Common.inMainMenu = false;
                        InventoryBag.checkEquipedGear(Game.Player.Character);
                        Game.Player.Character.Task.ClearAll();
                        Function.Call(Hash.SET_CURRENT_PED_WEAPON, (InputArgument)(Entity)Game.Player.Character, (InputArgument)2725352035U, (InputArgument)true);
                        Script.Wait(100);
                        HTools.Main.soundFX(Game.Player.Character, "noise.wav", Common.assetFolder);
                        string animDic = "anim@mp_player_intupperface_palm";
                        string animName = "exit";
                        if (Game.Player.Character.IsSittingInVehicle() && !Function.Call<bool>(Hash.IS_THIS_MODEL_A_QUADBIKE, (InputArgument)Function.Call<int>(Hash.GET_ENTITY_MODEL, (InputArgument)(Entity)Game.Player.Character.CurrentVehicle)) && !Function.Call<bool>(Hash.IS_THIS_MODEL_A_BICYCLE, (InputArgument)Function.Call<int>(Hash.GET_ENTITY_MODEL, (InputArgument)(Entity)Game.Player.Character.CurrentVehicle)) && !Function.Call<bool>(Hash.IS_PED_ON_ANY_BIKE, (InputArgument)(Entity)Game.Player.Character))
                        {
                            animDic = "anim@mp_player_intupperface_palm";
                            animName = "exit";
                        }
                        model = Game.Player.Character.Model;
                        if (model.Hash == HTools.Main.GetHashKey("PLAYER_ZERO"))
                            FastWardrobe.PropsControlFunc(Game.Player.Character, "MICHAELES HAT", 2, animDic, animName, 2000);
                        model = Game.Player.Character.Model;
                        if (model.Hash == HTools.Main.GetHashKey("PLAYER_ONE"))
                            FastWardrobe.PropsControlFunc(Game.Player.Character, "FRANKLINS HAT", 2, animDic, animName, 2000);
                        model = Game.Player.Character.Model;
                        if (model.Hash == HTools.Main.GetHashKey("PLAYER_TWO"))
                            FastWardrobe.PropsControlFunc(Game.Player.Character, "TREVORS HAT", 2, animDic, animName, 2000);
                        model = Game.Player.Character.Model;
                        if (model.Hash != HTools.Main.GetHashKey("mp_m_freemode_01"))
                        {
                            model = Game.Player.Character.Model;
                            if (model.Hash != HTools.Main.GetHashKey("mp_f_freemode_01"))
                                goto label_312;
                        }
                        FastWardrobe.PropsControlFunc(Game.Player.Character, "MPS HAT", 2, animDic, animName, 2000);
                    }
                label_312:
                    if (Function.Call<bool>(Hash.IS_DISABLED_CONTROL_JUST_PRESSED, (InputArgument)0, (InputArgument)FastWardrobe.mask_toggle_btn))
                    {
                        Common.inMainMenu = false;
                        InventoryBag.checkEquipedGear(Game.Player.Character);
                        Game.Player.Character.Task.ClearAll();
                        Function.Call(Hash.SET_CURRENT_PED_WEAPON, (InputArgument)(Entity)Game.Player.Character, (InputArgument)2725352035U, (InputArgument)true);
                        Script.Wait(100);
                        HTools.Main.soundFX(Game.Player.Character, "noise.wav", Common.assetFolder);
                        string animDic = "anim@mp_player_intupperface_palm";
                        string animName = "exit";
                        if (Game.Player.Character.IsSittingInVehicle() && !Function.Call<bool>(Hash.IS_THIS_MODEL_A_QUADBIKE, (InputArgument)Function.Call<int>(Hash.GET_ENTITY_MODEL, (InputArgument)(Entity)Game.Player.Character.CurrentVehicle)) && !Function.Call<bool>(Hash.IS_THIS_MODEL_A_BICYCLE, (InputArgument)Function.Call<int>(Hash.GET_ENTITY_MODEL, (InputArgument)(Entity)Game.Player.Character.CurrentVehicle)) && !Function.Call<bool>(Hash.IS_PED_ON_ANY_BIKE, (InputArgument)(Entity)Game.Player.Character))
                        {
                            animDic = "anim@mp_player_intupperface_palm";
                            animName = "exit";
                        }
                        model = Game.Player.Character.Model;
                        if (model.Hash == HTools.Main.GetHashKey("PLAYER_ZERO"))
                            FastWardrobe.PropsControlFunc(Game.Player.Character, "MICHAELES MASK", 1, animDic, animName, 2000, Common.config.GetValue<bool>("MICHAELES MASK", "HIDE_HAIRS", true), true);
                        model = Game.Player.Character.Model;
                        if (model.Hash == HTools.Main.GetHashKey("PLAYER_ONE"))
                            FastWardrobe.PropsControlFunc(Game.Player.Character, "FRANKLINS MASK", 1, animDic, animName, 2000, Common.config.GetValue<bool>("FRANKLINS MASK", "HIDE_HAIRS", true), true);
                        model = Game.Player.Character.Model;
                        if (model.Hash == HTools.Main.GetHashKey("PLAYER_TWO"))
                            FastWardrobe.PropsControlFunc(Game.Player.Character, "TREVORS MASK", 1, animDic, animName, 2000, Common.config.GetValue<bool>("TREVORS MASK", "HIDE_HAIRS", true), true);
                        model = Game.Player.Character.Model;
                        if (model.Hash != HTools.Main.GetHashKey("mp_m_freemode_01"))
                        {
                            model = Game.Player.Character.Model;
                            if (model.Hash != HTools.Main.GetHashKey("mp_f_freemode_01"))
                                goto label_325;
                        }
                        FastWardrobe.PropsControlFunc(Game.Player.Character, "MPS MASK", 1, animDic, animName, 2000, Common.config.GetValue<bool>("MPS MASK", "HIDE_HAIRS", true), true);
                    }
                }
            label_325:
                if (Common.cur_action_page != 3)
                    ;
                if (Common.cur_action_page == 4)
                {
                    if (Function.Call<bool>(Hash.IS_DISABLED_CONTROL_JUST_PRESSED, (InputArgument)0, (InputArgument)HungerSystem.eat_btn) && HungerSystem.hungerModuleActive)
                    {
                        HungerSystem._curPedsFood = HungerSystem.getPedsFood(Game.Player.Character, Common.doc);
                        if (HungerSystem._curPedsFood != "")
                        {
                            if (!HTools.Main.isOccupiedNative(Game.Player.Character) && Game.Player.CanControlCharacter && Common.curVehicleIsCar(Game.Player.Character))
                            {
                                HungerSystem.foodModel = HungerSystem.getFoodModelByTyoe(HungerSystem._curPedsFood);
                                Common.inMainMenu = false;
                                InventoryBag.checkEquipedGear(Game.Player.Character);
                                Game.Player.Character.Task.ClearAll();
                                Common.inMainMenu = false;
                                HungerSystem.isEating = true;
                                HungerSystem.eatingSoundsInt = 0;
                                HungerSystem.isVeryHungry = HungerSystem.getPedHungerLvl(Game.Player.Character, Common.doc) < HungerSystem.criticalHungerLvl;
                            }
                        }
                        else
                        {
                            if (!Function.Call<bool>(Hash.IS_HELP_MESSAGE_BEING_DISPLAYED))
                                Screen.ShowHelpText("~BLIP_INFO_ICON~ You dont have any ~p~food~w~", 6000);
                            Common.inMainMenu = false;
                            InventoryBag.checkEquipedGear(Game.Player.Character);
                            Game.Player.Character.Task.ClearAll();
                        }
                    }
                    if (Function.Call<bool>(Hash.IS_DISABLED_CONTROL_JUST_PRESSED, (InputArgument)0, (InputArgument)HungerSystem.drink_btn) && HungerSystem.hungerModuleActive)
                    {
                        HungerSystem._curPedsDrink = HungerSystem.getPedsDrinks(Game.Player.Character, Common.doc);
                        if (HungerSystem._curPedsDrink != "")
                        {
                            if (!HTools.Main.isOccupiedNative(Game.Player.Character) && Game.Player.CanControlCharacter && Common.curVehicleIsCar(Game.Player.Character))
                            {
                                HungerSystem.drinkModel = HungerSystem.getDrinksModelByTyoe(HungerSystem._curPedsDrink);
                                Common.inMainMenu = false;
                                InventoryBag.checkEquipedGear(Game.Player.Character);
                                Game.Player.Character.Task.ClearAll();
                                Common.inMainMenu = false;
                                HungerSystem.isDrinking = true;
                                HungerSystem.drinkSipsLeft = 500;
                                HungerSystem.drinkingInProcess = false;
                                HungerSystem.isVeryThirsty = HungerSystem.getPedThirstLvl(Game.Player.Character, Common.doc) < HungerSystem.criticalThirstLvl;
                            }
                        }
                        else
                        {
                            if (!Function.Call<bool>(Hash.IS_HELP_MESSAGE_BEING_DISPLAYED))
                                Screen.ShowHelpText("~BLIP_INFO_ICON~ You dont have any ~p~drinks~w~", 6000);
                            Common.inMainMenu = false;
                            InventoryBag.checkEquipedGear(Game.Player.Character);
                            Game.Player.Character.Task.ClearAll();
                        }
                    }
                }
            }
            if (HungerSystem.hungerModuleActive)
            {
                if (HungerSystem.isDrinking && !Common.inMainMenu && !InventoryBag.inMenu && Game.Player.CanControlCharacter)
                {
                    HTools.Main.DisableControlsFunc(true);
                    if (!HungerSystem.drinkingInProcess)
                    {
                        if (!Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Game.Player.Character, (InputArgument)"anim@scripted@heist@ig1_table_grab@gold@male@", (InputArgument)"enter", (InputArgument)3))
                            Game.Player.Character.Task.PlayAnimation("anim@scripted@heist@ig1_table_grab@gold@male@", "enter", 4f, -1, AnimationFlags.StayInEndFrame | AnimationFlags.UpperBodyOnly | AnimationFlags.Secondary);
                        else if ((double)Function.Call<float>(Hash.GET_ENTITY_ANIM_CURRENT_TIME, (InputArgument)(Entity)Game.Player.Character, (InputArgument)"anim@scripted@heist@ig1_table_grab@gold@male@", (InputArgument)"enter") >= 0.98000001907348633)
                        {
                            HungerSystem._drink = HungerSystem.createDrink(Game.Player.Character, Function.Call<Vector3>(Hash.GET_PED_BONE_COORDS, (InputArgument)(Entity)Game.Player.Character, (InputArgument)Function.Call<int>(Hash.GET_PED_BONE_INDEX, (InputArgument)(Entity)Game.Player.Character, (InputArgument)18905), (InputArgument)0, (InputArgument)0, (InputArgument)0), HungerSystem.drinkModel);
                            if (Game.Player.Character.Gender == Gender.Male)
                            {
                                HungerSystem.pedDrinkingAnimDict = "amb@world_human_drinking@beer@male@idle_a";
                                HungerSystem.pedDrinkingAnimName = "idle_b";
                            }
                            else
                            {
                                HungerSystem.pedDrinkingAnimDict = "amb@world_human_drinking@beer@female@idle_a";
                                HungerSystem.pedDrinkingAnimName = "idle_a";
                            }
                            if (!Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Game.Player.Character, (InputArgument)HungerSystem.pedDrinkingAnimDict, (InputArgument)HungerSystem.pedDrinkingAnimName, (InputArgument)3))
                                HungerSystem.drinkingInProcess = true;
                        }
                    }
                    else
                    {
                        int counter = 0;
                        if ((Entity)HungerSystem._drink != (Entity)null)
                        {
                            if (HungerSystem.drinkingEffectsTimer <= 0)
                            {
                                Function.Call(Hash.REQUEST_NAMED_PTFX_ASSET, (InputArgument)"scr_safehouse");
                                Function.Call(Hash.USE_PARTICLE_FX_ASSET, (InputArgument)"scr_safehouse");
                                Function.Call(Hash.START_PARTICLE_FX_NON_LOOPED_ON_ENTITY, (InputArgument)"scr_sh_cig_exhale_mouth", (InputArgument)(Entity)HungerSystem._drink, (InputArgument)0.0f, (InputArgument)0.0f, (InputArgument)0.05f, (InputArgument)0, (InputArgument)0, (InputArgument)90f, (InputArgument)0.8, (InputArgument)true, (InputArgument)true, (InputArgument)true);
                                HungerSystem.drinkingEffectsTimer = 500;
                            }
                            else
                                --HungerSystem.drinkingEffectsTimer;
                        }
                        if (!Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Game.Player.Character, (InputArgument)"amb@world_human_drinking@beer@male@exit", (InputArgument)"exit", (InputArgument)3))
                        {
                            Common.Draw(10);
                            if (!Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Game.Player.Character, (InputArgument)HungerSystem.pedDrinkingAnimDict, (InputArgument)HungerSystem.pedDrinkingAnimName, (InputArgument)3))
                                Game.Player.Character.Task.PlayAnimation(HungerSystem.pedDrinkingAnimDict, HungerSystem.pedDrinkingAnimName, 4f, -1, AnimationFlags.StayInEndFrame | AnimationFlags.UpperBodyOnly | AnimationFlags.Secondary);
                            else if (!Function.Call<bool>(Hash.IS_DISABLED_CONTROL_PRESSED, (InputArgument)0, (InputArgument)24))
                            {
                                if ((double)Function.Call<float>(Hash.GET_ENTITY_ANIM_CURRENT_TIME, (InputArgument)(Entity)Game.Player.Character, (InputArgument)HungerSystem.pedDrinkingAnimDict, (InputArgument)HungerSystem.pedDrinkingAnimName) >= 0.2800000011920929 && (double)Function.Call<float>(Hash.GET_ENTITY_ANIM_CURRENT_TIME, (InputArgument)(Entity)Game.Player.Character, (InputArgument)HungerSystem.pedDrinkingAnimDict, (InputArgument)HungerSystem.pedDrinkingAnimName) < 0.81000000238418579)
                                    Function.Call(Hash.SET_ENTITY_ANIM_CURRENT_TIME, (InputArgument)(Entity)Game.Player.Character, (InputArgument)HungerSystem.pedDrinkingAnimDict, (InputArgument)HungerSystem.pedDrinkingAnimName, (InputArgument)0.81f);
                                else if ((double)Function.Call<float>(Hash.GET_ENTITY_ANIM_CURRENT_TIME, (InputArgument)(Entity)Game.Player.Character, (InputArgument)HungerSystem.pedDrinkingAnimDict, (InputArgument)HungerSystem.pedDrinkingAnimName) <= 0.2800000011920929)
                                    Function.Call(Hash.SET_ENTITY_ANIM_CURRENT_TIME, (InputArgument)(Entity)Game.Player.Character, (InputArgument)HungerSystem.pedDrinkingAnimDict, (InputArgument)HungerSystem.pedDrinkingAnimName, (InputArgument)0.0f);
                            }
                            if (Function.Call<bool>(Hash.IS_DISABLED_CONTROL_JUST_PRESSED, (InputArgument)0, (InputArgument)24))
                            {
                                Function.Call(Hash.PLAY_SOUND_FRONTEND, (InputArgument)(-1), (InputArgument)"FocusInt", (InputArgument)"HintCamSounds");
                                if ((Entity)HungerSystem._drink == (Entity)null || (Entity)HungerSystem._drink != (Entity)null && !HungerSystem._drink.Exists())
                                    HungerSystem._drink = HungerSystem.createDrink(Game.Player.Character, Function.Call<Vector3>(Hash.GET_PED_BONE_COORDS, (InputArgument)(Entity)Game.Player.Character, (InputArgument)Function.Call<int>(Hash.GET_PED_BONE_INDEX, (InputArgument)(Entity)Game.Player.Character, (InputArgument)18905), (InputArgument)0, (InputArgument)0, (InputArgument)0), HungerSystem.drinkModel);
                                Function.Call(Hash.SET_ENTITY_ANIM_CURRENT_TIME, (InputArgument)(Entity)Game.Player.Character, (InputArgument)HungerSystem.pedDrinkingAnimDict, (InputArgument)HungerSystem.pedDrinkingAnimName, (InputArgument)0.0f);
                            }
                            if (Function.Call<bool>(Hash.IS_DISABLED_CONTROL_PRESSED, (InputArgument)0, (InputArgument)24) && (double)Function.Call<float>(Hash.GET_ENTITY_ANIM_CURRENT_TIME, (InputArgument)(Entity)Game.Player.Character, (InputArgument)HungerSystem.pedDrinkingAnimDict, (InputArgument)HungerSystem.pedDrinkingAnimName) >= 0.30000001192092896 && (double)Function.Call<float>(Hash.GET_ENTITY_ANIM_CURRENT_TIME, (InputArgument)(Entity)Game.Player.Character, (InputArgument)HungerSystem.pedDrinkingAnimDict, (InputArgument)HungerSystem.pedDrinkingAnimName) <= 0.33000001311302185)
                            {
                                --HungerSystem.drinkSipsLeft;
                                Game.Player.Character.HealthFloat += 0.1f;
                                Game.Player.ChargeSpecialAbility(0.01f);
                                double num = (double)Function.Call<float>(Hash.SET_ENTITY_ANIM_CURRENT_TIME, (InputArgument)(Entity)Game.Player.Character, (InputArgument)HungerSystem.pedDrinkingAnimDict, (InputArgument)HungerSystem.pedDrinkingAnimName, (InputArgument)0.3f);
                                if (HungerSystem.swallowSoundFXTimer <= 0)
                                {
                                    HTools.Main.soundFX(Game.Player.Character, "swallow.wav", Common.assetFolder, 18f);
                                    HungerSystem.swallowSoundFXTimer = 100;
                                }
                                else
                                    --HungerSystem.swallowSoundFXTimer;

                                int normalized = (HungerSystem.drinkSipsLeft/500) * HungerSystem.thirst_lvl_max;
                                int inverted = HungerSystem.thirst_lvl_max - normalized;
                                
                                int compounded = counter + inverted;
                                HungerSystem.savePedThirstLvl(Game.Player.Character, compounded, HungerSystem.thirst_lvl_max, Common.doc);

                            }
                            if (Function.Call<bool>(Hash.IS_DISABLED_CONTROL_JUST_PRESSED, (InputArgument)0, (InputArgument)25) || HungerSystem.drinkSipsLeft <= 0 || Game.Player.Character.IsRagdoll)
                            {
                                Function.Call(Hash.PLAY_SOUND_FRONTEND, (InputArgument)(-1), (InputArgument)"FocusOut", (InputArgument)"HintCamSounds");
                                if ((Entity)HungerSystem._drink == (Entity)null)
                                    HungerSystem._drink = HungerSystem.createDrink(Game.Player.Character, Function.Call<Vector3>(Hash.GET_PED_BONE_COORDS, (InputArgument)(Entity)Game.Player.Character, (InputArgument)Function.Call<int>(Hash.GET_PED_BONE_INDEX, (InputArgument)(Entity)Game.Player.Character, (InputArgument)18905), (InputArgument)0, (InputArgument)0, (InputArgument)0), HungerSystem.drinkModel);
                                if ((Entity)HungerSystem._drink != (Entity)null && !Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Game.Player.Character, (InputArgument)"amb@world_human_drinking@beer@male@exit", (InputArgument)"exit", (InputArgument)3))
                                    Game.Player.Character.Task.PlayAnimation("amb@world_human_drinking@beer@male@exit", "exit", 4f, 7000, AnimationFlags.UpperBodyOnly | AnimationFlags.Secondary);
                            }
                        }
                        else if ((double)Function.Call<float>(Hash.GET_ENTITY_ANIM_CURRENT_TIME, (InputArgument)(Entity)Game.Player.Character, (InputArgument)"amb@world_human_drinking@beer@male@exit", (InputArgument)"exit") >= 0.64999997615814209)
                        {
                            Function.Call(Hash.REMOVE_PARTICLE_FX_FROM_ENTITY, (InputArgument)(Entity)HungerSystem._drink);
                            HungerSystem.isDrinking = false;
                            
                            HungerSystem.drinkingInProcess = false;
                            Function.Call(Hash.PLAY_PED_AMBIENT_SPEECH_NATIVE, (InputArgument)(Entity)Game.Player.Character, (InputArgument)"GENERIC_DRINK", (InputArgument)"SPEECH_PARAMS_FORCE");
                            HungerSystem.updatePedDrinksCount(Game.Player.Character, HungerSystem._curPedsDrink, HungerSystem.getPedDrinksCount(Game.Player.Character, HungerSystem._curPedsDrink, Common.doc) - 1, Common.doc);
                            HungerSystem.drinksLeft = HungerSystem.getPedDrinksCount(Game.Player.Character, "", Common.doc);
                            HungerSystem._drink.Detach();
                            HungerSystem._drink.MarkAsNoLongerNeeded();
                            HungerSystem.savePedThirstLvl(Game.Player.Character, HungerSystem.thirst_lvl_max, HungerSystem.thirst_lvl_max, Common.doc);
                            HungerSystem.isThirsty = false;
                            counter = 0;
                        }
                    }
                }
                if (HungerSystem.isEating)
                {
                    HTools.Main.DisableControlsFunc(true);
                    string animDict = "amb@code_human_wander_eating_donut@male@idle_a";
                    string animName = "idle_c";
                    float num = 0.98f;
                    int duration = -1;
                    HungerSystem.eatingSoundsMaxInt = 100;
                    HungerSystem.eatingAnimTime = 0.25f;
                    if (!Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Game.Player.Character, (InputArgument)animDict, (InputArgument)animName, (InputArgument)3))
                    {
                        Game.Player.Character.Task.PlayAnimation(animDict, animName, 4f, duration, AnimationFlags.UpperBodyOnly | AnimationFlags.Secondary);
                        HTools.Main.soundFX(Game.Player.Character, "draw2.wav", Common.assetFolder);
                        HungerSystem.createFood(Game.Player.Character, Game.Player.Character.Position, HungerSystem.foodModel, attachPositionType: 1);
                    }
                    else
                    {
                        if ((double)Function.Call<float>(Hash.GET_ENTITY_ANIM_CURRENT_TIME, (InputArgument)(Entity)Game.Player.Character, (InputArgument)animDict, (InputArgument)animName) >= (double)HungerSystem.eatingAnimTime)
                        {
                            if (HungerSystem.eatingSoundsInt <= 0)
                            {
                                HungerSystem.eatingSoundsInt = HungerSystem.eatingSoundsMaxInt;
                                HTools.Main.soundFX(Game.Player.Character, "eat.wav", Common.assetFolder, 15f);
                                HTools.Main.soundFX(Game.Player.Character, "snack.wav", Common.assetFolder, 15f);
                            }
                            else
                                --HungerSystem.eatingSoundsInt;
                        }
                        Game.Player.Character.HealthFloat += 0.1f;
                        if ((double)Function.Call<float>(Hash.GET_ENTITY_ANIM_CURRENT_TIME, (InputArgument)(Entity)Game.Player.Character, (InputArgument)animDict, (InputArgument)animName) > (double)num)
                        {
                            if (!Game.Player.Character.IsInStealthMode)
                                Function.Call(Hash.PLAY_PED_AMBIENT_SPEECH_NATIVE, (InputArgument)(Entity)Game.Player.Character, (InputArgument)"GENERIC_EAT", (InputArgument)"SPEECH_PARAMS_FORCE_SHOUTED");
                            Screen.ShowHelpText("~BLIP_INFO_ICON~ You feel much better now!", 6000);
                            HTools.Main.soundFX(Game.Player.Character, "swallow.wav", Common.assetFolder, 15f);
                            HungerSystem.savePedHungerLvl(Game.Player.Character, HungerSystem.hunger_lvl_max, HungerSystem.hunger_lvl_max, Common.doc);
                            HungerSystem.updatePedFoodCount(Game.Player.Character, HungerSystem._curPedsFood, HungerSystem.getPedFoodCount(Game.Player.Character, HungerSystem._curPedsFood, Common.doc) - 1, Common.doc);
                            HungerSystem.clearFood(Game.Player.Character, HungerSystem.foodModel);
                            HTools.Main.stopBleeding(Game.Player.Character);
                            HungerSystem.foodLeft = HungerSystem.getPedFoodCount(Game.Player.Character, "", Common.doc);
                            HungerSystem.isEating = false;
                            HungerSystem.isHungry = false;
                        }
                    }
                }
            }
            if (Common.pedIsNearGunDealer)
            {
                HTools.Main.DisableControlsFunc(true);
                Common.Draw(11, cameraModuleParam: false, swingWeaponModuleParam: false, laserSightModuleParam: false, weaponJamningModuleParam: false);
                if (Function.Call<bool>(Hash.IS_DISABLED_CONTROL_JUST_PRESSED, (InputArgument)0, (InputArgument)24) && !Game.Player.IsAiming)
                {
                    Common.purchaseType = 3;
                    Common.purchaseSum = InventoryBag.BagPrice;
                    Common.purchaseProcess = true;
                }
                if (Function.Call<bool>(Hash.IS_DISABLED_CONTROL_JUST_PRESSED, (InputArgument)0, (InputArgument)25) && !Game.Player.IsAiming)
                {
                    Common.purchaseType = 4;
                    Common.purchaseSum = WeaponHolster.HolsterPrice;
                    Common.purchaseProcess = true;
                }
                if (Function.Call<bool>(Hash.IS_DISABLED_CONTROL_JUST_PRESSED, (InputArgument)0, (InputArgument)26) && !Game.Player.IsAiming)
                {
                    WeaponJamming.cleaningToolsCount = Common.getSupplies(Game.Player.Character, "weapon_tools");
                    if (WeaponJamming.cleaningToolsCount <= WeaponJamming.cleaningToolsMax)
                    {
                        Common.purchaseType = 5;
                        Common.purchaseSum = WeaponJamming.weaponToolsPrice;
                        Common.purchaseProcess = true;
                    }
                }
                if (Function.Call<bool>(Hash.IS_DISABLED_CONTROL_JUST_PRESSED, (InputArgument)0, (InputArgument)22) && !Game.Player.IsAiming)
                {
                    Vest.armorPlateCount = Vest.getArmorPlateCount(Game.Player.Character, "Armor_Plates");
                    if (Vest.armorPlateCount <= Vest.armorPlatesMax)
                    {
                        Common.purchaseType = 6;
                        Common.purchaseSum = Vest.armorPlatePrice;
                        Common.purchaseProcess = true;
                    }
                }
                if (Common.purchaseProcess)
                {
                    Common.purchaseProcess = false;
                    bool flag = true;
                    if ((Game.Player.Character.Model == (Model)PedHash.Michael || Game.Player.Character.Model == (Model)PedHash.Franklin || Game.Player.Character.Model == (Model)PedHash.Trevor) && Game.Player.Money < Common.purchaseSum)
                        flag = false;
                    if (flag)
                    {
                        InventoryBag._isBuyingGear = true;
                        Function.Call(Hash.PLAY_PED_AMBIENT_SPEECH_NATIVE, (InputArgument)(Entity)Game.Player.Character, (InputArgument)"GENERIC_HI", (InputArgument)"SPEECH_PARAMS_FORCE");
                        Common._GunDealer.Task.LookAt((Entity)Game.Player.Character, 1000);
                    }
                    else
                    {
                        Screen.ShowHelpText("~BLIP_INFO_ICON~ You don't have enough money!");
                        Function.Call(Hash.PLAY_PED_AMBIENT_SPEECH_NATIVE, (InputArgument)(Entity)Common._GunDealer, (InputArgument)"SHOP_BANTER", (InputArgument)"SPEECH_PARAMS_FORCE");
                    }
                }
                if (InventoryBag._isBuyingGear)
                {
                    if (!Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Game.Player.Character, (InputArgument)"anim@scripted@heist@ig1_table_grab@gold@male@", (InputArgument)"enter", (InputArgument)3))
                    {
                        Function.Call(Hash.PLAY_PED_AMBIENT_SPEECH_NATIVE, (InputArgument)(Entity)Common._GunDealer, (InputArgument)"SHOP_SELL", (InputArgument)"SPEECH_PARAMS_FORCE");
                        Game.Player.Character.Task.PlayAnimation("anim@scripted@heist@ig1_table_grab@gold@male@", "enter", 8f, -1, AnimationFlags.UpperBodyOnly | AnimationFlags.Secondary);
                        HungerSystem.createFoodPacket(Game.Player.Character, Game.Player.Character.Position);
                    }
                    else if ((double)Function.Call<float>(Hash.GET_ENTITY_ANIM_CURRENT_TIME, (InputArgument)(Entity)Game.Player.Character, (InputArgument)"anim@scripted@heist@ig1_table_grab@gold@male@", (InputArgument)"enter") > 0.98000001907348633)
                    {
                        if (Common.purchaseType == 3)
                        {
                            InventoryBag.ClearInventoryData(Game.Player.Character);
                            InventoryBag.bagSet(InventoryBag.bagModelCheck(Game.Player.Character), Game.Player.Character);
                            Function.Call(Hash.SET_TEXT_COLOUR, (InputArgument)0, (InputArgument)(int)byte.MaxValue, (InputArgument)0, (InputArgument)100);
                            Notification.Show("Dufflebag has been ~g~purchased", true);
                            HTools.Main.Notify("Your payment check: ~n~Dufflebag: ~h~" + InventoryBag.BagPrice.ToString() + "~h~~g~$~w~~n~-------------~n~Total sum: ~h~" + InventoryBag.BagPrice.ToString() + "~h~~g~$~w~", "Shopping purchase", 0, (int)byte.MaxValue, 0, NotificationIcon.BankMaze);
                            HungerSystem.clearFoodPacket(Game.Player.Character, "hei_prop_hei_paper_bag");
                            InventoryBag._isBuyingGear = false;
                            InventoryBag.hasBag = InventoryBag.doesPedHasInventoryBag(Game.Player.Character);
                        }
                        if (Common.purchaseType == 4)
                        {
                            WeaponHolster.SaveHolster(Game.Player.Character);
                            Function.Call(Hash.SET_TEXT_COLOUR, (InputArgument)0, (InputArgument)(int)byte.MaxValue, (InputArgument)0, (InputArgument)100);
                            Notification.Show("Holster has been ~g~purchased", true);
                            HTools.Main.Notify("Your payment check: ~n~Holster: ~h~" + WeaponHolster.HolsterPrice.ToString() + "~h~~g~$~w~~n~-------------~n~Total sum: ~h~" + WeaponHolster.HolsterPrice.ToString() + "~h~~g~$~w~", "Shopping purchase", 0, (int)byte.MaxValue, 0, NotificationIcon.BankMaze);
                            HungerSystem.clearFoodPacket(Game.Player.Character, "hei_prop_hei_paper_bag");
                            InventoryBag._isBuyingGear = false;
                            WeaponHolster.hasHolster = WeaponHolster.doesPedHasHolster(Game.Player.Character);
                        }
                        if (Common.purchaseType == 5)
                        {
                            Function.Call(Hash.SET_TEXT_COLOUR, (InputArgument)0, (InputArgument)(int)byte.MaxValue, (InputArgument)0, (InputArgument)100);
                            Common.saveSupplies(Game.Player.Character, "weapon_tools", WeaponJamming.cleaningToolsMax);
                            Notification.Show("Weapon cleaning toolkit set has been ~g~purchased", true);
                            HTools.Main.Notify("Your payment check: ~n~Weapon cleaning toolkit set: ~h~" + WeaponJamming.weaponToolsPrice.ToString() + "~h~~g~$~w~~n~-------------~n~Total sum: ~h~" + WeaponJamming.weaponToolsPrice.ToString() + "~h~~g~$~w~", "Shopping purchase", 0, (int)byte.MaxValue, 0, NotificationIcon.BankMaze);
                            HungerSystem.clearFoodPacket(Game.Player.Character, "hei_prop_hei_paper_bag");
                            InventoryBag._isBuyingGear = false;
                        }
                        if (Common.purchaseType == 6)
                        {
                            Function.Call(Hash.SET_TEXT_COLOUR, (InputArgument)0, (InputArgument)(int)byte.MaxValue, (InputArgument)0, (InputArgument)100);
                            Vest.SavePlates(Game.Player.Character, "Armor_Plates", Vest.armorPlatesMax);
                            Notification.Show("Armor plate set set has been ~g~purchased", true);
                            HTools.Main.Notify("Your payment check: ~n~Armor plate set: ~h~" + Vest.armorPlatePrice.ToString() + "~h~~g~$~w~~n~-------------~n~Total sum: ~h~" + Vest.armorPlatePrice.ToString() + "~h~~g~$~w~", "Shopping purchase", 0, (int)byte.MaxValue, 0, NotificationIcon.BankMaze);
                            HungerSystem.clearFoodPacket(Game.Player.Character, "hei_prop_hei_paper_bag");
                            InventoryBag._isBuyingGear = false;
                        }
                        Function.Call(Hash.PLAY_PED_AMBIENT_SPEECH_NATIVE, (InputArgument)(Entity)Game.Player.Character, (InputArgument)"GENERIC_THANKS", (InputArgument)"SPEECH_PARAMS_FORCE");
                        if (Game.Player.Character.Model == (Model)PedHash.Michael || Game.Player.Character.Model == (Model)PedHash.Franklin || Game.Player.Character.Model == (Model)PedHash.Trevor)
                            Game.Player.Money -= Common.purchaseSum;
                    }
                }
            }
            int num3;
            if (Common.pedIsNearShopkeeper)
            {
                HTools.Main.DisableControlsFunc(true);
                Common.Draw(6, cameraModuleParam: false, swingWeaponModuleParam: false, laserSightModuleParam: false, weaponJamningModuleParam: false);
                if (Function.Call<bool>(Hash.IS_DISABLED_CONTROL_JUST_PRESSED, (InputArgument)0, (InputArgument)24) && !Game.Player.IsAiming)
                {
                    Common.purchaseType = 1;
                    Common.purchaseSum = HungerSystem.foodCost;
                    Common.purchaseProcess = true;
                }
                if (Function.Call<bool>(Hash.IS_DISABLED_CONTROL_JUST_PRESSED, (InputArgument)0, (InputArgument)25) && !Game.Player.IsAiming)
                {
                    Common.purchaseType = 2;
                    Common.purchaseSum = CigsAndPills.cigsAndPillsPrice;
                    Common.purchaseProcess = true;
                }
                if (Common.purchaseProcess)
                {
                    Common.purchaseProcess = false;
                    bool flag = true;
                    if ((Game.Player.Character.Model == (Model)PedHash.Michael || Game.Player.Character.Model == (Model)PedHash.Franklin || Game.Player.Character.Model == (Model)PedHash.Trevor) && Game.Player.Money < Common.purchaseSum)
                        flag = false;
                    if (flag)
                    {
                        HungerSystem._buyingSnacks = true;
                        Function.Call(Hash.PLAY_PED_AMBIENT_SPEECH_NATIVE, (InputArgument)(Entity)Game.Player.Character, (InputArgument)"GENERIC_HI", (InputArgument)"SPEECH_PARAMS_FORCE");
                        Common._shopKeeper.Task.LookAt((Entity)Game.Player.Character, 1000);
                    }
                    else
                    {
                        Screen.ShowHelpText("~BLIP_INFO_ICNO~ You don't have enough money!");
                        Function.Call(Hash.PLAY_PED_AMBIENT_SPEECH_NATIVE, (InputArgument)(Entity)Common._shopKeeper, (InputArgument)"SHOP_BANTER", (InputArgument)"SPEECH_PARAMS_FORCE");
                    }
                }
                if (HungerSystem._buyingSnacks)
                {
                    if (!Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Game.Player.Character, (InputArgument)"anim@scripted@heist@ig1_table_grab@gold@male@", (InputArgument)"enter", (InputArgument)3))
                    {
                        Function.Call(Hash.PLAY_PED_AMBIENT_SPEECH_NATIVE, (InputArgument)(Entity)Common._shopKeeper, (InputArgument)"SHOP_SELL", (InputArgument)"SPEECH_PARAMS_FORCE");
                        Game.Player.Character.Task.PlayAnimation("anim@scripted@heist@ig1_table_grab@gold@male@", "enter", 8f, -1, AnimationFlags.UpperBodyOnly | AnimationFlags.Secondary);
                        HungerSystem.createFoodPacket(Game.Player.Character, Game.Player.Character.Position);
                    }
                    else if ((double)Function.Call<float>(Hash.GET_ENTITY_ANIM_CURRENT_TIME, (InputArgument)(Entity)Game.Player.Character, (InputArgument)"anim@scripted@heist@ig1_table_grab@gold@male@", (InputArgument)"enter") > 0.98000001907348633)
                    {
                        if (Common.purchaseType == 1)
                        {
                            HungerSystem.updatePedFoodCount(Game.Player.Character, "burgers", 3, Common.doc);
                            HungerSystem.updatePedDrinksCount(Game.Player.Character, "coffee", 3, Common.doc);
                            string[] strArray = new string[7]
                            {
                "Your payment check: ~n~3 coffee: ~h~",
                (HungerSystem.foodCost / 2).ToString(),
                "~h~~g~$~w~~n~2 burgers: ~h~",
                null,
                null,
                null,
                null
                            };
                            num3 = HungerSystem.foodCost / 2;
                            strArray[3] = num3.ToString();
                            strArray[4] = "~h~~g~$~w~~n~-------------~n~total sum: ~h~";
                            strArray[5] = HungerSystem.foodCost.ToString();
                            strArray[6] = "~h~~g~$~w~";
                            HTools.Main.Notify(string.Concat(strArray), "Shoping purchase", 0, (int)byte.MaxValue, 0, NotificationIcon.BankMaze);
                            HungerSystem.clearFoodPacket(Game.Player.Character, "hei_prop_hei_paper_bag");
                            HungerSystem._buyingSnacks = false;
                        }
                        if (Common.purchaseType == 2)
                        {
                            if (CigsAndPills.pillsCount < CigsAndPills.maxPills)
                                Common.saveSupplies(Game.Player.Character, "painkillers", CigsAndPills.maxPills);
                            if (CigsAndPills.cigsCount < CigsAndPills.maxCigs)
                                Common.saveSupplies(Game.Player.Character, "ciggaretes", CigsAndPills.maxCigs);
                            string[] strArray = new string[11];
                            strArray[0] = "Your payment check: ~n~~h~";
                            strArray[1] = CigsAndPills.maxPills.ToString();
                            strArray[2] = "~h~ painkillers: ~h~";
                            num3 = Common.purchaseSum / 2;
                            strArray[3] = num3.ToString();
                            strArray[4] = "~h~~g~$~w~~n~~h~";
                            strArray[5] = CigsAndPills.maxCigs.ToString();
                            strArray[6] = "~h~ cigs: ~h~";
                            num3 = Common.purchaseSum / 2;
                            strArray[7] = num3.ToString();
                            strArray[8] = "~h~~g~$~w~~n~-------------~n~total sum: ~h~";
                            strArray[9] = Common.purchaseSum.ToString();
                            strArray[10] = "~g~$~w~~h~";
                            HTools.Main.Notify(string.Concat(strArray), "Shoping purchase", 0, (int)byte.MaxValue, 0, NotificationIcon.BankMaze);
                            HungerSystem.clearFoodPacket(Game.Player.Character, "hei_prop_hei_paper_bag");
                            HungerSystem._buyingSnacks = false;
                        }
                        Function.Call(Hash.PLAY_PED_AMBIENT_SPEECH_NATIVE, (InputArgument)(Entity)Game.Player.Character, (InputArgument)"GENERIC_THANKS", (InputArgument)"SPEECH_PARAMS_FORCE");
                        if (Game.Player.Character.Model == (Model)PedHash.Michael || Game.Player.Character.Model == (Model)PedHash.Franklin || Game.Player.Character.Model == (Model)PedHash.Trevor)
                            Game.Player.Money -= Common.purchaseSum;
                    }
                }
            }
            Vector3 vector3_1;
            if (InventoryBag.timeReference < Game.GameTime)
            {
                InventoryBag.timeReference = Game.GameTime + 1000;
                Ped[] nearbyPeds = World.GetNearbyPeds(Game.Player.Character, 5f, (Model)PedHash.Ammucity01SMY, (Model)PedHash.AmmuCountrySMM);
                if (nearbyPeds.Length != 0)
                {
                    vector3_1 = Game.Player.Character.Position;
                    if ((double)vector3_1.DistanceTo(nearbyPeds[0].Position) <= 4.0 && Function.Call<bool>(Hash.IS_PED_FACING_PED, (InputArgument)(Entity)Game.Player.Character, (InputArgument)(Entity)nearbyPeds[0], (InputArgument)15f) && !nearbyPeds[0].IsFleeing && nearbyPeds[0].IsOnScreen)
                    {
                        if ((Entity)Common._GunDealer == (Entity)null || (Entity)Common._GunDealer != (Entity)null && Common._GunDealer.IsDead)
                        {
                            Common._GunDealer = nearbyPeds[0];
                            Game.Player.Character.Task.LookAt((Entity)nearbyPeds[0], 6000);
                        }
                        Common.pedIsNearGunDealer = true;
                    }
                    else
                    {
                        Common._GunDealer = (Ped)null;
                        Common.pedIsNearGunDealer = false;
                        Common.purchaseProcess = false;
                        if (InventoryBag._isBuyingGear)
                        {
                            Game.Player.Character.Task.ClearAll();
                            InventoryBag._isBuyingGear = false;
                        }
                    }
                }
                else
                {
                    Common._GunDealer = (Ped)null;
                    Common.pedIsNearGunDealer = false;
                    Common.purchaseProcess = false;
                    if (InventoryBag._isBuyingGear)
                    {
                        Game.Player.Character.Task.ClearAll();
                        InventoryBag._isBuyingGear = false;
                    }
                }
            }
            if (HungerSystem.hungerTimeRef2 < Game.GameTime)
            {
                HungerSystem.hungerTimeRef2 = Game.GameTime + 1000;
                Ped[] nearbyPeds = World.GetNearbyPeds(Game.Player.Character, 5f, (Model)PedHash.ShopKeep01);
                if (nearbyPeds.Length != 0)
                {
                    vector3_1 = Game.Player.Character.Position;
                    if ((double)vector3_1.DistanceTo(nearbyPeds[0].Position) <= 4.0 && Function.Call<bool>(Hash.IS_PED_FACING_PED, (InputArgument)(Entity)Game.Player.Character, (InputArgument)(Entity)nearbyPeds[0], (InputArgument)15f) && !nearbyPeds[0].IsFleeing && nearbyPeds[0].IsOnScreen && nearbyPeds[0].IsAlive)
                    {
                        if ((Entity)Common._shopKeeper == (Entity)null || (Entity)Common._shopKeeper != (Entity)null && Common._shopKeeper.IsDead)
                        {
                            Common._shopKeeper = nearbyPeds[0];
                            Game.Player.Character.Task.LookAt((Entity)nearbyPeds[0], 6000);
                        }
                        Common.pedIsNearShopkeeper = true;
                    }
                    else
                    {
                        Common._shopKeeper = (Ped)null;
                        Common.pedIsNearShopkeeper = false;
                        Common.purchaseProcess = false;
                        if (HungerSystem._buyingSnacks)
                        {
                            Game.Player.Character.Task.ClearAll();
                            HungerSystem._buyingSnacks = false;
                        }
                    }
                }
                else
                {
                    Common._shopKeeper = (Ped)null;
                    Common.pedIsNearShopkeeper = false;
                    Common.purchaseProcess = false;
                    if (HungerSystem._buyingSnacks)
                    {
                        Game.Player.Character.Task.ClearAll();
                        HungerSystem._buyingSnacks = false;
                    }
                }
            }
            if (HungerSystem.hungerModuleActive && HungerSystem.hungerTimeRef < Game.GameTime)
            {
                HungerSystem.hungerTimeRef = Game.GameTime + 30000;
                HungerSystem.curHungerLvl = HungerSystem.savePedHungerLvl(Game.Player.Character, HungerSystem.getPedHungerLvl(Game.Player.Character, Common.doc) - 1, HungerSystem.hunger_lvl_max, Common.doc);
                HungerSystem.hungerBar.Percentage = HungerSystem.curHungerLvl > 0 ? (float)((double)HungerSystem.curHungerLvl / (double)HungerSystem.hunger_lvl_max * 100.0) : 0.0f;
                if (HungerSystem.curHungerLvl < HungerSystem.hunger_lvl_max / 100 * 50)
                {
                    if (HungerSystem.curHungerLvl < HungerSystem.hunger_lvl_max / 100 * 25)
                    {
                        
                        HTools.Main.soundFX(Game.Player.Character, "StomachGrowling.wav", Common.assetFolder, 13f);
                        HungerSystem.hungerBar.ForegroundColor = Color.Red;
                    }
                    if (!HTools.Main.barPool.ToList().Contains(HungerSystem.hungerBar))
                        HTools.Main.barPool.Add(HungerSystem.hungerBar);
                }
                else if (HTools.Main.barPool.ToList().Contains(HungerSystem.hungerBar))
                    HTools.Main.barPool.Remove(HungerSystem.hungerBar);
                if (HungerSystem.curHungerLvl <= HungerSystem.criticalHungerLvl)
                {
                    Game.Player.Character.HealthFloat -= 0.5f;
                    if (!HungerSystem.isHungry)
                    {
                        HTools.Main.Notify("You're ~r~starving~w~.~n~Eat some ~g~food~w~ using the ~b~Main ~y~Menu~w~", "Health Report", 0, (int)byte.MaxValue, 0, NotificationIcon.LesterDeathwish);
                        HTools.Main.startBleeding(Game.Player.Character, false, useInjuryAnim: false);
                    }
                    HungerSystem.isHungry = true;
                }
                else
                {
                    if (HungerSystem.isHungry)
                        HTools.Main.stopBleeding(Game.Player.Character, false);
                    HungerSystem.isHungry = false;
                }
                if (HungerSystem.isHungry)
                    HTools.Main.soundFX(Game.Player.Character, "StomachGrowling.wav", Common.assetFolder, 13f);
            }
            if (HungerSystem.hungerModuleActive && HungerSystem.thirstTimeRef < Game.GameTime)
            {
                HungerSystem.thirstTimeRef = Game.GameTime + 30000;
                HungerSystem.curThirstLvl = HungerSystem.savePedThirstLvl(Game.Player.Character, HungerSystem.getPedThirstLvl(Game.Player.Character, Common.doc) - 1, HungerSystem.thirst_lvl_max, Common.doc);
                HungerSystem.thirstBar.Percentage = HungerSystem.curThirstLvl > 0 ? (float)((double)HungerSystem.curThirstLvl / (double)HungerSystem.thirst_lvl_max * 100.0) : 0.0f;
                if (HungerSystem.curThirstLvl < HungerSystem.thirst_lvl_max / 100 * 50)
                {
                    if (HungerSystem.curThirstLvl < HungerSystem.thirst_lvl_max / 100 * 25)
                    {
                        HTools.Main.soundFX(Game.Player.Character, "StomachGrowling.wav", Common.assetFolder, 13f);
                        HungerSystem.thirstBar.ForegroundColor = Color.Red;
                    }
                    if (!HTools.Main.barPool.ToList().Contains(HungerSystem.thirstBar))
                        HTools.Main.barPool.Add(HungerSystem.thirstBar);
                }
                else if (HTools.Main.barPool.ToList().Contains(HungerSystem.thirstBar))
                    HTools.Main.barPool.Remove(HungerSystem.thirstBar);
                if (HungerSystem.curThirstLvl <= HungerSystem.criticalThirstLvl)
                {
                    Game.Player.Character.HealthFloat -= 0.5f;
                    if (!HungerSystem.isThirsty)
                    {
                        HTools.Main.Notify("You're ~r~dehydrated~w~.~n~Drink ~g~fluids~w~ using the ~b~Main ~y~Menu~w~", "Health Report", 0, (int)byte.MaxValue, 0, NotificationIcon.LesterDeathwish);
                        HTools.Main.startBleeding(Game.Player.Character, false, useInjuryAnim: false);
                    }
                    HungerSystem.isThirsty = true;
                }
                else
                {
                    if (HungerSystem.isThirsty)
                        HTools.Main.stopBleeding(Game.Player.Character, false);
                    HungerSystem.isThirsty = false;
                }
                if (HungerSystem.isThirsty)
                    
                HTools.Main.soundFX(Game.Player.Character, "StomachGrowling.wav", Common.assetFolder, 13f);
            }
            if (WeaponHolster.holster_module_active)
            {
                if (WeaponHolster.customHolsterAnim && !WeaponHolster.intimidation && (Entity)InventoryBag.bagModelReturn(Game.Player.Character) == (Entity)null)
                {
                    if ((double)Function.Call<float>(Hash.GET_ENTITY_ANIM_CURRENT_TIME, (InputArgument)(Entity)Game.Player.Character, (InputArgument)"reaction@intimidation@cop@unarmed", (InputArgument)"outro") > 0.2 && (Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Game.Player.Character, (InputArgument)"move_m@intimidation@cop@unarmed", (InputArgument)"idle", (InputArgument)3) || Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Game.Player.Character, (InputArgument)"reaction@intimidation@cop@unarmed", (InputArgument)"intro", (InputArgument)3) || Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Game.Player.Character, (InputArgument)"reaction@intimidation@cop@unarmed", (InputArgument)"outro", (InputArgument)3) || Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Game.Player.Character, (InputArgument)"mp_arrest_paired", (InputArgument)"cop_p1_rf_right_0", (InputArgument)3)))
                    {
                        Function.Call(Hash.STOP_ENTITY_ANIM, (InputArgument)(Entity)Game.Player.Character, (InputArgument)"idle", (InputArgument)"move_m@intimidation@cop@unarmed", (InputArgument)3);
                        Function.Call(Hash.STOP_ENTITY_ANIM, (InputArgument)(Entity)Game.Player.Character, (InputArgument)"intro", (InputArgument)"reaction@intimidation@cop@unarmed", (InputArgument)3);
                        Function.Call(Hash.STOP_ENTITY_ANIM, (InputArgument)(Entity)Game.Player.Character, (InputArgument)"outro", (InputArgument)"reaction@intimidation@cop@unarmed", (InputArgument)3);
                        Function.Call(Hash.STOP_ENTITY_ANIM, (InputArgument)(Entity)Game.Player.Character, (InputArgument)"cop_p1_rf_right_0", (InputArgument)"mp_arrest_paired", (InputArgument)3);
                    }
                    if ((Entity)WeaponHolster.holster != (Entity)null && WeaponHolster.holster.Exists() && WeaponHolster.holsterSet && !Common.isOccupied(Game.Player.Character) && !HTools.Main.isOccupiedNative(Game.Player.Character) && !Function.Call<bool>(Hash.IS_PED_RUNNING_MOBILE_PHONE_TASK, (InputArgument)(Entity)Game.Player.Character) && !Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Game.Player.Character, (InputArgument)"reaction@intimidation@cop@unarmed", (InputArgument)"intro", (InputArgument)3) && !Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Game.Player.Character, (InputArgument)"move_m@intimidation@cop@unarmed", (InputArgument)"idle", (InputArgument)3) && !Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Game.Player.Character, (InputArgument)"reaction@intimidation@cop@unarmed", (InputArgument)"outro", (InputArgument)3) && WeaponHolster.weaponPistolInHands != WeaponHolster.pistolChanged)
                    {
                        WeaponHolster.pistolChanged = WeaponHolster.weaponPistolInHands;
                        if (!Game.Player.Character.IsSittingInVehicle())
                        {
                            if (!Function.Call<bool>(Hash.GET_PED_STEALTH_MOVEMENT, (InputArgument)(Entity)Game.Player.Character) && !Game.Player.Character.IsInCombat && !Game.Player.Character.IsDucking)
                            {
                                if (Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Game.Player.Character, (InputArgument)"mp_arrest_paired", (InputArgument)"cop_p1_rf_right_0", (InputArgument)3))
                                    Function.Call(Hash.STOP_ENTITY_ANIM, (InputArgument)(Entity)Game.Player.Character, (InputArgument)"cop_p1_rf_right_0", (InputArgument)"mp_arrest_paired", (InputArgument)3);
                                if (!Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Game.Player.Character, (InputArgument)"reaction@intimidation@cop@unarmed", (InputArgument)"outro", (InputArgument)3))
                                    Function.Call(Hash.TASK_PLAY_ANIM, (InputArgument)(Entity)Game.Player.Character, (InputArgument)"reaction@intimidation@cop@unarmed", (InputArgument)"outro", (InputArgument)8f, (InputArgument)(-8.0), (InputArgument)(-1), (InputArgument)48, (InputArgument)0.0f, (InputArgument)0, (InputArgument)0, (InputArgument)0);
                            }
                            else if (!Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Game.Player.Character, (InputArgument)"mp_arrest_paired", (InputArgument)"cop_p1_rf_right_0", (InputArgument)3))
                                Function.Call(Hash.TASK_PLAY_ANIM, (InputArgument)(Entity)Game.Player.Character, (InputArgument)"mp_arrest_paired", (InputArgument)"cop_p1_rf_right_0", (InputArgument)8f, (InputArgument)(-8.0), (InputArgument)(-1), (InputArgument)48, (InputArgument)0.0f, (InputArgument)0, (InputArgument)0, (InputArgument)0);
                            HTools.Main.soundFX(Game.Player.Character, "holster.wav", Common.assetFolder);
                        }
                    }
                }
                if (WeaponHolster.intimidation)
                {
                    Common.Draw(4);
                    HTools.Main.DisableControlsFunc(false);
                    if (!Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Game.Player.Character, (InputArgument)"move_m@intimidation@cop@unarmed", (InputArgument)"idle", (InputArgument)3) && !Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Game.Player.Character, (InputArgument)"reaction@intimidation@cop@unarmed", (InputArgument)"intro", (InputArgument)3) && !Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Game.Player.Character, (InputArgument)"reaction@intimidation@cop@unarmed", (InputArgument)"outro", (InputArgument)3))
                        Game.Player.Character.Task.PlayAnimation("move_m@intimidation@cop@unarmed", "idle", 12f, -1, AnimationFlags.StayInEndFrame | AnimationFlags.Secondary | AnimationFlags.AbortOnPedMovement);
                    else if (Game.IsControlJustPressed(Control.Attack) && (Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Game.Player.Character, (InputArgument)"move_m@intimidation@cop@unarmed", (InputArgument)"idle", (InputArgument)3) || Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Game.Player.Character, (InputArgument)"reaction@intimidation@cop@unarmed", (InputArgument)"intro", (InputArgument)3) || Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Game.Player.Character, (InputArgument)"reaction@intimidation@cop@unarmed", (InputArgument)"outro", (InputArgument)3)))
                    {
                        WeaponHolster.AttackSpeech(Game.Player.Character);
                        WeaponHolster.GetClosestPedDetectionFunction(Game.Player.Character);
                    }
                    else if (Game.IsControlJustPressed(Control.Aim))
                    {
                        WeaponHolster.intimidation = false;
                        Game.Player.Character.Task.ClearAll();
                    }
                }
                if (WeaponHolster.holsterTimerCounterLong < Game.GameTime)
                {
                    WeaponHolster.holsterTimerCounterLong = Game.GameTime + 5000;
                    if ((Entity)WeaponHolster.target != (Entity)null)
                    {
                        vector3_1 = WeaponHolster.target.Position;
                        if ((double)vector3_1.DistanceTo(Game.Player.Character.Position) > 50.0 || !WeaponHolster.target.Exists() || WeaponHolster.target.IsDead)
                            WeaponHolster.target.MarkAsNoLongerNeeded();
                        WeaponHolster.target = (Ped)null;
                    }
                    if (!WeaponHolster.check)
                    {
                        WeaponHolster.GetHolsterPropFunction(Game.Player.Character);
                        WeaponHolster.check = true;
                    }
                    if ((Entity)WeaponHolster.holster == (Entity)null && Function.Call<bool>(Hash.DOES_OBJECT_OF_TYPE_EXIST_AT_COORDS, (InputArgument)Game.Player.Character.Position.X, (InputArgument)Game.Player.Character.Position.Y, (InputArgument)Game.Player.Character.Position.Z, (InputArgument)3f, (InputArgument)WeaponHolster.worldPistolModel, (InputArgument)0) && Function.Call<bool>(Hash.IS_ENTITY_ATTACHED_TO_ENTITY, (InputArgument)(Entity)Function.Call<Prop>(Hash.GET_CLOSEST_OBJECT_OF_TYPE, (InputArgument)Game.Player.Character.Position.X, (InputArgument)Game.Player.Character.Position.Y, (InputArgument)Game.Player.Character.Position.Z, (InputArgument)3f, (InputArgument)WeaponHolster.worldPistolModel, (InputArgument)true, (InputArgument)false, (InputArgument)false), (InputArgument)(Entity)Game.Player.Character) && (Entity)WeaponHolster.HolstedPistol != (Entity)null)
                    {
                        WeaponHolster.HolstedPistol.Delete();
                        WeaponHolster.HolstedPistol = (Prop)null;
                    }
                }
                if ((Entity)WeaponHolster.HolstedPistolPrev != (Entity)null && !WeaponHolster.HolstedPistolPrev.IsAttached())
                {
                    WeaponHolster.HolstedPistolPrev.Delete();
                    WeaponHolster.HolstedPistolPrev = (Prop)null;
                }
                if (WeaponHolster.holsterTimerCounterShort < Game.GameTime)
                {
                    WeaponHolster.holsterTimerCounterShort = Game.GameTime + 500;
                    if (Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Game.Player.Character, (InputArgument)"missmic2@meat_hook", (InputArgument)"michael_meat_hook_fall", (InputArgument)3) || Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Game.Player.Character, (InputArgument)"missmic2@meat_hook", (InputArgument)"michael_meat_hook_idle", (InputArgument)3) || Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Game.Player.Character, (InputArgument)"missmic2@meat_hook", (InputArgument)"michael_meat_hook_react_a", (InputArgument)3) || Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Game.Player.Character, (InputArgument)"missmic2@meat_hook", (InputArgument)"michael_meat_hook_react_b", (InputArgument)3) || Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Game.Player.Character, (InputArgument)"missmic2@meat_hook", (InputArgument)"michael_meat_hook_react_c", (InputArgument)3) || Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Game.Player.Character, (InputArgument)"missmic2@meat_hook", (InputArgument)"michael_meat_hook_react_d", (InputArgument)3))
                    {
                        WeaponHolster.holsterSet = false;
                        if ((Entity)WeaponHolster.holster != (Entity)null && WeaponHolster.holster.Exists())
                        {
                            WeaponHolster.holster.Delete();
                            WeaponHolster.holster = (Prop)null;
                        }
                        if ((Entity)WeaponHolster.holster != (Entity)null && WeaponHolster.holster.Exists())
                        {
                            WeaponHolster.HolstedPistol.Delete();
                            WeaponHolster.HolstedPistol = (Prop)null;
                        }
                    }
                    if (WeaponHolster.holsterSet && (Entity)WeaponHolster.holster != (Entity)null && WeaponHolster.holster.Exists() && WeaponHolster.holster.IsAttachedTo((Entity)Game.Player.Character))
                    {
                        WeaponHolster.IconHolsterDrawFunc(Game.Player.Character, WeaponHolster.weaponPistolInHands);
                        if (((IEnumerable<WeaponGroup>)WeaponHolster._pistolWeaponGroup).Contains<WeaponGroup>(Game.Player.Character.Weapons.Current.Group))
                        {
                            WeaponHolster.worldPistolModel = (int)Game.Player.Character.Weapons.CurrentWeaponObject.Model;
                            WeaponHolster.choosenPistol = Game.Player.Character.Weapons.Current.Hash;
                        }
                        WeaponHolster.weaponPistolInHands = Game.Player.Character.Weapons.Current.Hash == WeaponHolster.choosenPistol;
                    }
                    if (((IEnumerable<WeaponGroup>)WeaponHolster._bigWeaponGroups).Contains<WeaponGroup>(Game.Player.Character.Weapons.Current.Group))
                    {
                        WeaponHolster.worldNonPistolWeaponModel = (int)Game.Player.Character.Weapons.CurrentWeaponObject.Model;
                        WeaponHolster.choosenNonPistolWeapon = (Model)Game.Player.Character.Weapons.Current.Hash;
                    }
                    WeaponHolster.weaponNonPistolInHands = (Model)Game.Player.Character.Weapons.Current.Hash == WeaponHolster.choosenNonPistolWeapon;
                    if (!Function.Call<bool>(Hash.IS_PLAYER_SWITCH_IN_PROGRESS) && !Screen.IsFadingIn && !Screen.IsFadingOut && !Function.Call<bool>(Hash.IS_CUTSCENE_PLAYING) && Game.Player.CanControlCharacter)
                    {
                        WeaponHolster.player = Game.Player.Character;
                    }
                    else
                    {
                        WeaponHolster.prevPlayer = WeaponHolster.player;
                        WeaponHolster.HolstedPistolPrev = WeaponHolster.HolstedPistol;
                    }
                    if ((Entity)WeaponHolster.player != (Entity)Game.Player.Character)
                        WeaponHolster.goodToGo = false;
                    else if (!WeaponHolster.goodToGo)
                    {
                        WeaponHolster.goodToGo = true;
                        if ((Entity)WeaponHolster.HolstedPistol != (Entity)null && WeaponHolster.HolstedPistol.Exists())
                            WeaponHolster.HolstedPistol = (Prop)null;
                        if ((Entity)WeaponHolster.HolstedNonPistolWeapon != (Entity)null && WeaponHolster.HolstedNonPistolWeapon.Exists())
                            WeaponHolster.HolstedNonPistolWeapon = (Prop)null;
                        if ((Entity)WeaponHolster.prevPlayer != (Entity)null && !WeaponHolster.prevPlayer.Exists())
                        {
                            if ((Entity)WeaponHolster.holster != (Entity)null && WeaponHolster.holster.Exists())
                            {
                                WeaponHolster.holster.Delete();
                                WeaponHolster.holster = (Prop)null;
                            }
                        }
                        else
                            WeaponHolster.holster = (Prop)null;
                        WeaponHolster.weaponPistolInHands = false;
                        WeaponHolster.worldPistolModel = 0;
                        WeaponHolster.weaponNonPistolInHands = false;
                        WeaponHolster.worldNonPistolWeaponModel = 0;
                        WeaponHolster.checkHolsterAfterCharacterSwitch(Game.Player.Character, WeaponHolster.useHipHolster);
                    }
                    if ((Entity)WeaponHolster.holster != (Entity)null && WeaponHolster.holster.Exists() && Function.Call<bool>(Hash.IS_ENTITY_ATTACHED_TO_ENTITY, (InputArgument)(Entity)WeaponHolster.holster, (InputArgument)(Entity)Game.Player.Character) && WeaponHolster.worldPistolModel != 0)
                    {
                        WeaponHolster.HolstedPistol = WeaponHolster.removeHolstedPistolFunc(Game.Player.Character, WeaponHolster.HolstedPistol, WeaponHolster.choosenPistol, WeaponHolster.worldPistolModel);
                        if (!Common.isOccupied(Game.Player.Character) && !HTools.Main.isOccupiedNative(Game.Player.Character) && !Game.Player.Character.IsSittingInVehicle())
                            WeaponHolster.HolstedPistol = WeaponHolster.checkPistolFunc(Game.Player.Character, WeaponHolster.holster, WeaponHolster.weaponPistolInHands, WeaponHolster.choosenPistol, WeaponHolster.worldPistolModel, WeaponHolster.HolstedPistol, WeaponHolster.useHipHolster, false, new Vector3(0.0f, 0.0f, 0.0f), new Vector3(0.0f, 0.0f, 0.0f), 0);
                    }
                    if (WeaponHolster.worldNonPistolWeaponModel != 0 && WeaponHolster.holsted_big_weapons_module_active)
                    {
                        WeaponHolster.HolstedNonPistolWeapon = WeaponHolster.removeHolstedPistolFunc(Game.Player.Character, WeaponHolster.HolstedNonPistolWeapon, (WeaponHash)WeaponHolster.choosenNonPistolWeapon, WeaponHolster.worldNonPistolWeaponModel);
                        if (!Common.isOccupied(Game.Player.Character) && !HTools.Main.isOccupiedNative(Game.Player.Character) && !Game.Player.Character.IsSittingInVehicle())
                            WeaponHolster.HolstedNonPistolWeapon = WeaponHolster.checkPistolFunc(Game.Player.Character, (Prop)null, WeaponHolster.weaponNonPistolInHands, (WeaponHash)WeaponHolster.choosenNonPistolWeapon, WeaponHolster.worldNonPistolWeaponModel, WeaponHolster.HolstedNonPistolWeapon, WeaponHolster.useHipHolster, true, WeaponHolster.holstedWeaponAttachPos, WeaponHolster.holstedWeaponAttachRot, WeaponHolster.holstedWeaponAttachBone, positionTypeParam: WeaponHolster.weaponPositionType);
                        if (!WeaponHolster.weaponNonPistolInHands && (Entity)WeaponHolster.HolstedNonPistolWeapon != (Entity)null && Game.Player.Character.IsJumping)
                        {
                            if (WeaponHolster.weaponSoundFXTimer <= 0)
                            {
                                if (Game.Player.Character.IsJumping)
                                    WeaponHolster.weaponSoundFXTimer = 0;
                                HTools.Main.soundFX(Game.Player.Character, WeaponHolster.weaponSoundsFXArray[WeaponHolster.weaponSoundFXIndex], Common.assetFolder);
                                if (WeaponHolster.weaponSoundFXIndex < WeaponHolster.weaponSoundsFXArray.Length - 1)
                                    num3 = ++WeaponHolster.weaponSoundFXIndex;
                                else
                                    WeaponHolster.weaponSoundFXIndex = 0;
                            }
                            else
                                num3 = --WeaponHolster.weaponSoundFXTimer;
                        }
                        else
                            WeaponHolster.weaponSoundFXTimer = 0;
                    }
                    if (Screen.IsFadingIn || Screen.IsFadingOut)
                    {
                        Prop[] allProps = World.GetAllProps((Model)"prop_holster_01");
                        if (!WeaponHolster.useHipHolster)
                            allProps = World.GetAllProps((Model)"prop_pistol_holster");
                        for (int index = 0; index < allProps.Length; num3 = ++index)
                        {
                            if (allProps.Length != 0 && (Entity)allProps[index] != (Entity)null && allProps[index].Exists() && !allProps[index].IsAttached())
                            {
                                allProps[index].Delete();
                                Array.Clear((Array)allProps, 0, allProps.Length);
                            }
                        }
                    }
                }
            }
            int num4 = FastWardrobe.mask_module_active ? 1 : 0;
            if (OnFootRadio.earRadioTimer < Game.GameTime)
            {
                OnFootRadio.earRadioTimer = Game.GameTime + 5000;
                model = Game.Player.Character.Model;
                if (model.Hash != HTools.Main.GetHashKey("mp_m_freemode_01"))
                {
                    model = Game.Player.Character.Model;
                    if (model.Hash != HTools.Main.GetHashKey("mp_f_freemode_01"))
                    {
                        model = Game.Player.Character.Model;
                        if (model.Hash != HTools.Main.GetHashKey("PLAYER_ZERO"))
                        {
                            model = Game.Player.Character.Model;
                            if (model.Hash != HTools.Main.GetHashKey("PLAYER_ONE"))
                            {
                                model = Game.Player.Character.Model;
                                if (model.Hash != HTools.Main.GetHashKey("PLAYER_TWO"))
                                    goto label_611;
                            }
                        }
                    }
                }
                int num5 = Function.Call<int>(Hash.GET_PED_PROP_INDEX, (InputArgument)(Entity)Game.Player.Character, (InputArgument)2);
                OnFootRadio.headset = false;
                if (num5 == 0)
                    OnFootRadio.headset = true;
                label_611:
                if (!OnFootRadio.headset && Function.Call<bool>(Hash.IS_MOBILE_PHONE_RADIO_ACTIVE))
                {
                    Vector3 position = new Vector3(266.1459f, -1007.036f, -100.9292f);
                    vector3_1 = Game.Player.Character.Position;
                    if ((double)vector3_1.DistanceTo(position) > 50.0 && !Function.Call<bool>(Hash.DOES_OBJECT_OF_TYPE_EXIST_AT_COORDS, (InputArgument)Game.Player.Character.Position.X, (InputArgument)Game.Player.Character.Position.Y, (InputArgument)Game.Player.Character.Position.Z, (InputArgument)25f, (InputArgument)HTools.Main.GetHashKey("prop_boombox_01"), (InputArgument)0))
                    {
                        Function.Call(Hash.SET_MOBILE_PHONE_RADIO_STATE, (InputArgument)false);
                        Function.Call(Hash.SET_MOBILE_RADIO_ENABLED_DURING_GAMEPLAY, (InputArgument)false);
                    }
                }
            }
            if ((Function.Call<bool>(Hash.IS_CONTROL_PRESSED, (InputArgument)0, (InputArgument)85) || Function.Call<bool>(Hash.IS_CONTROL_JUST_PRESSED, (InputArgument)0, (InputArgument)81) || Function.Call<bool>(Hash.IS_CONTROL_JUST_PRESSED, (InputArgument)0, (InputArgument)82)) && !Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Game.Player.Character, (InputArgument)"anim@cellphone@in_car@ds", (InputArgument)"cellphone_text_to_call", (InputArgument)3))
            {
                if (OnFootRadio.headset && !Function.Call<bool>(Hash.IS_PED_RUNNING_MOBILE_PHONE_TASK, (InputArgument)(Entity)Game.Player.Character) && !Function.Call<bool>(Hash.IS_PED_RUNNING_RAGDOLL_TASK, (InputArgument)(Entity)Game.Player.Character) && !Function.Call<bool>(Hash.IS_PED_DOING_DRIVEBY, (InputArgument)(Entity)Game.Player.Character) && !Function.Call<bool>(Hash.IS_PLAYER_FREE_AIMING, (InputArgument)Game.Player) && !Game.Player.Character.IsSittingInVehicle())
                {
                    Game.Player.Character.Task.ClearAll();
                    Function.Call(Hash.TASK_PLAY_ANIM, (InputArgument)(Entity)Game.Player.Character, (InputArgument)"anim@cellphone@in_car@ds", (InputArgument)"cellphone_text_to_call", (InputArgument)45f, (InputArgument)(-12.0), (InputArgument)(-1), (InputArgument)50, (InputArgument)0.0f, (InputArgument)0, (InputArgument)0, (InputArgument)0);
                }
            }
            else if ((Function.Call<bool>(Hash.IS_CONTROL_JUST_RELEASED, (InputArgument)0, (InputArgument)85) || Function.Call<bool>(Hash.IS_CONTROL_JUST_RELEASED, (InputArgument)0, (InputArgument)81) || Function.Call<bool>(Hash.IS_CONTROL_JUST_RELEASED, (InputArgument)0, (InputArgument)82)) && !Function.Call<bool>(Hash.IS_PED_RUNNING_MOBILE_PHONE_TASK) && Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Game.Player.Character, (InputArgument)"anim@cellphone@in_car@ds", (InputArgument)"cellphone_text_to_call", (InputArgument)3) && !Function.Call<bool>(Hash.IS_MOBILE_PHONE_CALL_ONGOING, (InputArgument)false) && !Game.Player.Character.IsSittingInVehicle())
            {
                if (Function.Call<bool>(Hash.IS_CONTROL_JUST_RELEASED, (InputArgument)0, (InputArgument)81) || Function.Call<bool>(Hash.IS_CONTROL_JUST_RELEASED, (InputArgument)0, (InputArgument)82))
                {
                    Script.Wait(1000);
                    Function.Call(Hash.STOP_ENTITY_ANIM, (InputArgument)(Entity)Game.Player.Character, (InputArgument)"cellphone_text_to_call", (InputArgument)"anim@cellphone@in_car@ds", (InputArgument)3);
                }
                else
                {
                    Script.Wait(200);
                    Function.Call(Hash.STOP_ENTITY_ANIM, (InputArgument)(Entity)Game.Player.Character, (InputArgument)"cellphone_text_to_call", (InputArgument)"anim@cellphone@in_car@ds", (InputArgument)3);
                }
            }
            if (Wallet.walletCount && !CigsAndPills.smoking)
            {
                Function.Call(Hash.SET_CURRENT_PED_WEAPON, (InputArgument)(Entity)Game.Player.Character, (InputArgument)2725352035U, (InputArgument)true);
                Function.Call(Hash.SET_PED_CAN_PLAY_GESTURE_ANIMS, (InputArgument)(Entity)Game.Player.Character, (InputArgument)false);
                Function.Call<int>(Hash.GET_PED_BONE_INDEX, (InputArgument)(Entity)Game.Player.Character, (InputArgument)36029);
                int num6 = Function.Call<int>(Hash.GET_PED_BONE_INDEX, (InputArgument)(Entity)Game.Player.Character, (InputArgument)6286);
                if (!Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Game.Player.Character, (InputArgument)"anim@amb@board_room@supervising@", (InputArgument)"dissaproval_01_lo_amy_skater_01", (InputArgument)3))
                {
                    Wallet.animSpeed = 1f;
                    Game.Player.Character.Task.LookAt((Entity)Game.Player.Character);
                    Function.Call(Hash.ATTACH_ENTITY_TO_ENTITY, (InputArgument)(Entity)Wallet.wallet, (InputArgument)(Entity)Game.Player.Character, (InputArgument)num6, (InputArgument)0.1, (InputArgument)0.015, (InputArgument)(-0.025), (InputArgument)115.0, (InputArgument)20.0, (InputArgument)0.0, (InputArgument)false, (InputArgument)false, (InputArgument)false, (InputArgument)false, (InputArgument)0, (InputArgument)true);
                    Game.Player.Character.Task.PlayAnimation("anim@amb@board_room@supervising@", "dissaproval_01_lo_amy_skater_01", Wallet.animSpeed, -1, AnimationFlags.UpperBodyOnly | AnimationFlags.Secondary);
                }
                else
                {
                    if ((double)Wallet.animSpeed < 2.0)
                        Wallet.animSpeed += 0.01f;
                    double num7 = (double)Function.Call<float>(Hash.SET_ENTITY_ANIM_SPEED, (InputArgument)(Entity)Game.Player.Character, (InputArgument)"anim@amb@board_room@supervising@", (InputArgument)"dissaproval_01_lo_amy_skater_01", (InputArgument)Wallet.animSpeed);
                    if ((double)Function.Call<float>(Hash.GET_ENTITY_ANIM_CURRENT_TIME, (InputArgument)(Entity)Game.Player.Character, (InputArgument)"anim@amb@board_room@supervising@", (InputArgument)"dissaproval_01_lo_amy_skater_01") > 0.10000000149011612 && (double)Function.Call<float>(Hash.GET_ENTITY_ANIM_CURRENT_TIME, (InputArgument)(Entity)Game.Player.Character, (InputArgument)"anim@amb@board_room@supervising@", (InputArgument)"dissaproval_01_lo_amy_skater_01") < 0.5)
                    {
                        if ((Entity)Wallet.walletOpened != (Entity)null)
                            Wallet.walletOpened.IsVisible = true;
                        if ((Entity)Wallet.wallet != (Entity)null)
                            Wallet.wallet.IsVisible = false;
                    }
                    if ((double)Function.Call<float>(Hash.GET_ENTITY_ANIM_CURRENT_TIME, (InputArgument)(Entity)Game.Player.Character, (InputArgument)"anim@amb@board_room@supervising@", (InputArgument)"dissaproval_01_lo_amy_skater_01") > 0.5)
                    {
                        if (Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Game.Player.Character, (InputArgument)"anim@amb@board_room@supervising@", (InputArgument)"dissaproval_01_lo_amy_skater_01", (InputArgument)3))
                        {
                            Game.Player.Character.Task.ClearAnimation("anim@amb@board_room@supervising@", "dissaproval_01_lo_amy_skater_01");
                            num3 = 9999999;
                            string str = num3.ToString() + "~g~~h~$~h~~w~";
                            if (Game.Player.Character.Model == (Model)PedHash.Michael || Game.Player.Character.Model == (Model)PedHash.Franklin || Game.Player.Character.Model == (Model)PedHash.Trevor)
                            {
                                num3 = Game.Player.Money;
                                str = num3.ToString() + " ~g~~h~$~h~~w~";
                            }
                            HTools.Main.Notify("Current balance: " + str, "Money in Wallet has been Counted", 0, (int)byte.MaxValue, 0, NotificationIcon.BankMaze);
                            Function.Call(Hash.PLAY_SOUND_FRONTEND, (InputArgument)(-1), (InputArgument)"LOCAL_PLYR_CASH_COUNTER_COMPLETE", (InputArgument)"DLC_HEISTS_GENERAL_FRONTEND_SOUNDS", (InputArgument)0);
                        }
                        if (!Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Game.Player.Character, (InputArgument)"mp_arrest_paired", (InputArgument)"cop_p1_rf_right_0", (InputArgument)3))
                        {
                            Function.Call(Hash.ATTACH_ENTITY_TO_ENTITY, (InputArgument)(Entity)Wallet.wallet, (InputArgument)(Entity)Game.Player.Character, (InputArgument)num6, (InputArgument)0.1, (InputArgument)0.015, (InputArgument)(-0.025), (InputArgument)115.0, (InputArgument)20.0, (InputArgument)0.0, (InputArgument)false, (InputArgument)false, (InputArgument)false, (InputArgument)false, (InputArgument)0, (InputArgument)true);
                            if ((Entity)Wallet.walletOpened != (Entity)null)
                                Wallet.walletOpened.IsVisible = false;
                            if ((Entity)Wallet.wallet != (Entity)null)
                                Wallet.wallet.IsVisible = true;
                            Function.Call(Hash.TASK_PLAY_ANIM, (InputArgument)(Entity)Game.Player.Character, (InputArgument)"mp_arrest_paired", (InputArgument)"cop_p1_rf_right_0", (InputArgument)4f, (InputArgument)(-4f), (InputArgument)(-1), (InputArgument)48, (InputArgument)0.0f, (InputArgument)0, (InputArgument)0, (InputArgument)0);
                            HTools.Main.soundFX(Game.Player.Character, "grab.wav", Common.assetFolder);
                            Script.Wait(700);
                            if (Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Game.Player.Character, (InputArgument)"mp_arrest_paired", (InputArgument)"cop_p1_rf_right_0", (InputArgument)3))
                                Game.Player.Character.Task.ClearAnimation("mp_arrest_paired", "cop_p1_rf_right_0");
                        }
                        if ((Entity)Wallet.wallet != (Entity)null && Wallet.wallet.Exists())
                        {
                            Wallet.wallet.Delete();
                            Wallet.wallet = (Prop)null;
                        }
                        else if (Function.Call<Prop>(Hash.GET_CLOSEST_OBJECT_OF_TYPE, (InputArgument)Game.Player.Character.Position.X, (InputArgument)Game.Player.Character.Position.Y, (InputArgument)Game.Player.Character.Position.Z, (InputArgument)3f, (InputArgument)HTools.Main.GetHashKey("prop_ld_wallet_02"), (InputArgument)true, (InputArgument)false, (InputArgument)false).Exists())
                        {
                            Prop prop = Function.Call<Prop>(Hash.GET_CLOSEST_OBJECT_OF_TYPE, (InputArgument)Game.Player.Character.Position.X, (InputArgument)Game.Player.Character.Position.Y, (InputArgument)Game.Player.Character.Position.Z, (InputArgument)3f, (InputArgument)HTools.Main.GetHashKey("prop_ld_wallet_02"), (InputArgument)true, (InputArgument)false, (InputArgument)false);
                            if ((Entity)prop != (Entity)Wallet.wallet && Function.Call<bool>(Hash.IS_ENTITY_ATTACHED_TO_ENTITY, (InputArgument)(Entity)prop, (InputArgument)(Entity)Game.Player.Character) && prop.Exists())
                                prop.Delete();
                        }
                        if ((Entity)Wallet.walletOpened != (Entity)null && Wallet.walletOpened.Exists())
                        {
                            Wallet.walletOpened.Delete();
                            Wallet.walletOpened = (Prop)null;
                        }
                        else if (Function.Call<Prop>(Hash.GET_CLOSEST_OBJECT_OF_TYPE, (InputArgument)Game.Player.Character.Position.X, (InputArgument)Game.Player.Character.Position.Y, (InputArgument)Game.Player.Character.Position.Z, (InputArgument)3f, (InputArgument)HTools.Main.GetHashKey("prop_ld_wallet_pickup"), (InputArgument)true, (InputArgument)false, (InputArgument)false).Exists())
                        {
                            Prop prop = Function.Call<Prop>(Hash.GET_CLOSEST_OBJECT_OF_TYPE, (InputArgument)Game.Player.Character.Position.X, (InputArgument)Game.Player.Character.Position.Y, (InputArgument)Game.Player.Character.Position.Z, (InputArgument)3f, (InputArgument)HTools.Main.GetHashKey("prop_ld_wallet_pickup"), (InputArgument)true, (InputArgument)false, (InputArgument)false);
                            if ((Entity)prop != (Entity)Wallet.wallet && Function.Call<bool>(Hash.IS_ENTITY_ATTACHED_TO_ENTITY, (InputArgument)(Entity)prop, (InputArgument)(Entity)Game.Player.Character) && prop.Exists())
                                prop.Delete();
                        }
                        Wallet.walletCount = false;
                        Wallet.inProcessWallet = false;
                    }
                }
            }
            if (CigsAndPills.play_swallow_pills_anim)
                CigsAndPills.SwallowPillsFunction(Game.Player.Character);
            if (CigsAndPills.blockKeys)
            {
                if (Game.Player.Character.Weapons.Current.Hash != WeaponHash.Unarmed)
                    Function.Call(Hash.SET_CURRENT_PED_WEAPON, (InputArgument)(Entity)Game.Player.Character, (InputArgument)2725352035U, (InputArgument)true);
                HTools.Main.DisableControlsFunc(false);
            }
            if ((Entity)CigsAndPills.cig != (Entity)null)
            {
                Vector3 vector3_2 = new Vector3(CigsAndPills.cig.FrontPosition.X, CigsAndPills.cig.FrontPosition.Y, CigsAndPills.cig.FrontPosition.Z);
                if (CigsAndPills.flame)
                {
                    if (CigsAndPills.sizzle <= 0)
                    {
                        num3 = --CigsAndPills.cig_durability;
                        CigsAndPills.sizzle = 200;
                        HTools.Main.soundFX(Game.Player.Character, "sizzle.wav", Common.assetFolder, 7f);
                        Function.Call(Hash.REQUEST_NAMED_PTFX_ASSET, (InputArgument)"scr_safehouse");
                        Function.Call(Hash.USE_PARTICLE_FX_ASSET, (InputArgument)"scr_safehouse");
                        Function.Call<int>(Hash.START_PARTICLE_FX_LOOPED_ON_ENTITY, (InputArgument)"scr_sh_lighter_flame", (InputArgument)(Entity)CigsAndPills.cig, (InputArgument)(-0.075f), (InputArgument)0.0f, (InputArgument)0.0f, (InputArgument)0, (InputArgument)0, (InputArgument)0, (InputArgument)0.2f, (InputArgument)false, (InputArgument)false, (InputArgument)false);
                    }
                    else
                        num3 = --CigsAndPills.sizzle;
                }
                else
                {
                    Function.Call(Hash.REMOVE_PARTICLE_FX_FROM_ENTITY, (InputArgument)(Entity)CigsAndPills.cig);
                    CigsAndPills.sizzle = Game.Player.Character.Gender == Gender.Male || Game.Player.Character.IsSittingInVehicle() ? 150 : 10;
                }
            }
            if (CigsAndPills.smoke == 1 && CigsAndPills.smoking && !Game.Player.Character.IsSittingInVehicle() && (!CigsAndPills.cigReady || CigsAndPills.cigReady && !CigsAndPills.readyToIgnite))
                HTools.Main.DisableControlsFunc(false);
            if (CigsAndPills.extraEffectsStat)
            {
                if (CigsAndPills.extraEffectsTimer > 0)
                {
                    num3 = --CigsAndPills.extraEffectsTimer;
                    if (CigsAndPills.extraEffects)
                    {
                        if (CigsAndPills.screenFX && !Screen.IsEffectActive(ScreenEffect.FocusIn))
                            Screen.StartEffect(ScreenEffect.FocusIn, 100);
                        if ((double)CigsAndPills.slowMoScale > 0.5)
                            CigsAndPills.slowMoScale -= 0.05f;
                        Game.TimeScale = CigsAndPills.slowMoScale;
                    }
                    if (Game.Player.Character.Health <= Game.Player.Character.MaxHealth)
                        num3 = ++Game.Player.Character.Health;
                    double num8 = (double)Function.Call<float>(Hash.SET_PED_MOVE_RATE_OVERRIDE, (InputArgument)(Entity)Game.Player.Character, (InputArgument)1.15f);
                }
                else
                {
                    double num9 = (double)Function.Call<float>(Hash.SET_PED_MOVE_RATE_OVERRIDE, (InputArgument)(Entity)Game.Player.Character, (InputArgument)1f);
                    if (Screen.IsEffectActive(ScreenEffect.FocusIn))
                        Screen.StopEffects();
                    if (CigsAndPills.screenFX && !Screen.IsEffectActive(ScreenEffect.FocusOut))
                    {
                        Function.Call(Hash.PLAY_SOUND_FRONTEND, (InputArgument)(-1), (InputArgument)"FocusOut", (InputArgument)"HintCamSounds");
                        Screen.StartEffect(ScreenEffect.FocusOut, 100);
                    }
                    if ((double)CigsAndPills.slowMoScale < 1.0)
                    {
                        CigsAndPills.slowMoScale += 0.1f;
                        Game.TimeScale = CigsAndPills.slowMoScale;
                    }
                    else
                    {
                        Common.followCamera = false;
                        if (Screen.IsEffectActive(ScreenEffect.FocusOut))
                            Screen.StopEffects();
                        CigsAndPills.extraEffectsStat = false;
                    }
                }
            }
            if (FocusMode.focusModeActive)
            {
                if (FocusMode.isFocused)
                {
                    Common.Draw(7);
                    HTools.Main.DisableControlsFunc(true);
                    if (!Game.Player.IsAiming)
                        Game.Player.ForcedAim = true;
                    Game.Player.IgnoredByEveryone = true;
                    Game.Player.DisableFiringThisFrame();
                    Function.Call(Hash.DISABLE_GAMEPLAY_CAM_ALTITUDE_FOV_SCALING_THIS_UPDATE);
                    Function.Call(Hash.SHOW_HUD_COMPONENT_THIS_FRAME, (InputArgument)14);
                    if (Function.Call<bool>(Hash.IS_DISABLED_CONTROL_JUST_PRESSED, (InputArgument)0, (InputArgument)25))
                    {
                        Function.Call(Hash.PLAY_SOUND_FRONTEND, (InputArgument)(-1), (InputArgument)"FocusIn", (InputArgument)"HintCamSounds");
                        FocusMode.focusTimer = 0;
                    }
                    if (Function.Call<bool>(Hash.IS_DISABLED_CONTROL_JUST_PRESSED, (InputArgument)0, (InputArgument)24))
                    {
                        if (Game.Player.Character.Weapons.Current.AmmoInClip > FocusMode.focusTargetedPeds.Length)
                        {
                            Vector3 source = Function.Call<Vector3>(Hash.GET_GAMEPLAY_CAM_COORD);
                            Vector3 vector3_3 = Function.Call<Vector3>(Hash.GET_GAMEPLAY_CAM_ROT);
                            float num10 = vector3_3.Z * ((float)System.Math.PI / 180f);
                            float num11 = vector3_3.X * ((float)System.Math.PI / 180f);
                            float num12 = (float)System.Math.Abs(System.Math.Cos((double)num11));
                            Ped _hitedPed = World.GetClosestPed(World.Raycast(source, source + new Vector3((float)(System.Math.Sin((double)num10) * (double)num12 * -1.0), (float)System.Math.Cos((double)num10) * num12, (float)System.Math.Sin((double)num11)) * 1000f, IntersectFlags.Peds).HitPosition, 1f);
                            if ((Entity)_hitedPed != (Entity)null && (Entity)_hitedPed != (Entity)Game.Player.Character && !Function.Call<bool>(Hash.IS_PED_IN_GROUP, (InputArgument)(Entity)_hitedPed, (InputArgument)Game.Player.Character.PedGroup))
                            {
                                if (!((IEnumerable<Ped>)FocusMode.focusTargetedPeds).Contains<Ped>(_hitedPed))
                                {
                                    Function.Call(Hash.PLAY_SOUND_FRONTEND, (InputArgument)(-1), (InputArgument)"FocusIn", (InputArgument)"HintCamSounds");
                                    FocusMode.focusTargetedPeds = ((IEnumerable<Ped>)FocusMode.focusTargetedPeds).Concat<Ped>((IEnumerable<Ped>)new Ped[1]
                                    {
                    _hitedPed
                                    }).ToArray<Ped>();
                                }
                                else
                                {
                                    FocusMode.focusTargetedPeds = ((IEnumerable<Ped>)FocusMode.focusTargetedPeds).Where<Ped>((Func<Ped, bool>)(val => (Entity)val != (Entity)_hitedPed)).ToArray<Ped>();
                                    Function.Call(Hash.PLAY_SOUND_FRONTEND, (InputArgument)(-1), (InputArgument)"FocusOut", (InputArgument)"HintCamSounds");
                                }
                            }
                        }
                        else
                            FocusMode.focusTimer = 0;
                    }
                    num3 = --FocusMode.focusTimer;
                    if ((double)Game.TimeScale > 0.001)
                        Game.TimeScale -= 0.05f;
                    if (FocusMode.focusTimer <= 0)
                    {
                        FocusMode.isFocused = false;
                        FocusMode.focusEffectsStoped = false;
                        FocusMode.targetsPicked = true;
                        FocusMode.targetCamSet = false;
                        FocusMode.focusButtonPressedCounter = 0;
                        FocusMode.focusTargetingTimer = 800;
                        if (Screen.IsEffectActive(ScreenEffect.FocusIn))
                            Screen.StopEffects();
                        Array.Reverse((Array)FocusMode.focusTargetedPeds);
                    }
                    if (FocusMode.focusTargetedPeds.Length != 0)
                    {
                        foreach (Ped focusTargetedPed in FocusMode.focusTargetedPeds)
                        {
                            Ped _target = focusTargetedPed;
                            if ((Entity)_target != (Entity)null)
                            {
                                vector3_1 = _target.Position;
                                float num13 = (float)(0.10000000149011612 * ((double)vector3_1.DistanceTo(Game.Player.Character.Position) / 10.0));
                                if ((double)num13 < 0.10000000149011612)
                                    num13 = 0.1f;
                                Vector3 dir = new Vector3(0.0f, 0.0f, 0.0f);
                                Vector3 rot = new Vector3(0.0f, GameplayCamera.Rotation.Y, 0.0f);
                                Vector3 scale = new Vector3(num13, num13, num13);
                                int num14 = Function.Call<int>(Hash.GET_PED_BONE_INDEX, (InputArgument)(Entity)_target, (InputArgument)31086);
                                Vector3 vector3_4 = Function.Call<Vector3>(Hash.GET_WORLD_POSITION_OF_ENTITY_BONE, (InputArgument)(Entity)_target, (InputArgument)num14);
                                World.DrawMarker(MarkerType.Chevron1, new Vector3(vector3_4.X, vector3_4.Y, vector3_4.Z + 0.5f), dir, rot, scale, Color.Red, faceCamera: true);
                            }
                            else
                                FocusMode.focusTargetedPeds = ((IEnumerable<Ped>)FocusMode.focusTargetedPeds).Where<Ped>((Func<Ped, bool>)(val => (Entity)val != (Entity)_target)).ToArray<Ped>();
                        }
                    }
                }
                if (!FocusMode.isFocused)
                {
                    if (Function.Call<bool>(Hash.IS_DISABLED_CONTROL_JUST_PRESSED, (InputArgument)0, (InputArgument)FocusMode.focus_mode_btn) && Game.Player.Character.IsOnFoot && Game.Player.CanControlCharacter)
                    {
                        if (((IEnumerable<WeaponGroup>)WeaponHolster._pistolWeaponGroup).Contains<WeaponGroup>(Game.Player.Character.Weapons.Current.Group) || ((IEnumerable<WeaponGroup>)WeaponHolster._bigWeaponGroups).Contains<WeaponGroup>(Game.Player.Character.Weapons.Current.Group))
                        {
                            if (Function.Call<bool>(Hash.IS_SPECIAL_ABILITY_ENABLED, (InputArgument)Game.Player))
                            {
                                GameplayCamera.Shake(CameraShake.Vibrate, 0.5f);
                                if (Function.Call<bool>(Hash.IS_SPECIAL_ABILITY_METER_FULL, (InputArgument)Game.Player))
                                {
                                    num3 = ++FocusMode.focusButtonPressedCounter;
                                    if (FocusMode.focusButtonPressedCounter == 2 && !Screen.IsEffectActive(ScreenEffect.DrugsDrivingIn))
                                        Screen.StartEffect(ScreenEffect.DrugsDrivingIn, 300);
                                    if (FocusMode.focusButtonPressedCounter == 5)
                                    {
                                        Game.Player.IgnoredByEveryone = true;
                                        Game.Player.IsInvincible = true;
                                        Function.Call(Hash.SET_PLAYER_ANGRY, (InputArgument)(Entity)Game.Player.Character, (InputArgument)true);
                                        Function.Call(Hash.PLAY_PED_AMBIENT_SPEECH_NATIVE, (InputArgument)(Entity)Game.Player.Character, (InputArgument)"DRAW_GUN", (InputArgument)"SPEECH_PARAMS_FORCE");
                                    }
                                }
                                else
                                {
                                    num3 = ++FocusMode.focusButtonPressedHintCounter;
                                    if (FocusMode.focusButtonPressedHintCounter == 2)
                                    {
                                        Function.Call(Hash.PLAY_SOUND_FRONTEND, (InputArgument)(-1), (InputArgument)"FocusIn", (InputArgument)"HintCamSounds");
                                        if (!Function.Call<bool>(Hash.IS_HELP_MESSAGE_BEING_DISPLAYED))
                                            Screen.ShowHelpText("~BLIP_INFO_ICON~ ~y~Special abilities~w~ meter is Not filled enough! Keep on pushing to refill it.", 10000);
                                    }
                                    Game.Player.ChargeSpecialAbility(0.03f);
                                }
                            }
                            else
                                num3 = ++FocusMode.focusButtonPressedCounter;
                        }
                        else if (!Function.Call<bool>(Hash.IS_HELP_MESSAGE_BEING_DISPLAYED))
                            Screen.ShowHelpText("~BLIP_INFO_ICON~ ~ц~You need to select any ~o~firearms~w~ (pistols,smgs,shotguns,assaultrifles,sniperrifles) to activate ~y~focus mode~w~", 5000);
                    }
                    if (FocusMode.focusButtonPressedCounter >= 5 && (!Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Game.Player.Character, (InputArgument)"anim@weapons@pistol@doubleaction_holster", (InputArgument)"holster", (InputArgument)3) || Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Game.Player.Character, (InputArgument)"anim@weapons@pistol@doubleaction_holster", (InputArgument)"holster", (InputArgument)3) && (double)Function.Call<float>(Hash.GET_ENTITY_ANIM_CURRENT_TIME, (InputArgument)(Entity)Game.Player.Character, (InputArgument)"anim@weapons@pistol@doubleaction_holster", (InputArgument)"holster") > 0.10000000149011612))
                    {
                        Game.Player.CanControlCharacter = true;
                        GameplayCamera.Shake(CameraShake.Vibrate, 0.5f);
                        Array.Clear((Array)FocusMode.focusTargetedPeds, 0, FocusMode.focusTargetedPeds.Length);
                        FocusMode.isFocused = true;
                        FocusMode.focusButtonPressedCounter = 0;
                        FocusMode.focusTimer = FocusMode.focusMaxTimer;
                        Function.Call(Hash.SET_AUDIO_FLAG, (InputArgument)"AllowAmbientSpeechInSlowMo", (InputArgument)true);
                        Function.Call(Hash.PLAY_SOUND_FRONTEND, (InputArgument)(-1), (InputArgument)"FocusIn", (InputArgument)"HintCamSounds");
                        if (!Screen.IsEffectActive(ScreenEffect.FocusIn))
                            Screen.StartEffect(ScreenEffect.FocusIn, 1000);
                        Game.Player.Character.Task.ClearAll();
                    }
                    if (!FocusMode.focusEffectsStoped)
                    {
                        if ((double)Game.TimeScale < 1.0)
                        {
                            Game.TimeScale += 0.1f;
                        }
                        else
                        {
                            double num15 = (double)Function.Call<float>(Hash.SET_PED_MOVE_RATE_OVERRIDE, (InputArgument)(Entity)Game.Player.Character, (InputArgument)1f);
                            FocusMode.focusEffectsStoped = true;
                            if (Game.Player.IsAiming)
                                Game.Player.ForcedAim = false;
                        }
                    }
                }
                if (FocusMode.targetsPicked)
                {
                    Function.Call(Hash.DISABLE_AIM_CAM_THIS_UPDATE);
                    Game.DisableAllControlsThisFrame();
                    Function.Call(Hash.FORCE_ALL_HEADING_VALUES_TO_ALIGN, (InputArgument)(Entity)Game.Player.Character);
                    Game.Player.DisableFiringThisFrame();
                    if (FocusMode.targetCam != (Camera)null && (Entity)FocusMode.focusTarget != (Entity)null && World.RenderingCamera == FocusMode.targetCam)
                    {
                        if (!FocusMode.targetCamSet)
                        {
                            FocusMode.targetCamSet = true;
                            FocusMode.rndTargetCamera = Common.rnd.Next(0, 0);
                            if (FocusMode.rndTargetCamera == 0)
                            {
                                FocusMode.targetCam.Position = new Vector3(Game.Player.Character.Position.X, Game.Player.Character.Position.Y, Game.Player.Character.Position.Z + 2.5f);
                                FocusMode.targetCam.Rotation = new Vector3(Game.Player.Character.Rotation.X, Game.Player.Character.Rotation.Y, Game.Player.Character.Rotation.Z);
                                FocusMode.targetCam.AttachTo((Entity)Game.Player.Character, new Vector3(0.7f, -0.95f, 0.7f));
                            }
                            else
                            {
                                FocusMode.targetCam.Position = new Vector3(Game.Player.Character.Position.X, Game.Player.Character.Position.Y, Game.Player.Character.Position.Z + 2.5f);
                                FocusMode.targetCam.Rotation = new Vector3(Game.Player.Character.Rotation.X, Game.Player.Character.Rotation.Y, Game.Player.Character.Rotation.Z + 180f);
                                FocusMode.targetCam.AttachTo((Entity)Game.Player.Character, new Vector3(0.3f, 2.95f, 0.5f));
                            }
                        }
                        if (FocusMode.rndTargetCamera == 0)
                        {
                            Camera targetCam = FocusMode.targetCam;
                            Ped focusTarget = FocusMode.focusTarget;
                            vector3_1 = new Vector3();
                            Vector3 offset = vector3_1;
                            targetCam.PointAt((Entity)focusTarget, offset);
                        }
                    }
                    if (FocusMode.focusTargetingTimer > 0)
                        num3 = --FocusMode.focusTargetingTimer;
                    if (FocusMode.focusEffectsStoped)
                    {
                        if (FocusMode.focusTargetedPeds.Length != 0 && Game.Player.Character.Weapons.Current.Ammo >= FocusMode.focusTargetedPeds.Length && FocusMode.focusTargetingTimer > 0)
                        {
                            if (FocusMode.focusUseCamera)
                            {
                                if (FocusMode.targetCam == (Camera)null && (GameplayCamera.IsRendering || World.RenderingCamera == ShoulderCameraSwitch.activeCam))
                                {
                                    FocusMode.targetCam = World.CreateCamera(GameplayCamera.Position, Vector3.Zero, GameplayCamera.FieldOfView);
                                    World.RenderingCamera = FocusMode.targetCam;
                                    FocusMode.targetCamSet = false;
                                }
                                else if (World.RenderingCamera != FocusMode.targetCam)
                                {
                                    FocusMode.targetCamSet = false;
                                    World.RenderingCamera = FocusMode.targetCam;
                                }
                            }
                            if ((Entity)FocusMode.focusTarget == (Entity)null)
                            {
                                if ((double)Game.TimeScale < 1.0)
                                {
                                    Game.TimeScale += 0.02f;
                                }
                                else
                                {
                                    foreach (Ped focusTargetedPed in FocusMode.focusTargetedPeds)
                                    {
                                        Ped _target = focusTargetedPed;
                                        if ((Entity)FocusMode.focusTarget == (Entity)null)
                                        {
                                            if ((Entity)_target == (Entity)null || (Entity)_target != (Entity)null && !_target.IsAlive)
                                            {
                                                if (((IEnumerable<Ped>)FocusMode.focusTargetedPeds).Contains<Ped>(_target))
                                                    FocusMode.focusTargetedPeds = ((IEnumerable<Ped>)FocusMode.focusTargetedPeds).Where<Ped>((Func<Ped, bool>)(val => (Entity)val != (Entity)_target)).ToArray<Ped>();
                                            }
                                            else
                                            {
                                                _target.ClearLastWeaponDamage();
                                                Game.Player.Character.Task.LookAt((Entity)_target);
                                                Function.Call(Hash.TASK_AIM_GUN_AT_COORD, (InputArgument)(Entity)Game.Player.Character, (InputArgument)FocusMode.shootingCoords.X, (InputArgument)FocusMode.shootingCoords.Y, (InputArgument)FocusMode.shootingCoords.Z, (InputArgument)(-1), (InputArgument)false, (InputArgument)false);
                                                FocusMode.targetCamSet = false;
                                                FocusMode.focusTargetAimingInProcess = false;
                                                FocusMode.focusPedfacingTime = 1;
                                                FocusMode.focusTargetFacing = false;
                                                FocusMode.shootingTarget = true;
                                                FocusMode.focusTarget = _target;
                                            }
                                        }
                                        else
                                            break;
                                    }
                                }
                            }
                            if ((Entity)FocusMode.focusTarget != (Entity)null)
                            {
                                if (FocusMode.shootingTarget && FocusMode.focusTargetFacing)
                                {
                                    if (!Game.Player.Character.IsShooting)
                                    {
                                        int num16 = Function.Call<int>(Hash.GET_PED_BONE_INDEX, (InputArgument)(Entity)FocusMode.focusTarget, (InputArgument)31086);
                                        Vector3 vector3_5 = Function.Call<Vector3>(Hash.GET_WORLD_POSITION_OF_ENTITY_BONE, (InputArgument)(Entity)FocusMode.focusTarget, (InputArgument)num16);
                                        FocusMode.shootingCoords = vector3_5;
                                        Function.Call(Hash.SET_PED_SHOOTS_AT_COORD, (InputArgument)(Entity)Game.Player.Character, (InputArgument)vector3_5.X, (InputArgument)vector3_5.Y, (InputArgument)vector3_5.Z, (InputArgument)false);
                                    }
                                    if (Game.Player.Character.IsShooting)
                                        FocusMode.shootingTarget = false;
                                }
                                if (!FocusMode.shootingTarget)
                                {
                                    if ((double)Game.TimeScale > 0.10000000149011612)
                                    {
                                        Game.TimeScale -= 0.02f;
                                        if (!FocusMode.focusTarget.IsOnScreen)
                                        {
                                            FocusMode.targetCam.AttachTo((Entity)FocusMode.focusTarget, new Vector3(0.2f, 1.5f, 3f));
                                            Camera targetCam = FocusMode.targetCam;
                                            Ped focusTarget = FocusMode.focusTarget;
                                            vector3_1 = new Vector3();
                                            Vector3 offset = vector3_1;
                                            targetCam.PointAt((Entity)focusTarget, offset);
                                        }
                                        Game.Player.Character.Task.ClearAll();
                                        Game.Player.Character.Task.AimAt(FocusMode.shootingCoords, -1);
                                    }
                                    else
                                    {
                                        Game.Player.Character.Task.ClearAll();
                                        Game.Player.Character.Task.AimAt(FocusMode.shootingCoords, -1);
                                        if (((IEnumerable<Ped>)FocusMode.focusTargetedPeds).Contains<Ped>(FocusMode.focusTarget))
                                            FocusMode.focusTargetedPeds = ((IEnumerable<Ped>)FocusMode.focusTargetedPeds).Where<Ped>((Func<Ped, bool>)(val => (Entity)val != (Entity)FocusMode.focusTarget)).ToArray<Ped>();
                                        FocusMode.focusTarget.DiesOnLowHealth = true;
                                        FocusMode.focusTarget.FatalInjuryHealthThreshold = 1f;
                                        FocusMode.focusTarget.HealthFloat = 0.5f;
                                        FocusMode.focusTarget.MarkAsNoLongerNeeded();
                                        FocusMode.focusTarget.ClearLastWeaponDamage();
                                        FocusMode.focusTarget = (Ped)null;
                                    }
                                }
                            }
                        }
                        else if ((double)Game.TimeScale < 1.0)
                        {
                            Game.TimeScale += 0.01f;
                        }
                        else
                        {
                            Function.Call(Hash.PLAY_SOUND_FRONTEND, (InputArgument)(-1), (InputArgument)"FocusOut", (InputArgument)"HintCamSounds");
                            double num17 = (double)Function.Call<float>(Hash.SET_PED_MOVE_RATE_OVERRIDE, (InputArgument)(Entity)Game.Player.Character, (InputArgument)1f);
                            Game.Player.IgnoredByEveryone = false;
                            Game.Player.IsInvincible = false;
                            Game.Player.Character.Task.ClearAll();
                            if (FocusMode.targetCam != (Camera)null)
                            {
                                World.RenderingCamera = (Camera)null;
                                FocusMode.targetCam.Delete();
                                FocusMode.targetCam = (Camera)null;
                            }
                            FocusMode.targetsPicked = false;
                            Game.Player.ForcedAim = false;
                            Function.Call(Hash.SPECIAL_ABILITY_DEPLETE_METER, (InputArgument)Game.Player, (InputArgument)true);
                        }
                    }
                }
                if (FocusMode.focusModeTimeRef < Game.GameTime)
                {
                    FocusMode.focusModeTimeRef = Game.GameTime + 1000;
                    if (!Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Game.Player.Character, (InputArgument)"melee@unarmed@streamed_taunts", (InputArgument)"damage_03", (InputArgument)3))
                    {
                        if (FocusMode.focusButtonPressedCounter > 0 && !Function.Call<bool>(Hash.IS_DISABLED_CONTROL_PRESSED, (InputArgument)0, (InputArgument)FocusMode.focus_mode_btn))
                        {
                            num3 = --FocusMode.focusButtonPressedCounter;
                            if (Screen.IsEffectActive(ScreenEffect.DrugsDrivingOut) && FocusMode.focusButtonPressedCounter == 1)
                                Screen.StopEffect(ScreenEffect.DrugsDrivingOut);
                        }
                        if (FocusMode.focusButtonPressedHintCounter > 0 && !Function.Call<bool>(Hash.IS_DISABLED_CONTROL_PRESSED, (InputArgument)0, (InputArgument)FocusMode.focus_mode_btn))
                            num3 = --FocusMode.focusButtonPressedHintCounter;
                    }
                    if (!FocusMode.focusTargetFacing && (Entity)FocusMode.focusTarget != (Entity)null && FocusMode.targetsPicked)
                    {
                        FocusMode.focusPedfacingTime = 1;
                        FocusMode.focusTargetAimingInProcess = true;
                        if (!Game.Player.Character.IsAiming)
                            Function.Call(Hash.TASK_AIM_GUN_AT_COORD, (InputArgument)(Entity)Game.Player.Character, (InputArgument)FocusMode.focusTarget.Position.X, (InputArgument)FocusMode.focusTarget.Position.Y, (InputArgument)FocusMode.focusTarget.Position.Z, (InputArgument)(-1), (InputArgument)false, (InputArgument)false);
                        if (FocusMode.focusTarget.IsInCover)
                            FocusMode.focusTarget.Task.GoTo(Game.Player.Character.FrontPosition, 5000);
                        num3 = --FocusMode.focusPedfacingTime;
                        if (FocusMode.focusPedfacingTime <= 0)
                            FocusMode.focusTargetFacing = true;
                    }
                }
            }
            if (WoundsSystem.woundsModuleActive && WoundsSystem.woundsTimer < Game.GameTime)
            {
                WoundsSystem.woundsTimer = Game.GameTime + 1000;
                if (!WoundsSystem.isWounded && Game.Player.Character.HasBeenDamagedByAnyWeapon())
                {
                    if (Common.rnd.Next(0, 5) == 0)
                    {
                        WoundsSystem.bleedTimer = Common.rnd.Next(30, 60);
                        Function.Call(Hash.CLEAR_PED_LAST_WEAPON_DAMAGE, (InputArgument)(Entity)Game.Player.Character);
                        WoundsSystem.isWounded = true;
                        Screen.ShowHelpText("~BLIIP_INFO_ICON~ You have been ~r~heavily wounded~w~.~n~ Use some painkillers to stop the pain!", 5000);
                    }
                    else
                        Function.Call(Hash.CLEAR_PED_LAST_WEAPON_DAMAGE, (InputArgument)(Entity)Game.Player.Character);
                }
                if (WoundsSystem.isWounded)
                {
                    if (WoundsSystem.bleedTimer <= 0 || (Entity)Game.Player.Character != (Entity)WoundsSystem.curWoundPlayer || Game.Player.Character.IsDead)
                    {
                        WoundsSystem.curWoundPlayer = Game.Player.Character;
                        HTools.Main.stopBleeding(Game.Player.Character);
                        Function.Call(Hash.CLEAR_PED_LAST_WEAPON_DAMAGE, (InputArgument)(Entity)Game.Player.Character);
                        WoundsSystem.isWounded = false;
                        Screen.ShowHelpText("~BLIIP_INFO_ICON~ The ~r~bleeding~w~ stopped", 5000);
                    }
                    else
                    {
                        num3 = --WoundsSystem.bleedTimer;
                        if ((Entity)WoundsSystem.curWoundPlayer == (Entity)Game.Player.Character)
                            HTools.Main.startBleeding(Game.Player.Character, true);
                    }
                }
            }
            if (WeaponSwing.swingGunAnim)
            {
                HTools.Main.DisableControlsFunc(true);
                if (!Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Game.Player.Character, (InputArgument)"anim@weapons@pistol@doubleaction_holster", (InputArgument)"holster", (InputArgument)3))
                    Game.Player.Character.Task.PlayAnimation("anim@weapons@pistol@doubleaction_holster", "holster", 4f, 1000, AnimationFlags.StayInEndFrame | AnimationFlags.UpperBodyOnly | AnimationFlags.Secondary);
                else if ((double)Function.Call<float>(Hash.GET_ENTITY_ANIM_CURRENT_TIME, (InputArgument)(Entity)Game.Player.Character, (InputArgument)"anim@weapons@pistol@doubleaction_holster", (InputArgument)"holster") > 0.40000000596046448)
                    WeaponSwing.swingGunAnim = false;
            }
            if ((WeaponHash)Game.Player.Character.Weapons.Current != WeaponHash.Unarmed)
            {
                Silencer.silencercheck();
                Scope.scopecheck();
                Flashlight.flashlightcheck();
                Grip.gripcheck();
                ExtendedMagazine.extendedmagazinecheck();
            }
            if (Common.AllWeaponsCount(Game.Player.Character) == 0)
                Common.RemoveAllAttachments();
            if (ExtendedMagazine.toggleExtendedMagazine)
            {
                HTools.Main.DisableControlsFunc(true);
                if (!Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Game.Player.Character, (InputArgument)"move_action@p_m_one@armed@2h_short@trans@a", (InputArgument)"idle2action", (InputArgument)3))
                {
                    if (!Game.Player.Character.IsInCover && Game.Player.Character.IsOnFoot && Game.Player.CanControlCharacter)
                    {
                        bool flag1 = false;
                        foreach ((WeaponHash weapon, WeaponComponentHash component) extendedmagazine in ExtendedMagazine.extendedmagazines)
                        {
                            if (Function.Call<bool>(Hash.DOES_WEAPON_TAKE_WEAPON_COMPONENT, (InputArgument)(Enum)Game.Player.Character.Weapons.Current.Hash, (InputArgument)(Enum)extendedmagazine.component))
                            {
                                flag1 = true;
                                break;
                            }
                        }
                        if (flag1)
                        {
                            if (ExtendedMagazine.HasPedBoughtExtendedMagazine(Game.Player.Character))
                            {
                                Game.Player.Character.Task.PlayAnimation("move_action@p_m_one@armed@2h_short@trans@a", "idle2action", 4f, -1, AnimationFlags.UpperBodyOnly | AnimationFlags.Secondary);
                                HTools.Main.soundFX(Game.Player.Character, "switchBtn.wav", Common.assetFolder, 13f);
                                bool flag2 = false;
                                foreach ((WeaponHash _, WeaponComponentHash component) in ExtendedMagazine.extendedmagazines)
                                {
                                    if (Function.Call<bool>(Hash.HAS_PED_GOT_WEAPON_COMPONENT, (InputArgument)(Entity)Game.Player.Character, (InputArgument)(Enum)Game.Player.Character.Weapons.Current.Hash, (InputArgument)(Enum)component))
                                    {
                                        flag2 = true;
                                        Function.Call(Hash.REMOVE_WEAPON_COMPONENT_FROM_PED, (InputArgument)(Entity)Game.Player.Character, (InputArgument)(Enum)Game.Player.Character.Weapons.Current.Hash, (InputArgument)(Enum)component);
                                        break;
                                    }
                                }
                                if (!flag2)
                                {
                                    foreach ((WeaponHash _, WeaponComponentHash component) in ExtendedMagazine.extendedmagazines)
                                    {
                                        if (Function.Call<bool>(Hash.DOES_WEAPON_TAKE_WEAPON_COMPONENT, (InputArgument)(Enum)Game.Player.Character.Weapons.Current.Hash, (InputArgument)(Enum)component))
                                        {
                                            Function.Call(Hash.GIVE_WEAPON_COMPONENT_TO_PED, (InputArgument)(Entity)Game.Player.Character, (InputArgument)(Enum)Game.Player.Character.Weapons.Current.Hash, (InputArgument)(Enum)component);
                                            break;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                Screen.ShowHelpText("~BLIP_INFO_ICON~ ~r~Extended Magazine~w~ hasn't been ~r~purchased", 5000);
                                ExtendedMagazine.toggleExtendedMagazine = false;
                            }
                        }
                        else
                        {
                            Screen.ShowHelpText("~BLIP_INFO_ICON~ ~r~Extended Magazine can't be attached to this weapon", 5000);
                            ExtendedMagazine.toggleExtendedMagazine = false;
                        }
                    }
                    else
                        ExtendedMagazine.toggleExtendedMagazine = false;
                }
                else if ((double)Function.Call<float>(Hash.GET_ENTITY_ANIM_CURRENT_TIME, (InputArgument)(Entity)Game.Player.Character, (InputArgument)"move_action@p_m_one@armed@2h_short@trans@a", (InputArgument)"idle2action") >= 0.949999988079071)
                {
                    HTools.Main.soundFX(Game.Player.Character, "switchBtn.wav", Common.assetFolder, 13f);
                    ExtendedMagazine.toggleExtendedMagazine = false;
                }
            }
            if (Scope.toggleScope)
            {
                HTools.Main.DisableControlsFunc(true);
                if (!Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Game.Player.Character, (InputArgument)"move_action@p_m_one@armed@2h_short@trans@a", (InputArgument)"idle2action", (InputArgument)3))
                {
                    if (!Game.Player.Character.IsInCover && Game.Player.Character.IsOnFoot && Game.Player.CanControlCharacter)
                    {
                        bool flag3 = false;
                        foreach (int scope in Scope.scopes)
                        {
                            if (Function.Call<bool>(Hash.DOES_WEAPON_TAKE_WEAPON_COMPONENT, (InputArgument)(Enum)Game.Player.Character.Weapons.Current.Hash, (InputArgument)(Enum)(WeaponComponentHash)scope))
                            {
                                flag3 = true;
                                break;
                            }
                        }
                        if (flag3)
                        {
                            if (Scope.HasPedBoughtScope(Game.Player.Character))
                            {
                                Game.Player.Character.Task.PlayAnimation("move_action@p_m_one@armed@2h_short@trans@a", "idle2action", 4f, -1, AnimationFlags.UpperBodyOnly | AnimationFlags.Secondary);
                                HTools.Main.soundFX(Game.Player.Character, "switchBtn.wav", Common.assetFolder, 13f);
                                bool flag4 = false;
                                foreach (WeaponComponentHash scope in Scope.scopes)
                                {
                                    if (Function.Call<bool>(Hash.HAS_PED_GOT_WEAPON_COMPONENT, (InputArgument)(Entity)Game.Player.Character, (InputArgument)(Enum)Game.Player.Character.Weapons.Current.Hash, (InputArgument)(Enum)scope))
                                    {
                                        flag4 = true;
                                        Function.Call(Hash.REMOVE_WEAPON_COMPONENT_FROM_PED, (InputArgument)(Entity)Game.Player.Character, (InputArgument)(Enum)Game.Player.Character.Weapons.Current.Hash, (InputArgument)(Enum)scope);
                                        break;
                                    }
                                }
                                if (!flag4)
                                {
                                    foreach (WeaponComponentHash scope in Scope.scopes)
                                    {
                                        if (Function.Call<bool>(Hash.DOES_WEAPON_TAKE_WEAPON_COMPONENT, (InputArgument)(Enum)Game.Player.Character.Weapons.Current.Hash, (InputArgument)(Enum)scope))
                                        {
                                            Function.Call(Hash.GIVE_WEAPON_COMPONENT_TO_PED, (InputArgument)(Entity)Game.Player.Character, (InputArgument)(Enum)Game.Player.Character.Weapons.Current.Hash, (InputArgument)(Enum)scope);
                                            break;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                Screen.ShowHelpText("~BLIP_INFO_ICON~ ~r~Scope~w~ hasn't been ~r~purchased", 5000);
                                Scope.toggleScope = false;
                            }
                        }
                        else
                        {
                            Screen.ShowHelpText("~BLIP_INFO_ICON~ ~r~Scope can't be attached to this weapon", 5000);
                            Scope.toggleScope = false;
                        }
                    }
                    else
                        Scope.toggleScope = false;
                }
                else if ((double)Function.Call<float>(Hash.GET_ENTITY_ANIM_CURRENT_TIME, (InputArgument)(Entity)Game.Player.Character, (InputArgument)"move_action@p_m_one@armed@2h_short@trans@a", (InputArgument)"idle2action") >= 0.949999988079071)
                {
                    HTools.Main.soundFX(Game.Player.Character, "switchBtn.wav", Common.assetFolder, 13f);
                    Scope.toggleScope = false;
                }
            }
            if (Flashlight.toggleFlashlight)
            {
                HTools.Main.DisableControlsFunc(true);
                if (!Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Game.Player.Character, (InputArgument)"move_action@p_m_one@armed@2h_short@trans@a", (InputArgument)"idle2action", (InputArgument)3))
                {
                    if (!Game.Player.Character.IsInCover && Game.Player.Character.IsOnFoot && Game.Player.CanControlCharacter)
                    {
                        bool flag5 = false;
                        foreach (int flashlight in Flashlight.flashlights)
                        {
                            if (Function.Call<bool>(Hash.DOES_WEAPON_TAKE_WEAPON_COMPONENT, (InputArgument)(Enum)Game.Player.Character.Weapons.Current.Hash, (InputArgument)(Enum)(WeaponComponentHash)flashlight))
                            {
                                flag5 = true;
                                break;
                            }
                        }
                        if (flag5)
                        {
                            if (Flashlight.HasPedBoughtFlashlight(Game.Player.Character))
                            {
                                Game.Player.Character.Task.PlayAnimation("move_action@p_m_one@armed@2h_short@trans@a", "idle2action", 4f, -1, AnimationFlags.UpperBodyOnly | AnimationFlags.Secondary);
                                HTools.Main.soundFX(Game.Player.Character, "switchBtn.wav", Common.assetFolder, 13f);
                                bool flag6 = false;
                                foreach (WeaponComponentHash flashlight in Flashlight.flashlights)
                                {
                                    if (Function.Call<bool>(Hash.HAS_PED_GOT_WEAPON_COMPONENT, (InputArgument)(Entity)Game.Player.Character, (InputArgument)(Enum)Game.Player.Character.Weapons.Current.Hash, (InputArgument)(Enum)flashlight))
                                    {
                                        flag6 = true;
                                        Function.Call(Hash.REMOVE_WEAPON_COMPONENT_FROM_PED, (InputArgument)(Entity)Game.Player.Character, (InputArgument)(Enum)Game.Player.Character.Weapons.Current.Hash, (InputArgument)(Enum)flashlight);
                                        break;
                                    }
                                }
                                if (!flag6)
                                {
                                    foreach (WeaponComponentHash flashlight in Flashlight.flashlights)
                                    {
                                        if (Function.Call<bool>(Hash.DOES_WEAPON_TAKE_WEAPON_COMPONENT, (InputArgument)(Enum)Game.Player.Character.Weapons.Current.Hash, (InputArgument)(Enum)flashlight))
                                        {
                                            Function.Call(Hash.GIVE_WEAPON_COMPONENT_TO_PED, (InputArgument)(Entity)Game.Player.Character, (InputArgument)(Enum)Game.Player.Character.Weapons.Current.Hash, (InputArgument)(Enum)flashlight);
                                            break;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                Screen.ShowHelpText("~BLIP_INFO_ICON~ ~r~Flashlight~w~ hasn't been ~r~purchased", 5000);
                                Flashlight.toggleFlashlight = false;
                            }
                        }
                        else
                        {
                            Screen.ShowHelpText("~BLIP_INFO_ICON~ ~r~Flashlight can't be attached to this weapon", 5000);
                            Flashlight.toggleFlashlight = false;
                        }
                    }
                    else
                        Flashlight.toggleFlashlight = false;
                }
                else if ((double)Function.Call<float>(Hash.GET_ENTITY_ANIM_CURRENT_TIME, (InputArgument)(Entity)Game.Player.Character, (InputArgument)"move_action@p_m_one@armed@2h_short@trans@a", (InputArgument)"idle2action") >= 0.949999988079071)
                {
                    HTools.Main.soundFX(Game.Player.Character, "switchBtn.wav", Common.assetFolder, 13f);
                    Flashlight.toggleFlashlight = false;
                }
            }
            if (Grip.toggleGrip)
            {
                HTools.Main.DisableControlsFunc(true);
                if (!Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Game.Player.Character, (InputArgument)"move_action@p_m_one@armed@2h_short@trans@a", (InputArgument)"idle2action", (InputArgument)3))
                {
                    if (!Game.Player.Character.IsInCover && Game.Player.Character.IsOnFoot && Game.Player.CanControlCharacter)
                    {
                        bool flag7 = false;
                        foreach (int grip in Grip.grips)
                        {
                            if (Function.Call<bool>(Hash.DOES_WEAPON_TAKE_WEAPON_COMPONENT, (InputArgument)(Enum)Game.Player.Character.Weapons.Current.Hash, (InputArgument)(Enum)(WeaponComponentHash)grip))
                            {
                                flag7 = true;
                                break;
                            }
                        }
                        if (flag7)
                        {
                            if (Grip.HasPedBoughtGrip(Game.Player.Character))
                            {
                                Game.Player.Character.Task.PlayAnimation("move_action@p_m_one@armed@2h_short@trans@a", "idle2action", 4f, -1, AnimationFlags.UpperBodyOnly | AnimationFlags.Secondary);
                                HTools.Main.soundFX(Game.Player.Character, "switchBtn.wav", Common.assetFolder, 13f);
                                bool flag8 = false;
                                foreach (WeaponComponentHash grip in Grip.grips)
                                {
                                    if (Function.Call<bool>(Hash.HAS_PED_GOT_WEAPON_COMPONENT, (InputArgument)(Entity)Game.Player.Character, (InputArgument)(Enum)Game.Player.Character.Weapons.Current.Hash, (InputArgument)(Enum)grip))
                                    {
                                        flag8 = true;
                                        Function.Call(Hash.REMOVE_WEAPON_COMPONENT_FROM_PED, (InputArgument)(Entity)Game.Player.Character, (InputArgument)(Enum)Game.Player.Character.Weapons.Current.Hash, (InputArgument)(Enum)grip);
                                        break;
                                    }
                                }
                                if (!flag8)
                                {
                                    foreach (WeaponComponentHash grip in Grip.grips)
                                    {
                                        if (Function.Call<bool>(Hash.DOES_WEAPON_TAKE_WEAPON_COMPONENT, (InputArgument)(Enum)Game.Player.Character.Weapons.Current.Hash, (InputArgument)(Enum)grip))
                                        {
                                            Function.Call(Hash.GIVE_WEAPON_COMPONENT_TO_PED, (InputArgument)(Entity)Game.Player.Character, (InputArgument)(Enum)Game.Player.Character.Weapons.Current.Hash, (InputArgument)(Enum)grip);
                                            break;
                                        }
                                    }
                                    return;
                                }
                            }
                            else
                            {
                                Screen.ShowHelpText("~BLIP_INFO_ICON~ ~r~Grip~w~ hasn't been ~r~purchased", 5000);
                                Grip.toggleGrip = false;
                            }
                        }
                        else
                        {
                            Screen.ShowHelpText("~BLIP_INFO_ICON~ ~r~Grip can't be attached to this weapon", 5000);
                            Grip.toggleGrip = false;
                        }
                    }
                    else
                        Grip.toggleGrip = false;
                }
                else if ((double)Function.Call<float>(Hash.GET_ENTITY_ANIM_CURRENT_TIME, (InputArgument)(Entity)Game.Player.Character, (InputArgument)"move_action@p_m_one@armed@2h_short@trans@a", (InputArgument)"idle2action") >= 0.949999988079071)
                {
                    HTools.Main.soundFX(Game.Player.Character, "switchBtn.wav", Common.assetFolder, 13f);
                    Grip.toggleGrip = false;
                }
            }
            if (Silencer.toggleSilencer)
            {
                HTools.Main.DisableControlsFunc(true);
                if (!Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Game.Player.Character, (InputArgument)"move_action@p_m_one@armed@2h_short@trans@a", (InputArgument)"idle2action", (InputArgument)3))
                {
                    if (!Game.Player.Character.IsInCover && Game.Player.Character.IsOnFoot && Game.Player.CanControlCharacter)
                    {
                        bool flag9 = false;
                        foreach (int silencer in Silencer.silencers)
                        {
                            if (Function.Call<bool>(Hash.DOES_WEAPON_TAKE_WEAPON_COMPONENT, (InputArgument)(Enum)Game.Player.Character.Weapons.Current.Hash, (InputArgument)(Enum)(WeaponComponentHash)silencer))
                            {
                                flag9 = true;
                                break;
                            }
                        }
                        if (flag9)
                        {
                            if (Silencer.HasPedBoughtSilencer(Game.Player.Character))
                            {
                                Game.Player.Character.Task.PlayAnimation("move_action@p_m_one@armed@2h_short@trans@a", "idle2action", 4f, -1, AnimationFlags.UpperBodyOnly | AnimationFlags.Secondary);
                                HTools.Main.soundFX(Game.Player.Character, "switchBtn.wav", Common.assetFolder, 13f);
                                bool flag10 = false;
                                foreach (WeaponComponentHash silencer in Silencer.silencers)
                                {
                                    if (Function.Call<bool>(Hash.HAS_PED_GOT_WEAPON_COMPONENT, (InputArgument)(Entity)Game.Player.Character, (InputArgument)(Enum)Game.Player.Character.Weapons.Current.Hash, (InputArgument)(Enum)silencer))
                                    {
                                        flag10 = true;
                                        Function.Call(Hash.REMOVE_WEAPON_COMPONENT_FROM_PED, (InputArgument)(Entity)Game.Player.Character, (InputArgument)(Enum)Game.Player.Character.Weapons.Current.Hash, (InputArgument)(Enum)silencer);
                                        break;
                                    }
                                }
                                if (!flag10)
                                {
                                    foreach (WeaponComponentHash silencer in Silencer.silencers)
                                    {
                                        if (Function.Call<bool>(Hash.DOES_WEAPON_TAKE_WEAPON_COMPONENT, (InputArgument)(Enum)Game.Player.Character.Weapons.Current.Hash, (InputArgument)(Enum)silencer))
                                        {
                                            Function.Call(Hash.GIVE_WEAPON_COMPONENT_TO_PED, (InputArgument)(Entity)Game.Player.Character, (InputArgument)(Enum)Game.Player.Character.Weapons.Current.Hash, (InputArgument)(Enum)silencer);
                                            break;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                Screen.ShowHelpText("~BLIP_INFO_ICON~ ~r~Silencer~w~ hasn't been ~r~purchased", 5000);
                                Silencer.toggleSilencer = false;
                            }
                        }
                        else
                        {
                            Screen.ShowHelpText("~BLIP_INFO_ICON~ ~r~Silencer can't be attached to this weapon", 5000);
                            Silencer.toggleSilencer = false;
                        }
                    }
                    else
                        Silencer.toggleSilencer = false;
                }
                else if ((double)Function.Call<float>(Hash.GET_ENTITY_ANIM_CURRENT_TIME, (InputArgument)(Entity)Game.Player.Character, (InputArgument)"move_action@p_m_one@armed@2h_short@trans@a", (InputArgument)"idle2action") >= 0.949999988079071)
                {
                    HTools.Main.soundFX(Game.Player.Character, "switchBtn.wav", Common.assetFolder, 13f);
                    Silencer.toggleSilencer = false;
                }
            }
            if (Game.Player.Character.IsOnFoot && Game.Player.Character.IsAiming && !FocusMode.isFocused && Game.Player.CanControlCharacter && !Silencer.toggleSilencer)
            {
                if (!WeaponJamming.jammingModeIsActive && (ShoulderCameraSwitch.ShoulderCameraModuleActive || LaserSight.laserSightModeActive || WeaponSwing.swingGunModuleActive || Silencer.silencerModeActive || AimingStyle.aimingStyleModeActive))
                {
                    WeaponSwing.canSwingGun = ((IEnumerable<WeaponGroup>)WeaponHolster._pistolWeaponGroup).Contains<WeaponGroup>(Game.Player.Character.Weapons.Current.Group) || ((IEnumerable<WeaponGroup>)WeaponHolster._bigWeaponGroups).Contains<WeaponGroup>(Game.Player.Character.Weapons.Current.Group);
                    AimingStyle.canSwitchAimingStyle = (WeaponHash)Game.Player.Character.Weapons.Current == WeaponHash.Pistol;
                    LaserSight.canUseLaserSight = true;
                    Common.Draw(0, action_page: Common.cur_action_page, cameraModuleParam: ShoulderCameraSwitch.ShoulderCameraModuleActive, swingWeaponModuleParam: WeaponSwing.swingGunModuleActive, laserSightModuleParam: LaserSight.laserSightModeActive, canSwingWeaponParam: WeaponSwing.canSwingGun, canUseLaserSightParam: LaserSight.canUseLaserSight, weaponJamningModuleParam: WeaponJamming.jammingModeIsActive, silencerModeActiveParam: Silencer.silencerModeActive, aimingStyleModeActiveParam: AimingStyle.aimingStyleModeActive, canSwitchAimingStyleParam: AimingStyle.canSwitchAimingStyle);
                }
                if (Function.Call<bool>(Hash.IS_DISABLED_CONTROL_JUST_PRESSED, (InputArgument)0, (InputArgument)AimingStyle.aiming_style_btn))
                {
                    Function.Call(Hash.PLAY_SOUND_FRONTEND, (InputArgument)(-1), (InputArgument)"FocusIn", (InputArgument)"HintCamSounds");
                    if (AimingStyle.aiming_style_indx < AimingStyle.aiming_style_indx_max)
                        num3 = ++AimingStyle.aiming_style_indx;
                    else
                        AimingStyle.aiming_style_indx = 0;
                    switch (AimingStyle.aiming_style_indx)
                    {
                        case 0:
                            Function.Call(Hash.SET_PLAYER_FORCE_SKIP_AIM_INTRO, (InputArgument)Game.Player, (InputArgument)false);
                            Function.Call(Hash.SET_WEAPON_ANIMATION_OVERRIDE, (InputArgument)(Entity)Game.Player.Character, (InputArgument)HTools.Main.GetHashKey("Default"));
                            break;
                        case 1:
                            Function.Call(Hash.SET_PLAYER_FORCE_SKIP_AIM_INTRO, (InputArgument)Game.Player, (InputArgument)true);
                            Function.Call(Hash.SET_WEAPON_ANIMATION_OVERRIDE, (InputArgument)(Entity)Game.Player.Character, (InputArgument)HTools.Main.GetHashKey("Hillbilly"));
                            break;
                        case 2:
                            Function.Call(Hash.SET_PLAYER_FORCE_SKIP_AIM_INTRO, (InputArgument)Game.Player, (InputArgument)true);
                            Function.Call(Hash.SET_WEAPON_ANIMATION_OVERRIDE, (InputArgument)(Entity)Game.Player.Character, (InputArgument)HTools.Main.GetHashKey("Gang1H"));
                            break;
                    }
                }
                if (Function.Call<bool>(Hash.IS_DISABLED_CONTROL_JUST_PRESSED, (InputArgument)0, (InputArgument)Silencer.silencer_toggle_btn) && !Game.IsControlPressed(Control.Sprint))
                {
                    Silencer.toggleSilencer = true;
                    HTools.Main.soundFX(Game.Player.Character, "switchBtn.wav", Common.assetFolder, 13f);
                }
                if (WeaponSwing.swingGunModuleActive)
                {
                    Game.DisableControlThisFrame((Control)WeaponSwing.swing_gun_btn);
                    if (Function.Call<bool>(Hash.IS_DISABLED_CONTROL_JUST_PRESSED, (InputArgument)0, (InputArgument)(Enum)(Control)WeaponSwing.swing_gun_btn) && (((IEnumerable<WeaponGroup>)WeaponHolster._pistolWeaponGroup).Contains<WeaponGroup>(Game.Player.Character.Weapons.Current.Group) || ((IEnumerable<WeaponGroup>)WeaponHolster._bigWeaponGroups).Contains<WeaponGroup>(Game.Player.Character.Weapons.Current.Group)) && Game.Player.CanControlCharacter && !Common.inMainMenu && !WeaponJamming.isCleaningJammedGun && !WeaponJamming.isFixingJammedGun && !WeaponJamming.isCheckingWeaponCondition && Game.Player.Character.IsOnFoot)
                    {
                        WeaponSwing.swingGunBtnCounter = 0;
                        WeaponSwing.swingGunAnim = true;
                    }
                }
                if (ShoulderCameraSwitch.ShoulderCameraModuleActive)
                {
                    if (ShoulderCameraSwitch.ShoulderCameraActive)
                    {
                        if (!Game.Player.Character.IsInCover)
                        {
                            if (ShoulderCameraSwitch.activeCam == (Camera)null)
                            {
                                ShoulderCameraSwitch.targetOffset = -0.7f;
                                ShoulderCameraSwitch.TransitionCamera(Game.Player.Character);
                            }
                            else if (Game.IsControlPressed(Control.Sprint))
                            {
                                ShoulderCameraSwitch.targetOffset = -0.7f;
                                ShoulderCameraSwitch.TransitionCamera(Game.Player.Character);
                                if (Game.IsControlPressed(Control.Cover) && !Game.Player.Character.IsAnimPlay("weapons@misc@digi_scanner", "walk_additive_left"))
                                    Game.Player.Character.Task.PlayAnimation("weapons@misc@digi_scanner", "walk_additive_left", 8f, -8f, -1, AnimationFlags.StayInEndFrame | AnimationFlags.Secondary | AnimationFlags.Additive, 0.0f);
                                else if (Game.IsControlPressed(Control.Talk) && !Game.Player.Character.IsAnimPlay("weapons@misc@digi_scanner", "walk_additive_right"))
                                    Game.Player.Character.Task.PlayAnimation("weapons@misc@digi_scanner", "walk_additive_right", 8f, -8f, -1, AnimationFlags.StayInEndFrame | AnimationFlags.Secondary | AnimationFlags.Additive, 0.0f);
                                else if (Game.IsControlJustReleased(Control.Cover) || Game.IsControlJustReleased(Control.Talk))
                                    Game.Player.Character.Task.ClearSecondary();
                            }
                            else
                            {
                                ShoulderCameraSwitch.targetOffset = -0.7f;
                                ShoulderCameraSwitch.TransitionCamera(Game.Player.Character);
                            }
                            Function.Call(Hash.DISABLE_GAMEPLAY_CAM_ALTITUDE_FOV_SCALING_THIS_UPDATE);
                            Function.Call(Hash.SHOW_HUD_COMPONENT_THIS_FRAME, (InputArgument)14);
                        }
                        else
                        {
                            ShoulderCameraSwitch.ShoulderCameraActive = false;
                            ShoulderCameraSwitch.targetOffset = 0.0f;
                            ShoulderCameraSwitch.TransitionCamera(Game.Player.Character);
                        }
                    }
                    else if (!ShoulderCameraSwitch.ShoulderCameraActive)
                    {
                        if (PeekingMod.Main.PeekingPosition == 1 || PeekingMod.Main.PeekingPosition == 2)
                            return;
                        ShoulderCameraSwitch.targetOffset = 0.0f;
                        ShoulderCameraSwitch.TransitionCamera(Game.Player.Character);
                    }
                    Game.DisableControlThisFrame((Control)ShoulderCameraSwitch.switch_shoulder_camera_btn);
                    Function.Call(Hash.DISABLE_CONTROL_ACTION, (InputArgument)2, (InputArgument)LaserSight.laser_sight_toggle_btn, (InputArgument)true);
                }
                if (LaserSight.laserSightModeActive)
                {
                    if (LaserSight.laserSightMode && !FocusMode.targetsPicked)
                    {
                        if ((WeaponHash)Game.Player.Character.Weapons.Current != LaserSight.laseredWeapon)
                            LaserSight.laserSightMode = false;
                        if (LaserSight.laserSightActivationTimer <= 0)
                        {
                            Prop currentWeaponObject = Game.Player.Character.Weapons.CurrentWeaponObject;
                            model = currentWeaponObject.Model;
                            Vector3 frontTopRight = model.Dimensions.frontTopRight;
                            float num18 = -0.03f;
                            if (((IEnumerable<WeaponGroup>)WeaponHolster._bigWeaponGroups).Contains<WeaponGroup>(Game.Player.Character.Weapons.Current.Group))
                                num18 = -0.06f;
                            Vector3 offsetPosition1 = currentWeaponObject.GetOffsetPosition(new Vector3(frontTopRight.X, frontTopRight.Y + num18, frontTopRight.Z - 0.03f));
                            Vector3 offsetPosition2 = currentWeaponObject.GetOffsetPosition(new Vector3(frontTopRight.X + 2.5f, frontTopRight.Y, frontTopRight.Z));
                            Function.Call(Hash.DRAW_LINE, (InputArgument)offsetPosition1.X, (InputArgument)offsetPosition1.Y, (InputArgument)offsetPosition1.Z, (InputArgument)offsetPosition2.X, (InputArgument)offsetPosition2.Y, (InputArgument)offsetPosition2.Z, (InputArgument)LaserSight.LSredColor, (InputArgument)LaserSight.LSgreenColor, (InputArgument)LaserSight.LSblueColor, (InputArgument)100);
                        }
                        else
                            num3 = --LaserSight.laserSightActivationTimer;
                    }
                    if (Function.Call<bool>(Hash.IS_DISABLED_CONTROL_JUST_PRESSED, (InputArgument)0, (InputArgument)LaserSight.laser_sight_toggle_btn))
                    {
                        bool flag = false;
                        foreach (int flashlight in LaserSight.flashlights)
                        {
                            if (Function.Call<bool>(Hash.HAS_PED_GOT_WEAPON_COMPONENT, (InputArgument)(Entity)Game.Player.Character, (InputArgument)(Enum)Game.Player.Character.Weapons.Current.Hash, (InputArgument)(Enum)(WeaponComponentHash)flashlight))
                            {
                                flag = true;
                                break;
                            }
                        }
                        if (flag)
                        {
                            LaserSight.laseredWeapon = (WeaponHash)Game.Player.Character.Weapons.Current;
                            HTools.Main.soundFX(Game.Player.Character, "switchBtn.wav", Common.assetFolder, 13f);
                            Game.Player.Character.Task.PlayAnimation("weapons@first_person@aim_idle@generic@melee@unarmed@", "aim_med_loop", 4f, -1, AnimationFlags.UpperBodyOnly | AnimationFlags.Secondary);
                            LaserSight.laserSightMode = !LaserSight.laserSightMode;
                            LaserSight.laserSightActivationTimer = 20;
                        }
                        else
                            Screen.ShowHelpText("~BLIP_INFO_ICON~ You need to set ~y~flashlight~w~ component to use a ~r~laser-sight~w~ with this weapon", 6000);
                    }
                }
                if (ShoulderCameraSwitch.ShoulderCameraModuleActive && Function.Call<bool>(Hash.IS_DISABLED_CONTROL_JUST_PRESSED, (InputArgument)0, (InputArgument)ShoulderCameraSwitch.switch_shoulder_camera_btn) && !Game.Player.Character.IsInCover && GameplayCamera.GetCamViewModeForContext(CamViewModeContext.OnFoot) != CamViewMode.FirstPerson)
                {
                    if (!ShoulderCameraSwitch.ShoulderCameraActive)
                    {
                        ShoulderCameraSwitch.ShoulderCameraActive = true;
                    }
                    else
                    {
                        if (ShoulderCameraSwitch.activeCam != (Camera)null && World.RenderingCamera == ShoulderCameraSwitch.activeCam)
                        {
                            ShoulderCameraSwitch.targetOffset = 0.0f;
                            ShoulderCameraSwitch.TransitionCamera(Game.Player.Character);
                        }
                        ShoulderCameraSwitch.ShoulderCameraActive = false;
                    }
                    Function.Call(Hash.PLAY_SOUND_FRONTEND, (InputArgument)(-1), (InputArgument)"FocusIn", (InputArgument)"HintCamSounds");
                }
            }
            else
            {
                LaserSight.laserSightActivationTimer = 20;
                if (ShoulderCameraSwitch.ShoulderCameraModuleActive && ShoulderCameraSwitch.activeCam != (Camera)null && World.RenderingCamera == ShoulderCameraSwitch.activeCam)
                {
                    ShoulderCameraSwitch.targetOffset = 0.0f;
                    ShoulderCameraSwitch.TransitionCamera(Game.Player.Character);
                    ShoulderCameraSwitch.ShoulderCameraActive = false;
                }
            }
            if (WeaponJamming.jammingModeIsActive)
            {
                if (WeaponJamming.weaponIsJammed && Game.Player.Character.Weapons.Current != WeaponHash.Unarmed)
                {
                    Game.DisableControlThisFrame(Control.Attack);
                    Game.DisableControlThisFrame(Control.Attack2);
                    if (Function.Call<bool>(Hash.IS_DISABLED_CONTROL_JUST_PRESSED, (InputArgument)0, (InputArgument)24))
                    {
                        WeaponJamming.jammCounter = Common.rnd.Next(1, 5);
                        HTools.Main.soundFX(Game.Player.Character, "dryfire.wav", Common.assetFolder, 15f);
                        if (!Function.Call<bool>(Hash.IS_HELP_MESSAGE_BEING_DISPLAYED))
                            Screen.ShowHelpText("~BLIP_INFO_ICON~ Weapon is ~r~jammed", 1000);
                    }
                }
                if ((Entity)WeaponJamming.curWeaponJammedPlayer != (Entity)Game.Player.Character)
                {
                    WeaponJamming.createWeaponConditionStructure(Game.Player.Character, Common.doc);
                    if (WeaponJamming.shootingWeapon != (WeaponHash)0 && (Entity)WeaponJamming.curWeaponJammedPlayer != (Entity)null && WeaponJamming.curWeaponJammedPlayer.Model != (Model)0)
                        WeaponJamming.saveShotsForCurWeapon(WeaponJamming.curWeaponJammedPlayer, Common.doc, WeaponJamming.shotsFired, WeaponJamming.shootingWeapon);
                    WeaponJamming.shotsFired = 0;
                    WeaponJamming.shootingWeapon = Game.Player.Character.Weapons.Current.Hash;
                    WeaponJamming.curWeaponJammedPlayer = Game.Player.Character;
                    WeaponJamming.isFixingJammedGun = false;
                    WeaponJamming.isCheckingWeaponCondition = false;
                    Array.Clear((Array)WeaponJamming.jammedWeapons, 0, WeaponJamming.jammedWeapons.Length);
                    WeaponJamming.clearWeaponCase(Game.Player.Character, HTools.Main.GetHashKey(WeaponJamming.briefcase_model));
                    WeaponJamming.clearWeaponCase(Game.Player.Character, HTools.Main.GetHashKey(WeaponJamming.briefcase_opened_model));
                    if (Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Game.Player.Character, (InputArgument)"anim@heists@money_grab@briefcase", (InputArgument)"enter", (InputArgument)3))
                        Game.Player.Character.Task.ClearAll();
                    WeaponJamming.cleaningRequired = false;
                }
                if (WeaponJamming.isCleaningJammedGun)
                {
                    if (Game.Player.Character.IsRagdoll)
                    {
                        WeaponJamming.isCleaningJammedGun = false;
                        WeaponJamming.weaponCleaningInProcess = false;
                        WeaponJamming.weaponIsReady = false;
                    }
                    HTools.Main.DisableControlsFunc(true);
                    bool cleaningWeaponIsBig = WeaponJamming.cleaningWeaponIsBig;
                    string animDict = !cleaningWeaponIsBig ? "combat@aim_variations@pistol" : "anim@amb@range@assemble_guns@";
                    string animName = !cleaningWeaponIsBig ? "var_f" : "expel_cartridge_01_amy_skater_01";
                    int num19 = cleaningWeaponIsBig ? 1 : 0;
                    int blendInSpeed = cleaningWeaponIsBig ? 1 : 4;
                    int duration = cleaningWeaponIsBig ? -1 : -1;
                    if (WeaponJamming.weaponCleaningInProcess && Game.Player.CanControlCharacter && !Game.Player.Character.IsAttached())
                    {
                        if (!WeaponJamming.weaponIsReady)
                        {
                            if (WeaponJamming.playCleaningWeaponAnimTimer > 0)
                                num3 = --WeaponJamming.playCleaningWeaponAnimTimer;
                            if ((WeaponHash)Game.Player.Character.Weapons.Current == WeaponJamming.cleaningWeapon && WeaponJamming.playCleaningWeaponAnimTimer <= 0)
                            {
                                if (Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Game.Player.Character, (InputArgument)animDict, (InputArgument)animName, (InputArgument)3))
                                {
                                    float num20 = 0.0f;
                                    float num21 = 0.99f;
                                    if (WeaponJamming.jammCounter > 0)
                                    {
                                        if (WeaponJamming.cleaningWeaponIsBig)
                                        {
                                            num20 = 0.21f;
                                            num21 = 0.25f;
                                        }
                                        else
                                        {
                                            num20 = 0.1f;
                                            num21 = 0.5f;
                                        }
                                    }
                                    if (WeaponJamming.jammCounter <= 0)
                                        WeaponJamming.weaponIsReady = true;
                                    if ((double)Function.Call<float>(Hash.GET_ENTITY_ANIM_CURRENT_TIME, (InputArgument)(Entity)Game.Player.Character, (InputArgument)animDict, (InputArgument)animName) >= (double)num21)
                                    {
                                        num3 = --WeaponJamming.jammCounter;
                                        Function.Call(Hash.SET_ENTITY_ANIM_CURRENT_TIME, (InputArgument)(Entity)Game.Player.Character, (InputArgument)animDict, (InputArgument)animName, (InputArgument)num20);
                                        if (!cleaningWeaponIsBig && (double)Function.Call<float>(Hash.GET_ENTITY_ANIM_CURRENT_TIME, (InputArgument)(Entity)Game.Player.Character, (InputArgument)animDict, (InputArgument)animName) >= 0.5 && (double)Function.Call<float>(Hash.GET_ENTITY_ANIM_CURRENT_TIME, (InputArgument)(Entity)Game.Player.Character, (InputArgument)animDict, (InputArgument)animName) < 0.699999988079071)
                                            HTools.Main.soundFX(Game.Player.Character, "tweak.wav", Common.assetFolder);
                                    }
                                }
                                else if (WeaponJamming.jammCounter > 0)
                                {
                                    Game.Player.Character.Task.PlayAnimation(animDict, animName, (float)blendInSpeed, duration, AnimationFlags.UpperBodyOnly | AnimationFlags.Secondary);
                                    if (!cleaningWeaponIsBig)
                                        HTools.Main.soundFX(Game.Player.Character, "tweak.wav", Common.assetFolder, 15f);
                                    else
                                        HTools.Main.soundFX(Game.Player.Character, "draw2.wav", Common.assetFolder, 15f);
                                }
                            }
                        }
                        else
                        {
                            if ((WeaponHash)Game.Player.Character.Weapons.Current != WeaponJamming.cleaningWeapon)
                                Game.Player.Character.Weapons.Select(WeaponJamming.cleaningWeapon);
                            if (!Game.Player.Character.IsReloading && !Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Game.Player.Character, (InputArgument)animDict, (InputArgument)animName, (InputArgument)3))
                            {
                                WeaponJamming.clearShotsForCurWeapon(Game.Player.Character, Common.doc, WeaponJamming.cleaningWeapon);
                                int supplies = Common.getSupplies(Game.Player.Character, "weapon_tools");
                                Common.saveSupplies(Game.Player.Character, "weapon_tools", supplies - 1);
                                WeaponJamming.cleaningRequired = false;
                                Game.Player.Character.Weapons.Select(WeaponHash.Unarmed);
                                WeaponJamming.weaponCleaningInProcess = false;
                                Game.Player.Character.Task.PlayAnimation("anim@scripted@heist@ig1_table_grab@cash@male@", "grab_idle", 4f, -1, AnimationFlags.Loop | AnimationFlags.UpperBodyOnly | AnimationFlags.Secondary);
                                num3 = supplies - 1;
                                Screen.ShowHelpText("~BLIP_INFO_ICON~ Your weapon is in ~g~good~w~ condition now! You have ~o~" + num3.ToString() + "~w~ cleaning tools left");
                            }
                        }
                    }
                    else
                    {
                        AimingStyle.canSwitchAimingStyle = (WeaponHash)Game.Player.Character.Weapons.Current == WeaponHash.Pistol;
                        WeaponSwing.canSwingGun = ((IEnumerable<WeaponGroup>)WeaponHolster._pistolWeaponGroup).Contains<WeaponGroup>(Game.Player.Character.Weapons.Current.Group) || ((IEnumerable<WeaponGroup>)WeaponHolster._bigWeaponGroups).Contains<WeaponGroup>(Game.Player.Character.Weapons.Current.Group);
                        LaserSight.canUseLaserSight = true;
                        Common.Draw(0, canClean: true, isCleaningWeapon: WeaponJamming.isCleaningJammedGun, cleaningRequiredParam: WeaponJamming.cleaningRequired, action_page: Common.cur_action_page, cameraModuleParam: ShoulderCameraSwitch.ShoulderCameraModuleActive, swingWeaponModuleParam: WeaponSwing.swingGunModuleActive, laserSightModuleParam: LaserSight.laserSightModeActive, canSwingWeaponParam: WeaponSwing.canSwingGun, canUseLaserSightParam: LaserSight.canUseLaserSight, weaponJamningModuleParam: WeaponJamming.jammingModeIsActive, silencerModeActiveParam: Silencer.silencerModeActive, aimingStyleModeActiveParam: AimingStyle.aimingStyleModeActive, canSwitchAimingStyleParam: AimingStyle.canSwitchAimingStyle);
                        if (Function.Call<bool>(Hash.IS_DISABLED_CONTROL_JUST_PRESSED, (InputArgument)0, (InputArgument)51) && WeaponJamming.cleaningRequired && (Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Game.Player.Character, (InputArgument)"anim@scripted@heist@ig1_table_grab@cash@male@", (InputArgument)"grab_idle", (InputArgument)3) || Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Game.Player.Character, (InputArgument)"anim@heists@money_grab@briefcase", (InputArgument)"enter", (InputArgument)3)) && !Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Game.Player.Character, (InputArgument)animDict, (InputArgument)animName, (InputArgument)3))
                        {
                            Game.Player.Character.Task.PlayAnimation("amb@medic@standing@kneel@base", "base", 4f, -1, AnimationFlags.StayInEndFrame);
                            Game.Player.Character.Task.PlayAnimation("mp_arrest_paired", "cop_p1_rf_right_0", 4f, -1, AnimationFlags.UpperBodyOnly | AnimationFlags.Secondary);
                            Screen.ShowHelpText("~BLIP_INFO_ICON~ cleaning " + WeaponJamming.cleaningWeapon.ToString() + " started...", 3000);
                            Game.Player.Character.Weapons.Select(WeaponJamming.cleaningWeapon);
                            WeaponJamming.playCleaningWeaponAnimTimer = 100;
                            WeaponJamming.jammCounter = 1;
                            if (WeaponJamming.cleaningWeaponIsBig)
                                WeaponJamming.jammCounter = 3;
                            WeaponJamming.weaponCleaningInProcess = true;
                            WeaponJamming.weaponIsReady = false;
                        }
                        if (Function.Call<bool>(Hash.IS_DISABLED_CONTROL_JUST_PRESSED, (InputArgument)0, (InputArgument)52))
                        {
                            if (Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Game.Player.Character, (InputArgument)"amb@medic@standing@kneel@base", (InputArgument)"base", (InputArgument)3) || Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Game.Player.Character, (InputArgument)"anim@heists@money_grab@briefcase", (InputArgument)"enter", (InputArgument)3) || Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Game.Player.Character, (InputArgument)"anim@scripted@heist@ig1_table_grab@cash@male@", (InputArgument)"grab_idle", (InputArgument)3))
                            {
                                Game.Player.Character.Weapons.Select(WeaponHash.Unarmed);
                                Game.Player.Character.Task.ClearAll();
                                Game.Player.Character.Task.PlayAnimation("anim@heists@money_grab@briefcase", "exit", 4f, 1800, AnimationFlags.None);
                                WeaponJamming.weaponCaseSwitched = false;
                            }
                            else
                            {
                                WeaponJamming.clearWeaponCase(Game.Player.Character, HTools.Main.GetHashKey(WeaponJamming.briefcase_model));
                                WeaponJamming.clearWeaponCase(Game.Player.Character, HTools.Main.GetHashKey(WeaponJamming.briefcase_opened_model));
                                WeaponJamming.isCleaningJammedGun = false;
                                WeaponJamming.weaponCaseSwitched = false;
                            }
                        }
                        if (Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Game.Player.Character, (InputArgument)"anim@heists@money_grab@briefcase", (InputArgument)"exit", (InputArgument)3))
                        {
                            if ((double)Function.Call<float>(Hash.GET_ENTITY_ANIM_CURRENT_TIME, (InputArgument)(Entity)Game.Player.Character, (InputArgument)"anim@heists@money_grab@briefcase", (InputArgument)"exit") > 0.65)
                            {
                                WeaponJamming.clearWeaponCase(Game.Player.Character, HTools.Main.GetHashKey(WeaponJamming.briefcase_model));
                                WeaponJamming.clearWeaponCase(Game.Player.Character, HTools.Main.GetHashKey(WeaponJamming.briefcase_opened_model));
                                WeaponJamming.isCleaningJammedGun = false;
                            }
                            else if (!WeaponJamming.weaponCaseSwitched)
                            {
                                WeaponJamming.weaponCaseSwitched = true;
                                WeaponJamming.clearWeaponCase(Game.Player.Character, HTools.Main.GetHashKey(WeaponJamming.briefcase_opened_model));
                                WeaponJamming.getWeaponCaseFunc(Game.Player.Character, HTools.Main.GetHashKey(WeaponJamming.briefcase_model), true, new Vector3(Game.Player.Character.FrontPosition.X, Game.Player.Character.FrontPosition.Y, Game.Player.Character.FrontPosition.Z), true);
                                WeaponJamming.clearWeaponCleaningToolsFunc(HTools.Main.GetHashKey(WeaponJamming.gunspray_can), Game.Player.Character.Position);
                                WeaponJamming.clearWeaponCleaningToolsFunc(HTools.Main.GetHashKey(WeaponJamming.gun_case_small), Game.Player.Character.Position);
                            }
                        }
                        if (!Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Game.Player.Character, (InputArgument)"anim@heists@money_grab@briefcase", (InputArgument)"exit", (InputArgument)3) && Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Game.Player.Character, (InputArgument)"anim@heists@money_grab@briefcase", (InputArgument)"enter", (InputArgument)3) && (double)Function.Call<float>(Hash.GET_ENTITY_ANIM_CURRENT_TIME, (InputArgument)(Entity)Game.Player.Character, (InputArgument)"anim@heists@money_grab@briefcase", (InputArgument)"enter") >= 0.64999997615814209 && !WeaponJamming.weaponCaseSwitched)
                        {
                            WeaponJamming.clearWeaponCase(Game.Player.Character, HTools.Main.GetHashKey(WeaponJamming.briefcase_model));
                            Prop weaponCaseFunc = WeaponJamming.getWeaponCaseFunc(Game.Player.Character, HTools.Main.GetHashKey(WeaponJamming.briefcase_opened_model), false, new Vector3(Game.Player.Character.Position.X - 0.5f, Game.Player.Character.Position.Y + 0.3f, (float)((double)Game.Player.Character.Position.Z - (double)Game.Player.Character.HeightAboveGround + 0.10000000149011612)), true);
                            if ((Entity)weaponCaseFunc != (Entity)null)
                            {
                                weaponCaseFunc.IsCollisionEnabled = false;
                                weaponCaseFunc.Rotation = new Vector3(Game.Player.Character.Rotation.X, Game.Player.Character.Rotation.Y, Game.Player.Character.Rotation.Z);
                                weaponCaseFunc.Position = new Vector3(Game.Player.Character.FrontPosition.X, Game.Player.Character.FrontPosition.Y, (float)((double)Game.Player.Character.Position.Z - (double)Game.Player.Character.HeightAboveGround + 0.10000000149011612));
                                WeaponJamming.getWeaponCleaningToolsFunc(Game.Player.Character, HTools.Main.GetHashKey(WeaponJamming.gunspray_can), new Vector3(Game.Player.Character.RightPosition.X, Game.Player.Character.RightPosition.Y, Game.Player.Character.RightPosition.Z + 0.1f));
                                WeaponJamming.getWeaponCleaningToolsFunc(Game.Player.Character, HTools.Main.GetHashKey(WeaponJamming.gun_case_small), new Vector3(Game.Player.Character.RightPosition.X - 0.2f, Game.Player.Character.RightPosition.Y, Game.Player.Character.RightPosition.Z + 0.3f));
                            }
                            Game.Player.Character.Task.PlayAnimation("anim@scripted@heist@ig1_table_grab@cash@male@", "grab_idle", 4f, -1, AnimationFlags.Loop | AnimationFlags.UpperBodyOnly | AnimationFlags.Secondary);
                            WeaponJamming.weaponCaseSwitched = true;
                        }
                    }
                }
                if (((IEnumerable<WeaponGroup>)WeaponHolster._pistolWeaponGroup).Contains<WeaponGroup>(Game.Player.Character.Weapons.Current.Group) || ((IEnumerable<WeaponGroup>)WeaponHolster._bigWeaponGroups).Contains<WeaponGroup>(Game.Player.Character.Weapons.Current.Group) && !WeaponJamming.isCleaningJammedGun)
                {
                    WeaponJamming.weaponIsJammed = ((IEnumerable<WeaponHash>)WeaponJamming.jammedWeapons).Contains<WeaponHash>(Game.Player.Character.Weapons.Current.Hash);
                    bool flag = ((IEnumerable<WeaponGroup>)WeaponHolster._bigWeaponGroups).Contains<WeaponGroup>(Game.Player.Character.Weapons.Current.Group) && (WeaponHash)Game.Player.Character.Weapons.Current != WeaponHash.MicroSMG && (WeaponHash)Game.Player.Character.Weapons.Current != WeaponHash.MiniSMG && (WeaponHash)Game.Player.Character.Weapons.Current != WeaponHash.SMGMk2;
                    string str1 = !flag ? "combat@aim_variations@pistol" : "anim@amb@range@assemble_guns@";
                    string animName1 = !flag ? "var_f" : "expel_cartridge_01_amy_skater_01";
                    float num22 = flag ? 0.5f : 0.99f;
                    int blendInSpeed = flag ? 1 : 4;
                    int duration = flag ? -1 : -1;
                    string animName2 = "drop_lh";
                    string animDict = "mp_weapon_drop";
                    if (flag)
                        animName2 = "drop_bh";
                    WeaponJamming.maxShotsBeforeBadCondition = flag ? WeaponJamming.weaponsMaxShots * 2 : WeaponJamming.weaponsMaxShots;
                    if (Game.Player.Character.IsAiming && !Game.Player.Character.IsSittingInVehicle() && !FocusMode.targetsPicked && !FocusMode.isFocused && Game.Player.CanControlCharacter && !Game.Player.Character.IsAttached())
                    {
                        Game.DisableControlThisFrame((Control)WeaponJamming.clean_weapon_btn);
                        WeaponSwing.canSwingGun = ((IEnumerable<WeaponGroup>)WeaponHolster._pistolWeaponGroup).Contains<WeaponGroup>(Game.Player.Character.Weapons.Current.Group) || ((IEnumerable<WeaponGroup>)WeaponHolster._bigWeaponGroups).Contains<WeaponGroup>(Game.Player.Character.Weapons.Current.Group);
                        AimingStyle.canSwitchAimingStyle = (WeaponHash)Game.Player.Character.Weapons.Current == WeaponHash.Pistol;
                        LaserSight.canUseLaserSight = true;
                        Common.Draw(0, weaponIsJammedParam: WeaponJamming.weaponIsJammed, canClean: true, cleaningRequiredParam: WeaponJamming.cleaningRequired, action_page: Common.cur_action_page, cameraModuleParam: ShoulderCameraSwitch.ShoulderCameraModuleActive, swingWeaponModuleParam: WeaponSwing.swingGunModuleActive, laserSightModuleParam: LaserSight.laserSightModeActive, canSwingWeaponParam: WeaponSwing.canSwingGun, canUseLaserSightParam: LaserSight.canUseLaserSight, weaponJamningModuleParam: WeaponJamming.jammingModeIsActive, silencerModeActiveParam: Silencer.silencerModeActive, aimingStyleModeActiveParam: AimingStyle.aimingStyleModeActive, canSwitchAimingStyleParam: AimingStyle.canSwitchAimingStyle);
                        if (Function.Call<bool>(Hash.IS_DISABLED_CONTROL_JUST_PRESSED, (InputArgument)0, (InputArgument)Scope.scope_toggle_btn))
                            Scope.toggleScope = true;
                        if (Function.Call<bool>(Hash.IS_DISABLED_CONTROL_JUST_PRESSED, (InputArgument)0, (InputArgument)Flashlight.flashlight_toggle_btn))
                            Flashlight.toggleFlashlight = true;
                        if (Function.Call<bool>(Hash.IS_DISABLED_CONTROL_JUST_PRESSED, (InputArgument)0, (InputArgument)Grip.grip_toggle_btn))
                            Grip.toggleGrip = true;
                        if (Function.Call<bool>(Hash.IS_DISABLED_CONTROL_JUST_PRESSED, (InputArgument)0, (InputArgument)ExtendedMagazine.extendedmagazine_toggle_btn))
                            ExtendedMagazine.toggleExtendedMagazine = true;
                        if (Function.Call<bool>(Hash.IS_DISABLED_CONTROL_JUST_PRESSED, (InputArgument)0, (InputArgument)WeaponJamming.clean_weapon_btn) && WeaponJamming.cleaningRequired)
                        {
                            if (Game.Player.CanControlCharacter && Game.Player.Character.IsOnFoot && !Game.Player.Character.IsInCombat && Game.Player.WantedLevel <= 0)
                            {
                                WeaponJamming.cleaningWeapon = Game.Player.Character.Weapons.Current.Hash;
                                WeaponJamming.cleaningWeaponIsBig = flag;
                                Game.Player.Character.Weapons.Select(WeaponHash.Unarmed);
                                if ((Entity)WeaponJamming.getWeaponCaseFunc(Game.Player.Character, HTools.Main.GetHashKey(WeaponJamming.briefcase_model), true, new Vector3(Game.Player.Character.FrontPosition.X, Game.Player.Character.FrontPosition.Y, Game.Player.Character.FrontPosition.Z), true) != (Entity)null && !Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Game.Player.Character, (InputArgument)"anim@heists@money_grab@briefcase", (InputArgument)"enter", (InputArgument)3))
                                {
                                    WeaponJamming.weaponCaseSwitched = false;
                                    Game.Player.Character.Task.PlayAnimation("anim@heists@money_grab@briefcase", "enter", 4f, -1, AnimationFlags.StayInEndFrame);
                                    WeaponJamming.isCleaningJammedGun = true;
                                }
                            }
                            else
                                Screen.ShowHelpText("~BLIP_INFO_ICON~ You can't clean your weapon now!", 3000);
                        }
                        if (Function.Call<bool>(Hash.IS_DISABLED_CONTROL_JUST_PRESSED, (InputArgument)0, (InputArgument)WeaponJamming.fix_weapon_btn) && !Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Game.Player.Character, (InputArgument)str1, (InputArgument)animName1, (InputArgument)3) && !Function.Call<bool>(Hash.IS_PED_RUNNING_MOBILE_PHONE_TASK, (InputArgument)(Entity)Game.Player.Character) && !Function.Call<bool>(Hash.IS_PED_RUNNING_RAGDOLL_TASK, (InputArgument)(Entity)Game.Player.Character) && !Game.IsControlPressed(Control.Sprint))
                        {
                            if (WeaponJamming.weaponIsJammed)
                            {
                                if (WeaponJamming.jammCounter >= 0)
                                {
                                    if (Game.Player.Character.IsInCover && Game.Player.Character.IsAimingFromCover)
                                    {
                                        if (flag)
                                        {
                                            if (!Game.Player.Character.IsInCoverFacingLeft)
                                                Game.Player.Character.Task.ClearAll();
                                        }
                                        else if (Game.Player.Character.IsInCoverFacingLeft)
                                            Game.Player.Character.Task.ClearAll();
                                    }
                                    WeaponJamming.weaponIsReady = false;
                                    Game.Player.Character.Task.PlayAnimation(str1, animName1, (float)blendInSpeed, duration, AnimationFlags.UpperBodyOnly | AnimationFlags.Secondary);
                                    if (!flag)
                                        HTools.Main.soundFX(Game.Player.Character, "tweak.wav", Common.assetFolder, 15f);
                                    WeaponJamming.isFixingJammedGun = true;
                                    WeaponJamming.weaponJammingAnimTimeOut = 500;
                                }
                            }
                            else if (!Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Game.Player.Character, (InputArgument)str1, (InputArgument)animName1, (InputArgument)3))
                            {
                                if (Game.Player.Character.IsInCover && Game.Player.Character.IsAimingFromCover)
                                {
                                    if (flag)
                                    {
                                        if (!Game.Player.Character.IsInCoverFacingLeft)
                                            Game.Player.Character.Task.ClearAll();
                                    }
                                    else if (Game.Player.Character.IsInCoverFacingLeft)
                                        Game.Player.Character.Task.ClearAll();
                                }
                                WeaponJamming.weaponIsReady = false;
                                Game.Player.Character.Task.PlayAnimation(str1, animName1, (float)blendInSpeed, duration, AnimationFlags.UpperBodyOnly | AnimationFlags.Secondary);
                                if (!flag)
                                    HTools.Main.soundFX(Game.Player.Character, "tweak.wav", Common.assetFolder, 15f);
                                WeaponJamming.isCheckingWeaponCondition = true;
                                WeaponJamming.weaponJammingAnimTimeOut = 300;
                            }
                        }
                        Game.DisableControlThisFrame(Control.Cover);
                        Game.DisableControlThisFrame(Control.ContextSecondary);
                        Game.DisableControlThisFrame(Control.Jump);
                        if (WeaponJamming.weaponIsJammed)
                        {
                            Game.DisableControlThisFrame(Control.Attack);
                            Game.DisableControlThisFrame(Control.Attack2);
                            if (Function.Call<bool>(Hash.IS_DISABLED_CONTROL_JUST_PRESSED, (InputArgument)0, (InputArgument)24))
                            {
                                WeaponJamming.jammCounter = Common.rnd.Next(1, 5);
                                HTools.Main.soundFX(Game.Player.Character, "dryfire.wav", Common.assetFolder, 15f);
                                if (!Function.Call<bool>(Hash.IS_HELP_MESSAGE_BEING_DISPLAYED))
                                    Screen.ShowHelpText("~BLIP_INFO_ICON~ Weapon is ~r~jammed", 1000);
                            }
                        }
                    }
                    if (WeaponJamming.weaponRemoveInProcess)
                    {
                        HTools.Main.DisableControlsFunc(true);
                        if (!Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Game.Player.Character, (InputArgument)animDict, (InputArgument)animName2, (InputArgument)3))
                        {
                            Game.Player.Character.Task.ClearAll();
                            Game.Player.Character.Task.PlayAnimation(animDict, animName2, 4f, -1, AnimationFlags.UpperBodyOnly | AnimationFlags.Secondary);
                        }
                        if ((double)Function.Call<float>(Hash.GET_ENTITY_ANIM_CURRENT_TIME, (InputArgument)(Entity)Game.Player.Character, (InputArgument)animDict, (InputArgument)animName2) > 0.800000011920929)
                        {
                            WeaponJamming.weaponRemoveInProcess = false;
                            WeaponJamming.clearShotsForCurWeapon(Game.Player.Character, Common.doc, (WeaponHash)Game.Player.Character.Weapons.Current);
                            Function.Call(Hash.GET_WEAPON_OBJECT_FROM_PED, (InputArgument)(Entity)Game.Player.Character, (InputArgument)false);
                            Script.Wait(200);
                            Game.Player.Character.Weapons.Remove(Game.Player.Character.Weapons.Current);
                            HTools.Main.soundFX(Game.Player.Character, "draw2.wav", Common.assetFolder);
                        }
                    }
                    if (WeaponJamming.isCheckingWeaponCondition)
                    {
                        if (Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Game.Player.Character, (InputArgument)str1, (InputArgument)animName1, (InputArgument)3))
                        {
                            if (flag && (double)Function.Call<float>(Hash.GET_ENTITY_ANIM_CURRENT_TIME, (InputArgument)(Entity)Game.Player.Character, (InputArgument)str1, (InputArgument)animName1) >= 0.20000000298023224 && !WeaponJamming.weaponIsReady)
                            {
                                if (Game.Player.Character.Weapons.Current.AmmoInClip > 1)
                                    num3 = --Game.Player.Character.Weapons.Current.AmmoInClip;
                                WeaponJamming.weaponIsReady = true;
                            }
                            if ((double)Function.Call<float>(Hash.GET_ENTITY_ANIM_CURRENT_TIME, (InputArgument)(Entity)Game.Player.Character, (InputArgument)str1, (InputArgument)animName1) >= (double)num22)
                            {
                                Game.Player.Character.Task.ClearAnimation(str1, animName1);
                                WeaponJamming.isCheckingWeaponCondition = false;
                                if (WeaponJamming.shootingWeapon == (WeaponHash)0)
                                    WeaponJamming.shootingWeapon = (WeaponHash)Game.Player.Character.Weapons.Current;
                                if (WeaponJamming.shotsFired > 0)
                                    WeaponJamming.saveShotsForCurWeapon(Game.Player.Character, Common.doc, WeaponJamming.shotsFired, WeaponJamming.shootingWeapon);
                                WeaponJamming.shootingWeapon = (WeaponHash)Game.Player.Character.Weapons.Current;
                                WeaponJamming.shotsFired = 0;
                                int weaponTotalShots = WeaponJamming.getCurWeaponTotalShots(Game.Player.Character, Common.doc, WeaponJamming.shootingWeapon);
                                WeaponJamming.hasCleaningTools = Common.getSupplies(Game.Player.Character, "weapon_tools") > 0;
                                WeaponJamming.max_rnd_chance = WeaponJamming.maxShotsBeforeBadCondition > weaponTotalShots ? WeaponJamming.maxShotsBeforeBadCondition - weaponTotalShots : 0;
                                if (WeaponJamming.hasCleaningTools && !Game.Player.Character.IsInCombat && !Game.Player.Character.IsInCover)
                                    WeaponJamming.cleaningRequired = true;
                                string str2 = WeaponJamming.cleaningRequired ? "~n~You have ~o~" + Common.getSupplies(Game.Player.Character, "weapon_tools").ToString() + "~w~ weapon cleaning toolkits. You can clean your weapon now." : "~n~You need to purchase a weapon cleaning toolkit from a ~p~weapon dealer~w~ or ~p~Ammunation~w~ for regular weapon maintenance. Dial the phone contact named ~p~Richard~w~ to call a blackmarket~BLIP_INFO_ICON~ ~p~dealer~w~";
                                if (WeaponJamming.max_rnd_chance <= 30 && WeaponJamming.max_rnd_chance > 1)
                                    Screen.ShowHelpText("~BLIP_INFO_ICON~ Your weapon is in ~o~BAD~w~ condition." + str2, 10000);
                                else if (WeaponJamming.max_rnd_chance < 1)
                                    Screen.ShowHelpText("~BLIP_INFO_ICON~ Your weapon is ~r~DESTROYED~w~." + str2, 10000);
                                else if (WeaponJamming.max_rnd_chance > 30)
                                    Screen.ShowHelpText("~BLIP_INFO_ICON~ Your weapon is in ~g~GOOD~w~ condition." + str2, 10000);
                            }
                        }
                        else if (WeaponJamming.weaponJammingAnimTimeOut > 0)
                        {
                            num3 = --WeaponJamming.weaponJammingAnimTimeOut;
                        }
                        else
                        {
                            WeaponJamming.isCheckingWeaponCondition = false;
                            Game.Player.Character.Task.ClearAll();
                        }
                        HTools.Main.DisableControlsFunc(true);
                    }
                    if (WeaponJamming.weaponIsJammed && WeaponJamming.isFixingJammedGun)
                    {
                        if (Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Game.Player.Character, (InputArgument)str1, (InputArgument)animName1, (InputArgument)3))
                        {
                            float num23 = 0.0f;
                            float num24 = 0.99f;
                            if (WeaponJamming.jammCounter > 0)
                            {
                                if (flag)
                                {
                                    num23 = 0.21f;
                                    num24 = 0.25f;
                                }
                                else
                                {
                                    num23 = 0.1f;
                                    num24 = 0.5f;
                                }
                            }
                            if (WeaponJamming.jammCounter <= 0)
                                WeaponJamming.weaponIsReady = true;
                            if ((double)Function.Call<float>(Hash.GET_ENTITY_ANIM_CURRENT_TIME, (InputArgument)(Entity)Game.Player.Character, (InputArgument)str1, (InputArgument)animName1) >= (double)num24)
                            {
                                num3 = --WeaponJamming.jammCounter;
                                Function.Call(Hash.SET_ENTITY_ANIM_CURRENT_TIME, (InputArgument)(Entity)Game.Player.Character, (InputArgument)str1, (InputArgument)animName1, (InputArgument)num23);
                                if (Game.Player.Character.Weapons.Current.AmmoInClip > 1)
                                    num3 = --Game.Player.Character.Weapons.Current.AmmoInClip;
                                if (!flag && (double)Function.Call<float>(Hash.GET_ENTITY_ANIM_CURRENT_TIME, (InputArgument)(Entity)Game.Player.Character, (InputArgument)str1, (InputArgument)animName1) >= 0.5 && (double)Function.Call<float>(Hash.GET_ENTITY_ANIM_CURRENT_TIME, (InputArgument)(Entity)Game.Player.Character, (InputArgument)str1, (InputArgument)animName1) < 0.699999988079071)
                                    HTools.Main.soundFX(Game.Player.Character, "tweak.wav", Common.assetFolder);
                            }
                            if ((double)Function.Call<float>(Hash.GET_ENTITY_ANIM_CURRENT_TIME, (InputArgument)(Entity)Game.Player.Character, (InputArgument)str1, (InputArgument)animName1) >= (double)num22)
                            {
                                Game.Player.Character.Task.ClearAnimation(str1, animName1);
                                WeaponJamming.isFixingJammedGun = false;
                                if (WeaponJamming.jammCounter <= 0 && ((IEnumerable<WeaponHash>)WeaponJamming.jammedWeapons).Contains<WeaponHash>(Game.Player.Character.Weapons.Current.Hash))
                                    WeaponJamming.jammedWeapons = ((IEnumerable<WeaponHash>)WeaponJamming.jammedWeapons).Where<WeaponHash>((Func<WeaponHash, bool>)(val => val != Game.Player.Character.Weapons.Current.Hash)).ToArray<WeaponHash>();
                            }
                        }
                        else if (WeaponJamming.weaponJammingAnimTimeOut > 0)
                        {
                            num3 = --WeaponJamming.weaponJammingAnimTimeOut;
                        }
                        else
                        {
                            WeaponJamming.isCheckingWeaponCondition = false;
                            Game.Player.Character.Task.ClearAll();
                        }
                        HTools.Main.DisableControlsFunc(true);
                    }
                    if (!WeaponJamming.weaponIsJammed && Game.Player.Character.IsShooting)
                    {
                        if (WeaponJamming.shootingWeapon != Game.Player.Character.Weapons.Current.Hash)
                        {
                            if (WeaponJamming.shootingWeapon != (WeaponHash)0 && Game.Player.Character.Model != (Model)0)
                                WeaponJamming.saveShotsForCurWeapon(Game.Player.Character, Common.doc, WeaponJamming.shotsFired, WeaponJamming.shootingWeapon);
                            WeaponJamming.shootingWeapon = Game.Player.Character.Weapons.Current.Hash;
                            WeaponJamming.shotsFired = 0;
                            int weaponTotalShots = WeaponJamming.getCurWeaponTotalShots(Game.Player.Character, Common.doc, WeaponJamming.shootingWeapon);
                            WeaponJamming.max_rnd_chance = WeaponJamming.maxShotsBeforeBadCondition > weaponTotalShots ? WeaponJamming.maxShotsBeforeBadCondition - weaponTotalShots : 0;
                        }
                        num3 = ++WeaponJamming.shotsFired;
                        if (Common.rnd.Next(0, WeaponJamming.max_rnd_chance) == 0)
                        {
                            WeaponJamming.jammCounter = Common.rnd.Next(1, 5);
                            if (!((IEnumerable<WeaponHash>)WeaponJamming.jammedWeapons).Contains<WeaponHash>(Game.Player.Character.Weapons.Current.Hash))
                                WeaponJamming.jammedWeapons = ((IEnumerable<WeaponHash>)WeaponJamming.jammedWeapons).Concat<WeaponHash>((IEnumerable<WeaponHash>)new WeaponHash[1]
                                {
                  Game.Player.Character.Weapons.Current.Hash
                                }).ToArray<WeaponHash>();
                        }
                    }
                }
                else
                {
                    WeaponJamming.isFixingJammedGun = false;
                    WeaponJamming.isCheckingWeaponCondition = false;
                    if (!WeaponJamming.isCleaningJammedGun)
                        WeaponJamming.cleaningRequired = false;
                }
                if (WeaponJamming.weaponJammingTimer < Game.GameTime)
                {
                    WeaponJamming.weaponJammingTimer = Game.GameTime + 20000;
                    if (WeaponJamming.shootingWeapon != (WeaponHash)0 && !Game.Player.Character.IsShooting && WeaponJamming.shotsFired > 0 && Game.Player.Character.Model != (Model)0)
                    {
                        WeaponJamming.saveShotsForCurWeapon(Game.Player.Character, Common.doc, WeaponJamming.shotsFired, WeaponJamming.shootingWeapon);
                        WeaponJamming.shootingWeapon = (WeaponHash)Game.Player.Character.Weapons.Current;
                        WeaponJamming.shotsFired = 0;
                    }
                }
            }
            if (Common.deal && !Common.payed)
            {
                if ((Entity)Common.seller != (Entity)null)
                {
                    vector3_1 = Common.seller.Position;
                    if ((double)vector3_1.DistanceTo(Game.Player.Character.Position) < 15.0 && !Common.payed)
                        Common.callContact.Name = "Pay for purchases";
                }
            }
            else
                Common.callContact.Name = "Richard";
            if (Common.come_over_mode)
            {
                if (Function.Call<int>(Hash.GET_INTERIOR_FROM_ENTITY, (InputArgument)(Entity)Game.Player.Character) == 0)
                {
                    if ((Entity)Common.seller == (Entity)null || (Entity)Common.seller != (Entity)null && (!Common.seller.Exists() || Common.seller.IsDead))
                    {
                        if ((Entity)HTools.Main.TryToGetPedAtLocation(Game.Player.Character.Position, 25f, PedHash.Dealer01SMY) == (Entity)null)
                            Common.CreateSeller(World.GetSafeCoordForPed(new Vector3(Game.Player.Character.Position.X, Game.Player.Character.Position.Y + 100f, Game.Player.Character.Position.Z), flags: 1));
                    }
                    else
                        Common.ComeOverFunc(Game.Player.Character, Common.seller, InventoryBag.hours_to_advance);
                }
                else
                {
                    if (Screen.IsFadedIn)
                    {
                        Screen.FadeOut(3000);
                        Script.Wait(1000);
                        Function.Call(Hash.PLAY_SOUND_FRONTEND, (InputArgument)(-1), (InputArgument)"DOOR_BUZZ", (InputArgument)"MP_PLAYER_APARTMENT", (InputArgument)1);
                    }
                    if (Screen.IsFadedOut)
                    {
                        Vector3 vector3_6 = new Vector3(Game.Player.Character.Position.X, Game.Player.Character.Position.Y, Game.Player.Character.Position.Z);
                        World.GetSafeCoordForPed(vector3_6, false, 1);
                        if ((Entity)Common.seller == (Entity)null || (Entity)Common.seller != (Entity)null && (!Common.seller.Exists() || Common.seller.IsDead))
                        {
                            if ((Entity)HTools.Main.TryToGetPedAtLocation(Game.Player.Character.Position, 25f, PedHash.Dealer01SMY) == (Entity)null)
                                Common.CreateSeller(vector3_6);
                        }
                        else
                            Common.seller.Position = vector3_6;
                        Function.Call(Hash.ADD_TO_CLOCK_TIME, (InputArgument)Common.rnd.Next(1, 3), (InputArgument)Common.rnd.Next(1, 60), (InputArgument)Common.rnd.Next(1, 60));
                        Script.Wait(2000);
                        Screen.FadeIn(3000);
                        Script.Wait(1000);
                        Common.come_over_mode = false;
                    }
                }
            }
            if (Common.followCamera)
                Common.followCameraCreateFunc(Game.Player.Character, Common.CamObject);
            else
                Common.followCameraDeleteFunc(Game.Player.Character, Common.CamObject);
            if (Screen.IsFadedOut || Function.Call<bool>(Hash.IS_PLAYER_SWITCH_IN_PROGRESS))
            {
                if (!Common.trash_cleared)
                {
                    Common.trash_cleared = true;
                    Common.update_inventory_status(Game.Player.Character);
                    Common.clearTrash();
                }
            }
            else
                Common.trash_cleared = false;
            if ((Entity)Common.curPlayer != (Entity)Game.Player.Character)
            {
                if ((Entity)InventoryBag.cur_bag != (Entity)null && !InventoryBag.cur_bag.IsAttached())
                    InventoryBag.cur_bag.Delete();
                Common.curPlayer = Game.Player.Character;
                Common.update_inventory_status(Game.Player.Character);
                Common.clearTrash();
            }
            if (Game.Player.Character.IsDead)
            {
                Common.ClearedItemsWhenDeadXML();
                Common.ClearItemsWhenDead();
                Common.clearTrash();
                Common.DeleteSupplies(Game.Player.Character);
            }
            if (InventoryBag.bag_module_active)
            {
                if (Game.Player.Character.IsOnFoot && (Entity)InventoryBag.bagModelReturn(Game.Player.Character) != (Entity)null)
                {
                    if (!Common.isOccupied(Game.Player.Character) && !HTools.Main.isOccupiedNative(Game.Player.Character))
                        InventoryBag.WeaponSwitchAnim(Game.Player.Character);
                    else
                        InventoryBag.prevWeapon = Function.Call<uint>(Hash.GET_SELECTED_PED_WEAPON, (InputArgument)(Entity)Game.Player.Character);
                }
                if (InventoryBag.bagPickUp)
                {
                    Entity dropedBag = InventoryBag.droped_bag;
                    if (dropedBag != (Entity)null && dropedBag.Exists() && dropedBag.Model == (Model)HTools.Main.GetHashKey(InventoryBag.stashedBagModel))
                    {
                        Common.camTimer = 0;
                        Common.CamObject = dropedBag;
                        Common.followCamera = false;
                        Common.Draw(1, InventoryBag.hasBag, InventoryBag.canTakeBagFromVehicle, WeaponHolster.hasHolster, InventoryBag.isBagBought, InventoryBag.isBagDropped);
                        if (Function.Call<bool>(Hash.IS_CONTROL_JUST_PRESSED, (InputArgument)0, (InputArgument)51))
                        {
                            if (dropedBag != (Entity)null && dropedBag.Exists())
                            {
                                vector3_1 = dropedBag.Position;
                                if ((double)vector3_1.DistanceTo(Game.Player.Character.Position) <= 1.0)
                                {
                                    Common.blipHandle(false, dropedBag, BlipSprite.Briefcase2, "DuffleBag", 0.85f, 200, true, true);
                                    dropedBag.Delete();
                                    InventoryBag.bagSet(InventoryBag.bagModelCheck(Game.Player.Character), Game.Player.Character);
                                    goto label_1305;
                                }
                            }
                            Screen.ShowHelpText("~BLIP_INFO_ICON~ ~c~Get closer to ~w~~h~Stashed bag~h~~w~", 6000);
                            InventoryBag.bagPickUp = false;
                        }
                    }
                }
            label_1305:
                if (!InventoryBag.canTakeBagFromVehicle && InventoryBag.canPutOnBagOnExit && Game.IsControlJustPressed(Control.VehicleExit))
                    InventoryBag.bagSet(InventoryBag.bagModelCheck(Game.Player.Character), Game.Player.Character);
                if (InventoryBag.droped_bag != (Entity)null)
                    Function.Call(Hash.DRAW_LIGHT_WITH_RANGE, (InputArgument)InventoryBag.droped_bag.Position.X, (InputArgument)InventoryBag.droped_bag.Position.Y, (InputArgument)InventoryBag.droped_bag.Position.Z, (InputArgument)50, (InputArgument)(int)byte.MaxValue, (InputArgument)0, (InputArgument)1f, (InputArgument)1f);
                if (InventoryBag.DufflebagTimeCounter < Game.GameTime)
                {
                    InventoryBag.DufflebagTimeCounter = Game.GameTime + 5000;
                    InventoryBag.droped_bag = InventoryBag.getDroppedBag(Game.Player.Character);
                    if ((Entity)Game.Player.Character != (Entity)null && InventoryBag.droped_bag != (Entity)null)
                    {
                        if (Function.Call<bool>(Hash.IS_PLAYER_SWITCH_IN_PROGRESS))
                        {
                            InventoryBag.droped_bag.Delete();
                            Common.blipsRemove(BlipSprite.Information);
                        }
                        if (Game.Player.Character.IsOnFoot)
                        {
                            if (InventoryBag.droped_bag != (Entity)null && InventoryBag.droped_bag.Exists())
                            {
                                vector3_1 = Game.Player.Character.Position;
                                if ((double)vector3_1.DistanceTo(InventoryBag.droped_bag.Position) <= 2.0)
                                {
                                    if (!InventoryBag.bagPickUp)
                                    {
                                        InventoryBag.bagPickUp = true;
                                        Screen.ShowHelpText("~BLIP_INFO_ICON~ Stashed bag found");
                                        goto label_1323;
                                    }
                                    else
                                        goto label_1323;
                                }
                            }
                            if (InventoryBag.bagPickUp)
                                InventoryBag.bagPickUp = false;
                        }
                    }
                    else if (InventoryBag.bagPickUp)
                        InventoryBag.bagPickUp = false;
                    label_1323:
                    if (Game.Player.Character.IsSittingInVehicle())
                    {
                        model = Game.Player.Character.CurrentVehicle.Model;
                        if (!model.IsBike)
                        {
                            model = Game.Player.Character.CurrentVehicle.Model;
                            if (!model.IsBicycle)
                            {
                                model = Game.Player.Character.CurrentVehicle.Model;
                                if (!model.IsQuadBike)
                                {
                                    Prop bag = InventoryBag.bagModelReturn(Game.Player.Character);
                                    if ((Entity)bag != (Entity)null && bag.IsVisible)
                                    {
                                        if (Game.Player.Character.CurrentVehicle.IsStopped)
                                        {
                                            InventoryBag.TakeOffBagInCar(bag, Game.Player.Character);
                                            goto label_1340;
                                        }
                                        else
                                            goto label_1340;
                                    }
                                    else if ((Entity)bag == (Entity)null)
                                    {
                                        if (InventoryBag.VehicleWithBag(Game.Player.Character))
                                        {
                                            InventoryBag.canTakeBagFromVehicle = true;
                                            if (!InventoryBag.notifed)
                                            {
                                                Function.Call(Hash.SET_TEXT_COLOUR, (InputArgument)(int)byte.MaxValue, (InputArgument)0, (InputArgument)0, (InputArgument)100);
                                                HTools.Main.Notify("~y~Your bag is stashed in this vehicle", "IBAG", (int)byte.MaxValue, 0, 0, NotificationIcon.Ammunation);
                                                Screen.ShowHelpText("~BLIP_INFO_ICON~ Your bag is stashed in this vehicle", 3000);
                                                Common.blipHandle(true, (Entity)Game.Player.Character.CurrentVehicle, BlipSprite.Information, "DuffleBag", 0.85f, 200, false, false);
                                                InventoryBag.notifed = true;
                                                goto label_1340;
                                            }
                                            else
                                                goto label_1340;
                                        }
                                        else
                                        {
                                            InventoryBag.canTakeBagFromVehicle = false;
                                            InventoryBag.notifed = false;
                                            goto label_1340;
                                        }
                                    }
                                    else if (!bag.IsVisible)
                                    {
                                        InventoryBag.canPutOnBagOnExit = true;
                                        goto label_1340;
                                    }
                                    else
                                        goto label_1340;
                                }
                            }
                        }
                    }
                    InventoryBag.notifed = false;
                    InventoryBag.canTakeBagFromVehicle = false;
                    InventoryBag.canPutOnBagOnExit = false;
                label_1340:
                    if (InventoryBag.doesPedHasInventoryBag(Game.Player.Character) && !Game.Player.Character.IsSittingInVehicle() && !Function.Call<bool>(Hash.IS_CUTSCENE_PLAYING) && Screen.IsFadedIn && Game.Player.Character.IsStopped && (Entity)InventoryBag.bagModelReturn(Game.Player.Character) == (Entity)null)
                        InventoryBag.bagSet(InventoryBag.bagModelCheck(Game.Player.Character), Game.Player.Character);
                    if ((Entity)Game.Player.Character != (Entity)null)
                    {
                        if (Game.Player.Character.IsOnFoot)
                            InventoryBag.checkBagVisibility(Game.Player.Character);
                        else if ((Entity)Game.Player.Character.CurrentVehicle != (Entity)null && Game.Player.Character.IsSittingInVehicle())
                        {
                            model = Game.Player.Character.CurrentVehicle.Model;
                            if (!model.IsBicycle)
                            {
                                model = Game.Player.Character.CurrentVehicle.Model;
                                if (!model.IsQuadBike)
                                {
                                    model = Game.Player.Character.CurrentVehicle.Model;
                                    if (!model.IsBike)
                                        goto label_1352;
                                }
                            }
                            InventoryBag.checkBagVisibility(Game.Player.Character);
                        }
                    }
                label_1352:
                    if (Game.IsMissionActive || Function.Call<bool>(Hash.IS_CUTSCENE_PLAYING))
                    {
                        PedHash[] pedHashArray = new PedHash[3]
                        {
              PedHash.Trevor,
              PedHash.Michael,
              PedHash.Franklin
                        };
                        foreach (PedHash pedHash in pedHashArray)
                        {
                            if (Game.Player.Character.Model != (Model)pedHash)
                            {
                                Ped[] allPeds = World.GetAllPeds((Model)pedHash);
                                if (((IEnumerable<Ped>)allPeds).Count<Ped>() > 0)
                                {
                                    Ped[] pedArray = allPeds;
                                    for (int index = 0; index < pedArray.Length; num3 = ++index)
                                    {
                                        Ped ped = pedArray[index];
                                        if ((Entity)InventoryBag.bagModelReturn(ped) == (Entity)null)
                                        {
                                            if (InventoryBag.DoesPedHasBigWeapons(ped))
                                            {
                                                InventoryBag.bagSet(InventoryBag.bagModelCheck(ped), ped);
                                                InventoryBag.bagModelReturn(ped);
                                            }
                                        }
                                        else
                                        {
                                            if (ped.IsSittingInVehicle())
                                            {
                                                model = ped.CurrentVehicle.Model;
                                                if (!model.IsBike)
                                                {
                                                    model = ped.CurrentVehicle.Model;
                                                    if (!model.IsBicycle)
                                                    {
                                                        model = ped.CurrentVehicle.Model;
                                                        if (!model.IsQuadBike)
                                                        {
                                                            Prop prop = InventoryBag.bagModelReturn(ped);
                                                            if ((Entity)prop != (Entity)null && prop.IsVisible)
                                                            {
                                                                prop.IsVisible = false;
                                                                continue;
                                                            }
                                                            continue;
                                                        }
                                                    }
                                                }
                                            }
                                            InventoryBag.checkBagVisibility(ped);
                                            if (InventoryBag.drawStrap && !InventoryBag.isStrapAttachedToPed(InventoryBag.bagModelReturn(ped), ped))
                                                InventoryBag.strapSet(InventoryBag.bagModelReturn(ped), ped);
                                        }
                                    }
                                }
                            }
                        }
                    }
                    if ((Entity)InventoryBag.bagModelReturn(Game.Player.Character) != (Entity)null && !Common.inMainMenu)
                        InventoryBag.checkEquipedGear(Game.Player.Character);
                }
            }
            if (Common.findSellerOption)
            {

                

                int num25 = 0;
                int num26 = 176;
                int num27 = 177;
                Screen.ShowHelpText("~y~Call ~w~closest ~BLIP_INFO_ICON~ ~y~Dealer~w~ to purchase ~r~supplies~w~, ~r~bags~w~ and ~r~holsters", 5000);
                Common.Draw(2, InventoryBag.hasBag, InventoryBag.canTakeBagFromVehicle, WeaponHolster.hasHolster, InventoryBag.isBagBought, InventoryBag.isBagDropped);
                if (InventoryBag.isBagDropped && Function.Call<bool>(Hash.IS_DISABLED_CONTROL_JUST_PRESSED, (InputArgument)0, (InputArgument)num25))
                {
                    Entity droppedBag = InventoryBag.getDroppedBag(Game.Player.Character);
                    if (droppedBag != (Entity)null)
                        Common.blipHandle(true, droppedBag, BlipSprite.Information, "Dufflebag", 0.85f, 200, true, false);
                    HTools.Main.Notify("Stashed bag's location~n~  has been ~y~Marked", "IBAG", (int)byte.MaxValue, 0, 0, NotificationIcon.Ammunation);
                    
                    //Function.Call(Hash.CELL_SET_INPUT, (InputArgument)2);
                    //HTools.Main.ClosePhoneFunc(Game.Player.Character, 0, 0);
                    Common.findSellerOption = false;
                    Common.followCamera = false;
                    HTools.Main.soundFX(Game.Player.Character, "beep.wav", Common.assetFolder);
                }
                if (Function.Call<bool>(Hash.IS_DISABLED_CONTROL_JUST_PRESSED, (InputArgument)0, (InputArgument)num27))
                {

                    Common.findSellerOption = false;
                    //Game.Player.Character.Task.ClearAll();
                    //Common.findSellerOption = false;
                    //Function.Call(Hash.CELL_SET_INPUT, (InputArgument)1);
                    //Common.IFruit.Close();
                    //HTools.Main.ClosePhoneFunc(Game.Player.Character, 0, 0);
                    Common.followCamera = false;
                    
                    //Game.Player.Character.Task.PutAwayMobilePhone();
                    //Game.Player.Character.Task.ClearAll();
                }
                if (Function.Call<bool>(Hash.IS_DISABLED_CONTROL_JUST_PRESSED, (InputArgument)0, (InputArgument)num26))
                {
                    WeaponJamming.hasCleaningTools = Common.getSupplies(Game.Player.Character, "weapon_tools") > 0;
                    InventoryBag.hasBag = InventoryBag.doesPedHasInventoryBag(Game.Player.Character);
                    WeaponHolster.hasHolster = WeaponHolster.doesPedHasHolster(Game.Player.Character);
                    bool flag = false;
                    if (!InventoryBag.hasBag)
                        flag = true;
                    if (!WeaponHolster.hasHolster)
                        flag = true;
                    if (!WeaponJamming.hasCleaningTools)
                        flag = true;
                    if (CigsAndPills.cigsCount < CigsAndPills.maxCigs || CigsAndPills.pillsCount < CigsAndPills.maxPills)
                        flag = true;
                    if (flag)
                    {
                        HTools.Main.Notify("Stay put. ~p~Dealer~w~ is heading your way.", "IBAG", (int)byte.MaxValue, 0, 0, NotificationIcon.Ammunation);
                        Common.trans_timer = 500;
                        Common.trans_in_process = false;
                        Common.trans_completed = false;
                        InventoryBag.hours_to_advance = Function.Call<int>(Hash.GET_CLOCK_HOURS) >= 23 ? Common.rnd.Next(1, 3) : Function.Call<int>(Hash.GET_CLOCK_HOURS) + Common.rnd.Next(1, 3);
                        Common.come_over_mode = true;
                        Common.followCamera = false;
                    }
                    else
                        HTools.Main.Notify("Sorry, can't send anyone to your location at the moment. Try again later.", "IBAG", (int)byte.MaxValue, 0, 0, NotificationIcon.Ammunation);
                    
                    //Function.Call(Hash.CELL_SET_INPUT, (InputArgument)3);
                    //HTools.Main.ClosePhoneFunc(Game.Player.Character, 0, 0);
                    Common.findSellerOption = false;
                    HTools.Main.soundFX(Game.Player.Character, "beep.wav", Common.assetFolder);
                }
                Common.camTimer = 0;
                int num28 = Common.followCamera ? 1 : 0;
                
            }
            if (InventoryBag.bag_module_active)
            {
                if (InventoryBag.inMenu)
                {
                    Function.Call(Hash.CAN_PHONE_BE_SEEN_ON_SCREEN, (InputArgument)false);
                    Common.camTimer = 0;
                    if (!InventoryBag.reattached && Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Game.Player.Character, (InputArgument)"anim@heists@money_grab@duffel", (InputArgument)"enter", (InputArgument)3) && (double)Function.Call<float>(Hash.GET_ENTITY_ANIM_CURRENT_TIME, (InputArgument)(Entity)Game.Player.Character, (InputArgument)"anim@heists@money_grab@duffel", (InputArgument)"enter") >= 0.75)
                    {
                        int num29 = Function.Call<int>(Hash.GET_PED_BONE_INDEX, (InputArgument)(Entity)Game.Player.Character, (InputArgument)57005);
                        InventoryBag.reattached = true;
                        Function.Call(Hash.ATTACH_ENTITY_TO_ENTITY, (InputArgument)(Entity)InventoryBag.bagModelReturn(Game.Player.Character), (InputArgument)(Entity)Game.Player.Character, (InputArgument)num29, (InputArgument)InventoryBag.xg, (InputArgument)InventoryBag.yg, (InputArgument)InventoryBag.zg, (InputArgument)InventoryBag.xrg, (InputArgument)InventoryBag.yrg, (InputArgument)InventoryBag.zrg, (InputArgument)true, (InputArgument)true, (InputArgument)false, (InputArgument)false, (InputArgument)2, (InputArgument)true);
                    }
                    if (Function.Call<bool>(Hash.IS_DISABLED_CONTROL_JUST_PRESSED, (InputArgument)0, (InputArgument)177) || Function.Call<bool>(Hash.IS_DISABLED_CONTROL_JUST_PRESSED, (InputArgument)0, (InputArgument)202) || Function.Call<bool>(Hash.IS_DISABLED_CONTROL_JUST_PRESSED, (InputArgument)0, (InputArgument)25))
                    {
                        Common.followCamera = false;
                        Game.Player.Character.Task.ClearAll();
                        InventoryBag.inMenu = false;
                        InventoryBag.mainMenuListString.Clear();
                        InventoryBag.stashedWeapons.Clear();
                        InventoryBag.characterWeapons.Clear();
                        InventoryBag.mainMenu.Visible = false;
                        InventoryBag.modMenuPool.CloseAllMenus();
                        InventoryBag.mainMenu.Clear();
                        InventoryBag.mainMenu = (UIMenu)null;
                        InventoryBag.modMenuPool = (MenuPool)null;
                        InventoryBag.weaponInventoryAnim(InventoryBag.bagModelReturn(Game.Player.Character), Game.Player.Character);
                    }
                    int num30 = Common.followCamera ? 1 : 0;
                    if (InventoryBag.modMenuPool != null)
                    {
                        InventoryBag.modMenuPool.ProcessMenus();
                        InventoryBag.modMenuPool.ProcessMouse();
                        InventoryBag.modMenuPool.MouseEdgeEnabled = true;
                        if (!InventoryBag.modMenuPool.IsAnyMenuOpen())
                        {
                            if (InventoryBag.mainMenu != null)
                            {
                                if (!Common.isOccupied(Game.Player.Character) && !HTools.Main.isOccupiedNative(Game.Player.Character))
                                    InventoryBag.weaponInventoryAnim(InventoryBag.bagModelReturn(Game.Player.Character), Game.Player.Character);
                                InventoryBag.mainMenu.Visible = true;
                            }
                            else
                                InventoryBag.Setup(Game.Player.Character);
                        }
                    }
                    else
                        InventoryBag.Setup(Game.Player.Character);
                }
                else if (InventoryBag.modMenuPool != null && InventoryBag.mainMenu != null)
                {
                    InventoryBag.mainMenuListString.Clear();
                    InventoryBag.stashedWeapons.Clear();
                    InventoryBag.characterWeapons.Clear();
                    InventoryBag.mainMenu.Visible = false;
                    InventoryBag.modMenuPool.CloseAllMenus();
                    InventoryBag.mainMenu.Clear();
                    InventoryBag.mainMenu = (UIMenu)null;
                    InventoryBag.modMenuPool = (MenuPool)null;
                }
            }
            if (Vest.vest_module_active)
            {
                Vest.vestcheck();

                if (Vest.inMenu)
                {
                    Function.Call(Hash.CAN_PHONE_BE_SEEN_ON_SCREEN, (InputArgument)false);
                    Common.camTimer = 0;
                    //Common.followCamera = true;
                    if (Function.Call<bool>(Hash.IS_DISABLED_CONTROL_JUST_PRESSED, (InputArgument)0, (InputArgument)177) || Function.Call<bool>(Hash.IS_DISABLED_CONTROL_JUST_PRESSED, (InputArgument)0, (InputArgument)202) || Function.Call<bool>(Hash.IS_DISABLED_CONTROL_JUST_PRESSED, (InputArgument)0, (InputArgument)25))
                    {
                        Common.followCamera = false;
                        Game.Player.Character.Task.ClearAll();
                        Vest.inMenu = false;
                        Vest.mainMenuListString.Clear();
                        Vest.stashedWeapons.Clear();
                        Vest.characterWeapons.Clear();
                        Vest.mainMenu.Visible = false;
                        Vest.modMenuPool.CloseAllMenus();
                        Vest.mainMenu.Clear();
                        Vest.mainMenu = (UIMenu)null;
                        Vest.modMenuPool = (MenuPool)null;
                    }
                    int num30 = Common.followCamera ? 1 : 0;
                    if (Vest.modMenuPool != null)
                    {
                        Vest.modMenuPool.ProcessMenus();
                        Vest.modMenuPool.ProcessMouse();
                        Vest.modMenuPool.MouseEdgeEnabled = true;
                        if (!Vest.modMenuPool.IsAnyMenuOpen())
                        {
                            if (Vest.mainMenu != null)
                            {
                                //if (!Common.isOccupied(Game.Player.Character) && !HTools.Main.isOccupiedNative(Game.Player.Character))
                                  //  InventoryBag.weaponInventoryAnim(InventoryBag.bagModelReturn(Game.Player.Character), Game.Player.Character);
                                Vest.mainMenu.Visible = true;
                            }
                            else
                                Vest.Setup(Game.Player.Character);
                        }
                    }
                    else
                        Vest.Setup(Game.Player.Character);

                    
                }
                else if (Vest.modMenuPool != null && Vest.mainMenu != null)
                {
                    Vest.mainMenuListString.Clear();
                    //Vest.stashedWeapons.Clear();
                    //Vest.characterWeapons.Clear();
                    Vest.mainMenu.Visible = false;
                    Vest.modMenuPool.CloseAllMenus();
                    Vest.mainMenu.Clear();
                    Vest.mainMenu = (UIMenu)null;
                    Vest.modMenuPool = (MenuPool)null;
                    Common.followCamera = false;
                }
            }
            if (!((Entity)Common.seller != (Entity)null) || !Common.trans_completed)
                return;
            if (Common.seller.IsAlive && !Common.seller.IsFleeing && Common.seller.Exists() && !Common.seller.IsInCombat && !Common.seller.IsInMeleeCombat)
            {
                vector3_1 = Game.Player.Character.Position;
                if ((double)vector3_1.DistanceTo(Common.seller.Position) >= 50.0)
                    return;
                if (Common.deal && Common.greetingFinished)
                {
                    vector3_1 = Game.Player.Character.Position;
                    if ((double)vector3_1.DistanceTo(Common.seller.Position) > 50.0)
                        Common.clearScriptFunction();
                    if (!Common.inProcessBag)
                    {
                        HTools.Main.DisableControlsFunc(true);
                        int num31 = 52;
                        int num32 = 0;
                        int num33 = 73;
                        int num34 = 26;
                        int num35 = 75;
                        int num36 = 51;
                        if (Common.sellerAvailableItems <= 0 && Common.TotalPrice <= 0)
                        {
                            Screen.ShowHelpTextThisFrame("No ~o~items~w~ are available right now");
                        }
                        else
                        {
                            int num37 = 999999;
                            if (Game.Player.Character.Model == (Model)PedHash.Michael || Game.Player.Character.Model == (Model)PedHash.Franklin || Game.Player.Character.Model == (Model)PedHash.Trevor)
                                num37 = Game.Player.Money;
                            Screen.ShowHelpTextThisFrame(" Price: ~c~" + Common.TotalPrice.ToString() + " ~g~~h~$~h~~n~~w~ Money: ~c~" + num37.ToString() + " ~g~~h~$~h~~w~");
                        }
                        Common.Draw(3, InventoryBag.hasBag, InventoryBag.canTakeBagFromVehicle, WeaponHolster.hasHolster, InventoryBag.isBagBought, InventoryBag.isBagDropped);
                        if (InventoryBag.bag_module_active)
                        {
                            if (!InventoryBag.isBagBought)
                            {
                                if (Function.Call<bool>(Hash.IS_DISABLED_CONTROL_JUST_PRESSED, (InputArgument)0, (InputArgument)num31))
                                {
                                    if (!Common.buyBag)
                                    {
                                        Common.buyBag = true;
                                        num3 = --Common.sellerAvailableItems;
                                        Common.TotalPrice += InventoryBag.BagPrice;
                                        Function.Call(Hash.SET_TEXT_COLOUR, (InputArgument)0, (InputArgument)(int)byte.MaxValue, (InputArgument)0, (InputArgument)100);
                                        Notification.Show("Dufflebag has been ~g~added~w~ to your ~o~Cart", true);
                                    }
                                    else
                                    {
                                        Common.buyBag = false;
                                        num3 = ++Common.sellerAvailableItems;
                                        Common.TotalPrice -= InventoryBag.BagPrice;
                                        Function.Call(Hash.SET_TEXT_COLOUR, (InputArgument)(int)byte.MaxValue, (InputArgument)(int)sbyte.MaxValue, (InputArgument)80, (InputArgument)100);
                                        Notification.Show("Dufflebag has been ~r~removed~w~ from your ~o~Cart", true);
                                    }
                                }
                            }
                            else
                                Common.buyBag = false;
                        }
                        if (WeaponHolster.holster_module_active)
                        {
                            if (!WeaponHolster.hasHolster)
                            {
                                if (Function.Call<bool>(Hash.IS_DISABLED_CONTROL_JUST_PRESSED, (InputArgument)0, (InputArgument)num33))
                                {
                                    if (!Common.buyHolster)
                                    {
                                        Common.buyHolster = true;
                                        num3 = --Common.sellerAvailableItems;
                                        Common.TotalPrice += WeaponHolster.HolsterPrice;
                                        Function.Call(Hash.SET_TEXT_COLOUR, (InputArgument)0, (InputArgument)(int)byte.MaxValue, (InputArgument)0, (InputArgument)100);
                                        Notification.Show("Holster has been ~g~added~w~ to your ~o~Cart", true);
                                    }
                                    else
                                    {
                                        Common.buyHolster = false;
                                        num3 = ++Common.sellerAvailableItems;
                                        Common.TotalPrice -= WeaponHolster.HolsterPrice;
                                        Function.Call(Hash.SET_TEXT_COLOUR, (InputArgument)(int)byte.MaxValue, (InputArgument)(int)sbyte.MaxValue, (InputArgument)80, (InputArgument)100);
                                        Notification.Show("Holster has been ~r~removed~w~ from your ~o~Cart", true);
                                    }
                                }
                            }
                            else
                                Common.buyHolster = false;
                        }
                        if (WeaponJamming.jammingModeIsActive)
                        {
                            if (WeaponJamming.cleaningToolsCount < WeaponJamming.cleaningToolsMax)
                            {
                                if (Function.Call<bool>(Hash.IS_DISABLED_CONTROL_JUST_PRESSED, (InputArgument)0, (InputArgument)num34))
                                {
                                    if (!Common.buyTools)
                                    {
                                        Common.buyTools = true;
                                        num3 = --Common.sellerAvailableItems;
                                        Common.TotalPrice += WeaponJamming.weaponToolsPrice;
                                        Function.Call(Hash.SET_TEXT_COLOUR, (InputArgument)0, (InputArgument)(int)byte.MaxValue, (InputArgument)0, (InputArgument)100);
                                        Notification.Show("Weapon cleaning tools has been ~g~added~w~ to your ~o~Cart", true);
                                    }
                                    else
                                    {
                                        Common.buyTools = false;
                                        num3 = ++Common.sellerAvailableItems;
                                        Common.TotalPrice -= WeaponJamming.weaponToolsPrice;
                                        Function.Call(Hash.SET_TEXT_COLOUR, (InputArgument)(int)byte.MaxValue, (InputArgument)(int)sbyte.MaxValue, (InputArgument)80, (InputArgument)100);
                                        Notification.Show("Weapon cleaning tools has been ~r~removed~w~ from your ~o~Cart", true);
                                    }
                                }
                            }
                            else
                                Common.buyTools = false;
                        }
                        if (CigsAndPills.cigsCount < CigsAndPills.maxCigs || CigsAndPills.pillsCount < CigsAndPills.maxPills)
                        {
                            if (Function.Call<bool>(Hash.IS_DISABLED_CONTROL_JUST_PRESSED, (InputArgument)0, (InputArgument)num32))
                            {
                                if (!Common.buySupplies)
                                {
                                    Common.buySupplies = true;
                                    num3 = --Common.sellerAvailableItems;
                                    Common.TotalPrice += CigsAndPills.SupplyPrice;
                                    Function.Call(Hash.SET_TEXT_COLOUR, (InputArgument)0, (InputArgument)(int)byte.MaxValue, (InputArgument)0, (InputArgument)100);
                                    Notification.Show("Medical supplies has been ~g~added~w~ to your ~o~Cart", true);
                                }
                                else
                                {
                                    Common.buySupplies = false;
                                    num3 = ++Common.sellerAvailableItems;
                                    Common.TotalPrice -= CigsAndPills.SupplyPrice;
                                    Function.Call(Hash.SET_TEXT_COLOUR, (InputArgument)(int)byte.MaxValue, (InputArgument)(int)sbyte.MaxValue, (InputArgument)80, (InputArgument)100);
                                    Notification.Show("Medical supplies has been ~r~removed~w~ from your ~o~Cart", true);
                                }
                            }
                        }
                        else
                            Common.buySupplies = false;
                        if (Function.Call<bool>(Hash.IS_DISABLED_CONTROL_JUST_PRESSED, (InputArgument)0, (InputArgument)num35))
                        {
                            Common.sellerDialogCounter = 3;
                            Common.inProcessBag = true;
                            Common.canceled = true;
                        }
                        if (Function.Call<bool>(Hash.IS_DISABLED_CONTROL_JUST_PRESSED, (InputArgument)0, (InputArgument)num36))
                        {
                            Common.sellerDialogCounter = 7;
                            Common.inProcessBag = true;
                            if (Common.buyBag || Common.buyHolster || Common.buySupplies || Common.buyTools)
                                Common.canceled = false;
                        }
                        if (Function.Call<bool>(Hash.IS_PED_FACING_PED, (InputArgument)(Entity)Common.seller, (InputArgument)(Entity)Game.Player.Character, (InputArgument)10f))
                        {
                            if (!Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Game.Player.Character, (InputArgument)"oddjobs@assassinate@construction@", (InputArgument)"unarmed_fold_arms", (InputArgument)3))
                            {
                                Game.Player.Character.Task.LookAt((Entity)Common.seller);
                                Game.Player.Character.Task.PlayAnimation("oddjobs@assassinate@construction@", "unarmed_fold_arms", 3f, -1, AnimationFlags.Loop | AnimationFlags.UpperBodyOnly);
                            }
                        }
                        else
                        {
                            HTools.Main.DisableControlsFunc(true);
                            if (Common.timeOut > 0)
                                num3 = --Common.timeOut;
                            if (Common.timeOut <= 0)
                            {
                                if (!Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Game.Player.Character, (InputArgument)"oddjobs@assassinate@construction@", (InputArgument)"unarmed_fold_arms", (InputArgument)3))
                                {
                                    Game.Player.Character.Task.TurnTo((Entity)Common.seller);
                                    Common.seller.Task.TurnTo((Entity)Game.Player.Character);
                                    Common.timeOut = 200;
                                }
                                else
                                {
                                    Game.Player.Character.Task.ClearAll();
                                    Game.Player.Character.Task.TurnTo((Entity)Common.seller);
                                    Common.seller.Task.TurnTo((Entity)Game.Player.Character);
                                    Common.timeOut = 200;
                                }
                            }
                        }
                    }
                    else if (Common.canceled)
                    {
                        Function.Call(Hash.PLAY_MISSION_COMPLETE_AUDIO, (InputArgument)"TREVOR_SMALL_01");
                        Function.Call(Hash.PLAY_PED_AMBIENT_SPEECH_NATIVE, (InputArgument)(Entity)Game.Player.Character, (InputArgument)"GENERIC_NO", (InputArgument)"SPEECH_PARAMS_FORCE");
                        Script.Wait(1000);
                        Function.Call(Hash.PLAY_PED_AMBIENT_SPEECH_NATIVE, (InputArgument)(Entity)Game.Player.Character, (InputArgument)"GENERIC_BYE", (InputArgument)"SPEECH_PARAMS_FORCE");
                        Common.clearScriptFunction();
                    }
                    else if (Common.payed)
                    {
                        int num38 = 9999999;
                        if (Game.Player.Character.Model == (Model)PedHash.Michael || Game.Player.Character.Model == (Model)PedHash.Franklin || Game.Player.Character.Model == (Model)PedHash.Trevor)
                            num38 = Game.Player.Money;
                        if (num38 > Common.TotalPrice + Common.TotalPrice / 100 * 5)
                        {
                            vector3_1 = Game.Player.Character.Position;
                            if ((double)vector3_1.DistanceTo(Common.seller.Position) <= 5.0)
                            {
                                Common.sellerDialogFunc(Common.sellerDialogCounter, Common.buyHolster, Common.buyBag, Common.buySupplies, Common.seller, Common.buyTools, Common.doc);
                            }
                            else
                            {
                                if (Common.timeOut > 0)
                                    num3 = --Common.timeOut;
                                if (Common.timeOut <= 0)
                                {
                                    TaskInvoker task = Game.Player.Character.Task;
                                    Ped seller = Common.seller;
                                    vector3_1 = new Vector3();
                                    Vector3 offset = vector3_1;
                                    task.GoTo((Entity)seller, offset);
                                    Common.seller.Task.GoTo(Game.Player.Character.Position, 5000);
                                    Common.timeOut = 200;
                                }
                            }
                        }
                        else
                        {
                            HTools.Main.Notify("Transaction ~r~Failed", "MAZE", (int)byte.MaxValue, 0, 0, NotificationIcon.BankMaze);
                            HTools.Main.Notify("~o~Not enough money on your account", "MAZE", (int)byte.MaxValue, 0, 0, NotificationIcon.BankMaze);
                            Function.Call(Hash.PLAY_PED_AMBIENT_SPEECH_NATIVE, (InputArgument)(Entity)Common.seller, (InputArgument)"GENERIC_CURSE_MED", (InputArgument)"SPEECH_PARAMS_FORCE");
                            Function.Call(Hash.PLAY_PED_AMBIENT_SPEECH_NATIVE, (InputArgument)(Entity)Game.Player.Character, (InputArgument)"GAME_BAD_SELF", (InputArgument)"SPEECH_PARAMS_FORCE");
                            Common.clearScriptFunction();
                        }
                    }
                    else
                    {
                        if (Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Game.Player.Character, (InputArgument)"oddjobs@assassinate@construction@", (InputArgument)"unarmed_fold_arms", (InputArgument)3))
                        {
                            Game.Player.Character.Task.ClearAll();
                            Function.Call(Hash.PLAY_PED_AMBIENT_SPEECH_NATIVE, (InputArgument)(Entity)Game.Player.Character, (InputArgument)"GENERIC_YES", (InputArgument)"SPEECH_PARAMS_FORCE");
                        }
                        Screen.ShowHelpTextThisFrame("~BLIP_INFO_ICON~ Pay for purchases with your ~y~Phone");
                    }
                }
                if ((Entity)Common.seller != (Entity)null && !Common.greeting)
                {
                    vector3_1 = Game.Player.Character.Position;
                    if ((double)vector3_1.DistanceTo(Common.seller.Position) < 7.0)
                    {
                        if (Common.seller.IsOnFoot)
                            Common.greeting = true;
                        else if (Common.allowActionPerform(Common.seller, 100))
                            Common.seller.Task.LeaveVehicle();
                    }
                    else
                    {
                        vector3_1 = Game.Player.Character.Position;
                        if ((double)vector3_1.DistanceTo(Common.seller.Position) < 50.0)
                        {
                            if (Common.timeOut > 0)
                                num3 = --Common.timeOut;
                            if (Common.timeOut <= 0)
                            {
                                TaskInvoker task = Common.seller.Task;
                                Ped character = Game.Player.Character;
                                vector3_1 = new Vector3();
                                Vector3 offset = vector3_1;
                                task.GoTo((Entity)character, offset);
                                Common.timeOut = 200;
                            }
                        }
                    }
                }
                if (!Common.greeting || Common.greetingFinished)
                    return;
                vector3_1 = Game.Player.Character.Position;
                if ((double)vector3_1.DistanceTo(Common.seller.Position) > 50.0)
                    Common.clearScriptFunction();
                vector3_1 = Game.Player.Character.Position;
                if ((double)vector3_1.DistanceTo(Common.seller.Position) < 7.0)
                {
                    int num39 = Common.followCamera ? 1 : 0;
                    Common.camTimer = 0;
                }
                else
                    Common.greeting = false;
                if (!Common.greeting)
                    return;
                if (Common.timeOut > 0)
                    num3 = --Common.timeOut;
                vector3_1 = Common.seller.Position;
                if ((double)vector3_1.DistanceTo(Game.Player.Character.Position) >= 2.5)
                    return;
                Function.Call(Hash.PLAY_PED_AMBIENT_SPEECH_NATIVE, (InputArgument)(Entity)Game.Player.Character, (InputArgument)"GENERIC_HI", (InputArgument)"SPEECH_PARAMS_FORCE");
                Common.seller.Task.LookAt((Entity)Game.Player.Character, 1000);
                Function.Call(Hash.PLAY_PED_AMBIENT_SPEECH_NATIVE, (InputArgument)(Entity)Common.seller, (InputArgument)"GENERIC_HOWS_IT_GOING", (InputArgument)"SPEECH_PARAMS_FORCE");
                if (Common.sellerDialogCounter > 0)
                    return;
                Common.payed = false;
                Common.greetingFinished = true;
                Common.followCamera = false;
                Common.seller.Task.ClearAll();
                Game.Player.Character.Task.ClearAll();
                Common.deal = true;
                WeaponJamming.cleaningToolsCount = Common.getSupplies(Game.Player.Character, "weapon_tools");
                Common.inProcessBag = false;
                Common.update_inventory_status(Game.Player.Character);
                WeaponJamming.hasCleaningTools = Common.getSupplies(Game.Player.Character, "weapon_tools") > 0;
                InventoryBag.hasBag = InventoryBag.doesPedHasInventoryBag(Game.Player.Character);
                WeaponHolster.hasHolster = WeaponHolster.doesPedHasHolster(Game.Player.Character);
                if (!Common.buyBag && !InventoryBag.isBagBought)
                    num3 = ++Common.sellerAvailableItems;
                if (!Common.buyHolster && !WeaponHolster.hasHolster)
                    num3 = ++Common.sellerAvailableItems;
                if (!Common.buyTools && !WeaponJamming.hasCleaningTools)
                    num3 = ++Common.sellerAvailableItems;
                if (Common.buySupplies || CigsAndPills.cigsCount >= CigsAndPills.maxCigs && CigsAndPills.pillsCount >= CigsAndPills.maxPills)
                    return;
                num3 = ++Common.sellerAvailableItems;
            }
            else
                Common.clearScriptFunction();
        }
    }
}

