// Decompiled with JetBrains decompiler
// Type: GTAExpansion.CigsAndPills
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


namespace GTAExpansion
{
    public static class CigsAndPills
    {
        public static bool extraEffects = ScriptSettings.Load("scripts\\Expansion\\Expansion.ini").GetValue<bool>("CIGS_AND_PILLS_SETTINGS", "EXTRA_EFFECTS", false);
        public static bool screenFX = ScriptSettings.Load("scripts\\Expansion\\Expansion.ini").GetValue<bool>("CIGS_AND_PILLS_SETTINGS", "SCREEN_EFFECT", true);
        public static bool hintShow = ScriptSettings.Load("scripts\\Expansion\\Expansion.ini").GetValue<bool>("CIGS_AND_PILLS_SETTINGS", "SHOW_HINTS", true);
        public static int swallowBTN = ScriptSettings.Load("scripts\\Expansion\\Expansion.ini").GetValue<int>("CIGS_AND_PILLS_SETTINGS", "PILLS_SWALLOW_BTN", 51);
        public static int maxPills = ScriptSettings.Load("scripts\\Expansion\\Expansion.ini").GetValue<int>("CIGS_AND_PILLS_SETTINGS", "MAX_PILLS", 25);
        public static int extraFXDuration = ScriptSettings.Load("scripts\\Expansion\\Expansion.ini").GetValue<int>("CIGS_AND_PILLS_SETTINGS", "EFFECTS_DURATION", 1000);
        public static int SupplyPrice = ScriptSettings.Load("scripts\\Expansion\\Expansion.ini").GetValue<int>("PRICES", "SUPPLY_PRICE", 25);
        public static bool cigsAndPillsCountDown = false;
        public static int cigsAndPillsCounter = 15;
        public static int pillsCount = 0;
        public static bool blockKeys = false;
        public static int cigsCount = 0;
        public static int smokeBTN = ScriptSettings.Load("scripts\\Expansion\\Expansion.ini").GetValue<int>("CIGS_AND_PILLS_SETTINGS", "SMOKE_TOGGLE_BTN", 44);
        public static int maxCigs = ScriptSettings.Load("scripts\\Expansion\\Expansion.ini").GetValue<int>("CIGS_AND_PILLS_SETTINGS", "MAX_CIGS", 25);
        public static int max_cig_durability = ScriptSettings.Load("scripts\\Expansion\\Expansion.ini").GetValue<int>("CIGS_AND_PILLS_SETTINGS", "MAX_CIG_DURABILITY", 25);
        public static int cig_durability = 0;
        public static bool cigIgnited = false;
        public static bool readyToIgnite = false;
        public static bool ignitingCig = false;
        public static int lighterFlameTimer = 0;
        public static bool cigReady = false;
        public static Prop lighter = (Prop)null;
        public static int particalEffect = 0;
        public static string smokeType = "prop_amb_ciggy_01";
        public static bool playCigAndSmokeAnim = true;
        public static bool flame = false;
        public static int sizzle = 0;
        public static int smoke = -1;
        public static bool smoking = false;
        public static bool startSmoke = true;
        public static bool play_swallow_pills_anim = false;
        public static Prop cig;
        public static Prop medbag;
        public static string medbagObject = "prop_ld_health_pack";
        public static bool canRefill = false;
        public static bool inProcessCigsAndPills = false;
        public static bool extraEffectsStat = false;
        public static int extraEffectsTimer = 0;
        public static float slowMoScale = 0.0f;
        public static Prop pillsJar = (Prop)null;
        public static bool swallow_in_process = false;
        public static float swallo_anim_current_time = 0.0f;
        public static int cigsAndPillsPrice = ScriptSettings.Load("scripts\\Expansion\\Expansion.ini").GetValue<int>("PRICES", "CIGS_AND_PAINKILLERS_PRICE", 25);

        public static void StartSmokeFunc(Ped ped, int type)
        {
            CigsAndPills.smoking = true;
            if (!((Entity)CigsAndPills.cig != (Entity)null))
                return;
            if (!CigsAndPills.cigReady)
            {
                if (!Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)ped, (InputArgument)"reaction@intimidation@cop@unarmed", (InputArgument)"intro", (InputArgument)3) && !Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)ped, (InputArgument)"amb@world_human_smoking@male@male_a@enter", (InputArgument)"enter", (InputArgument)3))
                    ped.Task.PlayAnimation("amb@world_human_smoking@male@male_a@enter", "enter", 4f, -1, AnimationFlags.StayInEndFrame | AnimationFlags.UpperBodyOnly | AnimationFlags.Secondary);
                if (!Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)ped, (InputArgument)"amb@world_human_smoking@male@male_a@enter", (InputArgument)"enter", (InputArgument)3))
                    return;
                if ((double)Function.Call<float>(Hash.GET_ENTITY_ANIM_CURRENT_TIME, (InputArgument)(Entity)ped, (InputArgument)"amb@world_human_smoking@male@male_a@enter", (InputArgument)"enter") >= 0.10000000149011612 && (double)Function.Call<float>(Hash.GET_ENTITY_ANIM_CURRENT_TIME, (InputArgument)(Entity)ped, (InputArgument)"amb@world_human_smoking@male@male_a@enter", (InputArgument)"enter") < 0.20000000298023224)
                {
                    CigsAndPills.cigsAndPillsCountDown = true;
                    CigsAndPills.cigsAndPillsCounter = 9;
                    CigsAndPills.cig.IsVisible = true;
                }
                if ((double)Function.Call<float>(Hash.GET_ENTITY_ANIM_CURRENT_TIME, (InputArgument)(Entity)ped, (InputArgument)"amb@world_human_smoking@male@male_a@enter", (InputArgument)"enter") >= 0.6 || (double)Function.Call<float>(Hash.GET_ENTITY_ANIM_CURRENT_TIME, (InputArgument)(Entity)ped, (InputArgument)"amb@world_human_smoking@male@male_a@enter", (InputArgument)"enter") <= 0.15000000596046448)
                    return;
                if (CigsAndPills.cig.Exists())
                {
                    if (ped.Model.Hash != Main.GetHashKey("PLAYER_ZERO") && ped.Model.Hash != Main.GetHashKey("PLAYER_ONE") && ped.Model.Hash != Main.GetHashKey("PLAYER_TWO"))
                    {
                        int num = Function.Call<int>(Hash.GET_PED_BONE_INDEX, (InputArgument)(Entity)ped, (InputArgument)47419);
                        Function.Call<Vector3>(Hash.GET_PED_BONE_COORDS, (InputArgument)(Entity)ped, (InputArgument)num, (InputArgument)0, (InputArgument)0, (InputArgument)0);
                        Function.Call(Hash.ATTACH_ENTITY_TO_ENTITY, (InputArgument)(Entity)CigsAndPills.cig, (InputArgument)(Entity)ped, (InputArgument)num, (InputArgument)0.0f, (InputArgument)0.0f, (InputArgument)0.01f, (InputArgument)0, (InputArgument)10f, (InputArgument)55f, (InputArgument)false, (InputArgument)false, (InputArgument)false, (InputArgument)false, (InputArgument)2, (InputArgument)true);
                    }
                    else
                    {
                        int num = Function.Call<int>(Hash.GET_PED_BONE_INDEX, (InputArgument)(Entity)ped, (InputArgument)65068);
                        Function.Call<Vector3>(Hash.GET_PED_BONE_COORDS, (InputArgument)(Entity)ped, (InputArgument)num, (InputArgument)0, (InputArgument)0, (InputArgument)0);
                        Function.Call(Hash.ATTACH_ENTITY_TO_ENTITY, (InputArgument)(Entity)CigsAndPills.cig, (InputArgument)(Entity)ped, (InputArgument)num, (InputArgument)0.02f, (InputArgument)(-0.05f), (InputArgument)0.1f, (InputArgument)10f, (InputArgument)90f, (InputArgument)0.0f, (InputArgument)false, (InputArgument)false, (InputArgument)false, (InputArgument)false, (InputArgument)2, (InputArgument)true);
                    }
                }
                if (!((Entity)CigsAndPills.cig != (Entity)null) || !CigsAndPills.cig.IsAttachedTo((Entity)ped))
                    return;
                CigsAndPills.cigReady = true;
                ped.Task.ClearAnimation("amb@world_human_smoking@male@male_a@enter", "enter");
                ped.Task.ClearSecondary();
            }
            else
            {
                if (Common.inMainMenu || InventoryBag.inMenu || ped.IsAiming || ped.IsRagdoll || Main.isOccupiedNative(ped))
                    return;
                Common.Draw(8, cameraModuleParam: false, swingWeaponModuleParam: false, laserSightModuleParam: false, weaponJamningModuleParam: false, aimingStyleModeActiveParam: false);
                if (!CigsAndPills.cigIgnited)
                {
                    if (!CigsAndPills.readyToIgnite)
                    {
                        Main.DisableControlsFunc(false);
                        if (Function.Call<bool>(Hash.IS_DISABLED_CONTROL_JUST_RELEASED, (InputArgument)0, (InputArgument)24))
                        {
                            CigsAndPills.readyToIgnite = true;
                            Function.Call(Hash.PLAY_SOUND_FRONTEND, (InputArgument)(-1), (InputArgument)"FocusIn", (InputArgument)"HintCamSounds");
                        }
                        if (Function.Call<bool>(Hash.IS_DISABLED_CONTROL_PRESSED, (InputArgument)0, (InputArgument)25))
                        {
                            Function.Call(Hash.PLAY_SOUND_FRONTEND, (InputArgument)(-1), (InputArgument)"FocusOut", (InputArgument)"HintCamSounds");
                            if (!Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)ped, (InputArgument)"reaction@intimidation@cop@unarmed", (InputArgument)"intro", (InputArgument)3))
                            {
                                CigsAndPills.startSmoke = false;
                                CigsAndPills.cig_durability = 0;
                                CigsAndPills.clearLighter(ped, Main.GetHashKey("ex_prop_exec_lighter_01"));
                                CigsAndPills.lighter = (Prop)null;
                                ped.Task.ClearAll();
                                Script.Wait(100);
                                CigsAndPills.stopSmokingFunc(ped);
                            }
                        }
                        if ((double)Function.Call<float>(Hash.GET_ENTITY_ANIM_CURRENT_TIME, (InputArgument)(Entity)ped, (InputArgument)"amb@world_human_smoking@male@male_a@enter", (InputArgument)"enter") <= 0.550000011920929)
                            return;
                        CigsAndPills.clearLighter(ped, Main.GetHashKey("ex_prop_exec_lighter_01"));
                        CigsAndPills.lighter = (Prop)null;
                        ped.Task.ClearAll();
                    }
                    else
                    {
                        Main.DisableControlsFunc(true);
                        if (!Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)ped, (InputArgument)"reaction@intimidation@cop@unarmed", (InputArgument)"intro", (InputArgument)3) && !Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)ped, (InputArgument)"amb@world_human_smoking@male@male_a@enter", (InputArgument)"enter", (InputArgument)3))
                        {
                            ped.Task.PlayAnimation("amb@world_human_smoking@male@male_a@enter", "enter", 4f, -1, AnimationFlags.StayInEndFrame | AnimationFlags.UpperBodyOnly | AnimationFlags.Secondary);
                            Function.Call(Hash.SET_ENTITY_ANIM_CURRENT_TIME, (InputArgument)(Entity)ped, (InputArgument)"amb@world_human_smoking@male@male_a@enter", (InputArgument)"enter", (InputArgument)0.28f);
                        }
                        else
                        {
                            if ((double)Function.Call<float>(Hash.GET_ENTITY_ANIM_CURRENT_TIME, (InputArgument)(Entity)ped, (InputArgument)"amb@world_human_smoking@male@male_a@enter", (InputArgument)"enter") > 0.2800000011920929 && (double)Function.Call<float>(Hash.GET_ENTITY_ANIM_CURRENT_TIME, (InputArgument)(Entity)ped, (InputArgument)"amb@world_human_smoking@male@male_a@enter", (InputArgument)"enter") < 0.31999999284744263)
                            {
                                int num = Function.Call<int>(Hash.GET_PED_BONE_INDEX, (InputArgument)(Entity)ped, (InputArgument)18905);
                                Vector3 pos = Function.Call<Vector3>(Hash.GET_PED_BONE_COORDS, (InputArgument)(Entity)ped, (InputArgument)num, (InputArgument)0, (InputArgument)0, (InputArgument)0);
                                CigsAndPills.lighter = CigsAndPills.createLighter(ped, pos, Main.GetHashKey("ex_prop_exec_lighter_01"));
                                Function.Call(Hash.REMOVE_PARTICLE_FX_FROM_ENTITY, (InputArgument)(Entity)CigsAndPills.lighter);
                            }
                            else if ((double)Function.Call<float>(Hash.GET_ENTITY_ANIM_CURRENT_TIME, (InputArgument)(Entity)ped, (InputArgument)"amb@world_human_smoking@male@male_a@enter", (InputArgument)"enter") < 0.2800000011920929)
                                Function.Call(Hash.SET_ENTITY_ANIM_CURRENT_TIME, (InputArgument)(Entity)ped, (InputArgument)"amb@world_human_smoking@male@male_a@enter", (InputArgument)"enter", (InputArgument)0.28f);
                            if ((double)Function.Call<float>(Hash.GET_ENTITY_ANIM_CURRENT_TIME, (InputArgument)(Entity)ped, (InputArgument)"amb@world_human_smoking@male@male_a@enter", (InputArgument)"enter") > 0.40000000596046448)
                                Function.Call(Hash.SET_ENTITY_ANIM_CURRENT_TIME, (InputArgument)(Entity)ped, (InputArgument)"amb@world_human_smoking@male@male_a@enter", (InputArgument)"enter", (InputArgument)0.4f);
                            if (!CigsAndPills.ignitingCig)
                            {
                                if (Function.Call<bool>(Hash.IS_DISABLED_CONTROL_JUST_PRESSED, (InputArgument)0, (InputArgument)25))
                                {
                                    Function.Call(Hash.PLAY_SOUND_FRONTEND, (InputArgument)(-1), (InputArgument)"FocusOut", (InputArgument)"HintCamSounds");
                                    int num = Function.Call<int>(Hash.GET_PED_BONE_INDEX, (InputArgument)(Entity)ped, (InputArgument)18905);
                                    Vector3 pos = Function.Call<Vector3>(Hash.GET_PED_BONE_COORDS, (InputArgument)(Entity)ped, (InputArgument)num, (InputArgument)0, (InputArgument)0, (InputArgument)0);
                                    CigsAndPills.lighter = CigsAndPills.createLighter(ped, pos, Main.GetHashKey("ex_prop_exec_lighter_01"), false);
                                    Function.Call(Hash.REMOVE_PARTICLE_FX_FROM_ENTITY, (InputArgument)(Entity)CigsAndPills.lighter);
                                    CigsAndPills.readyToIgnite = false;
                                    Script.Wait(500);
                                }
                                if (!Function.Call<bool>(Hash.IS_DISABLED_CONTROL_JUST_PRESSED, (InputArgument)0, (InputArgument)24))
                                    return;
                                Function.Call(Hash.PLAY_SOUND_FRONTEND, (InputArgument)(-1), (InputArgument)"FocusIn", (InputArgument)"HintCamSounds");
                                CigsAndPills.lighterFlameTimer = Common.rnd.Next(100, 200);
                                CigsAndPills.ignitingCig = true;
                                int num1 = Function.Call<int>(Hash.GET_PED_BONE_INDEX, (InputArgument)(Entity)ped, (InputArgument)18905);
                                Vector3 pos1 = Function.Call<Vector3>(Hash.GET_PED_BONE_COORDS, (InputArgument)(Entity)ped, (InputArgument)num1, (InputArgument)0, (InputArgument)0, (InputArgument)0);
                                CigsAndPills.lighter = CigsAndPills.createLighter(ped, pos1, Main.GetHashKey("ex_prop_exec_lighter_01"));
                                CigsAndPills.LighterSoundFX(ped);
                                CigsAndPills.particalEffect = 0;
                            }
                            else
                            {
                                if (Function.Call<bool>(Hash.IS_DISABLED_CONTROL_PRESSED, (InputArgument)0, (InputArgument)24))
                                {
                                    if ((Entity)CigsAndPills.lighter != (Entity)null)
                                    {
                                        Function.Call(Hash.REQUEST_NAMED_PTFX_ASSET, (InputArgument)"scr_safehouse");
                                        Function.Call(Hash.USE_PARTICLE_FX_ASSET, (InputArgument)"scr_safehouse");
                                        CigsAndPills.particalEffect = Function.Call<int>(Hash.START_PARTICLE_FX_LOOPED_ON_ENTITY, (InputArgument)"scr_sh_lighter_flame", (InputArgument)(Entity)CigsAndPills.lighter, (InputArgument)0, (InputArgument)0, (InputArgument)0.05f, (InputArgument)0, (InputArgument)0, (InputArgument)0, (InputArgument)0.65f, (InputArgument)true, (InputArgument)true, (InputArgument)true);
                                    }
                                    --CigsAndPills.lighterFlameTimer;
                                }
                                if (!Function.Call<bool>(Hash.IS_DISABLED_CONTROL_JUST_RELEASED, (InputArgument)0, (InputArgument)24) && CigsAndPills.lighterFlameTimer > 0)
                                    return;
                                Function.Call(Hash.PLAY_SOUND_FRONTEND, (InputArgument)(-1), (InputArgument)"FocusOut", (InputArgument)"HintCamSounds");
                                if ((Entity)CigsAndPills.lighter != (Entity)null)
                                    Function.Call(Hash.REMOVE_PARTICLE_FX_FROM_ENTITY, (InputArgument)(Entity)CigsAndPills.lighter);
                                if (CigsAndPills.lighterFlameTimer <= 0)
                                {
                                    CigsAndPills.ignitingCig = false;
                                    CigsAndPills.cigIgnited = true;
                                    if (!((Entity)CigsAndPills.cig != (Entity)null))
                                        return;
                                    Function.Call(Hash.REQUEST_NAMED_PTFX_ASSET, (InputArgument)"scr_safehouse");
                                    Function.Call(Hash.USE_PARTICLE_FX_ASSET, (InputArgument)"scr_safehouse");
                                    CigsAndPills.particalEffect = Function.Call<int>(Hash.START_PARTICLE_FX_LOOPED_ON_ENTITY, (InputArgument)"scr_sh_lighter_flame", (InputArgument)(Entity)CigsAndPills.cig, (InputArgument)(-0.075f), (InputArgument)0.0f, (InputArgument)0.0f, (InputArgument)0, (InputArgument)0, (InputArgument)0, (InputArgument)0.5f, (InputArgument)true, (InputArgument)true, (InputArgument)true);
                                }
                                else
                                {
                                    CigsAndPills.ignitingCig = false;
                                    if (!Common.showHints)
                                        return;
                                    Screen.ShowHelpText("~BLIP_INFO_ICON~ Hold ~" + ((IEnumerable<string>)Enum.GetNames(typeof(Inputs))).ElementAt<string>(24) + "~ a little longer to ignite the cig", 5000);
                                }
                            }
                        }
                    }
                }
                else if (!Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)ped, (InputArgument)"reaction@intimidation@cop@unarmed", (InputArgument)"intro", (InputArgument)3) && !Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)ped, (InputArgument)"amb@world_human_smoking@male@male_a@enter", (InputArgument)"enter", (InputArgument)3))
                {
                    ped.Task.PlayAnimation("amb@world_human_smoking@male@male_a@enter", "enter", 4f, -1, AnimationFlags.UpperBodyOnly | AnimationFlags.Secondary);
                    double num = (double)Function.Call<float>(Hash.SET_ENTITY_ANIM_CURRENT_TIME, (InputArgument)(Entity)ped, (InputArgument)"amb@world_human_smoking@male@male_a@enter", (InputArgument)"enter", (InputArgument)0.4f);
                }
                else
                {
                    if ((double)Function.Call<float>(Hash.GET_ENTITY_ANIM_CURRENT_TIME, (InputArgument)(Entity)ped, (InputArgument)"amb@world_human_smoking@male@male_a@enter", (InputArgument)"enter") <= 0.550000011920929)
                        return;
                    CigsAndPills.clearLighter(ped, Main.GetHashKey("ex_prop_exec_lighter_01"));
                    CigsAndPills.lighter = (Prop)null;
                    CigsAndPills.startSmoke = false;
                    CigsAndPills.cigIgnited = true;
                    CigsAndPills.cigsAndPillsCountDown = false;
                    CigsAndPills.cig_durability = CigsAndPills.max_cig_durability;
                    Common.saveSupplies(ped, "ciggaretes", --CigsAndPills.cigsCount);
                    Function.Call(Hash.STOP_PARTICLE_FX_LOOPED, (InputArgument)CigsAndPills.particalEffect, (InputArgument)true);
                }
            }
        }

        public static void SmokeProceEffectsFunc(Ped ped, int type, Prop _cig)
        {
            Game.Player.ChargeSpecialAbility(0.02f);
            Function.Call(Hash.REQUEST_NAMED_PTFX_ASSET, (InputArgument)"scr_safehouse");
            Function.Call(Hash.USE_PARTICLE_FX_ASSET, (InputArgument)"scr_safehouse");
            Function.Call(Hash.START_PARTICLE_FX_NON_LOOPED_ON_ENTITY, (InputArgument)"scr_sh_cig_exhale_mouth", (InputArgument)(Entity)_cig, (InputArgument)(-0.1f), (InputArgument)0.0f, (InputArgument)0.0f, (InputArgument)(_cig.Rotation.X + 90f), (InputArgument)_cig.Rotation.Y, (InputArgument)_cig.Rotation.Z, (InputArgument)1.0, (InputArgument)false, (InputArgument)false, (InputArgument)false);
            if (type == 1)
            {
                if (Function.Call<bool>(Hash.IS_PED_MALE, (InputArgument)(Entity)ped))
                {
                    if (!Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)ped, (InputArgument)"amb@world_human_smoking@male@male_b@idle_a", (InputArgument)"idle_a", (InputArgument)3))
                        return;
                    if ((double)Function.Call<float>(Hash.GET_ENTITY_ANIM_CURRENT_TIME, (InputArgument)(Entity)ped, (InputArgument)"amb@world_human_smoking@male@male_b@idle_a", (InputArgument)"idle_a") > 0.6)
                    {
                        CigsAndPills.flame = false;
                        int num = Function.Call<int>(Hash.GET_PED_BONE_INDEX, (InputArgument)(Entity)ped, (InputArgument)32679);
                        Vector3 vector3 = Function.Call<Vector3>(Hash.GET_PED_BONE_COORDS, (InputArgument)(Entity)ped, (InputArgument)num, (InputArgument)0, (InputArgument)(-0.1), (InputArgument)0);
                        Function.Call(Hash.REQUEST_NAMED_PTFX_ASSET, (InputArgument)"scr_safehouse");
                        Function.Call(Hash.USE_PARTICLE_FX_ASSET, (InputArgument)"scr_safehouse");
                        Function.Call(Hash.START_PARTICLE_FX_NON_LOOPED_AT_COORD, (InputArgument)"scr_sh_cig_exhale_mouth", (InputArgument)vector3.X, (InputArgument)vector3.Y, (InputArgument)((double)vector3.Z + 0.6), (InputArgument)ped.Rotation.X, (InputArgument)ped.Rotation.Y, (InputArgument)ped.Rotation.Z, (InputArgument)1.7, (InputArgument)false, (InputArgument)false, (InputArgument)false);
                    }
                    else
                    {
                        if ((double)Function.Call<float>(Hash.GET_ENTITY_ANIM_CURRENT_TIME, (InputArgument)(Entity)ped, (InputArgument)"amb@world_human_smoking@male@male_b@idle_a", (InputArgument)"idle_a") >= 0.5 || (double)Function.Call<float>(Hash.GET_ENTITY_ANIM_CURRENT_TIME, (InputArgument)(Entity)ped, (InputArgument)"amb@world_human_smoking@male@male_b@idle_a", (InputArgument)"idle_a") <= 0.1)
                            return;
                        CigsAndPills.flame = true;
                    }
                }
                else
                {
                    if (!Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)ped, (InputArgument)"amb@world_human_smoking@female@idle_a", (InputArgument)"idle_b", (InputArgument)3))
                        return;
                    if ((double)Function.Call<float>(Hash.GET_ENTITY_ANIM_CURRENT_TIME, (InputArgument)(Entity)ped, (InputArgument)"amb@world_human_smoking@female@idle_a", (InputArgument)"idle_b") > 0.85)
                    {
                        CigsAndPills.flame = false;
                        int num = Function.Call<int>(Hash.GET_PED_BONE_INDEX, (InputArgument)(Entity)ped, (InputArgument)32679);
                        Vector3 vector3 = Function.Call<Vector3>(Hash.GET_PED_BONE_COORDS, (InputArgument)(Entity)ped, (InputArgument)num, (InputArgument)0, (InputArgument)(-0.1), (InputArgument)0);
                        Function.Call(Hash.REQUEST_NAMED_PTFX_ASSET, (InputArgument)"scr_safehouse");
                        Function.Call(Hash.USE_PARTICLE_FX_ASSET, (InputArgument)"scr_safehouse");
                        Function.Call(Hash.START_PARTICLE_FX_NON_LOOPED_AT_COORD, (InputArgument)"scr_sh_cig_exhale_mouth", (InputArgument)vector3.X, (InputArgument)vector3.Y, (InputArgument)((double)vector3.Z + 0.6), (InputArgument)ped.Rotation.X, (InputArgument)ped.Rotation.Y, (InputArgument)ped.Rotation.Z, (InputArgument)1.7, (InputArgument)false, (InputArgument)false, (InputArgument)false);
                    }
                    else
                    {
                        if ((double)Function.Call<float>(Hash.GET_ENTITY_ANIM_CURRENT_TIME, (InputArgument)(Entity)ped, (InputArgument)"amb@world_human_smoking@female@idle_a", (InputArgument)"idle_b") <= 0.5 || (double)Function.Call<float>(Hash.GET_ENTITY_ANIM_CURRENT_TIME, (InputArgument)(Entity)ped, (InputArgument)"amb@world_human_smoking@female@idle_a", (InputArgument)"idle_b") >= 0.8)
                            return;
                        CigsAndPills.flame = true;
                    }
                }
            }
            else
            {
                Function.Call(Hash.REQUEST_NAMED_PTFX_ASSET, (InputArgument)"scr_safehouse");
                Function.Call(Hash.USE_PARTICLE_FX_ASSET, (InputArgument)"scr_safehouse");
                Function.Call(Hash.START_PARTICLE_FX_NON_LOOPED_ON_ENTITY, (InputArgument)"scr_sh_cig_exhale_mouth", (InputArgument)(Entity)_cig, (InputArgument)(-0.1f), (InputArgument)0.0f, (InputArgument)0.0f, (InputArgument)(_cig.Rotation.X + 90f), (InputArgument)_cig.Rotation.Y, (InputArgument)_cig.Rotation.Z, (InputArgument)0.5, (InputArgument)false, (InputArgument)false, (InputArgument)false);
                int num = Function.Call<int>(Hash.GET_PED_BONE_INDEX, (InputArgument)(Entity)ped, (InputArgument)32679);
                Vector3 vector3 = Function.Call<Vector3>(Hash.GET_PED_BONE_COORDS, (InputArgument)(Entity)ped, (InputArgument)num, (InputArgument)0, (InputArgument)(-0.1), (InputArgument)0);
                Function.Call(Hash.REQUEST_NAMED_PTFX_ASSET, (InputArgument)"scr_safehouse");
                Function.Call(Hash.USE_PARTICLE_FX_ASSET, (InputArgument)"scr_safehouse");
                if (!Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)ped, (InputArgument)"amb@code_human_in_car_mp_actions@first_person@smoke@std@ds@base", (InputArgument)"idle_a", (InputArgument)3))
                    return;
                if ((double)Function.Call<float>(Hash.GET_ENTITY_ANIM_CURRENT_TIME, (InputArgument)(Entity)ped, (InputArgument)"amb@code_human_in_car_mp_actions@first_person@smoke@std@ds@base", (InputArgument)"idle_a") < 0.5)
                {
                    CigsAndPills.flame = false;
                    Function.Call(Hash.START_PARTICLE_FX_NON_LOOPED_AT_COORD, (InputArgument)"scr_sh_cig_exhale_mouth", (InputArgument)vector3.X, (InputArgument)vector3.Y, (InputArgument)((double)vector3.Z + 0.5), (InputArgument)ped.Rotation.X, (InputArgument)ped.Rotation.Y, (InputArgument)ped.Rotation.Z, (InputArgument)1.7, (InputArgument)false, (InputArgument)false, (InputArgument)false);
                }
                else
                    CigsAndPills.flame = true;
            }
        }

        public static void SmokeLoopFunc(Ped ped, int type)
        {
            CigsAndPills.smoking = true;
            if (type == 1)
            {
                string animDict = "amb@world_human_smoking@male@male_b@idle_a";
                string animName = "idle_a";
                string str1 = "reaction@intimidation@cop@unarmed";
                string str2 = "intro";
                float num1 = 0.01f;
                int num2 = 64017;
                int duration = 8000;
                if (!Function.Call<bool>(Hash.IS_PED_MALE, (InputArgument)(Entity)ped))
                {
                    animDict = "amb@world_human_smoking@female@idle_a";
                    animName = "idle_b";
                    num1 = 0.015f;
                    num2 = 64112;
                    duration = -1;
                }
                if (!Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)ped, (InputArgument)animDict, (InputArgument)animName, (InputArgument)3))
                {
                    if (Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)ped, (InputArgument)str1, (InputArgument)str2, (InputArgument)3))
                        return;
                    ped.Task.PlayAnimation(animDict, animName, 4f, duration, AnimationFlags.UpperBodyOnly | AnimationFlags.Secondary);
                }
                else
                {
                    if (!((Entity)CigsAndPills.cig != (Entity)null) || !CigsAndPills.cig.Exists())
                        return;
                    int num3 = Function.Call<int>(Hash.GET_PED_BONE_INDEX, (InputArgument)(Entity)ped, (InputArgument)num2);
                    if ((double)Function.Call<float>(Hash.GET_ENTITY_ANIM_CURRENT_TIME, (InputArgument)(Entity)ped, (InputArgument)animDict, (InputArgument)animName) <= (double)num1)
                        return;
                    if (Function.Call<bool>(Hash.IS_PED_MALE, (InputArgument)(Entity)ped))
                        Function.Call(Hash.ATTACH_ENTITY_TO_ENTITY, (InputArgument)(Entity)CigsAndPills.cig, (InputArgument)(Entity)ped, (InputArgument)num3, (InputArgument)0.035f, (InputArgument)(-0.005f), (InputArgument)0.02f, (InputArgument)(-35.0), (InputArgument)(-110.0), (InputArgument)(-40.0), (InputArgument)false, (InputArgument)false, (InputArgument)false, (InputArgument)false, (InputArgument)2, (InputArgument)true);
                    else
                        Function.Call(Hash.ATTACH_ENTITY_TO_ENTITY, (InputArgument)(Entity)CigsAndPills.cig, (InputArgument)(Entity)ped, (InputArgument)num3, (InputArgument)0.019, (InputArgument)0.01, (InputArgument)0.021, (InputArgument)(-90.0), (InputArgument)(-90.0), (InputArgument)0.0, (InputArgument)false, (InputArgument)false, (InputArgument)false, (InputArgument)false, (InputArgument)2, (InputArgument)true);
                }
            }
            else
            {
                if (Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)ped, (InputArgument)"amb@code_human_in_car_mp_actions@first_person@smoke@std@ds@base", (InputArgument)"idle_a", (InputArgument)3))
                    return;
                int num = Function.Call<int>(Hash.GET_PED_BONE_INDEX, (InputArgument)(Entity)ped, (InputArgument)64017);
                Function.Call(Hash.ATTACH_ENTITY_TO_ENTITY, (InputArgument)(Entity)CigsAndPills.cig, (InputArgument)(Entity)ped, (InputArgument)num, (InputArgument)0.017, (InputArgument)(-0.01), (InputArgument)0.0, (InputArgument)0.0, (InputArgument)(-120.0), (InputArgument)(-90.0), (InputArgument)false, (InputArgument)false, (InputArgument)false, (InputArgument)false, (InputArgument)2, (InputArgument)true);
                ped.Task.PlayAnimation("amb@code_human_in_car_mp_actions@first_person@smoke@std@ds@base", "idle_a", 1f, -1, AnimationFlags.Loop | AnimationFlags.UpperBodyOnly | AnimationFlags.Secondary);
            }
        }

        public static void PauseSmokeFunc(Ped ped, int type)
        {
            CigsAndPills.flame = false;
            if (type == 1)
            {
                string str1 = "amb@world_human_smoking@male@male_b@idle_a";
                string str2 = "idle_a";
                Vector3 vector3_1 = new Vector3(0.0f, 0.0f, 0.01f);
                Vector3 vector3_2 = new Vector3(55f, 85f, 0.0f);
                Vector3 vector3_3 = new Vector3(1f / 1000f, 0.0f, 0.01f);
                Vector3 vector3_4 = new Vector3(55f, 85f, 0.0f);
                int num1 = 47419;
                int num2 = 47419;
                int num3 = ped.Model.Hash == Main.GetHashKey("PLAYER_ZERO") || ped.Model.Hash == Main.GetHashKey("PLAYER_ONE") ? 0 : (ped.Model.Hash != Main.GetHashKey("PLAYER_TWO") ? 1 : 0);
                if (!Function.Call<bool>(Hash.IS_PED_MALE, (InputArgument)(Entity)ped))
                {
                    str1 = "amb@world_human_smoking@female@idle_a";
                    str2 = "idle_b";
                    vector3_1 = new Vector3(0.0f, 0.0f, 0.01f);
                    vector3_2 = new Vector3(0.0f, 0.0f, 45f);
                    vector3_3 = new Vector3(1f / 1000f, 0.0f, 0.01f);
                    vector3_4 = new Vector3(0.0f, 0.0f, 55f);
                    num1 = 47419;
                    num2 = 47419;
                }
                if (num3 == 0)
                {
                    vector3_1 = new Vector3(0.02f, -0.05f, 0.1f);
                    vector3_2 = new Vector3(30f, 85f, 0.0f);
                    vector3_3 = new Vector3(0.02f, -0.05f, 0.1f);
                    vector3_4 = new Vector3(30f, 85f, 0.0f);
                    num1 = 65068;
                    num2 = 65068;
                }
                if (!Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)ped, (InputArgument)str1, (InputArgument)str2, (InputArgument)3))
                    return;
                if ((double)Function.Call<float>(Hash.GET_ENTITY_ANIM_CURRENT_TIME, (InputArgument)(Entity)ped, (InputArgument)str1, (InputArgument)str2) > 0.6)
                {
                    double num4 = (double)Function.Call<float>(Hash.SET_ENTITY_ANIM_CURRENT_TIME, (InputArgument)(Entity)ped, (InputArgument)str1, (InputArgument)str2, (InputArgument)0.3f);
                    int num5 = Function.Call<int>(Hash.GET_PED_BONE_INDEX, (InputArgument)(Entity)ped, (InputArgument)num1);
                    Function.Call<Vector3>(Hash.GET_PED_BONE_COORDS, (InputArgument)(Entity)ped, (InputArgument)num5, (InputArgument)0, (InputArgument)0, (InputArgument)0);
                    Function.Call(Hash.ATTACH_ENTITY_TO_ENTITY, (InputArgument)(Entity)CigsAndPills.cig, (InputArgument)(Entity)ped, (InputArgument)num5, (InputArgument)vector3_1.X, (InputArgument)vector3_1.Y, (InputArgument)vector3_1.Z, (InputArgument)vector3_2.X, (InputArgument)vector3_2.Y, (InputArgument)vector3_2.Z, (InputArgument)false, (InputArgument)false, (InputArgument)false, (InputArgument)false, (InputArgument)2, (InputArgument)true);
                }
                else if ((double)Function.Call<float>(Hash.GET_ENTITY_ANIM_CURRENT_TIME, (InputArgument)(Entity)ped, (InputArgument)str1, (InputArgument)str2) < 0.5 && (double)Function.Call<float>(Hash.GET_ENTITY_ANIM_CURRENT_TIME, (InputArgument)(Entity)ped, (InputArgument)str1, (InputArgument)str2) > 0.2)
                {
                    double num6 = (double)Function.Call<float>(Hash.SET_ENTITY_ANIM_CURRENT_TIME, (InputArgument)(Entity)ped, (InputArgument)str1, (InputArgument)str2, (InputArgument)0.3f);
                    int num7 = Function.Call<int>(Hash.GET_PED_BONE_INDEX, (InputArgument)(Entity)ped, (InputArgument)num2);
                    Function.Call<Vector3>(Hash.GET_PED_BONE_COORDS, (InputArgument)(Entity)ped, (InputArgument)num7, (InputArgument)0, (InputArgument)0, (InputArgument)0);
                    Function.Call(Hash.ATTACH_ENTITY_TO_ENTITY, (InputArgument)(Entity)CigsAndPills.cig, (InputArgument)(Entity)ped, (InputArgument)num7, (InputArgument)vector3_3.X, (InputArgument)vector3_3.Y, (InputArgument)vector3_3.Z, (InputArgument)vector3_4.X, (InputArgument)vector3_4.Y, (InputArgument)vector3_4.Z, (InputArgument)false, (InputArgument)false, (InputArgument)false, (InputArgument)false, (InputArgument)2, (InputArgument)true);
                }
                Function.Call(Hash.STOP_ENTITY_ANIM, (InputArgument)(Entity)ped, (InputArgument)str2, (InputArgument)str1, (InputArgument)3);
                CigsAndPills.playCigAndSmokeAnim = false;
                CigsAndPills.smoking = false;
            }
            else
            {
                CigsAndPills.flame = false;
                CigsAndPills.smoking = false;
                if (!Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)ped, (InputArgument)"amb@code_human_in_car_mp_actions@first_person@smoke@std@ds@base", (InputArgument)"idle_a", (InputArgument)3))
                    return;
                Function.Call(Hash.STOP_ENTITY_ANIM, (InputArgument)(Entity)ped, (InputArgument)"idle_a", (InputArgument)"amb@code_human_in_car_mp_actions@first_person@smoke@std@ds@base", (InputArgument)3);
                CigsAndPills.playCigAndSmokeAnim = false;
            }
        }

        public static void StopSmokeFunc(Ped ped, int type)
        {
            if (type == 1)
            {
                string str1 = "amb@world_human_smoking@male@male_b@idle_a";
                string str2 = "idle_a";
                string str3 = "reaction@intimidation@cop@unarmed";
                string str4 = "intro";
                string animDict = "amb@world_human_smoking@male@male_a@exit";
                string animName = "exit";
                if (!Function.Call<bool>(Hash.IS_PED_MALE, (InputArgument)(Entity)ped))
                {
                    str1 = "amb@world_human_smoking@female@idle_a";
                    str2 = "idle_b";
                    str3 = "reaction@intimidation@cop@unarmed";
                    str4 = "intro";
                    animDict = "amb@world_human_leaning@female@smoke@exit";
                    animName = "exit";
                }
                if (!((Entity)CigsAndPills.cig != (Entity)null))
                    return;
                Function.Call(Hash.REMOVE_PARTICLE_FX_FROM_ENTITY, (InputArgument)(Entity)CigsAndPills.cig);
                if (Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)ped, (InputArgument)str1, (InputArgument)str2, (InputArgument)3) && (double)Function.Call<float>(Hash.GET_ENTITY_ANIM_CURRENT_TIME, (InputArgument)(Entity)ped, (InputArgument)str1, (InputArgument)str2) >= 0.30000001192092896 && (double)Function.Call<float>(Hash.GET_ENTITY_ANIM_CURRENT_TIME, (InputArgument)(Entity)ped, (InputArgument)str1, (InputArgument)str2) < 0.60000002384185791)
                    Function.Call(Hash.SET_ENTITY_ANIM_CURRENT_TIME, (InputArgument)(Entity)ped, (InputArgument)str1, (InputArgument)str2, (InputArgument)0.6);
                int num = Function.Call<int>(Hash.GET_PED_BONE_INDEX, (InputArgument)(Entity)ped, (InputArgument)64017);
                Function.Call(Hash.ATTACH_ENTITY_TO_ENTITY, (InputArgument)(Entity)CigsAndPills.cig, (InputArgument)(Entity)ped, (InputArgument)num, (InputArgument)0.017, (InputArgument)(-0.01), (InputArgument)0.0, (InputArgument)0.0, (InputArgument)(-120.0), (InputArgument)(-90.0), (InputArgument)false, (InputArgument)false, (InputArgument)false, (InputArgument)false, (InputArgument)2, (InputArgument)true);
                if (Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)ped, (InputArgument)str3, (InputArgument)str4, (InputArgument)3))
                    return;
                if (!Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)ped, (InputArgument)animDict, (InputArgument)animName, (InputArgument)3))
                    ped.Task.PlayAnimation(animDict, animName, 4f, -1, AnimationFlags.StayInEndFrame | AnimationFlags.UpperBodyOnly | AnimationFlags.Secondary | AnimationFlags.AbortOnPedMovement);
                if ((double)Function.Call<float>(Hash.GET_ENTITY_ANIM_CURRENT_TIME, (InputArgument)(Entity)ped, (InputArgument)animDict, (InputArgument)animName) < 0.40000000596046448)
                    return;
                CigsAndPills.cigsAndPillsCountDown = false;
                CigsAndPills.smoke = -1;
                CigsAndPills.startSmoke = true;
                CigsAndPills.flame = false;
                if ((Entity)CigsAndPills.cig != (Entity)null)
                {
                    Function.Call(Hash.DETACH_ENTITY, (InputArgument)(Entity)CigsAndPills.cig, (InputArgument)true, (InputArgument)true);
                    CigsAndPills.cig.MarkAsNoLongerNeeded();
                    CigsAndPills.cig = (Prop)null;
                }
                CigsAndPills.smoking = false;
                CigsAndPills.ignitingCig = false;
                CigsAndPills.readyToIgnite = false;
                CigsAndPills.cigReady = false;
                CigsAndPills.cigIgnited = false;
            }
            else
            {
                if (!((Entity)CigsAndPills.cig != (Entity)null))
                    return;
                Function.Call(Hash.REMOVE_PARTICLE_FX_FROM_ENTITY, (InputArgument)(Entity)CigsAndPills.cig);
                int num = Function.Call<int>(Hash.GET_PED_BONE_INDEX, (InputArgument)(Entity)ped, (InputArgument)64017);
                Function.Call(Hash.ATTACH_ENTITY_TO_ENTITY, (InputArgument)(Entity)CigsAndPills.cig, (InputArgument)(Entity)ped, (InputArgument)num, (InputArgument)0.017, (InputArgument)(-0.01), (InputArgument)0.0, (InputArgument)0.0, (InputArgument)(-120.0), (InputArgument)(-90.0), (InputArgument)false, (InputArgument)false, (InputArgument)false, (InputArgument)false, (InputArgument)2, (InputArgument)true);
                if (!Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)ped, (InputArgument)"amb@code_human_in_car_mp_actions@first_person@smoke@std@ds@base", (InputArgument)"exit", (InputArgument)3))
                {
                    CigsAndPills.cigsAndPillsCountDown = true;
                    CigsAndPills.cigsAndPillsCounter = 1;
                    Function.Call(Hash.TASK_PLAY_ANIM, (InputArgument)(Entity)ped, (InputArgument)"amb@code_human_in_car_mp_actions@first_person@smoke@std@ds@base", (InputArgument)"exit", (InputArgument)3f, (InputArgument)(-3f), (InputArgument)(-1), (InputArgument)48, (InputArgument)0.0f, (InputArgument)0, (InputArgument)0, (InputArgument)0);
                    if (ped.IsSittingInVehicle() && (Entity)ped.CurrentVehicle != (Entity)null && ped.CurrentVehicle.Windows[VehicleWindowIndex.FrontLeftWindow].IsIntact)
                    {
                        ped.CurrentVehicle.Windows[VehicleWindowIndex.FrontLeftWindow].RollDown();
                        Main.soundFX(ped, "window.wav", Common.assetFolder);
                    }
                }
                if (Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)ped, (InputArgument)"amb@code_human_in_car_mp_actions@first_person@smoke@std@ds@base", (InputArgument)"exit", (InputArgument)3) && CigsAndPills.cigsAndPillsCounter <= 1)
                {
                    CigsAndPills.cigsAndPillsCountDown = false;
                    CigsAndPills.smoke = -1;
                    CigsAndPills.startSmoke = true;
                    if ((Entity)CigsAndPills.cig != (Entity)null)
                    {
                        CigsAndPills.cig.Delete();
                        CigsAndPills.cig = (Prop)null;
                    }
                    CigsAndPills.smoking = false;
                    CigsAndPills.ignitingCig = false;
                    CigsAndPills.readyToIgnite = false;
                    CigsAndPills.cigReady = false;
                    CigsAndPills.cigIgnited = false;
                }
                if (!Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)ped, (InputArgument)"amb@code_human_in_car_mp_actions@first_person@smoke@std@ds@base", (InputArgument)"idle_a", (InputArgument)3))
                    return;
                Function.Call(Hash.STOP_ENTITY_ANIM, (InputArgument)(Entity)ped, (InputArgument)"exit", (InputArgument)"amb@code_human_in_car_mp_actions@first_person@smoke@std@ds@base", (InputArgument)3);
            }
        }

        public static Prop createLighter(
          Ped ped,
          Vector3 pos,
          int model,
          bool attach = true,
          bool leftHandAttach = false)
        {
            Prop[] nearbyProps = World.GetNearbyProps(ped.Position, 5f, (Model)model);
            Prop prop;
            if (nearbyProps.Length == 0)
            {
                prop = World.CreateProp((Model)model, pos, true, true);
            }
            else
            {
                prop = nearbyProps[0];
                if (!prop.IsAttachedTo((Entity)ped))
                    prop = World.CreateProp((Model)model, pos, true, true);
            }
            if ((Entity)prop != (Entity)null && attach)
            {
                if (!leftHandAttach)
                {
                    int num = Function.Call<int>(Hash.GET_PED_BONE_INDEX, (InputArgument)(Entity)ped, (InputArgument)64112);
                    Function.Call(Hash.ATTACH_ENTITY_TO_ENTITY, (InputArgument)(Entity)prop, (InputArgument)(Entity)ped, (InputArgument)num, (InputArgument)0.025f, (InputArgument)0.03f, (InputArgument)(-0.015f), (InputArgument)0.0f, (InputArgument)0.0f, (InputArgument)90f, (InputArgument)true, (InputArgument)true, (InputArgument)false, (InputArgument)false, (InputArgument)0, (InputArgument)true);
                }
                else
                {
                    int num = Function.Call<int>(Hash.GET_PED_BONE_INDEX, (InputArgument)(Entity)ped, (InputArgument)4185);
                    Function.Call(Hash.ATTACH_ENTITY_TO_ENTITY, (InputArgument)(Entity)prop, (InputArgument)(Entity)ped, (InputArgument)num, (InputArgument)0.025f, (InputArgument)0.03f, (InputArgument)(-0.015f), (InputArgument)0.0f, (InputArgument)0.0f, (InputArgument)90f, (InputArgument)true, (InputArgument)true, (InputArgument)false, (InputArgument)false, (InputArgument)0, (InputArgument)true);
                }
            }
            return prop;
        }

        public static void clearLighter(Ped ped, int model)
        {
            Prop[] allProps = World.GetAllProps((Model)model);
            if (allProps.Length == 0)
                return;
            foreach (Prop prop in allProps)
            {
                if (prop.IsAttached())
                    prop.Detach();
                prop.MarkAsNoLongerNeeded();
                prop.Delete();
            }
        }

        public static void LighterSoundFX(Ped ped)
        {
            Main.soundFX(ped, "lighter.wav", Common.assetFolder);
            Main.soundFX(ped, "puff.wav", Common.assetFolder);
        }

        public static void stopSmokingFunc(Ped ped)
        {
            if ((Entity)CigsAndPills.cig != (Entity)null)
            {
                if (Function.Call<bool>(Hash.IS_ENTITY_ATTACHED_TO_ENTITY, (InputArgument)(Entity)Function.Call<Prop>(Hash.GET_CLOSEST_OBJECT_OF_TYPE, (InputArgument)ped.Position.X, (InputArgument)ped.Position.Y, (InputArgument)ped.Position.Z, (InputArgument)3f, (InputArgument)Main.GetHashKey(CigsAndPills.smokeType), (InputArgument)true, (InputArgument)false, (InputArgument)false)))
                    Function.Call<Prop>(Hash.GET_CLOSEST_OBJECT_OF_TYPE, (InputArgument)ped.Position.X, (InputArgument)ped.Position.Y, (InputArgument)ped.Position.Z, (InputArgument)3f, (InputArgument)Main.GetHashKey(CigsAndPills.smokeType), (InputArgument)true, (InputArgument)false, (InputArgument)false).Delete();
            }
            else
                CigsAndPills.cig.Delete();
            CigsAndPills.smoke = -1;
            CigsAndPills.startSmoke = true;
            if (CigsAndPills.playCigAndSmokeAnim)
                CigsAndPills.playCigAndSmokeAnim = false;
            CigsAndPills.cig = (Prop)null;
        }

        public static void SwallowPillsFunction(Ped ped)
        {
            string animDict = "friends@frl@ig_1";
            string animName = "drink_lamar";
            if (CigsAndPills.cigsAndPillsCounter > 15)
                return;
            if (!Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)ped, (InputArgument)animDict, (InputArgument)animName, (InputArgument)3))
            {
                if (!CigsAndPills.swallow_in_process)
                {
                    Function.Call(Hash.SET_PED_STEALTH_MOVEMENT, (InputArgument)(Entity)ped, (InputArgument)false, (InputArgument)0);
                    Function.Call(Hash.SET_PED_USING_ACTION_MODE, (InputArgument)(Entity)ped, (InputArgument)false, (InputArgument)0);
                    if (ped.IsInCover)
                        ped.Task.ClearAllImmediately();
                    ped.Task.PlayAnimation(animDict, animName, 32f, 12000, AnimationFlags.UpperBodyOnly | AnimationFlags.Secondary);
                    Function.Call(Hash.SET_ENTITY_ANIM_CURRENT_TIME, (InputArgument)(Entity)ped, (InputArgument)animDict, (InputArgument)animName, (InputArgument)0.15f);
                }
                else if ((double)CigsAndPills.swallo_anim_current_time < 0.85000002384185791)
                {
                    CigsAndPills.play_swallow_pills_anim = false;
                    CigsAndPills.inProcessCigsAndPills = false;
                    CigsAndPills.cigsAndPillsCounter = 0;
                    Prop[] nearbyProps = World.GetNearbyProps(ped.Position, 3f, (Model)Main.GetHashKey("prop_cs_pills"));
                    if (nearbyProps.Length != 0)
                    {
                        foreach (Prop prop in nearbyProps)
                        {
                            if (prop.IsAttachedTo((Entity)ped))
                            {
                                Main.soundFX(ped, "shakeJar.wav", Common.assetFolder);
                                prop.Detach();
                                prop.MarkAsNoLongerNeeded();
                                int pillsCount = CigsAndPills.pillsCount;
                                Function.Call(Hash.SET_TEXT_COLOUR, (InputArgument)(int)byte.MaxValue, (InputArgument)0, (InputArgument)0, (InputArgument)100);
                                Notification.Show("~r~-" + pillsCount.ToString() + "~w~ Painkillers", true);
                                Common.saveSupplies(ped, "painkillers", 0);
                            }
                        }
                    }
                }
            }
            if (!Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)ped, (InputArgument)animDict, (InputArgument)animName, (InputArgument)3))
                return;
            Main.DisableControlsFunc(false);
            CigsAndPills.swallow_in_process = true;
            CigsAndPills.swallo_anim_current_time = Function.Call<float>(Hash.GET_ENTITY_ANIM_CURRENT_TIME, (InputArgument)(Entity)ped, (InputArgument)animDict, (InputArgument)animName);
            if ((double)Function.Call<float>(Hash.GET_ENTITY_ANIM_CURRENT_TIME, (InputArgument)(Entity)ped, (InputArgument)animDict, (InputArgument)animName) < 0.15000000596046448)
                Function.Call(Hash.SET_ENTITY_ANIM_CURRENT_TIME, (InputArgument)(Entity)ped, (InputArgument)animDict, (InputArgument)animName, (InputArgument)0.15f);
            if ((double)Function.Call<float>(Hash.GET_ENTITY_ANIM_CURRENT_TIME, (InputArgument)(Entity)ped, (InputArgument)animDict, (InputArgument)animName) >= 0.18999999761581421 && (double)Function.Call<float>(Hash.GET_ENTITY_ANIM_CURRENT_TIME, (InputArgument)(Entity)ped, (InputArgument)animDict, (InputArgument)animName) < 0.1914999932050705)
            {
                int num = Function.Call<int>(Hash.GET_PED_BONE_INDEX, (InputArgument)(Entity)ped, (InputArgument)4090);
                Function.Call<Vector3>(Hash.GET_PED_BONE_COORDS, (InputArgument)(Entity)ped, (InputArgument)num, (InputArgument)0, (InputArgument)0, (InputArgument)0);
                bool flag = false;
                Prop[] nearbyProps = World.GetNearbyProps(ped.Position, 3f, (Model)Main.GetHashKey("prop_cs_pills"));
                if (nearbyProps.Length != 0)
                {
                    foreach (Prop prop in nearbyProps)
                    {
                        if (prop.IsAttachedTo((Entity)ped))
                        {
                            CigsAndPills.pillsJar = prop;
                            Function.Call(Hash.ATTACH_ENTITY_TO_ENTITY, (InputArgument)(Entity)CigsAndPills.pillsJar, (InputArgument)(Entity)ped, (InputArgument)num, (InputArgument)(-0.01), (InputArgument)(-0.03), (InputArgument)(-0.02), (InputArgument)(-150.0), (InputArgument)40.0, (InputArgument)0.0, (InputArgument)false, (InputArgument)false, (InputArgument)false, (InputArgument)false, (InputArgument)2, (InputArgument)true);
                            flag = true;
                            break;
                        }
                    }
                    if (!flag)
                    {
                        CigsAndPills.pillsJar = World.CreateProp((Model)"prop_cs_pills", ped.Position, true, true);
                        Function.Call(Hash.SET_ENTITY_NO_COLLISION_ENTITY, (InputArgument)(Entity)CigsAndPills.pillsJar, (InputArgument)(Entity)ped, (InputArgument)true);
                        Function.Call(Hash.ATTACH_ENTITY_TO_ENTITY, (InputArgument)(Entity)CigsAndPills.pillsJar, (InputArgument)(Entity)ped, (InputArgument)num, (InputArgument)(-0.01), (InputArgument)(-0.03), (InputArgument)(-0.02), (InputArgument)(-150.0), (InputArgument)40.0, (InputArgument)0.0, (InputArgument)false, (InputArgument)false, (InputArgument)false, (InputArgument)false, (InputArgument)2, (InputArgument)true);
                    }
                }
                else
                {
                    CigsAndPills.pillsJar = World.CreateProp((Model)"prop_cs_pills", ped.Position, true, true);
                    Function.Call(Hash.SET_ENTITY_NO_COLLISION_ENTITY, (InputArgument)(Entity)CigsAndPills.pillsJar, (InputArgument)(Entity)ped, (InputArgument)true);
                    Function.Call(Hash.ATTACH_ENTITY_TO_ENTITY, (InputArgument)(Entity)CigsAndPills.pillsJar, (InputArgument)(Entity)ped, (InputArgument)num, (InputArgument)(-0.01), (InputArgument)(-0.03), (InputArgument)(-0.02), (InputArgument)(-150.0), (InputArgument)40.0, (InputArgument)0.0, (InputArgument)false, (InputArgument)false, (InputArgument)false, (InputArgument)false, (InputArgument)2, (InputArgument)true);
                }
            }
            if ((double)Function.Call<float>(Hash.GET_ENTITY_ANIM_CURRENT_TIME, (InputArgument)(Entity)ped, (InputArgument)animDict, (InputArgument)animName) < 0.18999999761581421)
                return;
            if ((Entity)CigsAndPills.pillsJar != (Entity)null && CigsAndPills.pillsJar.Exists() && CigsAndPills.pillsJar.IsAttachedTo((Entity)ped))
            {
                if ((double)Function.Call<float>(Hash.GET_ENTITY_ANIM_CURRENT_TIME, (InputArgument)(Entity)ped, (InputArgument)animDict, (InputArgument)animName) >= 0.18999999761581421 && (double)Function.Call<float>(Hash.GET_ENTITY_ANIM_CURRENT_TIME, (InputArgument)(Entity)ped, (InputArgument)animDict, (InputArgument)animName) < 0.1914999932050705)
                    Main.soundFX(ped, "shakeJar.wav", Common.assetFolder);
                if ((double)Function.Call<float>(Hash.GET_ENTITY_ANIM_CURRENT_TIME, (InputArgument)(Entity)ped, (InputArgument)animDict, (InputArgument)animName) >= 0.27000001072883606 && (double)Function.Call<float>(Hash.GET_ENTITY_ANIM_CURRENT_TIME, (InputArgument)(Entity)ped, (InputArgument)animDict, (InputArgument)animName) < 0.27129998803138733)
                    Main.soundFX(ped, "openJar.wav", Common.assetFolder);
                if ((double)Function.Call<float>(Hash.GET_ENTITY_ANIM_CURRENT_TIME, (InputArgument)(Entity)ped, (InputArgument)animDict, (InputArgument)animName) >= 0.550000011920929 && (double)Function.Call<float>(Hash.GET_ENTITY_ANIM_CURRENT_TIME, (InputArgument)(Entity)ped, (InputArgument)animDict, (InputArgument)animName) < 0.55150002241134644)
                    Main.soundFX(ped, "swallow.wav", Common.assetFolder);
                if ((double)Function.Call<float>(Hash.GET_ENTITY_ANIM_CURRENT_TIME, (InputArgument)(Entity)ped, (InputArgument)animDict, (InputArgument)animName) >= 0.64999997615814209 && (double)Function.Call<float>(Hash.GET_ENTITY_ANIM_CURRENT_TIME, (InputArgument)(Entity)ped, (InputArgument)animDict, (InputArgument)animName) < 0.65149998664855957)
                    Main.soundFX(ped, "openJar.wav", Common.assetFolder);
                if ((double)Function.Call<float>(Hash.GET_ENTITY_ANIM_CURRENT_TIME, (InputArgument)(Entity)ped, (InputArgument)animDict, (InputArgument)animName) < 0.85)
                    return;
                Main.soundFX(ped, "shakeJar.wav", Common.assetFolder);
                CigsAndPills.inProcessCigsAndPills = false;
                CigsAndPills.cigsAndPillsCounter = 0;
                CigsAndPills.play_swallow_pills_anim = false;
                ped.Task.ClearAll();
                if ((Entity)CigsAndPills.pillsJar != (Entity)null && CigsAndPills.pillsJar.Exists())
                {
                    if (CigsAndPills.pillsCount <= 0)
                    {
                        Function.Call(Hash.DETACH_ENTITY, (InputArgument)(Entity)CigsAndPills.pillsJar, (InputArgument)true, (InputArgument)false);
                        CigsAndPills.pillsJar.MarkAsNoLongerNeeded();
                        CigsAndPills.pillsJar = (Prop)null;
                    }
                    else
                    {
                        CigsAndPills.pillsJar.Delete();
                        CigsAndPills.pillsJar = (Prop)null;
                    }
                }
                Prop[] nearbyProps = World.GetNearbyProps(ped.Position, 3f, (Model)Main.GetHashKey("prop_cs_pills"));
                if (nearbyProps.Length != 0)
                {
                    foreach (PoolObject poolObject in nearbyProps)
                        poolObject.Delete();
                }
                Function.Call(Hash.STOP_CURRENT_PLAYING_AMBIENT_SPEECH, (InputArgument)(Entity)ped);
                Function.Call(Hash.SET_AUDIO_FLAG, (InputArgument)"AllowAmbientSpeechInSlowMo", (InputArgument)true);
                Function.Call(Hash.SET_PED_CAN_PLAY_GESTURE_ANIMS, (InputArgument)(Entity)ped, (InputArgument)false);
                if (!ped.IsInStealthMode)
                    Function.Call(Hash.PLAY_PED_AMBIENT_SPEECH_NATIVE, (InputArgument)(Entity)ped, (InputArgument)"GENERIC_DRINK", (InputArgument)"SPEECH_PARAMS_FORCE_SHOUTED");
                if (!CigsAndPills.extraEffects)
                    ped.Health = ped.MaxHealth;
                int num = Common.rnd.Next(1, 4);
                Common.saveSupplies(ped, "painkillers", CigsAndPills.pillsCount - num);
                CigsAndPills.extraEffectsTimer = CigsAndPills.extraFXDuration;
                CigsAndPills.extraEffectsStat = true;
                CigsAndPills.slowMoScale = 1f;
                Function.Call(Hash.SET_PED_CAN_PLAY_GESTURE_ANIMS, (InputArgument)(Entity)ped, (InputArgument)true);
                Function.Call(Hash.PLAY_SOUND_FRONTEND, (InputArgument)(-1), (InputArgument)"FocusIn", (InputArgument)"HintCamSounds");
                if (!CigsAndPills.extraEffects && CigsAndPills.screenFX && !Screen.IsEffectActive(ScreenEffect.DrugsDrivingIn))
                    Screen.StartEffect(ScreenEffect.DrugsDrivingIn, 150);
                if (CigsAndPills.extraEffects && CigsAndPills.screenFX && !Screen.IsEffectActive(ScreenEffect.FocusIn))
                    Screen.StartEffect(ScreenEffect.FocusIn, 1000);
                CigsAndPills.blockKeys = false;
                Script.Wait(1000);
                if (!CigsAndPills.extraEffects && CigsAndPills.screenFX && !Screen.IsEffectActive(ScreenEffect.DrugsDrivingOut))
                    Screen.StartEffect(ScreenEffect.DrugsDrivingOut, 1000);
                Script.Wait(1000);
                Screen.StopEffects();
            }
            else
            {
                Function.Call(Hash.SET_ENTITY_ANIM_CURRENT_TIME, (InputArgument)(Entity)ped, (InputArgument)animDict, (InputArgument)animName, (InputArgument)0.19f);
                int num = Function.Call<int>(Hash.GET_PED_BONE_INDEX, (InputArgument)(Entity)ped, (InputArgument)4090);
                Function.Call<Vector3>(Hash.GET_PED_BONE_COORDS, (InputArgument)(Entity)ped, (InputArgument)num, (InputArgument)0, (InputArgument)0, (InputArgument)0);
                bool flag = false;
                Prop[] nearbyProps = World.GetNearbyProps(ped.Position, 3f, (Model)Main.GetHashKey("prop_cs_pills"));
                if (nearbyProps.Length != 0)
                {
                    foreach (Prop prop in nearbyProps)
                    {
                        if (prop.IsAttachedTo((Entity)ped))
                        {
                            CigsAndPills.pillsJar = prop;
                            Function.Call(Hash.ATTACH_ENTITY_TO_ENTITY, (InputArgument)(Entity)CigsAndPills.pillsJar, (InputArgument)(Entity)ped, (InputArgument)num, (InputArgument)(-0.01), (InputArgument)(-0.03), (InputArgument)(-0.02), (InputArgument)(-150.0), (InputArgument)40.0, (InputArgument)0.0, (InputArgument)false, (InputArgument)false, (InputArgument)false, (InputArgument)false, (InputArgument)2, (InputArgument)true);
                            flag = true;
                            break;
                        }
                    }
                    if (flag)
                        return;
                    CigsAndPills.pillsJar = World.CreateProp((Model)"prop_cs_pills", ped.Position, true, true);
                    Function.Call(Hash.SET_ENTITY_NO_COLLISION_ENTITY, (InputArgument)(Entity)CigsAndPills.pillsJar, (InputArgument)(Entity)ped, (InputArgument)true);
                    Function.Call(Hash.ATTACH_ENTITY_TO_ENTITY, (InputArgument)(Entity)CigsAndPills.pillsJar, (InputArgument)(Entity)ped, (InputArgument)num, (InputArgument)(-0.01), (InputArgument)(-0.03), (InputArgument)(-0.02), (InputArgument)(-150.0), (InputArgument)40.0, (InputArgument)0.0, (InputArgument)false, (InputArgument)false, (InputArgument)false, (InputArgument)false, (InputArgument)2, (InputArgument)true);
                }
                else
                {
                    CigsAndPills.pillsJar = World.CreateProp((Model)"prop_cs_pills", ped.Position, true, true);
                    Function.Call(Hash.SET_ENTITY_NO_COLLISION_ENTITY, (InputArgument)(Entity)CigsAndPills.pillsJar, (InputArgument)(Entity)ped, (InputArgument)true);
                    Function.Call(Hash.ATTACH_ENTITY_TO_ENTITY, (InputArgument)(Entity)CigsAndPills.pillsJar, (InputArgument)(Entity)ped, (InputArgument)num, (InputArgument)(-0.01), (InputArgument)(-0.03), (InputArgument)(-0.02), (InputArgument)(-150.0), (InputArgument)40.0, (InputArgument)0.0, (InputArgument)false, (InputArgument)false, (InputArgument)false, (InputArgument)false, (InputArgument)2, (InputArgument)true);
                }
            }
        }
    }
}
