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
    public static class Scope
    {
        public static bool scopeModeActive = ScriptSettings.Load("scripts\\Expansion\\Expansion.ini").GetValue<bool>("SCOPE_MODE", "SCOPE_MODE_ACTIVE", true);
        public static int scope_toggle_btn = ScriptSettings.Load("scripts\\Expansion\\Expansion.ini").GetValue<int>("SCOPE_MODE", "SCOPE_TOGGLE_BTN", 56);
        public static bool toggleScope = false;
        public static WeaponComponentHash[] scopes = new WeaponComponentHash[18]
        {
      WeaponComponentHash.AtScopeLarge,
      WeaponComponentHash.AtScopeLargeFixedZoom,
      WeaponComponentHash.AtScopeLargeFixedZoomMk2,
      WeaponComponentHash.AtScopeLargeMk2,
      WeaponComponentHash.AtScopeMacro,
      WeaponComponentHash.AtScopeMacro02,
      WeaponComponentHash.AtScopeMacro02Mk2,
      WeaponComponentHash.AtScopeMacro02SMGMk2,
      WeaponComponentHash.AtScopeMacroMk2,
      WeaponComponentHash.AtScopeMax,
      WeaponComponentHash.AtScopeMedium,
      WeaponComponentHash.AtScopeMediumMk2,
      WeaponComponentHash.AtScopeNV,
      WeaponComponentHash.AtScopeSmall,
      WeaponComponentHash.AtScopeSmall02,
      WeaponComponentHash.AtScopeSmallMk2,
      WeaponComponentHash.AtScopeSmallSMGMk2,
      WeaponComponentHash.AtScopeThermal,
        };
        public static bool HasPedBoughtScope(Ped ped)
        {
            string name = ((PedHash)ped.Model).ToString();
            if (char.IsDigit(name[0]))
                name = "CustomPed_" + name;
            if (Common.doc.Element((XName)"WeaponList").Element((XName)name) == null)
                Common.doc.Element((XName)"WeaponList").Add((object)new XElement((XName)name));
            XElement xelement = Common.doc.Element((XName)"WeaponList").Element((XName)name);
            return xelement.Attribute((XName)"Scope") != null && xelement.Attribute((XName)"Scope").Value == "true";
        }
        public static void ScopeToXML()
        {
            string name = ((PedHash)Game.Player.Character.Model).ToString();
            if (char.IsDigit(name[0]))
                name = "CustomPed_" + name;
            if (Common.doc.Element((XName)"WeaponList").Element((XName)name) == null)
                Common.doc.Element((XName)"WeaponList").Add((object)new XElement((XName)name));
            if (Common.doc.Element((XName)"WeaponList").Element((XName)name).Attribute((XName)"Scope") == null)
            {
                Common.doc.Element((XName)"WeaponList").Element((XName)name).Add((object)new XAttribute((XName)"Scope", (object)true));
                Common.saveDoc();
                Common.doc.Element((XName)"WeaponList").Element((XName)name).Attribute((XName)"Scope").SetValue((object)true);
                Common.saveDoc();
            }
            else if (Common.doc.Element((XName)"WeaponList").Element((XName)name).Attribute((XName)"Scope").Value == (object)false)
            {
                Common.doc.Element((XName)"WeaponList").Element((XName)name).Attribute((XName)"Scope").SetValue((object)true);
                Common.saveDoc();
            }

        }

        public static void ScopeXMLRemoval()
        {
            string name = ((PedHash)Game.Player.Character.Model).ToString();
            if (char.IsDigit(name[0]))
                name = "CustomPed_" + name;
            if (Common.doc.Element((XName)"WeaponList").Element((XName)name) == null)
                Common.doc.Element((XName)"WeaponList").Add((object)new XElement((XName)name));
            if (Common.doc.Element((XName)"WeaponList").Element((XName)name).Attribute((XName)"Scope") == null)
            {
                Common.doc.Element((XName)"WeaponList").Element((XName)name).Add((object)new XAttribute((XName)"Scope", (object)false));
                Common.saveDoc();
                Common.doc.Element((XName)"WeaponList").Element((XName)name).Attribute((XName)"Scope").SetValue((object)false);
                Common.saveDoc();
            }
            else if ((Common.doc.Element((XName)"WeaponList").Element((XName)name).Attribute((XName)"Scope").Value == (object)true))
            {
                

                Common.doc.Element((XName)"WeaponList").Element((XName)name).Attribute((XName)"Scope").SetValue((object)false);
                Common.saveDoc();
            }


        }
        public static void scopecheck()
        {
            var player = Game.Player.Character;
            var weaponHash = player.Weapons.Current.Hash;
            foreach (WeaponComponentHash scope in Scope.scopes)
            {
                if (Function.Call<bool>(Hash.HAS_PED_GOT_WEAPON_COMPONENT, (InputArgument)(Entity)player, (InputArgument)(Enum)weaponHash, (InputArgument)(Enum)scope))
                {
                    ScopeToXML();
                    break;
                }
            }
        }

    }
}
