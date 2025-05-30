// Decompiled with JetBrains decompiler
// Type: GTAExpansion.HungerSystem
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
    public static class HungerSystem
    {
        public static bool hungerModuleActive = ScriptSettings.Load("scripts\\Expansion\\Expansion.ini").GetValue<bool>("HUNGER_SETTINGS", "HUNGER_MODE_ACTIVE", true);
        public static int hunger_lvl_max = ScriptSettings.Load("scripts\\Expansion\\Expansion.ini").GetValue<int>("HUNGER_SETTINGS", "MAX_LVL", 1000);
        public static int criticalHungerLvl = ScriptSettings.Load("scripts\\Expansion\\Expansion.ini").GetValue<int>("HUNGER_SETTINGS", "MIN_CRITICAL_LVL", 10);
        public static int eat_btn = ScriptSettings.Load("scripts\\Expansion\\Expansion.ini").GetValue<int>("HUNGER_SETTINGS", "EAT_BTN", 45);
        public static int drink_btn = ScriptSettings.Load("scripts\\Expansion\\Expansion.ini").GetValue<int>("HUNGER_SETTINGS", "DRINK_BTN", 52);
        public static bool isHungry = false;
        public static bool isVeryHungry = false;
        public static bool isEating = false;
        public static bool isDrinking = false;
        public static int drinkSipsLeft = 0;
        public static bool drinkingInProcess = false;
        public static int drinkingEffectsTimer = 0;
        public static int swallowSoundFXTimer = 0;
        public static int eatingSoundsInt = 300;
        public static int eatingSoundsMaxInt = 300;
        public static float eatingAnimTime = 0.5f;
        public static int hungerTimeRef = 0;
        public static int hungerTimeRef2 = 0;
        public static Prop _drink = (Prop)null;
        public static bool _buyingSnacks = false;
        public static int foodCost = ScriptSettings.Load("scripts\\Expansion\\Expansion.ini").GetValue<int>("PRICES", "FOOD_PRICE", 10);
        public static int curHungerLvl = 0;
        public static string _curPedsFood = "";
        public static string _curPedsDrink = "";
        public static string foodModel = "prop_choc_meto";
        public static string drinkModel = "p_amb_coffeecup_01";
        public static string[] food_chocolates = new string[2]
        {
      "prop_choc_meto",
      "prop_choc_ego"
        };
        public static string[] food_burgers = new string[1]
        {
      "prop_cs_burger_01"
        };
        public static string[] drinks_coffee = new string[1]
        {
      "p_amb_coffeecup_01"
        };
        public static string[] drinks_beer = new string[1]
        {
      "p_amb_coffeecup_01"
        };
        public static int foodLeft = 0;
        public static int drinksLeft = 0;
        public static string pedDrinkingAnimDict = "amb@prop_human_seat_chair_drink@male@generic@idle_a";
        public static string pedDrinkingAnimName = "idle_a";
        public static CBar hungerBar = new CBar("Hunger lvl");

        public static int getPedHungerLvl(Ped ped, XDocument _doc)
        {
            string name = ((PedHash)ped.Model).ToString();
            if (char.IsDigit(name[0]))
                name = "CustomPed_" + name;
            if (_doc.Element((XName)"WeaponList").Element((XName)name) == null)
                _doc.Element((XName)"WeaponList").Add((object)new XElement((XName)name));
            XElement xelement1 = _doc.Element((XName)"WeaponList").Element((XName)name);
            if (xelement1.Element((XName)"hunger") == null)
                xelement1.Add((object)new XElement((XName)"hunger"));
            XElement xelement2 = xelement1.Element((XName)"hunger");
            if (xelement2.Element((XName)"level") == null)
                xelement2.Add((object)new XElement((XName)"level", (object)0));
            return Main.TryToConvertInt32(xelement2.Element((XName)"level").Value);
        }

        public static int savePedHungerLvl(Ped ped, int lvl, int max_lvl, XDocument _doc)
        {
            string name = ((PedHash)ped.Model).ToString();
            if (char.IsDigit(name[0]))
                name = "CustomPed_" + name;
            if (_doc.Element((XName)"WeaponList").Element((XName)name) == null)
                _doc.Element((XName)"WeaponList").Add((object)new XElement((XName)name));
            XElement xelement1 = _doc.Element((XName)"WeaponList").Element((XName)name);
            if (xelement1.Element((XName)"hunger") == null)
                xelement1.Add((object)new XElement((XName)"hunger"));
            XElement xelement2 = xelement1.Element((XName)"hunger");
            if (xelement2.Element((XName)"level") == null)
                xelement2.Add((object)new XElement((XName)"level"));
            int convertInt32_1 = Main.TryToConvertInt32(lvl.ToString());
            xelement2.Element((XName)"level").Value = convertInt32_1 > 0 ? convertInt32_1.ToString() : 0.ToString();
            if (Main.TryToConvertInt32(xelement2.Element((XName)"level").Value) > max_lvl)
                xelement2.Element((XName)"level").Value = max_lvl.ToString();
            int convertInt32_2 = Main.TryToConvertInt32(xelement2.Element((XName)"level").Value);
            Common.saveDoc(_doc);
            return convertInt32_2;
        }

        public static string getFoodModelByTyoe(string food_type)
        {
            string foodModelByTyoe = "";
            string[] strArray = new string[0];
            if (food_type == "chocolates")
                strArray = HungerSystem.food_chocolates;
            if (food_type == "burgers")
                strArray = HungerSystem.food_burgers;
            if (strArray.Length != 0)
            {
                int index = Common.rnd.Next(0, strArray.Length - 1);
                foodModelByTyoe = strArray[index];
            }
            return foodModelByTyoe;
        }

        public static string getPedsFood(Ped ped, XDocument _doc, string foodType = "")
        {
            string pedsFood = "";
            string name = ((PedHash)ped.Model).ToString();
            if (char.IsDigit(name[0]))
                name = "CustomPed_" + name;
            if (_doc.Element((XName)"WeaponList").Element((XName)name) == null)
                _doc.Element((XName)"WeaponList").Add((object)new XElement((XName)name));
            XElement xelement1 = _doc.Element((XName)"WeaponList").Element((XName)name);
            if (xelement1.Element((XName)"hunger") == null)
                xelement1.Add((object)new XElement((XName)"hunger"));
            XElement xelement2 = xelement1.Element((XName)"hunger");
            if (xelement2.Element((XName)"food") == null)
                xelement2.Add((object)new XElement((XName)"food"));
            XElement xelement3 = xelement2.Element((XName)"food");
            if (foodType != "")
            {
                XElement xelement4 = xelement3.Element((XName)foodType);
                pedsFood = xelement4 == null || Main.TryToConvertInt32(xelement4.Value) <= 0 ? "" : foodType;
            }
            else if (xelement3.Elements() != null)
            {
                foreach (XElement element in xelement3.Elements())
                {
                    if (Main.TryToConvertInt32(element.Value) > 0)
                        pedsFood = element.Name.ToString();
                }
            }
            return pedsFood;
        }

        public static void clearFoodPacket(Ped ped, string foodModel)
        {
            Prop[] allProps = World.GetAllProps((Model)Main.GetHashKey(foodModel));
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

        public static Prop createFoodPacket(
          Ped ped,
          Vector3 pos,
          string foodModel = "hei_prop_hei_paper_bag",
          bool attach = true,
          bool leftHandAttach = false)
        {
            Prop[] nearbyProps = World.GetNearbyProps(ped.Position, 5f, (Model)foodModel);
            Prop prop;
            if (nearbyProps.Length == 0)
            {
                prop = World.CreateProp((Model)foodModel, pos, true, true);
            }
            else
            {
                prop = nearbyProps[0];
                if (!prop.IsAttachedTo((Entity)ped))
                    prop = World.CreateProp((Model)foodModel, pos, true, true);
            }
            if ((Entity)prop != (Entity)null && attach)
                HungerSystem.AttachFoodPacket(ped, prop, leftHandAttach);
            return prop;
        }

        public static void AttachFoodPacket(Ped ped, Prop food, bool leftHandAttach = false)
        {
            if (!leftHandAttach)
            {
                int num = Function.Call<int>(Hash.GET_PED_BONE_INDEX, (InputArgument)(Entity)ped, (InputArgument)57005);
                Function.Call(Hash.ATTACH_ENTITY_TO_ENTITY, (InputArgument)(Entity)food, (InputArgument)(Entity)ped, (InputArgument)num, (InputArgument)0.25f, (InputArgument)0.03f, (InputArgument)(-0.016f), (InputArgument)45f, (InputArgument)(-90f), (InputArgument)(-55f), (InputArgument)true, (InputArgument)true, (InputArgument)false, (InputArgument)false, (InputArgument)0, (InputArgument)true);
            }
            else
            {
                int num = Function.Call<int>(Hash.GET_PED_BONE_INDEX, (InputArgument)(Entity)ped, (InputArgument)18905);
                Function.Call(Hash.ATTACH_ENTITY_TO_ENTITY, (InputArgument)(Entity)food, (InputArgument)(Entity)ped, (InputArgument)num, (InputArgument)0.095f, (InputArgument)0.02f, (InputArgument)0.0f, (InputArgument)82f, (InputArgument)(-180f), (InputArgument)(-180f), (InputArgument)true, (InputArgument)true, (InputArgument)false, (InputArgument)false, (InputArgument)0, (InputArgument)true);
            }
        }

        public static void clearFood(Ped ped, string foodModel)
        {
            Prop[] allProps = World.GetAllProps((Model)Main.GetHashKey(foodModel));
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

        public static Prop createFood(
          Ped ped,
          Vector3 pos,
          string foodModel = "prop_choc_meto",
          bool attach = true,
          bool leftHandAttach = false,
          int attachPositionType = 0)
        {
            Prop[] nearbyProps = World.GetNearbyProps(ped.Position, 5f, (Model)foodModel);
            Prop prop;
            if (nearbyProps.Length == 0)
            {
                prop = World.CreateProp((Model)foodModel, pos, true, true);
            }
            else
            {
                prop = nearbyProps[0];
                if (!prop.IsAttachedTo((Entity)ped))
                    prop = World.CreateProp((Model)foodModel, pos, true, true);
            }
            if ((Entity)prop != (Entity)null && attach)
                HungerSystem.AttachFood(ped, prop, leftHandAttach, attachPositionType);
            return prop;
        }

        public static void AttachFood(Ped ped, Prop food, bool leftHandAttach = false, int attachPositionType = 0)
        {
            if (!leftHandAttach)
            {
                int num = Function.Call<int>(Hash.GET_PED_BONE_INDEX, (InputArgument)(Entity)ped, (InputArgument)57005);
                Function.Call(Hash.ATTACH_ENTITY_TO_ENTITY, (InputArgument)(Entity)food, (InputArgument)(Entity)ped, (InputArgument)num, (InputArgument)0.155f, (InputArgument)0.045f, (InputArgument)(-0.055f), (InputArgument)(-13f), (InputArgument)(-180f), (InputArgument)90f, (InputArgument)true, (InputArgument)true, (InputArgument)false, (InputArgument)false, (InputArgument)0, (InputArgument)true);
            }
            else
            {
                int num = Function.Call<int>(Hash.GET_PED_BONE_INDEX, (InputArgument)(Entity)ped, (InputArgument)18905);
                Function.Call(Hash.ATTACH_ENTITY_TO_ENTITY, (InputArgument)(Entity)food, (InputArgument)(Entity)ped, (InputArgument)num, (InputArgument)0.095f, (InputArgument)0.02f, (InputArgument)0.0f, (InputArgument)82f, (InputArgument)(-180f), (InputArgument)(-180f), (InputArgument)true, (InputArgument)true, (InputArgument)false, (InputArgument)false, (InputArgument)0, (InputArgument)true);
            }
        }

        public static string getDrinksModelByTyoe(string drink_type)
        {
            string drinksModelByTyoe = "";
            string[] strArray = new string[0];
            if (drink_type == "coffee")
                strArray = HungerSystem.drinks_coffee;
            if (drink_type == "beer")
                strArray = HungerSystem.drinks_beer;
            if (strArray.Length != 0)
            {
                int index = Common.rnd.Next(0, strArray.Length - 1);
                drinksModelByTyoe = strArray[index];
            }
            return drinksModelByTyoe;
        }

        public static string getPedsDrinks(Ped ped, XDocument _doc, string drinkType = "")
        {
            string pedsDrinks = "";
            string name = ((PedHash)ped.Model).ToString();
            if (char.IsDigit(name[0]))
                name = "CustomPed_" + name;
            if (_doc.Element((XName)"WeaponList").Element((XName)name) == null)
                _doc.Element((XName)"WeaponList").Add((object)new XElement((XName)name));
            XElement xelement1 = _doc.Element((XName)"WeaponList").Element((XName)name);
            if (xelement1.Element((XName)"hunger") == null)
                xelement1.Add((object)new XElement((XName)"hunger"));
            XElement xelement2 = xelement1.Element((XName)"hunger");
            if (xelement2.Element((XName)"drinks") == null)
                xelement2.Add((object)new XElement((XName)"drinks"));
            XElement xelement3 = xelement2.Element((XName)"drinks");
            if (drinkType != "")
            {
                XElement xelement4 = xelement3.Element((XName)drinkType);
                pedsDrinks = xelement4 == null || Main.TryToConvertInt32(xelement4.Value) <= 0 ? "" : drinkType;
            }
            else if (xelement3.Elements() != null)
            {
                foreach (XElement element in xelement3.Elements())
                {
                    if (Main.TryToConvertInt32(element.Value) > 0)
                        pedsDrinks = element.Name.ToString();
                }
            }
            return pedsDrinks;
        }

        public static int getPedDrinksCount(Ped ped, string drinkType, XDocument _doc)
        {
            int pedDrinksCount = 0;
            string name = ((PedHash)ped.Model).ToString();
            if (char.IsDigit(name[0]))
                name = "CustomPed_" + name;
            if (_doc.Element((XName)"WeaponList").Element((XName)name) == null)
                _doc.Element((XName)"WeaponList").Add((object)new XElement((XName)name));
            XElement xelement1 = _doc.Element((XName)"WeaponList").Element((XName)name);
            if (xelement1.Element((XName)"hunger") == null)
                xelement1.Add((object)new XElement((XName)"hunger"));
            XElement xelement2 = xelement1.Element((XName)"hunger");
            if (xelement2.Element((XName)"drinks") == null)
                xelement2.Add((object)new XElement((XName)"drinks"));
            XElement xelement3 = xelement2.Element((XName)"drinks");
            if (drinkType != "")
            {
                if (xelement3.Element((XName)drinkType) != null)
                    pedDrinksCount = Main.TryToConvertInt32(xelement3.Element((XName)drinkType).Value);
            }
            else if (xelement3.Elements() != null)
            {
                foreach (XElement element in xelement3.Elements())
                    pedDrinksCount += Main.TryToConvertInt32(element.Value);
            }
            return pedDrinksCount;
        }

        public static void updatePedDrinksCount(
          Ped ped,
          string drinkType,
          int drinksCount,
          XDocument _doc)
        {
            string name = ((PedHash)ped.Model).ToString();
            if (char.IsDigit(name[0]))
                name = "CustomPed_" + name;
            if (_doc.Element((XName)"WeaponList").Element((XName)name) == null)
                _doc.Element((XName)"WeaponList").Add((object)new XElement((XName)name));
            XElement xelement1 = _doc.Element((XName)"WeaponList").Element((XName)name);
            if (xelement1.Element((XName)"hunger") == null)
                xelement1.Add((object)new XElement((XName)"hunger"));
            XElement xelement2 = xelement1.Element((XName)"hunger");
            if (xelement2.Element((XName)"drinks") == null)
                xelement2.Add((object)new XElement((XName)"drinks"));
            XElement xelement3 = xelement2.Element((XName)"drinks");
            if (xelement3.Element((XName)drinkType) == null)
                xelement3.Add((object)new XElement((XName)drinkType, (object)Main.TryToConvertInt32(drinksCount.ToString()).ToString()));
            else
                xelement3.Element((XName)drinkType).Value = Main.TryToConvertInt32(drinksCount.ToString()).ToString();
            Common.saveDoc(_doc);
        }

        public static void clearDrink(Ped ped, string DrinkModel)
        {
            Prop[] allProps = World.GetAllProps((Model)Main.GetHashKey(DrinkModel));
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

        public static Prop createDrink(
          Ped ped,
          Vector3 pos,
          string DrinkModel = "p_amb_coffeecup_01",
          bool attach = true,
          bool leftHandAttach = false,
          int attachPositionType = 0)
        {
            Prop[] nearbyProps = World.GetNearbyProps(ped.Position, 5f, (Model)DrinkModel);
            Prop prop;
            if (nearbyProps.Length == 0)
            {
                prop = World.CreateProp((Model)DrinkModel, pos, true, true);
            }
            else
            {
                prop = nearbyProps[0];
                if (!prop.IsAttachedTo((Entity)ped))
                    prop = World.CreateProp((Model)DrinkModel, pos, true, true);
            }
            if ((Entity)prop != (Entity)null && attach)
                HungerSystem.AttachDrink(ped, prop, leftHandAttach, attachPositionType);
            return prop;
        }

        public static void AttachDrink(
          Ped ped,
          Prop Drink,
          bool leftHandAttach = false,
          int attachPositionType = 0)
        {
            if (!leftHandAttach)
            {
                int num = Function.Call<int>(Hash.GET_PED_BONE_INDEX, (InputArgument)(Entity)ped, (InputArgument)57005);
                Function.Call(Hash.ATTACH_ENTITY_TO_ENTITY, (InputArgument)(Entity)Drink, (InputArgument)(Entity)ped, (InputArgument)num, (InputArgument)0.145f, (InputArgument)0.05f, (InputArgument)(-0.025f), (InputArgument)(-75f), (InputArgument)15f, (InputArgument)(-20f), (InputArgument)true, (InputArgument)true, (InputArgument)false, (InputArgument)true, (InputArgument)1, (InputArgument)true);
            }
            else
            {
                int num = Function.Call<int>(Hash.GET_PED_BONE_INDEX, (InputArgument)(Entity)ped, (InputArgument)18905);
                Function.Call(Hash.ATTACH_ENTITY_TO_ENTITY, (InputArgument)(Entity)Drink, (InputArgument)(Entity)ped, (InputArgument)num, (InputArgument)0.095f, (InputArgument)0.02f, (InputArgument)0.0f, (InputArgument)82f, (InputArgument)(-180f), (InputArgument)(-180f), (InputArgument)true, (InputArgument)true, (InputArgument)false, (InputArgument)false, (InputArgument)0, (InputArgument)true);
            }
        }

        public static int getPedFoodCount(Ped ped, string foodType, XDocument _doc)
        {
            int pedFoodCount = 0;
            string name = ((PedHash)ped.Model).ToString();
            if (char.IsDigit(name[0]))
                name = "CustomPed_" + name;
            if (_doc.Element((XName)"WeaponList").Element((XName)name) == null)
                _doc.Element((XName)"WeaponList").Add((object)new XElement((XName)name));
            XElement xelement1 = _doc.Element((XName)"WeaponList").Element((XName)name);
            if (xelement1.Element((XName)"hunger") == null)
                xelement1.Add((object)new XElement((XName)"hunger"));
            XElement xelement2 = xelement1.Element((XName)"hunger");
            if (xelement2.Element((XName)"food") == null)
                xelement2.Add((object)new XElement((XName)"food"));
            XElement xelement3 = xelement2.Element((XName)"food");
            if (foodType != "")
            {
                if (xelement3.Element((XName)foodType) != null)
                    pedFoodCount = Main.TryToConvertInt32(xelement3.Element((XName)foodType).Value);
            }
            else if (xelement3.Elements() != null)
            {
                foreach (XElement element in xelement3.Elements())
                    pedFoodCount += Main.TryToConvertInt32(element.Value);
            }
            return pedFoodCount;
        }

        public static void updatePedFoodCount(Ped ped, string foodType, int foodCount, XDocument _doc)
        {
            string name = ((PedHash)ped.Model).ToString();
            if (char.IsDigit(name[0]))
                name = "CustomPed_" + name;
            if (_doc.Element((XName)"WeaponList").Element((XName)name) == null)
                _doc.Element((XName)"WeaponList").Add((object)new XElement((XName)name));
            XElement xelement1 = _doc.Element((XName)"WeaponList").Element((XName)name);
            if (xelement1.Element((XName)"hunger") == null)
                xelement1.Add((object)new XElement((XName)"hunger"));
            XElement xelement2 = xelement1.Element((XName)"hunger");
            if (xelement2.Element((XName)"food") == null)
                xelement2.Add((object)new XElement((XName)"food"));
            XElement xelement3 = xelement2.Element((XName)"food");
            if (xelement3.Element((XName)foodType) == null)
                xelement3.Add((object)new XElement((XName)foodType, (object)Main.TryToConvertInt32(foodCount.ToString()).ToString()));
            else
                xelement3.Element((XName)foodType).Value = Main.TryToConvertInt32(foodCount.ToString()).ToString();
            Common.saveDoc(_doc);
        }
    }
}
