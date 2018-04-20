using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace POEStashChecker.Utility
{
    public class SortableBindingList<T> : BindingList<T>
    {
        private readonly Dictionary<Type, PropertyComparer<T>> m_Comparers;
        private bool m_IsSorted;
        private ListSortDirection m_ListSortDirection;
        private PropertyDescriptor m_PropertyDescriptor;

        public SortableBindingList() : base(new List<T>())
        {
            m_Comparers = new Dictionary<Type, PropertyComparer<T>>();
        }

        public SortableBindingList(IEnumerable<T> enumeration) : base(new List<T>(enumeration))
        {
            m_Comparers = new Dictionary<Type, PropertyComparer<T>>();
        }

        protected override bool SupportsSortingCore => true;

        protected override bool IsSortedCore => m_IsSorted;

        protected override PropertyDescriptor SortPropertyCore => m_PropertyDescriptor;

        protected override ListSortDirection SortDirectionCore => m_ListSortDirection;

        protected override bool SupportsSearchingCore => true;

        protected override void ApplySortCore(PropertyDescriptor property, ListSortDirection direction)
        {
            List<T> itemsList = (List<T>)Items;

            Type propertyType = property.PropertyType;
            PropertyComparer<T> comparer;
            if (!m_Comparers.TryGetValue(propertyType, out comparer))
            {
                comparer = new PropertyComparer<T>(property, direction);
                m_Comparers.Add(propertyType, comparer);
            }

            comparer.SetPropertyAndDirection(property, direction);
            itemsList.Sort(comparer);

            m_PropertyDescriptor = property;
            m_ListSortDirection = direction;
            m_IsSorted = true;

            OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
        }

        protected override void RemoveSortCore()
        {
            m_IsSorted = false;
            m_PropertyDescriptor = base.SortPropertyCore;
            m_ListSortDirection = base.SortDirectionCore;

            OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
        }

        protected override int FindCore(PropertyDescriptor property, object key)
        {
            int count = Count;
            for (int i = 0; i < count; ++i)
            {
                T element = this[i];
                object value = property.GetValue(element);
                if (value != null && value.Equals(key))
                {
                    return i;
                }
            }

            return -1;
        }

        public void RemoveRange(int index, int count)
        {
            if (count >= Count)
            {
                Clear();
                return;
            }

            int amount = Math.Min(Count, count);
            for (int i = 0; i < amount; ++i)
            {
                RemoveAt(index);
            }
        }
    }
}
