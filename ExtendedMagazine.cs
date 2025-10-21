using GTA;
using GTA.Native;
using System;
using System.Xml.Linq;

namespace GTAExpansion
{
    public static class ExtendedMagazine
    {
        public static bool ModeActive = ScriptSettings.Load("scripts\\Expansion\\Expansion.ini")
            .GetValue("EXTENDEDMAGAZINE_MODE", "EXTENDEDMAGAZINE_MODE_ACTIVE", true);

        public static int ToggleButton = ScriptSettings.Load("scripts\\Expansion\\Expansion.ini")
            .GetValue("EXTENDEDMAGAZINE_MODE", "EXTENDEDMAGAZINE_TOGGLE_BTN", 47);

        public static bool ToggleState = false;

        public static readonly (WeaponHash weapon, WeaponComponentHash component)[] ExtendedMagazines = new[]
        {
            // Pistols
            (WeaponHash.Pistol, WeaponComponentHash.PistolClip02),
            (WeaponHash.CombatPistol, WeaponComponentHash.CombatPistolClip02),
            (WeaponHash.APPistol, WeaponComponentHash.APPistolClip02),
            (WeaponHash.Pistol50, WeaponComponentHash.Pistol50Clip02),
            (WeaponHash.SNSPistol, WeaponComponentHash.SNSPistolClip02),
            (WeaponHash.HeavyPistol, WeaponComponentHash.HeavyPistolClip02),
            (WeaponHash.VintagePistol, WeaponComponentHash.VintagePistolClip02),
            (WeaponHash.CeramicPistol, WeaponComponentHash.CeramicPistolClip02),
            (WeaponHash.PistolMk2, WeaponComponentHash.PistolMk2Clip02),

            // SMGs
            (WeaponHash.MicroSMG, WeaponComponentHash.MicroSMGClip02),
            (WeaponHash.SMG, WeaponComponentHash.SMGClip02),
            (WeaponHash.AssaultSMG, WeaponComponentHash.AssaultSMGClip02),
            (WeaponHash.CombatPDW, WeaponComponentHash.CombatPDWClip02),
            (WeaponHash.MachinePistol, WeaponComponentHash.MachinePistolClip02),
            (WeaponHash.MiniSMG, WeaponComponentHash.MiniSMGClip02),
            (WeaponHash.SMGMk2, WeaponComponentHash.SMGMk2Clip02),

            // Rifles
            (WeaponHash.AssaultRifle, WeaponComponentHash.AssaultRifleClip02),
            (WeaponHash.CarbineRifle, WeaponComponentHash.CarbineRifleClip02),
            (WeaponHash.AdvancedRifle, WeaponComponentHash.AdvancedRifleClip02),
            (WeaponHash.SpecialCarbine, WeaponComponentHash.SpecialCarbineClip02),
            (WeaponHash.BullpupRifle, WeaponComponentHash.BullpupRifleClip02),
            (WeaponHash.CompactRifle, WeaponComponentHash.CompactRifleClip02),
            (WeaponHash.MilitaryRifle, WeaponComponentHash.MilitaryRifleClip02),
            (WeaponHash.HeavyRifle, WeaponComponentHash.HeavyRifleClip02),
            (WeaponHash.ServiceCarbine, WeaponComponentHash.ServiceCarbineClip02),
            (WeaponHash.AssaultrifleMk2, WeaponComponentHash.AssaultRifleMk2Clip02),
            (WeaponHash.CarbineRifleMk2, WeaponComponentHash.CarbineRifleMk2Clip02),

            // Shotguns
            (WeaponHash.AssaultShotgun, WeaponComponentHash.AssaultShotgunClip02),
            (WeaponHash.HeavyShotgun, WeaponComponentHash.HeavyShotgunClip02),

            // Snipers
        //    (WeaponHash.SniperRifle, WeaponComponentHash.Sniper),
          //  (WeaponHash.HeavySniper, WeaponComponentHash.HeavySniperClip02),
            (WeaponHash.MarksmanRifle, WeaponComponentHash.MarksmanRifleClip02),
            (WeaponHash.HeavySniperMk2, WeaponComponentHash.HeavySniperMk2Clip02),
            (WeaponHash.MarksmanRifleMk2, WeaponComponentHash.MarksmanRifleMk2Clip02),

            // Machine Guns
            (WeaponHash.MG, WeaponComponentHash.MGClip02),
            (WeaponHash.CombatMG, WeaponComponentHash.CombatMGClip02),
            (WeaponHash.Gusenberg, WeaponComponentHash.GusenbergClip02),
            (WeaponHash.CombatMGMk2, WeaponComponentHash.CombatMGMk2Clip02)
        };

        public static void CheckExtendedMagazine()
        {
            Ped player = Game.Player.Character;
            WeaponHash currentWeapon = player.Weapons.Current.Hash;

            foreach (var (weapon, component) in ExtendedMagazines)
            {
                if (currentWeapon == weapon &&
                    Function.Call<bool>(Hash.HAS_PED_GOT_WEAPON_COMPONENT, player, weapon, component))
                {
                    Common.UpdateAttachment("ExtendedMagazine", true);
                    break;
                }
            }
        }

        public static bool HasPedBoughtExtendedMagazine(Ped ped)
        {
            string pedName = NormalizePedName(ped);
            XElement weaponList = Common.doc.Element("WeaponList");
            XElement pedElement = weaponList.Element(pedName);

            if (pedElement == null)
            {
                pedElement = new XElement(pedName);
                weaponList.Add(pedElement);
            }

            XAttribute attr = pedElement.Attribute("ExtendedMagazine");
            return attr != null && attr.Value == "true";
        }

        public static void SaveExtendedMagazineToXML()
        {
            string pedName = NormalizePedName(Game.Player.Character);
            XElement weaponList = Common.doc.Element("WeaponList");
            XElement pedElement = weaponList.Element(pedName);

            if (pedElement == null)
            {
                pedElement = new XElement(pedName);
                weaponList.Add(pedElement);
            }

            XAttribute attr = pedElement.Attribute("ExtendedMagazine");
            if (attr == null)
            {
                pedElement.Add(new XAttribute("ExtendedMagazine", true));
            }
            else
            {
                attr.SetValue(true);
            }

            Common.saveDoc();
        }

        public static void RemoveExtendedMagazineFromXML()
        {
            string pedName = NormalizePedName(Game.Player.Character);
            XElement weaponList = Common.doc.Element("WeaponList");
            XElement pedElement = weaponList.Element(pedName);

            if (pedElement == null)
            {
                pedElement = new XElement(pedName);
                weaponList.Add(pedElement);
            }

            XAttribute attr = pedElement.Attribute("ExtendedMagazine");
            if (attr == null)
            {
                pedElement.Add(new XAttribute("ExtendedMagazine", false));
            }
            else
            {
                attr.SetValue(false);
            }

            Common.saveDoc();
        }

        private static string NormalizePedName(Ped ped)
        {
            string name = ((PedHash)ped.Model).ToString();
            return char.IsDigit(name[0]) ? "CustomPed_" + name : name;
        }
    }
}