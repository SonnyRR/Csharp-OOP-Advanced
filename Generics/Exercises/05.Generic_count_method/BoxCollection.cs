﻿namespace GenericsBox
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class BoxCollection<T> where T : IComparable<T>
    {
        private readonly List<T> internalList;

        public BoxCollection()
        {
            this.internalList = new List<T>();
        }

        public IReadOnlyList<T> Values => this.internalList;

        public void Add(T item)
        {
            this.internalList.Add(item);
        }

        public void SwapElements(int firstIndex, int secondIndex)
        {
            // TODO : Check boundaries

            T firstTempElement = this.internalList[firstIndex];
            T secondTempElement = this.internalList[secondIndex];

            this.internalList[firstIndex] = secondTempElement;
            this.internalList[secondIndex] = firstTempElement;
        }

        public int GetGreaterThan(T item)
        {
            int count = 0;

            this.internalList.ForEach(x =>
            {
                if (item.CompareTo(x) < 0)
                {
                    count++;
                }
            });
            return count;
        }
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            this.internalList.ForEach(x => builder.AppendLine($"{typeof(T)}: {x}"));
            return builder.ToString().TrimEnd();
        }
    }
}
