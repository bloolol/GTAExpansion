// Decompiled with JetBrains decompiler
// Type: GTAExpansion.WeaponJamming
// Assembly: GTAExpansion, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 57B8053D-C566-4641-A84B-F5EB537251F0
// Assembly location: D:\SteamLibrary\steamapps\common\Grand Theft Auto V\scripts\GTAExpansion.dll

using GTA;
using GTA.Math;
using GTA.Native;
using HTools;
using System.Xml.Linq;


namespace GTAExpansion
{
    public static class WeaponJamming
    {
        public static bool jammingModeIsActive = ScriptSettings.Load("scripts\\Expansion\\Expansion.ini").GetValue<bool>("WEAPON_JAMMING", "WEAPON_JAMMING_MODE_ACTIVE", true);
        public static int fix_weapon_btn = ScriptSettings.Load("scripts\\Expansion\\Expansion.ini").GetValue<int>("WEAPON_JAMMING", "CHECK_WEAPON_BTN", 246);
        public static int clean_weapon_btn = ScriptSettings.Load("scripts\\Expansion\\Expansion.ini").GetValue<int>("WEAPON_JAMMING", "CLEAN_WEAPON_BTN", 75);
        public static int drop_weapon_btn = ScriptSettings.Load("scripts\\Expansion\\Expansion.ini").GetValue<int>("WEAPON_JAMMING", "DROP_WEAPON_BTN", 56);
        public static string briefcase_model = "prop_security_case_01";
        public static string briefcase_opened_model = "prop_security_case_02";
        public static string gun_case_small = "prop_box_guncase_01a";
        public static string gunspray_can = "prop_spraygun_01";
        public static string gunshell = "prop_sgun_casing";
        public static bool weaponIsJammed = false;
        public static int max_rnd_chance = 100;
        public static int maxShotsBeforeBadCondition = 100;
        public static int weaponsMaxShots = ScriptSettings.Load("scripts\\Expansion\\Expansion.ini").GetValue<int>("WEAPON_JAMMING", "WEAPON_MAX_SHOTS_RANDOM_PARAM", 200);
        public static bool isFixingJammedGun = false;
        public static int weaponJammingAnimTimeOut = 500;
        public static bool isCheckingWeaponCondition = false;
        public static bool isCleaningJammedGun = false;
        public static bool cleaningWeaponIsBig = false;
        public static bool cleaningRequired = false;
        public static bool hasCleaningTools = false;
        public static int cleaningToolsMax = 3;
        public static int cleaningToolsCount = 0;
        public static WeaponHash shootingWeapon = (WeaponHash)0;
        public static WeaponHash cleaningWeapon = (WeaponHash)0;
        public static int playCleaningWeaponAnimTimer = 0;
        public static int shotsFired = 0;
        public static WeaponHash[] jammedWeapons = new WeaponHash[0];
        public static int jammCounter = 0;
        public static int weaponJammingTimer = 0;
        public static bool weaponCleaningInProcess = false;
        public static bool weaponIsReady = false;
        public static Ped curWeaponJammedPlayer = Game.Player.Character;
        public static bool weaponCaseSwitched = false;
        public static bool weaponRemoveInProcess = false;
        public static int weaponToolsPrice = ScriptSettings.Load("scripts\\Expansion\\Expansion.ini").GetValue<int>("PRICES", "WEAPON_CLEANING_TOOLS_PRICE", 300);

        public static void AttachWeaponCase(Ped ped, Prop weaponCase)
        {
            int num = Function.Call<int>(Hash.GET_PED_BONE_INDEX, (InputArgument)(Entity)ped, (InputArgument)57005);
            Function.Call(Hash.ATTACH_ENTITY_TO_ENTITY, (InputArgument)(Entity)weaponCase, (InputArgument)(Entity)ped, (InputArgument)num, (InputArgument)0.1f, (InputArgument)0.06f, (InputArgument) (- 0.01f), (InputArgument)(-54f), (InputArgument) (- 75f), (InputArgument)2f, (InputArgument)true, (InputArgument)true, (InputArgument)false, (InputArgument)false, (InputArgument)2, (InputArgument)true);
        }

        public static Prop getWeaponCaseFunc(
          Ped ped,
          int caseModel,
          bool attach,
          Vector3 pos,
          bool dynamic)
        {
            Prop[] nearbyProps = World.GetNearbyProps(ped.Position, 5f, (Model)caseModel);
            Prop prop;
            if (nearbyProps.Length == 0)
            {
                prop = World.CreateProp((Model)caseModel, pos, dynamic, true);
            }
            else
            {
                prop = nearbyProps[0];
                if (!prop.IsAttachedTo((Entity)ped))
                    prop = World.CreateProp((Model)caseModel, pos, dynamic, true);
            }
            if ((Entity)prop != (Entity)null && attach)
                WeaponJamming.AttachWeaponCase(ped, prop);
            return prop;
        }

        public static void clearWeaponCase(Ped ped, int caseModel)
        {
            Prop[] allProps = World.GetAllProps((Model)caseModel);
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

        public static void clearWeaponCleaningToolsFunc(int Model, Vector3 pos)
        {
            Vector3 position = pos;
            Model[] modelArray = new Model[1] { (Model)Model };
            foreach (Prop nearbyProp in World.GetNearbyProps(position, 15f, modelArray))
            {
                if (!nearbyProp.IsAttached())
                {
                    nearbyProp.MarkAsNoLongerNeeded();
                    nearbyProp.Delete();
                }
            }
        }

        public static Prop getWeaponCleaningToolsFunc(Ped ped, int Model, Vector3 pos)
        {
            Prop[] nearbyProps = World.GetNearbyProps(pos, 5f, (Model)Model);
            return nearbyProps.Length != 0 ? nearbyProps[0] : World.CreateProp((Model)Model, pos, true, true);
        }

        public static void saveWeaponCleaningToolsFunc(Ped ped, XDocument _doc)
        {
            string name = ((PedHash)ped.Model).ToString();
            if (char.IsDigit(name[0]))
                name = "CustomPed_" + name;
            if (_doc.Element((XName)"WeaponList").Element((XName)name) == null || _doc.Element((XName)"WeaponList").Element((XName)name).Element((XName)"WeaponsConditions") == null)
                return;
            if (_doc.Element((XName)"WeaponList").Element((XName)name).Element((XName)"WeaponsConditions").Attribute((XName)"tools") == null)
                _doc.Element((XName)"WeaponList").Element((XName)name).Element((XName)"WeaponsConditions").Add((object)new XAttribute((XName)"tools", (object)true));
            else
                _doc.Element((XName)"WeaponList").Element((XName)name).Element((XName)"WeaponsConditions").Attribute((XName)"tools").Value = "true";
        }

        public static bool doesPedHasWeaponCleaningToolsFunc(Ped ped, XDocument _doc)
        {
            bool flag = false;
            string name = ((PedHash)ped.Model).ToString();
            if (char.IsDigit(name[0]))
                name = "CustomPed_" + name;
            if (_doc.Element((XName)"WeaponList").Element((XName)name) != null && _doc.Element((XName)"WeaponList").Element((XName)name).Element((XName)"WeaponsConditions") != null)
            {
                XAttribute xattribute = _doc.Element((XName)"WeaponList").Element((XName)name).Element((XName)"WeaponsConditions").Attribute((XName)"tools");
                flag = xattribute != null && xattribute.Value.ToString() == "true";
            }
            return flag;
        }

        public static int getCurWeaponTotalShots(
          Ped ped,
          XDocument _doc,
          WeaponHash shootingWeaponParam)
        {
            int weaponTotalShots = 0;
            string name = ((PedHash)ped.Model).ToString();
            if (char.IsDigit(name[0]))
                name = "CustomPed_" + name;
            if (_doc.Element((XName)"WeaponList").Element((XName)name) != null && _doc.Element((XName)"WeaponList").Element((XName)name).Element((XName)"WeaponsConditions") != null)
            {
                XElement xelement = _doc.Element((XName)"WeaponList").Element((XName)name).Element((XName)"WeaponsConditions").Element((XName)shootingWeaponParam.ToString());
                if (xelement != null && xelement.Attribute((XName)"shots") != null)
                    weaponTotalShots = Main.TryToConvertInt32(xelement.Attribute((XName)"shots").Value);
            }
            return weaponTotalShots;
        }

        public static void clearShotsForCurWeapon(
          Ped ped,
          XDocument _doc,
          WeaponHash cleaningWeaponParam)
        {
            string name = ((PedHash)ped.Model).ToString();
            if (char.IsDigit(name[0]))
                name = "CustomPed_" + name;
            if (_doc.Element((XName)"WeaponList").Element((XName)name) == null)
                _doc.Element((XName)"WeaponList").Add((object)new XElement((XName)name));
            if (_doc.Element((XName)"WeaponList").Element((XName)name) == null)
                return;
            if (_doc.Element((XName)"WeaponList").Element((XName)name).Element((XName)"WeaponsConditions") == null)
                _doc.Element((XName)"WeaponList").Element((XName)name).Add((object)new XElement((XName)"WeaponsConditions"));
            if (_doc.Element((XName)"WeaponList").Element((XName)name).Element((XName)"WeaponsConditions") == null)
                return;
            XElement xelement = _doc.Element((XName)"WeaponList").Element((XName)name).Element((XName)"WeaponsConditions").Element((XName)cleaningWeaponParam.ToString());
            if (xelement == null)
                return;
            if (xelement.Attribute((XName)"shots") != null)
                xelement.Attribute((XName)"shots").Value = 0.ToString();
            else
                xelement.Add((object)new XAttribute((XName)"shots", (object)0));
            Common.saveDoc(_doc);
        }

        public static void saveShotsForCurWeapon(
          Ped ped,
          XDocument _doc,
          int shotsFiredParam,
          WeaponHash shootingWeaponParam)
        {
            string name = ((PedHash)ped.Model).ToString();
            if (char.IsDigit(name[0]))
                name = "CustomPed_" + name;
            if (char.IsDigit(shootingWeaponParam.ToString()[0]))
                return;
            if (_doc.Element((XName)"WeaponList").Element((XName)name) == null)
                _doc.Element((XName)"WeaponList").Add((object)new XElement((XName)name));
            if (_doc.Element((XName)"WeaponList").Element((XName)name) == null)
                return;
            if (_doc.Element((XName)"WeaponList").Element((XName)name).Element((XName)"WeaponsConditions") == null)
                _doc.Element((XName)"WeaponList").Element((XName)name).Add((object)new XElement((XName)"WeaponsConditions"));
            if (_doc.Element((XName)"WeaponList").Element((XName)name).Element((XName)"WeaponsConditions") == null)
                return;
            XElement xelement = _doc.Element((XName)"WeaponList").Element((XName)name).Element((XName)"WeaponsConditions").Element((XName)shootingWeaponParam.ToString());
            if (xelement == null)
                return;
            if (xelement.Attribute((XName)"shots") != null)
                xelement.Attribute((XName)"shots").Value = (Main.TryToConvertInt32(xelement.Attribute((XName)"shots").Value) + Main.TryToConvertInt32(shotsFiredParam.ToString())).ToString();
            else
                xelement.Add((object)new XAttribute((XName)"shots", (object)Main.TryToConvertInt32(shotsFiredParam.ToString())));
            Common.saveDoc(_doc);
        }

        public static void createWeaponConditionStructure(Ped ped, XDocument _doc)
        {
            string name = ((PedHash)ped.Model).ToString();
            if (char.IsDigit(name[0]))
                name = "CustomPed_" + name;
            if (_doc.Element((XName)"WeaponList").Element((XName)name) == null)
                _doc.Element((XName)"WeaponList").Add((object)new XElement((XName)name));
            if (_doc.Element((XName)"WeaponList").Element((XName)name) == null)
                return;
            if (_doc.Element((XName)"WeaponList").Element((XName)name).Element((XName)"WeaponsConditions") == null)
                _doc.Element((XName)"WeaponList").Element((XName)name).Add((object)new XElement((XName)"WeaponsConditions"));
            if (_doc.Element((XName)"WeaponList").Element((XName)name).Element((XName)"WeaponsConditions") != null)
            {
                XElement xelement1 = _doc.Element((XName)"WeaponList").Element((XName)name).Element((XName)"WeaponsConditions");
                foreach (WeaponHash allWeaponHash in Common.allWeaponHashes)
                {
                    XElement xelement2 = xelement1.Element((XName)allWeaponHash.ToString());
                    if (xelement2 == null)
                    {
                        xelement1.Add((object)new XElement((XName)allWeaponHash.ToString()));
                        xelement2 = xelement1.Element((XName)allWeaponHash.ToString());
                    }
                    if (xelement2.Attribute((XName)"shots") == null)
                        xelement2.Add((object)new XAttribute((XName)"shots", (object)0));
                }
            }
            Common.saveDoc(_doc);
        }
    }
}
