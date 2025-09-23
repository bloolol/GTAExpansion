// Decompiled with JetBrains decompiler
// Type: GTAExpansion.Common
// Assembly: GTAExpansion, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 57B8053D-C566-4641-A84B-F5EB537251F0
// Assembly location: D:\SteamLibrary\steamapps\common\Grand Theft Auto V\scripts\GTAExpansion.dll

using GTA;
using GTA.Math;
using GTA.Native;
using GTA.UI;
using HTools;
using HTools.hphone;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;

namespace GTAExpansion
{
    public static class Common
    {
        public static string assetFolder = "Expansion/";
        public static ScriptSettings config = ScriptSettings.Load("scripts\\Expansion\\Expansion.ini");
        public static bool showHints = ScriptSettings.Load("scripts\\Expansion\\Expansion.ini").GetValue<bool>("SETTINGS", "HINT_TOGGLE", true);
        public static int main_menu_btn_on_foot = ScriptSettings.Load("scripts\\Expansion\\Expansion.ini").GetValue<int>("SETTINGS", "MAIN_MENU_BTN_ON_FOOT", 37);
        public static int main_menu_btn_in_vehicle = ScriptSettings.Load("scripts\\Expansion\\Expansion.ini").GetValue<int>("SETTINGS", "MAIN_MENU_BTN_IN_VEHICLE", 73);
        public static int main_menu_sec_btn = ScriptSettings.Load("scripts\\Expansion\\Expansion.ini").GetValue<int>("SETTINGS", "MAIN_MENU_SEC_BTN", 45);
        public static int exit_menu_btn = ScriptSettings.Load("scripts\\Expansion\\Expansion.ini").GetValue<int>("SETTINGS", "CLOSE_MAIN_MENU_BTN", 37);
        public static int next_menu_btn = ScriptSettings.Load("scripts\\Expansion\\Expansion.ini").GetValue<int>("SETTINGS", "NEXT_MAIN_MENU_BTN", 0);
        public static XDocument doc = XDocument.Load("scripts\\Expansion\\WeaponStash.xml");
        public static int cur_action_page = 0;
        public static int max_action_page = 4;
        public static int main_menu_btn = 36;
        public static bool inMainMenu = false;
        public static int GameTimeRef = 0;
        public static bool loaded = false;
        public static bool MaskIsOn = false;
        public static bool followCamera = false;
        public static Camera follow_camera = (Camera)null;
        public static int followCameraTimer = 0;
        public static Entity CamObject;
        public static int camTimer = 0;
        public static bool buyTools = false;
        public static bool buyBag = false;
        public static bool buyHolster = false;
        public static bool buySupplies = false;
        public static int sellerAvailableItems = 0;
        public static System.Random rnd = new System.Random();
        public static int trans_timer = 0;
        public static Camera trans_cam;
        public static bool trans_in_process;
        public static float trans_cam_x;
        public static float trans_cam_y;
        public static bool trans_completed = false;
        public static Ped curPlayer = Game.Player.Character;
        public static Model[] allWeaponModels = Weapon.GetAllModels();
        public static int purchaseType = 0;
        public static int purchaseSum = 0;
        public static bool purchaseProcess = false;
        public static List<Vector3> Store_Locations = new List<Vector3>();
        public static bool showBlips = ScriptSettings.Load("scripts\\Expansion\\Expansion.ini").GetValue<bool>("SETTUBGS", "SHOP_STORE_BLIPS", true);
        public static int actionTimer = 0;
        public static bool pedIsNearShopkeeper = false;
        public static bool pedIsNearGunDealer = false;
        public static Ped _shopKeeper = (Ped)null;
        public static Ped _GunDealer = (Ped)null;
        public static bool come_over_mode = false;
        public static bool greeting = false;
        public static bool greetingFinished = false;
        public static bool deal = false;
        public static bool payed = false;
        public static Ped seller;
        public static Ped Driver;
        public static Vehicle Taxi;
        public static BlipSprite sellerBlip = BlipSprite.ShootingRange;
        public static int TotalPrice = 0;
        public static int timeOut = 0;
        public static bool findSellerOption = false;
        public static int sellerDialogCounter = 6;
        public static bool stuckTimerActive = false;
        public static int stuckTimer = 0;
        public static int hours_to_advance = 0;
        public static bool canceled = false;
        public static bool inProcessBag = false;
        public static bool trash_cleared = false;
        public static WeaponHash[] allWeaponHashes = (WeaponHash[])Enum.GetValues(typeof(WeaponHash));
        public static Prop[] AuxillaryProps = new Prop[2];
        public static WeaponComponentHash[] allComponentsHashes = (WeaponComponentHash[])Enum.GetValues(typeof(WeaponComponentHash));
        public static WeaponTint[] allTintHashes = (WeaponTint[])Enum.GetValues(typeof(WeaponTint));
        public static PedHash[] allPedHashes = (PedHash[])Enum.GetValues(typeof(PedHash));
        private static InstructionBtn btn1 = new InstructionBtn("");
        private static InstructionBtn btn2 = new InstructionBtn("");
        private static InstructionBtn btn3 = new InstructionBtn("");
        private static InstructionBtn btn4 = new InstructionBtn("");
        private static InstructionBtn btn5 = new InstructionBtn("");
        private static InstructionBtn btn6 = new InstructionBtn("");
        private static InstructionBtn btn7 = new InstructionBtn("");
        private static InstructionBtn btn8 = new InstructionBtn("");
        private static InstructionBtn btn9 = new InstructionBtn("");
        private static InstructionBtn[] common_btns = new InstructionBtn[9]
        {
      Common.btn1,
      Common.btn2,
      Common.btn3,
      Common.btn4,
      Common.btn5,
      Common.btn6,
      Common.btn7,
      Common.btn8,
      Common.btn9
        };
        public static HPhoneApp IFruit = new HPhoneApp();
        public static HPhoneContact callContact;
        
        public static bool IsAnimPlay(this Ped ped, string animDict, string animName)
        {
            return Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)ped, (InputArgument)animDict, (InputArgument)animName, (InputArgument)3);
        }
        public static void ContactAnsweredDate(HPhoneContact contact)
        {
            Main.soundFX(Game.Player.Character, "beep.wav", Common.assetFolder);
            Common.update_inventory_status(Game.Player.Character);
            if (Common.deal && !Common.payed)
            {
                if (!((Entity)Common.seller != (Entity)null) || (double)Common.seller.Position.DistanceTo(Game.Player.Character.Position) >= 15.0 || Common.payed)
                    return;
                Common.payed = true;
            }
            else
                Common.findSellerOption = true;
        }

        public static void update_inventory_status(Ped ped)
        {
            InventoryBag.cur_bag = InventoryBag.bagModelReturn(ped);
            InventoryBag.hasBag = InventoryBag.doesPedWearingBag(ped);
            WeaponHolster.hasHolster = WeaponHolster.doesPedHasHolster(ped);
            InventoryBag.isBagBought = InventoryBag.doesPedHasInventoryBag(ped);
            InventoryBag.isBagDropped = InventoryBag.DoesDroppedBagExist(ped);
        }

        public static bool isOccupied(Ped ped)
        {
            return Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)ped, (InputArgument)"missmic2@meat_hook", (InputArgument)"michael_meat_hook_fall", (InputArgument)3) || Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)ped, (InputArgument)"missmic2@meat_hook", (InputArgument)"michael_meat_hook_idle", (InputArgument)3) || Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)ped, (InputArgument)"missmic2@meat_hook", (InputArgument)"michael_meat_hook_react_a", (InputArgument)3) || Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)ped, (InputArgument)"missmic2@meat_hook", (InputArgument)"michael_meat_hook_react_b", (InputArgument)3) || Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)ped, (InputArgument)"missmic2@meat_hook", (InputArgument)"michael_meat_hook_react_c", (InputArgument)3) || Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)ped, (InputArgument)"missmic2@meat_hook", (InputArgument)"michael_meat_hook_react_d", (InputArgument)3) || Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)ped, (InputArgument)"amb@world_human_smoking@male@male_b@idle_a", (InputArgument)"idle_a", (InputArgument)3) || Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)ped, (InputArgument)"amb@world_human_smoking@male@male_a@enter", (InputArgument)"enter", (InputArgument)3) || Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)ped, (InputArgument)"amb@world_human_smoking@male@male_a@exit", (InputArgument)"exit", (InputArgument)3) || Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)ped, (InputArgument)"reaction@intimidation@cop@unarmed", (InputArgument)"intro", (InputArgument)3) || Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)ped, (InputArgument)"reaction@intimidation@cop@unarmed", (InputArgument)"outro", (InputArgument)3) || Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)ped, (InputArgument)"reaction@intimidation@cop@unarmed", (InputArgument)"intro", (InputArgument)3) || Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)ped, (InputArgument)"reaction@intimidation@cop@unarmed", (InputArgument)"outro", (InputArgument)3) || Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)ped, (InputArgument)"move_m@intimidation@cop@unarmed", (InputArgument)"idle", (InputArgument)3) || Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)ped, (InputArgument)"mp_arrest_paired", (InputArgument)"cop_p1_rf_right_0", (InputArgument)3) || Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)ped, (InputArgument)"skydive@parachute@", (InputArgument)"chute_off", (InputArgument)3) || Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)ped, (InputArgument)"move_action@p_m_one@holster", (InputArgument)"1h_holster_unarmed", (InputArgument)3) || Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)ped, (InputArgument)"anim@heists@money_grab@briefcase", (InputArgument)"enter", (InputArgument)3) || Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)ped, (InputArgument)"anim@heists@money_grab@briefcase", (InputArgument)"exit", (InputArgument)3) || Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)ped, (InputArgument)"anim@scripted@heist@ig1_table_grab@gold@male@", (InputArgument)"enter", (InputArgument)3) || Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)ped, (InputArgument)"move_action@p_m_zero@holster", (InputArgument)"2h_melee_holster_2h_melee", (InputArgument)3) || Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)ped, (InputArgument)"cover@weapon@2h", (InputArgument)"blindfire_low_r_aim_low_edge", (InputArgument)3) || Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)ped, (InputArgument)"weapon@w_sp_jerrycan", (InputArgument)"unholster", (InputArgument)3) || Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)ped, (InputArgument)"veh@driveby@first_person@driver@1h", (InputArgument)"outro_90l", (InputArgument)3) || Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)ped, (InputArgument)"veh@driveby@first_person@driver@1h", (InputArgument)"outro_0", (InputArgument)3) || Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)ped, (InputArgument)"cellphone@in_car@low@ds", (InputArgument)"cellphone_text_out", (InputArgument)3) || Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)ped, (InputArgument)"amb@code_human_in_car_mp_actions@first_person@smoke@std@ds@base", (InputArgument)"idle_a", (InputArgument)3) || Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)ped, (InputArgument)"veh@driveby@first_person@passenger_left_handed@1h", (InputArgument)"outro_0", (InputArgument)3) || Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)ped, (InputArgument)"anim@veh@bike@police@front@base", (InputArgument)"horn_outro", (InputArgument)3) || Main.is_playing_any_guitar_anim(ped);
        }

        public static bool allowActionPerform(Ped ped, int time)
        {
            --Common.actionTimer;
            if (Common.actionTimer > 0)
                return false;
            Common.actionTimer = time;
            return true;
        }

        // Weapon capacity   
        public static int AllWeaponsCount(Ped ped)
        {
            int num = 0;
            foreach (AllWeapons allWeapons in Enum.GetValues(typeof(AllWeapons)))
            {
                if (Function.Call<bool>(Hash.HAS_PED_GOT_WEAPON, new InputArgument[3]
                {
        (InputArgument) ped.Handle,
        (InputArgument) allWeapons.GetHashCode(),
        (InputArgument) false
                }))
                    ++num;
            }
            return num;
        }

        public static int bigWeaponsCount(Ped ped)
        {
            int num = 0;
            foreach (BigWeapons bigWeapons in Enum.GetValues(typeof(BigWeapons)))
            {
                if (Function.Call<bool>(Hash.HAS_PED_GOT_WEAPON, new InputArgument[3]
                {
        (InputArgument) ped.Handle,
        (InputArgument) bigWeapons.GetHashCode(),
        (InputArgument) false
                }))
                    ++num;
            }
            return num;

        }

        public static int smallWeaponsCount(Ped ped)
        {
            int num = 0;
            foreach (SmallWeapons smallWeapons in Enum.GetValues(typeof(SmallWeapons)))
            {
                if (Function.Call<bool>(Hash.HAS_PED_GOT_WEAPON, new InputArgument[3]
                {
        (InputArgument) ped.Handle,
        (InputArgument) smallWeapons.GetHashCode(),
        (InputArgument) false
                }))
                    ++num;
            }
            return num;

        }

        public static int ExplosivesCount(Ped ped)
        {
            int num = 0;
            foreach (Explosives explosives in Enum.GetValues(typeof(Explosives)))
            {
                if (Function.Call<bool>(Hash.HAS_PED_GOT_WEAPON, new InputArgument[3]
                {
        (InputArgument) ped.Handle,
        (InputArgument) explosives.GetHashCode(),
        (InputArgument) false
                }))
                    ++num;
            }
            return num;

        }

        public static int BigMeleeCount(Ped ped)
        {
            int num = 0;
            foreach (BigMelee bigMelee in Enum.GetValues(typeof(BigMelee)))
            {
                if (Function.Call<bool>(Hash.HAS_PED_GOT_WEAPON, new InputArgument[3]
                {
        (InputArgument) ped.Handle,
        (InputArgument) bigMelee.GetHashCode(),
        (InputArgument) false
                }))
                    ++num;
            }
            return num;

        }



        private enum BigWeapons : uint
        {
            SniperRifle = 100416529, // 0x05FC3C11
            CompactLauncher = 125959754, // 0x0781FE4A
            CombatPDW = 171789620, // 0x0A3D4D34
            HeavySniperMKII = 177293209, // 0x0A914799
            HeavySniper = 205991906, // 0x0C472FE2
            SweeperShotgun = 317205821, // 0x12E82D3D
            MicroSMG = 324215364, // 0x13532244
            PumpShotgun = 487013001, // 0x1D073A89
            SMG = 736523883, // 0x2BE6766B
            AssaultRifleMKII = 961495388, // 0x394F415C
            HeavyShotgun = 984333226, // 0x3AABBBAA
            Minigun = 1119849093, // 0x42BF8A85
            RayCarbine = 1198256469, // 0x476BF155
            GrenadeLauncherSmoke = 1305664598, // 0x4DD2DC56
            PumpShotgunMKII = 1432025498, // 0x555AF99A
            Gusenberg = 1627465347, // 0x61012683
            CompactRifle = 1649403952, // 0x624FE830
            HomingLauncher = 1672152130, // 0x63AB0442
            MarksManRifleMKII = 1785463520, // 0x6A6C02E0
            Railgun = 1834241177, // 0x6D544C99
            SawnOffShotgun = 2017895192, // 0x7846A318
            SmgMKII = 2024373456, // 0x78A97CD0
            BullpupRifle = 2132975508, // 0x7F229F94
            Firework = 2138347493, // 0x7F7497E5
            CombatMG = 2144741730, // 0x7FD62962
            CarbineRifle = 2210333304, // 0x83BF0278
            BullupRifleMKII = 2228681469, // 0x84D6FAFD
            SpecialCarbineMKII = 2526821735, // 0x969C3D67
            MG = 2634544996, // 0x9D07F764
            BullpupShotgun = 2640438543, // 0x9D61E50F
            GrenadeLauncher = 2726580491, // 0xA284510B
            Musket = 2828843422, // 0xA89CB99E
            AdvancedRifle = 2937143193, // 0xAF113F99
            RPG = 2982836145, // 0xB1CA77B1
            WidowMaker = 3056410471, // 0xB62D1F67
            MiniSMG = 3173288789, // 0xBD248B55
            AssaultRifle = 3220176749, // 0xBFEFFF6D
            SpecialCarbine = 3231910285, // 0xC0A3098D
            MarksmanRifle = 3342088282, // 0xC734385A
            CombatMGMKII = 3686625920, // 0xDBBD7280
            AssaultShotgun = 3800352039, // 0xE284C527
            DoubleBarrelShotgun = 4019527611, // 0xEF951FBB
            AssaultSMG = 4024951519, // 0xEFE7E2DF
            CarbineRifleMKII = 4208062921, // 0xFAD1F1C9
            Hatchet = 4191993645,
            TacticalSmg = 0x14E5AFD5,
            TacticalRifle = 0xD1D5F52B,
            MilitaryRifle = 3249783761,
            CandyCane = 0x6589186A,
            PrecisionRifle = 0x6E7DDDEC,
            HeavyRifle = 0xC78D71B4,
            BattleRifle = 0x72B66B11,
        }

        private enum Explosives : uint
        {
            Cocktail = 615608432, // 0x24B17070
            StickyBomb = 741814745, // 0x2C3731D9
            Grenade = 2481070269, // 0x93E220BD
            BZ = 2694266206, // 0xA0973D5E
            ProximityMine = 2874559379, // 0xAB564B93
            PipeBomb = 3125143736, // 0xBA45E8B8
            TearGas = 4256991824, // 0xFDBC8A50
        }

        private enum BigMelee : uint
        {
            PipeWrench = 419712736, // 0x19044EE0
            StoneHatchet = 940833800, // 0x3813FC08
            GolfClub = 1141786504, // 0x440E4788
            Hammer = 1317494643, // 0x4E875F73
            NightStick = 1737195953, // 0x678B81B1
            CrowBar = 2227010557, // 0x84BD7BFD
            PoolCue = 2484171525, // 0x94117305
            Bat = 2508868239, // 0x958A4A8F
            BattleAxe = 3441901897, // 0xCD274149
            Machete = 3713923289, // 0xDD5DF8D9
            Hatchet = 4191993645, // 0xF9DCBF2D
        }
        private enum SmallWeapons : uint
        {
            VintagePistol = 137902532, // 0x083839C4
            Pistol = 453432689, // 0x1B06D571
            APPistol = 584646201, // 0x22D8FE39
                                  // JerryCan = 883325847 0x34A67B97
            StunGun = 911657153, // 0x3656C8C1
            FlareGun = 1198879012, // 0x47757124
            CombatPistol = 1593441988, // 0x5EF9FEC4
            SnsPistolMKII = 2285322324, // 0x88374054
            DoubleActionRevolver = 2548703416, // 0x97EA20B8
            Pistol50 = 2578377531, // 0x99AEEB3B
            RayPistol = 2939590305, // 0xAF3696A1
            SNSPistol = 3218215474, // 0xBFD21232
            PistolMKII = 3219281620, // 0xBFE256D4
            Revolver = 0xC1B3C3D1, // 0xC1B3C3D1
            HeavyRevolverMKII = 3415619887, // 0xCB96392F
            HeavyPistol = 3523564046, // 0xD205520E
            MachinePistol = 3675956304, // 0xDB1AA450
            MarksmanPistol = 3696079510, // 0xDC4DB296
            PericoPistol = 0x57A4368C,
            CeramicPistol = 0x2B5EF5EC,
            NavyRevolver = 0x917F6C8C,
        }

        private enum AllWeapons : uint
        {
            SniperRifle = 100416529, // 0x05FC3C11
            CompactLauncher = 125959754, // 0x0781FE4A
            VintagePistol = 137902532, // 0x083839C4
            CombatPDW = 171789620, // 0x0A3D4D34
            HeavySniperMKII = 177293209, // 0x0A914799
            HeavySniper = 205991906, // 0x0C472FE2
            SweeperShotgun = 317205821, // 0x12E82D3D
            MicroSMG = 324215364, // 0x13532244
            PipeWrench = 419712736, // 0x19044EE0
            Pistol = 453432689, // 0x1B06D571
            PumpShotgun = 487013001, // 0x1D073A89
            APPistol = 584646201, // 0x22D8FE39
            Cocktail = 615608432, // 0x24B17070
            SMG = 736523883, // 0x2BE6766B
            StickyBomb = 741814745, // 0x2C3731D9
            JerryCan = 883325847, // 0x34A67B97
            StunGun = 911657153, // 0x3656C8C1
            StoneHatchet = 940833800, // 0x3813FC08
            AssaultRifleMKII = 961495388, // 0x394F415C
            HeavyShotgun = 984333226, // 0x3AABBBAA
            Minigun = 1119849093, // 0x42BF8A85
            GolfClub = 1141786504, // 0x440E4788
            RayCarbine = 1198256469, // 0x476BF155
            FlareGun = 1198879012, // 0x47757124
            GrenadeLauncherSmoke = 1305664598, // 0x4DD2DC56
            Hammer = 1317494643, // 0x4E875F73
            PumpShotgunMKII = 1432025498, // 0x555AF99A
            CombatPistol = 1593441988, // 0x5EF9FEC4
            Gusenberg = 1627465347, // 0x61012683
            CompactRifle = 1649403952, // 0x624FE830
            HomingLauncher = 1672152130, // 0x63AB0442
            NightStick = 1737195953, // 0x678B81B1
            MarksManRifleMKII = 1785463520, // 0x6A6C02E0
            Railgun = 1834241177, // 0x6D544C99
            SawnOffShotgun = 2017895192, // 0x7846A318
            SmgMKII = 2024373456, // 0x78A97CD0
            BullpupRifle = 2132975508, // 0x7F229F94
            Firework = 2138347493, // 0x7F7497E5
            CombatMG = 2144741730, // 0x7FD62962
            CarbineRifle = 2210333304, // 0x83BF0278
            CrowBar = 2227010557, // 0x84BD7BFD
            BullupRifleMKII = 2228681469, // 0x84D6FAFD
            SnsPistolMKII = 2285322324, // 0x88374054
            Grenade = 2481070269, // 0x93E220BD
            PoolCue = 2484171525, // 0x94117305
            Bat = 2508868239, // 0x958A4A8F
            SpecialCarbineMKII = 2526821735, // 0x969C3D67
            DoubleActionRevolver = 2548703416, // 0x97EA20B8
            Pistol50 = 2578377531, // 0x99AEEB3B
            MG = 2634544996, // 0x9D07F764
            BullpupShotgun = 2640438543, // 0x9D61E50F
            BZ = 2694266206, // 0xA0973D5E
            GrenadeLauncher = 2726580491, // 0xA284510B
            Musket = 2828843422, // 0xA89CB99E
            ProximityMine = 2874559379, // 0xAB564B93
            AdvancedRifle = 2937143193, // 0xAF113F99
            RayPistol = 2939590305, // 0xAF3696A1
            RPG = 2982836145, // 0xB1CA77B1
            WidowMaker = 3056410471, // 0xB62D1F67
            PipeBomb = 3125143736, // 0xBA45E8B8
            MiniSMG = 3173288789, // 0xBD248B55
            SNSPistol = 3218215474, // 0xBFD21232
            PistolMKII = 3219281620, // 0xBFE256D4
            AssaultRifle = 3220176749, // 0xBFEFFF6D
            SpecialCarbine = 3231910285, // 0xC0A3098D
            Revolver = 0xC1B3C3D1, // 0xC1B3C3D1
            MarksmanRifle = 3342088282, // 0xC734385A
            HeavyRevolverMKII = 3415619887, // 0xCB96392F
            BattleAxe = 3441901897, // 0xCD274149
            HeavyPistol = 3523564046, // 0xD205520E
            MachinePistol = 3675956304, // 0xDB1AA450
            CombatMGMKII = 3686625920, // 0xDBBD7280
            MarksmanPistol = 3696079510, // 0xDC4DB296
            Machete = 3713923289, // 0xDD5DF8D9
            AssaultShotgun = 3800352039, // 0xE284C527
            DoubleBarrelShotgun = 4019527611, // 0xEF951FBB
            AssaultSMG = 4024951519, // 0xEFE7E2DF
            Hatchet = 4191993645, // 0xF9DCBF2D
            CarbineRifleMKII = 4208062921, // 0xFAD1F1C9
            TearGas = 4256991824, // 0xFDBC8A50
            CeramicPistol = 0x2B5EF5EC,
            NavyRevolver = 0x917F6C8C,
            TacticalSmg = 0x14E5AFD5,
            TacticalRifle = 3520460075,
            MilitaryRifle = 0x9D1F17E6,
            PericoPistol = 0x57A4368C,
            CandyCane = 0x6589186A,
            PrecisionRifle = 0x6E7DDDEC,
            HeavyRifle = 0xC78D71B4,
            BattleRifle = 0x72B66B11,

        }

        //





        public static void followCameraCreateFunc(Ped ped, Entity follow_object)
        {
            ++Common.camTimer;
            if (Common.camTimer >= 150)
            {
                Common.camTimer = 0;
                Common.followCamera = false;
            }
            if (!Game.Player.Character.IsSittingInVehicle())
            {
                if (Function.Call<int>(Hash.GET_FOLLOW_PED_CAM_VIEW_MODE) != 4)
                {
                    if (Common.follow_camera == (Camera)null)
                    {
                        Common.follow_camera = World.CreateCamera(GameplayCamera.Position, Vector3.Zero, GameplayCamera.FieldOfView);
                        World.RenderingCamera = Common.follow_camera;
                        if (!(follow_object != (Entity)null) || !follow_object.Exists())
                            return;
                        Common.follow_camera.PointAt(follow_object);
                    }
                    else
                    {
                        if (World.RenderingCamera != Common.follow_camera)
                            World.RenderingCamera = Common.follow_camera;
                        if (follow_object != (Entity)null && follow_object.Exists())
                            Common.follow_camera.PointAt(follow_object);
                        Common.follow_camera.Position = GameplayCamera.Position;
                        Common.follow_camera.Rotation = GameplayCamera.Rotation;
                        if (Common.followCameraTimer >= 300 || Common.followCameraTimer >= 100)
                            return;
                        ++Common.followCameraTimer;
                        if ((double)Common.follow_camera.FieldOfView <= (double)GameplayCamera.FieldOfView - 3.0)
                            return;
                        Common.follow_camera.FieldOfView -= 0.1f;
                    }
                }
                else
                {
                    if (!(Common.follow_camera != (Camera)null) || !Common.follow_camera.Exists())
                        return;
                    if (World.RenderingCamera == Common.follow_camera)
                        World.RenderingCamera = (Camera)null;
                    Common.follow_camera.Delete();
                    Common.follow_camera = (Camera)null;
                }
            }
            else if (Common.follow_camera == (Camera)null)
            {
                Common.follow_camera = World.CreateCamera(GameplayCamera.Position, Vector3.Zero, GameplayCamera.FieldOfView);
                World.RenderingCamera = Common.follow_camera;
                if (!(follow_object != (Entity)null) || !follow_object.Exists())
                    return;
                Common.follow_camera.PointAt(follow_object);
            }
            else
            {
                if (World.RenderingCamera != Common.follow_camera)
                    World.RenderingCamera = Common.follow_camera;
                if (follow_object != (Entity)null && follow_object.Exists())
                    Common.follow_camera.PointAt(follow_object);
                Common.follow_camera.Position = GameplayCamera.Position;
                Common.follow_camera.Rotation = GameplayCamera.Rotation;
                if (Common.followCameraTimer >= 300 || Common.followCameraTimer >= 100)
                    return;
                ++Common.followCameraTimer;
                if ((double)Common.follow_camera.FieldOfView <= (double)GameplayCamera.FieldOfView - 3.0)
                    return;
                Common.follow_camera.FieldOfView -= 0.1f;
            }
        }

        public static void followCameraDeleteFunc(Ped ped, Entity follow_obje)
        {
            if (!(Common.follow_camera != (Camera)null) || !Common.follow_camera.Exists())
                return;
            Common.follow_camera.Position = GameplayCamera.Position;
            Common.follow_camera.Rotation = GameplayCamera.Rotation;
            if (Common.followCameraTimer > 0)
            {
                --Common.followCameraTimer;
                if ((double)Common.follow_camera.FieldOfView != (double)GameplayCamera.FieldOfView)
                {
                    if ((double)Common.follow_camera.FieldOfView > (double)GameplayCamera.FieldOfView)
                        Common.follow_camera.FieldOfView -= 0.1f;
                    else
                        Common.follow_camera.FieldOfView += 0.1f;
                }
                else
                {
                    if (World.RenderingCamera == Common.follow_camera)
                        World.RenderingCamera = (Camera)null;
                    Common.follow_camera.Delete();
                    Common.follow_camera = (Camera)null;
                }
            }
            else
            {
                if (World.RenderingCamera == Common.follow_camera)
                    World.RenderingCamera = (Camera)null;
                Common.follow_camera.Delete();
                Common.follow_camera = (Camera)null;
            }
        }

        public static bool camera_transition(
          Vector3 cam_position,
          Vector3 cam_rotation,
          int hours_to_advance,
          bool fadeScreenIn,
          Weather weather,
          bool cantControlCharacter,
          bool AdvanceAtDayTime)
        {
            if (!Common.trans_in_process)
            {
                if (cantControlCharacter)
                    Game.Player.CanControlCharacter = false;
                Common.trans_completed = false;
                if (Common.trans_timer <= 0)
                    Common.trans_in_process = true;
                else if (Common.trans_cam == (Camera)null)
                {
                    Common.trans_cam = World.CreateCamera(cam_position, cam_rotation, GameplayCamera.FieldOfView);
                    Common.trans_cam_x = 0.0f;
                    Common.trans_cam_y = 0.0f;
                }
                else if (World.RenderingCamera != Common.trans_cam)
                {
                    World.RenderingCamera = Common.trans_cam;
                    Common.trans_cam_x = 0.0f;
                    Common.trans_cam_y = 0.0f;
                    Common.trans_cam.Rotation = new Vector3(0.0f, 0.0f, 0.0f);
                }
                else
                {
                    --Common.trans_timer;
                    if (Function.Call<int>(Hash.GET_CLOCK_HOURS) != hours_to_advance)
                        Function.Call(Hash.ADD_TO_CLOCK_TIME, (InputArgument)0, (InputArgument)1, (InputArgument)0);
                    if ((double)Common.trans_cam.Rotation.Y < 90.0)
                    {
                        Common.trans_cam_x += 0.1f;
                        Common.trans_cam.Rotation = new Vector3(Common.trans_cam_x, Common.trans_cam_y, 0.0f);
                    }
                    else if ((double)Common.trans_cam.Rotation.Y > 90.0)
                    {
                        Common.trans_cam_x -= 0.1f;
                        Common.trans_cam.Rotation = new Vector3(Common.trans_cam_x, Common.trans_cam_y, 0.0f);
                    }
                }
            }
            else if (!AdvanceAtDayTime && Function.Call<int>(Hash.GET_CLOCK_HOURS) != hours_to_advance || AdvanceAtDayTime && (Function.Call<int>(Hash.GET_CLOCK_HOURS) > hours_to_advance + 3 || Function.Call<int>(Hash.GET_CLOCK_HOURS) < hours_to_advance - 3))
            {
                Function.Call(Hash.ADD_TO_CLOCK_TIME, (InputArgument)0, (InputArgument)3, (InputArgument)0);
            }
            else
            {
                if (Screen.IsFadedIn)
                    Screen.FadeOut(2000);
                if (Screen.IsFadedOut)
                {
                    World.DestroyAllCameras();
                    World.RenderingCamera = (Camera)null;
                    Common.trans_cam = (Camera)null;
                    Common.trans_in_process = false;
                    Common.trans_completed = true;
                    if (fadeScreenIn)
                        Screen.FadeIn(3000);
                    World.TransitionToWeather(weather, 1f);
                    World.Weather = weather;
                    if (cantControlCharacter)
                        Game.Player.CanControlCharacter = true;
                    return true;
                }
            }
            return false;
        }

        public static void checkMask(Ped ped)
        {
            if (ped.Model.Hash == Main.GetHashKey("PLAYER_ZERO"))
            {
                if (Function.Call<int>(Hash.GET_PED_DRAWABLE_VARIATION, (InputArgument)(Entity)ped, (InputArgument)8) == 7 || Function.Call<int>(Hash.GET_PED_DRAWABLE_VARIATION, (InputArgument)(Entity)ped, (InputArgument)8) == 9 || Function.Call<int>(Hash.GET_PED_DRAWABLE_VARIATION, (InputArgument)(Entity)ped, (InputArgument)8) == 14 || Function.Call<int>(Hash.GET_PED_DRAWABLE_VARIATION, (InputArgument)(Entity)ped, (InputArgument)8) == 21 || Function.Call<int>(Hash.GET_PED_DRAWABLE_VARIATION, (InputArgument)(Entity)ped, (InputArgument)8) == 23 || Function.Call<int>(Hash.GET_PED_DRAWABLE_VARIATION, (InputArgument)(Entity)ped, (InputArgument)9) == 8 || Function.Call<int>(Hash.GET_PED_PROP_INDEX, (InputArgument)(Entity)ped, (InputArgument)0) == 2 || Function.Call<int>(Hash.GET_PED_PROP_INDEX, (InputArgument)(Entity)ped, (InputArgument)0) == 14 || Function.Call<int>(Hash.GET_PED_PROP_INDEX, (InputArgument)(Entity)ped, (InputArgument)0) == 15 || Function.Call<int>(Hash.GET_PED_PROP_INDEX, (InputArgument)(Entity)ped, (InputArgument)0) == 16 || Function.Call<int>(Hash.GET_PED_PROP_INDEX, (InputArgument)(Entity)ped, (InputArgument)0) == 17 || Function.Call<int>(Hash.GET_PED_PROP_INDEX, (InputArgument)(Entity)ped, (InputArgument)0) == 18 || Function.Call<int>(Hash.GET_PED_PROP_INDEX, (InputArgument)(Entity)ped, (InputArgument)0) == 19 || Function.Call<int>(Hash.GET_PED_PROP_INDEX, (InputArgument)(Entity)ped, (InputArgument)0) == 20 || Function.Call<int>(Hash.GET_PED_PROP_INDEX, (InputArgument)(Entity)ped, (InputArgument)0) == 23 || Function.Call<int>(Hash.GET_PED_PROP_INDEX, (InputArgument)(Entity)ped, (InputArgument)0) == 25)
                {
                    Common.MaskIsOn = true;
                    if (CigsAndPills.smoke != -1 && CigsAndPills.smoke != 0)
                        CigsAndPills.stopSmokingFunc(ped);
                }
                else
                    Common.MaskIsOn = false;
            }
            if (ped.Model.Hash == Main.GetHashKey("PLAYER_ONE"))
            {
                if (Function.Call<int>(Hash.GET_PED_DRAWABLE_VARIATION, (InputArgument)(Entity)ped, (InputArgument)8) == 4 || Function.Call<int>(Hash.GET_PED_DRAWABLE_VARIATION, (InputArgument)(Entity)ped, (InputArgument)8) == 5 || Function.Call<int>(Hash.GET_PED_DRAWABLE_VARIATION, (InputArgument)(Entity)ped, (InputArgument)8) == 8 || Function.Call<int>(Hash.GET_PED_DRAWABLE_VARIATION, (InputArgument)(Entity)ped, (InputArgument)8) == 9 || Function.Call<int>(Hash.GET_PED_DRAWABLE_VARIATION, (InputArgument)(Entity)ped, (InputArgument)8) == 18 || Function.Call<int>(Hash.GET_PED_DRAWABLE_VARIATION, (InputArgument)(Entity)ped, (InputArgument)9) == 4 || Function.Call<int>(Hash.GET_PED_DRAWABLE_VARIATION, (InputArgument)(Entity)ped, (InputArgument)2) == 5 || Function.Call<int>(Hash.GET_PED_PROP_INDEX, (InputArgument)(Entity)ped, (InputArgument)0) == 1 || Function.Call<int>(Hash.GET_PED_PROP_INDEX, (InputArgument)(Entity)ped, (InputArgument)0) == 6 || Function.Call<int>(Hash.GET_PED_PROP_INDEX, (InputArgument)(Entity)ped, (InputArgument)0) == 8 || Function.Call<int>(Hash.GET_PED_PROP_INDEX, (InputArgument)(Entity)ped, (InputArgument)0) == 9 || Function.Call<int>(Hash.GET_PED_PROP_INDEX, (InputArgument)(Entity)ped, (InputArgument)0) == 10 || Function.Call<int>(Hash.GET_PED_PROP_INDEX, (InputArgument)(Entity)ped, (InputArgument)0) == 13 || Function.Call<int>(Hash.GET_PED_PROP_INDEX, (InputArgument)(Entity)ped, (InputArgument)0) == 14)
                {
                    Common.MaskIsOn = true;
                    if (CigsAndPills.smoke != -1 && CigsAndPills.smoke != 0)
                        CigsAndPills.stopSmokingFunc(ped);
                }
                else
                    Common.MaskIsOn = false;
            }
            if (ped.Model.Hash != Main.GetHashKey("PLAYER_TWO"))
                return;
            if (Function.Call<int>(Hash.GET_PED_DRAWABLE_VARIATION, (InputArgument)(Entity)ped, (InputArgument)8) == 1 || Function.Call<int>(Hash.GET_PED_DRAWABLE_VARIATION, (InputArgument)(Entity)ped, (InputArgument)8) == 6 || Function.Call<int>(Hash.GET_PED_DRAWABLE_VARIATION, (InputArgument)(Entity)ped, (InputArgument)8) == 10 || Function.Call<int>(Hash.GET_PED_DRAWABLE_VARIATION, (InputArgument)(Entity)ped, (InputArgument)8) == 13 || Function.Call<int>(Hash.GET_PED_DRAWABLE_VARIATION, (InputArgument)(Entity)ped, (InputArgument)8) == 15 || Function.Call<int>(Hash.GET_PED_DRAWABLE_VARIATION, (InputArgument)(Entity)ped, (InputArgument)9) == 5 || Function.Call<int>(Hash.GET_PED_DRAWABLE_VARIATION, (InputArgument)(Entity)ped, (InputArgument)9) == 6 || Function.Call<int>(Hash.GET_PED_DRAWABLE_VARIATION, (InputArgument)(Entity)ped, (InputArgument)9) == 7 || Function.Call<int>(Hash.GET_PED_PROP_INDEX, (InputArgument)(Entity)ped, (InputArgument)0) == 2 || Function.Call<int>(Hash.GET_PED_PROP_INDEX, (InputArgument)(Entity)ped, (InputArgument)0) == 14 || Function.Call<int>(Hash.GET_PED_PROP_INDEX, (InputArgument)(Entity)ped, (InputArgument)0) == 15 || Function.Call<int>(Hash.GET_PED_PROP_INDEX, (InputArgument)(Entity)ped, (InputArgument)0) == 16 || Function.Call<int>(Hash.GET_PED_PROP_INDEX, (InputArgument)(Entity)ped, (InputArgument)0) == 17 || Function.Call<int>(Hash.GET_PED_PROP_INDEX, (InputArgument)(Entity)ped, (InputArgument)0) == 18 || Function.Call<int>(Hash.GET_PED_PROP_INDEX, (InputArgument)(Entity)ped, (InputArgument)0) == 19 || Function.Call<int>(Hash.GET_PED_PROP_INDEX, (InputArgument)(Entity)ped, (InputArgument)0) == 20 || Function.Call<int>(Hash.GET_PED_PROP_INDEX, (InputArgument)(Entity)ped, (InputArgument)0) == 23 || Function.Call<int>(Hash.GET_PED_PROP_INDEX, (InputArgument)(Entity)ped, (InputArgument)0) == 25)
            {
                Common.MaskIsOn = true;
                if (CigsAndPills.smoke == -1 || CigsAndPills.smoke == 0)
                    return;
                CigsAndPills.stopSmokingFunc(ped);
            }
            else
                Common.MaskIsOn = false;
        }

        public static void AnimPlayFunc(
          Ped ped,
          float actionPoint,
          float stopPoint,
          string animDict,
          string animName,
          float animSpeed,
          int animFlags,
          Action Action)
        {
            if (!Function.Call<bool>(Hash.IS_ENTITY_PLAYING_ANIM, (InputArgument)(Entity)ped, (InputArgument)animDict, (InputArgument)animName, (InputArgument)3))
            {
                if (animFlags == 1)
                    ped.Task.PlayAnimation(animDict, animName, animSpeed, -1, AnimationFlags.UpperBodyOnly | AnimationFlags.Secondary);
                if (animFlags == 2)
                    ped.Task.PlayAnimation(animDict, animName, animSpeed, -1, AnimationFlags.StayInEndFrame | AnimationFlags.UpperBodyOnly | AnimationFlags.Secondary);
                if (animFlags == 3)
                    ped.Task.PlayAnimation(animDict, animName, animSpeed, -1, AnimationFlags.Secondary);
                if ((double)Function.Call<float>(Hash.GET_ENTITY_ANIM_CURRENT_TIME, (InputArgument)(Entity)ped, (InputArgument)animDict, (InputArgument)animName) != (double)actionPoint)
                    return;
                Action();
            }
            else
            {
                if ((double)Function.Call<float>(Hash.GET_ENTITY_ANIM_CURRENT_TIME, (InputArgument)(Entity)ped, (InputArgument)animDict, (InputArgument)animName) <= (double)stopPoint)
                    return;
                Function.Call(Hash.STOP_ENTITY_ANIM, (InputArgument)(Entity)ped, (InputArgument)animName, (InputArgument)animDict, (InputArgument)3f);
            }
        }

        public static void Draw(
          int mode,
          bool hasBag = false,
          bool bagInCar = false,
          bool hasHolster = false,
          bool isBagBought = false,
          bool bagIsDropped = false,
          bool weaponIsJammedParam = false,
          bool canClean = false,
          bool isCleaningWeapon = false,
          bool cleaningRequiredParam = false,
          int action_page = 0,
          bool cameraModuleParam = true,
          bool swingWeaponModuleParam = true,
          bool laserSightModuleParam = true,
          bool canSwingWeaponParam = false,
          bool canUseLaserSightParam = false,
          bool weaponJamningModuleParam = true,
          bool silencerModeActiveParam = false,
          bool aimingStyleModeActiveParam = true,
          bool readyToIgnite = false,
          bool canSwitchAimingStyleParam = false)
        {
            InstructionBtn[] source = new InstructionBtn[0];
            int index1 = 0;
            if (mode == 0)
            {
                if (!isCleaningWeapon)
                {
                    if (weaponJamningModuleParam)
                    {
                        Common.common_btns[index1] = !weaponIsJammedParam ? Main.setBtn(Common.common_btns[index1], (Control)WeaponJamming.fix_weapon_btn, "Check weapon condition") : Main.setBtn(Common.common_btns[index1], (Control)WeaponJamming.fix_weapon_btn, "Fix");
                        InstructionBtn[] array = ((IEnumerable<InstructionBtn>)source).Append<InstructionBtn>(Common.common_btns[index1]).ToArray<InstructionBtn>();
                        int index2 = index1 + 1;
                        if (cleaningRequiredParam)
                        {
                            Common.common_btns[index2] = Main.setBtn(Common.common_btns[index2], (Control)WeaponJamming.clean_weapon_btn, "Clean weapon");
                            array = ((IEnumerable<InstructionBtn>)array).Append<InstructionBtn>(Common.common_btns[index2]).ToArray<InstructionBtn>();
                            ++index2;
                        }
                         Common.common_btns[index2] = Main.setBtn(Common.common_btns[index2], (Control)Scope.scope_toggle_btn, "Scope");
                        source = ((IEnumerable<InstructionBtn>)array).Append<InstructionBtn>(Common.common_btns[index2]).ToArray<InstructionBtn>();
                        index1 = index2 + 1;

                        Common.common_btns[index1] = Main.setBtn(Common.common_btns[index1], (Control)Flashlight.flashlight_toggle_btn, "Flashlight");
                        source = ((IEnumerable<InstructionBtn>)source).Append<InstructionBtn>(Common.common_btns[index1]).ToArray<InstructionBtn>();
                        ++index1;
                        
                        Common.common_btns[index1] = Main.setBtn(Common.common_btns[index1], (Control)Grip.grip_toggle_btn, "Grip");
                        source = ((IEnumerable<InstructionBtn>)source).Append<InstructionBtn>(Common.common_btns[index1]).ToArray<InstructionBtn>();
                        ++index1;
                    }
                    if (silencerModeActiveParam)
                    {
                        Common.common_btns[index1] = Main.setBtn(Common.common_btns[index1], (Control)Silencer.silencer_toggle_btn, "Suppressor");
                        source = ((IEnumerable<InstructionBtn>)source).Append<InstructionBtn>(Common.common_btns[index1]).ToArray<InstructionBtn>();
                        ++index1;
                    }

                    if (laserSightModuleParam & canUseLaserSightParam)
                    {
                        Common.common_btns[index1] = Main.setBtn(Common.common_btns[index1], (Control)LaserSight.laser_sight_toggle_btn, "Laser-sight");
                        source = ((IEnumerable<InstructionBtn>)source).Append<InstructionBtn>(Common.common_btns[index1]).ToArray<InstructionBtn>();
                        ++index1;
                    }
                    if (swingWeaponModuleParam & canSwingWeaponParam)
                    {
                        Common.common_btns[index1] = Main.setBtn(Common.common_btns[index1], (Control)WeaponSwing.swing_gun_btn, "Swing gun");
                        source = ((IEnumerable<InstructionBtn>)source).Append<InstructionBtn>(Common.common_btns[index1]).ToArray<InstructionBtn>();
                        ++index1;
                    }
                    if (cameraModuleParam)
                    {
                        Common.common_btns[index1] = Main.setBtn(Common.common_btns[index1], (Control)ShoulderCameraSwitch.switch_shoulder_camera_btn, "Switch shoulder");
                        source = ((IEnumerable<InstructionBtn>)source).Append<InstructionBtn>(Common.common_btns[index1]).ToArray<InstructionBtn>();
                        ++index1;
                    }
                    if (aimingStyleModeActiveParam & canSwitchAimingStyleParam)
                    {
                        Common.common_btns[index1] = Main.setBtn(Common.common_btns[index1], (Control)AimingStyle.aiming_style_btn, "Aim style");
                        source = ((IEnumerable<InstructionBtn>)source).Append<InstructionBtn>(Common.common_btns[index1]).ToArray<InstructionBtn>();
                        ++index1;
                    }
                    
                }
                else if (weaponJamningModuleParam)
                {
                    if (cleaningRequiredParam)
                    {
                        Common.common_btns[index1] = Main.setBtn(Common.common_btns[index1], Control.Context, "Clean");
                        source = ((IEnumerable<InstructionBtn>)source).Append<InstructionBtn>(Common.common_btns[index1]).ToArray<InstructionBtn>();
                        ++index1;
                    }
                    Common.common_btns[index1] = Main.setBtn(Common.common_btns[index1], Control.ContextSecondary, "Finish");
                    source = ((IEnumerable<InstructionBtn>)source).Append<InstructionBtn>(Common.common_btns[index1]).ToArray<InstructionBtn>();
                    ++index1;
                }
            }
            if (mode == 1)
            {
                Common.common_btns[index1] = Main.setBtn(Common.common_btns[index1], Control.Context, "Grab bag");
                source = ((IEnumerable<InstructionBtn>)source).Append<InstructionBtn>(Common.common_btns[index1]).ToArray<InstructionBtn>();
                ++index1;
            }
            if (mode == 2)
            {
                Common.common_btns[index1] = Main.setBtn(Common.common_btns[index1], Control.PhoneSelect, "Call dealer");
                InstructionBtn[] array = ((IEnumerable<InstructionBtn>)source).Append<InstructionBtn>(Common.common_btns[index1]).ToArray<InstructionBtn>();
                int index3 = index1 + 1;
                if (InventoryBag.isBagDropped && InventoryBag.bag_module_active)
                {
                    Common.common_btns[index3] = Main.setBtn(Common.common_btns[index3], Control.NextCamera, "Mark stashed bag");
                    array = ((IEnumerable<InstructionBtn>)array).Append<InstructionBtn>(Common.common_btns[index3]).ToArray<InstructionBtn>();
                    ++index3;
                }
                Common.common_btns[index3] = Main.setBtn(Common.common_btns[index3], Control.PhoneCancel, "Cancel");
                source = ((IEnumerable<InstructionBtn>)array).Append<InstructionBtn>(Common.common_btns[index3]).ToArray<InstructionBtn>();
                index1 = index3 + 1;
            }
            if (mode == 3)
            {
                if (!isBagBought && InventoryBag.bag_module_active)
                {
                    string label = "Uncheck bag";
                    if (!Common.buyBag)
                        label = "Check bag (" + InventoryBag.BagPrice.ToString() + " $)";
                    Common.common_btns[index1] = Main.setBtn(Common.common_btns[index1], Control.ContextSecondary, label);
                    source = ((IEnumerable<InstructionBtn>)source).Append<InstructionBtn>(Common.common_btns[index1]).ToArray<InstructionBtn>();
                    ++index1;
                }
                if (WeaponHolster.holster_module_active && !hasHolster)
                {
                    string label = "Uncheck holster";
                    if (!Common.buyHolster)
                        label = "Check holster (" + WeaponHolster.HolsterPrice.ToString() + " $)";
                    Common.common_btns[index1] = Main.setBtn(Common.common_btns[index1], Control.VehicleDuck, label);
                    source = ((IEnumerable<InstructionBtn>)source).Append<InstructionBtn>(Common.common_btns[index1]).ToArray<InstructionBtn>();
                    ++index1;
                }
                if (CigsAndPills.cigsCount < CigsAndPills.maxCigs || CigsAndPills.pillsCount < CigsAndPills.maxPills)
                {
                    string label = "Uncheck supplies";
                    if (!Common.buySupplies)
                        label = "Check supplies (" + CigsAndPills.SupplyPrice.ToString() + " $)";
                    Common.common_btns[index1] = Main.setBtn(Common.common_btns[index1], Control.NextCamera, label);
                    source = ((IEnumerable<InstructionBtn>)source).Append<InstructionBtn>(Common.common_btns[index1]).ToArray<InstructionBtn>();
                    ++index1;
                }
                if (WeaponJamming.jammingModeIsActive && WeaponJamming.cleaningToolsCount < WeaponJamming.cleaningToolsMax)
                {
                    string label = "Uncheck weapon tools";
                    if (!Common.buyTools)
                        label = "Check weapon tools (" + WeaponJamming.weaponToolsPrice.ToString() + " $)";
                    Common.common_btns[index1] = Main.setBtn(Common.common_btns[index1], Control.LookBehind, label);
                    source = ((IEnumerable<InstructionBtn>)source).Append<InstructionBtn>(Common.common_btns[index1]).ToArray<InstructionBtn>();
                    ++index1;
                }
                if (Common.buyBag || Common.buyHolster || Common.buySupplies || Common.buyTools)
                {
                    Common.common_btns[index1] = Main.setBtn(Common.common_btns[index1], Control.Context, "Confirm");
                    source = ((IEnumerable<InstructionBtn>)source).Append<InstructionBtn>(Common.common_btns[index1]).ToArray<InstructionBtn>();
                    ++index1;
                }
                Common.common_btns[index1] = Main.setBtn(Common.common_btns[index1], Control.VehicleExit, "Cancel");
                source = ((IEnumerable<InstructionBtn>)source).Append<InstructionBtn>(Common.common_btns[index1]).ToArray<InstructionBtn>();
                ++index1;
            }
            if (mode == 4)
            {
                if (!WeaponHolster.intimidation)
                {
                    Common.common_btns[index1] = Main.setBtn(Common.common_btns[index1], (Control)Common.exit_menu_btn, "Close");
                    InstructionBtn[] array1 = ((IEnumerable<InstructionBtn>)source).Append<InstructionBtn>(Common.common_btns[index1]).ToArray<InstructionBtn>();
                    int index4 = index1 + 1;
                    Common.common_btns[index4] = Main.setBtn(Common.common_btns[index4], (Control)Common.next_menu_btn, "Next");
                    source = ((IEnumerable<InstructionBtn>)array1).Append<InstructionBtn>(Common.common_btns[index4]).ToArray<InstructionBtn>();
                    index1 = index4 + 1;
                    if (action_page == 0)
                    {
                        if (((IEnumerable<WeaponGroup>)WeaponHolster._bigWeaponGroups).Contains<WeaponGroup>(Game.Player.Character.Weapons.Current.Group))
                        {
                            Common.common_btns[index1] = Main.setBtn(Common.common_btns[index1], (Control)WeaponHolster.weapon_menu_btn, "Weapon menu");
                            source = ((IEnumerable<InstructionBtn>)source).Append<InstructionBtn>(Common.common_btns[index1]).ToArray<InstructionBtn>();
                            ++index1;



                        }


                        if (Game.Player.Character.Armor > 0 || Vest.armortakenoff )
                        {
                            Common.common_btns[index1] = Main.setBtn(Common.common_btns[index1], (Control)Vest.vest_menu_btn, "Vest menu");
                            source = ((IEnumerable<InstructionBtn>)source).Append<InstructionBtn>(Common.common_btns[index1]).ToArray<InstructionBtn>();
                            ++index1;
                        }

                        // if (
                        if (WeaponHolster.holster_module_active & hasHolster)
                        {
                            Common.common_btns[index1] = Main.setBtn(Common.common_btns[index1], (Control)WeaponHolster.holster_toggle_btn, "Holster");
                            source = ((IEnumerable<InstructionBtn>)source).Append<InstructionBtn>(Common.common_btns[index1]).ToArray<InstructionBtn>();
                            ++index1;
                            if ((Entity)WeaponHolster.holster != (Entity)null && WeaponHolster.holster.Exists() && !Game.Player.Character.IsSittingInVehicle())
                            {
                                Common.common_btns[index1] = Main.setBtn(Common.common_btns[index1], (Control)WeaponHolster.intimidate_btn, "Start Intimidate");
                                source = ((IEnumerable<InstructionBtn>)source).Append<InstructionBtn>(Common.common_btns[index1]).ToArray<InstructionBtn>();
                                ++index1;
                            }
                        }
                        if (InventoryBag.bag_module_active)
                        {
                            if (hasBag)
                            {
                                Common.common_btns[index1] = Main.setBtn(Common.common_btns[index1], (Control)InventoryBag.bag_menu_btn, "Bag menu");
                                InstructionBtn[] array2 = ((IEnumerable<InstructionBtn>)source).Append<InstructionBtn>(Common.common_btns[index1]).ToArray<InstructionBtn>();
                                int index5 = index1 + 1;
                                Common.common_btns[index5] = Main.setBtn(Common.common_btns[index5], (Control)InventoryBag.bag_coords_update_btn, "Update bag attach position from settings");
                                source = ((IEnumerable<InstructionBtn>)array2).Append<InstructionBtn>(Common.common_btns[index5]).ToArray<InstructionBtn>();
                                index1 = index5 + 1;
                            }
                            else if (bagInCar)
                            {
                                Common.common_btns[index1] = Main.setBtn(Common.common_btns[index1], (Control)InventoryBag.bag_menu_btn, "Grab bag");
                                source = ((IEnumerable<InstructionBtn>)source).Append<InstructionBtn>(Common.common_btns[index1]).ToArray<InstructionBtn>();
                                ++index1;
                            }
                        }
                        if (Game.Player.Character.IsSittingInVehicle() && (Game.Player.Character.CurrentVehicle.IsBicycle || Game.Player.Character.CurrentVehicle.IsBike))
                        {
                            Common.common_btns[index1] = Main.setBtn(Common.common_btns[index1], (Control)Helmet.helmet_on_btn, "Put helmet on");
                            source = ((IEnumerable<InstructionBtn>)source).Append<InstructionBtn>(Common.common_btns[index1]).ToArray<InstructionBtn>();
                            ++index1;
                        }
                    }
                    if (action_page == 1)
                    {
                        Common.common_btns[index1] = Main.setBtn(Common.common_btns[index1], (Control)CigsAndPills.smokeBTN, "Smoke (" + CigsAndPills.cigsCount.ToString() + " cigs left)");
                        InstructionBtn[] array3 = ((IEnumerable<InstructionBtn>)source).Append<InstructionBtn>(Common.common_btns[index1]).ToArray<InstructionBtn>();
                        int index6 = index1 + 1;
                        Common.common_btns[index6] = Main.setBtn(Common.common_btns[index6], (Control)CigsAndPills.swallowBTN, "Pills (" + CigsAndPills.pillsCount.ToString() + " pills left)");
                        InstructionBtn[] array4 = ((IEnumerable<InstructionBtn>)array3).Append<InstructionBtn>(Common.common_btns[index6]).ToArray<InstructionBtn>();
                        int index7 = index6 + 1;
                        Common.common_btns[index7] = Main.setBtn(Common.common_btns[index7], (Control)Wallet.wallet_btn, "Wallet");
                        InstructionBtn[] array5 = ((IEnumerable<InstructionBtn>)array4).Append<InstructionBtn>(Common.common_btns[index7]).ToArray<InstructionBtn>();
                        int index8 = index7 + 1;
                        Common.common_btns[index8] = Main.setBtn(Common.common_btns[index8], (Control)OnFootRadio.earphone_toggle_btn, "Earphone");
                        source = ((IEnumerable<InstructionBtn>)array5).Append<InstructionBtn>(Common.common_btns[index8]).ToArray<InstructionBtn>();
                        index1 = index8 + 1;
                        if (OnFootRadio.headset)
                        {
                            Common.common_btns[index1] = Main.setBtn(Common.common_btns[index1], (Control)OnFootRadio.readio_off_btn, "Toggle Radio");
                            source = ((IEnumerable<InstructionBtn>)source).Append<InstructionBtn>(Common.common_btns[index1]).ToArray<InstructionBtn>();
                            ++index1;
                        }
                    }
                    if (action_page == 2 && FastWardrobe.mask_module_active)
                    {
                        Common.common_btns[index1] = Main.setBtn(Common.common_btns[index1], (Control)FastWardrobe.mask_toggle_btn, "Mask");
                        InstructionBtn[] array6 = ((IEnumerable<InstructionBtn>)source).Append<InstructionBtn>(Common.common_btns[index1]).ToArray<InstructionBtn>();
                        int index9 = index1 + 1;
                        Common.common_btns[index9] = Main.setBtn(Common.common_btns[index9], (Control)FastWardrobe.gloves_toggle_btn, "Gloves");
                        InstructionBtn[] array7 = ((IEnumerable<InstructionBtn>)array6).Append<InstructionBtn>(Common.common_btns[index9]).ToArray<InstructionBtn>();
                        int index10 = index9 + 1;
                        Common.common_btns[index10] = Main.setBtn(Common.common_btns[index10], (Control)FastWardrobe.glasses_toggle_btn, "Glasses");
                        InstructionBtn[] array8 = ((IEnumerable<InstructionBtn>)array7).Append<InstructionBtn>(Common.common_btns[index10]).ToArray<InstructionBtn>();
                        int index11 = index10 + 1;
                        Common.common_btns[index11] = Main.setBtn(Common.common_btns[index11], (Control)FastWardrobe.hat_toggle_btn, "Hat");
                        source = ((IEnumerable<InstructionBtn>)array8).Append<InstructionBtn>(Common.common_btns[index11]).ToArray<InstructionBtn>();
                        index1 = index11 + 1;
                    }
                    if (action_page == 3)
                    {
                        Common.common_btns[index1] = Main.setBtn(Common.common_btns[index1], (Control)WeaponHolster.toggle_holsted_weapon_btn, "Toggle weapons visibility mode");
                        source = ((IEnumerable<InstructionBtn>)source).Append<InstructionBtn>(Common.common_btns[index1]).ToArray<InstructionBtn>();
                        ++index1;
                        if (WeaponHolster.holsted_big_weapons_module_active)
                        {
                            Common.common_btns[index1] = Main.setBtn(Common.common_btns[index1], (Control)WeaponHolster.toggle_holsted_weapon_position, "Toggle weapon position");
                            source = ((IEnumerable<InstructionBtn>)source).Append<InstructionBtn>(Common.common_btns[index1]).ToArray<InstructionBtn>();
                            ++index1;
                        }
                    }
                    if (action_page == 4)
                    {
                        Common.common_btns[index1] = Main.setBtn(Common.common_btns[index1], (Control)HungerSystem.eat_btn, "Eat(" + HungerSystem.foodLeft.ToString() + ")");
                        InstructionBtn[] array9 = ((IEnumerable<InstructionBtn>)source).Append<InstructionBtn>(Common.common_btns[index1]).ToArray<InstructionBtn>();
                        int index12 = index1 + 1;
                        Common.common_btns[index12] = Main.setBtn(Common.common_btns[index12], (Control)HungerSystem.drink_btn, "Drink(" + HungerSystem.drinksLeft.ToString() + ")");
                        source = ((IEnumerable<InstructionBtn>)array9).Append<InstructionBtn>(Common.common_btns[index12]).ToArray<InstructionBtn>();
                        index1 = index12 + 1;
                    }
                }
                else
                {
                    Common.common_btns[index1] = Main.setBtn(Common.common_btns[index1], Control.Attack, "Start Intimidate");
                    InstructionBtn[] array = ((IEnumerable<InstructionBtn>)source).Append<InstructionBtn>(Common.common_btns[index1]).ToArray<InstructionBtn>();
                    int index13 = index1 + 1;
                    Common.common_btns[index13] = Main.setBtn(Common.common_btns[index13], Control.Aim, "Stop Intimidate");
                    source = ((IEnumerable<InstructionBtn>)array).Append<InstructionBtn>(Common.common_btns[index13]).ToArray<InstructionBtn>();
                    index1 = index13 + 1;
                }
            }
            if (mode == 5)
            {
                Common.common_btns[index1] = Main.setBtn(Common.common_btns[index1], (Control)Common.main_menu_sec_btn, "Expansion actions");
                source = ((IEnumerable<InstructionBtn>)source).Append<InstructionBtn>(Common.common_btns[index1]).ToArray<InstructionBtn>();
                ++index1;
            }
            if (mode == 6)
            {
                Common.common_btns[index1] = Main.setBtn(Common.common_btns[index1], Control.Attack, "Buy snacks (10$)");
                InstructionBtn[] array = ((IEnumerable<InstructionBtn>)source).Append<InstructionBtn>(Common.common_btns[index1]).ToArray<InstructionBtn>();
                int index14 = index1 + 1;
                Common.common_btns[index14] = Main.setBtn(Common.common_btns[index14], Control.Aim, "Buy cigs and painkillers (" + CigsAndPills.cigsAndPillsPrice.ToString() + "$)");
                source = ((IEnumerable<InstructionBtn>)array).Append<InstructionBtn>(Common.common_btns[index14]).ToArray<InstructionBtn>();
                index1 = index14 + 1;
            }
            if (mode == 7)
            {
                Common.common_btns[index1] = Main.setBtn(Common.common_btns[index1], Control.Attack, "Mark/Unmark");
                InstructionBtn[] array = ((IEnumerable<InstructionBtn>)source).Append<InstructionBtn>(Common.common_btns[index1]).ToArray<InstructionBtn>();
                int index15 = index1 + 1;
                Common.common_btns[index15] = Main.setBtn(Common.common_btns[index15], Control.Aim, "Execute");
                source = ((IEnumerable<InstructionBtn>)array).Append<InstructionBtn>(Common.common_btns[index15]).ToArray<InstructionBtn>();
                index1 = index15 + 1;
            }
            if (mode == 8)
            {
                Common.common_btns[index1] = Main.setBtn(Common.common_btns[index1], Control.Attack, "Ignite");
                source = ((IEnumerable<InstructionBtn>)source).Append<InstructionBtn>(Common.common_btns[index1]).ToArray<InstructionBtn>();
                ++index1;
                if (!readyToIgnite)
                {
                    Common.common_btns[index1] = Main.setBtn(Common.common_btns[index1], Control.Aim, "Drop");
                    source = ((IEnumerable<InstructionBtn>)source).Append<InstructionBtn>(Common.common_btns[index1]).ToArray<InstructionBtn>();
                    ++index1;
                }
            }
            if (mode == 9)
            {
                Common.common_btns[index1] = Main.setBtn(Common.common_btns[index1], Control.ContextSecondary, "Drop cig");
                source = ((IEnumerable<InstructionBtn>)source).Append<InstructionBtn>(Common.common_btns[index1]).ToArray<InstructionBtn>();
                ++index1;
            }
            if (mode == 10)
            {
                Common.common_btns[index1] = Main.setBtn(Common.common_btns[index1], Control.Attack, "Make a sip");
                InstructionBtn[] array = ((IEnumerable<InstructionBtn>)source).Append<InstructionBtn>(Common.common_btns[index1]).ToArray<InstructionBtn>();
                int index16 = index1 + 1;
                Common.common_btns[index16] = Main.setBtn(Common.common_btns[index16], Control.Aim, "Drop");
                source = ((IEnumerable<InstructionBtn>)array).Append<InstructionBtn>(Common.common_btns[index16]).ToArray<InstructionBtn>();
                int num = index16 + 1;
            }
            if (mode == 11)
            {
                //if (InventoryBag.hasBag)

                Common.common_btns[index1] = Main.setBtn(Common.common_btns[index1], Control.Attack, "Buy dufflebag (" + InventoryBag.BagPrice.ToString() + "$)");
                InstructionBtn[] array = ((IEnumerable<InstructionBtn>)source).Append<InstructionBtn>(Common.common_btns[index1]).ToArray<InstructionBtn>();
                int index14 = index1 + 1;
                Common.common_btns[index14] = Main.setBtn(Common.common_btns[index14], Control.Aim, "Buy holster (" + WeaponHolster.HolsterPrice.ToString() + "$)");    
                source = ((IEnumerable<InstructionBtn>)array).Append<InstructionBtn>(Common.common_btns[index14]).ToArray<InstructionBtn>();
                index1 = index14 + 1;
                WeaponJamming.cleaningToolsCount = Common.getSupplies(Game.Player.Character, "weapon_tools");
                if (WeaponJamming.cleaningToolsCount <= WeaponJamming.cleaningToolsMax)
                {
                    Common.common_btns[index1] = Main.setBtn(Common.common_btns[index1], Control.LookBehind, "Buy cleaning kit (" + WeaponJamming.weaponToolsPrice.ToString() + "$)");
                    source = ((IEnumerable<InstructionBtn>)source).Append<InstructionBtn>(Common.common_btns[index1]).ToArray<InstructionBtn>();
                    ++index1;
                }
            }
            List<InstructionBtn> list = Main.instructionButtonPool.ToList();
            foreach (InstructionBtn instructionBtn in source)
            {
                if (!list.Contains(instructionBtn))
                    list.Add(instructionBtn);
            }
        }

        public static void iconDrawFunc(int x, int y, int width, int height, string icon_name)
        {
            if (File.Exists("scripts\\Expansion\\" + icon_name))
                new CustomSprite(".\\scripts\\Expansion\\" + icon_name, (SizeF)new Size(width, height), (PointF)new Point(x, y)).Draw();
            else
                Screen.ShowSubtitle(icon_name + " was not found");
        }

        public static bool curVehicleIsCar(Ped ped)
        {
            if (!Game.Player.Character.IsSittingInVehicle())
                return true;
            return Game.Player.Character.IsSittingInVehicle() && !Game.Player.Character.CurrentVehicle.IsBicycle && !Game.Player.Character.CurrentVehicle.IsBike && !Game.Player.Character.CurrentVehicle.IsQuadBike && !Game.Player.Character.CurrentVehicle.IsRegularQuadBike && !Game.Player.Character.CurrentVehicle.IsAmphibiousQuadBike && !Game.Player.Character.CurrentVehicle.IsPlane && !Game.Player.Character.CurrentVehicle.IsHelicopter;
        }

        public static int getSupplies(Ped ped, string elem)
        {
            int supplies = 0;
            string name = ((PedHash)ped.Model).ToString();
            if (char.IsDigit(name[0]))
                name = "CustomPed_" + name;
            if (Common.doc.Element((XName)"WeaponList").Element((XName)name) != null && Common.doc.Element((XName)"WeaponList").Element((XName)name).Element((XName)"Supplies") != null)
            {
                XElement xelement = Common.doc.Element((XName)"WeaponList").Element((XName)name).Element((XName)"Supplies");
                if (xelement != null && xelement.Element((XName)elem) != null && xelement.Element((XName)elem).Element((XName)"Count") != null)
                    return Convert.ToInt32(xelement.Element((XName)elem).Element((XName)"Count").Value);
            }
            return supplies;
        }

        public static void saveSupplies(Ped ped, string elem, int num)
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
                if (Common.doc.Element((XName)"WeaponList").Element((XName)name).Element((XName)"Supplies") == null)
                {
                    Common.doc.Element((XName)"WeaponList").Element((XName)name).Add((object)new XElement((XName)"Supplies"));
                    Common.saveDoc();
                    xelement = Common.doc.Element((XName)"WeaponList").Element((XName)name).Element((XName)"Supplies");
                }
                if (Common.doc.Element((XName)"WeaponList").Element((XName)name).Element((XName)"Supplies") != null)
                    xelement = Common.doc.Element((XName)"WeaponList").Element((XName)name).Element((XName)"Supplies");
            }
            if (xelement == null)
                return;
            if (xelement.Element((XName)elem) == null)
            {
                xelement.Add((object)new XElement((XName)elem, (object)new XElement((XName)"Count", (object)num)));
                Common.saveDoc();
            }
            else if (xelement.Element((XName)elem).Element((XName)"Count") == null)
            {
                xelement.Element((XName)elem).Add((object)new XElement((XName)"Count", (object)num));
                Common.saveDoc();
            }
            else
            {
                xelement.Element((XName)elem).Element((XName)"Count").SetValue((object)num);
                Common.saveDoc();
            }
        }

        public static void saveDoc(XDocument _doc = null)
        {
            if (_doc == null)
                _doc = Common.doc;
            _doc.Save("scripts\\Expansion\\WeaponStash.xml");
        }

        public static void sellerDialogFunc(
          int counter,
          bool holster_purchase,
          bool bag_purchase,
          bool supplies_purchase,
          Ped dealer,
          bool cleaning_tools_purchashed,
          XDocument _doc)
        {
            if (Common.payed)
            {
                Function.Call(Hash.PLAY_PED_AMBIENT_SPEECH_NATIVE, (InputArgument)(Entity)Game.Player.Character, (InputArgument)"GENERIC_THANKS", (InputArgument)"SPEECH_PARAMS_FORCE");
                Script.Wait(1000);
                Function.Call(Hash.PLAY_PED_AMBIENT_SPEECH_NATIVE, (InputArgument)(Entity)dealer, (InputArgument)"GENERIC_BYE", (InputArgument)"SPEECH_PARAMS_FORCE");
                if (Common.TotalPrice + Common.TotalPrice / 100 * 5 > 0)
                {
                    Main.Notify((Common.TotalPrice + Common.TotalPrice / 100 * 5).ToString() + "~g~ $ ~w~Transaction ~g~successfully ~w~completed~n~Payment transaction ~o~5%~w~ has been discharged~n~Thank you for using our service!", "MAZE", (int)byte.MaxValue, 0, 0, NotificationIcon.BankMaze);
                    if (Game.Player.Character.Model == (Model)PedHash.Michael || Game.Player.Character.Model == (Model)PedHash.Franklin || Game.Player.Character.Model == (Model)PedHash.Trevor)
                        Game.Player.Money -= Common.TotalPrice + Common.TotalPrice / 100 * 5;
                }
                Function.Call(Hash.PLAY_MISSION_COMPLETE_AUDIO, (InputArgument)"TREVOR_SMALL_01");
                if (bag_purchase)
                {
                    InventoryBag.ClearInventoryData(Game.Player.Character);
                    InventoryBag.bagSet(InventoryBag.bagModelCheck(Game.Player.Character), Game.Player.Character);
                    Function.Call(Hash.SET_TEXT_COLOUR, (InputArgument)0, (InputArgument)(int)byte.MaxValue, (InputArgument)0, (InputArgument)100);
                    Notification.Show("Dufflebag has been ~g~purchased", true);
                }
                if (supplies_purchase)
                {
                    int num1 = CigsAndPills.maxPills - CigsAndPills.pillsCount;
                    int num2 = CigsAndPills.maxCigs - CigsAndPills.cigsCount;
                    if (CigsAndPills.pillsCount < CigsAndPills.maxPills)
                    {
                        Function.Call(Hash.SET_TEXT_COLOUR, (InputArgument)0, (InputArgument)(int)byte.MaxValue, (InputArgument)0, (InputArgument)100);
                        Common.saveSupplies(Game.Player.Character, "painkillers", CigsAndPills.maxPills);
                        Notification.Show("~g~+" + num1.ToString() + " ~w~Pills", true);
                    }
                    if (CigsAndPills.cigsCount < CigsAndPills.maxCigs)
                    {
                        Function.Call(Hash.SET_TEXT_COLOUR, (InputArgument)0, (InputArgument)(int)byte.MaxValue, (InputArgument)0, (InputArgument)100);
                        Common.saveSupplies(Game.Player.Character, "ciggaretes", CigsAndPills.maxCigs);
                        Notification.Show("~g~+" + num2.ToString() + " ~w~Cigs", true);
                    }
                }
                if (holster_purchase)
                {
                    WeaponHolster.SaveHolster(Game.Player.Character);
                    Function.Call(Hash.SET_TEXT_COLOUR, (InputArgument)0, (InputArgument)(int)byte.MaxValue, (InputArgument)0, (InputArgument)100);
                    Notification.Show("Holster has been ~g~purchased", true);
                }
                if (cleaning_tools_purchashed && WeaponJamming.cleaningToolsCount < WeaponJamming.cleaningToolsMax)
                {
                    Function.Call(Hash.SET_TEXT_COLOUR, (InputArgument)0, (InputArgument)(int)byte.MaxValue, (InputArgument)0, (InputArgument)100);
                    Common.saveSupplies(Game.Player.Character, "weapon_tools", WeaponJamming.cleaningToolsMax);
                    Notification.Show("Weapon cleaning tools has been ~g~purchased", true);
                }
            }
            Common.clearScriptFunction();
            Game.Player.Character.Task.ClearAll();
            Common.buyBag = false;
            Common.buyHolster = false;
            Common.buySupplies = false;
            Common.buyTools = false;
        }

        public static void ComeOverFunc(Ped ped, Ped partner, int hour_to_advance)
        {
            if (!Common.trans_completed)
            {
                Common.camera_transition(GameplayCamera.Position, new Vector3(0.0f, 0.0f, GameplayCamera.Rotation.Z), hour_to_advance, false, Weather.Clouds, true, true);
            }
            else
            {
                Vector3 safeCoordForPed = World.GetSafeCoordForPed(new Vector3(ped.Position.X, ped.Position.Y, ped.Position.Z), false);
                if ((Entity)Common.Taxi == (Entity)null || (Entity)Common.Taxi != (Entity)null && (!Common.Taxi.Exists() || Common.Taxi.IsDead) || (Entity)Common.Driver == (Entity)null || (Entity)Common.Driver != (Entity)null && (!Common.Driver.Exists() || Common.Driver.IsDead))
                {
                    if (!Screen.IsFadingOut)
                        Screen.FadeOut(1000);
                    if (!Screen.IsFadedOut)
                        return;
                    Script.Wait(2000);
                    Function.Call(Hash.CLEAR_AREA_OF_VEHICLES, (InputArgument)ped.Position.X, (InputArgument)ped.Position.Y, (InputArgument)ped.Position.Z, (InputArgument)100f, (InputArgument)false, (InputArgument)false, (InputArgument)false, (InputArgument)false, (InputArgument)false);
                    Function.Call(Hash.ADD_TO_CLOCK_TIME, (InputArgument)Common.rnd.Next(1, 3), (InputArgument)Common.rnd.Next(1, 60), (InputArgument)Common.rnd.Next(1, 60));
                    (Common.Taxi, Common.Driver) = Main.CreateVehicleWithDriverFunc(ped, VehicleHash.Taxi, PedHash.MexGang01GMY, safeCoordForPed, true, partner);
                }
                else
                {
                    if (!((Entity)Common.Taxi != (Entity)null) || !Common.Taxi.Exists() || !Common.Taxi.IsAlive || !((Entity)Common.Driver != (Entity)null) || !Common.Driver.Exists() || !Common.Driver.IsAlive)
                        return;
                    if (!Screen.IsFadingIn && Screen.IsFadedOut)
                    {
                        Screen.FadeIn(1000);
                        Script.Wait(2000);
                    }
                    if (!Screen.IsFadedIn || !((Entity)partner != (Entity)null) || !partner.Exists())
                        return;
                    Main.addToGroup(Common.Driver, partner);
                    if (Common.Driver.IsInVehicle(Common.Taxi))
                    {
                        Common.stuckTimerActive = true;
                        if (Common.stuckTimer >= 60)
                        {
                            Common.come_over_mode = false;
                            Common.stuckTimer = 0;
                            Common.stuckTimerActive = false;
                            Common.Taxi.MarkAsNoLongerNeeded();
                            Common.Taxi = (Vehicle)null;
                            Common.Driver.MarkAsNoLongerNeeded();
                            Common.Driver = (Ped)null;
                            if (partner.AttachedBlip != (Blip)null)
                                partner.AttachedBlip.Delete();
                            partner.MarkAsNoLongerNeeded();
                            partner = (Ped)null;
                            Common.greeting = false;
                            Common.followCamera = false;
                            Main.Notify("Sorry, somethings came up, call me some other time, will you?", "~r~ARRANGEMENT CANCEL~w~", (int)byte.MaxValue, 0, 0, NotificationIcon.Ammunation);
                        }
                        Vector3 position;
                        if (!Common.followCamera)
                        {
                            position = Common.Driver.Position;
                            if ((double)position.DistanceTo(ped.Position) < 25.0)
                            {
                                Common.CamObject = (Entity)partner;
                                Common.followCamera = true;
                            }
                        }
                        position = Common.Driver.Position;
                        if ((double)position.DistanceTo(ped.Position) > 25.0)
                        {
                            if (!Common.allowActionPerform(Common.Driver, 100))
                                return;
                            Common.Driver.Task.DriveTo(Common.Taxi, ped.Position, 25f, 20f, DrivingStyle.SometimesOvertakeTraffic);
                        }
                        else if (partner.IsInVehicle(Common.Taxi))
                        {
                            Common.Driver.CurrentVehicle.Speed = 0.0f;
                            Common.Driver.Task.StandStill(1000);
                            Common.Driver.AlwaysKeepTask = true;
                            --Common.actionTimer;
                            if (!Common.allowActionPerform(Common.Driver, 100))
                                return;
                            partner.Task.LeaveVehicle();
                        }
                        else
                        {
                            Common.Driver.LeaveGroup();
                            Main.addToGroup(ped, partner);
                            Common.come_over_mode = false;
                            Common.Driver.MarkAsNoLongerNeeded();
                            Common.Driver = (Ped)null;
                            Common.greeting = true;
                            Common.stuckTimerActive = false;
                            Common.Taxi.MarkAsNoLongerNeeded();
                            Common.Taxi = (Vehicle)null;
                        }
                    }
                    else
                    {
                        if (Function.Call<bool>(Hash.IS_PED_IN_VEHICLE, (InputArgument)(Entity)Common.Driver, (InputArgument)(Entity)Common.Taxi, (InputArgument)false) || Common.Driver.IsGettingIntoVehicle || !Common.allowActionPerform(Common.Driver, 100))
                            return;
                        Common.Driver.Task.EnterVehicle(Common.Taxi, VehicleSeat.Driver, 10000, 1);
                    }
                }
            }
        }

        public static void CreateSeller(Vector3 location)
        {
            Ped[] nearbyPeds = World.GetNearbyPeds(location, 125f, (Model)PedHash.Dealer01SMY);
            Common.seller = (Ped)null;
            bool flag1 = false;
            if (((IEnumerable<Ped>)nearbyPeds).Count<Ped>() > 0)
            {
                foreach (Ped ped in nearbyPeds)
                {
                    if ((Entity)ped != (Entity)null && ped.IsAlive && ped.Exists())
                    {
                        Common.seller = ped;
                        flag1 = true;
                        break;
                    }
                }
            }
            if (!flag1)
                Common.seller = World.CreatePed((Model)PedHash.Dealer01SMY, location);
            if (!((Entity)Common.seller != (Entity)null))
                return;
            Common.blipHandle(true, (Entity)Common.seller, Common.sellerBlip, "Dealer", 0.9f, 220, true, true);
            Function.Call(Hash.SET_ENTITY_AS_MISSION_ENTITY, (InputArgument)(Entity)Common.seller, (InputArgument)true);
            Common.greeting = false;
            Common.greetingFinished = false;
            Common.deal = false;
            Common.payed = false;
            Common.buyBag = false;
            Common.buyHolster = false;
            Common.buySupplies = false;
            Common.buyTools = false;
            Prop[] nearbyProps = World.GetNearbyProps(Common.seller.Position, 2.5f, (Model)Main.GetHashKey(InventoryBag.bagModel));
            Prop prop1 = (Prop)null;
            bool flag2 = false;
            Common.sellerDialogCounter = 3;
            if (((IEnumerable<Prop>)nearbyProps).Count<Prop>() > 0)
            {
                foreach (Prop prop2 in nearbyProps)
                {
                    if (!prop2.IsAttached() && !prop2.IsAttachedTo((Entity)Common.seller) && !prop2.IsAttachedTo((Entity)Game.Player.Character) && (Entity)prop2 != InventoryBag.getDroppedBag(Game.Player.Character))
                    {
                        prop1 = prop2;
                        flag2 = true;
                    }
                }
            }
            if (!flag2)
                prop1 = World.CreateProp((Model)Main.GetHashKey(InventoryBag.bagModel), Common.seller.Position, true, true);
            if (!((Entity)prop1 != (Entity)null) || prop1.IsAttached() || prop1.IsAttachedTo((Entity)Common.seller) || prop1.IsAttachedTo((Entity)Game.Player.Character))
                return;
            int num = Function.Call<int>(Hash.GET_PED_BONE_INDEX, (InputArgument)(Entity)Common.seller, (InputArgument)InventoryBag.bag_attach_bone);
            Function.Call(Hash.ATTACH_ENTITY_TO_ENTITY, (InputArgument)(Entity)prop1, (InputArgument)(Entity)Common.seller, (InputArgument)num, (InputArgument)InventoryBag.xdg, (InputArgument)InventoryBag.ydg, (InputArgument)InventoryBag.zdg, (InputArgument)InventoryBag.xrdg, (InputArgument)InventoryBag.yrdg, (InputArgument)InventoryBag.zrdg, (InputArgument)true, (InputArgument)true, (InputArgument)false, (InputArgument)false, (InputArgument)0, (InputArgument)true);
        }

        public static void clearScriptFunction()
        {
            Common.come_over_mode = false;
            World.DestroyAllCameras();
            World.RenderingCamera = (Camera)null;
            Common.deal = false;
            Common.greeting = false;
            Common.greetingFinished = false;
            Common.followCamera = false;
            Common.canceled = false;
            Common.sellerAvailableItems = 0;
            if ((Entity)Common.seller != (Entity)null && Common.seller.Exists())
            {
                Common.blipHandle(false, (Entity)Common.seller, Common.sellerBlip, "", 0.0f, 0, false, false);
                Prop[] nearbyProps = World.GetNearbyProps(Common.seller.Position, 50f, (Model)Main.GetHashKey(InventoryBag.bagModel));
                if (((IEnumerable<Prop>)nearbyProps).Count<Prop>() > 0)
                {
                    foreach (Prop prop in nearbyProps)
                    {
                        if (prop.IsAttachedTo((Entity)Common.seller) || !prop.IsAttached() && (Entity)prop != InventoryBag.getDroppedBag(Game.Player.Character))
                            prop.Delete();
                    }
                }
                Common.seller.Task.ClearAll();
                Common.seller.MarkAsNoLongerNeeded();
                Common.seller = (Ped)null;
            }
            Common.payed = false;
            Game.Pause(false);
            Game.Player.CanControlCharacter = true;
            Game.Player.Character.Task.ClearAll();
            World.RenderingCamera = (Camera)null;
        }

        public static void blipHandle(
          bool add,
          Entity entity,
          BlipSprite sprite,
          string name,
          float scale,
          int alpha,
          bool flashing,
          bool showRoute)
        {
            if (!(entity != (Entity)null) || !entity.Exists())
                return;
            if (add)
            {
                if (entity.AttachedBlip == (Blip)null || entity.AttachedBlip != (Blip)null && !entity.AttachedBlip.Exists())
                    entity.AddBlip();
                if (!(entity.AttachedBlip != (Blip)null))
                    return;
                entity.AttachedBlip.Sprite = sprite;
                entity.AttachedBlip.Name = name;
                entity.AttachedBlip.Scale = scale;
                entity.AttachedBlip.Alpha = alpha;
                entity.AttachedBlip.IsFlashing = flashing;
                entity.AttachedBlip.ShowRoute = showRoute;
            }
            else
            {
                if (!(entity.AttachedBlip != (Blip)null))
                    return;
                entity.AttachedBlip.Delete();
            }
        }

        public static void blipsRemove(BlipSprite sprite)
        {
            Blip[] allBlips = World.GetAllBlips();
            if (allBlips == null || allBlips.Length == 0)
                return;
            foreach (Blip blip in allBlips)
            {
                if (blip.Sprite == sprite)
                    blip.Delete();
            }
        }

        public static void clearTrash()
        {
            Prop[] allProps1 = World.GetAllProps((Model)InventoryBag.bagModel);
            Prop[] allProps2 = World.GetAllProps((Model)InventoryBag.bagModelFull);
            Prop[] allProps3 = World.GetAllProps((Model)InventoryBag.stashedBagModel);
            if (((IEnumerable<Prop>)allProps1).Count<Prop>() > 0)
            {
                foreach (Prop prop in allProps1)
                {
                    if ((Entity)prop != (Entity)InventoryBag.cur_bag && (Entity)prop != InventoryBag.getDroppedBag(Game.Player.Character) && !prop.IsAttached() || prop.IsAttachedTo((Entity)Game.Player.Character) && (Entity)prop != (Entity)InventoryBag.cur_bag)
                        prop.Delete();
                }
            }
            if (((IEnumerable<Prop>)allProps2).Count<Prop>() > 0)
            {
                foreach (Prop prop in allProps2)
                {
                    if ((Entity)prop != (Entity)InventoryBag.cur_bag && (Entity)prop != InventoryBag.getDroppedBag(Game.Player.Character) && !prop.IsAttached() || prop.IsAttachedTo((Entity)Game.Player.Character) && (Entity)prop != (Entity)InventoryBag.cur_bag)
                        prop.Delete();
                }
            }
            if (((IEnumerable<Prop>)allProps3).Count<Prop>() > 0)
            {
                foreach (Prop prop in allProps3)
                {
                    if ((Entity)prop != (Entity)InventoryBag.cur_bag && (Entity)prop != InventoryBag.getDroppedBag(Game.Player.Character) && !prop.IsAttached() || prop.IsAttachedTo((Entity)Game.Player.Character) && (Entity)prop != (Entity)InventoryBag.cur_bag)
                        prop.Delete();
                }
            }
            if (!InventoryBag.drawStrap)
                return;
            Prop[] allProps4 = World.GetAllProps((Model)"prop_cs_heist_bag_strap_01");
            if (((IEnumerable<Prop>)allProps4).Count<Prop>() <= 0)
                return;
            foreach (Prop prop in allProps4)
            {
                if (!prop.IsAttached() && !Function.Call<bool>(Hash.IS_ENTITY_A_MISSION_ENTITY, (InputArgument)(Entity)prop))
                    prop.Delete();
            }
        }
    }
}
