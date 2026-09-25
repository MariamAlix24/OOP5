using System;
using System.Collections.Generic;
using System.Text;

namespace OOP5
{
    internal class ExpressShipment:Shipment,ITrackable,IInsurable
    {
        private decimal extraFee;
        public decimal ExtraFee
        {
            get { return extraFee; }
            set
            {
                if (value >= 0)
                {
                    extraFee = value;
                }
            }
        }

        public ExpressShipment(string trackingCode, string description, decimal weight, decimal deliveryFee, DeliveryAddress destination, decimal extraFee)
            : base(trackingCode, description, weight, deliveryFee, destination)
        {
            ExtraFee = extraFee;
        }
        public override decimal EstimatedCost
        {
            get
            {
                return DeliveryFee + (Weight * 5m) + ExtraFee; 
            }
        }
        public override void PrintShipment()
        {
            Console.WriteLine($"[Express Shipment]");
            Console.WriteLine($"Tracking Code: {TrackingCode}");
            Console.WriteLine($"Description: {Description}");
            Console.WriteLine($"Weight: {Weight} kg");
            Console.WriteLine($"Delivery Fee: {DeliveryFee}");
            Console.WriteLine($"Extra Fee: {ExtraFee}");
            Console.WriteLine($"Estimated Cost: {EstimatedCost}");
            Console.WriteLine($"Destination: {Destination.GetFullAddress()}");
        }
        public string GetTrackingStatus()
        {
            return $"Shipment {TrackingCode} is Out for Delivery.";
        }
        public decimal CalculateInsurance()
        {
            return EstimatedCost * 0.08m;
        }
        public override Shipment CopyShipment()
        {
            DeliveryAddress clonedAddress = new DeliveryAddress(Destination.city, Destination.street, Destination.BuildingNumber);
            return new ExpressShipment(TrackingCode, Description, Weight, DeliveryFee, clonedAddress, ExtraFee);
        }
        public override Shipment DeepCopy()
        {
            DeliveryAddress newAddress = new DeliveryAddress(Destination.city, Destination.street, Destination.BuildingNumber);
            return new ExpressShipment(TrackingCode, Description, Weight, DeliveryFee, newAddress, ExtraFee);
        }
    }
}
