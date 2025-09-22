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
    public static class Grip
    {
        public static bool gripModeActive = ScriptSettings.Load("scripts\\Expansion\\Expansion.ini").GetValue<bool>("GRIP_MODE", "GRIP_MODE_ACTIVE", true);
        public static int grip_toggle_btn = ScriptSettings.Load("scripts\\Expansion\\Expansion.ini").GetValue<int>("GRIP_MODE", "GRIP_TOGGLE_BTN", 29);
        public static bool toggleGrip = false;
        public static WeaponComponentHash[] grips = new WeaponComponentHash[2]
        {
      WeaponComponentHash.AtArAfGrip,
      WeaponComponentHash.AtArAfGrip02,
        };
        public static bool HasPedBoughtGrip(Ped ped)
        {
            string name = ((PedHash)ped.Model).ToString();
            if (char.IsDigit(name[0]))
                name = "CustomPed_" + name;
            if (Common.doc.Element((XName)"WeaponList").Element((XName)name) == null)
                Common.doc.Element((XName)"WeaponList").Add((object)new XElement((XName)name));
            XElement xelement = Common.doc.Element((XName)"WeaponList").Element((XName)name);
            return xelement.Attribute((XName)"Grip") != null && xelement.Attribute((XName)"Grip").Value == "true";
        }
        public static void GripToXML()
        {
            string name = ((PedHash)Game.Player.Character.Model).ToString();
            if (char.IsDigit(name[0]))
                name = "CustomPed_" + name;
            if (Common.doc.Element((XName)"WeaponList").Element((XName)name) == null)
                Common.doc.Element((XName)"WeaponList").Add((object)new XElement((XName)name));
            if (Common.doc.Element((XName)"WeaponList").Element((XName)name).Attribute((XName)"Grip") == null)
            {
                Common.doc.Element((XName)"WeaponList").Element((XName)name).Add((object)new XAttribute((XName)"Grip", (object)true));
                Common.saveDoc();
                Common.doc.Element((XName)"WeaponList").Element((XName)name).Attribute((XName)"Grip").SetValue((object)true);
                Common.saveDoc();
            }
            else
            {
                Common.doc.Element((XName)"WeaponList").Element((XName)name).Attribute((XName)"Grip").SetValue((object)true);
                Common.saveDoc();
            }

        }
        public static void GripXMLRemoval()
        {
            string name = ((PedHash)Game.Player.Character.Model).ToString();
            if (char.IsDigit(name[0]))
                name = "CustomPed_" + name;
            if (Common.doc.Element((XName)"WeaponList").Element((XName)name) == null)
                Common.doc.Element((XName)"WeaponList").Add((object)new XElement((XName)name));
            if (Common.doc.Element((XName)"WeaponList").Element((XName)name).Attribute((XName)"Grip") == null)
            {
                Common.doc.Element((XName)"WeaponList").Element((XName)name).Add((object)new XAttribute((XName)"Grip", (object)false));
                Common.saveDoc();
                Common.doc.Element((XName)"WeaponList").Element((XName)name).Attribute((XName)"Grip").SetValue((object)false);
                Common.saveDoc();
            }
            else
            {
                Common.doc.Element((XName)"WeaponList").Element((XName)name).Attribute((XName)"Grip").SetValue((object)false);
                Common.saveDoc();
            }


        }

        public static void gripcheck()
        {
            foreach (WeaponComponentHash Grip in Grip.grips)
            {
                if (Function.Call<bool>(Hash.HAS_PED_GOT_WEAPON_COMPONENT, (InputArgument)(Entity)Game.Player.Character, (InputArgument)(Enum)Game.Player.Character.Weapons.Current.Hash, (InputArgument)(Enum)Grip))
                {
                    GripToXML();
                    break;
                }
            }
        }
    }
}
