using System;
using System.Collections.Generic;
using System.Text;

namespace OOP5
{
    internal sealed class CompletedShipment:Shipment
    { 
        public CompletedShipment(string trackingCode, string description, decimal weight, decimal deliveryFee, DeliveryAddress destination)
          : base(trackingCode, description, weight, deliveryFee, destination)
        {
        }
        public override decimal EstimatedCost
        {
            get { return DeliveryFee + (Weight * 5m); }
        }
        public override void PrintShipment()
        {
            Console.WriteLine($"[Completed Shipment]");
            Console.WriteLine($"Tracking Code: {TrackingCode}");
            Console.WriteLine($"Description: {Description}");
            Console.WriteLine($"Weight: {Weight} kg");
            Console.WriteLine($"Delivery Fee: {DeliveryFee}");
            Console.WriteLine($"Estimated Cost: {EstimatedCost}");
            Console.WriteLine($"Destination: {Destination.GetFullAddress()}");
        }
        public override Shipment CopyShipment()
        {
            DeliveryAddress clonedAddress = new DeliveryAddress(Destination.city, Destination.street, Destination.BuildingNumber);
            return new CompletedShipment(TrackingCode, Description, Weight, DeliveryFee, clonedAddress);
        }
        public override Shipment DeepCopy()
        {
            DeliveryAddress newAddress = new DeliveryAddress(Destination.city, Destination.street, Destination.BuildingNumber);
            return new CompletedShipment(TrackingCode, Description, Weight, DeliveryFee, newAddress);
        }
    }
}
