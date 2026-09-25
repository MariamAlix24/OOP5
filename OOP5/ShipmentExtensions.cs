using System;
using System.Collections.Generic;
using System.Text;

namespace OOP5
{
    internal  static class ShipmentExtensions
    {
        public static string GetSummary(this Shipment shipment)
        {
            if (shipment == null) return string.Empty;
            string typeName = shipment.GetType().Name.Replace("Shipment", "");
            if (string.IsNullOrEmpty(typeName)) typeName = "Standard";
            return $"{shipment.TrackingCode} | {typeName} | {shipment.Weight} KG | {shipment.GetTrackingStatus()}";
        }
        public static bool IsDelivered(this Shipment shipment)
        {
            if (shipment == null) return false;
            return shipment.GetTrackingStatus().Equals("Delivered", StringComparison.OrdinalIgnoreCase);
        }
    }
}

