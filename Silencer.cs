// Decompiled with JetBrains decompiler
// Type: GTAExpansion.Silencer
// Assembly: GTAExpansion, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 57B8053D-C566-4641-A84B-F5EB537251F0
// Assembly location: D:\SteamLibrary\steamapps\common\Grand Theft Auto V\scripts\GTAExpansion.dll

using GTA;
using GTA.Native;
using System;
using System.Drawing;
using System.Xml.Linq;


namespace GTAExpansion
{
    public static class Silencer
    {
        public static bool silencerModeActive = ScriptSettings.Load("scripts\\Expansion\\Expansion.ini").GetValue<bool>("SILENCER_MODE", "SILENCER_MODE_ACTIVE", true);
        public static int silencer_toggle_btn = ScriptSettings.Load("scripts\\Expansion\\Expansion.ini").GetValue<int>("SILENCER_MODE", "SILENCER_TOGGLE_BTN", 52);
        public static bool toggleSilencer = false;
        public static WeaponComponentHash[] silencers = new WeaponComponentHash[7]
        {
      WeaponComponentHash.AtArSupp,
      WeaponComponentHash.AtArSupp02,
      WeaponComponentHash.AtPiSupp,
      WeaponComponentHash.AtPiSupp02,
      WeaponComponentHash.AtSrSupp,
      WeaponComponentHash.AtSrSupp03,
      WeaponComponentHash.CeramicPistolSupp
        };
        public static bool HasPedBoughtSilencer(Ped ped)
        {

            string name = ((PedHash)ped.Model).ToString();
            if (char.IsDigit(name[0]))
                name = "CustomPed_" + name;
            if (Common.doc.Element((XName)"WeaponList").Element((XName)name) == null)
                Common.doc.Element((XName)"WeaponList").Add((object)new XElement((XName)name));
            XElement xelement = Common.doc.Element((XName)"WeaponList").Element((XName)name);
            return xelement.Attribute((XName)"Silencer") != null && xelement.Attribute((XName)"Silencer").Value == "true";
        }
        public static void SilencerToXML()
        {
            string name = ((PedHash)Game.Player.Character.Model).ToString();
            if (char.IsDigit(name[0]))
                name = "CustomPed_" + name;
            if (Common.doc.Element((XName)"WeaponList").Element((XName)name) == null)
                Common.doc.Element((XName)"WeaponList").Add((object)new XElement((XName)name));
            if (Common.doc.Element((XName)"WeaponList").Element((XName)name).Attribute((XName)"Silencer") == null)
            {
                Common.doc.Element((XName)"WeaponList").Element((XName)name).Add((object)new XAttribute((XName)"Silencer", (object)true));
                Common.saveDoc();
                Common.doc.Element((XName)"WeaponList").Element((XName)name).Attribute((XName)"Silencer").SetValue((object)true);
                Common.saveDoc();
            }
            else if (Common.doc.Element((XName)"WeaponList").Element((XName)name).Attribute((XName)"Silencer").Value == "false")
            {
                Common.doc.Element((XName)"WeaponList").Element((XName)name).Attribute((XName)"Silencer").SetValue((object)true);
                Common.saveDoc();
            }

        }
       public static void SilencerXMLRemoval()
        {
            string name = ((PedHash)Game.Player.Character.Model).ToString();
            if (char.IsDigit(name[0]))
                name = "CustomPed_" + name;
            if (Common.doc.Element((XName)"WeaponList").Element((XName)name) == null)
                Common.doc.Element((XName)"WeaponList").Add((object)new XElement((XName)name));
            if (Common.doc.Element((XName)"WeaponList").Element((XName)name).Attribute((XName)"Silencer") == null)
            {
                Common.doc.Element((XName)"WeaponList").Element((XName)name).Add((object)new XAttribute((XName)"Silencer", (object)false));
                Common.saveDoc();
                Common.doc.Element((XName)"WeaponList").Element((XName)name).Attribute((XName)"Silencer").SetValue((object)false);
                Common.saveDoc();
            }
            else if ((Common.doc.Element((XName)"WeaponList").Element((XName)name).Attribute((XName)"Silencer").Value == (object)true))

            {
                
                    Common.doc.Element((XName)"WeaponList").Element((XName)name).Attribute((XName)"Silencer").SetValue((object)false);
                    Common.saveDoc();
                
            }

            return;

        }
        public static void silencercheck()
        {
            if (Common.GetAttachmentState("Silencer") == true)
                return;

            var player = Game.Player.Character;
            var weaponHash = player.Weapons.Current.Hash;


            foreach (WeaponComponentHash silencer in Silencer.silencers)
            {
                if (Function.Call<bool>(Hash.HAS_PED_GOT_WEAPON_COMPONENT, (InputArgument)(Entity)player, (InputArgument)(Enum)weaponHash, (InputArgument)(Enum)silencer))
                {
                   Common.UpdateAttachment("Silencer", true);
                    

                    break;
                }
            }
        }
    }
}
