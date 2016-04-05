
namespace _03_GenericList
{
    using System;
    using System.Linq;

    [Version(0, 1)]
    public class GenericList<T> where T : IComparable<T>
    {
        private const int DefaultSize = 16;
        private T[] elements;
        private int currentIndex;

        public GenericList(int capacity = DefaultSize)
        {
            this.elements = new T[capacity];
            this.currentIndex = 0;
        }

        public void Add(T element)
        {
            if (currentIndex >= elements.Length)
            {
                this.AutoGrowList();
            }

            this.elements[currentIndex] = element;

            currentIndex++;
        }

        public T this[int index]
        {
            get
            {
                CheckIndex(index);
                return this.elements[index];
            }
            set
            {
                CheckIndex(index);
                this.elements[index] = value;
            }
        }

        public void RemoveAt(int index)
        {
            CheckIndex(index);

            T[] temp = new T[this.elements.Length];

            for (var i = 0; i < index; i++)
            {
                temp[i] = this.elements[i];
            }

            for (var i = index + 1; i < this.elements.Length; i++)
            {
                temp[i - 1] = this.elements[i];
            }

            this.elements = temp;
            currentIndex--;
        }

        public void InsertAt(int index, T element)
        {
            CheckIndex(index);

            T[] temp = new T[this.elements.Length + 1];

            for (int i = 0; i < index; i++)
            {
                temp[i] = this.elements[i];
            }

            temp[index] = element;

            for (int i = index; i < this.elements.Length; i++)
            {
                temp[i + 1] = this.elements[i];
            }

            this.elements = temp;
            this.currentIndex++;
        }

        public void Clear()
        {
            this.elements = new T[DefaultSize];
            this.currentIndex = 0;
        }

        public int FindIndexOf(T element)
        {
            for (int i = 0; i < this.elements.Length; i++)
            {
                if (element.Equals(this.elements[i]))
                {
                    return i;
                }
            }

            return -1;
        }

        public bool Contains(T elementToCheck)
        {
            return this.FindIndexOf(elementToCheck) != -1;
        }

        public T Min()
        {
            T min = this.elements[0];

            for (var i = 1; i < currentIndex; i++)
            {
                T currElement = this.elements[i];
                if (currElement.CompareTo(min) < 0)
                {
                    min = currElement;
                }
            }

            return min;
        }

        public T Max()
        {
            T max = this.elements[0];

            for (var i = 1; i < currentIndex; i++)
            {
                T currElement = this.elements[i];
                if (currElement.CompareTo(max) > 0)
                {
                    max = currElement;
                }
            }

            return max;
        }

        private void AutoGrowList()
        {
            T[] doubleSizedList = new T[elements.Length * 2];
            for (var i = 0; i < elements.Length; i++)
            {
                doubleSizedList[i] = this.elements[i];
            }

            this.elements = doubleSizedList;
        }

        private void CheckIndex(int index)
        {
            if (index < 0 || index >= currentIndex)
            {
                throw new IndexOutOfRangeException(string.Format("Invalid index: " + index));
            }
        }

        public override string ToString()
        {
            return string.Join(", ", this.elements.Take(currentIndex));
        }
    }
}
