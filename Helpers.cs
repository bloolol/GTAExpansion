using GTA;
using GTA.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTAExpansion
{
    public static class Helpers
    {

        // public static ScriptSettings config = ScriptSettings.Load("scripts\\Okoniewitz\\NotUselessArmor.ini");
        public static int[] Armor = new int[10]
        {
      64729,
      10706,
      23553,
      24816,
      24817,
      24818,
      57597,
      0,
      11816,
      56604
        };
        public static int ArmorPlayer = 0;
        public static int[,] Modeles;

        public static int GetArmorType()
        {
            int armor = Game.Player.Character.Armor;
            if (armor > 80)
                return 5;
            if (armor > 60)
                return 4;
            if (armor > 40)
                return 3;
            return armor > 20 ? 2 : (armor > 0 ? 1 : 0);
        }

        public static int GetPlayerID()
        {
            Ped Player = Game.Player.Character;

            if (Player.Model.Hash == Helpers.GetHashKey("PLAYER_TWO"))
                return 2;
            Model model = Player.Model;
            if (model.Hash == Helpers.GetHashKey("PLAYER_ONE"))
                return 1;
            model = Player.Model;
            return model.Hash == Helpers.GetHashKey("PLAYER_ZERO") ? 0 : 3;
        }

        private static int GetHashKey(string value)
        {
            return Function.Call<int>(Hash.GET_HASH_KEY, new InputArgument[1]
            {
        (InputArgument) value
            });
        }



        public static int[,] CharacterClothes = new int[3, 3]
{
    {
      8,
      17,
      0
    },
    {
      8,
      6,
      14
    },
    {
      8,
      8,
      14
    }
};
    }
}
