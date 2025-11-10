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
using System.Runtime.Remoting.Messaging;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GTAExpansion
{
    public class GTAExpansion : Script
    {
        public GTAExpansion() => this.Tick += new EventHandler(this.OnTick);

        private void OnTick(object sender, EventArgs e)
        {
            if (Game.IsPaused)
                return;
            Ped Player = Game.Player.Character;
            if (Player.IsDead)
                Player = Game.Player.Character;
            if (!Common.loaded)
            {
                AssetLoader.LoadAllAssetsOnce();
                
                Common.blipsRemove(BlipSprite.Information);
                if ((Entity)Player != (Entity)null)
                    InventoryBag.prevWeapon = Function.Call<uint>(Hash.GET_SELECTED_PED_WEAPON, (InputArgument)(Entity)Player);
                if (InventoryBag.doesPedHasInventoryBag(Player) && !Player.IsSittingInVehicle() && !Function.Call<bool>(Hash.IS_CUTSCENE_PLAYING) && Screen.IsFadedIn && Player.IsStopped && (Entity)InventoryBag.bagModelReturn(Player) == (Entity)null)
                {
                    InventoryBag.bagSet(InventoryBag.bagModelCheck(Player), Player);
                    Common.clearTrash();
                }
                InventoryBag.updateDuffleBagAttachPos(Player, false);
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
                Player.CanWearHelmet = false;
                if (HungerSystem.hungerModuleActive)
                {
                    HungerSystem.foodLeft = HungerSystem.getPedFoodCount(Player, "", Common.doc);
                    HungerSystem.drinksLeft = HungerSystem.getPedDrinksCount(Player, "", Common.doc);
                    //Blips.InitializeStoreLocations();
                    //Blips.UpdateStoreBlips();
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
                WeaponJamming.createWeaponConditionStructure(Player, Common.doc);
            }
            if (CigsAndPills.smoke == 0 || CigsAndPills.smoke == 1)
            {
                if (CigsAndPills.startSmoke)
                {
                    if (!HTools.Main.isOccupiedNative(Player) && (WeaponHash)Player.Weapons.Current == WeaponHash.Unarmed && !Common.inMainMenu && !InventoryBag.inMenu && Game.Player.CanControlCharacter)
                        CigsAndPills.StartSmokeFunc(Player, 0);
                }
                else if (CigsAndPills.smoke == 1 && !HTools.Main.isOccupiedNative(Player) && (WeaponHash)Player.Weapons.Current == WeaponHash.Unarmed && !Common.inMainMenu && !InventoryBag.inMenu && !WeaponJamming.isCleaningJammedGun && !Player.IsSprinting && !Player.IsWalking && !Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Player, (InputArgument)"amb@code_human_in_car_mp_actions@first_person@smoke@std@ds@base", (InputArgument)"exit", (InputArgument)3) && !Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Player, (InputArgument)"amb@world_human_smoking@male@male_a@exit", (InputArgument)"exit", (InputArgument)3) && !Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Player, (InputArgument)"amb@world_human_leaning@female@smoke@exit", (InputArgument)"exit", (InputArgument)3))
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
                if (Player.IsSittingInVehicle())
                {
                    Common.main_menu_btn = Common.main_menu_btn_in_vehicle;
                }
                else
                {
                    Common.main_menu_btn = Common.main_menu_btn_on_foot;
                    Player.CanWearHelmet = false;
                }
                if ((Entity)Player != (Entity)null)
                {
                    CigsAndPills.cigsCount = Common.getSupplies(Player, "ciggaretes");
                    CigsAndPills.pillsCount = Common.getSupplies(Player, "painkillers");
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
                if ((Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Player, (InputArgument)"amb@world_human_smoking@male@male_a@idle_a", (InputArgument)"idle_c", (InputArgument)3) || Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Player, (InputArgument)"amb@world_human_leaning@female@smoke@idle_a", (InputArgument)"idle_b", (InputArgument)3) || Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Player, (InputArgument)"amb@world_human_smoking@male@male_b@idle_a", (InputArgument)"idle_a", (InputArgument)3) || Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Player, (InputArgument)"amb@world_human_smoking@female@idle_a", (InputArgument)"idle_b", (InputArgument)3) || Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Player, (InputArgument)"amb@code_human_in_car_mp_actions@first_person@smoke@std@ds@base", (InputArgument)"idle_a", (InputArgument)3) || CigsAndPills.smoke == -1 || CigsAndPills.startSmoke) && false)
                {
                    CigsAndPills.smoke = -1;
                    CigsAndPills.startSmoke = true;
                    if ((Entity)CigsAndPills.cig != (Entity)null)
                    {
                        CigsAndPills.cig.MarkAsNoLongerNeeded();
                        CigsAndPills.cig = (Prop)null;
                    }
                }
                if (CigsAndPills.smoke != 1 && (Entity)CigsAndPills.cig == (Entity)null && Function.Call<bool>(Hash.DOES_OBJECT_OF_TYPE_EXIST_AT_COORDS, (InputArgument)Player.Position.X, (InputArgument)Player.Position.Y, (InputArgument)Player.Position.Z, (InputArgument)3f, (InputArgument)HTools.Main.GetHashKey(CigsAndPills.smokeType), (InputArgument)0))
                {
                    Prop prop = Function.Call<Prop>(Hash.GET_CLOSEST_OBJECT_OF_TYPE, (InputArgument)Player.Position.X, (InputArgument)Player.Position.Y, (InputArgument)Player.Position.Z, (InputArgument)3f, (InputArgument)HTools.Main.GetHashKey(CigsAndPills.smokeType), (InputArgument)true, (InputArgument)false, (InputArgument)false);
                    if (Function.Call<bool>(Hash.IS_ENTITY_ATTACHED_TO_ENTITY, (InputArgument)(Entity)prop, (InputArgument)(Entity)Player))
                    {
                        if ((Entity)CigsAndPills.cig == (Entity)null)
                            CigsAndPills.cig = prop;
                        CigsAndPills.smoke = 1;
                        CigsAndPills.startSmoke = false;
                    }
                }
                if (Function.Call<Prop>(Hash.GET_CLOSEST_OBJECT_OF_TYPE, (InputArgument)Player.Position.X, (InputArgument)Player.Position.Y, (InputArgument)Player.Position.Z, (InputArgument)3f, (InputArgument)HTools.Main.GetHashKey(CigsAndPills.smokeType), (InputArgument)true, (InputArgument)false, (InputArgument)false).Exists())
                {
                    Prop prop = Function.Call<Prop>(Hash.GET_CLOSEST_OBJECT_OF_TYPE, (InputArgument)Player.Position.X, (InputArgument)Player.Position.Y, (InputArgument)Player.Position.Z, (InputArgument)3f, (InputArgument)HTools.Main.GetHashKey(CigsAndPills.smokeType), (InputArgument)true, (InputArgument)false, (InputArgument)false);
                    if ((Entity)prop != (Entity)CigsAndPills.cig && Function.Call<bool>(Hash.IS_ENTITY_ATTACHED_TO_ENTITY, (InputArgument)(Entity)prop, (InputArgument)(Entity)Player) && prop.Exists())
                        prop.Delete();
                }
                if ((CigsAndPills.smoke == 1 || CigsAndPills.smoke == 0) && Common.curVehicleIsCar(Player))
                {
                    int type = Player.IsSittingInVehicle() ? 2 : 1;
                    switch (CigsAndPills.smoke)
                    {
                        case 0:
                            if (!HTools.Main.isOccupiedNative(Player) && (Player.IsSittingInVehicle() || !Player.IsSittingInVehicle() && (WeaponHash)Player.Weapons.Current == WeaponHash.Unarmed) && !Common.inMainMenu && Game.Player.CanControlCharacter)
                            {
                                CigsAndPills.StopSmokeFunc(Player, type);
                                break;
                            }
                            break;
                        case 1:
                            if ((Entity)CigsAndPills.cig == (Entity)null)
                            {
                                CigsAndPills.cig = World.CreateProp((Model)CigsAndPills.smokeType, Player.Position, true, false);
                                if ((Entity)CigsAndPills.cig != (Entity)null)
                                    CigsAndPills.cig.IsVisible = false;
                                Function.Call(Hash.SET_ENTITY_NO_COLLISION_ENTITY, (InputArgument)(Entity)CigsAndPills.cig, (InputArgument)(Entity)Player, (InputArgument)true);
                                if (Player.IsSittingInVehicle() && (Entity)Player.CurrentVehicle != (Entity)null)
                                {
                                    Function.Call(Hash.SET_ENTITY_NO_COLLISION_ENTITY, (InputArgument)(Entity)CigsAndPills.cig, (InputArgument)(Entity)Player.CurrentVehicle, (InputArgument)true);
                                    if (!Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Player, (InputArgument)"mp_arrest_paired", (InputArgument)"cop_p1_rf_right_0", (InputArgument)3))
                                        Function.Call(Hash.TASK_PLAY_ANIM, (InputArgument)(Entity)Player, (InputArgument)"mp_arrest_paired", (InputArgument)"cop_p1_rf_right_0", (InputArgument)7f, (InputArgument)(-12.0), (InputArgument)(-1), (InputArgument)48, (InputArgument)0.0f, (InputArgument)0, (InputArgument)0, (InputArgument)0);
                                }
                                int num = Function.Call<int>(Hash.GET_PED_BONE_INDEX, (InputArgument)(Entity)Player, (InputArgument)64017);
                                if (Function.Call<bool>(Hash.IS_PED_MALE, (InputArgument)(Entity)Player))
                                    Function.Call(Hash.ATTACH_ENTITY_TO_ENTITY, (InputArgument)(Entity)CigsAndPills.cig, (InputArgument)(Entity)Player, (InputArgument)num, (InputArgument)0.017, (InputArgument)(-0.01), (InputArgument)0.0, (InputArgument)0.0, (InputArgument)(-120.0), (InputArgument)(-90.0), (InputArgument)false, (InputArgument)false, (InputArgument)false, (InputArgument)false, (InputArgument)2, (InputArgument)true);
                                else
                                    Function.Call(Hash.ATTACH_ENTITY_TO_ENTITY, (InputArgument)(Entity)CigsAndPills.cig, (InputArgument)(Entity)Player, (InputArgument)num, (InputArgument)0.017, (InputArgument)(-0.01), (InputArgument)0.0, (InputArgument)0.0, (InputArgument)0.0, (InputArgument)(-90.0), (InputArgument)false, (InputArgument)false, (InputArgument)false, (InputArgument)false, (InputArgument)2, (InputArgument)true);
                            }
                            if ((Entity)CigsAndPills.cig != (Entity)null && !CigsAndPills.startSmoke)
                            {
                                if (!HTools.Main.isOccupiedNative(Player) && (Player.IsSittingInVehicle() || !Player.IsSittingInVehicle() && (WeaponHash)Player.Weapons.Current == WeaponHash.Unarmed) && !Game.IsControlJustPressed(Control.VehicleHandbrake) && !Game.IsControlJustPressed(Control.VehicleHorn) && !Game.IsControlJustPressed(Control.VehicleHeadlight) && !Game.IsControlJustPressed(Control.Enter) && !Game.IsControlJustPressed(Control.VehicleExit) && Game.Player.CanControlCharacter && !Common.inMainMenu && !InventoryBag.inMenu && !HungerSystem.isEating && !HungerSystem.isDrinking && !Player.IsSprinting && !Player.IsWalking)
                                {
                                    if (CigsAndPills.cig_durability > 0)
                                        CigsAndPills.SmokeLoopFunc(Player, type);
                                    else
                                        CigsAndPills.StopSmokeFunc(Player, type);
                                }
                                else
                                    CigsAndPills.PauseSmokeFunc(Player, type);
                                if ((Entity)CigsAndPills.cig != (Entity)null)
                                {
                                    CigsAndPills.SmokeProceEffectsFunc(Player, type, CigsAndPills.cig);
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
                    if (Function.Call<bool>(Hash.IS_PLAYER_BEING_ARRESTED, (InputArgument)(Entity)Player, (InputArgument)0) && !Game.IsMissionActive)
                    {
                        if (InventoryBag.doesPedHasInventoryBag(Player))
                            InventoryBag.looseBagFunc(Player, InventoryBag.bagModelReturn(Player));
                    }
                    else if (InventoryBag.can_loose_bag)
                    {
                        if (Player.IsRagdoll && !Player.IsDead && Player.Health > 0)
                        {
                            if (InventoryBag.doesPedWearingBag(Player))
                            {
                                Prop bag = InventoryBag.bagModelReturn(Player);
                                if ((Entity)bag != (Entity)null)
                                {
                                    int num = Common.rnd.Next(1, 4);
                                    if (!InventoryBag.DropChanceCounted && num == 1)
                                    {
                                        InventoryBag.DropChanceCounted = true;
                                        InventoryBag.DropBagFunc(Player, bag);
                                    }
                                }
                            }
                        }
                        else
                            InventoryBag.DropChanceCounted = false;
                    }
                }
               
            }
            if (Function.Call<bool>(Hash.IS_DISABLED_CONTROL_PRESSED, (InputArgument)0, (InputArgument)Common.main_menu_btn) && !Common.inMainMenu && !InventoryBag.inMenu && !FocusMode.targetsPicked && !WeaponJamming.isCleaningJammedGun && !Wallet.inProcessWallet && !WeaponHolster.intimidation && !Common.deal && !Common.findSellerOption && !Common.pedIsNearShopkeeper)
                Common.Draw(5);
            if (Function.Call<bool>(Hash.IS_DISABLED_CONTROL_PRESSED, (InputArgument)0, (InputArgument)Common.main_menu_btn) && Function.Call<bool>(Hash.IS_DISABLED_CONTROL_JUST_PRESSED, (InputArgument)0, (InputArgument)Common.main_menu_sec_btn) && !FocusMode.targetsPicked && !Common.inMainMenu && !InventoryBag.inMenu && !Wallet.inProcessWallet && !WeaponHolster.intimidation && !Common.deal && !Common.findSellerOption && !Common.pedIsNearShopkeeper)
            {
                Common.update_inventory_status(Player);
                if (HungerSystem.hungerModuleActive)
                {
                    HungerSystem.foodLeft = HungerSystem.getPedFoodCount(Player, "", Common.doc);
                    HungerSystem.drinksLeft = HungerSystem.getPedDrinksCount(Player, "", Common.doc);
                }
                Function.Call(Hash.PLAY_SOUND_FRONTEND, (InputArgument)(-1), (InputArgument)"FocusIn", (InputArgument)"HintCamSounds");
                Common.inMainMenu = true;
                Player.Weapons.Select(WeaponHash.Unarmed);
                if (!HTools.Main.barPool.ToList().Contains(HungerSystem.thirstBar))
                    HTools.Main.barPool.Add(HungerSystem.thirstBar);
                if (!HTools.Main.barPool.ToList().Contains(HungerSystem.hungerBar))
                    HTools.Main.barPool.Add(HungerSystem.hungerBar);


            }
            Model model;
            if (Common.inMainMenu)
            {
                HTools.Main.DisableControlsFunc(true);
                if (Common.curVehicleIsCar(Player) && !Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Player, (InputArgument)"anim@scripted@heist@ig1_table_grab@gold@male@", (InputArgument)"enter", (InputArgument)3))
                {
                    Prop prop = InventoryBag.bagModelReturn(Player);
                    if ((Entity)prop != (Entity)null)
                    {
                        int num = Function.Call<int>(Hash.GET_PED_BONE_INDEX, (InputArgument)(Entity)Player, (InputArgument)11816);
                        Function.Call(Hash.ATTACH_ENTITY_TO_ENTITY, (InputArgument)(Entity)prop, (InputArgument)(Entity)Player, (InputArgument)num, (InputArgument)0.2f, (InputArgument)(-0.35f), (InputArgument)0.1f, (InputArgument)(-20f), (InputArgument)110f, (InputArgument)90f, (InputArgument)true, (InputArgument)true, (InputArgument)false, (InputArgument)false, (InputArgument)2, (InputArgument)true);
                    }
                    Player.Task.PlayAnimation("anim@scripted@heist@ig1_table_grab@gold@male@", "enter", 8f, -1, AnimationFlags.StayInEndFrame | AnimationFlags.UpperBodyOnly | AnimationFlags.Secondary);
                }
                Common.Draw(4, InventoryBag.hasBag, InventoryBag.canTakeBagFromVehicle, WeaponHolster.hasHolster, InventoryBag.isBagBought, InventoryBag.isBagDropped, action_page: Common.cur_action_page);
                if ((WeaponHash)Player.Weapons.Current != WeaponHash.Unarmed)
                    Player.Weapons.Select(WeaponHash.Unarmed);
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
                    Player.Task.ClearAll();
                    InventoryBag.checkEquipedGear(Player);
                    if (HTools.Main.barPool.ToList().Contains(HungerSystem.thirstBar))
                        HTools.Main.barPool.Remove(HungerSystem.thirstBar);
                    if (HTools.Main.barPool.ToList().Contains(HungerSystem.hungerBar))
                        HTools.Main.barPool.Remove(HungerSystem.hungerBar);
                }
                if (Common.cur_action_page == 0)
                {
                    if (!Player.IsWearingHelmet && Function.Call<bool>(Hash.IS_DISABLED_CONTROL_JUST_PRESSED, (InputArgument)0, (InputArgument)Helmet.helmet_on_btn))
                    {
                        Function.Call(Hash.SET_PED_HELMET_TEXTURE_INDEX, (InputArgument)(Entity)Player, (InputArgument)0);
                        Function.Call(Hash.SET_PED_HELMET, (InputArgument)(Entity)Player, (InputArgument)true);
                    }
                    if (InventoryBag.bag_module_active)
                    {
                        if (Function.Call<bool>(Hash.IS_DISABLED_CONTROL_JUST_PRESSED, (InputArgument)0, (InputArgument)InventoryBag.bag_coords_update_btn) && InventoryBag.hasBag)
                        {
                            Common.inMainMenu = false;
                            InventoryBag.checkEquipedGear(Player);
                            InventoryBag.updateDuffleBagAttachPos(Player);
                            Player.Task.ClearAll();
                        }
                        if (InventoryBag.hasBag)
                        {
                            if (Function.Call<bool>(Hash.IS_DISABLED_CONTROL_JUST_PRESSED, (InputArgument)0, (InputArgument)InventoryBag.bag_menu_btn))
                            {
                                Common.inMainMenu = false;
                                Player.Task.ClearAll();
                                InventoryBag.inMenu = true;
                                InventoryBag.reattached = false;
                            }
                        }
                        else if (InventoryBag.canTakeBagFromVehicle && Function.Call<bool>(Hash.IS_DISABLED_CONTROL_JUST_PRESSED, (InputArgument)0, (InputArgument)InventoryBag.bag_menu_btn))
                            InventoryBag.bagSet(InventoryBag.bagModelCheck(Player), Player);
                    }
                    if (Vest.vest_module_active)
                    {
                        if (Function.Call<bool>(Hash.IS_DISABLED_CONTROL_JUST_PRESSED, (InputArgument)0, (InputArgument)Vest.vest_menu_btn) && Vest.HasPedBoughtVest(Player))
                        {
                            Common.inMainMenu = false;
                            Player.Task.ClearAll();
                            Vest.inMenu = true;
                        }
                        

                    }
                    if (WeaponHolster.holster_module_active && !Function.Call<bool>(Hash.IS_PED_RUNNING_MOBILE_PHONE_TASK, (InputArgument)(Entity)Player) && !Function.Call<bool>(Hash.IS_PED_RUNNING_RAGDOLL_TASK, (InputArgument)(Entity)Player) && !Function.Call<bool>(Hash.IS_PLAYER_FREE_AIMING, (InputArgument)Game.Player) && Player.IsOnFoot)
                    {
                        if (Function.Call<bool>(Hash.IS_DISABLED_CONTROL_JUST_PRESSED, (InputArgument)0, (InputArgument)WeaponHolster.intimidate_btn))
                        {
                            Common.inMainMenu = false;
                            InventoryBag.checkEquipedGear(Player);
                            Player.Task.ClearAll();
                            if (WeaponHolster.hasHolster && (Entity)WeaponHolster.holster != (Entity)null && WeaponHolster.holster.Exists() && Function.Call<uint>(Hash.GET_SELECTED_PED_WEAPON, (InputArgument)(Entity)Player) == 2725352035U)
                            {
                                if (WeaponHolster.intimidation)
                                {
                                    Array.Clear((Array)WeaponHolster.closestPeds, 0, WeaponHolster.closestPeds.Length);
                                    if (Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Player, (InputArgument)"move_m@intimidation@cop@unarmed", (InputArgument)"idle", (InputArgument)3) || Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Player, (InputArgument)"reaction@intimidation@cop@unarmed", (InputArgument)"intro", (InputArgument)3) || Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Player, (InputArgument)"reaction@intimidation@cop@unarmed", (InputArgument)"outro", (InputArgument)3))
                                    {
                                        Function.Call(Hash.STOP_ENTITY_ANIM, (InputArgument)(Entity)Player, (InputArgument)"idle", (InputArgument)"move_m@intimidation@cop@unarmed", (InputArgument)3);
                                        Function.Call(Hash.STOP_ENTITY_ANIM, (InputArgument)(Entity)Player, (InputArgument)"intro", (InputArgument)"reaction@intimidation@cop@unarmed", (InputArgument)3);
                                        Function.Call(Hash.STOP_ENTITY_ANIM, (InputArgument)(Entity)Player, (InputArgument)"outro", (InputArgument)"reaction@intimidation@cop@unarmed", (InputArgument)3);
                                    }
                                }
                                else if (!Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Player, (InputArgument)"move_m@intimidation@cop@unarmed", (InputArgument)"idle", (InputArgument)3) && !Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Player, (InputArgument)"reaction@intimidation@cop@unarmed", (InputArgument)"intro", (InputArgument)3) && !Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Player, (InputArgument)"reaction@intimidation@cop@unarmed", (InputArgument)"outro", (InputArgument)3))
                                {
                                    WeaponHolster.AttackSpeech(Player);
                                    Player.CanPlayGestures = false;
                                    WeaponHolster.GetClosestPedDetectionFunction(Player);
                                    Player.Task.PlayAnimation("move_m@intimidation@cop@unarmed", "idle", 12f, -1, AnimationFlags.StayInEndFrame | AnimationFlags.Secondary | AnimationFlags.AbortOnPedMovement);
                                    WeaponHolster.intimidation = true;
                                }
                            }
                        }
                        if (Function.Call<bool>(Hash.IS_DISABLED_CONTROL_JUST_PRESSED, (InputArgument)0, (InputArgument)WeaponHolster.holster_toggle_btn))
                        {
                            Common.inMainMenu = false;
                            InventoryBag.checkEquipedGear(Player);
                            Player.Task.ClearAll();
                            if (WeaponHolster.hasHolster)
                            {
                                string str = "prop_holster_01";
                                if (!WeaponHolster.useHipHolster)
                                    str = "prop_pistol_holster";
                                if (Function.Call<Prop>(Hash.GET_CLOSEST_OBJECT_OF_TYPE, (InputArgument)Player.Position.X, (InputArgument)Player.Position.Y, (InputArgument)Player.Position.Z, (InputArgument)3f, (InputArgument)HTools.Main.GetHashKey(str), (InputArgument)true, (InputArgument)false, (InputArgument)false).Exists())
                                {
                                    Prop prop = Function.Call<Prop>(Hash.GET_CLOSEST_OBJECT_OF_TYPE, (InputArgument)Player.Position.X, (InputArgument)Player.Position.Y, (InputArgument)Player.Position.Z, (InputArgument)3f, (InputArgument)HTools.Main.GetHashKey(str), (InputArgument)true, (InputArgument)false, (InputArgument)false);
                                    if (Function.Call<bool>(Hash.IS_ENTITY_ATTACHED_TO_ENTITY, (InputArgument)(Entity)prop, (InputArgument)(Entity)Player))
                                    {
                                        WeaponHolster.holster = prop;
                                        WeaponHolster.UnsetHolster(Player, WeaponHolster.useHipHolster);
                                    }
                                    else
                                        WeaponHolster.SetHolster(Player);
                                }
                                else
                                    WeaponHolster.SetHolster(Player);
                            }
                        }
                    }
                }
                if (Common.cur_action_page == 1)
                {
                    if (!Function.Call<bool>(Hash.IS_PED_RUNNING_MOBILE_PHONE_TASK, (InputArgument)(Entity)Player) && !Function.Call<bool>(Hash.IS_PED_RUNNING_RAGDOLL_TASK, (InputArgument)(Entity)Player) && !Function.Call<bool>(Hash.IS_PED_DOING_DRIVEBY, (InputArgument)(Entity)Player) && !Function.Call<bool>(Hash.IS_PLAYER_FREE_AIMING, (InputArgument)Game.Player))
                    {
                        model = Player.Model;
                        if (model.Hash != HTools.Main.GetHashKey("mp_m_freemode_01"))
                        {
                            model = Player.Model;
                            if (model.Hash != HTools.Main.GetHashKey("mp_f_freemode_01"))
                            {
                                model = Player.Model;
                                if (model.Hash != HTools.Main.GetHashKey("PLAYER_ZERO"))
                                {
                                    model = Player.Model;
                                    if (model.Hash != HTools.Main.GetHashKey("PLAYER_ONE"))
                                    {
                                        model = Player.Model;
                                        if (model.Hash != HTools.Main.GetHashKey("PLAYER_TWO"))
                                            goto label_195;
                                    }
                                }
                            }
                        }
                        OnFootRadio.headset = Function.Call<int>(Hash.GET_PED_PROP_INDEX, (InputArgument)(Entity)Player, (InputArgument)2) == 0;
                        
                    label_195:
                        bool hasboughtheadset = OnFootRadio.HasPedBoughtHeadset(Player);
                        if (Function.Call<bool>(Hash.IS_DISABLED_CONTROL_JUST_PRESSED, (InputArgument)0, (InputArgument)OnFootRadio.earphone_toggle_btn) && hasboughtheadset )
                        {
                            Common.inMainMenu = false;
                            InventoryBag.checkEquipedGear(Player);
                            Player.Task.ClearAll();
                            Function.Call(Hash.SET_CURRENT_PED_WEAPON, (InputArgument)(Entity)Player, (InputArgument)2725352035U, (InputArgument)true);
                            Script.Wait(100);
                            string animDict = "anim@cellphone@in_car@ds";

                         
                           

                            if (Player.IsSittingInVehicle() && !Function.Call<bool>(Hash.IS_THIS_MODEL_A_QUADBIKE, (InputArgument)Function.Call<int>(Hash.GET_ENTITY_MODEL, (InputArgument)(Entity)Player.CurrentVehicle)) && !Function.Call<bool>(Hash.IS_THIS_MODEL_A_BICYCLE, (InputArgument)Function.Call<int>(Hash.GET_ENTITY_MODEL, (InputArgument)(Entity)Player.CurrentVehicle)) && !Function.Call<bool>(Hash.IS_PED_ON_ANY_BIKE, (InputArgument)(Entity)Player))
                            {
                                Player.Task.ClearAll();
                                Function.Call(Hash.TASK_PLAY_ANIM, (InputArgument)(Entity)Player, (InputArgument)"anim@cellphone@in_car@ds", (InputArgument)"cellphone_text_to_call", (InputArgument)45f, (InputArgument)(-12.0), (InputArgument)(-1), (InputArgument)48, (InputArgument)0.0f, (InputArgument)0, (InputArgument)0, (InputArgument)0);
                            }
                            else if (!Player.IsSittingInVehicle() && !Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Player, (InputArgument)"anim@cellphone@in_car@ds", (InputArgument)"cellphone_text_to_call", (InputArgument)3))
                                Function.Call(Hash.TASK_PLAY_ANIM, (InputArgument)(Entity)Player, (InputArgument)"anim@cellphone@in_car@ds", (InputArgument)"cellphone_text_to_call", (InputArgument)45f, (InputArgument)(-12.0), (InputArgument)(-1), (InputArgument)48, (InputArgument)0.0f, (InputArgument)0, (InputArgument)0, (InputArgument)0);
                            HTools.Main.soundFX(Player, "beep.wav", Common.assetFolder);
                            if (!OnFootRadio.headset)
                            {
                                Function.Call(Hash.SET_TEXT_COLOUR, (InputArgument)0, (InputArgument)(int)byte.MaxValue, (InputArgument)0, (InputArgument)100);
                                Notification.Show("Mobile radio is ~g~available", true);
                                try
                                {
                                    Function.Call(Hash.SET_PED_PROP_INDEX, (InputArgument)(Entity)Player, (InputArgument)2, (InputArgument)0, (InputArgument)0);
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
                                Function.Call(Hash.CLEAR_PED_PROP, (InputArgument)(Entity)Player, (InputArgument)2);
                                OnFootRadio.headset = false;
                                Function.Call(Hash.SET_RADIO_TO_STATION_NAME, (InputArgument)"OFF");
                                Function.Call(Hash.SET_MOBILE_RADIO_ENABLED_DURING_GAMEPLAY, (InputArgument)false);
                            }
                        }
                        if (OnFootRadio.headset && Function.Call<bool>(Hash.IS_DISABLED_CONTROL_JUST_PRESSED, (InputArgument)0, (InputArgument)OnFootRadio.readio_off_btn) && !Function.Call<bool>(Hash.IS_PED_RUNNING_MOBILE_PHONE_TASK, (InputArgument)(Entity)Player) && !Function.Call<bool>(Hash.IS_PED_RUNNING_RAGDOLL_TASK, (InputArgument)(Entity)Player) && !Function.Call<bool>(Hash.IS_PED_DOING_DRIVEBY, (InputArgument)(Entity)Player) && !Function.Call<bool>(Hash.IS_PLAYER_FREE_AIMING, (InputArgument)Game.Player))
                        {
                            Common.inMainMenu = false;
                            InventoryBag.checkEquipedGear(Player);
                            Player.Task.ClearAll();
                            if (Player.IsSittingInVehicle() && !Function.Call<bool>(Hash.IS_THIS_MODEL_A_QUADBIKE, (InputArgument)Function.Call<int>(Hash.GET_ENTITY_MODEL, (InputArgument)(Entity)Player.CurrentVehicle)) && !Function.Call<bool>(Hash.IS_THIS_MODEL_A_BICYCLE, (InputArgument)Function.Call<int>(Hash.GET_ENTITY_MODEL, (InputArgument)(Entity)Player.CurrentVehicle)) && !Function.Call<bool>(Hash.IS_PED_ON_ANY_BIKE, (InputArgument)(Entity)Player))
                            {
                                Player.Task.ClearAll();
                                Function.Call(Hash.TASK_PLAY_ANIM, (InputArgument)(Entity)Player, (InputArgument)"anim@cellphone@in_car@ds", (InputArgument)"cellphone_text_to_call", (InputArgument)45f, (InputArgument)(-12.0), (InputArgument)(-1), (InputArgument)48, (InputArgument)0.0f, (InputArgument)0, (InputArgument)0, (InputArgument)0);
                            }
                            else if (!Player.IsSittingInVehicle() && !Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Player, (InputArgument)"anim@cellphone@in_car@ds", (InputArgument)"cellphone_text_to_call", (InputArgument)3))
                                Function.Call(Hash.TASK_PLAY_ANIM, (InputArgument)(Entity)Player, (InputArgument)"anim@cellphone@in_car@ds", (InputArgument)"cellphone_text_to_call", (InputArgument)45f, (InputArgument)(-12.0), (InputArgument)(-1), (InputArgument)48, (InputArgument)0.0f, (InputArgument)0, (InputArgument)0, (InputArgument)0);
                            if (!Function.Call<bool>(Hash.IS_MOBILE_PHONE_RADIO_ACTIVE))
                            {
                                Function.Call(Hash.SET_MOBILE_RADIO_ENABLED_DURING_GAMEPLAY, (InputArgument)true);
                                if (OnFootRadio.prevStation != (int)byte.MaxValue)
                                    Function.Call(Hash.SET_RADIO_TO_STATION_INDEX, (InputArgument)OnFootRadio.prevStation);
                                else
                                    Function.Call(Hash.SET_RADIO_TO_STATION_INDEX, (InputArgument)0);
                                HTools.Main.soundFX(Player, "beep.wav", Common.assetFolder);
                            }
                            else
                            {
                                HTools.Main.soundFX(Player, "beep.wav", Common.assetFolder);
                                OnFootRadio.prevStation = Function.Call<int>(Hash.GET_PLAYER_RADIO_STATION_INDEX);
                                Function.Call(Hash.SET_RADIO_TO_STATION_INDEX, (InputArgument)(int)byte.MaxValue);
                                Function.Call(Hash.SET_MOBILE_RADIO_ENABLED_DURING_GAMEPLAY, (InputArgument)false);
                            }
                        }
                    }
                    if (Function.Call<bool>(Hash.IS_DISABLED_CONTROL_PRESSED, (InputArgument)0, (InputArgument)Wallet.wallet_btn) && !Function.Call<bool>(Hash.IS_PED_RUNNING_MOBILE_PHONE_TASK, (InputArgument)(Entity)Player) && Player.IsOnFoot && !Player.IsRagdoll && !CigsAndPills.smoking)
                    {
                        Common.inMainMenu = false;
                        InventoryBag.checkEquipedGear(Player);
                        Player.Task.ClearAll();
                        if (!Function.Call<bool>(Hash.IS_PED_RUNNING_MOBILE_PHONE_TASK, (InputArgument)(Entity)Player) && !Function.Call<bool>(Hash.IS_PLAYER_FREE_AIMING, (InputArgument)(Entity)Player) && !Function.Call<bool>(Hash.IS_CUTSCENE_PLAYING) && !Player.IsSittingInVehicle() && !Player.IsSwimming && !Player.IsSwimmingUnderWater && !Player.IsJumping && !Player.IsRagdoll && !Player.IsBeingStunned && !Player.IsClimbing && !Player.IsDiving && !Player.IsFalling && !Player.IsGettingIntoVehicle && !Player.IsInAir && Player.IsOnFoot && Player.IsIdle)
                        {
                            Wallet.inProcessWallet = true;
                            Wallet.walletCount = false;
                            Function.Call(Hash.SET_CURRENT_PED_WEAPON, (InputArgument)(Entity)Player, (InputArgument)2725352035U, (InputArgument)true);
                            Function.Call(Hash.SET_PED_CAN_PLAY_GESTURE_ANIMS, (InputArgument)(Entity)Player, (InputArgument)false);
                            if (!Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Player, (InputArgument)"amb@world_human_smoking@male@male_a@idle_a", (InputArgument)"idle_c", (InputArgument)3) && !Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Player, (InputArgument)"amb@world_human_leaning@female@smoke@idle_a", (InputArgument)"idle_b", (InputArgument)3) && !Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Player, (InputArgument)"amb@world_human_smoking@male@male_b@idle_a", (InputArgument)"idle_a", (InputArgument)3) && !Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Player, (InputArgument)"mp_player_inteat@pnq", (InputArgument)"loop_fp", (InputArgument)3) && !Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Player, (InputArgument)"amb@world_human_smoking@female@idle_a", (InputArgument)"idle_b", (InputArgument)3))
                            {
                                if (!Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Player, (InputArgument)"mp_arrest_paired", (InputArgument)"cop_p1_rf_right_0", (InputArgument)3))
                                {
                                    Function.Call(Hash.TASK_PLAY_ANIM, (InputArgument)(Entity)Player, (InputArgument)"mp_arrest_paired", (InputArgument)"cop_p1_rf_right_0", (InputArgument)4f, (InputArgument)(-4f), (InputArgument)(-1), (InputArgument)50, (InputArgument)0.0f, (InputArgument)0, (InputArgument)0, (InputArgument)0);
                                    Script.Wait(500);
                                    if (Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Player, (InputArgument)"mp_arrest_paired", (InputArgument)"cop_p1_rf_right_0", (InputArgument)3))
                                        Player.Task.ClearAnimation("mp_arrest_paired", "cop_p1_rf_right_0");
                                }
                                HTools.Main.soundFX(Player, "grab.wav", Common.assetFolder);
                                Wallet.wallet = World.CreateProp((Model)"prop_ld_wallet_02", Player.Position, true, false);
                                Wallet.walletOpened = World.CreateProp((Model)"prop_ld_wallet_pickup", Player.Position, true, false);
                                Function.Call(Hash.SET_ENTITY_NO_COLLISION_ENTITY, (InputArgument)(Entity)Wallet.wallet, (InputArgument)(Entity)Player, (InputArgument)true);
                                int num1 = Function.Call<int>(Hash.GET_PED_BONE_INDEX, (InputArgument)(Entity)Player, (InputArgument)36029);
                                int num2 = Function.Call<int>(Hash.GET_PED_BONE_INDEX, (InputArgument)(Entity)Player, (InputArgument)6286);
                                if ((Entity)Wallet.wallet == (Entity)null && Function.Call<bool>(Hash.DOES_OBJECT_OF_TYPE_EXIST_AT_COORDS, (InputArgument)Player.Position.X, (InputArgument)Player.Position.Y, (InputArgument)Player.Position.Z, (InputArgument)3f, (InputArgument)HTools.Main.GetHashKey("prop_ld_wallet_02"), (InputArgument)0))
                                {
                                    Prop prop = Function.Call<Prop>(Hash.GET_CLOSEST_OBJECT_OF_TYPE, (InputArgument)Player.Position.X, (InputArgument)Player.Position.Y, (InputArgument)Player.Position.Z, (InputArgument)3f, (InputArgument)HTools.Main.GetHashKey("prop_ld_wallet_02"), (InputArgument)true, (InputArgument)false, (InputArgument)false);
                                    if (Function.Call<bool>(Hash.IS_ENTITY_ATTACHED_TO_ENTITY, (InputArgument)(Entity)prop, (InputArgument)(Entity)Player) && (Entity)Wallet.wallet == (Entity)null)
                                        Wallet.wallet = prop;
                                }
                                if ((Entity)Wallet.walletOpened == (Entity)null && Function.Call<bool>(Hash.DOES_OBJECT_OF_TYPE_EXIST_AT_COORDS, (InputArgument)Player.Position.X, (InputArgument)Player.Position.Y, (InputArgument)Player.Position.Z, (InputArgument)3f, (InputArgument)HTools.Main.GetHashKey("prop_ld_wallet_pickup"), (InputArgument)0))
                                {
                                    Prop prop = Function.Call<Prop>(Hash.GET_CLOSEST_OBJECT_OF_TYPE, (InputArgument)Player.Position.X, (InputArgument)Player.Position.Y, (InputArgument)Player.Position.Z, (InputArgument)3f, (InputArgument)HTools.Main.GetHashKey("prop_ld_wallet_pickup"), (InputArgument)true, (InputArgument)false, (InputArgument)false);
                                    if (Function.Call<bool>(Hash.IS_ENTITY_ATTACHED_TO_ENTITY, (InputArgument)(Entity)prop, (InputArgument)(Entity)Player) && (Entity)Wallet.walletOpened == (Entity)null)
                                        Wallet.walletOpened = prop;
                                }
                                if (Function.Call<Prop>(Hash.GET_CLOSEST_OBJECT_OF_TYPE, (InputArgument)Player.Position.X, (InputArgument)Player.Position.Y, (InputArgument)Player.Position.Z, (InputArgument)3f, (InputArgument)HTools.Main.GetHashKey("prop_ld_wallet_02"), (InputArgument)true, (InputArgument)false, (InputArgument)false).Exists())
                                {
                                    Prop prop = Function.Call<Prop>(Hash.GET_CLOSEST_OBJECT_OF_TYPE, (InputArgument)Player.Position.X, (InputArgument)Player.Position.Y, (InputArgument)Player.Position.Z, (InputArgument)3f, (InputArgument)HTools.Main.GetHashKey("prop_ld_wallet_02"), (InputArgument)true, (InputArgument)false, (InputArgument)false);
                                    if ((Entity)prop != (Entity)Wallet.wallet && Function.Call<bool>(Hash.IS_ENTITY_ATTACHED_TO_ENTITY, (InputArgument)(Entity)prop, (InputArgument)(Entity)Player) && prop.Exists())
                                        prop.Delete();
                                }
                                if (Function.Call<Prop>(Hash.GET_CLOSEST_OBJECT_OF_TYPE, (InputArgument)Player.Position.X, (InputArgument)Player.Position.Y, (InputArgument)Player.Position.Z, (InputArgument)3f, (InputArgument)HTools.Main.GetHashKey("prop_ld_wallet_pickup"), (InputArgument)true, (InputArgument)false, (InputArgument)false).Exists())
                                {
                                    Prop prop = Function.Call<Prop>(Hash.GET_CLOSEST_OBJECT_OF_TYPE, (InputArgument)Player.Position.X, (InputArgument)Player.Position.Y, (InputArgument)Player.Position.Z, (InputArgument)3f, (InputArgument)HTools.Main.GetHashKey("prop_ld_wallet_pickup"), (InputArgument)true, (InputArgument)false, (InputArgument)false);
                                    if ((Entity)prop != (Entity)Wallet.walletOpened && Function.Call<bool>(Hash.IS_ENTITY_ATTACHED_TO_ENTITY, (InputArgument)(Entity)prop, (InputArgument)(Entity)Player) && prop.Exists())
                                        prop.Delete();
                                }
                                if ((Entity)Wallet.wallet != (Entity)null && Wallet.wallet.Exists())
                                {
                                    Function.Call(Hash.ATTACH_ENTITY_TO_ENTITY, (InputArgument)(Entity)Wallet.wallet, (InputArgument)(Entity)Player, (InputArgument)num2, (InputArgument)0.1, (InputArgument)0.015, (InputArgument)(-0.025), (InputArgument)115.0, (InputArgument)20.0, (InputArgument)0.0, (InputArgument)false, (InputArgument)false, (InputArgument)false, (InputArgument)false, (InputArgument)0, (InputArgument)true);
                                    Wallet.wallet.IsVisible = true;
                                }
                                if ((Entity)Wallet.walletOpened != (Entity)null && Wallet.wallet.Exists())
                                {
                                    Function.Call(Hash.ATTACH_ENTITY_TO_ENTITY, (InputArgument)(Entity)Wallet.walletOpened, (InputArgument)(Entity)Player, (InputArgument)num1, (InputArgument)0.15, (InputArgument)0.025, (InputArgument)0.1, (InputArgument)(-85.0), (InputArgument)(-45.0), (InputArgument)(-10.0), (InputArgument)false, (InputArgument)false, (InputArgument)false, (InputArgument)false, (InputArgument)0, (InputArgument)true);
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
                        InventoryBag.checkEquipedGear(Player);
                        Player.Task.ClearAll();
                        if (CigsAndPills.cigsCount > 0)
                        {
                            Common.checkMask(Player);
                            if (!Common.MaskIsOn && !Player.IsWearingHelmet)
                            {
                                Player.Task.ClearAll();
                                Function.Call(Hash.SET_CURRENT_PED_WEAPON, (InputArgument)(Entity)Player, (InputArgument)2725352035U, (InputArgument)true);
                                switch (CigsAndPills.smoke)
                                {
                                    case -1:
                                    case 0:
                                        Function.Call(Hash.SET_CURRENT_PED_WEAPON, (InputArgument)(Entity)Player, (InputArgument)2725352035U, (InputArgument)true);
                                        if (Function.Call<bool>(Hash.IS_ENTITY_ATTACHED_TO_ENTITY, (InputArgument)(Entity)Function.Call<Prop>(Hash.GET_CLOSEST_OBJECT_OF_TYPE, (InputArgument)Player.Position.X, (InputArgument)Player.Position.Y, (InputArgument)Player.Position.Z, (InputArgument)3f, (InputArgument)HTools.Main.GetHashKey(CigsAndPills.smokeType), (InputArgument)true, (InputArgument)false, (InputArgument)false)))
                                            Function.Call<Prop>(Hash.GET_CLOSEST_OBJECT_OF_TYPE, (InputArgument)Player.Position.X, (InputArgument)Player.Position.Y, (InputArgument)Player.Position.Z, (InputArgument)3f, (InputArgument)HTools.Main.GetHashKey(CigsAndPills.smokeType), (InputArgument)true, (InputArgument)false, (InputArgument)false).Delete();
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
                        InventoryBag.checkEquipedGear(Player);
                        Player.Task.ClearAll();
                        if (CigsAndPills.pillsCount > 0)
                        {
                            Common.checkMask(Player);
                            if (!Common.MaskIsOn && !Player.IsWearingHelmet)
                            {
                                if (!Function.Call<bool>(Hash.IS_PED_RUNNING_MOBILE_PHONE_TASK, (InputArgument)(Entity)Player) && !Function.Call<bool>(Hash.IS_PLAYER_FREE_AIMING, (InputArgument)(Entity)Player) && !Function.Call<bool>(Hash.IS_CUTSCENE_PLAYING) && !Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Player, (InputArgument)"amb@world_human_smoking@male@male_a@idle_a", (InputArgument)"idle_c", (InputArgument)3) && !Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Player, (InputArgument)"amb@world_human_leaning@female@smoke@idle_a", (InputArgument)"idle_b", (InputArgument)3) && !Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Player, (InputArgument)"amb@world_human_smoking@male@male_b@idle_a", (InputArgument)"idle_a", (InputArgument)3) && !Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Player, (InputArgument)"amb@world_human_smoking@female@idle_a", (InputArgument)"idle_b", (InputArgument)3) && !Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Player, (InputArgument)"mp_player_inteat@pnq", (InputArgument)"loop_fp", (InputArgument)3))
                                {
                                    Function.Call(Hash.SET_PED_CAN_PLAY_GESTURE_ANIMS, (InputArgument)(Entity)Player, (InputArgument)false);
                                    Function.Call(Hash.SET_CURRENT_PED_WEAPON, (InputArgument)(Entity)Player, (InputArgument)2725352035U, (InputArgument)true);
                                    if (Player.IsSittingInVehicle())
                                    {
                                        if (Player.IsSittingInVehicle() && Function.Call<bool>(Hash.IS_THIS_MODEL_A_CAR, (InputArgument)Player.CurrentVehicle.Model) && !Player.IsDoingDriveBy)
                                        {
                                            Player.Task.ClearAll();
                                            CigsAndPills.inProcessCigsAndPills = true;
                                            CigsAndPills.cigsAndPillsCounter = 15;
                                            CigsAndPills.swallo_anim_current_time = 0.0f;
                                            CigsAndPills.swallow_in_process = false;
                                        }
                                    }
                                    else
                                    {
                                        Player.Task.ClearAll();
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
                        InventoryBag.checkEquipedGear(Player);
                        Player.Task.ClearAll();
                        Function.Call(Hash.SET_CURRENT_PED_WEAPON, (InputArgument)(Entity)Player, (InputArgument)2725352035U, (InputArgument)true);
                        Script.Wait(100);
                        HTools.Main.soundFX(Player, "noise.wav", Common.assetFolder);
                        string animDic = "anim@mp_player_intupperface_palm";
                        string animName = "exit";
                        if (!Player.IsSittingInVehicle())
                        {
                            animDic = "clothingspecs";
                            animName = "try_glasses_positive_a";
                        }
                        model = Player.Model;
                        if (model.Hash == HTools.Main.GetHashKey("PLAYER_ZERO"))
                            FastWardrobe.PropsControlFunc(Player, "MICHAELES GLASSES", 2, animDic, animName, 1000);
                        model = Player.Model;
                        if (model.Hash == HTools.Main.GetHashKey("PLAYER_ONE"))
                            FastWardrobe.PropsControlFunc(Player, "FRANKLINS GLASSES", 2, animDic, animName, 1000);
                        model = Player.Model;
                        if (model.Hash == HTools.Main.GetHashKey("PLAYER_TWO"))
                            FastWardrobe.PropsControlFunc(Player, "TREVORS GLASSES", 2, animDic, animName, 1000);
                        model = Player.Model;
                        if (model.Hash != HTools.Main.GetHashKey("mp_m_freemode_01"))
                        {
                            model = Player.Model;
                            if (model.Hash != HTools.Main.GetHashKey("mp_f_freemode_01"))
                                goto label_290;
                        }
                        FastWardrobe.PropsControlFunc(Player, "MPS GLASSES", 2, animDic, animName, 1000);
                    }
                label_290:
                    if (Function.Call<bool>(Hash.IS_DISABLED_CONTROL_JUST_PRESSED, (InputArgument)0, (InputArgument)FastWardrobe.gloves_toggle_btn))
                    {
                        Common.inMainMenu = false;
                        InventoryBag.checkEquipedGear(Player);
                        Player.Task.ClearAll();
                        Function.Call(Hash.SET_CURRENT_PED_WEAPON, (InputArgument)(Entity)Player, (InputArgument)2725352035U, (InputArgument)true);
                        Script.Wait(100);
                        HTools.Main.soundFX(Player, "noise.wav", Common.assetFolder);
                        string animDic = "switch@michael@closet";
                        string animName = "closet_c";
                        model = Player.Model;
                        if (model.Hash == HTools.Main.GetHashKey("PLAYER_ZERO"))
                            FastWardrobe.PropsControlFunc(Player, "MICHAELES GLOVES", 1, animDic, animName, 2000);
                        model = Player.Model;
                        if (model.Hash == HTools.Main.GetHashKey("PLAYER_ONE"))
                            FastWardrobe.PropsControlFunc(Player, "FRANKLINS GLOVES", 1, animDic, animName, 2000);
                        model = Player.Model;
                        if (model.Hash == HTools.Main.GetHashKey("PLAYER_TWO"))
                            FastWardrobe.PropsControlFunc(Player, "TREVORS GLOVES", 1, animDic, animName, 2000);
                        model = Player.Model;
                        if (model.Hash != HTools.Main.GetHashKey("mp_m_freemode_01"))
                        {
                            model = Player.Model;
                            if (model.Hash != HTools.Main.GetHashKey("mp_f_freemode_01"))
                                goto label_300;
                        }
                        FastWardrobe.PropsControlFunc(Player, "MPS GLOVES", 1, animDic, animName, 2000);
                    }
                label_300:
                    if (Function.Call<bool>(Hash.IS_DISABLED_CONTROL_JUST_PRESSED, (InputArgument)0, (InputArgument)FastWardrobe.hat_toggle_btn))
                    {
                        Common.inMainMenu = false;
                        InventoryBag.checkEquipedGear(Player);
                        Player.Task.ClearAll();
                        Function.Call(Hash.SET_CURRENT_PED_WEAPON, (InputArgument)(Entity)Player, (InputArgument)2725352035U, (InputArgument)true);
                        Script.Wait(100);
                        HTools.Main.soundFX(Player, "noise.wav", Common.assetFolder);
                        string animDic = "anim@mp_player_intupperface_palm";
                        string animName = "exit";
                        if (Player.IsSittingInVehicle() && !Function.Call<bool>(Hash.IS_THIS_MODEL_A_QUADBIKE, (InputArgument)Function.Call<int>(Hash.GET_ENTITY_MODEL, (InputArgument)(Entity)Player.CurrentVehicle)) && !Function.Call<bool>(Hash.IS_THIS_MODEL_A_BICYCLE, (InputArgument)Function.Call<int>(Hash.GET_ENTITY_MODEL, (InputArgument)(Entity)Player.CurrentVehicle)) && !Function.Call<bool>(Hash.IS_PED_ON_ANY_BIKE, (InputArgument)(Entity)Player))
                        {
                            animDic = "anim@mp_player_intupperface_palm";
                            animName = "exit";
                        }
                        model = Player.Model;
                        if (model.Hash == HTools.Main.GetHashKey("PLAYER_ZERO"))
                            FastWardrobe.PropsControlFunc(Player, "MICHAELES HAT", 2, animDic, animName, 2000);
                        model = Player.Model;
                        if (model.Hash == HTools.Main.GetHashKey("PLAYER_ONE"))
                            FastWardrobe.PropsControlFunc(Player, "FRANKLINS HAT", 2, animDic, animName, 2000);
                        model = Player.Model;
                        if (model.Hash == HTools.Main.GetHashKey("PLAYER_TWO"))
                            FastWardrobe.PropsControlFunc(Player, "TREVORS HAT", 2, animDic, animName, 2000);
                        model = Player.Model;
                        if (model.Hash != HTools.Main.GetHashKey("mp_m_freemode_01"))
                        {
                            model = Player.Model;
                            if (model.Hash != HTools.Main.GetHashKey("mp_f_freemode_01"))
                                goto label_312;
                        }
                        FastWardrobe.PropsControlFunc(Player, "MPS HAT", 2, animDic, animName, 2000);
                    }
                label_312:
                    if (Function.Call<bool>(Hash.IS_DISABLED_CONTROL_JUST_PRESSED, (InputArgument)0, (InputArgument)FastWardrobe.mask_toggle_btn))
                    {
                        Common.inMainMenu = false;
                        InventoryBag.checkEquipedGear(Player);
                        Player.Task.ClearAll();
                        Function.Call(Hash.SET_CURRENT_PED_WEAPON, (InputArgument)(Entity)Player, (InputArgument)2725352035U, (InputArgument)true);
                        Script.Wait(100);
                        HTools.Main.soundFX(Player, "noise.wav", Common.assetFolder);
                        string animDic = "anim@mp_player_intupperface_palm";
                        string animName = "exit";
                        if (Player.IsSittingInVehicle() && !Function.Call<bool>(Hash.IS_THIS_MODEL_A_QUADBIKE, (InputArgument)Function.Call<int>(Hash.GET_ENTITY_MODEL, (InputArgument)(Entity)Player.CurrentVehicle)) && !Function.Call<bool>(Hash.IS_THIS_MODEL_A_BICYCLE, (InputArgument)Function.Call<int>(Hash.GET_ENTITY_MODEL, (InputArgument)(Entity)Player.CurrentVehicle)) && !Function.Call<bool>(Hash.IS_PED_ON_ANY_BIKE, (InputArgument)(Entity)Player))
                        {
                            animDic = "anim@mp_player_intupperface_palm";
                            animName = "exit";
                        }
                        model = Player.Model;
                        if (model.Hash == HTools.Main.GetHashKey("PLAYER_ZERO"))
                            FastWardrobe.PropsControlFunc(Player, "MICHAELES MASK", 1, animDic, animName, 2000, Common.config.GetValue<bool>("MICHAELES MASK", "HIDE_HAIRS", true), true);
                        model = Player.Model;
                        if (model.Hash == HTools.Main.GetHashKey("PLAYER_ONE"))
                            FastWardrobe.PropsControlFunc(Player, "FRANKLINS MASK", 1, animDic, animName, 2000, Common.config.GetValue<bool>("FRANKLINS MASK", "HIDE_HAIRS", true), true);
                        model = Player.Model;
                        if (model.Hash == HTools.Main.GetHashKey("PLAYER_TWO"))
                            FastWardrobe.PropsControlFunc(Player, "TREVORS MASK", 1, animDic, animName, 2000, Common.config.GetValue<bool>("TREVORS MASK", "HIDE_HAIRS", true), true);
                        model = Player.Model;
                        if (model.Hash != HTools.Main.GetHashKey("mp_m_freemode_01"))
                        {
                            model = Player.Model;
                            if (model.Hash != HTools.Main.GetHashKey("mp_f_freemode_01"))
                                goto label_325;
                        }
                        FastWardrobe.PropsControlFunc(Player, "MPS MASK", 1, animDic, animName, 2000, Common.config.GetValue<bool>("MPS MASK", "HIDE_HAIRS", true), true);
                    }
                }
            label_325:
                if (Common.cur_action_page != 3)
                    ;
                if (Common.cur_action_page == 4)
                {
                    if (Function.Call<bool>(Hash.IS_DISABLED_CONTROL_JUST_PRESSED, (InputArgument)0, (InputArgument)HungerSystem.eat_btn) && HungerSystem.hungerModuleActive)
                    {
                        HungerSystem._curPedsFood = HungerSystem.getPedsFood(Player, Common.doc);
                        if (HungerSystem._curPedsFood != "")
                        {
                            if (!HTools.Main.isOccupiedNative(Player) && Game.Player.CanControlCharacter && Common.curVehicleIsCar(Player))
                            {
                                HungerSystem.foodModel = HungerSystem.getFoodModelByTyoe(HungerSystem._curPedsFood);
                                Common.inMainMenu = false;
                                InventoryBag.checkEquipedGear(Player);
                                Player.Task.ClearAll();
                                Common.inMainMenu = false;
                                HungerSystem.isEating = true;
                                HungerSystem.eatingSoundsInt = 0;
                                HungerSystem.isVeryHungry = HungerSystem.getPedHungerLvl(Player, Common.doc) < HungerSystem.criticalHungerLvl;
                            }
                        }
                        else
                        {
                            if (!Function.Call<bool>(Hash.IS_HELP_MESSAGE_BEING_DISPLAYED))
                                Screen.ShowHelpText("~BLIP_INFO_ICON~ You dont have any ~p~food~w~", 6000);
                            Common.inMainMenu = false;
                            InventoryBag.checkEquipedGear(Player);
                            Player.Task.ClearAll();
                        }
                    }
                    if (Function.Call<bool>(Hash.IS_DISABLED_CONTROL_JUST_PRESSED, (InputArgument)0, (InputArgument)HungerSystem.drink_btn) && HungerSystem.hungerModuleActive)
                    {
                        HungerSystem._curPedsDrink = HungerSystem.getPedsDrinks(Player, Common.doc);
                        if (HungerSystem._curPedsDrink != "")
                        {
                            if (!HTools.Main.isOccupiedNative(Player) && Game.Player.CanControlCharacter && Common.curVehicleIsCar(Player))
                            {
                                HungerSystem.drinkModel = HungerSystem.getDrinksModelByTyoe(HungerSystem._curPedsDrink);
                                Common.inMainMenu = false;
                                InventoryBag.checkEquipedGear(Player);
                                Player.Task.ClearAll();
                                Common.inMainMenu = false;
                                HungerSystem.isDrinking = true;
                                HungerSystem.drinkSipsLeft = 500;
                                HungerSystem.drinkingInProcess = false;
                                HungerSystem.isVeryThirsty = HungerSystem.getPedThirstLvl(Player, Common.doc) < HungerSystem.criticalThirstLvl;
                            }
                        }
                        else
                        {
                            if (!Function.Call<bool>(Hash.IS_HELP_MESSAGE_BEING_DISPLAYED))
                                Screen.ShowHelpText("~BLIP_INFO_ICON~ You dont have any ~p~drinks~w~", 6000);
                            Common.inMainMenu = false;
                            InventoryBag.checkEquipedGear(Player);
                            Player.Task.ClearAll();
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
                        if (!Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Player, (InputArgument)"anim@scripted@heist@ig1_table_grab@gold@male@", (InputArgument)"enter", (InputArgument)3))
                            Player.Task.PlayAnimation("anim@scripted@heist@ig1_table_grab@gold@male@", "enter", 4f, -1, AnimationFlags.StayInEndFrame | AnimationFlags.UpperBodyOnly | AnimationFlags.Secondary);
                        else if ((double)Function.Call<float>(Hash.GET_ENTITY_ANIM_CURRENT_TIME, (InputArgument)(Entity)Player, (InputArgument)"anim@scripted@heist@ig1_table_grab@gold@male@", (InputArgument)"enter") >= 0.98000001907348633)
                        {
                            HungerSystem._drink = HungerSystem.createDrink(Player, Function.Call<Vector3>(Hash.GET_PED_BONE_COORDS, (InputArgument)(Entity)Player, (InputArgument)Function.Call<int>(Hash.GET_PED_BONE_INDEX, (InputArgument)(Entity)Player, (InputArgument)18905), (InputArgument)0, (InputArgument)0, (InputArgument)0), HungerSystem.drinkModel);
                            if (Player.Gender == Gender.Male)
                            {
                                HungerSystem.pedDrinkingAnimDict = "amb@world_human_drinking@beer@male@idle_a";
                                HungerSystem.pedDrinkingAnimName = "idle_b";
                            }
                            else
                            {
                                HungerSystem.pedDrinkingAnimDict = "amb@world_human_drinking@beer@female@idle_a";
                                HungerSystem.pedDrinkingAnimName = "idle_a";
                            }
                            if (!Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Player, (InputArgument)HungerSystem.pedDrinkingAnimDict, (InputArgument)HungerSystem.pedDrinkingAnimName, (InputArgument)3))
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
                        if (!Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Player, (InputArgument)"amb@world_human_drinking@beer@male@exit", (InputArgument)"exit", (InputArgument)3))
                        {
                            Common.Draw(10);
                            if (!Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Player, (InputArgument)HungerSystem.pedDrinkingAnimDict, (InputArgument)HungerSystem.pedDrinkingAnimName, (InputArgument)3))
                                Player.Task.PlayAnimation(HungerSystem.pedDrinkingAnimDict, HungerSystem.pedDrinkingAnimName, 4f, -1, AnimationFlags.StayInEndFrame | AnimationFlags.UpperBodyOnly | AnimationFlags.Secondary);
                            else if (!Function.Call<bool>(Hash.IS_DISABLED_CONTROL_PRESSED, (InputArgument)0, (InputArgument)24))
                            {
                                if ((double)Function.Call<float>(Hash.GET_ENTITY_ANIM_CURRENT_TIME, (InputArgument)(Entity)Player, (InputArgument)HungerSystem.pedDrinkingAnimDict, (InputArgument)HungerSystem.pedDrinkingAnimName) >= 0.2800000011920929 && (double)Function.Call<float>(Hash.GET_ENTITY_ANIM_CURRENT_TIME, (InputArgument)(Entity)Player, (InputArgument)HungerSystem.pedDrinkingAnimDict, (InputArgument)HungerSystem.pedDrinkingAnimName) < 0.81000000238418579)
                                    Function.Call(Hash.SET_ENTITY_ANIM_CURRENT_TIME, (InputArgument)(Entity)Player, (InputArgument)HungerSystem.pedDrinkingAnimDict, (InputArgument)HungerSystem.pedDrinkingAnimName, (InputArgument)0.81f);
                                else if ((double)Function.Call<float>(Hash.GET_ENTITY_ANIM_CURRENT_TIME, (InputArgument)(Entity)Player, (InputArgument)HungerSystem.pedDrinkingAnimDict, (InputArgument)HungerSystem.pedDrinkingAnimName) <= 0.2800000011920929)
                                    Function.Call(Hash.SET_ENTITY_ANIM_CURRENT_TIME, (InputArgument)(Entity)Player, (InputArgument)HungerSystem.pedDrinkingAnimDict, (InputArgument)HungerSystem.pedDrinkingAnimName, (InputArgument)0.0f);
                            }
                            if (Function.Call<bool>(Hash.IS_DISABLED_CONTROL_JUST_PRESSED, (InputArgument)0, (InputArgument)24))
                            {
                                Function.Call(Hash.PLAY_SOUND_FRONTEND, (InputArgument)(-1), (InputArgument)"FocusInt", (InputArgument)"HintCamSounds");
                                if ((Entity)HungerSystem._drink == (Entity)null || (Entity)HungerSystem._drink != (Entity)null && !HungerSystem._drink.Exists())
                                    HungerSystem._drink = HungerSystem.createDrink(Player, Function.Call<Vector3>(Hash.GET_PED_BONE_COORDS, (InputArgument)(Entity)Player, (InputArgument)Function.Call<int>(Hash.GET_PED_BONE_INDEX, (InputArgument)(Entity)Player, (InputArgument)18905), (InputArgument)0, (InputArgument)0, (InputArgument)0), HungerSystem.drinkModel);
                                Function.Call(Hash.SET_ENTITY_ANIM_CURRENT_TIME, (InputArgument)(Entity)Player, (InputArgument)HungerSystem.pedDrinkingAnimDict, (InputArgument)HungerSystem.pedDrinkingAnimName, (InputArgument)0.0f);
                            }
                            if (Function.Call<bool>(Hash.IS_DISABLED_CONTROL_PRESSED, (InputArgument)0, (InputArgument)24) && (double)Function.Call<float>(Hash.GET_ENTITY_ANIM_CURRENT_TIME, (InputArgument)(Entity)Player, (InputArgument)HungerSystem.pedDrinkingAnimDict, (InputArgument)HungerSystem.pedDrinkingAnimName) >= 0.30000001192092896 && (double)Function.Call<float>(Hash.GET_ENTITY_ANIM_CURRENT_TIME, (InputArgument)(Entity)Player, (InputArgument)HungerSystem.pedDrinkingAnimDict, (InputArgument)HungerSystem.pedDrinkingAnimName) <= 0.33000001311302185)
                            {
                                --HungerSystem.drinkSipsLeft;
                                Player.HealthFloat += 0.1f;
                                Game.Player.ChargeSpecialAbility(0.01f);
                                double num = (double)Function.Call<float>(Hash.SET_ENTITY_ANIM_CURRENT_TIME, (InputArgument)(Entity)Player, (InputArgument)HungerSystem.pedDrinkingAnimDict, (InputArgument)HungerSystem.pedDrinkingAnimName, (InputArgument)0.3f);
                                if (HungerSystem.swallowSoundFXTimer <= 0)
                                {
                                    HTools.Main.soundFX(Player, "swallow.wav", Common.assetFolder, 18f);
                                    HungerSystem.swallowSoundFXTimer = 100;
                                }
                                else
                                    --HungerSystem.swallowSoundFXTimer;

                                int normalized = (HungerSystem.drinkSipsLeft/500) * HungerSystem.thirst_lvl_max;
                                int inverted = HungerSystem.thirst_lvl_max - normalized;
                                
                                int compounded = counter + inverted;
                                HungerSystem.savePedThirstLvl(Player, compounded, HungerSystem.thirst_lvl_max, Common.doc);

                            }
                            if (Function.Call<bool>(Hash.IS_DISABLED_CONTROL_JUST_PRESSED, (InputArgument)0, (InputArgument)25) || HungerSystem.drinkSipsLeft <= 0 || Player.IsRagdoll)
                            {
                                Function.Call(Hash.PLAY_SOUND_FRONTEND, (InputArgument)(-1), (InputArgument)"FocusOut", (InputArgument)"HintCamSounds");
                                if ((Entity)HungerSystem._drink == (Entity)null)
                                    HungerSystem._drink = HungerSystem.createDrink(Player, Function.Call<Vector3>(Hash.GET_PED_BONE_COORDS, (InputArgument)(Entity)Player, (InputArgument)Function.Call<int>(Hash.GET_PED_BONE_INDEX, (InputArgument)(Entity)Player, (InputArgument)18905), (InputArgument)0, (InputArgument)0, (InputArgument)0), HungerSystem.drinkModel);
                                if ((Entity)HungerSystem._drink != (Entity)null && !Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Player, (InputArgument)"amb@world_human_drinking@beer@male@exit", (InputArgument)"exit", (InputArgument)3))
                                    Player.Task.PlayAnimation("amb@world_human_drinking@beer@male@exit", "exit", 4f, 7000, AnimationFlags.UpperBodyOnly | AnimationFlags.Secondary);
                            }
                        }
                        else if ((double)Function.Call<float>(Hash.GET_ENTITY_ANIM_CURRENT_TIME, (InputArgument)(Entity)Player, (InputArgument)"amb@world_human_drinking@beer@male@exit", (InputArgument)"exit") >= 0.64999997615814209)
                        {
                            Function.Call(Hash.REMOVE_PARTICLE_FX_FROM_ENTITY, (InputArgument)(Entity)HungerSystem._drink);
                            HungerSystem.isDrinking = false;
                            
                            HungerSystem.drinkingInProcess = false;
                            Function.Call(Hash.PLAY_PED_AMBIENT_SPEECH_NATIVE, (InputArgument)(Entity)Player, (InputArgument)"GENERIC_DRINK", (InputArgument)"SPEECH_PARAMS_FORCE");
                            HungerSystem.updatePedDrinksCount(Player, HungerSystem._curPedsDrink, HungerSystem.getPedDrinksCount(Player, HungerSystem._curPedsDrink, Common.doc) - 1, Common.doc);
                            HungerSystem.drinksLeft = HungerSystem.getPedDrinksCount(Player, "", Common.doc);
                            HungerSystem._drink.Detach();
                            HungerSystem._drink.MarkAsNoLongerNeeded();
                            HungerSystem.savePedThirstLvl(Player, HungerSystem.thirst_lvl_max, HungerSystem.thirst_lvl_max, Common.doc);
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
                    if (!Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Player, (InputArgument)animDict, (InputArgument)animName, (InputArgument)3))
                    {
                        Player.Task.PlayAnimation(animDict, animName, 4f, duration, AnimationFlags.UpperBodyOnly | AnimationFlags.Secondary);
                        HTools.Main.soundFX(Player, "draw2.wav", Common.assetFolder);
                        HungerSystem.createFood(Player, Player.Position, HungerSystem.foodModel, attachPositionType: 1);
                    }
                    else
                    {
                        if ((double)Function.Call<float>(Hash.GET_ENTITY_ANIM_CURRENT_TIME, (InputArgument)(Entity)Player, (InputArgument)animDict, (InputArgument)animName) >= (double)HungerSystem.eatingAnimTime)
                        {
                            if (HungerSystem.eatingSoundsInt <= 0)
                            {
                                HungerSystem.eatingSoundsInt = HungerSystem.eatingSoundsMaxInt;
                                HTools.Main.soundFX(Player, "eat.wav", Common.assetFolder, 15f);
                                HTools.Main.soundFX(Player, "snack.wav", Common.assetFolder, 15f);
                            }
                            else
                                --HungerSystem.eatingSoundsInt;
                        }
                        Player.HealthFloat += 0.1f;
                        if ((double)Function.Call<float>(Hash.GET_ENTITY_ANIM_CURRENT_TIME, (InputArgument)(Entity)Player, (InputArgument)animDict, (InputArgument)animName) > (double)num)
                        {
                            if (!Player.IsInStealthMode)
                                Function.Call(Hash.PLAY_PED_AMBIENT_SPEECH_NATIVE, (InputArgument)(Entity)Player, (InputArgument)"GENERIC_EAT", (InputArgument)"SPEECH_PARAMS_FORCE_SHOUTED");
                            Screen.ShowHelpText("~BLIP_INFO_ICON~ You feel much better now!", 6000);
                            HTools.Main.soundFX(Player, "swallow.wav", Common.assetFolder, 15f);
                            HungerSystem.savePedHungerLvl(Player, HungerSystem.hunger_lvl_max, HungerSystem.hunger_lvl_max, Common.doc);
                            HungerSystem.updatePedFoodCount(Player, HungerSystem._curPedsFood, HungerSystem.getPedFoodCount(Player, HungerSystem._curPedsFood, Common.doc) - 1, Common.doc);
                            HungerSystem.clearFood(Player, HungerSystem.foodModel);
                            HTools.Main.stopBleeding(Player);
                            HungerSystem.foodLeft = HungerSystem.getPedFoodCount(Player, "", Common.doc);
                            HungerSystem.isEating = false;
                            HungerSystem.isHungry = false;
                        }
                    }
                }
            }
            /*
            if (Common.pedIsNearSuburbanCashier)
            {
                int Headset = 8; HTools.Main.DisableControlsFunc(true); Common.Draw(12, cameraModuleParam: false, swingWeaponModuleParam: false, laserSightModuleParam: false, weaponJamningModuleParam: false);
                if (Function.Call<bool>(Hash.IS_DISABLED_CONTROL_JUST_PRESSED, (InputArgument)0, (InputArgument)26) && !Game.Player.IsAiming)
                {
                    OnFootRadio.isHeadsetBought = OnFootRadio.HasPedBoughtHeadset(Player);
                    if (!OnFootRadio.isHeadsetBought)
                    {
                        Common.purchaseType = Headset;
                        Common.purchaseSum = OnFootRadio.HeadsetPrice;
                        Common.purchaseProcess = true;
                    }
                }
                if (Common.purchaseProcess)
                {
                    Common.purchaseProcess = false;
                    bool flag = true;
                    if ((Player.Model == (Model)PedHash.Michael || Player.Model == (Model)PedHash.Franklin || Player.Model == (Model)PedHash.Trevor) && Game.Player.Money < Common.purchaseSum)
                        flag = false;
                    if (flag)
                    {
                        InventoryBag._isBuyingGear = true;
                        Function.Call(Hash.PLAY_PED_AMBIENT_SPEECH_NATIVE, (InputArgument)(Entity)Player, (InputArgument)"GENERIC_HI", (InputArgument)"SPEECH_PARAMS_FORCE");
                        Common._SuburbanCashier.Task.LookAt((Entity)Player, 1000);
                    }
                    else
                    {
                        Screen.ShowHelpText("~BLIP_INFO_ICON~ You don't have enough money!");
                        Function.Call(Hash.PLAY_PED_AMBIENT_SPEECH_NATIVE, (InputArgument)(Entity)Common._SuburbanCashier, (InputArgument)"SHOP_BANTER", (InputArgument)"SPEECH_PARAMS_FORCE");
                    }
                }
                if (InventoryBag._isBuyingGear)
                {

                    if (!Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Player, (InputArgument)"anim@scripted@heist@ig1_table_grab@gold@male@", (InputArgument)"enter", (InputArgument)3))
                    {

                        Function.Call(Hash.PLAY_PED_AMBIENT_SPEECH_NATIVE, (InputArgument)(Entity)Common._SuburbanCashier, (InputArgument)"SHOP_SELL", (InputArgument)"SPEECH_PARAMS_FORCE");
                        Function.Call(Hash.REQUEST_ANIM_DICT, "anim@scripted@heist@ig1_table_grab@gold@male@");
                        while (!Function.Call<bool>(Hash.HAS_ANIM_DICT_LOADED, "anim@scripted@heist@ig1_table_grab@gold@male@"))
                            Script.Wait(0);

                        if (!Player.IsSprinting && !Player.IsWalking && !Player.IsInVehicle() && !HTools.Main.isOccupiedNative(Player))
                        {
                            Function.Call(Hash.TASK_PLAY_ANIM, Player, "anim@scripted@heist@ig1_table_grab@gold@male@", "enter", 8f, -8f, -1, 49, 0f, false, false, false);
                            HungerSystem.createFoodPacket(Player, Player.Position);
                        }
                    }
                    else if ((double)Function.Call<float>(Hash.GET_ENTITY_ANIM_CURRENT_TIME, (InputArgument)(Entity)Player, (InputArgument)"anim@scripted@heist@ig1_table_grab@gold@male@", (InputArgument)"enter") > 0.98000001907348633)
                    {
                        if (Common.purchaseType == Headset)
                        {
                            OnFootRadio.PlayerBoughtHeadset(Player);
                            Function.Call(Hash.SET_TEXT_COLOUR, (InputArgument)0, (InputArgument)(int)byte.MaxValue, (InputArgument)0, (InputArgument)100);
                            Notification.Show("Dufflebag has been ~g~purchased", true);
                            HTools.Main.Notify("Your payment check: ~n~Dufflebag: ~h~" + InventoryBag.BagPrice.ToString() + "~h~~g~$~w~~n~-------------~n~Total sum: ~h~" + InventoryBag.BagPrice.ToString() + "~h~~g~$~w~", "Shopping purchase", 0, (int)byte.MaxValue, 0, NotificationIcon.BankMaze);
                            HungerSystem.clearFoodPacket(Player, "hei_prop_hei_paper_bag");
                            InventoryBag._isBuyingGear = false;
                            OnFootRadio.isHeadsetBought = true;
                        }

                        Function.Call(Hash.PLAY_PED_AMBIENT_SPEECH_NATIVE, (InputArgument)(Entity)Player, (InputArgument)"GENERIC_THANKS", (InputArgument)"SPEECH_PARAMS_FORCE");
                        if (Player.Model == (Model)PedHash.Michael || Player.Model == (Model)PedHash.Franklin || Player.Model == (Model)PedHash.Trevor)
                            Game.Player.Money -= Common.purchaseSum;
                    }
                }


            }
            */
            if (Common.pedIsNearGunDealer)
            {
                int Dufflebag = 3;
                int Holster = 4;
                int CleaningToolKit = 5;
                int ArmorPlateSet = 6;
                int Headset = 8;
                HTools.Main.DisableControlsFunc(true);
                Common.Draw(11, cameraModuleParam: false, swingWeaponModuleParam: false, laserSightModuleParam: false, weaponJamningModuleParam: false);
                if (Function.Call<bool>(Hash.IS_DISABLED_CONTROL_JUST_PRESSED, (InputArgument)0, (InputArgument)24) && !Game.Player.IsAiming)
                {
                    Common.purchaseType = Dufflebag;
                    Common.purchaseSum = InventoryBag.BagPrice;
                    Common.purchaseProcess = true;
                }
                if (Function.Call<bool>(Hash.IS_DISABLED_CONTROL_JUST_PRESSED, (InputArgument)0, (InputArgument)25) && !Game.Player.IsAiming)
                {
                    Common.purchaseType = Holster;
                    Common.purchaseSum = WeaponHolster.HolsterPrice;
                    Common.purchaseProcess = true;
                }
                if (Function.Call<bool>(Hash.IS_DISABLED_CONTROL_JUST_PRESSED, (InputArgument)0, (InputArgument)26) && !Game.Player.IsAiming)
                {
                    WeaponJamming.cleaningToolsCount = Common.getSupplies(Player, "weapon_tools");
                    if (WeaponJamming.cleaningToolsCount <= WeaponJamming.cleaningToolsMax)
                    {
                        Common.purchaseType = CleaningToolKit;
                        Common.purchaseSum = WeaponJamming.weaponToolsPrice;
                        Common.purchaseProcess = true;
                    }
                }
                if (Function.Call<bool>(Hash.IS_DISABLED_CONTROL_JUST_PRESSED, (InputArgument)0, (InputArgument)22) && !Game.Player.IsAiming)
                {
                    Vest.armorPlateCount = Vest.getArmorPlateCount(Player, "Armor_Plates");
                    if (Vest.armorPlateCount <= Vest.armorPlatesMax)
                    {
                        Common.purchaseType = ArmorPlateSet;
                        Common.purchaseSum = Vest.armorPlatePrice;
                        Common.purchaseProcess = true;
                    }
                }
                if (Function.Call<bool>(Hash.IS_DISABLED_CONTROL_JUST_PRESSED, (InputArgument)0, (InputArgument)21) && !Game.Player.IsAiming)
                {
                    OnFootRadio.isHeadsetBought = OnFootRadio.HasPedBoughtHeadset(Player);
                    if (!OnFootRadio.isHeadsetBought)
                    {
                        Common.purchaseType = Headset;
                        Common.purchaseSum = OnFootRadio.HeadsetPrice;
                        Common.purchaseProcess = true;
                    }
                }
                if (Common.purchaseProcess)
                {
                    Common.purchaseProcess = false;
                    bool flag = true;
                    if ((Player.Model == (Model)PedHash.Michael || Player.Model == (Model)PedHash.Franklin || Player.Model == (Model)PedHash.Trevor) && Game.Player.Money < Common.purchaseSum)
                        flag = false;
                    if (flag)
                    {
                        InventoryBag._isBuyingGear = true;
                        Function.Call(Hash.PLAY_PED_AMBIENT_SPEECH_NATIVE, (InputArgument)(Entity)Player, (InputArgument)"GENERIC_HI", (InputArgument)"SPEECH_PARAMS_FORCE");
                        Common._GunDealer.Task.LookAt((Entity)Player, 1000);
                    }
                    else
                    {
                        Screen.ShowHelpText("~BLIP_INFO_ICON~ You don't have enough money!");
                        Function.Call(Hash.PLAY_PED_AMBIENT_SPEECH_NATIVE, (InputArgument)(Entity)Common._GunDealer, (InputArgument)"SHOP_BANTER", (InputArgument)"SPEECH_PARAMS_FORCE");
                    }
                }
                if (InventoryBag._isBuyingGear)
                {                    
                    if (!Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Player, (InputArgument)"anim@scripted@heist@ig1_table_grab@gold@male@", (InputArgument)"enter", (InputArgument)3))
                    {
                        Function.Call(Hash.PLAY_PED_AMBIENT_SPEECH_NATIVE, (InputArgument)(Entity)Common._GunDealer, (InputArgument)"SHOP_SELL", (InputArgument)"SPEECH_PARAMS_FORCE");
                        Player.Task.PlayAnimation("anim@scripted@heist@ig1_table_grab@gold@male@", "enter", 8f, -1, AnimationFlags.UpperBodyOnly | AnimationFlags.Secondary);
                        HungerSystem.createFoodPacket(Player, Player.Position);
                    }
                    else if ((double)Function.Call<float>(Hash.GET_ENTITY_ANIM_CURRENT_TIME, (InputArgument)(Entity)Player, (InputArgument)"anim@scripted@heist@ig1_table_grab@gold@male@", (InputArgument)"enter") > 0.98000001907348633)
                    {
                        if (Common.purchaseType == Dufflebag)
                        {
                            InventoryBag.ClearInventoryData(Player);
                            InventoryBag.bagSet(InventoryBag.bagModelCheck(Player), Player);
                            Function.Call(Hash.SET_TEXT_COLOUR, (InputArgument)0, (InputArgument)(int)byte.MaxValue, (InputArgument)0, (InputArgument)100);
                            Notification.Show("Dufflebag has been ~g~purchased", true);
                            HTools.Main.Notify("Your payment check: ~n~Dufflebag: ~h~" + InventoryBag.BagPrice.ToString() + "~h~~g~$~w~~n~-------------~n~Total sum: ~h~" + InventoryBag.BagPrice.ToString() + "~h~~g~$~w~", "Shopping purchase", 0, (int)byte.MaxValue, 0, NotificationIcon.BankMaze);
                            HungerSystem.clearFoodPacket(Player, "hei_prop_hei_paper_bag");
                            InventoryBag._isBuyingGear = false;
                            InventoryBag.hasBag = InventoryBag.doesPedHasInventoryBag(Player);
                        }
                        if (Common.purchaseType == Holster)
                        {
                            WeaponHolster.SaveHolster(Player);
                            Function.Call(Hash.SET_TEXT_COLOUR, (InputArgument)0, (InputArgument)(int)byte.MaxValue, (InputArgument)0, (InputArgument)100);
                            Notification.Show("Holster has been ~g~purchased", true);
                            HTools.Main.Notify("Your payment check: ~n~Holster: ~h~" + WeaponHolster.HolsterPrice.ToString() + "~h~~g~$~w~~n~-------------~n~Total sum: ~h~" + WeaponHolster.HolsterPrice.ToString() + "~h~~g~$~w~", "Shopping purchase", 0, (int)byte.MaxValue, 0, NotificationIcon.BankMaze);
                            HungerSystem.clearFoodPacket(Player, "hei_prop_hei_paper_bag");
                            InventoryBag._isBuyingGear = false;
                            WeaponHolster.hasHolster = WeaponHolster.doesPedHasHolster(Player);
                        }
                        if (Common.purchaseType == CleaningToolKit)
                        {
                            Function.Call(Hash.SET_TEXT_COLOUR, (InputArgument)0, (InputArgument)(int)byte.MaxValue, (InputArgument)0, (InputArgument)100);
                            Common.saveSupplies(Player, "weapon_tools", WeaponJamming.cleaningToolsMax);
                            Notification.Show("Weapon cleaning toolkit set has been ~g~purchased", true);
                            HTools.Main.Notify("Your payment check: ~n~Weapon cleaning toolkit set: ~h~" + WeaponJamming.weaponToolsPrice.ToString() + "~h~~g~$~w~~n~-------------~n~Total sum: ~h~" + WeaponJamming.weaponToolsPrice.ToString() + "~h~~g~$~w~", "Shopping purchase", 0, (int)byte.MaxValue, 0, NotificationIcon.BankMaze);
                            HungerSystem.clearFoodPacket(Player, "hei_prop_hei_paper_bag");
                            InventoryBag._isBuyingGear = false;
                        }
                        if (Common.purchaseType == ArmorPlateSet)
                        {
                            Function.Call(Hash.SET_TEXT_COLOUR, (InputArgument)0, (InputArgument)(int)byte.MaxValue, (InputArgument)0, (InputArgument)100);
                            Vest.SavePlates(Player, "Armor_Plates", Vest.armorPlatesMax);
                            Notification.Show("Armor plate set set has been ~g~purchased", true);
                            HTools.Main.Notify("Your payment check: ~n~Armor plate set: ~h~" + Vest.armorPlatePrice.ToString() + "~h~~g~$~w~~n~-------------~n~Total sum: ~h~" + Vest.armorPlatePrice.ToString() + "~h~~g~$~w~", "Shopping purchase", 0, (int)byte.MaxValue, 0, NotificationIcon.BankMaze);
                            HungerSystem.clearFoodPacket(Player, "hei_prop_hei_paper_bag");
                            InventoryBag._isBuyingGear = false;
                        }
                        if (Common.purchaseType == Headset)
                        {
                            OnFootRadio.PlayerBoughtHeadset(Player);
                            Function.Call(Hash.SET_TEXT_COLOUR, (InputArgument)0, (InputArgument)(int)byte.MaxValue, (InputArgument)0, (InputArgument)100);
                            Notification.Show("~b~Headset~w~ has been ~g~purchased", true);
                            HTools.Main.Notify("Your payment check: ~n~headset: ~h~" + OnFootRadio.HeadsetPrice.ToString() + "~h~~g~$~w~~n~-------------~n~Total sum: ~h~" + OnFootRadio.HeadsetPrice.ToString() + "~h~~g~$~w~", "Shopping purchase", 0, (int)byte.MaxValue, 0, NotificationIcon.BankMaze);
                            HungerSystem.clearFoodPacket(Player, "hei_prop_hei_paper_bag");
                            InventoryBag._isBuyingGear = false;
                            OnFootRadio.isHeadsetBought = true;

                        }
                        Function.Call(Hash.PLAY_PED_AMBIENT_SPEECH_NATIVE, (InputArgument)(Entity)Player, (InputArgument)"GENERIC_THANKS", (InputArgument)"SPEECH_PARAMS_FORCE");
                        if (Player.Model == (Model)PedHash.Michael || Player.Model == (Model)PedHash.Franklin || Player.Model == (Model)PedHash.Trevor)
                            Game.Player.Money -= Common.purchaseSum;
                    }
                }
            }
            int num3;
            if (Common.pedIsNearShopkeeper)
            {
                int Food_Drinks = 1;
                int Cigs_Pills = 2;
                HTools.Main.DisableControlsFunc(true);
                Common.Draw(6, cameraModuleParam: false, swingWeaponModuleParam: false, laserSightModuleParam: false, weaponJamningModuleParam: false);
                if (Function.Call<bool>(Hash.IS_DISABLED_CONTROL_JUST_PRESSED, (InputArgument)0, (InputArgument)24) && !Game.Player.IsAiming)
                {
                    Common.purchaseType = Food_Drinks;
                    Common.purchaseSum = HungerSystem.foodCost;
                    Common.purchaseProcess = true;
                }
                if (Function.Call<bool>(Hash.IS_DISABLED_CONTROL_JUST_PRESSED, (InputArgument)0, (InputArgument)25) && !Game.Player.IsAiming)
                {
                    Common.purchaseType = Cigs_Pills;
                    Common.purchaseSum = CigsAndPills.cigsAndPillsPrice;
                    Common.purchaseProcess = true;
                }
                if (Common.purchaseProcess)
                {
                    Common.purchaseProcess = false;
                    bool flag = true;
                    if ((Player.Model == (Model)PedHash.Michael || Player.Model == (Model)PedHash.Franklin || Player.Model == (Model)PedHash.Trevor) && Game.Player.Money < Common.purchaseSum)
                        flag = false;
                    if (flag)
                    {
                        HungerSystem._buyingSnacks = true;
                        Function.Call(Hash.PLAY_PED_AMBIENT_SPEECH_NATIVE, (InputArgument)(Entity)Player, (InputArgument)"GENERIC_HI", (InputArgument)"SPEECH_PARAMS_FORCE");
                        Common._shopKeeper.Task.LookAt((Entity)Player, 1000);
                    }
                    else
                    {
                        Screen.ShowHelpText("~BLIP_INFO_ICNO~ You don't have enough money!");
                        Function.Call(Hash.PLAY_PED_AMBIENT_SPEECH_NATIVE, (InputArgument)(Entity)Common._shopKeeper, (InputArgument)"SHOP_BANTER", (InputArgument)"SPEECH_PARAMS_FORCE");
                    }
                }
                if (HungerSystem._buyingSnacks)
                {                    
                    if (!Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Player, (InputArgument)"anim@scripted@heist@ig1_table_grab@gold@male@", (InputArgument)"enter", (InputArgument)3))
                    {
                        Function.Call(Hash.PLAY_PED_AMBIENT_SPEECH_NATIVE, (InputArgument)(Entity)Common._shopKeeper, (InputArgument)"SHOP_SELL", (InputArgument)"SPEECH_PARAMS_FORCE");
                        Player.Task.PlayAnimation("anim@scripted@heist@ig1_table_grab@gold@male@", "enter", 8f, -1, AnimationFlags.UpperBodyOnly | AnimationFlags.Secondary);
                        HungerSystem.createFoodPacket(Player, Player.Position);
                    }
                    else if ((double)Function.Call<float>(Hash.GET_ENTITY_ANIM_CURRENT_TIME, (InputArgument)(Entity)Player, (InputArgument)"anim@scripted@heist@ig1_table_grab@gold@male@", (InputArgument)"enter") > 0.98000001907348633)
                    {
                        if (Common.purchaseType == Food_Drinks)
                        {
                            HungerSystem.updatePedFoodCount(Player, "burgers", 3, Common.doc);
                            HungerSystem.updatePedDrinksCount(Player, "coffee", 3, Common.doc);
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
                            HungerSystem.clearFoodPacket(Player, "hei_prop_hei_paper_bag");
                            HungerSystem._buyingSnacks = false;
                        }
                        if (Common.purchaseType == Cigs_Pills)
                        {
                            if (CigsAndPills.pillsCount < CigsAndPills.maxPills)
                                Common.saveSupplies(Player, "painkillers", CigsAndPills.maxPills);
                            if (CigsAndPills.cigsCount < CigsAndPills.maxCigs)
                                Common.saveSupplies(Player, "ciggaretes", CigsAndPills.maxCigs);
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
                            HungerSystem.clearFoodPacket(Player, "hei_prop_hei_paper_bag");
                            HungerSystem._buyingSnacks = false;
                        }
                        Function.Call(Hash.PLAY_PED_AMBIENT_SPEECH_NATIVE, (InputArgument)(Entity)Player, (InputArgument)"GENERIC_THANKS", (InputArgument)"SPEECH_PARAMS_FORCE");
                        if (Player.Model == (Model)PedHash.Michael || Player.Model == (Model)PedHash.Franklin || Player.Model == (Model)PedHash.Trevor)
                            Game.Player.Money -= Common.purchaseSum;
                    }
                }
            }
            Vector3 vector3_1;
            /*
            if (OnFootRadio.timeReference < Game.GameTime)
            {
                OnFootRadio.timeReference = Game.GameTime + 1000;
                Ped[] nearbyPeds = World.GetNearbyPeds(Player, 5f, (Model)PedHash.ShopMidSFY);
                if (nearbyPeds.Length != 0)
                {
                    vector3_1 = Player.Position;
                    if ((double)vector3_1.DistanceTo(nearbyPeds[0].Position) <= 4.0 && Function.Call<bool>(Hash.IS_PED_FACING_PED, (InputArgument)(Entity)Player, (InputArgument)(Entity)nearbyPeds[0], (InputArgument)15f) && !nearbyPeds[0].IsFleeing && nearbyPeds[0].IsOnScreen)
                    {
                        if ((Entity)Common._SuburbanCashier == (Entity)null || (Entity)Common._SuburbanCashier != (Entity)null && Common._SuburbanCashier.IsDead)
                        {
                            Common._SuburbanCashier = nearbyPeds[0];
                            Player.Task.LookAt((Entity)nearbyPeds[0], 6000);
                        }
                        Common.pedIsNearSuburbanCashier = true;
                    }
                    else
                    {
                        Common._SuburbanCashier = (Ped)null;
                        Common.pedIsNearSuburbanCashier = false;
                        Common.purchaseProcess = false;
                        if (InventoryBag._isBuyingGear)
                        {
                            Player.Task.ClearAll();
                            InventoryBag._isBuyingGear = false;
                        }
                    }
                }
                else
                {
                    Common._SuburbanCashier = (Ped)null;
                    Common.pedIsNearSuburbanCashier = false;
                    Common.purchaseProcess = false;
                    if (InventoryBag._isBuyingGear)
                    {
                        Player.Task.ClearAll();
                        InventoryBag._isBuyingGear = false;
                    }
                }
            }
            */
            if (InventoryBag.timeReference < Game.GameTime)
            {
                InventoryBag.timeReference = Game.GameTime + 1000;
                Ped[] nearbyPeds = World.GetNearbyPeds(Player, 5f, (Model)PedHash.Ammucity01SMY, (Model)PedHash.AmmuCountrySMM);
                if (nearbyPeds.Length != 0)
                {
                    vector3_1 = Player.Position;
                    if ((double)vector3_1.DistanceTo(nearbyPeds[0].Position) <= 4.0 && Function.Call<bool>(Hash.IS_PED_FACING_PED, (InputArgument)(Entity)Player, (InputArgument)(Entity)nearbyPeds[0], (InputArgument)15f) && !nearbyPeds[0].IsFleeing && nearbyPeds[0].IsOnScreen)
                    {
                        if ((Entity)Common._GunDealer == (Entity)null || (Entity)Common._GunDealer != (Entity)null && Common._GunDealer.IsDead)
                        {
                            Common._GunDealer = nearbyPeds[0];
                            Player.Task.LookAt((Entity)nearbyPeds[0], 6000);
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
                            Player.Task.ClearAll();
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
                        Player.Task.ClearAll();
                        InventoryBag._isBuyingGear = false;
                    }
                }
            }
            if (HungerSystem.hungerTimeRef2 < Game.GameTime)
            {
                HungerSystem.hungerTimeRef2 = Game.GameTime + 1000;
                Ped[] nearbyPeds = World.GetNearbyPeds(Player, 5f, (Model)PedHash.ShopKeep01);
                if (nearbyPeds.Length != 0)
                {
                    vector3_1 = Player.Position;
                    if ((double)vector3_1.DistanceTo(nearbyPeds[0].Position) <= 4.0 && Function.Call<bool>(Hash.IS_PED_FACING_PED, (InputArgument)(Entity)Player, (InputArgument)(Entity)nearbyPeds[0], (InputArgument)15f) && !nearbyPeds[0].IsFleeing && nearbyPeds[0].IsOnScreen && nearbyPeds[0].IsAlive)
                    {
                        if ((Entity)Common._shopKeeper == (Entity)null || (Entity)Common._shopKeeper != (Entity)null && Common._shopKeeper.IsDead)
                        {
                            Common._shopKeeper = nearbyPeds[0];
                            Player.Task.LookAt((Entity)nearbyPeds[0], 6000);
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
                            Player.Task.ClearAll();
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
                        Player.Task.ClearAll();
                        HungerSystem._buyingSnacks = false;
                    }
                }
            }
            if (HungerSystem.hungerModuleActive)
            {
                HungerSystem.hungerBar.Percentage = HungerSystem.curHungerLvl > 0 ? (float)((double)HungerSystem.curHungerLvl / (double)HungerSystem.hunger_lvl_max * 100.0) : 0.0f;

                if (HungerSystem.hungerTimeRef > Game.GameTime)
                {
                    HungerSystem.hungerTimeRef = Game.GameTime + 30000;
                    HungerSystem.curHungerLvl = HungerSystem.savePedHungerLvl(Player, HungerSystem.getPedHungerLvl(Player, Common.doc) - 1, HungerSystem.hunger_lvl_max, Common.doc);
                    //HungerSystem.hungerBar.Percentage = HungerSystem.curHungerLvl > 0 ? (float)((double)HungerSystem.curHungerLvl / (double)HungerSystem.hunger_lvl_max * 100.0) : 0.0f;

                    if (HungerSystem.curHungerLvl < HungerSystem.hunger_lvl_max / 100 * 50)
                    {
                        if (HungerSystem.curHungerLvl < HungerSystem.hunger_lvl_max / 100 * 25 && Player.IsAlive)
                        {

                            HTools.Main.soundFX(Player, "StomachGrowling.wav", Common.assetFolder, 13f);
                            HungerSystem.hungerBar.ForegroundColor = Color.Red;
                        }
                        if (!HTools.Main.barPool.ToList().Contains(HungerSystem.hungerBar))
                            HTools.Main.barPool.Add(HungerSystem.hungerBar);
                    }
                    else if (HTools.Main.barPool.ToList().Contains(HungerSystem.hungerBar))
                        HTools.Main.barPool.Remove(HungerSystem.hungerBar);
                    if (HungerSystem.curHungerLvl <= HungerSystem.criticalHungerLvl)
                    {
                        Player.HealthFloat -= 0.5f;
                        if (!HungerSystem.isHungry)
                        {
                            HTools.Main.Notify("You're ~r~starving~w~.~n~Eat some ~g~food~w~ using the ~b~Main ~y~Menu~w~", "Health Report", 0, (int)byte.MaxValue, 0, NotificationIcon.LesterDeathwish);
                            HTools.Main.startBleeding(Player, false, useInjuryAnim: false);
                        }
                        HungerSystem.isHungry = true;
                    }
                    else
                    {
                        if (HungerSystem.isHungry)
                            HTools.Main.stopBleeding(Player, false);
                        HungerSystem.isHungry = false;
                    }
                    if (HungerSystem.isHungry && Player.IsAlive)
                        HTools.Main.soundFX(Player, "StomachGrowling.wav", Common.assetFolder, 13f);
                }
            }
            if (HungerSystem.hungerModuleActive)
            {
                HungerSystem.thirstBar.Percentage = HungerSystem.curThirstLvl > 0 ? (float)((double)HungerSystem.curThirstLvl / (double)HungerSystem.thirst_lvl_max * 100.0) : 0.0f;

                if (HungerSystem.thirstTimeRef < Game.GameTime)
                {
                    HungerSystem.thirstTimeRef = Game.GameTime + 30000;
                    HungerSystem.curThirstLvl = HungerSystem.savePedThirstLvl(Player, HungerSystem.getPedThirstLvl(Player, Common.doc) - 1, HungerSystem.thirst_lvl_max, Common.doc);
                    //HungerSystem.thirstBar.Percentage = HungerSystem.curThirstLvl > 0 ? (float)((double)HungerSystem.curThirstLvl / (double)HungerSystem.thirst_lvl_max * 100.0) : 0.0f;
                    if (HungerSystem.curThirstLvl < HungerSystem.thirst_lvl_max / 100 * 50)
                    {
                        if (HungerSystem.curThirstLvl < HungerSystem.thirst_lvl_max / 100 * 25 && Player.IsAlive)
                        {
                            if (!HungerSystem.isHungry)
                                HTools.Main.soundFX(Player, "StomachGrowling.wav", Common.assetFolder, 13f);
                            HungerSystem.thirstBar.ForegroundColor = Color.Red;
                        }
                        if (!HTools.Main.barPool.ToList().Contains(HungerSystem.thirstBar))
                            HTools.Main.barPool.Add(HungerSystem.thirstBar);
                    }
                    else if (HTools.Main.barPool.ToList().Contains(HungerSystem.thirstBar))
                        HTools.Main.barPool.Remove(HungerSystem.thirstBar);
                    if (HungerSystem.curThirstLvl <= HungerSystem.criticalThirstLvl)
                    {
                        Player.HealthFloat -= 0.5f;
                        if (!HungerSystem.isThirsty)
                        {
                            HTools.Main.Notify("You're ~r~dehydrated~w~.~n~Drink ~g~fluids~w~ using the ~b~Main ~y~Menu~w~", "Health Report", 0, (int)byte.MaxValue, 0, NotificationIcon.LesterDeathwish);
                            HTools.Main.startBleeding(Player, false, useInjuryAnim: false);
                        }
                        HungerSystem.isThirsty = true;
                    }
                    else
                    {
                        if (HungerSystem.isThirsty)
                            HTools.Main.stopBleeding(Player, false);
                        HungerSystem.isThirsty = false;
                    }
                    if (HungerSystem.isThirsty && Player.IsAlive && !HungerSystem.isHungry)

                        HTools.Main.soundFX(Player, "StomachGrowling.wav", Common.assetFolder, 13f);
                }
            }
            if (WeaponHolster.holster_module_active)
            {
                if (WeaponHolster.customHolsterAnim && !WeaponHolster.intimidation && (Entity)InventoryBag.bagModelReturn(Player) == (Entity)null)
                {
                    if ((double)Function.Call<float>(Hash.GET_ENTITY_ANIM_CURRENT_TIME, (InputArgument)(Entity)Player, (InputArgument)"reaction@intimidation@cop@unarmed", (InputArgument)"outro") > 0.2 && (Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Player, (InputArgument)"move_m@intimidation@cop@unarmed", (InputArgument)"idle", (InputArgument)3) || Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Player, (InputArgument)"reaction@intimidation@cop@unarmed", (InputArgument)"intro", (InputArgument)3) || Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Player, (InputArgument)"reaction@intimidation@cop@unarmed", (InputArgument)"outro", (InputArgument)3) || Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Player, (InputArgument)"mp_arrest_paired", (InputArgument)"cop_p1_rf_right_0", (InputArgument)3)))
                    {
                        Function.Call(Hash.STOP_ENTITY_ANIM, (InputArgument)(Entity)Player, (InputArgument)"idle", (InputArgument)"move_m@intimidation@cop@unarmed", (InputArgument)3);
                        Function.Call(Hash.STOP_ENTITY_ANIM, (InputArgument)(Entity)Player, (InputArgument)"intro", (InputArgument)"reaction@intimidation@cop@unarmed", (InputArgument)3);
                        Function.Call(Hash.STOP_ENTITY_ANIM, (InputArgument)(Entity)Player, (InputArgument)"outro", (InputArgument)"reaction@intimidation@cop@unarmed", (InputArgument)3);
                        Function.Call(Hash.STOP_ENTITY_ANIM, (InputArgument)(Entity)Player, (InputArgument)"cop_p1_rf_right_0", (InputArgument)"mp_arrest_paired", (InputArgument)3);
                    }
                    if ((Entity)WeaponHolster.holster != (Entity)null && WeaponHolster.holster.Exists() && WeaponHolster.holsterSet && !Common.isOccupied(Player) && !HTools.Main.isOccupiedNative(Player) && !Function.Call<bool>(Hash.IS_PED_RUNNING_MOBILE_PHONE_TASK, (InputArgument)(Entity)Player) && !Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Player, (InputArgument)"reaction@intimidation@cop@unarmed", (InputArgument)"intro", (InputArgument)3) && !Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Player, (InputArgument)"move_m@intimidation@cop@unarmed", (InputArgument)"idle", (InputArgument)3) && !Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Player, (InputArgument)"reaction@intimidation@cop@unarmed", (InputArgument)"outro", (InputArgument)3) && WeaponHolster.weaponPistolInHands != WeaponHolster.pistolChanged)
                    {
                        WeaponHolster.pistolChanged = WeaponHolster.weaponPistolInHands;
                        if (!Player.IsSittingInVehicle())
                        {
                            if (!Function.Call<bool>(Hash.GET_PED_STEALTH_MOVEMENT, (InputArgument)(Entity)Player) && !Player.IsInCombat && !Player.IsDucking)
                            {
                                if (Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Player, (InputArgument)"mp_arrest_paired", (InputArgument)"cop_p1_rf_right_0", (InputArgument)3))
                                    Function.Call(Hash.STOP_ENTITY_ANIM, (InputArgument)(Entity)Player, (InputArgument)"cop_p1_rf_right_0", (InputArgument)"mp_arrest_paired", (InputArgument)3);
                                if (!Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Player, (InputArgument)"reaction@intimidation@cop@unarmed", (InputArgument)"outro", (InputArgument)3))
                                    Function.Call(Hash.TASK_PLAY_ANIM, (InputArgument)(Entity)Player, (InputArgument)"reaction@intimidation@cop@unarmed", (InputArgument)"outro", (InputArgument)8f, (InputArgument)(-8.0), (InputArgument)(-1), (InputArgument)48, (InputArgument)0.0f, (InputArgument)0, (InputArgument)0, (InputArgument)0);
                            }
                            else if (!Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Player, (InputArgument)"mp_arrest_paired", (InputArgument)"cop_p1_rf_right_0", (InputArgument)3))
                                Function.Call(Hash.TASK_PLAY_ANIM, (InputArgument)(Entity)Player, (InputArgument)"mp_arrest_paired", (InputArgument)"cop_p1_rf_right_0", (InputArgument)8f, (InputArgument)(-8.0), (InputArgument)(-1), (InputArgument)48, (InputArgument)0.0f, (InputArgument)0, (InputArgument)0, (InputArgument)0);
                            HTools.Main.soundFX(Player, "holster.wav", Common.assetFolder);
                        }
                    }
                }
                if (WeaponHolster.intimidation)
                {
                    Common.Draw(4);
                    HTools.Main.DisableControlsFunc(false);
                    if (!Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Player, (InputArgument)"move_m@intimidation@cop@unarmed", (InputArgument)"idle", (InputArgument)3) && !Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Player, (InputArgument)"reaction@intimidation@cop@unarmed", (InputArgument)"intro", (InputArgument)3) && !Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Player, (InputArgument)"reaction@intimidation@cop@unarmed", (InputArgument)"outro", (InputArgument)3))
                        Player.Task.PlayAnimation("move_m@intimidation@cop@unarmed", "idle", 12f, -1, AnimationFlags.StayInEndFrame | AnimationFlags.Secondary | AnimationFlags.AbortOnPedMovement);
                    else if (Game.IsControlJustPressed(Control.Attack) && (Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Player, (InputArgument)"move_m@intimidation@cop@unarmed", (InputArgument)"idle", (InputArgument)3) || Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Player, (InputArgument)"reaction@intimidation@cop@unarmed", (InputArgument)"intro", (InputArgument)3) || Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Player, (InputArgument)"reaction@intimidation@cop@unarmed", (InputArgument)"outro", (InputArgument)3)))
                    {
                        WeaponHolster.AttackSpeech(Player);
                        WeaponHolster.GetClosestPedDetectionFunction(Player);
                    }
                    else if (Game.IsControlJustPressed(Control.Aim))
                    {
                        WeaponHolster.intimidation = false;
                        Player.Task.ClearAll();
                    }
                }
                if (WeaponHolster.holsterTimerCounterLong < Game.GameTime)
                {
                    WeaponHolster.holsterTimerCounterLong = Game.GameTime + 5000;
                    if ((Entity)WeaponHolster.target != (Entity)null)
                    {
                        vector3_1 = WeaponHolster.target.Position;
                        if ((double)vector3_1.DistanceTo(Player.Position) > 50.0 || !WeaponHolster.target.Exists() || WeaponHolster.target.IsDead)
                            WeaponHolster.target.MarkAsNoLongerNeeded();
                        WeaponHolster.target = (Ped)null;
                    }
                    if (!WeaponHolster.check)
                    {
                        WeaponHolster.GetHolsterPropFunction(Player);
                        WeaponHolster.check = true;
                    }
                    if ((Entity)WeaponHolster.holster == (Entity)null && Function.Call<bool>(Hash.DOES_OBJECT_OF_TYPE_EXIST_AT_COORDS, (InputArgument)Player.Position.X, (InputArgument)Player.Position.Y, (InputArgument)Player.Position.Z, (InputArgument)3f, (InputArgument)WeaponHolster.worldPistolModel, (InputArgument)0) && Function.Call<bool>(Hash.IS_ENTITY_ATTACHED_TO_ENTITY, (InputArgument)(Entity)Function.Call<Prop>(Hash.GET_CLOSEST_OBJECT_OF_TYPE, (InputArgument)Player.Position.X, (InputArgument)Player.Position.Y, (InputArgument)Player.Position.Z, (InputArgument)3f, (InputArgument)WeaponHolster.worldPistolModel, (InputArgument)true, (InputArgument)false, (InputArgument)false), (InputArgument)(Entity)Player) && (Entity)WeaponHolster.HolstedPistol != (Entity)null)
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
                    if (Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Player, (InputArgument)"missmic2@meat_hook", (InputArgument)"michael_meat_hook_fall", (InputArgument)3) || Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Player, (InputArgument)"missmic2@meat_hook", (InputArgument)"michael_meat_hook_idle", (InputArgument)3) || Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Player, (InputArgument)"missmic2@meat_hook", (InputArgument)"michael_meat_hook_react_a", (InputArgument)3) || Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Player, (InputArgument)"missmic2@meat_hook", (InputArgument)"michael_meat_hook_react_b", (InputArgument)3) || Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Player, (InputArgument)"missmic2@meat_hook", (InputArgument)"michael_meat_hook_react_c", (InputArgument)3) || Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Player, (InputArgument)"missmic2@meat_hook", (InputArgument)"michael_meat_hook_react_d", (InputArgument)3))
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
                    if (WeaponHolster.holsterSet && (Entity)WeaponHolster.holster != (Entity)null && WeaponHolster.holster.Exists() && WeaponHolster.holster.IsAttachedTo((Entity)Player))
                    {
                        WeaponHolster.IconHolsterDrawFunc(Player, WeaponHolster.weaponPistolInHands);
                        if (((IEnumerable<WeaponGroup>)WeaponHolster._pistolWeaponGroup).Contains<WeaponGroup>(Player.Weapons.Current.Group))
                        {
                            WeaponHolster.worldPistolModel = (int)Player.Weapons.CurrentWeaponObject.Model;
                            WeaponHolster.choosenPistol = Player.Weapons.Current.Hash;
                        }
                        WeaponHolster.weaponPistolInHands = Player.Weapons.Current.Hash == WeaponHolster.choosenPistol;
                    }
                    if (((IEnumerable<WeaponGroup>)WeaponHolster._bigWeaponGroups).Contains<WeaponGroup>(Player.Weapons.Current.Group))
                    {
                        WeaponHolster.worldNonPistolWeaponModel = (int)Player.Weapons.CurrentWeaponObject.Model;
                        WeaponHolster.choosenNonPistolWeapon = (Model)Player.Weapons.Current.Hash;
                    }
                    WeaponHolster.weaponNonPistolInHands = (Model)Player.Weapons.Current.Hash == WeaponHolster.choosenNonPistolWeapon;
                    if (!Function.Call<bool>(Hash.IS_PLAYER_SWITCH_IN_PROGRESS) && !Screen.IsFadingIn && !Screen.IsFadingOut && !Function.Call<bool>(Hash.IS_CUTSCENE_PLAYING) && Game.Player.CanControlCharacter)
                    {
                        WeaponHolster.player = Player;
                    }
                    else
                    {
                        WeaponHolster.prevPlayer = WeaponHolster.player;
                        WeaponHolster.HolstedPistolPrev = WeaponHolster.HolstedPistol;
                    }
                    if ((Entity)WeaponHolster.player != (Entity)Player)
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
                        WeaponHolster.checkHolsterAfterCharacterSwitch(Player, WeaponHolster.useHipHolster);
                    }
                    if ((Entity)WeaponHolster.holster != (Entity)null && WeaponHolster.holster.Exists() && Function.Call<bool>(Hash.IS_ENTITY_ATTACHED_TO_ENTITY, (InputArgument)(Entity)WeaponHolster.holster, (InputArgument)(Entity)Player) && WeaponHolster.worldPistolModel != 0)
                    {
                        WeaponHolster.HolstedPistol = WeaponHolster.removeHolstedPistolFunc(Player, WeaponHolster.HolstedPistol, WeaponHolster.choosenPistol, WeaponHolster.worldPistolModel);
                        if (!Common.isOccupied(Player) && !HTools.Main.isOccupiedNative(Player) && !Player.IsSittingInVehicle())
                            WeaponHolster.HolstedPistol = WeaponHolster.checkPistolFunc(Player, WeaponHolster.holster, WeaponHolster.weaponPistolInHands, WeaponHolster.choosenPistol, WeaponHolster.worldPistolModel, WeaponHolster.HolstedPistol, WeaponHolster.useHipHolster, false, new Vector3(0.0f, 0.0f, 0.0f), new Vector3(0.0f, 0.0f, 0.0f), 0);
                    }
                    if (WeaponHolster.worldNonPistolWeaponModel != 0 && WeaponHolster.holsted_big_weapons_module_active)
                    {
                        WeaponHolster.HolstedNonPistolWeapon = WeaponHolster.removeHolstedPistolFunc(Player, WeaponHolster.HolstedNonPistolWeapon, (WeaponHash)WeaponHolster.choosenNonPistolWeapon, WeaponHolster.worldNonPistolWeaponModel);
                        if (!Common.isOccupied(Player) && !HTools.Main.isOccupiedNative(Player) && !Player.IsSittingInVehicle())
                            WeaponHolster.HolstedNonPistolWeapon = WeaponHolster.checkPistolFunc(Player, (Prop)null, WeaponHolster.weaponNonPistolInHands, (WeaponHash)WeaponHolster.choosenNonPistolWeapon, WeaponHolster.worldNonPistolWeaponModel, WeaponHolster.HolstedNonPistolWeapon, WeaponHolster.useHipHolster, true, WeaponHolster.holstedWeaponAttachPos, WeaponHolster.holstedWeaponAttachRot, WeaponHolster.holstedWeaponAttachBone, positionTypeParam: WeaponHolster.weaponPositionType);
                        if (!WeaponHolster.weaponNonPistolInHands && (Entity)WeaponHolster.HolstedNonPistolWeapon != (Entity)null && Player.IsJumping)
                        {
                            if (WeaponHolster.weaponSoundFXTimer <= 0)
                            {
                                if (Player.IsJumping)
                                    WeaponHolster.weaponSoundFXTimer = 0;
                                HTools.Main.soundFX(Player, WeaponHolster.weaponSoundsFXArray[WeaponHolster.weaponSoundFXIndex], Common.assetFolder);
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
                model = Player.Model;
                if (model.Hash != HTools.Main.GetHashKey("mp_m_freemode_01"))
                {
                    model = Player.Model;
                    if (model.Hash != HTools.Main.GetHashKey("mp_f_freemode_01"))
                    {
                        model = Player.Model;
                        if (model.Hash != HTools.Main.GetHashKey("PLAYER_ZERO"))
                        {
                            model = Player.Model;
                            if (model.Hash != HTools.Main.GetHashKey("PLAYER_ONE"))
                            {
                                model = Player.Model;
                                if (model.Hash != HTools.Main.GetHashKey("PLAYER_TWO"))
                                    goto label_611;
                            }
                        }
                    }
                }
                int num5 = Function.Call<int>(Hash.GET_PED_PROP_INDEX, (InputArgument)(Entity)Player, (InputArgument)2);
                OnFootRadio.headset = false;
                if (num5 == 0)
                    OnFootRadio.headset = true;
                label_611:
                if (!OnFootRadio.headset && Function.Call<bool>(Hash.IS_MOBILE_PHONE_RADIO_ACTIVE))
                {
                    Vector3 position = new Vector3(266.1459f, -1007.036f, -100.9292f);
                    vector3_1 = Player.Position;
                    if ((double)vector3_1.DistanceTo(position) > 50.0 && !Function.Call<bool>(Hash.DOES_OBJECT_OF_TYPE_EXIST_AT_COORDS, (InputArgument)Player.Position.X, (InputArgument)Player.Position.Y, (InputArgument)Player.Position.Z, (InputArgument)25f, (InputArgument)HTools.Main.GetHashKey("prop_boombox_01"), (InputArgument)0))
                    {
                        Function.Call(Hash.SET_MOBILE_PHONE_RADIO_STATE, (InputArgument)false);
                        Function.Call(Hash.SET_MOBILE_RADIO_ENABLED_DURING_GAMEPLAY, (InputArgument)false);
                    }
                }
            }
            if ((Function.Call<bool>(Hash.IS_CONTROL_PRESSED, (InputArgument)0, (InputArgument)85) || Function.Call<bool>(Hash.IS_CONTROL_JUST_PRESSED, (InputArgument)0, (InputArgument)81) || Function.Call<bool>(Hash.IS_CONTROL_JUST_PRESSED, (InputArgument)0, (InputArgument)82)) && !Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Player, (InputArgument)"anim@cellphone@in_car@ds", (InputArgument)"cellphone_text_to_call", (InputArgument)3))
            {
                if (OnFootRadio.headset && !Function.Call<bool>(Hash.IS_PED_RUNNING_MOBILE_PHONE_TASK, (InputArgument)(Entity)Player) && !Function.Call<bool>(Hash.IS_PED_RUNNING_RAGDOLL_TASK, (InputArgument)(Entity)Player) && !Function.Call<bool>(Hash.IS_PED_DOING_DRIVEBY, (InputArgument)(Entity)Player) && !Function.Call<bool>(Hash.IS_PLAYER_FREE_AIMING, (InputArgument)Game.Player) && !Player.IsSittingInVehicle())
                {
                    Player.Task.ClearAll();
                    Function.Call(Hash.TASK_PLAY_ANIM, (InputArgument)(Entity)Player, (InputArgument)"anim@cellphone@in_car@ds", (InputArgument)"cellphone_text_to_call", (InputArgument)45f, (InputArgument)(-12.0), (InputArgument)(-1), (InputArgument)50, (InputArgument)0.0f, (InputArgument)0, (InputArgument)0, (InputArgument)0);
                }
            }
            else if ((Function.Call<bool>(Hash.IS_CONTROL_JUST_RELEASED, (InputArgument)0, (InputArgument)85) || Function.Call<bool>(Hash.IS_CONTROL_JUST_RELEASED, (InputArgument)0, (InputArgument)81) || Function.Call<bool>(Hash.IS_CONTROL_JUST_RELEASED, (InputArgument)0, (InputArgument)82)) && !Function.Call<bool>(Hash.IS_PED_RUNNING_MOBILE_PHONE_TASK) && Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Player, (InputArgument)"anim@cellphone@in_car@ds", (InputArgument)"cellphone_text_to_call", (InputArgument)3) && !Function.Call<bool>(Hash.IS_MOBILE_PHONE_CALL_ONGOING, (InputArgument)false) && !Player.IsSittingInVehicle())
            {
                if (Function.Call<bool>(Hash.IS_CONTROL_JUST_RELEASED, (InputArgument)0, (InputArgument)81) || Function.Call<bool>(Hash.IS_CONTROL_JUST_RELEASED, (InputArgument)0, (InputArgument)82))
                {
                    Script.Wait(1000);
                    Function.Call(Hash.STOP_ENTITY_ANIM, (InputArgument)(Entity)Player, (InputArgument)"cellphone_text_to_call", (InputArgument)"anim@cellphone@in_car@ds", (InputArgument)3);
                }
                else
                {
                    Script.Wait(200);
                    Function.Call(Hash.STOP_ENTITY_ANIM, (InputArgument)(Entity)Player, (InputArgument)"cellphone_text_to_call", (InputArgument)"anim@cellphone@in_car@ds", (InputArgument)3);
                }
            }
            if (Wallet.walletCount && !CigsAndPills.smoking)
            {
                Function.Call(Hash.SET_CURRENT_PED_WEAPON, (InputArgument)(Entity)Player, (InputArgument)2725352035U, (InputArgument)true);
                Function.Call(Hash.SET_PED_CAN_PLAY_GESTURE_ANIMS, (InputArgument)(Entity)Player, (InputArgument)false);
                Function.Call<int>(Hash.GET_PED_BONE_INDEX, (InputArgument)(Entity)Player, (InputArgument)36029);
                int num6 = Function.Call<int>(Hash.GET_PED_BONE_INDEX, (InputArgument)(Entity)Player, (InputArgument)6286);
                if (!Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Player, (InputArgument)"anim@amb@board_room@supervising@", (InputArgument)"dissaproval_01_lo_amy_skater_01", (InputArgument)3))
                {
                    Wallet.animSpeed = 1f;
                    Player.Task.LookAt((Entity)Player);
                    Function.Call(Hash.ATTACH_ENTITY_TO_ENTITY, (InputArgument)(Entity)Wallet.wallet, (InputArgument)(Entity)Player, (InputArgument)num6, (InputArgument)0.1, (InputArgument)0.015, (InputArgument)(-0.025), (InputArgument)115.0, (InputArgument)20.0, (InputArgument)0.0, (InputArgument)false, (InputArgument)false, (InputArgument)false, (InputArgument)false, (InputArgument)0, (InputArgument)true);
                    Player.Task.PlayAnimation("anim@amb@board_room@supervising@", "dissaproval_01_lo_amy_skater_01", Wallet.animSpeed, -1, AnimationFlags.UpperBodyOnly | AnimationFlags.Secondary);
                }
                else
                {
                    if ((double)Wallet.animSpeed < 2.0)
                        Wallet.animSpeed += 0.01f;
                    double num7 = (double)Function.Call<float>(Hash.SET_ENTITY_ANIM_SPEED, (InputArgument)(Entity)Player, (InputArgument)"anim@amb@board_room@supervising@", (InputArgument)"dissaproval_01_lo_amy_skater_01", (InputArgument)Wallet.animSpeed);
                    if ((double)Function.Call<float>(Hash.GET_ENTITY_ANIM_CURRENT_TIME, (InputArgument)(Entity)Player, (InputArgument)"anim@amb@board_room@supervising@", (InputArgument)"dissaproval_01_lo_amy_skater_01") > 0.10000000149011612 && (double)Function.Call<float>(Hash.GET_ENTITY_ANIM_CURRENT_TIME, (InputArgument)(Entity)Player, (InputArgument)"anim@amb@board_room@supervising@", (InputArgument)"dissaproval_01_lo_amy_skater_01") < 0.5)
                    {
                        if ((Entity)Wallet.walletOpened != (Entity)null)
                            Wallet.walletOpened.IsVisible = true;
                        if ((Entity)Wallet.wallet != (Entity)null)
                            Wallet.wallet.IsVisible = false;
                    }
                    if ((double)Function.Call<float>(Hash.GET_ENTITY_ANIM_CURRENT_TIME, (InputArgument)(Entity)Player, (InputArgument)"anim@amb@board_room@supervising@", (InputArgument)"dissaproval_01_lo_amy_skater_01") > 0.5)
                    {
                        if (Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Player, (InputArgument)"anim@amb@board_room@supervising@", (InputArgument)"dissaproval_01_lo_amy_skater_01", (InputArgument)3))
                        {
                            Player.Task.ClearAnimation("anim@amb@board_room@supervising@", "dissaproval_01_lo_amy_skater_01");
                            num3 = 9999999;
                            string str = num3.ToString() + "~g~~h~$~h~~w~";
                            if (Player.Model == (Model)PedHash.Michael || Player.Model == (Model)PedHash.Franklin || Player.Model == (Model)PedHash.Trevor)
                            {
                                num3 = Game.Player.Money;
                                str = num3.ToString() + " ~g~~h~$~h~~w~";
                            }
                            HTools.Main.Notify("Current balance: " + str, "Money in Wallet has been Counted", 0, (int)byte.MaxValue, 0, NotificationIcon.BankMaze);
                            Function.Call(Hash.PLAY_SOUND_FRONTEND, (InputArgument)(-1), (InputArgument)"LOCAL_PLYR_CASH_COUNTER_COMPLETE", (InputArgument)"DLC_HEISTS_GENERAL_FRONTEND_SOUNDS", (InputArgument)0);
                        }
                        if (!Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Player, (InputArgument)"mp_arrest_paired", (InputArgument)"cop_p1_rf_right_0", (InputArgument)3))
                        {
                            Function.Call(Hash.ATTACH_ENTITY_TO_ENTITY, (InputArgument)(Entity)Wallet.wallet, (InputArgument)(Entity)Player, (InputArgument)num6, (InputArgument)0.1, (InputArgument)0.015, (InputArgument)(-0.025), (InputArgument)115.0, (InputArgument)20.0, (InputArgument)0.0, (InputArgument)false, (InputArgument)false, (InputArgument)false, (InputArgument)false, (InputArgument)0, (InputArgument)true);
                            if ((Entity)Wallet.walletOpened != (Entity)null)
                                Wallet.walletOpened.IsVisible = false;
                            if ((Entity)Wallet.wallet != (Entity)null)
                                Wallet.wallet.IsVisible = true;
                            Function.Call(Hash.TASK_PLAY_ANIM, (InputArgument)(Entity)Player, (InputArgument)"mp_arrest_paired", (InputArgument)"cop_p1_rf_right_0", (InputArgument)4f, (InputArgument)(-4f), (InputArgument)(-1), (InputArgument)48, (InputArgument)0.0f, (InputArgument)0, (InputArgument)0, (InputArgument)0);
                            HTools.Main.soundFX(Player, "grab.wav", Common.assetFolder);
                            Script.Wait(700);
                            if (Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Player, (InputArgument)"mp_arrest_paired", (InputArgument)"cop_p1_rf_right_0", (InputArgument)3))
                                Player.Task.ClearAnimation("mp_arrest_paired", "cop_p1_rf_right_0");
                        }
                        if ((Entity)Wallet.wallet != (Entity)null && Wallet.wallet.Exists())
                        {
                            Wallet.wallet.Delete();
                            Wallet.wallet = (Prop)null;
                        }
                        else if (Function.Call<Prop>(Hash.GET_CLOSEST_OBJECT_OF_TYPE, (InputArgument)Player.Position.X, (InputArgument)Player.Position.Y, (InputArgument)Player.Position.Z, (InputArgument)3f, (InputArgument)HTools.Main.GetHashKey("prop_ld_wallet_02"), (InputArgument)true, (InputArgument)false, (InputArgument)false).Exists())
                        {
                            Prop prop = Function.Call<Prop>(Hash.GET_CLOSEST_OBJECT_OF_TYPE, (InputArgument)Player.Position.X, (InputArgument)Player.Position.Y, (InputArgument)Player.Position.Z, (InputArgument)3f, (InputArgument)HTools.Main.GetHashKey("prop_ld_wallet_02"), (InputArgument)true, (InputArgument)false, (InputArgument)false);
                            if ((Entity)prop != (Entity)Wallet.wallet && Function.Call<bool>(Hash.IS_ENTITY_ATTACHED_TO_ENTITY, (InputArgument)(Entity)prop, (InputArgument)(Entity)Player) && prop.Exists())
                                prop.Delete();
                        }
                        if ((Entity)Wallet.walletOpened != (Entity)null && Wallet.walletOpened.Exists())
                        {
                            Wallet.walletOpened.Delete();
                            Wallet.walletOpened = (Prop)null;
                        }
                        else if (Function.Call<Prop>(Hash.GET_CLOSEST_OBJECT_OF_TYPE, (InputArgument)Player.Position.X, (InputArgument)Player.Position.Y, (InputArgument)Player.Position.Z, (InputArgument)3f, (InputArgument)HTools.Main.GetHashKey("prop_ld_wallet_pickup"), (InputArgument)true, (InputArgument)false, (InputArgument)false).Exists())
                        {
                            Prop prop = Function.Call<Prop>(Hash.GET_CLOSEST_OBJECT_OF_TYPE, (InputArgument)Player.Position.X, (InputArgument)Player.Position.Y, (InputArgument)Player.Position.Z, (InputArgument)3f, (InputArgument)HTools.Main.GetHashKey("prop_ld_wallet_pickup"), (InputArgument)true, (InputArgument)false, (InputArgument)false);
                            if ((Entity)prop != (Entity)Wallet.wallet && Function.Call<bool>(Hash.IS_ENTITY_ATTACHED_TO_ENTITY, (InputArgument)(Entity)prop, (InputArgument)(Entity)Player) && prop.Exists())
                                prop.Delete();
                        }
                        Wallet.walletCount = false;
                        Wallet.inProcessWallet = false;
                    }
                }
            }
            if (CigsAndPills.play_swallow_pills_anim)
                CigsAndPills.SwallowPillsFunction(Player);
            if (CigsAndPills.blockKeys)
            {
                if (Player.Weapons.Current.Hash != WeaponHash.Unarmed)
                    Function.Call(Hash.SET_CURRENT_PED_WEAPON, (InputArgument)(Entity)Player, (InputArgument)2725352035U, (InputArgument)true);
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
                        HTools.Main.soundFX(Player, "sizzle.wav", Common.assetFolder, 7f);
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
                    CigsAndPills.sizzle = Player.Gender == Gender.Male || Player.IsSittingInVehicle() ? 150 : 10;
                }
            }
            if (CigsAndPills.smoke == 1 && CigsAndPills.smoking && !Player.IsSittingInVehicle() && (!CigsAndPills.cigReady || CigsAndPills.cigReady && !CigsAndPills.readyToIgnite))
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
                    if (Player.Health <= Player.MaxHealth)
                        num3 = ++Player.Health;
                    double num8 = (double)Function.Call<float>(Hash.SET_PED_MOVE_RATE_OVERRIDE, (InputArgument)(Entity)Player, (InputArgument)1.15f);
                }
                else
                {
                    double num9 = (double)Function.Call<float>(Hash.SET_PED_MOVE_RATE_OVERRIDE, (InputArgument)(Entity)Player, (InputArgument)1f);
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
                        if (Player.Weapons.Current.AmmoInClip > FocusMode.focusTargetedPeds.Length)
                        {
                            Vector3 source = Function.Call<Vector3>(Hash.GET_GAMEPLAY_CAM_COORD);
                            Vector3 vector3_3 = Function.Call<Vector3>(Hash.GET_GAMEPLAY_CAM_ROT);
                            float num10 = vector3_3.Z * ((float)System.Math.PI / 180f);
                            float num11 = vector3_3.X * ((float)System.Math.PI / 180f);
                            float num12 = (float)System.Math.Abs(System.Math.Cos((double)num11));
                            Ped _hitedPed = World.GetClosestPed(World.Raycast(source, source + new Vector3((float)(System.Math.Sin((double)num10) * (double)num12 * -1.0), (float)System.Math.Cos((double)num10) * num12, (float)System.Math.Sin((double)num11)) * 1000f, IntersectFlags.Peds).HitPosition, 1f);
                            if ((Entity)_hitedPed != (Entity)null && (Entity)_hitedPed != (Entity)Player && !Function.Call<bool>(Hash.IS_PED_IN_GROUP, (InputArgument)(Entity)_hitedPed, (InputArgument)Player.PedGroup))
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
                                float num13 = (float)(0.10000000149011612 * ((double)vector3_1.DistanceTo(Player.Position) / 10.0));
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
                    if (Function.Call<bool>(Hash.IS_DISABLED_CONTROL_JUST_PRESSED, (InputArgument)0, (InputArgument)FocusMode.focus_mode_btn) && Player.IsOnFoot && Game.Player.CanControlCharacter)
                    {
                        if (((IEnumerable<WeaponGroup>)WeaponHolster._pistolWeaponGroup).Contains<WeaponGroup>(Player.Weapons.Current.Group) || ((IEnumerable<WeaponGroup>)WeaponHolster._bigWeaponGroups).Contains<WeaponGroup>(Player.Weapons.Current.Group))
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
                                        Function.Call(Hash.SET_PLAYER_ANGRY, (InputArgument)(Entity)Player, (InputArgument)true);
                                        Function.Call(Hash.PLAY_PED_AMBIENT_SPEECH_NATIVE, (InputArgument)(Entity)Player, (InputArgument)"DRAW_GUN", (InputArgument)"SPEECH_PARAMS_FORCE");
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
                    if (FocusMode.focusButtonPressedCounter >= 5 && (!Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Player, (InputArgument)"anim@weapons@pistol@doubleaction_holster", (InputArgument)"holster", (InputArgument)3) || Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Player, (InputArgument)"anim@weapons@pistol@doubleaction_holster", (InputArgument)"holster", (InputArgument)3) && (double)Function.Call<float>(Hash.GET_ENTITY_ANIM_CURRENT_TIME, (InputArgument)(Entity)Player, (InputArgument)"anim@weapons@pistol@doubleaction_holster", (InputArgument)"holster") > 0.10000000149011612))
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
                        Player.Task.ClearAll();
                    }
                    if (!FocusMode.focusEffectsStoped)
                    {
                        if ((double)Game.TimeScale < 1.0)
                        {
                            Game.TimeScale += 0.1f;
                        }
                        else
                        {
                            double num15 = (double)Function.Call<float>(Hash.SET_PED_MOVE_RATE_OVERRIDE, (InputArgument)(Entity)Player, (InputArgument)1f);
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
                    Function.Call(Hash.FORCE_ALL_HEADING_VALUES_TO_ALIGN, (InputArgument)(Entity)Player);
                    Game.Player.DisableFiringThisFrame();
                    if (FocusMode.targetCam != (Camera)null && (Entity)FocusMode.focusTarget != (Entity)null && World.RenderingCamera == FocusMode.targetCam)
                    {
                        if (!FocusMode.targetCamSet)
                        {
                            FocusMode.targetCamSet = true;
                            FocusMode.rndTargetCamera = Common.rnd.Next(0, 0);
                            if (FocusMode.rndTargetCamera == 0)
                            {
                                FocusMode.targetCam.Position = new Vector3(Player.Position.X, Player.Position.Y, Player.Position.Z + 2.5f);
                                FocusMode.targetCam.Rotation = new Vector3(Player.Rotation.X, Player.Rotation.Y, Player.Rotation.Z);
                                FocusMode.targetCam.AttachTo((Entity)Player, new Vector3(0.7f, -0.95f, 0.7f));
                            }
                            else
                            {
                                FocusMode.targetCam.Position = new Vector3(Player.Position.X, Player.Position.Y, Player.Position.Z + 2.5f);
                                FocusMode.targetCam.Rotation = new Vector3(Player.Rotation.X, Player.Rotation.Y, Player.Rotation.Z + 180f);
                                FocusMode.targetCam.AttachTo((Entity)Player, new Vector3(0.3f, 2.95f, 0.5f));
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
                        if (FocusMode.focusTargetedPeds.Length != 0 && Player.Weapons.Current.Ammo >= FocusMode.focusTargetedPeds.Length && FocusMode.focusTargetingTimer > 0)
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
                                                Player.Task.LookAt((Entity)_target);
                                                Function.Call(Hash.TASK_AIM_GUN_AT_COORD, (InputArgument)(Entity)Player, (InputArgument)FocusMode.shootingCoords.X, (InputArgument)FocusMode.shootingCoords.Y, (InputArgument)FocusMode.shootingCoords.Z, (InputArgument)(-1), (InputArgument)false, (InputArgument)false);
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
                                    if (!Player.IsShooting)
                                    {
                                        int num16 = Function.Call<int>(Hash.GET_PED_BONE_INDEX, (InputArgument)(Entity)FocusMode.focusTarget, (InputArgument)31086);
                                        Vector3 vector3_5 = Function.Call<Vector3>(Hash.GET_WORLD_POSITION_OF_ENTITY_BONE, (InputArgument)(Entity)FocusMode.focusTarget, (InputArgument)num16);
                                        FocusMode.shootingCoords = vector3_5;
                                        Function.Call(Hash.SET_PED_SHOOTS_AT_COORD, (InputArgument)(Entity)Player, (InputArgument)vector3_5.X, (InputArgument)vector3_5.Y, (InputArgument)vector3_5.Z, (InputArgument)false);
                                    }
                                    if (Player.IsShooting)
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
                                        Player.Task.ClearAll();
                                        Player.Task.AimAt(FocusMode.shootingCoords, -1);
                                    }
                                    else
                                    {
                                        Player.Task.ClearAll();
                                        Player.Task.AimAt(FocusMode.shootingCoords, -1);
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
                            double num17 = (double)Function.Call<float>(Hash.SET_PED_MOVE_RATE_OVERRIDE, (InputArgument)(Entity)Player, (InputArgument)1f);
                            Game.Player.IgnoredByEveryone = false;
                            Game.Player.IsInvincible = false;
                            Player.Task.ClearAll();
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
                    if (!Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Player, (InputArgument)"melee@unarmed@streamed_taunts", (InputArgument)"damage_03", (InputArgument)3))
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
                        if (!Player.IsAiming)
                            Function.Call(Hash.TASK_AIM_GUN_AT_COORD, (InputArgument)(Entity)Player, (InputArgument)FocusMode.focusTarget.Position.X, (InputArgument)FocusMode.focusTarget.Position.Y, (InputArgument)FocusMode.focusTarget.Position.Z, (InputArgument)(-1), (InputArgument)false, (InputArgument)false);
                        if (FocusMode.focusTarget.IsInCover)
                            FocusMode.focusTarget.Task.GoTo(Player.FrontPosition, 5000);
                        num3 = --FocusMode.focusPedfacingTime;
                        if (FocusMode.focusPedfacingTime <= 0)
                            FocusMode.focusTargetFacing = true;
                    }
                }
            }
            if (WoundsSystem.woundsModuleActive && WoundsSystem.woundsTimer < Game.GameTime)
            {
                WoundsSystem.woundsTimer = Game.GameTime + 1000;
                if (!WoundsSystem.isWounded && Player.HasBeenDamagedByAnyWeapon())
                {
                    if (Common.rnd.Next(0, 5) == 0)
                    {
                        WoundsSystem.bleedTimer = Common.rnd.Next(30, 60);
                        Function.Call(Hash.CLEAR_PED_LAST_WEAPON_DAMAGE, (InputArgument)(Entity)Player);
                        WoundsSystem.isWounded = true;
                        Screen.ShowHelpText("~BLIIP_INFO_ICON~ You have been ~r~heavily wounded~w~.~n~ Use some painkillers to stop the pain!", 5000);
                    }
                    else
                        Function.Call(Hash.CLEAR_PED_LAST_WEAPON_DAMAGE, (InputArgument)(Entity)Player);
                }
                if (WoundsSystem.isWounded)
                {
                    if (WoundsSystem.bleedTimer <= 0 || (Entity)Player != (Entity)WoundsSystem.curWoundPlayer || Player.IsDead)
                    {
                        WoundsSystem.curWoundPlayer = Player;
                        HTools.Main.stopBleeding(Player);
                        Function.Call(Hash.CLEAR_PED_LAST_WEAPON_DAMAGE, (InputArgument)(Entity)Player);
                        WoundsSystem.isWounded = false;
                        Screen.ShowHelpText("~BLIIP_INFO_ICON~ The ~r~bleeding~w~ stopped", 5000);
                    }
                    else
                    {
                        num3 = --WoundsSystem.bleedTimer;
                        if ((Entity)WoundsSystem.curWoundPlayer == (Entity)Player)
                            HTools.Main.startBleeding(Player, true);
                    }
                }
            }
            if (WeaponSwing.swingGunAnim)
            {
                HTools.Main.DisableControlsFunc(true);
                if (!Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Player, (InputArgument)"anim@weapons@pistol@doubleaction_holster", (InputArgument)"holster", (InputArgument)3))
                    Player.Task.PlayAnimation("anim@weapons@pistol@doubleaction_holster", "holster", 4f, 1000, AnimationFlags.StayInEndFrame | AnimationFlags.UpperBodyOnly | AnimationFlags.Secondary);
                else if ((double)Function.Call<float>(Hash.GET_ENTITY_ANIM_CURRENT_TIME, (InputArgument)(Entity)Player, (InputArgument)"anim@weapons@pistol@doubleaction_holster", (InputArgument)"holster") > 0.40000000596046448)
                    WeaponSwing.swingGunAnim = false;
            }
            if ((WeaponHash)Player.Weapons.Current != WeaponHash.Unarmed)
            {
                Silencer.silencercheck();
                Scope.scopecheck();
                Flashlight.flashlightcheck();
                Grip.gripcheck();
                ExtendedMagazine.extendedmagazinecheck();
            }
            if (Common.AllWeaponsCount(Player) == 0)
                Common.RemoveAllAttachments();
            if (ExtendedMagazine.toggleExtendedMagazine)
            {
                HTools.Main.DisableControlsFunc(true);
                if (!Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Player, (InputArgument)"move_action@p_m_one@armed@2h_short@trans@a", (InputArgument)"idle2action", (InputArgument)3))
                {
                    if (!Player.IsInCover && Player.IsOnFoot && Game.Player.CanControlCharacter)
                    {
                        bool flag1 = false;
                        foreach ((WeaponHash weapon, WeaponComponentHash component) extendedmagazine in ExtendedMagazine.extendedmagazines)
                        {
                            if (Function.Call<bool>(Hash.DOES_WEAPON_TAKE_WEAPON_COMPONENT, (InputArgument)(Enum)Player.Weapons.Current.Hash, (InputArgument)(Enum)extendedmagazine.component))
                            {
                                flag1 = true;
                                break;
                            }
                        }
                        if (flag1)
                        {
                            if (ExtendedMagazine.HasPedBoughtExtendedMagazine(Player))
                            {
                                Player.Task.PlayAnimation("move_action@p_m_one@armed@2h_short@trans@a", "idle2action", 4f, -1, AnimationFlags.UpperBodyOnly | AnimationFlags.Secondary);
                                HTools.Main.soundFX(Player, "switchBtn.wav", Common.assetFolder, 13f);
                                bool flag2 = false;
                                foreach ((WeaponHash _, WeaponComponentHash component) in ExtendedMagazine.extendedmagazines)
                                {
                                    if (Function.Call<bool>(Hash.HAS_PED_GOT_WEAPON_COMPONENT, (InputArgument)(Entity)Player, (InputArgument)(Enum)Player.Weapons.Current.Hash, (InputArgument)(Enum)component))
                                    {
                                        flag2 = true;
                                        Function.Call(Hash.REMOVE_WEAPON_COMPONENT_FROM_PED, (InputArgument)(Entity)Player, (InputArgument)(Enum)Player.Weapons.Current.Hash, (InputArgument)(Enum)component);
                                        break;
                                    }
                                }
                                if (!flag2)
                                {
                                    foreach ((WeaponHash _, WeaponComponentHash component) in ExtendedMagazine.extendedmagazines)
                                    {
                                        if (Function.Call<bool>(Hash.DOES_WEAPON_TAKE_WEAPON_COMPONENT, (InputArgument)(Enum)Player.Weapons.Current.Hash, (InputArgument)(Enum)component))
                                        {
                                            Function.Call(Hash.GIVE_WEAPON_COMPONENT_TO_PED, (InputArgument)(Entity)Player, (InputArgument)(Enum)Player.Weapons.Current.Hash, (InputArgument)(Enum)component);
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
                else if ((double)Function.Call<float>(Hash.GET_ENTITY_ANIM_CURRENT_TIME, (InputArgument)(Entity)Player, (InputArgument)"move_action@p_m_one@armed@2h_short@trans@a", (InputArgument)"idle2action") >= 0.949999988079071)
                {
                    HTools.Main.soundFX(Player, "switchBtn.wav", Common.assetFolder, 13f);
                    ExtendedMagazine.toggleExtendedMagazine = false;
                }
            }
            if (Scope.toggleScope)
            {
                HTools.Main.DisableControlsFunc(true);
                if (!Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Player, (InputArgument)"move_action@p_m_one@armed@2h_short@trans@a", (InputArgument)"idle2action", (InputArgument)3))
                {
                    if (!Player.IsInCover && Player.IsOnFoot && Game.Player.CanControlCharacter)
                    {
                        bool flag3 = false;
                        foreach (int scope in Scope.scopes)
                        {
                            if (Function.Call<bool>(Hash.DOES_WEAPON_TAKE_WEAPON_COMPONENT, (InputArgument)(Enum)Player.Weapons.Current.Hash, (InputArgument)(Enum)(WeaponComponentHash)scope))
                            {
                                flag3 = true;
                                break;
                            }
                        }
                        if (flag3)
                        {
                            if (Scope.HasPedBoughtScope(Player))
                            {
                                Player.Task.PlayAnimation("move_action@p_m_one@armed@2h_short@trans@a", "idle2action", 4f, -1, AnimationFlags.UpperBodyOnly | AnimationFlags.Secondary);
                                HTools.Main.soundFX(Player, "switchBtn.wav", Common.assetFolder, 13f);
                                bool flag4 = false;
                                foreach (WeaponComponentHash scope in Scope.scopes)
                                {
                                    if (Function.Call<bool>(Hash.HAS_PED_GOT_WEAPON_COMPONENT, (InputArgument)(Entity)Player, (InputArgument)(Enum)Player.Weapons.Current.Hash, (InputArgument)(Enum)scope))
                                    {
                                        flag4 = true;
                                        Function.Call(Hash.REMOVE_WEAPON_COMPONENT_FROM_PED, (InputArgument)(Entity)Player, (InputArgument)(Enum)Player.Weapons.Current.Hash, (InputArgument)(Enum)scope);
                                        break;
                                    }
                                }
                                if (!flag4)
                                {
                                    foreach (WeaponComponentHash scope in Scope.scopes)
                                    {
                                        if (Function.Call<bool>(Hash.DOES_WEAPON_TAKE_WEAPON_COMPONENT, (InputArgument)(Enum)Player.Weapons.Current.Hash, (InputArgument)(Enum)scope))
                                        {
                                            Function.Call(Hash.GIVE_WEAPON_COMPONENT_TO_PED, (InputArgument)(Entity)Player, (InputArgument)(Enum)Player.Weapons.Current.Hash, (InputArgument)(Enum)scope);
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
                else if ((double)Function.Call<float>(Hash.GET_ENTITY_ANIM_CURRENT_TIME, (InputArgument)(Entity)Player, (InputArgument)"move_action@p_m_one@armed@2h_short@trans@a", (InputArgument)"idle2action") >= 0.949999988079071)
                {
                    HTools.Main.soundFX(Player, "switchBtn.wav", Common.assetFolder, 13f);
                    Scope.toggleScope = false;
                }
            }
            if (Flashlight.toggleFlashlight)
            {
                HTools.Main.DisableControlsFunc(true);
                if (!Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Player, (InputArgument)"move_action@p_m_one@armed@2h_short@trans@a", (InputArgument)"idle2action", (InputArgument)3))
                {
                    if (!Player.IsInCover && Player.IsOnFoot && Game.Player.CanControlCharacter)
                    {
                        bool flag5 = false;
                        foreach (int flashlight in Flashlight.flashlights)
                        {
                            if (Function.Call<bool>(Hash.DOES_WEAPON_TAKE_WEAPON_COMPONENT, (InputArgument)(Enum)Player.Weapons.Current.Hash, (InputArgument)(Enum)(WeaponComponentHash)flashlight))
                            {
                                flag5 = true;
                                break;
                            }
                        }
                        if (flag5)
                        {
                            if (Flashlight.HasPedBoughtFlashlight(Player))
                            {
                                Player.Task.PlayAnimation("move_action@p_m_one@armed@2h_short@trans@a", "idle2action", 4f, -1, AnimationFlags.UpperBodyOnly | AnimationFlags.Secondary);
                                HTools.Main.soundFX(Player, "switchBtn.wav", Common.assetFolder, 13f);
                                bool flag6 = false;
                                foreach (WeaponComponentHash flashlight in Flashlight.flashlights)
                                {
                                    if (Function.Call<bool>(Hash.HAS_PED_GOT_WEAPON_COMPONENT, (InputArgument)(Entity)Player, (InputArgument)(Enum)Player.Weapons.Current.Hash, (InputArgument)(Enum)flashlight))
                                    {
                                        flag6 = true;
                                        Function.Call(Hash.REMOVE_WEAPON_COMPONENT_FROM_PED, (InputArgument)(Entity)Player, (InputArgument)(Enum)Player.Weapons.Current.Hash, (InputArgument)(Enum)flashlight);
                                        break;
                                    }
                                }
                                if (!flag6)
                                {
                                    foreach (WeaponComponentHash flashlight in Flashlight.flashlights)
                                    {
                                        if (Function.Call<bool>(Hash.DOES_WEAPON_TAKE_WEAPON_COMPONENT, (InputArgument)(Enum)Player.Weapons.Current.Hash, (InputArgument)(Enum)flashlight))
                                        {
                                            Function.Call(Hash.GIVE_WEAPON_COMPONENT_TO_PED, (InputArgument)(Entity)Player, (InputArgument)(Enum)Player.Weapons.Current.Hash, (InputArgument)(Enum)flashlight);
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
                else if ((double)Function.Call<float>(Hash.GET_ENTITY_ANIM_CURRENT_TIME, (InputArgument)(Entity)Player, (InputArgument)"move_action@p_m_one@armed@2h_short@trans@a", (InputArgument)"idle2action") >= 0.949999988079071)
                {
                    HTools.Main.soundFX(Player, "switchBtn.wav", Common.assetFolder, 13f);
                    Flashlight.toggleFlashlight = false;
                }
            }
            if (Grip.toggleGrip)
            {
                HTools.Main.DisableControlsFunc(true);
                if (!Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Player, (InputArgument)"move_action@p_m_one@armed@2h_short@trans@a", (InputArgument)"idle2action", (InputArgument)3))
                {
                    if (!Player.IsInCover && Player.IsOnFoot && Game.Player.CanControlCharacter)
                    {
                        bool flag7 = false;
                        foreach (int grip in Grip.grips)
                        {
                            if (Function.Call<bool>(Hash.DOES_WEAPON_TAKE_WEAPON_COMPONENT, (InputArgument)(Enum)Player.Weapons.Current.Hash, (InputArgument)(Enum)(WeaponComponentHash)grip))
                            {
                                flag7 = true;
                                break;
                            }
                        }
                        if (flag7)
                        {
                            if (Grip.HasPedBoughtGrip(Player))
                            {
                                Player.Task.PlayAnimation("move_action@p_m_one@armed@2h_short@trans@a", "idle2action", 4f, -1, AnimationFlags.UpperBodyOnly | AnimationFlags.Secondary);
                                HTools.Main.soundFX(Player, "switchBtn.wav", Common.assetFolder, 13f);
                                bool flag8 = false;
                                foreach (WeaponComponentHash grip in Grip.grips)
                                {
                                    if (Function.Call<bool>(Hash.HAS_PED_GOT_WEAPON_COMPONENT, (InputArgument)(Entity)Player, (InputArgument)(Enum)Player.Weapons.Current.Hash, (InputArgument)(Enum)grip))
                                    {
                                        flag8 = true;
                                        Function.Call(Hash.REMOVE_WEAPON_COMPONENT_FROM_PED, (InputArgument)(Entity)Player, (InputArgument)(Enum)Player.Weapons.Current.Hash, (InputArgument)(Enum)grip);
                                        break;
                                    }
                                }
                                if (!flag8)
                                {
                                    foreach (WeaponComponentHash grip in Grip.grips)
                                    {
                                        if (Function.Call<bool>(Hash.DOES_WEAPON_TAKE_WEAPON_COMPONENT, (InputArgument)(Enum)Player.Weapons.Current.Hash, (InputArgument)(Enum)grip))
                                        {
                                            Function.Call(Hash.GIVE_WEAPON_COMPONENT_TO_PED, (InputArgument)(Entity)Player, (InputArgument)(Enum)Player.Weapons.Current.Hash, (InputArgument)(Enum)grip);
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
                else if ((double)Function.Call<float>(Hash.GET_ENTITY_ANIM_CURRENT_TIME, (InputArgument)(Entity)Player, (InputArgument)"move_action@p_m_one@armed@2h_short@trans@a", (InputArgument)"idle2action") >= 0.949999988079071)
                {
                    HTools.Main.soundFX(Player, "switchBtn.wav", Common.assetFolder, 13f);
                    Grip.toggleGrip = false;
                }
            }
            if (Silencer.toggleSilencer)
            {
                HTools.Main.DisableControlsFunc(true);
                if (!Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Player, (InputArgument)"move_action@p_m_one@armed@2h_short@trans@a", (InputArgument)"idle2action", (InputArgument)3))
                {
                    if (!Player.IsInCover && Player.IsOnFoot && Game.Player.CanControlCharacter)
                    {
                        bool flag9 = false;
                        foreach (int silencer in Silencer.silencers)
                        {
                            if (Function.Call<bool>(Hash.DOES_WEAPON_TAKE_WEAPON_COMPONENT, (InputArgument)(Enum)Player.Weapons.Current.Hash, (InputArgument)(Enum)(WeaponComponentHash)silencer))
                            {
                                flag9 = true;
                                break;
                            }
                        }
                        if (flag9)
                        {
                            if (Silencer.HasPedBoughtSilencer(Player))
                            {
                                Player.Task.PlayAnimation("move_action@p_m_one@armed@2h_short@trans@a", "idle2action", 4f, -1, AnimationFlags.UpperBodyOnly | AnimationFlags.Secondary);
                                HTools.Main.soundFX(Player, "switchBtn.wav", Common.assetFolder, 13f);
                                bool flag10 = false;
                                foreach (WeaponComponentHash silencer in Silencer.silencers)
                                {
                                    if (Function.Call<bool>(Hash.HAS_PED_GOT_WEAPON_COMPONENT, (InputArgument)(Entity)Player, (InputArgument)(Enum)Player.Weapons.Current.Hash, (InputArgument)(Enum)silencer))
                                    {
                                        flag10 = true;
                                        Function.Call(Hash.REMOVE_WEAPON_COMPONENT_FROM_PED, (InputArgument)(Entity)Player, (InputArgument)(Enum)Player.Weapons.Current.Hash, (InputArgument)(Enum)silencer);
                                        break;
                                    }
                                }
                                if (!flag10)
                                {
                                    foreach (WeaponComponentHash silencer in Silencer.silencers)
                                    {
                                        if (Function.Call<bool>(Hash.DOES_WEAPON_TAKE_WEAPON_COMPONENT, (InputArgument)(Enum)Player.Weapons.Current.Hash, (InputArgument)(Enum)silencer))
                                        {
                                            Function.Call(Hash.GIVE_WEAPON_COMPONENT_TO_PED, (InputArgument)(Entity)Player, (InputArgument)(Enum)Player.Weapons.Current.Hash, (InputArgument)(Enum)silencer);
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
                else if ((double)Function.Call<float>(Hash.GET_ENTITY_ANIM_CURRENT_TIME, (InputArgument)(Entity)Player, (InputArgument)"move_action@p_m_one@armed@2h_short@trans@a", (InputArgument)"idle2action") >= 0.949999988079071)
                {
                    HTools.Main.soundFX(Player, "switchBtn.wav", Common.assetFolder, 13f);
                    Silencer.toggleSilencer = false;
                }
            }
            if (Player.IsOnFoot && Player.IsAiming && !FocusMode.isFocused && Game.Player.CanControlCharacter && !Silencer.toggleSilencer)
            {
                if (!WeaponJamming.jammingModeIsActive && (ShoulderCameraSwitch.ShoulderCameraModuleActive || LaserSight.laserSightModeActive || WeaponSwing.swingGunModuleActive || Silencer.silencerModeActive || AimingStyle.aimingStyleModeActive))
                {
                    WeaponSwing.canSwingGun = ((IEnumerable<WeaponGroup>)WeaponHolster._pistolWeaponGroup).Contains<WeaponGroup>(Player.Weapons.Current.Group) || ((IEnumerable<WeaponGroup>)WeaponHolster._bigWeaponGroups).Contains<WeaponGroup>(Player.Weapons.Current.Group);
                    AimingStyle.canSwitchAimingStyle = (WeaponHash)Player.Weapons.Current == WeaponHash.Pistol;
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
                            Function.Call(Hash.SET_WEAPON_ANIMATION_OVERRIDE, (InputArgument)(Entity)Player, (InputArgument)HTools.Main.GetHashKey("Default"));
                            break;
                        case 1:
                            Function.Call(Hash.SET_PLAYER_FORCE_SKIP_AIM_INTRO, (InputArgument)Game.Player, (InputArgument)true);
                            Function.Call(Hash.SET_WEAPON_ANIMATION_OVERRIDE, (InputArgument)(Entity)Player, (InputArgument)HTools.Main.GetHashKey("Hillbilly"));
                            break;
                        case 2:
                            Function.Call(Hash.SET_PLAYER_FORCE_SKIP_AIM_INTRO, (InputArgument)Game.Player, (InputArgument)true);
                            Function.Call(Hash.SET_WEAPON_ANIMATION_OVERRIDE, (InputArgument)(Entity)Player, (InputArgument)HTools.Main.GetHashKey("Gang1H"));
                            break;
                    }
                }
                if (Function.Call<bool>(Hash.IS_DISABLED_CONTROL_JUST_PRESSED, (InputArgument)0, (InputArgument)Silencer.silencer_toggle_btn) && !Game.IsControlPressed(Control.Sprint))
                {
                    Silencer.toggleSilencer = true;
                    HTools.Main.soundFX(Player, "switchBtn.wav", Common.assetFolder, 13f);
                }
                if (WeaponSwing.swingGunModuleActive)
                {
                    Game.DisableControlThisFrame((Control)WeaponSwing.swing_gun_btn);
                    if (Function.Call<bool>(Hash.IS_DISABLED_CONTROL_JUST_PRESSED, (InputArgument)0, (InputArgument)(Enum)(Control)WeaponSwing.swing_gun_btn) && (((IEnumerable<WeaponGroup>)WeaponHolster._pistolWeaponGroup).Contains<WeaponGroup>(Player.Weapons.Current.Group) || ((IEnumerable<WeaponGroup>)WeaponHolster._bigWeaponGroups).Contains<WeaponGroup>(Player.Weapons.Current.Group)) && Game.Player.CanControlCharacter && !Common.inMainMenu && !WeaponJamming.isCleaningJammedGun && !WeaponJamming.isFixingJammedGun && !WeaponJamming.isCheckingWeaponCondition && Player.IsOnFoot)
                    {
                        WeaponSwing.swingGunBtnCounter = 0;
                        WeaponSwing.swingGunAnim = true;
                    }
                }
                if (ShoulderCameraSwitch.ShoulderCameraModuleActive)
                {
                    if (ShoulderCameraSwitch.ShoulderCameraActive)
                    {
                        if (!Player.IsInCover)
                        {
                            if (ShoulderCameraSwitch.activeCam == (Camera)null)
                            {
                                ShoulderCameraSwitch.targetOffset = -0.7f;
                                ShoulderCameraSwitch.TransitionCamera(Player);
                            }
                            else if (Game.IsControlPressed(Control.Sprint))
                            {
                                ShoulderCameraSwitch.targetOffset = -0.7f;
                                ShoulderCameraSwitch.TransitionCamera(Player);
                                if (Game.IsControlPressed(Control.Cover) && !Player.IsAnimPlay("weapons@misc@digi_scanner", "walk_additive_left"))
                                    Player.Task.PlayAnimation("weapons@misc@digi_scanner", "walk_additive_left", 8f, -8f, -1, AnimationFlags.StayInEndFrame | AnimationFlags.Secondary | AnimationFlags.Additive, 0.0f);
                                else if (Game.IsControlPressed(Control.Talk) && !Player.IsAnimPlay("weapons@misc@digi_scanner", "walk_additive_right"))
                                    Player.Task.PlayAnimation("weapons@misc@digi_scanner", "walk_additive_right", 8f, -8f, -1, AnimationFlags.StayInEndFrame | AnimationFlags.Secondary | AnimationFlags.Additive, 0.0f);
                                else if (Game.IsControlJustReleased(Control.Cover) || Game.IsControlJustReleased(Control.Talk))
                                    Player.Task.ClearSecondary();
                            }
                            else
                            {
                                ShoulderCameraSwitch.targetOffset = -0.7f;
                                ShoulderCameraSwitch.TransitionCamera(Player);
                            }
                            Function.Call(Hash.DISABLE_GAMEPLAY_CAM_ALTITUDE_FOV_SCALING_THIS_UPDATE);
                            Function.Call(Hash.SHOW_HUD_COMPONENT_THIS_FRAME, (InputArgument)14);
                        }
                        else
                        {
                            ShoulderCameraSwitch.ShoulderCameraActive = false;
                            ShoulderCameraSwitch.targetOffset = 0.0f;
                            ShoulderCameraSwitch.TransitionCamera(Player);
                        }
                    }
                    else if (!ShoulderCameraSwitch.ShoulderCameraActive)
                    {
                        if (PeekingMod.Main.PeekingPosition == 1 || PeekingMod.Main.PeekingPosition == 2)
                            return;
                        ShoulderCameraSwitch.targetOffset = 0.0f;
                        ShoulderCameraSwitch.TransitionCamera(Player);
                    }
                    Game.DisableControlThisFrame((Control)ShoulderCameraSwitch.switch_shoulder_camera_btn);
                    Function.Call(Hash.DISABLE_CONTROL_ACTION, (InputArgument)2, (InputArgument)LaserSight.laser_sight_toggle_btn, (InputArgument)true);
                }
                if (LaserSight.laserSightModeActive)
                {
                    if (LaserSight.laserSightMode && !FocusMode.targetsPicked)
                    {
                        if ((WeaponHash)Player.Weapons.Current != LaserSight.laseredWeapon)
                            LaserSight.laserSightMode = false;
                        if (LaserSight.laserSightActivationTimer <= 0)
                        {
                            Prop currentWeaponObject = Player.Weapons.CurrentWeaponObject;
                            model = currentWeaponObject.Model;
                            Vector3 frontTopRight = model.Dimensions.frontTopRight;
                            float num18 = -0.03f;
                            if (((IEnumerable<WeaponGroup>)WeaponHolster._bigWeaponGroups).Contains<WeaponGroup>(Player.Weapons.Current.Group))
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
                            if (Function.Call<bool>(Hash.HAS_PED_GOT_WEAPON_COMPONENT, (InputArgument)(Entity)Player, (InputArgument)(Enum)Player.Weapons.Current.Hash, (InputArgument)(Enum)(WeaponComponentHash)flashlight))
                            {
                                flag = true;
                                break;
                            }
                        }
                        if (flag)
                        {
                            LaserSight.laseredWeapon = (WeaponHash)Player.Weapons.Current;
                            HTools.Main.soundFX(Player, "switchBtn.wav", Common.assetFolder, 13f);
                            Player.Task.PlayAnimation("weapons@first_person@aim_idle@generic@melee@unarmed@", "aim_med_loop", 4f, -1, AnimationFlags.UpperBodyOnly | AnimationFlags.Secondary);
                            LaserSight.laserSightMode = !LaserSight.laserSightMode;
                            LaserSight.laserSightActivationTimer = 20;
                        }
                        else
                            Screen.ShowHelpText("~BLIP_INFO_ICON~ You need to set ~y~flashlight~w~ component to use a ~r~laser-sight~w~ with this weapon", 6000);
                    }
                }
                if (ShoulderCameraSwitch.ShoulderCameraModuleActive && Function.Call<bool>(Hash.IS_DISABLED_CONTROL_JUST_PRESSED, (InputArgument)0, (InputArgument)ShoulderCameraSwitch.switch_shoulder_camera_btn) && !Player.IsInCover && GameplayCamera.GetCamViewModeForContext(CamViewModeContext.OnFoot) != CamViewMode.FirstPerson)
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
                            ShoulderCameraSwitch.TransitionCamera(Player);
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
                    ShoulderCameraSwitch.TransitionCamera(Player);
                    ShoulderCameraSwitch.ShoulderCameraActive = false;
                }
            }
            if (WeaponJamming.jammingModeIsActive)
            {
                if (WeaponJamming.weaponIsJammed && Player.Weapons.Current != WeaponHash.Unarmed)
                {
                    Game.DisableControlThisFrame(Control.Attack);
                    Game.DisableControlThisFrame(Control.Attack2);
                    if (Function.Call<bool>(Hash.IS_DISABLED_CONTROL_JUST_PRESSED, (InputArgument)0, (InputArgument)24))
                    {
                        WeaponJamming.jammCounter = Common.rnd.Next(1, 5);
                        HTools.Main.soundFX(Player, "dryfire.wav", Common.assetFolder, 15f);
                        if (!Function.Call<bool>(Hash.IS_HELP_MESSAGE_BEING_DISPLAYED))
                            Screen.ShowHelpText("~BLIP_INFO_ICON~ Weapon is ~r~jammed", 1000);
                    }
                }
                if ((Entity)WeaponJamming.curWeaponJammedPlayer != (Entity)Player)
                {
                    WeaponJamming.createWeaponConditionStructure(Player, Common.doc);
                    if (WeaponJamming.shootingWeapon != (WeaponHash)0 && (Entity)WeaponJamming.curWeaponJammedPlayer != (Entity)null && WeaponJamming.curWeaponJammedPlayer.Model != (Model)0)
                        WeaponJamming.saveShotsForCurWeapon(WeaponJamming.curWeaponJammedPlayer, Common.doc, WeaponJamming.shotsFired, WeaponJamming.shootingWeapon);
                    WeaponJamming.shotsFired = 0;
                    WeaponJamming.shootingWeapon = Player.Weapons.Current.Hash;
                    WeaponJamming.curWeaponJammedPlayer = Player;
                    WeaponJamming.isFixingJammedGun = false;
                    WeaponJamming.isCheckingWeaponCondition = false;
                    Array.Clear((Array)WeaponJamming.jammedWeapons, 0, WeaponJamming.jammedWeapons.Length);
                    WeaponJamming.clearWeaponCase(Player, HTools.Main.GetHashKey(WeaponJamming.briefcase_model));
                    WeaponJamming.clearWeaponCase(Player, HTools.Main.GetHashKey(WeaponJamming.briefcase_opened_model));
                    if (Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Player, (InputArgument)"anim@heists@money_grab@briefcase", (InputArgument)"enter", (InputArgument)3))
                        Player.Task.ClearAll();
                    WeaponJamming.cleaningRequired = false;
                }
                if (WeaponJamming.isCleaningJammedGun)
                {
                    if (Player.IsRagdoll)
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
                    if (WeaponJamming.weaponCleaningInProcess && Game.Player.CanControlCharacter && !Player.IsAttached())
                    {
                        if (!WeaponJamming.weaponIsReady)
                        {
                            if (WeaponJamming.playCleaningWeaponAnimTimer > 0)
                                num3 = --WeaponJamming.playCleaningWeaponAnimTimer;
                            if ((WeaponHash)Player.Weapons.Current == WeaponJamming.cleaningWeapon && WeaponJamming.playCleaningWeaponAnimTimer <= 0)
                            {
                                if (Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Player, (InputArgument)animDict, (InputArgument)animName, (InputArgument)3))
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
                                    if ((double)Function.Call<float>(Hash.GET_ENTITY_ANIM_CURRENT_TIME, (InputArgument)(Entity)Player, (InputArgument)animDict, (InputArgument)animName) >= (double)num21)
                                    {
                                        num3 = --WeaponJamming.jammCounter;
                                        Function.Call(Hash.SET_ENTITY_ANIM_CURRENT_TIME, (InputArgument)(Entity)Player, (InputArgument)animDict, (InputArgument)animName, (InputArgument)num20);
                                        if (!cleaningWeaponIsBig && (double)Function.Call<float>(Hash.GET_ENTITY_ANIM_CURRENT_TIME, (InputArgument)(Entity)Player, (InputArgument)animDict, (InputArgument)animName) >= 0.5 && (double)Function.Call<float>(Hash.GET_ENTITY_ANIM_CURRENT_TIME, (InputArgument)(Entity)Player, (InputArgument)animDict, (InputArgument)animName) < 0.699999988079071)
                                            HTools.Main.soundFX(Player, "tweak.wav", Common.assetFolder);
                                    }
                                }
                                else if (WeaponJamming.jammCounter > 0)
                                {
                                    Player.Task.PlayAnimation(animDict, animName, (float)blendInSpeed, duration, AnimationFlags.UpperBodyOnly | AnimationFlags.Secondary);
                                    if (!cleaningWeaponIsBig)
                                        HTools.Main.soundFX(Player, "tweak.wav", Common.assetFolder, 15f);
                                    else
                                        HTools.Main.soundFX(Player, "draw2.wav", Common.assetFolder, 15f);
                                }
                            }
                        }
                        else
                        {
                            if ((WeaponHash)Player.Weapons.Current != WeaponJamming.cleaningWeapon)
                                Player.Weapons.Select(WeaponJamming.cleaningWeapon);
                            if (!Player.IsReloading && !Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Player, (InputArgument)animDict, (InputArgument)animName, (InputArgument)3))
                            {
                                WeaponJamming.clearShotsForCurWeapon(Player, Common.doc, WeaponJamming.cleaningWeapon);
                                int supplies = Common.getSupplies(Player, "weapon_tools");
                                Common.saveSupplies(Player, "weapon_tools", supplies - 1);
                                WeaponJamming.cleaningRequired = false;
                                Player.Weapons.Select(WeaponHash.Unarmed);
                                WeaponJamming.weaponCleaningInProcess = false;
                                Player.Task.PlayAnimation("anim@scripted@heist@ig1_table_grab@cash@male@", "grab_idle", 4f, -1, AnimationFlags.Loop | AnimationFlags.UpperBodyOnly | AnimationFlags.Secondary);
                                num3 = supplies - 1;
                                Screen.ShowHelpText("~BLIP_INFO_ICON~ Your weapon is in ~g~good~w~ condition now! You have ~o~" + num3.ToString() + "~w~ cleaning tools left");
                            }
                        }
                    }
                    else
                    {
                        AimingStyle.canSwitchAimingStyle = (WeaponHash)Player.Weapons.Current == WeaponHash.Pistol;
                        WeaponSwing.canSwingGun = ((IEnumerable<WeaponGroup>)WeaponHolster._pistolWeaponGroup).Contains<WeaponGroup>(Player.Weapons.Current.Group) || ((IEnumerable<WeaponGroup>)WeaponHolster._bigWeaponGroups).Contains<WeaponGroup>(Player.Weapons.Current.Group);
                        LaserSight.canUseLaserSight = true;
                        Common.Draw(0, canClean: true, isCleaningWeapon: WeaponJamming.isCleaningJammedGun, cleaningRequiredParam: WeaponJamming.cleaningRequired, action_page: Common.cur_action_page, cameraModuleParam: ShoulderCameraSwitch.ShoulderCameraModuleActive, swingWeaponModuleParam: WeaponSwing.swingGunModuleActive, laserSightModuleParam: LaserSight.laserSightModeActive, canSwingWeaponParam: WeaponSwing.canSwingGun, canUseLaserSightParam: LaserSight.canUseLaserSight, weaponJamningModuleParam: WeaponJamming.jammingModeIsActive, silencerModeActiveParam: Silencer.silencerModeActive, aimingStyleModeActiveParam: AimingStyle.aimingStyleModeActive, canSwitchAimingStyleParam: AimingStyle.canSwitchAimingStyle);
                        if (Function.Call<bool>(Hash.IS_DISABLED_CONTROL_JUST_PRESSED, (InputArgument)0, (InputArgument)51) && WeaponJamming.cleaningRequired && (Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Player, (InputArgument)"anim@scripted@heist@ig1_table_grab@cash@male@", (InputArgument)"grab_idle", (InputArgument)3) || Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Player, (InputArgument)"anim@heists@money_grab@briefcase", (InputArgument)"enter", (InputArgument)3)) && !Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Player, (InputArgument)animDict, (InputArgument)animName, (InputArgument)3))
                        {
                            Player.Task.PlayAnimation("amb@medic@standing@kneel@base", "base", 4f, -1, AnimationFlags.StayInEndFrame);
                            Player.Task.PlayAnimation("mp_arrest_paired", "cop_p1_rf_right_0", 4f, -1, AnimationFlags.UpperBodyOnly | AnimationFlags.Secondary);
                            Screen.ShowHelpText("~BLIP_INFO_ICON~ cleaning " + WeaponJamming.cleaningWeapon.ToString() + " started...", 3000);
                            Player.Weapons.Select(WeaponJamming.cleaningWeapon);
                            WeaponJamming.playCleaningWeaponAnimTimer = 100;
                            WeaponJamming.jammCounter = 1;
                            if (WeaponJamming.cleaningWeaponIsBig)
                                WeaponJamming.jammCounter = 3;
                            WeaponJamming.weaponCleaningInProcess = true;
                            WeaponJamming.weaponIsReady = false;
                        }
                        if (Function.Call<bool>(Hash.IS_DISABLED_CONTROL_JUST_PRESSED, (InputArgument)0, (InputArgument)52))
                        {
                            if (Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Player, (InputArgument)"amb@medic@standing@kneel@base", (InputArgument)"base", (InputArgument)3) || Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Player, (InputArgument)"anim@heists@money_grab@briefcase", (InputArgument)"enter", (InputArgument)3) || Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Player, (InputArgument)"anim@scripted@heist@ig1_table_grab@cash@male@", (InputArgument)"grab_idle", (InputArgument)3))
                            {
                                Player.Weapons.Select(WeaponHash.Unarmed);
                                Player.Task.ClearAll();
                                Player.Task.PlayAnimation("anim@heists@money_grab@briefcase", "exit", 4f, 1800, AnimationFlags.None);
                                WeaponJamming.weaponCaseSwitched = false;
                            }
                            else
                            {
                                WeaponJamming.clearWeaponCase(Player, HTools.Main.GetHashKey(WeaponJamming.briefcase_model));
                                WeaponJamming.clearWeaponCase(Player, HTools.Main.GetHashKey(WeaponJamming.briefcase_opened_model));
                                WeaponJamming.isCleaningJammedGun = false;
                                WeaponJamming.weaponCaseSwitched = false;
                            }
                        }
                        if (Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Player, (InputArgument)"anim@heists@money_grab@briefcase", (InputArgument)"exit", (InputArgument)3))
                        {
                            if ((double)Function.Call<float>(Hash.GET_ENTITY_ANIM_CURRENT_TIME, (InputArgument)(Entity)Player, (InputArgument)"anim@heists@money_grab@briefcase", (InputArgument)"exit") > 0.65)
                            {
                                WeaponJamming.clearWeaponCase(Player, HTools.Main.GetHashKey(WeaponJamming.briefcase_model));
                                WeaponJamming.clearWeaponCase(Player, HTools.Main.GetHashKey(WeaponJamming.briefcase_opened_model));
                                WeaponJamming.isCleaningJammedGun = false;
                            }
                            else if (!WeaponJamming.weaponCaseSwitched)
                            {
                                WeaponJamming.weaponCaseSwitched = true;
                                WeaponJamming.clearWeaponCase(Player, HTools.Main.GetHashKey(WeaponJamming.briefcase_opened_model));
                                WeaponJamming.getWeaponCaseFunc(Player, HTools.Main.GetHashKey(WeaponJamming.briefcase_model), true, new Vector3(Player.FrontPosition.X, Player.FrontPosition.Y, Player.FrontPosition.Z), true);
                                WeaponJamming.clearWeaponCleaningToolsFunc(HTools.Main.GetHashKey(WeaponJamming.gunspray_can), Player.Position);
                                WeaponJamming.clearWeaponCleaningToolsFunc(HTools.Main.GetHashKey(WeaponJamming.gun_case_small), Player.Position);
                            }
                        }
                        if (!Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Player, (InputArgument)"anim@heists@money_grab@briefcase", (InputArgument)"exit", (InputArgument)3) && Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Player, (InputArgument)"anim@heists@money_grab@briefcase", (InputArgument)"enter", (InputArgument)3) && (double)Function.Call<float>(Hash.GET_ENTITY_ANIM_CURRENT_TIME, (InputArgument)(Entity)Player, (InputArgument)"anim@heists@money_grab@briefcase", (InputArgument)"enter") >= 0.64999997615814209 && !WeaponJamming.weaponCaseSwitched)
                        {
                            WeaponJamming.clearWeaponCase(Player, HTools.Main.GetHashKey(WeaponJamming.briefcase_model));
                            Prop weaponCaseFunc = WeaponJamming.getWeaponCaseFunc(Player, HTools.Main.GetHashKey(WeaponJamming.briefcase_opened_model), false, new Vector3(Player.Position.X - 0.5f, Player.Position.Y + 0.3f, (float)((double)Player.Position.Z - (double)Player.HeightAboveGround + 0.10000000149011612)), true);
                            if ((Entity)weaponCaseFunc != (Entity)null)
                            {
                                weaponCaseFunc.IsCollisionEnabled = false;
                                weaponCaseFunc.Rotation = new Vector3(Player.Rotation.X, Player.Rotation.Y, Player.Rotation.Z);
                                weaponCaseFunc.Position = new Vector3(Player.FrontPosition.X, Player.FrontPosition.Y, (float)((double)Player.Position.Z - (double)Player.HeightAboveGround + 0.10000000149011612));
                                WeaponJamming.getWeaponCleaningToolsFunc(Player, HTools.Main.GetHashKey(WeaponJamming.gunspray_can), new Vector3(Player.RightPosition.X, Player.RightPosition.Y, Player.RightPosition.Z + 0.1f));
                                WeaponJamming.getWeaponCleaningToolsFunc(Player, HTools.Main.GetHashKey(WeaponJamming.gun_case_small), new Vector3(Player.RightPosition.X - 0.2f, Player.RightPosition.Y, Player.RightPosition.Z + 0.3f));
                            }
                            Player.Task.PlayAnimation("anim@scripted@heist@ig1_table_grab@cash@male@", "grab_idle", 4f, -1, AnimationFlags.Loop | AnimationFlags.UpperBodyOnly | AnimationFlags.Secondary);
                            WeaponJamming.weaponCaseSwitched = true;
                        }
                    }
                }
                if (((IEnumerable<WeaponGroup>)WeaponHolster._pistolWeaponGroup).Contains<WeaponGroup>(Player.Weapons.Current.Group) || ((IEnumerable<WeaponGroup>)WeaponHolster._bigWeaponGroups).Contains<WeaponGroup>(Player.Weapons.Current.Group) && !WeaponJamming.isCleaningJammedGun)
                {
                    WeaponJamming.weaponIsJammed = ((IEnumerable<WeaponHash>)WeaponJamming.jammedWeapons).Contains<WeaponHash>(Player.Weapons.Current.Hash);
                    bool flag = ((IEnumerable<WeaponGroup>)WeaponHolster._bigWeaponGroups).Contains<WeaponGroup>(Player.Weapons.Current.Group) && (WeaponHash)Player.Weapons.Current != WeaponHash.MicroSMG && (WeaponHash)Player.Weapons.Current != WeaponHash.MiniSMG && (WeaponHash)Player.Weapons.Current != WeaponHash.SMGMk2;
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
                    if (Player.IsAiming && !Player.IsSittingInVehicle() && !FocusMode.targetsPicked && !FocusMode.isFocused && Game.Player.CanControlCharacter && !Player.IsAttached())
                    {
                        Game.DisableControlThisFrame((Control)WeaponJamming.clean_weapon_btn);
                        WeaponSwing.canSwingGun = ((IEnumerable<WeaponGroup>)WeaponHolster._pistolWeaponGroup).Contains<WeaponGroup>(Player.Weapons.Current.Group) || ((IEnumerable<WeaponGroup>)WeaponHolster._bigWeaponGroups).Contains<WeaponGroup>(Player.Weapons.Current.Group);
                        AimingStyle.canSwitchAimingStyle = (WeaponHash)Player.Weapons.Current == WeaponHash.Pistol;
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
                            if (Game.Player.CanControlCharacter && Player.IsOnFoot && !Player.IsInCombat && Game.Player.WantedLevel <= 0)
                            {
                                WeaponJamming.cleaningWeapon = Player.Weapons.Current.Hash;
                                WeaponJamming.cleaningWeaponIsBig = flag;
                                Player.Weapons.Select(WeaponHash.Unarmed);
                                if ((Entity)WeaponJamming.getWeaponCaseFunc(Player, HTools.Main.GetHashKey(WeaponJamming.briefcase_model), true, new Vector3(Player.FrontPosition.X, Player.FrontPosition.Y, Player.FrontPosition.Z), true) != (Entity)null && !Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Player, (InputArgument)"anim@heists@money_grab@briefcase", (InputArgument)"enter", (InputArgument)3))
                                {
                                    WeaponJamming.weaponCaseSwitched = false;
                                    Player.Task.PlayAnimation("anim@heists@money_grab@briefcase", "enter", 4f, -1, AnimationFlags.StayInEndFrame);
                                    WeaponJamming.isCleaningJammedGun = true;
                                }
                            }
                            else
                                Screen.ShowHelpText("~BLIP_INFO_ICON~ You can't clean your weapon now!", 3000);
                        }
                        if (Function.Call<bool>(Hash.IS_DISABLED_CONTROL_JUST_PRESSED, (InputArgument)0, (InputArgument)WeaponJamming.fix_weapon_btn) && !Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Player, (InputArgument)str1, (InputArgument)animName1, (InputArgument)3) && !Function.Call<bool>(Hash.IS_PED_RUNNING_MOBILE_PHONE_TASK, (InputArgument)(Entity)Player) && !Function.Call<bool>(Hash.IS_PED_RUNNING_RAGDOLL_TASK, (InputArgument)(Entity)Player) && !Game.IsControlPressed(Control.Sprint))
                        {
                            if (WeaponJamming.weaponIsJammed)
                            {
                                if (WeaponJamming.jammCounter >= 0)
                                {
                                    if (Player.IsInCover && Player.IsAimingFromCover)
                                    {
                                        if (flag)
                                        {
                                            if (!Player.IsInCoverFacingLeft)
                                                Player.Task.ClearAll();
                                        }
                                        else if (Player.IsInCoverFacingLeft)
                                            Player.Task.ClearAll();
                                    }
                                    WeaponJamming.weaponIsReady = false;
                                    Player.Task.PlayAnimation(str1, animName1, (float)blendInSpeed, duration, AnimationFlags.UpperBodyOnly | AnimationFlags.Secondary);
                                    if (!flag)
                                        HTools.Main.soundFX(Player, "tweak.wav", Common.assetFolder, 15f);
                                    WeaponJamming.isFixingJammedGun = true;
                                    WeaponJamming.weaponJammingAnimTimeOut = 500;
                                }
                            }
                            else if (!Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Player, (InputArgument)str1, (InputArgument)animName1, (InputArgument)3))
                            {
                                if (Player.IsInCover && Player.IsAimingFromCover)
                                {
                                    if (flag)
                                    {
                                        if (!Player.IsInCoverFacingLeft)
                                            Player.Task.ClearAll();
                                    }
                                    else if (Player.IsInCoverFacingLeft)
                                        Player.Task.ClearAll();
                                }
                                WeaponJamming.weaponIsReady = false;
                                Player.Task.PlayAnimation(str1, animName1, (float)blendInSpeed, duration, AnimationFlags.UpperBodyOnly | AnimationFlags.Secondary);
                                if (!flag)
                                    HTools.Main.soundFX(Player, "tweak.wav", Common.assetFolder, 15f);
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
                                HTools.Main.soundFX(Player, "dryfire.wav", Common.assetFolder, 15f);
                                if (!Function.Call<bool>(Hash.IS_HELP_MESSAGE_BEING_DISPLAYED))
                                    Screen.ShowHelpText("~BLIP_INFO_ICON~ Weapon is ~r~jammed", 1000);
                            }
                        }
                    }
                    if (WeaponJamming.weaponRemoveInProcess)
                    {
                        HTools.Main.DisableControlsFunc(true);
                        if (!Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Player, (InputArgument)animDict, (InputArgument)animName2, (InputArgument)3))
                        {
                            Player.Task.ClearAll();
                            Player.Task.PlayAnimation(animDict, animName2, 4f, -1, AnimationFlags.UpperBodyOnly | AnimationFlags.Secondary);
                        }
                        if ((double)Function.Call<float>(Hash.GET_ENTITY_ANIM_CURRENT_TIME, (InputArgument)(Entity)Player, (InputArgument)animDict, (InputArgument)animName2) > 0.800000011920929)
                        {
                            WeaponJamming.weaponRemoveInProcess = false;
                            WeaponJamming.clearShotsForCurWeapon(Player, Common.doc, (WeaponHash)Player.Weapons.Current);
                            Function.Call(Hash.GET_WEAPON_OBJECT_FROM_PED, (InputArgument)(Entity)Player, (InputArgument)false);
                            Script.Wait(200);
                            Player.Weapons.Remove(Player.Weapons.Current);
                            HTools.Main.soundFX(Player, "draw2.wav", Common.assetFolder);
                        }
                    }
                    if (WeaponJamming.isCheckingWeaponCondition)
                    {
                        if (Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Player, (InputArgument)str1, (InputArgument)animName1, (InputArgument)3))
                        {
                            if (flag && (double)Function.Call<float>(Hash.GET_ENTITY_ANIM_CURRENT_TIME, (InputArgument)(Entity)Player, (InputArgument)str1, (InputArgument)animName1) >= 0.20000000298023224 && !WeaponJamming.weaponIsReady)
                            {
                                if (Player.Weapons.Current.AmmoInClip > 1)
                                    num3 = --Player.Weapons.Current.AmmoInClip;
                                WeaponJamming.weaponIsReady = true;
                            }
                            if ((double)Function.Call<float>(Hash.GET_ENTITY_ANIM_CURRENT_TIME, (InputArgument)(Entity)Player, (InputArgument)str1, (InputArgument)animName1) >= (double)num22)
                            {
                                Player.Task.ClearAnimation(str1, animName1);
                                WeaponJamming.isCheckingWeaponCondition = false;
                                if (WeaponJamming.shootingWeapon == (WeaponHash)0)
                                    WeaponJamming.shootingWeapon = (WeaponHash)Player.Weapons.Current;
                                if (WeaponJamming.shotsFired > 0)
                                    WeaponJamming.saveShotsForCurWeapon(Player, Common.doc, WeaponJamming.shotsFired, WeaponJamming.shootingWeapon);
                                WeaponJamming.shootingWeapon = (WeaponHash)Player.Weapons.Current;
                                WeaponJamming.shotsFired = 0;
                                int weaponTotalShots = WeaponJamming.getCurWeaponTotalShots(Player, Common.doc, WeaponJamming.shootingWeapon);
                                WeaponJamming.hasCleaningTools = Common.getSupplies(Player, "weapon_tools") > 0;
                                WeaponJamming.max_rnd_chance = WeaponJamming.maxShotsBeforeBadCondition > weaponTotalShots ? WeaponJamming.maxShotsBeforeBadCondition - weaponTotalShots : 0;
                                if (WeaponJamming.hasCleaningTools && !Player.IsInCombat && !Player.IsInCover)
                                    WeaponJamming.cleaningRequired = true;
                                string str2 = WeaponJamming.cleaningRequired ? "~n~You have ~o~" + Common.getSupplies(Player, "weapon_tools").ToString() + "~w~ weapon cleaning toolkits. You can clean your weapon now." : "~n~You need to purchase a weapon cleaning toolkit from a ~p~weapon dealer~w~ or ~p~Ammunation~w~ for regular weapon maintenance. Dial the phone contact named ~p~Richard~w~ to call a blackmarket~BLIP_INFO_ICON~ ~p~dealer~w~";
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
                            Player.Task.ClearAll();
                        }
                        HTools.Main.DisableControlsFunc(true);
                    }
                    if (WeaponJamming.weaponIsJammed && WeaponJamming.isFixingJammedGun)
                    {
                        if (Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Player, (InputArgument)str1, (InputArgument)animName1, (InputArgument)3))
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
                            if ((double)Function.Call<float>(Hash.GET_ENTITY_ANIM_CURRENT_TIME, (InputArgument)(Entity)Player, (InputArgument)str1, (InputArgument)animName1) >= (double)num24)
                            {
                                num3 = --WeaponJamming.jammCounter;
                                Function.Call(Hash.SET_ENTITY_ANIM_CURRENT_TIME, (InputArgument)(Entity)Player, (InputArgument)str1, (InputArgument)animName1, (InputArgument)num23);
                                if (Player.Weapons.Current.AmmoInClip > 1)
                                    num3 = --Player.Weapons.Current.AmmoInClip;
                                if (!flag && (double)Function.Call<float>(Hash.GET_ENTITY_ANIM_CURRENT_TIME, (InputArgument)(Entity)Player, (InputArgument)str1, (InputArgument)animName1) >= 0.5 && (double)Function.Call<float>(Hash.GET_ENTITY_ANIM_CURRENT_TIME, (InputArgument)(Entity)Player, (InputArgument)str1, (InputArgument)animName1) < 0.699999988079071)
                                    HTools.Main.soundFX(Player, "tweak.wav", Common.assetFolder);
                            }
                            if ((double)Function.Call<float>(Hash.GET_ENTITY_ANIM_CURRENT_TIME, (InputArgument)(Entity)Player, (InputArgument)str1, (InputArgument)animName1) >= (double)num22)
                            {
                                Player.Task.ClearAnimation(str1, animName1);
                                WeaponJamming.isFixingJammedGun = false;
                                if (WeaponJamming.jammCounter <= 0 && ((IEnumerable<WeaponHash>)WeaponJamming.jammedWeapons).Contains<WeaponHash>(Player.Weapons.Current.Hash))
                                    WeaponJamming.jammedWeapons = ((IEnumerable<WeaponHash>)WeaponJamming.jammedWeapons).Where<WeaponHash>((Func<WeaponHash, bool>)(val => val != Player.Weapons.Current.Hash)).ToArray<WeaponHash>();
                            }
                        }
                        else if (WeaponJamming.weaponJammingAnimTimeOut > 0)
                        {
                            num3 = --WeaponJamming.weaponJammingAnimTimeOut;
                        }
                        else
                        {
                            WeaponJamming.isCheckingWeaponCondition = false;
                            Player.Task.ClearAll();
                        }
                        HTools.Main.DisableControlsFunc(true);
                    }
                    if (!WeaponJamming.weaponIsJammed && Player.IsShooting)
                    {
                        if (WeaponJamming.shootingWeapon != Player.Weapons.Current.Hash)
                        {
                            if (WeaponJamming.shootingWeapon != (WeaponHash)0 && Player.Model != (Model)0)
                                WeaponJamming.saveShotsForCurWeapon(Player, Common.doc, WeaponJamming.shotsFired, WeaponJamming.shootingWeapon);
                            WeaponJamming.shootingWeapon = Player.Weapons.Current.Hash;
                            WeaponJamming.shotsFired = 0;
                            int weaponTotalShots = WeaponJamming.getCurWeaponTotalShots(Player, Common.doc, WeaponJamming.shootingWeapon);
                            WeaponJamming.max_rnd_chance = WeaponJamming.maxShotsBeforeBadCondition > weaponTotalShots ? WeaponJamming.maxShotsBeforeBadCondition - weaponTotalShots : 0;
                        }
                        num3 = ++WeaponJamming.shotsFired;
                        if (Common.rnd.Next(0, WeaponJamming.max_rnd_chance) == 0)
                        {
                            WeaponJamming.jammCounter = Common.rnd.Next(1, 5);
                            if (!((IEnumerable<WeaponHash>)WeaponJamming.jammedWeapons).Contains<WeaponHash>(Player.Weapons.Current.Hash))
                                WeaponJamming.jammedWeapons = ((IEnumerable<WeaponHash>)WeaponJamming.jammedWeapons).Concat<WeaponHash>((IEnumerable<WeaponHash>)new WeaponHash[1]
                                {
                  Player.Weapons.Current.Hash
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
                    if (WeaponJamming.shootingWeapon != (WeaponHash)0 && !Player.IsShooting && WeaponJamming.shotsFired > 0 && Player.Model != (Model)0)
                    {
                        WeaponJamming.saveShotsForCurWeapon(Player, Common.doc, WeaponJamming.shotsFired, WeaponJamming.shootingWeapon);
                        WeaponJamming.shootingWeapon = (WeaponHash)Player.Weapons.Current;
                        WeaponJamming.shotsFired = 0;
                    }
                }
            }
            if (Common.deal && !Common.payed)
            {
                if ((Entity)Common.seller != (Entity)null)
                {
                    vector3_1 = Common.seller.Position;
                    if ((double)vector3_1.DistanceTo(Player.Position) < 15.0 && !Common.payed)
                        Common.callContact.Name = "Pay for purchases";
                }
            }
            else
                Common.callContact.Name = "Richard";
            if (Common.come_over_mode)
            {
                if (Function.Call<int>(Hash.GET_INTERIOR_FROM_ENTITY, (InputArgument)(Entity)Player) == 0)
                {
                    if ((Entity)Common.seller == (Entity)null || (Entity)Common.seller != (Entity)null && (!Common.seller.Exists() || Common.seller.IsDead))
                    {
                        if ((Entity)HTools.Main.TryToGetPedAtLocation(Player.Position, 25f, PedHash.Dealer01SMY) == (Entity)null)
                            Common.CreateSeller(World.GetSafeCoordForPed(new Vector3(Player.Position.X, Player.Position.Y + 100f, Player.Position.Z), flags: 1));
                    }
                    else
                        Common.ComeOverFunc(Player, Common.seller, InventoryBag.hours_to_advance);
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
                        Vector3 vector3_6 = new Vector3(Player.Position.X, Player.Position.Y, Player.Position.Z);
                        World.GetSafeCoordForPed(vector3_6, false, 1);
                        if ((Entity)Common.seller == (Entity)null || (Entity)Common.seller != (Entity)null && (!Common.seller.Exists() || Common.seller.IsDead))
                        {
                            if ((Entity)HTools.Main.TryToGetPedAtLocation(Player.Position, 25f, PedHash.Dealer01SMY) == (Entity)null)
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
                Common.followCameraCreateFunc(Player, Common.CamObject);
            else
                Common.followCameraDeleteFunc(Player, Common.CamObject);
            if (Screen.IsFadedOut || Function.Call<bool>(Hash.IS_PLAYER_SWITCH_IN_PROGRESS))
            {
                if (!Common.trash_cleared)
                {
                    Common.trash_cleared = true;
                    Common.update_inventory_status(Player);
                    Common.clearTrash();
                }
            }
            else
                Common.trash_cleared = false;
            if ((Entity)Common.curPlayer != (Entity)Player)
            {
                if ((Entity)InventoryBag.cur_bag != (Entity)null && !InventoryBag.cur_bag.IsAttached())
                    InventoryBag.cur_bag.Delete();
                Common.curPlayer = Player;
                Common.update_inventory_status(Player);
                Common.clearTrash();
            }
            if (Player.IsDead)
            {
                OnFootRadio.isHeadsetBought = false;
                Vest.armortakenoff = false;
                Common.ClearedItemsWhenDeadXML();
                Common.ClearItemsWhenDead();
                Common.clearTrash();
                Common.DeleteSupplies(Player);
                Player.Weapons.RemoveAll();
            }
            if (InventoryBag.bag_module_active)
            {
                if (Player.IsOnFoot && (Entity)InventoryBag.bagModelReturn(Player) != (Entity)null)
                {
                    if (!Common.isOccupied(Player) && !HTools.Main.isOccupiedNative(Player))
                        InventoryBag.WeaponSwitchAnim(Player);
                    else
                        InventoryBag.prevWeapon = Function.Call<uint>(Hash.GET_SELECTED_PED_WEAPON, (InputArgument)(Entity)Player);
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
                                if ((double)vector3_1.DistanceTo(Player.Position) <= 1.0)
                                {
                                    Common.blipHandle(false, dropedBag, BlipSprite.Briefcase2, "DuffleBag", 0.85f, 200, true, true);
                                    dropedBag.Delete();
                                    InventoryBag.bagSet(InventoryBag.bagModelCheck(Player), Player);
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
                    InventoryBag.bagSet(InventoryBag.bagModelCheck(Player), Player);
                if (InventoryBag.droped_bag != (Entity)null)
                    Function.Call(Hash.DRAW_LIGHT_WITH_RANGE, (InputArgument)InventoryBag.droped_bag.Position.X, (InputArgument)InventoryBag.droped_bag.Position.Y, (InputArgument)InventoryBag.droped_bag.Position.Z, (InputArgument)50, (InputArgument)(int)byte.MaxValue, (InputArgument)0, (InputArgument)1f, (InputArgument)1f);
                if (InventoryBag.DufflebagTimeCounter < Game.GameTime)
                {
                    InventoryBag.DufflebagTimeCounter = Game.GameTime + 5000;
                    InventoryBag.droped_bag = InventoryBag.getDroppedBag(Player);
                    if ((Entity)Player != (Entity)null && InventoryBag.droped_bag != (Entity)null)
                    {
                        if (Function.Call<bool>(Hash.IS_PLAYER_SWITCH_IN_PROGRESS))
                        {
                            InventoryBag.droped_bag.Delete();
                            Common.blipsRemove(BlipSprite.Information);
                        }
                        if (Player.IsOnFoot)
                        {
                            if (InventoryBag.droped_bag != (Entity)null && InventoryBag.droped_bag.Exists())
                            {
                                vector3_1 = Player.Position;
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
                    if (Player.IsSittingInVehicle())
                    {
                        model = Player.CurrentVehicle.Model;
                        if (!model.IsBike)
                        {
                            model = Player.CurrentVehicle.Model;
                            if (!model.IsBicycle)
                            {
                                model = Player.CurrentVehicle.Model;
                                if (!model.IsQuadBike)
                                {
                                    Prop bag = InventoryBag.bagModelReturn(Player);
                                    if ((Entity)bag != (Entity)null && bag.IsVisible)
                                    {
                                        if (Player.CurrentVehicle.IsStopped)
                                        {
                                            InventoryBag.TakeOffBagInCar(bag, Player);
                                            goto label_1340;
                                        }
                                        else
                                            goto label_1340;
                                    }
                                    else if ((Entity)bag == (Entity)null)
                                    {
                                        if (InventoryBag.VehicleWithBag(Player))
                                        {
                                            InventoryBag.canTakeBagFromVehicle = true;
                                            if (!InventoryBag.notifed)
                                            {
                                                Function.Call(Hash.SET_TEXT_COLOUR, (InputArgument)(int)byte.MaxValue, (InputArgument)0, (InputArgument)0, (InputArgument)100);
                                                HTools.Main.Notify("~y~Your bag is stashed in this vehicle", "IBAG", (int)byte.MaxValue, 0, 0, NotificationIcon.Ammunation);
                                                Screen.ShowHelpText("~BLIP_INFO_ICON~ Your bag is stashed in this vehicle", 3000);
                                                Common.blipHandle(true, (Entity)Player.CurrentVehicle, BlipSprite.Information, "DuffleBag", 0.85f, 200, false, false);
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
                    if (InventoryBag.doesPedHasInventoryBag(Player) && !Player.IsSittingInVehicle() && !Function.Call<bool>(Hash.IS_CUTSCENE_PLAYING) && Screen.IsFadedIn && Player.IsStopped && (Entity)InventoryBag.bagModelReturn(Player) == (Entity)null)
                        InventoryBag.bagSet(InventoryBag.bagModelCheck(Player), Player);
                    if ((Entity)Player != (Entity)null)
                    {
                        if (Player.IsOnFoot)
                            InventoryBag.checkBagVisibility(Player);
                        else if ((Entity)Player.CurrentVehicle != (Entity)null && Player.IsSittingInVehicle())
                        {
                            model = Player.CurrentVehicle.Model;
                            if (!model.IsBicycle)
                            {
                                model = Player.CurrentVehicle.Model;
                                if (!model.IsQuadBike)
                                {
                                    model = Player.CurrentVehicle.Model;
                                    if (!model.IsBike)
                                        goto label_1352;
                                }
                            }
                            InventoryBag.checkBagVisibility(Player);
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
                            if (Player.Model != (Model)pedHash)
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
                    if ((Entity)InventoryBag.bagModelReturn(Player) != (Entity)null && !Common.inMainMenu)
                        InventoryBag.checkEquipedGear(Player);
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
                    Entity droppedBag = InventoryBag.getDroppedBag(Player);
                    if (droppedBag != (Entity)null)
                        Common.blipHandle(true, droppedBag, BlipSprite.Information, "Dufflebag", 0.85f, 200, true, false);
                    HTools.Main.Notify("Stashed bag's location~n~  has been ~y~Marked", "IBAG", (int)byte.MaxValue, 0, 0, NotificationIcon.Ammunation);
                    
                    //Function.Call(Hash.CELL_SET_INPUT, (InputArgument)2);
                    //HTools.Main.ClosePhoneFunc(Player, 0, 0);
                    Common.findSellerOption = false;
                    Common.followCamera = false;
                    HTools.Main.soundFX(Player, "beep.wav", Common.assetFolder);
                }
                if (Function.Call<bool>(Hash.IS_DISABLED_CONTROL_JUST_PRESSED, (InputArgument)0, (InputArgument)num27))
                {

                    Common.findSellerOption = false;
                    //Player.Task.ClearAll();
                    //Common.findSellerOption = false;
                    //Function.Call(Hash.CELL_SET_INPUT, (InputArgument)1);
                    //Common.IFruit.Close();
                    //HTools.Main.ClosePhoneFunc(Player, 0, 0);
                    Common.followCamera = false;
                    
                    //Player.Task.PutAwayMobilePhone();
                    //Player.Task.ClearAll();
                }
                if (Function.Call<bool>(Hash.IS_DISABLED_CONTROL_JUST_PRESSED, (InputArgument)0, (InputArgument)num26))
                {
                    WeaponJamming.hasCleaningTools = Common.getSupplies(Player, "weapon_tools") > 0;
                    InventoryBag.hasBag = InventoryBag.doesPedHasInventoryBag(Player);
                    WeaponHolster.hasHolster = WeaponHolster.doesPedHasHolster(Player);
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
                    //HTools.Main.ClosePhoneFunc(Player, 0, 0);
                    Common.findSellerOption = false;
                    HTools.Main.soundFX(Player, "beep.wav", Common.assetFolder);
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
                    if (!InventoryBag.reattached && Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Player, (InputArgument)"anim@heists@money_grab@duffel", (InputArgument)"enter", (InputArgument)3) && (double)Function.Call<float>(Hash.GET_ENTITY_ANIM_CURRENT_TIME, (InputArgument)(Entity)Player, (InputArgument)"anim@heists@money_grab@duffel", (InputArgument)"enter") >= 0.75)
                    {
                        int num29 = Function.Call<int>(Hash.GET_PED_BONE_INDEX, (InputArgument)(Entity)Player, (InputArgument)57005);
                        InventoryBag.reattached = true;
                        Function.Call(Hash.ATTACH_ENTITY_TO_ENTITY, (InputArgument)(Entity)InventoryBag.bagModelReturn(Player), (InputArgument)(Entity)Player, (InputArgument)num29, (InputArgument)InventoryBag.xg, (InputArgument)InventoryBag.yg, (InputArgument)InventoryBag.zg, (InputArgument)InventoryBag.xrg, (InputArgument)InventoryBag.yrg, (InputArgument)InventoryBag.zrg, (InputArgument)true, (InputArgument)true, (InputArgument)false, (InputArgument)false, (InputArgument)2, (InputArgument)true);
                    }
                    if (Function.Call<bool>(Hash.IS_DISABLED_CONTROL_JUST_PRESSED, (InputArgument)0, (InputArgument)177) || Function.Call<bool>(Hash.IS_DISABLED_CONTROL_JUST_PRESSED, (InputArgument)0, (InputArgument)202) || Function.Call<bool>(Hash.IS_DISABLED_CONTROL_JUST_PRESSED, (InputArgument)0, (InputArgument)25))
                    {
                        Common.followCamera = false;
                        Player.Task.ClearAll();
                        InventoryBag.inMenu = false;
                        InventoryBag.mainMenuListString.Clear();
                        InventoryBag.stashedWeapons.Clear();
                        InventoryBag.characterWeapons.Clear();
                        InventoryBag.mainMenu.Visible = false;
                        InventoryBag.modMenuPool.CloseAllMenus();
                        InventoryBag.mainMenu.Clear();
                        InventoryBag.mainMenu = (UIMenu)null;
                        InventoryBag.modMenuPool = (MenuPool)null;
                        InventoryBag.weaponInventoryAnim(InventoryBag.bagModelReturn(Player), Player);
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
                                if (!Common.isOccupied(Player) && !HTools.Main.isOccupiedNative(Player))
                                    InventoryBag.weaponInventoryAnim(InventoryBag.bagModelReturn(Player), Player);
                                InventoryBag.mainMenu.Visible = true;
                            }
                            else
                                InventoryBag.Setup(Player);
                        }
                    }
                    else
                        InventoryBag.Setup(Player);
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
                        Player.Task.ClearAll();
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
                                //if (!Common.isOccupied(Player) && !HTools.Main.isOccupiedNative(Player))
                                  //  InventoryBag.weaponInventoryAnim(InventoryBag.bagModelReturn(Player), Player);
                                Vest.mainMenu.Visible = true;
                            }
                            else
                                Vest.Setup(Player);
                        }
                    }
                    else
                        Vest.Setup(Player);

                    
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
                vector3_1 = Player.Position;
                if ((double)vector3_1.DistanceTo(Common.seller.Position) >= 50.0)
                    return;
                if (Common.deal && Common.greetingFinished)
                {
                    vector3_1 = Player.Position;
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
                            if (Player.Model == (Model)PedHash.Michael || Player.Model == (Model)PedHash.Franklin || Player.Model == (Model)PedHash.Trevor)
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
                        if (Function.Call<bool>(Hash.IS_PED_FACING_PED, (InputArgument)(Entity)Common.seller, (InputArgument)(Entity)Player, (InputArgument)10f))
                        {
                            if (!Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Player, (InputArgument)"oddjobs@assassinate@construction@", (InputArgument)"unarmed_fold_arms", (InputArgument)3))
                            {
                                Player.Task.LookAt((Entity)Common.seller);
                                Player.Task.PlayAnimation("oddjobs@assassinate@construction@", "unarmed_fold_arms", 3f, -1, AnimationFlags.Loop | AnimationFlags.UpperBodyOnly);
                            }
                        }
                        else
                        {
                            HTools.Main.DisableControlsFunc(true);
                            if (Common.timeOut > 0)
                                num3 = --Common.timeOut;
                            if (Common.timeOut <= 0)
                            {
                                if (!Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Player, (InputArgument)"oddjobs@assassinate@construction@", (InputArgument)"unarmed_fold_arms", (InputArgument)3))
                                {
                                    Player.Task.TurnTo((Entity)Common.seller);
                                    Common.seller.Task.TurnTo((Entity)Player);
                                    Common.timeOut = 200;
                                }
                                else
                                {
                                    Player.Task.ClearAll();
                                    Player.Task.TurnTo((Entity)Common.seller);
                                    Common.seller.Task.TurnTo((Entity)Player);
                                    Common.timeOut = 200;
                                }
                            }
                        }
                    }
                    else if (Common.canceled)
                    {
                        Function.Call(Hash.PLAY_MISSION_COMPLETE_AUDIO, (InputArgument)"TREVOR_SMALL_01");
                        Function.Call(Hash.PLAY_PED_AMBIENT_SPEECH_NATIVE, (InputArgument)(Entity)Player, (InputArgument)"GENERIC_NO", (InputArgument)"SPEECH_PARAMS_FORCE");
                        Script.Wait(1000);
                        Function.Call(Hash.PLAY_PED_AMBIENT_SPEECH_NATIVE, (InputArgument)(Entity)Player, (InputArgument)"GENERIC_BYE", (InputArgument)"SPEECH_PARAMS_FORCE");
                        Common.clearScriptFunction();
                    }
                    else if (Common.payed)
                    {
                        int num38 = 9999999;
                        if (Player.Model == (Model)PedHash.Michael || Player.Model == (Model)PedHash.Franklin || Player.Model == (Model)PedHash.Trevor)
                            num38 = Game.Player.Money;
                        if (num38 > Common.TotalPrice + Common.TotalPrice / 100 * 5)
                        {
                            vector3_1 = Player.Position;
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
                                    TaskInvoker task = Player.Task;
                                    Ped seller = Common.seller;
                                    vector3_1 = new Vector3();
                                    Vector3 offset = vector3_1;
                                    task.GoTo((Entity)seller, offset);
                                    Common.seller.Task.GoTo(Player.Position, 5000);
                                    Common.timeOut = 200;
                                }
                            }
                        }
                        else
                        {
                            HTools.Main.Notify("Transaction ~r~Failed", "MAZE", (int)byte.MaxValue, 0, 0, NotificationIcon.BankMaze);
                            HTools.Main.Notify("~o~Not enough money on your account", "MAZE", (int)byte.MaxValue, 0, 0, NotificationIcon.BankMaze);
                            Function.Call(Hash.PLAY_PED_AMBIENT_SPEECH_NATIVE, (InputArgument)(Entity)Common.seller, (InputArgument)"GENERIC_CURSE_MED", (InputArgument)"SPEECH_PARAMS_FORCE");
                            Function.Call(Hash.PLAY_PED_AMBIENT_SPEECH_NATIVE, (InputArgument)(Entity)Player, (InputArgument)"GAME_BAD_SELF", (InputArgument)"SPEECH_PARAMS_FORCE");
                            Common.clearScriptFunction();
                        }
                    }
                    else
                    {
                        if (Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)Player, (InputArgument)"oddjobs@assassinate@construction@", (InputArgument)"unarmed_fold_arms", (InputArgument)3))
                        {
                            Player.Task.ClearAll();
                            Function.Call(Hash.PLAY_PED_AMBIENT_SPEECH_NATIVE, (InputArgument)(Entity)Player, (InputArgument)"GENERIC_YES", (InputArgument)"SPEECH_PARAMS_FORCE");
                        }
                        Screen.ShowHelpTextThisFrame("~BLIP_INFO_ICON~ Pay for purchases with your ~y~Phone");
                    }
                }
                if ((Entity)Common.seller != (Entity)null && !Common.greeting)
                {
                    vector3_1 = Player.Position;
                    if ((double)vector3_1.DistanceTo(Common.seller.Position) < 7.0)
                    {
                        if (Common.seller.IsOnFoot)
                            Common.greeting = true;
                        else if (Common.allowActionPerform(Common.seller, 100))
                            Common.seller.Task.LeaveVehicle();
                    }
                    else
                    {
                        vector3_1 = Player.Position;
                        if ((double)vector3_1.DistanceTo(Common.seller.Position) < 50.0)
                        {
                            if (Common.timeOut > 0)
                                num3 = --Common.timeOut;
                            if (Common.timeOut <= 0)
                            {
                                TaskInvoker task = Common.seller.Task;
                                Ped character = Player;
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
                vector3_1 = Player.Position;
                if ((double)vector3_1.DistanceTo(Common.seller.Position) > 50.0)
                    Common.clearScriptFunction();
                vector3_1 = Player.Position;
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
                if ((double)vector3_1.DistanceTo(Player.Position) >= 2.5)
                    return;
                Function.Call(Hash.PLAY_PED_AMBIENT_SPEECH_NATIVE, (InputArgument)(Entity)Player, (InputArgument)"GENERIC_HI", (InputArgument)"SPEECH_PARAMS_FORCE");
                Common.seller.Task.LookAt((Entity)Player, 1000);
                Function.Call(Hash.PLAY_PED_AMBIENT_SPEECH_NATIVE, (InputArgument)(Entity)Common.seller, (InputArgument)"GENERIC_HOWS_IT_GOING", (InputArgument)"SPEECH_PARAMS_FORCE");
                if (Common.sellerDialogCounter > 0)
                    return;
                Common.payed = false;
                Common.greetingFinished = true;
                Common.followCamera = false;
                Common.seller.Task.ClearAll();
                Player.Task.ClearAll();
                Common.deal = true;
                WeaponJamming.cleaningToolsCount = Common.getSupplies(Player, "weapon_tools");
                Common.inProcessBag = false;
                Common.update_inventory_status(Player);
                WeaponJamming.hasCleaningTools = Common.getSupplies(Player, "weapon_tools") > 0;
                InventoryBag.hasBag = InventoryBag.doesPedHasInventoryBag(Player);
                WeaponHolster.hasHolster = WeaponHolster.doesPedHasHolster(Player);
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
