// Decompiled with JetBrains decompiler
// Type: GTAExpansion.Crouch
// Assembly: GTAExpansion, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 57B8053D-C566-4641-A84B-F5EB537251F0
// Assembly location: D:\SteamLibrary\steamapps\common\Grand Theft Auto V\scripts\GTAExpansion.dll

using GTA;
using System.Diagnostics;
using GTA.Native;
using GTA.Math;

    



namespace GTAExpansion
{
    internal class Crouch
    {
         public static bool CrouchModeActive = ScriptSettings.Load("scripts\\Expansion\\Expansion.ini").GetValue<bool>("CROUCH", "CROUCH_MODE_ACTIVE", true);
         public static bool crouched = false;
         public static Stopwatch crouchBtnPressTimer = new Stopwatch();
        

        /*
        bool isPlayerCrouching = false;
        bool GetIsPlayerCrouching() { return isPlayerCrouching; }
        bool CanCrouch(Ped ped)
        {
            if (!DOES_ENTITY_EXIST(ped) || IS_ENTITY_DEAD(ped, false) || IS_PED_DEAD_OR_DYING(ped, true) ||
                IS_PED_INJURED(ped) || IS_PED_USING_ANY_SCENARIO(ped) || IS_PED_RAGDOLL(ped) ||
                IS_PED_GETTING_UP(ped) || IS_PED_FALLING(ped) || IS_PED_JUMPING(ped) ||
                IS_PED_DIVING(ped) || IS_PED_SWIMMING(ped) || IS_PED_GOING_INTO_COVER(ped) ||
                IS_PED_CLIMBING(ped) || IS_PED_VAULTING(ped) || IS_PED_HANGING_ON_TO_VEHICLE(ped) ||
                IS_PED_IN_ANY_VEHICLE(ped, true) || IS_PED_IN_COVER(ped, false) || !IS_PED_ON_FOOT(ped) ||
                IS_PED_TAKING_OFF_HELMET(ped) || GET_ENTITY_SUBMERGED_LEVEL(ped) >= 0.7f || IS_PED_PERFORMING_MELEE_ACTION(ped))
                return false;

            return true;
        }

        void SetCrouch(Ped ped, bool state)
        {
            if (state)
            {
                DisablePedConfigFlag(ped, PCF_OpenDoorArmIK);
                EnablePedConfigFlag(ped, PCF_PhoneDisableTextingAnimations);
                EnablePedConfigFlag(ped, PCF_PhoneDisableTalkingAnimations);
                EnablePedConfigFlag(ped, PCF_PhoneDisableCameraAnimations);

                isPlayerCrouching = true;
                SET_PED_MOVEMENT_CLIPSET(ped, crouchedMovementClipSet, blendSpeedCrouched);
                SET_PED_STRAFE_CLIPSET(ped, crouchedStrafingClipSet);
            }
            else
            {
                isPlayerCrouching = false;
                SET_PED_STEALTH_MOVEMENT(ped, false, NULL);
                RESET_PED_MOVEMENT_CLIPSET(ped, blendSpeedCrouched);
                RESET_PED_STRAFE_CLIPSET(ped);
                EnablePedConfigFlag(ped, PCF_OpenDoorArmIK);
                DisablePedConfigFlag(ped, PCF_PhoneDisableTextingAnimations);
                DisablePedConfigFlag(ped, PCF_PhoneDisableTalkingAnimations);
                DisablePedConfigFlag(ped, PCF_PhoneDisableCameraAnimations);
                SET_PED_CAN_PLAY_GESTURE_ANIMS(ped, true);
                SET_PED_CAN_PLAY_AMBIENT_ANIMS(ped, true);
                SET_PED_CAN_PLAY_AMBIENT_BASE_ANIMS(ped, true);
                SET_PLAYER_NOISE_MULTIPLIER(GetPlayer(), 1.0f);
            }
            return;
        }

        Timer timerCrouch;
        constexpr int crouchHold = 250;
        bool stealthState = false;
        void EnableCrouching()
        {
            if (!RequestClipSet(crouchedMovementClipSet) || !RequestClipSet(crouchedStrafingClipSet))
                return;

            if (!IS_PED_HUMAN(GetPlayerPed()))
                return;

            if (IS_CONTROL_JUST_PRESSED(PLAYER_CONTROL, INPUT_DUCK))
            {
                if (isPlayerCrouching)
                    SetCrouch(GetPlayerPed(), false);
                else
                {
                    timerCrouch.Reset();
                    if (GET_PED_STEALTH_MOVEMENT(GetPlayerPed()))
                    {
                        stealthState = true;
                        SET_PED_STEALTH_MOVEMENT(GetPlayerPed(), false, NULL);  // Fixes bug when crouching near objects where the player would not be able to stand up
                    }
                }
            }
            else if (IS_CONTROL_JUST_RELEASED(PLAYER_CONTROL, INPUT_DUCK) && Between(timerCrouch.Get(), 0, crouchHold) && stealthState)
            {
                stealthState = false;
                // Enable stealth mode if control is released early and ensure compatibility with non-story peds
                if (IsPedMainProtagonist(GetPlayerPed()))
                    SET_PED_STEALTH_MOVEMENT(GetPlayerPed(), true, NULL);
                else if (Ini::EnablePlayerActionsForAllPeds)
                    SET_PED_STEALTH_MOVEMENT(GetPlayerPed(), true, "DEFAULT_ACTION");
            }
            else if (IS_CONTROL_PRESSED(PLAYER_CONTROL, INPUT_DUCK) && timerCrouch.Get() > crouchHold)
            {
                timerCrouch.Set(INT_MIN);
                if (!isPlayerCrouching && CanCrouch(GetPlayerPed()))
                    SetCrouch(GetPlayerPed(), true);
            }

            if (isPlayerCrouching)
            {
                if (!CanCrouch(GetPlayerPed()))
                    SetCrouch(GetPlayerPed(), false);
                else
                {
                    EnablePedResetFlag(GetPlayerPed(), PRF_DisableActionMode);
                    EnablePedResetFlag(GetPlayerPed(), PRF_DontUseSprintEnergy);
                    EnablePedResetFlag(GetPlayerPed(), PRF_ScriptDisableSecondaryAnimationTasks);
                    EnablePedResetFlag(GetPlayerPed(), PRF_DisableDustOffAnims);
                    EnablePedResetFlag(GetPlayerPed(), PRF_DisableWallHitAnimation);

                    SET_PED_CAN_PLAY_AMBIENT_IDLES(GetPlayerPed(), true, true); // Resets every frame
                    SET_PED_CAN_PLAY_GESTURE_ANIMS(GetPlayerPed(), false);
                    SET_PED_CAN_PLAY_AMBIENT_ANIMS(GetPlayerPed(), false);
                    SET_PED_CAN_PLAY_AMBIENT_BASE_ANIMS(GetPlayerPed(), false);

                    SET_PLAYER_NOISE_MULTIPLIER(GetPlayer(), 0.0f);
                    DISABLE_ON_FOOT_FIRST_PERSON_VIEW_THIS_UPDATE();

                    if (IsPlayerAiming(true, true) || IS_CONTROL_PRESSED(PLAYER_CONTROL, INPUT_ATTACK) || IS_CONTROL_PRESSED(PLAYER_CONTROL, INPUT_ATTACK2))
                        SET_PED_MAX_MOVE_BLEND_RATIO(GetPlayerPed(), 0.25f);
                    else
                        SET_PED_MAX_MOVE_BLEND_RATIO(GetPlayerPed(), PEDMOVEBLENDRATIO_RUN);
                }
            }

            // Ensure action compatibility with non-story peds. THIS MUST BE AT THE BOTTOM
            if (Ini::EnablePlayerActionsForAllPeds && !IsPedMainProtagonist(GetPlayerPed()) && !GetIsPlayerCrouching())
            {
                if (!GET_PED_STEALTH_MOVEMENT(GetPlayerPed()) && !stealthState)
                {
                    if (IS_PED_IN_MELEE_COMBAT(GetPlayerPed()) || COUNT_PEDS_IN_COMBAT_WITH_TARGET(GetPlayerPed()) > 0 || IS_PED_SHOOTING(GetPlayerPed()))
                        SET_PED_USING_ACTION_MODE(GetPlayerPed(), true, 10000, "DEFAULT_ACTION");
                }
            }
            return;
        }
        */
    }
}
