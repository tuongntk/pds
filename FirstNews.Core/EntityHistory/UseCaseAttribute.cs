﻿using System;

namespace FirstNews.Core.EntityHistory
{
    /// <summary>
    /// This attribute is used to set the description for a single method or
    /// all methods of a class or interface.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class UseCaseAttribute : Attribute
    {
        public string Description { get; set; }
    }
}