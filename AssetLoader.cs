using GTA;
using GTA.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTAExpansion
{
    public static class AssetLoader
    {
        private static readonly HashSet<string> loadedAnimDicts = new HashSet<string>();
        private static readonly HashSet<string> loadedClipSets = new HashSet<string>();
        private static readonly HashSet<int> loadedModels = new HashSet<int>();

        public static void RequestAnimDict(string dict)
        {
            if (loadedAnimDicts.Contains(dict)) return;

            Function.Call(Hash.REQUEST_ANIM_DICT, dict);
            int start = Game.GameTime;
            while (!Function.Call<bool>(Hash.HAS_ANIM_DICT_LOADED, dict))
            {
                Script.Yield();
                if (Game.GameTime - start > 3000) break;
            }

            loadedAnimDicts.Add(dict);
        }

        public static void RequestClipSet(string clip)
        {
            if (loadedClipSets.Contains(clip)) return;

            Function.Call(Hash.REQUEST_CLIP_SET, clip);
            int start = Game.GameTime;
            while (!Function.Call<bool>(Hash.HAS_CLIP_SET_LOADED, clip))
            {
                Script.Yield();
                if (Game.GameTime - start > 3000) break;
            }

            loadedClipSets.Add(clip);
        }

        public static void RequestModel(string modelName)
        {
            int hash = Function.Call<int>(Hash.GET_HASH_KEY, modelName);
            if (loadedModels.Contains(hash)) return;

            Function.Call(Hash.REQUEST_MODEL, hash);
            int start = Game.GameTime;
            while (!Function.Call<bool>(Hash.HAS_MODEL_LOADED, hash))
            {
                Script.Yield();
                if (Game.GameTime - start > 3000) break;
            }

            loadedModels.Add(hash);
        }

        public static void LoadAllAssetsOnce()
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
        }
    }
}