using Newtonsoft;
using System;
using System.Text;

namespace LightningNotification
{
    // Contains all the properties for Lightning
    public class Lightning
    {
        // Values for FlashType
        public enum FlashType
        {
            CloudToGround = 0,
            CloudToCloud = 1,
            HeartBeat = 9
        }

        /// <summary>  
        /// Flash Type
        /// </summary>  
        public FlashType FlashTypes { get; set; }

        /// <summary>  
        /// Strike Time - the number of milliseconds since January 1, 1970, 00:00:00 GMT
        /// </summary>  
        public long StrikeTime { get; set; }

        /// <summary>  
        /// Latitude
        /// </summary>  
        public double Latitude { get; set; }

        /// <summary>  
        /// Longitude
        /// </summary>  
        public double Longitude { get; set; }

        /// <summary>  
        /// PeakAmps
        /// </summary>  
        public double PeakAmps { get; set; }

        /// <summary>  
        /// Reserved
        /// </summary>  
        public string Reserved { get; set; }

        /// <summary>  
        /// IcHeight
        /// </summary>  
        public double IcHeight { get; set; }

        /// <summary>  
        /// ReceivedTime
        /// </summary>  
        public long ReceivedTime { get; set; }

        /// <summary>  
        /// NumberOfSensors
        /// </summary>  
        public double NumberOfSensors { get; set; }

        /// <summary>  
        /// Multiplicity
        /// </summary>  
        public double Multiplicity { get; set; }

        /// <summary>  
        /// Overrride ToString()
        /// </summary>  
        public override string ToString()
        {
            var properties = this.GetType().GetProperties();

            var stringBuilder = new StringBuilder();

            foreach (var property in properties)
            {
                var val = property.GetValue(this, null) ?? "(null)";
                stringBuilder.AppendLine(property.Name + ": " + val.ToString());
            }

            return stringBuilder.ToString();
        }
    }
}
