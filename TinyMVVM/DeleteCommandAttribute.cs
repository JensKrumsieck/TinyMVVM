using System;

namespace TinyMVVM
{
    /// <summary>
    /// Marks the DeleteMethod in ListingViewModel
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class DeleteCommandAttribute : Attribute
    { }
}
