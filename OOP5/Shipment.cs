using System;
using System.Collections.Generic;
using System.Text;

namespace OOP5
{
    internal abstract partial class Shipment
    {
        private string trackingCode;
        private string description;
        private decimal weight;
        private decimal deliveryFee;
        public static int TotalShipmentsCreated { get; private set; } = 0;
        public string TrackingCode
        {
            get { return trackingCode; }
            private set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    trackingCode = value;
                }
            }
        }
        public string Description
        {
            get { return description; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    description = value;
                }
            }
        }
        public decimal Weight
        {
            get { return weight; }
            set
            {
                if (value > 0)
                {
                    weight = value;
                }
            }
        }
        public decimal DeliveryFee
        {
            get { return deliveryFee; }
            private set
            {
                if (value > 0)
                {
                    deliveryFee = value;
                }
            }
        }
        public DeliveryAddress Destination { get; set; }
        public abstract decimal EstimatedCost
        {
            get;
        }
        public Shipment(string trackingCode, string description, decimal weight, decimal deliveryFee, DeliveryAddress destination)
        {
            this.trackingCode = !string.IsNullOrWhiteSpace(trackingCode) ? trackingCode : "UNKNOWN";
            this.description = !string.IsNullOrWhiteSpace(description) ? description : "No Description";
            this.weight = weight > 0 ? weight : 1.0m;
            this.deliveryFee = deliveryFee > 0 ? deliveryFee : 10.0m;
            this.Destination = destination;
            TotalShipmentsCreated++;
        }

        public Shipment(string trackingCode)
            : this(trackingCode, "No Description", 1.0m, 10.0m, new DeliveryAddress("Cairo", "Egypt", 2))
        {
        }
        public void UpdateDeliveryFee(decimal newFee)
        {
            if (newFee > 0)
            {
                deliveryFee = newFee;
            }
        }
        public void UpdateWeight(decimal newWeight)
        {
            if (newWeight > 0)
            {
                weight = newWeight;
            }
        }
        public void UpdateWeight(decimal newWeight, decimal extraPackingWeight)
        {
            if (newWeight > 0 && extraPackingWeight >= 0)
            {
                weight = newWeight + extraPackingWeight;
            }
        }
        public abstract void PrintShipment();
        public abstract Shipment CopyShipment();
        public Shipment ShallowCopy()
        {
            return (Shipment)this.MemberwiseClone();
        }
        public abstract Shipment DeepCopy();
        static Shipment()
        {
            TotalShipmentsCreated = 0;
            Console.WriteLine("Shipment System Initialized");
        }
        public static int GetTotalShipmentsCreated()
        {
            return TotalShipmentsCreated;
        }
        partial void OnTrackingStatusChanged(string newStatus)
        {
            Console.WriteLine($"Tracking status changed to: {newStatus}");
        }
    }
}
