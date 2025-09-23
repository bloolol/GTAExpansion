// Decompiled with JetBrains decompiler
// Type: GTAExpansion.ShoulderCameraSwitch
// Assembly: GTAExpansion, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 57B8053D-C566-4641-A84B-F5EB537251F0
// Assembly location: D:\SteamLibrary\steamapps\common\Grand Theft Auto V\scripts\GTAExpansion.dll

using GTA;
using GTA.Math;
using GTA.Native;
using NAudio.Midi;
using System.Windows.Forms;


namespace GTAExpansion
{
    public static class ShoulderCameraSwitch
    {
        public static bool ShoulderCameraModuleActive = ScriptSettings.Load("scripts\\Expansion\\Expansion.ini").GetValue<bool>("AIM_CAMERA_SWITCH", "AIM_CAMERA_SWITCH_MODE_ACTIVE", true);
        public static int switch_shoulder_camera_btn = ScriptSettings.Load("scripts\\Expansion\\Expansion.ini").GetValue<int>("AIM_CAMERA_SWITCH", "SWITCH_SHOULDER_CAM_BTN", 0);
        public static Camera ShoulderCamera = (Camera)null;
        public static bool ShoulderCameraActive = false;

        public static bool isCustomCamActive = false;
        public static Camera activeCam;
        public static float currentOffset = 0.0f;
        public static float targetOffset = 0.0f;
        public static float transitionSpeed = 0.03f;
        public static bool toggleKeyReleased = true;
        public static float shoulderCamPitch = 0.0f;
        public static float shoulderCamYaw = 0.0f;
        public static float shoulderCamRoll = 0.0f;
       
        public static Keys toggleKey;
        /*
        public static Camera switchShoulderCamera(Ped ped, Camera shoulderLeftCamera)
        {
            if (shoulderLeftCamera == (Camera)null)
            {
                if (GameplayCamera.IsRendering & GameplayCamera.GetCamViewModeForContext(CamViewModeContext.OnFoot) != CamViewMode.FirstPerson)
                {
                    shoulderLeftCamera = World.CreateCamera(GameplayCamera.Position, Vector3.Zero, GameplayCamera.FieldOfView);
                    World.RenderingCamera = shoulderLeftCamera;

                    if (Crouch.crouched)
                    {
                        shoulderLeftCamera.AttachTo((Entity)ped, new Vector3(-0.40f, -1.45f, 0.38f));
                    }
                    else
                        shoulderLeftCamera.AttachTo((Entity)ped, new Vector3(-0.40f, -1.45f, 0.71f));
                }
            }
            else if (GameplayCamera.IsRendering && World.RenderingCamera != shoulderLeftCamera)
                World.RenderingCamera = shoulderLeftCamera;
            return shoulderLeftCamera;
        }
        */
        public static void TransitionCamera(Ped player)
        {
            if ((double)currentOffset < (double)targetOffset)
            {
                currentOffset += transitionSpeed;
                if ((double)currentOffset > (double)targetOffset)
                    currentOffset = targetOffset;
            }
            else if ((double)currentOffset > (double)targetOffset)
            {
                currentOffset -= transitionSpeed;
                if ((double)currentOffset < (double)targetOffset)
                    currentOffset = targetOffset;
            }
            Vector3 vector3_1 = Function.Call<Vector3>(Hash.GET_GAMEPLAY_CAM_COORD);
            Vector3 vector3_2 = Function.Call<Vector3>(Hash.GET_GAMEPLAY_CAM_ROT, (InputArgument)2);
            float fov = Function.Call<float>(Hash.GET_GAMEPLAY_CAM_FOV);
            Vector3 vector3_3 = player.RightVector * currentOffset;
            Vector3 position = vector3_1 + vector3_3;
            Vector3 rotation = vector3_2 + new Vector3(shoulderCamPitch, shoulderCamYaw, shoulderCamRoll);
            if (activeCam == (Camera)null || !activeCam.Exists())
                activeCam = World.CreateCamera(position, rotation, fov);
            if (activeCam != (Camera)null && activeCam.Exists())
            {
                activeCam.Position = position;
                activeCam.Rotation = rotation;
                activeCam.FieldOfView = fov;
                Function.Call(Hash.SET_CAM_ACTIVE, (InputArgument)activeCam, (InputArgument)true);
                Function.Call(Hash.RENDER_SCRIPT_CAMS, (InputArgument)true, (InputArgument)false, (InputArgument)0, (InputArgument)true, (InputArgument)false);
            }
            if ((double)currentOffset != 0.0 || !(activeCam != (Camera)null))
                return;
            DisableCustomCamera();
        }

        public static void TransitionCameraCrouch(Ped player)
        {
            if ((double)currentOffset < (double)targetOffset)
            {
                currentOffset += transitionSpeed;
                if ((double)currentOffset > (double)targetOffset)
                    currentOffset = targetOffset;
            }
            else if ((double)currentOffset > (double)targetOffset)
            {
                currentOffset -= transitionSpeed;
                if ((double)currentOffset < (double)targetOffset)
                    currentOffset = targetOffset;
            }
            Vector3 vector3_1 = Function.Call<Vector3>(Hash.GET_GAMEPLAY_CAM_COORD);
            Vector3 vector3_2 = Function.Call<Vector3>(Hash.GET_GAMEPLAY_CAM_ROT, (InputArgument)2);
            float fov = Function.Call<float>(Hash.GET_GAMEPLAY_CAM_FOV);
            Vector3 vector3_3 = player.UpVector * currentOffset;
            Vector3 position = vector3_1 + vector3_3;
            Vector3 rotation = vector3_2 + new Vector3(shoulderCamPitch, shoulderCamYaw, shoulderCamRoll);
            if (activeCam == (Camera)null || !activeCam.Exists())
                activeCam = World.CreateCamera(position, rotation, fov);
            if (activeCam != (Camera)null && activeCam.Exists())
            {
                activeCam.Position = position;
                activeCam.Rotation = rotation;
                activeCam.FieldOfView = fov;
                Function.Call(Hash.SET_CAM_ACTIVE, (InputArgument)activeCam, (InputArgument)true);
                Function.Call(Hash.RENDER_SCRIPT_CAMS, (InputArgument)true, (InputArgument)false, (InputArgument)0, (InputArgument)true, (InputArgument)false);
            }
            if ((double)currentOffset != 0.0 || !(activeCam != (Camera)null))
                return;
            DisableCustomCamera();
        }

        public static void DisableCustomCamera()
        {
            if (activeCam != (Camera)null && activeCam.Exists())
            {
                activeCam.Delete();
                activeCam = (Camera)null;
            }
            Function.Call(Hash.RENDER_SCRIPT_CAMS, (InputArgument)false, (InputArgument)false, (InputArgument)0, (InputArgument)true, (InputArgument)false);
            currentOffset = 0.0f;
        }
        /*
        public static float fCameraPositionX()
        {
            float num = 0.0f;
            switch (Function.Call<int>(Hash.GET_FOLLOW_PED_CAM_VIEW_MODE))
            {
                case 0:
                    return PeekingMod.Main.PeekingPosition == 1 ? 0.31f : -0.31f;
                case 1:
                    return PeekingMod.Main.PeekingPosition == 1 ? 0.45f : -0.45f;
                case 2:
                    return PeekingMod.Main.PeekingPosition == 1 ? 0.55f : -0.55f;
                case 4:
                    return PeekingMod.Main.PeekingPosition == 1 ? 0.19f : -0.19f;
                default:
                    return num;
            }
        }
        */
        /*
        public static float fCameraRotationY()
        {
            float num = 0.0f;
            switch (Function.Call<int>(Hash.GET_FOLLOW_PED_CAM_VIEW_MODE))
            {
                case 0:
                    return PeekingMod.Main.PeekingPosition == 1 ? 10f : -10f;
                case 1:
                    return PeekingMod.Main.PeekingPosition == 1 ? 10f : -10f;
                case 2:
                    return PeekingMod.Main.PeekingPosition == 1 ? 10f : -10f;
                case 4:
                    return PeekingMod.Main.PeekingPosition == 1 ? 10f : -10f;
                default:
                    return num;
            }
        }
        */
    }
}
