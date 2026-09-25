using System;
using System.Collections.Generic;
using System.Text;

namespace OOP5
{
    internal class PriorityInternationalShipment: InternationalShipment
    {
        public PriorityInternationalShipment(string trackingCode, string description, decimal weight, decimal deliveryFee, DeliveryAddress destination, string destinationCountry, decimal customsFee)
                 : base(trackingCode, description, weight, deliveryFee, destination, destinationCountry, customsFee)
        {
        }
        public sealed override void GenerateCustomsReport()
        {
            Console.WriteLine($"PRIORITY Customs Report for {TrackingCode} to {DestinationCountry}");
        }
        public override Shipment CopyShipment()
        {
            DeliveryAddress clonedAddress = new DeliveryAddress(Destination.city, Destination.street, Destination.BuildingNumber);
            return new PriorityInternationalShipment(TrackingCode, Description, Weight, DeliveryFee, clonedAddress, DestinationCountry, CustomsFee);
        }
        public override Shipment DeepCopy()
        {
            DeliveryAddress newAddress = new DeliveryAddress(Destination.city, Destination.street, Destination.BuildingNumber);
            return new PriorityInternationalShipment(TrackingCode, Description, Weight, DeliveryFee, newAddress, DestinationCountry, CustomsFee);
        }
    }
}
