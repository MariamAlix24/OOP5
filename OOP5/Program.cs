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
        }
    }
}
