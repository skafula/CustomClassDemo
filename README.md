# CustomClassDemo
Short demo of creating custom class by implementing IList&lt;T> -> ICollection&lt;T> -> IEnumerable&lt;T> -> IEnumerable

The purpose of making a custom class is that there's the oppportunity to implement custom logic on the methods and properties.

Also implemented IEquatable to change the logic of Contains method. 
Contains checks the reference of the objects by default so sometimes needs to change the logic of Equals method used by Contains method.
