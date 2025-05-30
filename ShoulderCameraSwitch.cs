// Decompiled with JetBrains decompiler
// Type: GTAExpansion.ShoulderCameraSwitch
// Assembly: GTAExpansion, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 57B8053D-C566-4641-A84B-F5EB537251F0
// Assembly location: D:\SteamLibrary\steamapps\common\Grand Theft Auto V\scripts\GTAExpansion.dll

using GTA;
using GTA.Math;


namespace GTAExpansion
{
    public static class ShoulderCameraSwitch
    {
        public static bool ShoulderCameraModuleActive = ScriptSettings.Load("scripts\\Expansion\\Expansion.ini").GetValue<bool>("AIM_CAMERA_SWITCH", "AIM_CAMERA_SWITCH_MODE_ACTIVE", true);
        public static int switch_shoulder_camera_btn = ScriptSettings.Load("scripts\\Expansion\\Expansion.ini").GetValue<int>("AIM_CAMERA_SWITCH", "SWITCH_SHOULDER_CAM_BTN", 0);
        public static Camera ShoulderCamera = (Camera)null;
        public static bool ShoulderCameraActive = false;


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

    }
}
