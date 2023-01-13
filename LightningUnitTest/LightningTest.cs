using System;
using System.IO;
using Newtonsoft.Json;
using NUnit.Framework;
using LightningNotification;


namespace LightningUnitTest
{
    public class LightningTest
    {
        [SetUp]
        // Deserialize assets from json to object
        public void Setup()
        {
            using var assetReader = new StreamReader("assets.json");
            string assetsJson = assetReader.ReadToEnd();
            lightningChecker = new LightningChecker(assetsJson);
        }

        LightningChecker lightningChecker;

        [Test]
        // Checks if the method provides an input parameter
        public void EmptyString()
        {
            lightningChecker.NotifyLightningStrike("");
            Assert.Pass();
        }

        [Test]
        // Checks if the method provides an valid parameter format
        public void ValidLightningFormat()
        {
            lightningChecker.NotifyLightningStrike("{\"flashType\":1,\"strikeTime\":1446760902380,\"latitude\":10.5799716,\"longitude\":-14.0589797,\"peakAmps\":3117,\"reserved\":\"000\",\"icHeight\":18831,\"receivedTime\":1446760915182,\"numberOfSensors\":8,\"multiplicity\":1}");
            Assert.Pass();
        }

        [Test]
        // Checks if the method provides an valid Latitude format
        public void InvalidLatitude()
        {
            try
            {
                lightningChecker.NotifyLightningStrike("{\"flashType\":1,\"strikeTime\":1446760902380,\"latitude\":\"10.5799716\",\"longitude\":-14.0589797,\"peakAmps\":3117,\"reserved\":\"000\",\"icHeight\":18831,\"receivedTime\":1446760915182,\"numberOfSensors\":8,\"multiplicity\":1}");
            }
            catch (Exception ex)
            {
                if (ex is JsonException)
                {
                    Assert.Pass();
                }
            }
            Assert.Fail();
        }

        [Test]
        // Checks if the method provides an input parameter for Longitude
        public void NoLongitude()
        {
            try
            {
                lightningChecker.NotifyLightningStrike("{\"flashType\":1,\"strikeTime\":1446760902380,\"latitude\":\"10.5799716\",\"peakAmps\":3117,\"reserved\":\"000\",\"icHeight\":18831,\"receivedTime\":1446760915182,\"numberOfSensors\":8,\"multiplicity\":1}");
            }
            catch (Exception ex)
            {
                if (ex is JsonException)
                {
                    Assert.Pass();
                }
            }
            Assert.Fail();
        }
    }
}
