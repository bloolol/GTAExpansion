// Decompiled with JetBrains decompiler
// Type: GTAExpansion.OnFootRadio
// Assembly: GTAExpansion, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 57B8053D-C566-4641-A84B-F5EB537251F0
// Assembly location: D:\SteamLibrary\steamapps\common\Grand Theft Auto V\scripts\GTAExpansion.dll

using GTA;
using System.Xml.Linq;


namespace GTAExpansion
{
    public static class OnFootRadio
    {
        public static int earphone_toggle_btn = ScriptSettings.Load("scripts\\Expansion\\Expansion.ini").GetValue<int>("EAR_RADIO_SETTINGS", "EARPHONE_TOGGLE_KEY", 249);
        public static int readio_off_btn = ScriptSettings.Load("scripts\\Expansion\\Expansion.ini").GetValue<int>("EAR_RADIO_SETTINGS", "TURN_OFF_RADIO", 174);
        public static int prevStation = (int)byte.MaxValue;
        public static bool headset;
        public static int earRadioTimer = 0;
        public static bool isHeadsetBought = false;
        public static int HeadsetPrice = ScriptSettings.Load("scripts\\Expansion\\Expansion.ini").GetValue<int>("PRICES", "EARPHONES_PRICE", 100);
        public static int timeReference = 0;
        public static bool headset_module_active = ScriptSettings.Load("scripts\\Expansion\\Expansion.ini").GetValue<bool>("HEADSET_SETTINGS", "HEADSET_MODULE_ACTIVE", true);


        public static void PlayerBoughtHeadset(Ped ped)
        {
            if (ped == null || !ped.Exists()) return;

            string name = ((PedHash)ped.Model).ToString();
            if (char.IsDigit(name[0]))
                name = "CustomPed_" + name;

            XElement weaponList = Common.doc.Element("WeaponList");
            XElement pedElement = weaponList?.Element(name);

            if (pedElement == null)
            {
                pedElement = new XElement(name);
                weaponList.Add(pedElement);
            }

            XAttribute headsetAttr = pedElement.Attribute("headset");
            if (headsetAttr == null)
            {
                pedElement.SetAttributeValue("headset", "true");
            }
            else
            {
                headsetAttr.Value = "true";
            }

            Common.saveDoc();
        }







        public static bool HasPedBoughtHeadset(Ped ped)
        {
            string name = ((PedHash)ped.Model).ToString();
            if (char.IsDigit(name[0]))
                name = "CustomPed_" + name;

            XElement weaponList = Common.doc.Element((XName)"WeaponList");
            XElement pedElement = weaponList.Element((XName)name);

            if (pedElement == null)
            {
                pedElement = new XElement((XName)name);
                weaponList.Add(pedElement);
            }

            XAttribute headsetAttr = pedElement.Attribute((XName)"headset");
            return headsetAttr != null && headsetAttr.Value == "true";
        }



    }
}
