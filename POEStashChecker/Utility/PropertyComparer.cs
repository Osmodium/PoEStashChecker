using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;

namespace POEStashChecker.Utility
{
    public class PropertyComparer<T> : IComparer<T>
    {
        private readonly IComparer m_Comparer;
        private PropertyDescriptor m_PropertyDescriptor;
        private int m_Reverse;

        public PropertyComparer(PropertyDescriptor property, ListSortDirection direction)
        {
            m_PropertyDescriptor = property;
            Type comparerForPropertyType = typeof(Comparer<>).MakeGenericType(property.PropertyType);
            m_Comparer = (IComparer)comparerForPropertyType.InvokeMember("Default", BindingFlags.Static | BindingFlags.GetProperty | BindingFlags.Public, null, null, null);
            SetListSortDirection(direction);
        }

        #region IComparer<T> Members

        public int Compare(T x, T y)
        {
            return m_Reverse * m_Comparer.Compare(m_PropertyDescriptor.GetValue(x), m_PropertyDescriptor.GetValue(y));
        }

        #endregion

        private void SetPropertyDescriptor(PropertyDescriptor descriptor)
        {
            m_PropertyDescriptor = descriptor;
        }

        private void SetListSortDirection(ListSortDirection direction)
        {
            m_Reverse = direction == ListSortDirection.Ascending ? 1 : -1;
        }

        public void SetPropertyAndDirection(PropertyDescriptor descriptor, ListSortDirection direction)
        {
            SetPropertyDescriptor(descriptor);
            SetListSortDirection(direction);
        }
    }
}
