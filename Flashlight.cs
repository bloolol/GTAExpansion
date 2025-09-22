using GTA;
using GTA.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GTAExpansion
{
    public static class Flashlight
    {
        public static bool flashlightModeActive = ScriptSettings.Load("scripts\\Expansion\\Expansion.ini").GetValue<bool>("FLASHLIGHT_MODE", "FLASHLIGHT_MODE_ACTIVE", true);
        public static int flashlight_toggle_btn = ScriptSettings.Load("scripts\\Expansion\\Expansion.ini").GetValue<int>("FLASHLIGHT_MODE", "FLASHLIGHT_TOGGLE_BTN", 47);
        public static bool toggleFlashlight = false;
        public static WeaponComponentHash[] flashlights = new WeaponComponentHash[5]
        {
      WeaponComponentHash.AtArFlsh,
      WeaponComponentHash.AtArFlshReh,
      WeaponComponentHash.AtPiFlsh,
      WeaponComponentHash.AtPiFlsh02,
      WeaponComponentHash.AtPiFlsh03,
        };
        public static bool HasPedBoughtFlashlight(Ped ped)
        {
            string name = ((PedHash)ped.Model).ToString();
            if (char.IsDigit(name[0]))
                name = "CustomPed_" + name;
            if (Common.doc.Element((XName)"WeaponList").Element((XName)name) == null)
                Common.doc.Element((XName)"WeaponList").Add((object)new XElement((XName)name));
            XElement xelement = Common.doc.Element((XName)"WeaponList").Element((XName)name);
            return xelement.Attribute((XName)"Flashlight") != null && xelement.Attribute((XName)"Flashlight").Value == "true";
        }
        public static void FlashlightToXML()
        {
            string name = ((PedHash)Game.Player.Character.Model).ToString();
            if (char.IsDigit(name[0]))
                name = "CustomPed_" + name;
            if (Common.doc.Element((XName)"WeaponList").Element((XName)name) == null)
                Common.doc.Element((XName)"WeaponList").Add((object)new XElement((XName)name));
            if (Common.doc.Element((XName)"WeaponList").Element((XName)name).Attribute((XName)"Flashlight") == null)
            {
                Common.doc.Element((XName)"WeaponList").Element((XName)name).Add((object)new XAttribute((XName)"Flashlight", (object)true));
                Common.saveDoc();
                Common.doc.Element((XName)"WeaponList").Element((XName)name).Attribute((XName)"Flashlight").SetValue((object)true);
                Common.saveDoc();
            }
            else
            {
                Common.doc.Element((XName)"WeaponList").Element((XName)name).Attribute((XName)"Flashlight").SetValue((object)true);
                Common.saveDoc();
            }

        }
        public static void FlaghlightXMLRemoval()
        {
            string name = ((PedHash)Game.Player.Character.Model).ToString();
            if (char.IsDigit(name[0]))
                name = "CustomPed_" + name;
            if (Common.doc.Element((XName)"WeaponList").Element((XName)name) == null)
                Common.doc.Element((XName)"WeaponList").Add((object)new XElement((XName)name));
            if (Common.doc.Element((XName)"WeaponList").Element((XName)name).Attribute((XName)"Flashlight") == null)
            {
                Common.doc.Element((XName)"WeaponList").Element((XName)name).Add((object)new XAttribute((XName)"Flashlight", (object)false));
                Common.saveDoc();
                Common.doc.Element((XName)"WeaponList").Element((XName)name).Attribute((XName)"Flashlight").SetValue((object)false);
                Common.saveDoc();
            }
            else
            {
                Common.doc.Element((XName)"WeaponList").Element((XName)name).Attribute((XName)"Flashlight").SetValue((object)false);
                Common.saveDoc();
            }


        }
        public static void flashlightcheck()
        {
            foreach (WeaponComponentHash flashlight in Flashlight.flashlights)
            {
                if (Function.Call<bool>(Hash.HAS_PED_GOT_WEAPON_COMPONENT, (InputArgument)(Entity)Game.Player.Character, (InputArgument)(Enum)Game.Player.Character.Weapons.Current.Hash, (InputArgument)(Enum)flashlight))
                {
                    FlashlightToXML();
                    break;
                }
            }
        }
    }
}
