namespace IdSourceGenerator
{
    using System;

    [AttributeUsage(AttributeTargets.Class|AttributeTargets.Struct, Inherited = true, AllowMultiple = false)]
    public class GameIdValueAttribute : Attribute
    {
        
    }
}