using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using MoreLinq;
using System.Text.Json.Serialization;

namespace LightningNotification
{
    public class LightningChecker
    {
        // Gets the assets and convert it into List
        public LightningChecker(List<Assets> assets)
        {
            assetsContainer = assets;
        }

        // Deserialize assets from json to object
        public LightningChecker(string assetsJson)
        {
            assetsContainer = JsonConvert.DeserializeObject<List<Assets>>(assetsJson);
        }

        List<Assets> assetsContainer;

        // Prints the matched Asset Owner and Asset Name
        static void sendNotification(Assets asset)
        {
            Console.WriteLine("lightning alert for {0}:{1}", asset.AssetOwner, asset.AssetName);
        }

        // Used to Nofify the Asset for a specific lightning strike
        public void NotifyLightningStrike(Lightning lightning)
        {
            // A 'heartbeat' flashType is not a lightning strike. It is used internally by the software to maintain connection.
            if (lightning.FlashTypes == Lightning.FlashType.HeartBeat)
            {
                // Return immediately since reported lightning is not a real one.
                return;
            }

            // Identify the assets that has been striked by lightning
            var assetsStriked = LightningStrikeReceived(lightning);
            foreach (var asset in assetsStriked.ToList())
            {
                sendNotification(asset);
                assetsContainer.RemoveAll(x => x.AssetOwner.Equals(asset.AssetOwner) && x.QuadKey.Equals(asset.QuadKey));
            }
        }

        // Deserialize lightning from json to object
        public void NotifyLightningStrike(string lightning)
        {
            if (string.IsNullOrWhiteSpace(lightning))
            {
                return;
            }
            this.NotifyLightningStrike(JsonConvert.DeserializeObject<Lightning>(lightning));
        }

        // Converts the lightning properties into a matching quadkey using 
        IEnumerable<Assets> LightningStrikeReceived(Lightning lightning)
        {
            int levelOfDetail = 12;

            TileSystem.LatLongToPixelXY(lightning.Latitude, lightning.Longitude, levelOfDetail, out int pixelX, out int pixelY);
            TileSystem.PixelXYToTileXY(pixelX, pixelY, out int tileX, out int tileY);

            string quadKey = TileSystem.TileXYToQuadKey(tileX, tileY, levelOfDetail);

            return assetsContainer.Where(x => x.QuadKey.Equals(quadKey)).DistinctBy(x => new { x.AssetOwner, x.QuadKey });
        }
    }
}
