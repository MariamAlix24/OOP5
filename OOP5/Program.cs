namespace OOP5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Part 01 — Theoretical Questions
            #region Q1  Object Copying
            //a)When you assign one object variable to another, you copy the reference (memory address) of the object, not the actual object itself.
            //b)No, it does not create a new object. Both variables will point to the exact same object in memory, so modifying one affects the other.
            //c)Copying a reference: Copies only the memory address. Both variables refer to the same object.
            //-Copying an object: Creates a new, independent object in memory with the same values.
            #endregion
            #region Q2  Shallow Copy vs Deep Copy
            //a) A Shallow Copy creates a new object and copies all value-type fields, but it only copies the references for reference - type fields.
            //b) A Deep Copy creates a new object and recursively duplicates all referenced objects, making a fully independent copy.
            //c) Reference - type members are shared between both the original and copied objects. Modifying a reference - type member in one affects the other.
            //d) Reference - type members are completely duplicated as new objects.Changing them in the copied object will NOT affect the original.
            //e) When an object contains mutable reference-type fields(like a list or another object) that will be modified later, and you want to ensure the original data remains unchanged.
            #endregion
            #region Q3  Static Members
            //a)A static field belongs to the class itself and is shared by all instances, while an instance field belongs to a specific object and has a separate copy for each object.
            //b)A static method belongs to the class and can be called without creating an object. It CANNOT directly access instance members because it does not operate on a specific object instance.
            //c)A static constructor is used to initialize static data or perform actions that need to be done once. It is executed automatically before the first instance is created or any static member is referenced.
            //d)A static class is a class that contains only static members and cannot be instantiated or inherited. No, you CANNOT create an object from a static class.
            #endregion
            #region Q4  Extension Methods
            //a)An extension method allows you to add new methods to an existing type without modifying its original source code, inheriting from it, or recompiling it.
            //b)The this keyword must be used before the type in the first parameter.
            //c)An extension method must be declared inside a non-nested, non-generic static class.
            //d)No, an extension method cannot access private or protected members of the class it extends. It can only access public members.
            #endregion
            #region Q5  Partial Classes and Partial Methods
            //a)A Partial Class allows the definition of a single class to be split across multiple physical files. When compiled, all parts are combined into one class.
            //b)Developers split a class to make large codebases easier to manage, to allow multiple developers to work on different parts of the class at the same time, or to separate auto-generated code from custom code.
            //c) A Partial Method is a method declared in one part of a partial class and optionally implemented in another part of the same class.
            //d) If a partial method has no implementation, the compiler completely removes its declaration and all calls to it at compile-time, so there is no performance overhead.
            #endregion
            #endregion
            #region Part 02 — Practical
            #region 1  Object Copying Test
            /*DeliveryAddress addr = new DeliveryAddress("Cairo", "Main St", 5);
            StandardShipment original = new StandardShipment("TR001", "Books", 2.0m, 10.0m, addr);
            Shipment assigned = original;
            assigned.UpdateWeight(5.0m);
            Console.WriteLine($"Original Weight: {original.Weight}");
            Console.WriteLine($"Assigned Weight: {assigned.Weight}");
            Shipment copied = original.CopyShipment();
            copied.UpdateWeight(10.0m);
            Console.WriteLine($"Original Weight: {original.Weight}");
            Console.WriteLine($"Copied Weight:   {copied.Weight}");*/
            #endregion
            #region 2  Shallow Copy Test
            /*DeliveryAddress originalAddress = new DeliveryAddress("Cairo", "El-Nasr St", 15);
            StandardShipment originalShipment = new StandardShipment("TR505", "Laptop", 3.0m, 20.0m, originalAddress);
            Shipment copiedShipment = originalShipment.ShallowCopy();
            Console.WriteLine($"Original Address: {originalShipment.Destination.GetFullAddress()}");
            Console.WriteLine($"Copied Address:   {copiedShipment.Destination.GetFullAddress()}");
            copiedShipment.Destination.city = "Alexandria";
            Console.WriteLine($"Original Address: {originalShipment.Destination.GetFullAddress()}");
            Console.WriteLine($"Copied Address:   {copiedShipment.Destination.GetFullAddress()}");*/
            #endregion
            #region 3  Deep Copy Test
            /*DeliveryAddress address = new DeliveryAddress("Cairo", "El-Tahrir St", 10);
            StandardShipment original = new StandardShipment("TR909", "Phone", 1.0m, 15.0m, address);
            Shipment copied = original.DeepCopy();
            Console.WriteLine("Original Address: " + original.Destination.city);
            Console.WriteLine("Copied Address:   " + copied.Destination.city);
            copied.Destination.city = "Giza";
            Console.WriteLine("Original Address: " + original.Destination.city);
            Console.WriteLine("Copied Address:   " + copied.Destination.city);
            bool isSame = ReferenceEquals(original.Destination, copied.Destination);
            Console.WriteLine("Same Address Object? " + isSame);*/
            #endregion
            #region 4&5&6  Static Test
            /*Console.WriteLine($"Total Shipments Created : {Shipment.GetTotalShipmentsCreated()}");
            DeliveryAddress addr = new DeliveryAddress("Cairo", "Tahrir St", 5);
            StandardShipment s1 = new StandardShipment("TR001", "Books", 2.0m, 10.0m, addr);
            ExpressShipment s2 = new ExpressShipment("TR002", "Laptop", 3.0m, 20.0m, addr, 15.0m);
            CompletedShipment s3 = new CompletedShipment("TR003", "Phone", 1.0m, 12.0m, addr);
            Console.WriteLine($"Total Shipments Created : {Shipment.GetTotalShipmentsCreated()}");*/
            #endregion
            #region 11  Main() Checklist
            DeliveryUtilities.PrintSeparator();
            Console.WriteLine("Smart Delivery Management System");
            DeliveryUtilities.PrintSeparator();
            DeliveryUtilities.PrintSeparator();
            Console.WriteLine("Creating Shipments...");
            DeliveryUtilities.PrintSeparator();
            DeliveryAddress address1 = new DeliveryAddress("Cairo", "Tahrir St", 5);
            DeliveryAddress address2 = new DeliveryAddress("Cairo", "Naser St", 10);
            DeliveryAddress address3 = new DeliveryAddress("Alex", "Corniche", 12);
            StandardShipment origShipment = new StandardShipment("SH001", "Books", 3.0m, 10.0m, address1);
            Console.WriteLine("Standard Shipment Created");
            ExpressShipment expShipment = new ExpressShipment("SH002", "Laptop", 2.0m, 20.0m, address2, 15.0m);
            Console.WriteLine("Express Shipment Created");
            InternationalShipment intShipment = new InternationalShipment("SH003", "Phones", 8.0m, 50.0m, address3, "Customs Cleared",30.0m );
            Console.WriteLine("International Shipment Created");
            Console.WriteLine($"Total Shipments Created : {Shipment.GetTotalShipmentsCreated()}");
            DeliveryUtilities.PrintSeparator();
            Console.WriteLine("Object Copying");
            DeliveryUtilities.PrintSeparator();
            Shipment assignedShipment = origShipment;
            Console.WriteLine($"Original Shipment  : {origShipment.TrackingCode}");
            Console.WriteLine($"Assigned Shipment  : {assignedShipment.TrackingCode}");
            Console.WriteLine($"Same Object : {ReferenceEquals(origShipment, assignedShipment)}");
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("Shallow Copy");
            Console.WriteLine("------------------------------------------");
            StandardShipment shallowCopy = (StandardShipment)origShipment.ShallowCopy();
            Console.WriteLine($"Original Shipment Address : {origShipment.Destination.city}");
            Console.WriteLine($"Copied Shipment Address   : {shallowCopy.Destination.city}");
            Console.WriteLine("Changing copied shipment address...");
            shallowCopy.Destination.city = "Giza";
            Console.WriteLine($"Original Shipment Address : {origShipment.Destination.city}");
            Console.WriteLine($"Copied Shipment Address   : {shallowCopy.Destination.city}");
            Console.WriteLine($"Same DeliveryAddress Object : {ReferenceEquals(origShipment.Destination, shallowCopy.Destination)}");
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("Deep Copy");
            Console.WriteLine("------------------------------------------");
            origShipment.Destination.city = "Cairo";
            StandardShipment deepCopy = (StandardShipment)origShipment.DeepCopy();
            Console.WriteLine($"Original Shipment Address : {origShipment.Destination.city}");
            Console.WriteLine($"Copied Shipment Address   : {deepCopy.Destination.city}");
            Console.WriteLine("Changing copied shipment address...");
            deepCopy.Destination.city = "Giza";
            Console.WriteLine($"Original Shipment Address : {origShipment.Destination.city}");
            Console.WriteLine($"Copied Shipment Address   : {deepCopy.Destination.city}");
            Console.WriteLine($"Same DeliveryAddress Object : {ReferenceEquals(origShipment.Destination, deepCopy.Destination)}");
            DeliveryUtilities.PrintSeparator();
            Console.WriteLine("Extension Methods");
            DeliveryUtilities.PrintSeparator();
            expShipment.UpdateTrackingStatus("Out For Delivery");
            intShipment.UpdateTrackingStatus("Delivered");
            Console.WriteLine(origShipment.GetSummary());
            Console.WriteLine(expShipment.GetSummary());
            Console.WriteLine(intShipment.GetSummary());
            Console.WriteLine($"SH001 Is Delivered : {origShipment.IsDelivered()}");
            Console.WriteLine($"SH003 Is Delivered : {intShipment.IsDelivered()}");
            DeliveryUtilities.PrintSeparator();
            Console.WriteLine("Tracking Status");
            DeliveryUtilities.PrintSeparator();
            origShipment.UpdateTrackingStatus("Out For Delivery");
            DeliveryUtilities.PrintSeparator();
            Console.WriteLine("Static Utilities");
            DeliveryUtilities.PrintSeparator();
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("Delivery Center");
            Console.WriteLine("------------------------------------------");
            Console.WriteLine($"Total Shipments Created : {Shipment.GetTotalShipmentsCreated()}");
            DeliveryUtilities.PrintSeparator();
            Console.WriteLine("Partial Method");
            DeliveryUtilities.PrintSeparator();
            origShipment.UpdateTrackingStatus("Delivered");
            DeliveryUtilities.PrintSeparator();
            Console.WriteLine("Assignment Completed");
            DeliveryUtilities.PrintSeparator();
            #endregion
            #endregion
        }
    }
}
