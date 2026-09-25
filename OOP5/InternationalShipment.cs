using System;
using System.Collections.Generic;
using System.Text;

namespace OOP5
{
    internal class InternationalShipment:Shipment, ITrackable, IInsurable
    {
        private string destinationCountry;
        private decimal customsFee;
        public string DestinationCountry
        {
            get { return destinationCountry; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    destinationCountry = value;
                }
            }
        }
        public decimal CustomsFee
        {
            get { return customsFee; }
            set
            {
                if (value >= 0)
                {
                    customsFee = value;
                }
            }
        }
        public InternationalShipment(string trackingCode, string description, decimal weight, decimal deliveryFee, DeliveryAddress destination, string destinationCountry, decimal customsFee)
            : base(trackingCode, description, weight, deliveryFee, destination)
        {
            DestinationCountry = destinationCountry;
            CustomsFee = customsFee;
        }
        public override void PrintShipment()
        {
            Console.WriteLine($"[International Shipment]");
            Console.WriteLine($"Tracking Code: {TrackingCode}");
            Console.WriteLine($"Description: {Description}");
            Console.WriteLine($"Weight: {Weight} kg");
            Console.WriteLine($"Delivery Fee: {DeliveryFee}");
            Console.WriteLine($"Destination Country: {DestinationCountry}");
            Console.WriteLine($"Customs Fee: {CustomsFee}");
            Console.WriteLine($"Estimated Cost: {EstimatedCost}");
            Console.WriteLine($"Destination: {Destination.GetFullAddress()}");
        }
        public override decimal EstimatedCost
        {
            get
            {
                return DeliveryFee + (Weight * 5m) + CustomsFee;
            }
        }
        public virtual void GenerateCustomsReport()
        {
            Console.WriteLine($"Customs Report for {TrackingCode} to {DestinationCountry}");
        }
        public string GetTrackingStatus()
        {
            return $"Shipment {TrackingCode} has been Delivered.";
        }
        public decimal CalculateInsurance()
        {
            return EstimatedCost * 0.12m; 
        }
        public override Shipment CopyShipment()
        {
            DeliveryAddress clonedAddress = new DeliveryAddress(Destination.city, Destination.street, Destination.BuildingNumber);
            return new InternationalShipment(TrackingCode, Description, Weight, DeliveryFee, clonedAddress, DestinationCountry, CustomsFee);
        }
        public override Shipment DeepCopy()
        {
            DeliveryAddress newAddress = new DeliveryAddress(Destination.city, Destination.street, Destination.BuildingNumber);
            return new InternationalShipment(TrackingCode, Description, Weight, DeliveryFee, newAddress, DestinationCountry, CustomsFee);
        }
    }
}
  