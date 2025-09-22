using ExpansionEnums;
using GTA;
using GTA.Native;
using GTA.UI;
using HTools;
using NativeUI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection.Emit;
using System.Xml.Linq;

namespace GTAExpansion
{
    public static class Vest
    {
        public static int vest_menu_btn = ScriptSettings.Load("scripts\\Expansion\\Expansion.ini").GetValue<int>("VEST", "VEST_MENU_BTN", 22);
        public static MenuPool modMenuPool;
        public static UIMenu mainMenu;
        public static List<object> mainMenuListString = new List<object>();
        public static Color btnColor1 = Color.Transparent;
        public static Color btnColor2 = Color.GhostWhite;
        public static Color btnTextColor1 = Color.White;
        public static Color btnTextColor2 = Color.Black;
        public static List<WeaponHash> stashedWeapons = new List<WeaponHash>();
        public static List<WeaponHash> characterWeapons = new List<WeaponHash>();
        public static bool inMenu = false;
        public static bool armortakenoff = false;
        public static int armorlevel;
        public static void Setup(Ped ped)
        {
            Vest.modMenuPool = new MenuPool();
            Vest.mainMenu = new UIMenu("Vest Menu", "Select option");
            Vest.modMenuPool.Add(Vest.mainMenu);
            Vest.mainMenu.OnMenuClose += new MenuCloseEvent(Vest.onMenuClose);
            //UIMenu uiMenu1 = new UIMenu("Stash weapon", "Select Weapon");
            //UIMenu uiMenu2 = new UIMenu("Take weapon", "Select Weapon");
            //UIMenu uiMenu5 = new UIMenu("Stash item", "Select Item");
            //UIMenu uiMenu6 = new UIMenu("Take item", "Select Item");
            UIMenu uiMenu1 = new UIMenu("Auxillary", "Select Item");
            UIMenu uiMenu2 = new UIMenu("Admin Pouch", "Select Item");
            UIMenu uiMenu5 = new UIMenu("Triple Magazine Pouch", "Select Item");
            UIMenu uiMenu6 = new UIMenu("Pistol Magazine Pouch #1", "Select Item");
            UIMenu uiMenu7 = new UIMenu("Pistol Magazine Pouch #2", "Select Item");
            UIMenu uiMenu8 = new UIMenu("General Purpose Pouch #1", "Select Item");
            UIMenu uiMenu9 = new UIMenu("General Purpose Pouch #2", "Select Item");
            UIMenu uiMenu10 = new UIMenu("Hanger Pouch", "Select Item");
            UIMenuColoredItem StashItem = new UIMenuColoredItem("Stash", Vest.btnColor1, Vest.btnColor2);
            StashItem.SetRightBadge(UIMenuItem.BadgeStyle.Ammo);
            StashItem.TextColor = Vest.btnTextColor1;
            StashItem.HighlightedTextColor = Vest.btnTextColor2;
            UIMenuColoredItem TakeItem = new UIMenuColoredItem("Take", Vest.btnColor1, Vest.btnColor2);
            TakeItem.SetRightBadge(UIMenuItem.BadgeStyle.Ammo);
            TakeItem.TextColor = Vest.btnTextColor1;
            TakeItem.HighlightedTextColor = Vest.btnTextColor2;
            UIMenuColoredItem RemoveArmor = new UIMenuColoredItem("Take off armor", Vest.btnColor1, Vest.btnColor2);
            UIMenuColoredItem EquipArmor = new UIMenuColoredItem("Equip armor", Vest.btnColor1, Vest.btnColor2);
            UIMenuColoredItem ReplaceArmorPlate = new UIMenuColoredItem("Replace armor plates", Vest.btnColor1, Vest.btnColor2);
            UIMenuColoredItem CloseMenu = new UIMenuColoredItem("Exit", Color.Transparent, Color.GhostWhite);
            ReplaceArmorPlate.SetRightBadge(UIMenuItem.BadgeStyle.Clothes);
            ReplaceArmorPlate.TextColor = Vest.btnTextColor1;
            ReplaceArmorPlate.HighlightedTextColor = Vest.btnTextColor2;
            EquipArmor.SetRightBadge(UIMenuItem.BadgeStyle.Clothes);
            EquipArmor.TextColor = Vest.btnTextColor1;
            EquipArmor.HighlightedTextColor = Vest.btnTextColor2;
            RemoveArmor.SetRightBadge(UIMenuItem.BadgeStyle.Tick);
            CloseMenu.SetRightBadge(UIMenuItem.BadgeStyle.Lock);
            CloseMenu.TextColor = Vest.btnTextColor1;
            CloseMenu.HighlightedTextColor = Vest.btnTextColor2;
            RemoveArmor.SetRightBadge(UIMenuItem.BadgeStyle.Clothes);
            RemoveArmor.TextColor = Vest.btnTextColor1;
            RemoveArmor.HighlightedTextColor = Vest.btnTextColor2;
            string character = ((PedHash)ped.Model).ToString();
            if (char.IsDigit(character[0]))
                character = "CustomPed_" + character;
            if (Common.doc.Element((XName)"WeaponList").Element((XName)character) == null)
                Common.doc.Element((XName)"WeaponList").Add((object)new XElement((XName)character));
           /* if (!Vest.mainMenuListString.Contains((object)uiMenu1))
            {
                Vest.mainMenuListString.Add((object)uiMenu1);
                UIMenu uiMenu11 = Vest.modMenuPool.AddSubMenu(Vest.mainMenu, "Auxillary");
                Vest.mainMenu.CurrentSelection = 0;
                if (Common.doc.Element((XName)"WeaponList").Element((XName)character) != null && Common.doc.Element((XName)"WeaponList").Element((XName)character).Element((XName)"Auxillary") != null && Common.doc.Element((XName)"WeaponList").Element((XName)character).Element((XName)"Auxillary").Elements() != null)
                {
                    foreach (XElement element in Common.doc.Element((XName)"WeaponList").Element((XName)character).Element((XName)"Auxillary").Elements())
                    {
                        foreach (Prop AuxProp in Common.AuxillaryProps)
                        {
                            if (element.Name.ToString() == AuxProp.ToString())
                            {

                                        UIMenuCheckboxItem menuCheckboxItem = new UIMenuCheckboxItem(element.Name.ToString(), false);
                                        if (!uiMenu11.MenuItems.Contains((UIMenuItem)menuCheckboxItem))
                                            uiMenu11.AddItem((UIMenuItem)menuCheckboxItem);
                                    
                                
                            }
                        }
                    }
                }
                else if (Common.doc.Element((XName)"WeaponList").Element((XName)character) == null && Common.doc.Element((XName)"WeaponList").Element((XName)character).Element((XName)"Auxillary") == null && Common.doc.Element((XName)"WeaponList").Element((XName)character).Element((XName)"Auxillary").Elements() == null)
                {

                    if (!Vest.mainMenuListString.Contains((object)uiMenu1))
                    {
                        Vest.mainMenuListString.Add((object)uiMenu1);
                        UIMenu uiMenu4 = Vest.modMenuPool.AddSubMenu(Vest.mainMenu, "Auxillary");
                        Vest.mainMenu.CurrentSelection = 0;
                        foreach (WeaponHash allWeaponHash in Common.allWeaponHashes)
                        {
                            if (ped.Weapons.HasWeapon(allWeaponHash))
                            {
                                UIMenuCheckboxItem menuCheckboxItem = new UIMenuCheckboxItem(allWeaponHash.ToString(), false);
                                if (!uiMenu4.MenuItems.Contains((UIMenuItem)menuCheckboxItem) && allWeaponHash != WeaponHash.Unarmed && allWeaponHash != WeaponHash.Parachute)
                                    uiMenu4.AddItem((UIMenuItem)menuCheckboxItem);
                            }
                        }
                        if (!uiMenu4.MenuItems.Contains((UIMenuItem)StashItem))
                            uiMenu4.AddItem((UIMenuItem)StashItem);
                        uiMenu4.OnItemSelect += (ItemSelectEvent)((sender, item, index) =>
                        {
                            if (item != StashItem)
                                return;
                            XElement xelement1 = Common.doc.Element((XName)"WeaponList").Element((XName)character);
                            if (xelement1.Element((XName)"AmmoType_Admin_Pouch") == null)
                                xelement1.Add((object)new XElement((XName)"AmmoType_Admin_Pouch"));
                            object[] names = (object[])Enum.GetNames(typeof(eAmmoType));
                            Array values = Enum.GetValues(typeof(eAmmoType));
                            for (int index2 = 0; index2 < names.Length; ++index2)
                            {
                                string name = names[index2].ToString();
                                int content = Function.Call<int>(Hash.GET_PED_AMMO_BY_TYPE, (InputArgument)(Entity)ped, (InputArgument)(uint)values.GetValue(index2));
                                if (content > 0)
                                {
                                    if (xelement1.Element((XName)"AmmoType_Admin_Pouch").Element((XName)name) == null)
                                        xelement1.Element((XName)"AmmoType_Admin_Pouch").Add((object)new XElement((XName)name, (object)content));
                                    else
                                        xelement1.Element((XName)"AmmoType_Admin_Pouch").Element((XName)name).Value = content.ToString();
                                }
                            }
                            if (xelement1.Element((XName)"Weapons_Admin_Pouch") == null)
                                xelement1.Add((object)new XElement((XName)"Weapons_Admin_Pouch"));
                            XElement xelement2 = xelement1.Element((XName)"Weapons_Admin_Pouch");
                            foreach (WeaponHash characterWeapon in Vest.characterWeapons)
                            {
                                int content = Function.Call<int>(Hash.GET_AMMO_IN_PED_WEAPON, (InputArgument)(Entity)ped, (InputArgument)(int)characterWeapon);
                                if (Function.Call<uint>(Hash.GET_WEAPONTYPE_GROUP, (InputArgument)(int)characterWeapon) != 2685387236U && Function.Call<uint>(Hash.GET_WEAPONTYPE_GROUP, (InputArgument)(int)characterWeapon) != 3566412244U)
                                {
                                    if (xelement2.Element((XName)characterWeapon.ToString()) == null)
                                    {
                                        if (characterWeapon != WeaponHash.Unarmed)
                                        {
                                            xelement2.Add((object)new XElement((XName)characterWeapon.ToString(), (object)new XElement((XName)"AMMO_Admin_Pouch", (object)content)));
                                            foreach (WeaponComponentHash allComponentsHash in Common.allComponentsHashes)
                                            {
                                                bool flag = Function.Call<bool>(Hash.HAS_PED_GOT_WEAPON_COMPONENT, (InputArgument)(Entity)ped, (InputArgument)(int)characterWeapon, (InputArgument)(int)allComponentsHash);
                                                if (xelement2.Element((XName)characterWeapon.ToString()).Element((XName)allComponentsHash.ToString()) == null & flag)
                                                    xelement2.Element((XName)characterWeapon.ToString()).Add((object)new XElement((XName)allComponentsHash.ToString()));
                                            }
                                            foreach (WeaponTint allTintHash in Common.allTintHashes)
                                            {
                                                int num = Function.Call<int>(Hash.GET_PED_WEAPON_TINT_INDEX, (InputArgument)(Entity)ped, (InputArgument)(int)characterWeapon);
                                                if (allTintHash == (WeaponTint)num)
                                                {
                                                    if (xelement2.Element((XName)characterWeapon.ToString()).Attribute((XName)"tint_Admin_Pouch") == null)
                                                        xelement2.Element((XName)characterWeapon.ToString()).Add((object)new XAttribute((XName)"tint_Admin_Pouch", (object)allTintHash.ToString()));
                                                    else
                                                        xelement2.Element((XName)characterWeapon.ToString()).Attribute((XName)"tint_Admin_Pouch").Value = allTintHash.ToString();
                                                }
                                            }
                                            if (characterWeapon != WeaponHash.Unarmed)
                                                Function.Call(Hash.REMOVE_WEAPON_FROM_PED, (InputArgument)(Entity)ped, (InputArgument)(int)characterWeapon);
                                        }
                                    }
                                    else if (xelement2.Element((XName)characterWeapon.ToString()).Element((XName)"AMMO_Admin_Pouch") == null)
                                    {
                                        xelement2.Element((XName)characterWeapon.ToString()).Add((object)new XElement((XName)"AMMO_Admin_Pouch", (object)content));
                                        foreach (WeaponComponentHash allComponentsHash in Common.allComponentsHashes)
                                        {
                                            bool flag = Function.Call<bool>(Hash.HAS_PED_GOT_WEAPON_COMPONENT, (InputArgument)(Entity)ped, (InputArgument)(int)characterWeapon, (InputArgument)(int)allComponentsHash);
                                            if (xelement2.Element((XName)characterWeapon.ToString()).Element((XName)allComponentsHash.ToString()) == null & flag)
                                                xelement2.Element((XName)characterWeapon.ToString()).Add((object)new XElement((XName)allComponentsHash.ToString()));
                                        }
                                        foreach (WeaponTint allTintHash in Common.allTintHashes)
                                        {
                                            int num = Function.Call<int>(Hash.GET_PED_WEAPON_TINT_INDEX, (InputArgument)(Entity)ped, (InputArgument)(int)characterWeapon);
                                            if (allTintHash == (WeaponTint)num)
                                            {
                                                if (xelement2.Element((XName)characterWeapon.ToString()).Attribute((XName)"tint_Admin_Pouch") == null)
                                                    xelement2.Element((XName)characterWeapon.ToString()).Add((object)new XAttribute((XName)"tint_Admin_Pouch", (object)allTintHash.ToString()));
                                                else
                                                    xelement2.Element((XName)characterWeapon.ToString()).Attribute((XName)"tint_Admin_Pouch").Value = allTintHash.ToString();
                                            }
                                        }
                                        if (characterWeapon != WeaponHash.Unarmed)
                                            Function.Call(Hash.REMOVE_WEAPON_FROM_PED, (InputArgument)(Entity)ped, (InputArgument)(int)characterWeapon);
                                    }
                                    else
                                    {
                                        int num3 = int.Parse(xelement2.Element((XName)characterWeapon.ToString()).Element((XName)"AMMO_Admin_Pouch").Value) + content;
                                        xelement2.Element((XName)characterWeapon.ToString()).Element((XName)"AMMO_Admin_Pouch").Value = num3.ToString();
                                        foreach (WeaponComponentHash allComponentsHash in Common.allComponentsHashes)
                                        {
                                            bool flag = Function.Call<bool>(Hash.HAS_PED_GOT_WEAPON_COMPONENT, (InputArgument)(Entity)ped, (InputArgument)(int)characterWeapon, (InputArgument)(int)allComponentsHash);
                                            if (xelement2.Element((XName)characterWeapon.ToString()).Element((XName)allComponentsHash.ToString()) == null & flag)
                                                xelement2.Element((XName)characterWeapon.ToString()).Add((object)new XElement((XName)allComponentsHash.ToString()));
                                        }
                                        foreach (WeaponTint allTintHash in Common.allTintHashes)
                                        {
                                            int num4 = Function.Call<int>(Hash.GET_PED_WEAPON_TINT_INDEX, (InputArgument)(Entity)ped, (InputArgument)(int)characterWeapon);
                                            if (allTintHash == (WeaponTint)num4)
                                            {
                                                if (xelement2.Element((XName)characterWeapon.ToString()).Attribute((XName)"tint_Admin_Pouch") == null)
                                                    xelement2.Element((XName)characterWeapon.ToString()).Add((object)new XAttribute((XName)"tint_Admin_Pouch", (object)allTintHash.ToString()));
                                                else
                                                    xelement2.Element((XName)characterWeapon.ToString()).Attribute((XName)"tint_Admin_Pouch").Value = allTintHash.ToString();
                                            }
                                        }
                                        if (characterWeapon != WeaponHash.Unarmed)
                                            Function.Call(Hash.REMOVE_WEAPON_FROM_PED, (InputArgument)(Entity)ped, (InputArgument)(int)characterWeapon);
                                    }
                                }
                                else
                                {
                                    if (xelement2.Element((XName)characterWeapon.ToString()) == null)
                                        xelement2.Add((object)new XElement((XName)characterWeapon.ToString()));
                                    foreach (WeaponTint allTintHash in Common.allTintHashes)
                                    {
                                        int num = Function.Call<int>(Hash.GET_PED_WEAPON_TINT_INDEX, (InputArgument)(Entity)ped, (InputArgument)(int)characterWeapon);
                                        if (allTintHash == (WeaponTint)num)
                                        {
                                            if (xelement2.Element((XName)characterWeapon.ToString()).Attribute((XName)"tint_Admin_Pouch") == null)
                                                xelement2.Element((XName)characterWeapon.ToString()).Add((object)new XAttribute((XName)"tint_Admin_Pouch", (object)allTintHash.ToString()));
                                            else
                                                xelement2.Element((XName)characterWeapon.ToString()).Attribute((XName)"tint_Admin_Pouch").Value = allTintHash.ToString();
                                        }
                                    }
                                    if (characterWeapon != WeaponHash.Unarmed)
                                        Function.Call(Hash.REMOVE_WEAPON_FROM_PED, (InputArgument)(Entity)ped, (InputArgument)(int)characterWeapon);
                                }
                            }
                            Common.saveDoc();
                            Vest.modMenuPool.CloseAllMenus();
                            Vest.inMenu = false;
                            //if (!((Entity)Vest.bagModelReturn(ped) != (Entity)null))
                            //return;
                            //Vest.weaponInventoryAnim(Vest.bagModelReturn(ped), ped);
                        });
                        uiMenu4.OnCheckboxChange += (CheckboxChangeEvent)((sender, item, index) =>
                        {
                            if (item.Checked)
                            {
                                foreach (WeaponHash allWeaponHash in Common.allWeaponHashes)
                                {
                                    if (ped.Weapons.HasWeapon(allWeaponHash) && item.Text.ToString() == allWeaponHash.ToString() && !Vest.characterWeapons.Contains(allWeaponHash))
                                        Vest.characterWeapons.Add(allWeaponHash);
                                }
                            }
                            else
                            {
                                foreach (WeaponHash allWeaponHash in Common.allWeaponHashes)
                                {
                                    if (ped.Weapons.HasWeapon(allWeaponHash) && item.Text.ToString() == allWeaponHash.ToString() && Vest.characterWeapons.Contains(allWeaponHash))
                                        Vest.characterWeapons.Remove(allWeaponHash);
                                }
                            }
                        });
                    }

                }

            }*/
                if (!Vest.mainMenuListString.Contains((object)uiMenu2))
                {
                Vest.mainMenuListString.Add((object)uiMenu2);
                UIMenu uiMenu3 = Vest.modMenuPool.AddSubMenu(Vest.mainMenu, "Admin Pouch");
                Vest.mainMenu.CurrentSelection = 0;
                if (Common.doc.Element((XName)"WeaponList").Element((XName)character) != null && Common.doc.Element((XName)"WeaponList").Element((XName)character).Element((XName)"Weapons_Admin_Pouch") != null && Common.doc.Element((XName)"WeaponList").Element((XName)character).Element((XName)"Weapons_Admin_Pouch").Elements() != null)
                {
                    foreach (XElement element in Common.doc.Element((XName)"WeaponList").Element((XName)character).Element((XName)"Weapons_Admin_Pouch").Elements())
                    {
                        foreach (WeaponHash allWeaponHash in Common.allWeaponHashes)
                        {
                            if (element.Name.ToString() == allWeaponHash.ToString())
                            {
                                XName name1 = element.Name;
                                WeaponHash weaponHash = WeaponHash.Unarmed;
                                XName xname1 = (XName)weaponHash.ToString();
                                if (name1 != xname1)
                                {
                                    XName name2 = element.Name;
                                    weaponHash = WeaponHash.Parachute;
                                    XName xname2 = (XName)weaponHash.ToString();
                                    if (name2 != xname2)
                                    {
                                        UIMenuCheckboxItem menuCheckboxItem = new UIMenuCheckboxItem(element.Name.ToString(), false);
                                        if (!uiMenu3.MenuItems.Contains((UIMenuItem)menuCheckboxItem))
                                            uiMenu3.AddItem((UIMenuItem)menuCheckboxItem);
                                    }
                                }
                            }
                        }
                    }
                }
                else if (Common.doc.Element((XName)"WeaponList").Element((XName)character) == null && Common.doc.Element((XName)"WeaponList").Element((XName)character).Element((XName)"Weapons_Admin_Pouch") == null && Common.doc.Element((XName)"WeaponList").Element((XName)character).Element((XName)"Weapons_Admin_Pouch").Elements() == null)               
                    goto label_59;
                
                if (!uiMenu3.MenuItems.Contains((UIMenuItem)TakeItem))
                    uiMenu3.AddItem((UIMenuItem)TakeItem);
                uiMenu3.OnItemSelect += (ItemSelectEvent)((sender, item, index) =>
                {
                    if (item != TakeItem)
                        return;
                    if (Common.doc.Element((XName)"WeaponList").Element((XName)character) != null)
                    {
                        if (Common.doc.Element((XName)"WeaponList").Element((XName)character).Element((XName)"AmmoType_Admin_Pouch").Elements() != null)
                        {
                            object[] names = (object[])Enum.GetNames(typeof(eAmmoType));
                            Array values = Enum.GetValues(typeof(eAmmoType));
                            for (int index1 = 0; index1 < names.Length; ++index1)
                            {
                                string name = names[index1].ToString();
                                uint num1 = (uint)values.GetValue(index1);
                                XElement xelement = Common.doc.Element((XName)"WeaponList").Element((XName)character).Element((XName)"AmmoType_Admin_Pouch").Element((XName)name);
                                if (xelement != null && Main.TryToConvertInt32(xelement.Value) > 0)
                                {
                                    int num2 = (int)Function.Call<uint>(Hash.SET_PED_AMMO_BY_TYPE, (InputArgument)(Entity)ped, (InputArgument)num1, (InputArgument)Main.TryToConvertInt32(xelement.Value));
                                    xelement.Remove();
                                }
                            }
                        }
                        if (Common.doc.Element((XName)"WeaponList").Element((XName)character).Element((XName)"Weapons_Admin_Pouch") != null)
                        {
                            foreach (WeaponHash stashedWeapon in Vest.stashedWeapons)
                            {
                                foreach (XElement element in Common.doc.Element((XName)"WeaponList").Element((XName)character).Element((XName)"Weapons_Admin_Pouch").Elements())
                                {
                                    if (element.Element((XName)"AMMO_Admin_Pouch") != null)
                                    {
                                        if (element.Name == (XName)stashedWeapon.ToString())
                                        {
                                            ped.Weapons.Give(stashedWeapon, (int)element.Element((XName)"AMMO_Admin_Pouch"), false, false);
                                            foreach (WeaponComponentHash allComponentsHash in Common.allComponentsHashes)
                                            {
                                                bool flag = Function.Call<bool>(Hash.DOES_WEAPON_TAKE_WEAPON_COMPONENT, (InputArgument)(int)stashedWeapon, (InputArgument)(int)allComponentsHash);
                                                if (element.Element((XName)allComponentsHash.ToString()) != null & flag)
                                                    Function.Call(Hash.GIVE_WEAPON_COMPONENT_TO_PED, (InputArgument)(Entity)ped, (InputArgument)(int)stashedWeapon, (InputArgument)(int)allComponentsHash);
                                            }
                                            foreach (WeaponTint allTintHash in Common.allTintHashes)
                                            {
                                                if (element.Attribute((XName)"tint_Admin_Pouch") != null && element.Attribute((XName)"tint_Admin_Pouch").Value == allTintHash.ToString())
                                                    Function.Call(Hash.SET_PED_WEAPON_TINT_INDEX, (InputArgument)(Entity)ped, (InputArgument)(int)stashedWeapon, (InputArgument)(int)allTintHash);
                                            }
                                            element.Remove();
                                        }
                                    }
                                    else if (element.Name == (XName)stashedWeapon.ToString())
                                    {
                                        ped.Weapons.Give(stashedWeapon, 0, false, false);
                                        foreach (WeaponComponentHash allComponentsHash in Common.allComponentsHashes)
                                        {
                                            bool flag = Function.Call<bool>(Hash.DOES_WEAPON_TAKE_WEAPON_COMPONENT, (InputArgument)(int)stashedWeapon, (InputArgument)(int)allComponentsHash);
                                            if (element.Element((XName)allComponentsHash.ToString()) != null & flag)
                                                Function.Call(Hash.GIVE_WEAPON_COMPONENT_TO_PED, (InputArgument)(Entity)ped, (InputArgument)(int)stashedWeapon, (InputArgument)(int)allComponentsHash);
                                        }
                                        foreach (WeaponTint allTintHash in Common.allTintHashes)
                                        {
                                            if (element.Attribute((XName)"tint_Admin_Pouch") != null && element.Attribute((XName)"tint_Admin_Pouch").Value == allTintHash.ToString())
                                                Function.Call(Hash.SET_PED_WEAPON_TINT_INDEX, (InputArgument)(Entity)ped, (InputArgument)(int)stashedWeapon, (InputArgument)(int)allTintHash);
                                        }
                                        element.Remove();
                                    }
                                }
                            }
                        }
                        Common.saveDoc();
                    }
                    Vest.modMenuPool.CloseAllMenus();
                    Vest.inMenu = false;
                    //if (!((Entity)Vest.bagModelReturn(ped) != (Entity)null))
                        //return;
                    //Vest.weaponInventoryAnim(Vest.bagModelReturn(ped), ped);
                });            
                uiMenu3.OnCheckboxChange += (CheckboxChangeEvent)((sender, item, index) =>
                {
                    if (item.Checked)
                    {
                        foreach (WeaponHash allWeaponHash in Common.allWeaponHashes)
                        {
                            if (item.Text.ToString() == allWeaponHash.ToString() && !Vest.stashedWeapons.Contains(allWeaponHash))
                                Vest.stashedWeapons.Add(allWeaponHash);
                        }
                    }
                    else
                    {
                        foreach (WeaponHash allWeaponHash in Common.allWeaponHashes)
                        {
                            if (item.Text.ToString() == allWeaponHash.ToString() && Vest.stashedWeapons.Contains(allWeaponHash))
                                Vest.stashedWeapons.Remove(allWeaponHash);
                        }
                    }
                });
            }
        label_59:
            if (!Vest.mainMenuListString.Contains((object)uiMenu1))
            {
                Vest.mainMenuListString.Add((object)uiMenu1);
                UIMenu uiMenu4 = Vest.modMenuPool.AddSubMenu(Vest.mainMenu, "Admin Pouch");
                Vest.mainMenu.CurrentSelection = 0;
                foreach (WeaponHash allWeaponHash in Common.allWeaponHashes)
                {
                    if (ped.Weapons.HasWeapon(allWeaponHash))
                    {
                        UIMenuCheckboxItem menuCheckboxItem = new UIMenuCheckboxItem(allWeaponHash.ToString(), false);
                        if (!uiMenu4.MenuItems.Contains((UIMenuItem)menuCheckboxItem) && allWeaponHash != WeaponHash.Unarmed && allWeaponHash != WeaponHash.Parachute)
                            uiMenu4.AddItem((UIMenuItem)menuCheckboxItem);
                    }
                }
                if (!uiMenu4.MenuItems.Contains((UIMenuItem)StashItem))
                    uiMenu4.AddItem((UIMenuItem)StashItem);
                uiMenu4.OnItemSelect += (ItemSelectEvent)((sender, item, index) =>
                {
                    if (item != StashItem)
                        return;
                    XElement xelement1 = Common.doc.Element((XName)"WeaponList").Element((XName)character);
                    if (xelement1.Element((XName)"AmmoType_Admin_Pouch") == null)
                        xelement1.Add((object)new XElement((XName)"AmmoType_Admin_Pouch"));
                    object[] names = (object[])Enum.GetNames(typeof(eAmmoType));
                    Array values = Enum.GetValues(typeof(eAmmoType));
                    for (int index2 = 0; index2 < names.Length; ++index2)
                    {
                        string name = names[index2].ToString();
                        int content = Function.Call<int>(Hash.GET_PED_AMMO_BY_TYPE, (InputArgument)(Entity)ped, (InputArgument)(uint)values.GetValue(index2));
                        if (content > 0)
                        {
                            if (xelement1.Element((XName)"AmmoType_Admin_Pouch").Element((XName)name) == null)
                                xelement1.Element((XName)"AmmoType_Admin_Pouch").Add((object)new XElement((XName)name, (object)content));
                            else
                                xelement1.Element((XName)"AmmoType_Admin_Pouch").Element((XName)name).Value = content.ToString();
                        }
                    }
                    if (xelement1.Element((XName)"Weapons_Admin_Pouch") == null)
                        xelement1.Add((object)new XElement((XName)"Weapons_Admin_Pouch"));
                    XElement xelement2 = xelement1.Element((XName)"Weapons_Admin_Pouch");
                    foreach (WeaponHash characterWeapon in Vest.characterWeapons)
                    {
                        int content = Function.Call<int>(Hash.GET_AMMO_IN_PED_WEAPON, (InputArgument)(Entity)ped, (InputArgument)(int)characterWeapon);
                        if (Function.Call<uint>(Hash.GET_WEAPONTYPE_GROUP, (InputArgument)(int)characterWeapon) != 2685387236U && Function.Call<uint>(Hash.GET_WEAPONTYPE_GROUP, (InputArgument)(int)characterWeapon) != 3566412244U)
                        {
                            if (xelement2.Element((XName)characterWeapon.ToString()) == null)
                            {
                                if (characterWeapon != WeaponHash.Unarmed)
                                {
                                    xelement2.Add((object)new XElement((XName)characterWeapon.ToString(), (object)new XElement((XName)"AMMO_Admin_Pouch", (object)content)));
                                    foreach (WeaponComponentHash allComponentsHash in Common.allComponentsHashes)
                                    {
                                        bool flag = Function.Call<bool>(Hash.HAS_PED_GOT_WEAPON_COMPONENT, (InputArgument)(Entity)ped, (InputArgument)(int)characterWeapon, (InputArgument)(int)allComponentsHash);
                                        if (xelement2.Element((XName)characterWeapon.ToString()).Element((XName)allComponentsHash.ToString()) == null & flag)
                                            xelement2.Element((XName)characterWeapon.ToString()).Add((object)new XElement((XName)allComponentsHash.ToString()));
                                    }
                                    foreach (WeaponTint allTintHash in Common.allTintHashes)
                                    {
                                        int num = Function.Call<int>(Hash.GET_PED_WEAPON_TINT_INDEX, (InputArgument)(Entity)ped, (InputArgument)(int)characterWeapon);
                                        if (allTintHash == (WeaponTint)num)
                                        {
                                            if (xelement2.Element((XName)characterWeapon.ToString()).Attribute((XName)"tint_Admin_Pouch") == null)
                                                xelement2.Element((XName)characterWeapon.ToString()).Add((object)new XAttribute((XName)"tint_Admin_Pouch", (object)allTintHash.ToString()));
                                            else
                                                xelement2.Element((XName)characterWeapon.ToString()).Attribute((XName)"tint_Admin_Pouch").Value = allTintHash.ToString();
                                        }
                                    }
                                    if (characterWeapon != WeaponHash.Unarmed)
                                        Function.Call(Hash.REMOVE_WEAPON_FROM_PED, (InputArgument)(Entity)ped, (InputArgument)(int)characterWeapon);
                                }
                            }
                            else if (xelement2.Element((XName)characterWeapon.ToString()).Element((XName)"AMMO_Admin_Pouch") == null)
                            {
                                xelement2.Element((XName)characterWeapon.ToString()).Add((object)new XElement((XName)"AMMO_Admin_Pouch", (object)content));
                                foreach (WeaponComponentHash allComponentsHash in Common.allComponentsHashes)
                                {
                                    bool flag = Function.Call<bool>(Hash.HAS_PED_GOT_WEAPON_COMPONENT, (InputArgument)(Entity)ped, (InputArgument)(int)characterWeapon, (InputArgument)(int)allComponentsHash);
                                    if (xelement2.Element((XName)characterWeapon.ToString()).Element((XName)allComponentsHash.ToString()) == null & flag)
                                        xelement2.Element((XName)characterWeapon.ToString()).Add((object)new XElement((XName)allComponentsHash.ToString()));
                                }
                                foreach (WeaponTint allTintHash in Common.allTintHashes)
                                {
                                    int num = Function.Call<int>(Hash.GET_PED_WEAPON_TINT_INDEX, (InputArgument)(Entity)ped, (InputArgument)(int)characterWeapon);
                                    if (allTintHash == (WeaponTint)num)
                                    {
                                        if (xelement2.Element((XName)characterWeapon.ToString()).Attribute((XName)"tint_Admin_Pouch") == null)
                                            xelement2.Element((XName)characterWeapon.ToString()).Add((object)new XAttribute((XName)"tint_Admin_Pouch", (object)allTintHash.ToString()));
                                        else
                                            xelement2.Element((XName)characterWeapon.ToString()).Attribute((XName)"tint_Admin_Pouch").Value = allTintHash.ToString();
                                    }
                                }
                                if (characterWeapon != WeaponHash.Unarmed)
                                    Function.Call(Hash.REMOVE_WEAPON_FROM_PED, (InputArgument)(Entity)ped, (InputArgument)(int)characterWeapon);
                            }
                            else
                            {
                                int num3 = int.Parse(xelement2.Element((XName)characterWeapon.ToString()).Element((XName)"AMMO_Admin_Pouch").Value) + content;
                                xelement2.Element((XName)characterWeapon.ToString()).Element((XName)"AMMO_Admin_Pouch").Value = num3.ToString();
                                foreach (WeaponComponentHash allComponentsHash in Common.allComponentsHashes)
                                {
                                    bool flag = Function.Call<bool>(Hash.HAS_PED_GOT_WEAPON_COMPONENT, (InputArgument)(Entity)ped, (InputArgument)(int)characterWeapon, (InputArgument)(int)allComponentsHash);
                                    if (xelement2.Element((XName)characterWeapon.ToString()).Element((XName)allComponentsHash.ToString()) == null & flag)
                                        xelement2.Element((XName)characterWeapon.ToString()).Add((object)new XElement((XName)allComponentsHash.ToString()));
                                }
                                foreach (WeaponTint allTintHash in Common.allTintHashes)
                                {
                                    int num4 = Function.Call<int>(Hash.GET_PED_WEAPON_TINT_INDEX, (InputArgument)(Entity)ped, (InputArgument)(int)characterWeapon);
                                    if (allTintHash == (WeaponTint)num4)
                                    {
                                        if (xelement2.Element((XName)characterWeapon.ToString()).Attribute((XName)"tint_Admin_Pouch") == null)
                                            xelement2.Element((XName)characterWeapon.ToString()).Add((object)new XAttribute((XName)"tint_Admin_Pouch", (object)allTintHash.ToString()));
                                        else
                                            xelement2.Element((XName)characterWeapon.ToString()).Attribute((XName)"tint_Admin_Pouch").Value = allTintHash.ToString();
                                    }
                                }
                                if (characterWeapon != WeaponHash.Unarmed)
                                    Function.Call(Hash.REMOVE_WEAPON_FROM_PED, (InputArgument)(Entity)ped, (InputArgument)(int)characterWeapon);
                            }
                        }
                        else
                        {
                            if (xelement2.Element((XName)characterWeapon.ToString()) == null)
                                xelement2.Add((object)new XElement((XName)characterWeapon.ToString()));
                            foreach (WeaponTint allTintHash in Common.allTintHashes)
                            {
                                int num = Function.Call<int>(Hash.GET_PED_WEAPON_TINT_INDEX, (InputArgument)(Entity)ped, (InputArgument)(int)characterWeapon);
                                if (allTintHash == (WeaponTint)num)
                                {
                                    if (xelement2.Element((XName)characterWeapon.ToString()).Attribute((XName)"tint_Admin_Pouch") == null)
                                        xelement2.Element((XName)characterWeapon.ToString()).Add((object)new XAttribute((XName)"tint_Admin_Pouch", (object)allTintHash.ToString()));
                                    else
                                        xelement2.Element((XName)characterWeapon.ToString()).Attribute((XName)"tint_Admin_Pouch").Value = allTintHash.ToString();
                                }
                            }
                            if (characterWeapon != WeaponHash.Unarmed)
                                Function.Call(Hash.REMOVE_WEAPON_FROM_PED, (InputArgument)(Entity)ped, (InputArgument)(int)characterWeapon);
                        }
                    }
                    Common.saveDoc();
                    Vest.modMenuPool.CloseAllMenus();
                    Vest.inMenu = false;
                    //if (!((Entity)Vest.bagModelReturn(ped) != (Entity)null))
                        //return;
                    //Vest.weaponInventoryAnim(Vest.bagModelReturn(ped), ped);
                });
                uiMenu4.OnCheckboxChange += (CheckboxChangeEvent)((sender, item, index) =>
                {
                    if (item.Checked)
                    {
                        foreach (WeaponHash allWeaponHash in Common.allWeaponHashes)
                        {
                            if (ped.Weapons.HasWeapon(allWeaponHash) && item.Text.ToString() == allWeaponHash.ToString() && !Vest.characterWeapons.Contains(allWeaponHash))
                                Vest.characterWeapons.Add(allWeaponHash);
                        }
                    }
                    else
                    {
                        foreach (WeaponHash allWeaponHash in Common.allWeaponHashes)
                        {
                            if (ped.Weapons.HasWeapon(allWeaponHash) && item.Text.ToString() == allWeaponHash.ToString() && Vest.characterWeapons.Contains(allWeaponHash))
                                Vest.characterWeapons.Remove(allWeaponHash);
                        }
                    }
                });
            }
            //if ((Entity)Vest.bagModelReturn(ped) != (Entity)null)
            if (Game.Player.Character.Armor >  0) 
            {
                if (!Vest.mainMenu.MenuItems.Contains((UIMenuItem)RemoveArmor) && !Vest.armortakenoff)
                    Vest.mainMenu.AddItem((UIMenuItem)RemoveArmor);
                else if (!Vest.mainMenu.MenuItems.Contains((UIMenuItem)RemoveArmor) && Vest.armortakenoff)
                    Vest.mainMenu.AddItem((UIMenuItem)EquipArmor);
                if (!Vest.mainMenu.MenuItems.Contains((UIMenuItem)ReplaceArmorPlate) && Game.Player.Character.Armor < 100)
                    Vest.mainMenu.AddItem((UIMenuItem)ReplaceArmorPlate);
            /*  if (!Vest.mainMenu.MenuItems.Contains((UIMenuItem)LoadOutfit) && Common.doc.Element((XName)"WeaponList").Element((XName)character).Element((XName)"Outfit") != null)
                    Vest.mainMenu.AddItem((UIMenuItem)LoadOutfit);
                if (!Vest.mainMenu.MenuItems.Contains((UIMenuItem)ChangeBagPosition))
                    Vest.mainMenu.AddItem((UIMenuItem)ChangeBagPosition);  */
                if (!Vest.mainMenu.MenuItems.Contains((UIMenuItem)CloseMenu))
                    Vest.mainMenu.AddItem((UIMenuItem)CloseMenu);
            }
            Vest.mainMenu.OnItemSelect += (ItemSelectEvent)((sender, item, index) =>
            {
                if (item == RemoveArmor )
                {
                    if (!ped.IsSittingInVehicle() || ped.IsSittingInVehicle() && !ped.CurrentVehicle.IsBicycle && !ped.CurrentVehicle.IsBike && !ped.CurrentVehicle.IsQuadBike)
                    {
                        Vest.inMenu = false;
                        Game.Player.Character.Task.ClearAll();
                        armorlevel = Game.Player.Character.Armor;
                        Game.Player.Character.Armor = 0;
                        armortakenoff = true;
                        Vest.modMenuPool.CloseAllMenus();
                        //Vest.bagRemove(Vest.bagModelReturn(ped), ped);
                    }
                    //else
                      //  Main.Notify("~r~You cant stash your bag here", "IBAG", (int)byte.MaxValue, 0, 0, NotificationIcon.Ammunation);
                }
                if (item == EquipArmor)
                {
                    if (!ped.IsSittingInVehicle() || ped.IsSittingInVehicle() && !ped.CurrentVehicle.IsBicycle && !ped.CurrentVehicle.IsBike && !ped.CurrentVehicle.IsQuadBike)
                    {
                        Vest.inMenu = false;
                        Game.Player.Character.Task.ClearAll();
                        Game.Player.Character.Armor = armorlevel;
                        armortakenoff = false;
                        Vest.modMenuPool.CloseAllMenus();
                        //Vest.bagRemove(Vest.bagModelReturn(ped), ped);
                    }
                    //else
                    //  Main.Notify("~r~You cant stash your bag here", "IBAG", (int)byte.MaxValue, 0, 0, NotificationIcon.Ammunation);
                }
                if (item == ReplaceArmorPlate)
                {
                    Vest.inMenu = false;
                    Game.Player.Character.Armor = 100;
                    Vest.modMenuPool.CloseAllMenus();
                    
                }
            /*  if (item == LoadOutfit && (Entity)Vest.bagModelReturn(ped) != (Entity)null)
                {
                    Vest.modMenuPool.CloseAllMenus();
                    Vest.inMenu = false;
                    Vest.LoadOutfitFunc(ped);
                }
                if (item == ChangeBagPosition && (Entity)Vest.bagModelReturn(ped) != (Entity)null)
                {
                    
                    Vest.modMenuPool.CloseAllMenus();
                    Vest.inMenu = false;
                }*/
                if (item != CloseMenu) //|| !((Entity)Vest.bagModelReturn(ped) != (Entity)null))
                    return;
                Vest.mainMenuListString.Clear();
                Vest.stashedWeapons.Clear();
                Vest.inMenu = false;
                //Vest.weaponInventoryAnim(Vest.bagModelReturn(Game.Player.Character), Game.Player.Character);
            });
        }

        public static void onMenuClose(UIMenu sender)
        {
            if (Vest.modMenuPool.IsAnyMenuOpen())
                return;
            Vest.modMenuPool.CloseAllMenus();
            Vest.inMenu = false;
        }

    }
}
