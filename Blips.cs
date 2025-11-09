using GTA;
using GTA.Math;

using System.Collections.Generic;
using System.Linq;


namespace GTAExpansion
{



    public  class Blips
    {
        public static List<Blip> storeBlips = new List<Blip>();
        public static int lastBlipUpdateTime = 0;
        public const int blipUpdateInterval = 5000;
        public static bool storeLocationsInitialized = false;

        public static void UpdateStoreBlips()
        {
            if (!Common.showBlips || Game.GameTime - lastBlipUpdateTime < blipUpdateInterval)
                return;

            lastBlipUpdateTime = Game.GameTime;

            // Delete old blips
            foreach (Blip blip in storeBlips)
            {
                if (blip.Exists()) blip.Delete();
            }
            storeBlips.Clear();

            // Create new blips
            foreach (Vector3 loc in Common.Store_Locations)
            {
                Blip blip = World.CreateBlip(loc);
                blip.Sprite = BlipSprite.Store;
                blip.Color = BlipColor.Green;
                blip.IsShortRange = true;
                blip.Name = "24/7 Store";
                storeBlips.Add(blip);
            }
        }

        public static void InitializeStoreLocations()
        {
            if (storeLocationsInitialized) return;

            Common.Store_Locations.AddRange(new List<Vector3>
    {
        new Vector3(1735.83f, 6419.51f, 35.0373f),
        new Vector3(1960.42f, 3748.89f, 32.3438f),
        new Vector3(2682.55f, 3282.32f, 55.24f),
        new Vector3(1700.17f, 4927.65f, 46.93f),
        new Vector3(-2974.73f, 390.8f, 22.5f),
        new Vector3(1138.54f, -951.4f, 50.16f),
        new Vector3(29.15f, -1344.53f, 36.23f),
        new Vector3(-1224.34f, -905.99f, 19.47f),
        new Vector3(1394.16919f, 3599.86f, 34.0121f),
        new Vector3(-3038.9082f, 589.5187f, 6.9048f),
        new Vector3(-3240.317f, 1004.43341f, 11.8307f),
        new Vector3(544.2802f, 2672.81128f, 41.1566f),
        new Vector3(2559.247f, 385.5266f, 107.623f),
        new Vector3(376.6533f, 323.6471f, 102.5664f),
        new Vector3(1166.392f, 2703.50415f, 37.1573f),
        new Vector3(-2973.26172f, 390.8184f, 14.0433f),
        new Vector3(-1491.05652f, -383.5728f, 39.1706f),
        new Vector3(1698.80847f, 4929.19775f, 41.0783f),
        new Vector3(-711.721f, -916.6965f, 18.2145f),
        new Vector3(-53.124f, -1756.4054f, 28.421f),
        new Vector3(1159.54211f, -326.6986f, 67.923f),
        new Vector3(-1822.28662f, 788.006f, 137.1859f)
    });

            storeLocationsInitialized = true;
        }







    }
}
