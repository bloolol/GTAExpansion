using GTA;
using GTA.Native;
using GTA.UI;


namespace GTAExpansion
{
    public static class FastWardrobe
    {
        public static bool mask_module_active = ScriptSettings.Load("scripts\\Expansion\\Expansion.ini").GetValue<bool>("OUTFIT_COMPONENTS_SETTINGS", "OUTFIT_COMPONENTS_MODULE_ACTIVE", true);
        public static int mask_toggle_btn = ScriptSettings.Load("scripts\\Expansion\\Expansion.ini").GetValue<int>("OUTFIT_COMPONENTS_SETTINGS", "MASK_TOGGLE_BTN", 249);
        public static int gloves_toggle_btn = ScriptSettings.Load("scripts\\Expansion\\Expansion.ini").GetValue<int>("OUTFIT_COMPONENTS_SETTINGS", "GLOVES_TOGGLE_BTN", 249);
        public static int glasses_toggle_btn = ScriptSettings.Load("scripts\\Expansion\\Expansion.ini").GetValue<int>("OUTFIT_COMPONENTS_SETTINGS", "GLASSES_TOGGLE_BTN", 249);
        public static int hat_toggle_btn = ScriptSettings.Load("scripts\\Expansion\\Expansion.ini").GetValue<int>("OUTFIT_COMPONENTS_SETTINGS", "HAT_TOGGLE_BTN", 45);
        public static int maskTimeCounter = 0;

        public static void PropsControlFunc(
          Ped ped,
          string section,
          int type,
          string animDic,
          string animName,
          int animDuration,
          bool hideHairs = false,
          bool hideBeard = false)
        {
            int num1 = Common.config.GetValue<int>(section, "COMPONENTID", 0);
            int num2 = Common.config.GetValue<int>(section, "MODEL", 0);
            int num3 = Common.config.GetValue<int>(section, "TEXTURE", 0);
            ped.Task.PlayAnimation(animDic, animName, 4f, animDuration, AnimationFlags.UpperBodyOnly | AnimationFlags.Secondary);
            if (type == 1)
            {
                if (Function.Call<int>(Hash.GET_PED_DRAWABLE_VARIATION, (InputArgument)(Entity)ped, (InputArgument)num1) != num2 || Function.Call<int>(Hash.GET_PED_TEXTURE_VARIATION, (InputArgument)(Entity)ped, (InputArgument)num1) != num3)
                {
                    if (hideBeard)
                    {
                        int num4 = Function.Call<int>(Hash.GET_PED_DRAWABLE_VARIATION, (InputArgument)(Entity)ped, (InputArgument)1);
                        Function.Call(Hash.SET_PED_COMPONENT_VARIATION, (InputArgument)(Entity)ped, (InputArgument)1, (InputArgument)num4, (InputArgument)1);
                    }
                    if (hideHairs)
                    {
                        int num5 = Function.Call<int>(Hash.GET_PED_DRAWABLE_VARIATION, (InputArgument)(Entity)ped, (InputArgument)2);
                        Function.Call(Hash.SET_PED_COMPONENT_VARIATION, (InputArgument)(Entity)ped, (InputArgument)2, (InputArgument)num5, (InputArgument)1);
                    }
                    if (Function.Call<bool>(Hash.IS_PED_COMPONENT_VARIATION_VALID, (InputArgument)(Entity)ped, (InputArgument)num1, (InputArgument)num2, (InputArgument)num3))
                    {
                        Function.Call(Hash.SET_PED_COMPONENT_VARIATION, (InputArgument)(Entity)ped, (InputArgument)num1, (InputArgument)num2, (InputArgument)num3);
                    }
                    else
                    {
                        Function.Call(Hash.SET_TEXT_COLOUR, (InputArgument)(int)byte.MaxValue, (InputArgument)(int)sbyte.MaxValue, (InputArgument)80, (InputArgument)100);
                        Notification.Show("Invalid Component number", true);
                    }
                }
                else
                {
                    if (hideBeard)
                    {
                        int num6 = Function.Call<int>(Hash.GET_PED_DRAWABLE_VARIATION, (InputArgument)(Entity)ped, (InputArgument)1);
                        Function.Call(Hash.SET_PED_COMPONENT_VARIATION, (InputArgument)(Entity)ped, (InputArgument)1, (InputArgument)num6, (InputArgument)0);
                    }
                    if (hideHairs)
                    {
                        int num7 = Function.Call<int>(Hash.GET_PED_DRAWABLE_VARIATION, (InputArgument)(Entity)ped, (InputArgument)2);
                        Function.Call(Hash.SET_PED_COMPONENT_VARIATION, (InputArgument)(Entity)ped, (InputArgument)2, (InputArgument)num7, (InputArgument)0);
                    }
                    num1 = Common.config.GetValue<int>(section, "OFFCOMPONENTID", 0);
                    num2 = Common.config.GetValue<int>(section, "OFFMODEL", 0);
                    num3 = Common.config.GetValue<int>(section, "OFFTEXTURE", 0);
                    if (Function.Call<bool>(Hash.IS_PED_COMPONENT_VARIATION_VALID, (InputArgument)(Entity)ped, (InputArgument)num1, (InputArgument)num2, (InputArgument)num3))
                    {
                        Function.Call(Hash.SET_PED_COMPONENT_VARIATION, (InputArgument)(Entity)ped, (InputArgument)num1, (InputArgument)num2, (InputArgument)num3);
                    }
                    else
                    {
                        Function.Call(Hash.SET_TEXT_COLOUR, (InputArgument)(int)byte.MaxValue, (InputArgument)(int)sbyte.MaxValue, (InputArgument)80, (InputArgument)100);
                        Notification.Show("Invalid Component number", true);
                    }
                }
            }
            if (type != 2)
                return;
            if (Function.Call<int>(Hash.GET_PED_PROP_INDEX, (InputArgument)(Entity)ped, (InputArgument)num1) != num2)
            {
                if (Function.Call<int>(Hash.GET_PED_PROP_TEXTURE_INDEX, (InputArgument)(Entity)ped, (InputArgument)num1) != num3)
                {
                    try
                    {
                        Function.Call(Hash.SET_PED_PROP_INDEX, (InputArgument)(Entity)ped, (InputArgument)num1, (InputArgument)num2, (InputArgument)num3, (InputArgument)false);
                        return;
                    }
                    catch
                    {
                        Function.Call(Hash.SET_TEXT_COLOUR, (InputArgument)(int)byte.MaxValue, (InputArgument)(int)sbyte.MaxValue, (InputArgument)80, (InputArgument)100);
                        Notification.Show("Invalid Prop number", true);
                        return;
                    }
                }
            }
            Function.Call(Hash.CLEAR_PED_PROP, (InputArgument)(Entity)ped, (InputArgument)num1);
        }
    }
}
