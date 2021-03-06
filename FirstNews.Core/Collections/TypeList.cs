﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace FirstNews.Core.Collections
{
    /// <summary>
    /// A shortcut for <see cref="TypeList{TBaseType}"/> to use object as base type.
    /// </summary>
    public class TypeList : TypeList<object>, ITypeList { }

    /// <summary>
    /// Extends <see cref="List{Type}"/> to add restriction a specific base type.
    /// </summary>
    /// <typeparam name="TBaseType">Base Type of <see cref="Type"/>s in this list</typeparam>
    public class TypeList<TBaseType> : ITypeList<TBaseType>
    {
        /// <summary>
        /// Gets the count.
        /// </summary>
        /// <value>The count.</value>
        public int Count { get { return _typeList.Count; } }

        /// <summary>
        /// Gets a value indicating whether this instance is read only.
        /// </summary>
        /// <value><c>true</c> if this instance is read only; otherwise, <c>false</c>.</value>
        public bool IsReadOnly { get { return false; } }

        /// <summary>
        /// Gets or sets the <see cref="Type"/> at the specified index.
        /// </summary>
        /// <param name="index">Index.</param>
        public Type this[int index]
        {
            get { return _typeList[index]; }
            set
            {
                CheckType(value);
                _typeList[index] = value;
            }
        }

        private readonly List<Type> _typeList;

        /// <summary>
        /// Creates a new <see cref="TypeList{T}"/> object.
        /// </summary>
        public TypeList()
        {
            _typeList = new List<Type>();
        }

        public void Add<T>() where T : TBaseType
        {
            _typeList.Add(typeof(T));
        }

        public void Add(Type item)
        {
            CheckType(item);
            _typeList.Add(item);
        }

        public void Insert(int index, Type item)
        {
            _typeList.Insert(index, item);
        }

        public int IndexOf(Type item)
        {
            return _typeList.IndexOf(item);
        }

        public bool Contains<T>() where T : TBaseType
        {
            return Contains(typeof(T));
        }

        public bool Contains(Type item)
        {
            return _typeList.Contains(item);
        }

        public void Remove<T>() where T : TBaseType
        {
            _typeList.Remove(typeof(T));
        }

        public bool Remove(Type item)
        {
            return _typeList.Remove(item);
        }

        public void RemoveAt(int index)
        {
            _typeList.RemoveAt(index);
        }

        public void Clear()
        {
            _typeList.Clear();
        }

        public void CopyTo(Type[] array, int arrayIndex)
        {
            _typeList.CopyTo(array, arrayIndex);
        }

        public IEnumerator<Type> GetEnumerator()
        {
            return _typeList.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _typeList.GetEnumerator();
        }

        private static void CheckType(Type item)
        {
            if (!typeof(TBaseType).GetTypeInfo().IsAssignableFrom(item))
                throw new ArgumentException("Given item is not type of " + typeof(TBaseType).AssemblyQualifiedName, "item");
        }
    }
}
