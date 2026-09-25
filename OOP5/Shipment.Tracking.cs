using System;
using System.Collections.Generic;
using System.Text;

namespace OOP5
{
    internal abstract partial class Shipment
    {
        public string TrackingStatus { get; set; } = "In Transit";
        partial void OnTrackingStatusChanged(string newStatus);
        public string GetTrackingStatus()
        {
            return TrackingStatus;
        }

        public void UpdateTrackingStatus(string newStatus)
        {
            if (!string.IsNullOrWhiteSpace(newStatus))
            {
                TrackingStatus = newStatus;
                OnTrackingStatusChanged(newStatus);
            }
        }
    }
}
