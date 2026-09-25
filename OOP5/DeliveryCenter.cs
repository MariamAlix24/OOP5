using System;
using System.Collections.Generic;
using System.Text;

namespace OOP5
{
    internal class DeliveryCenter
    {
        public Driver Driver { get; set; }
        public string CenterName { get; set; }
        private Shipment[] shipments = new Shipment[20];
        public DeliveryCenter(string centerName)
        {
            CenterName = centerName;
        }
        public Shipment this[int index]
        {
            get
            {
                if (index >= 0 && index < shipments.Length)
                    return shipments[index];

                return null;
            }
        }
        public Shipment this[string trackingCode]
        {
            get
            {
                for (int i = 0; i < shipments.Length; i++)
                {
                    if (shipments[i] != null && shipments[i].TrackingCode == trackingCode)
                        return shipments[i];
                }
                return null;
            }
        }
        public bool AddShipment(Shipment shipment)
        {
            for (int i = 0; i < shipments.Length; i++)
            {
                if (shipments[i] == null)
                {
                    shipments[i] = shipment;
                    return true;
                }
            }
            return false;
        }
        public bool RemoveShipment(string trackingCode)
        {
            for (int i = 0; i < shipments.Length; i++)
            {
                if (shipments[i] != null && shipments[i].TrackingCode == trackingCode)
                {
                    shipments[i] = null;
                    return true;
                }
            }
            return false;
        }
        public void PrintAllShipments()
        {
            Console.WriteLine($"Delivery Center: {CenterName}");

            for (int i = 0; i < shipments.Length; i++)
            {
                if (shipments[i] != null)
                {
                    shipments[i].PrintShipment();
                }
            }
        }
        public void PrintTrackingStatuses()
        {
            foreach (Shipment shipment in shipments)
            {
                if (shipment is ITrackable trackableShipment)
                {
                    Console.WriteLine(trackableShipment.GetTrackingStatus());
                }
            }
        }
    }
}
