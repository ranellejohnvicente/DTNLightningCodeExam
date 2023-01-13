using LightningNotification;
using System;
using System.IO;
using Newtonsoft.Json;

namespace LightningStrikeApp
{
    class Program
    {
        static void Main()
        {
            // Used to read the assets json file
            using var lightningAssetsReader = new StreamReader("assets.json");
            string assets = lightningAssetsReader.ReadToEnd();
            LightningChecker lightningChecker = null;

            try
            {
                lightningChecker = new LightningChecker(assets);
            }
            catch (Exception ex)
            {
                if (ex is JsonException)
                {
                    Console.WriteLine("This Asset Format is invalid.");
                    Console.WriteLine();
                }
                throw;
            }

            // Used to read the lightning json file
            using var lightningStreamReader = new StreamReader(@"lightning.json");
            string lightningStrike;
            int lightningStrikeNumber = 0;

            // Loop through the Lightning Strikes to Alert the Assets.
            while ((lightningStrike = lightningStreamReader.ReadLine()) != null)
            {
                lightningStrikeNumber++;

                try
                {
                    lightningChecker.NotifyLightningStrike(lightningStrike);
                }
                catch (Exception ex)
                {
                    if (ex is JsonException)
                    {
                        Console.WriteLine("The Lightning Strike JSON Object from Line: {0}", lightningStrikeNumber + " is invalid.");
                        Console.WriteLine(lightningStrike);
                        Console.WriteLine();
                        continue;
                    }
                    throw;
                }
            }
        }
    }
}
