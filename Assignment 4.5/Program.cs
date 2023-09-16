using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_4._5
{
    using System;

    class CustomList<T>
    {
        private T[] items;
        private int capacity;
        private int count;

        public CustomList(int capacity)
        {
            this.capacity = capacity;
            this.items = new T[capacity];
            this.count = 0;
        }

        public int Count
        {
            get { return count; }
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= count)
                {
                    throw new IndexOutOfRangeException("Index is out of range.");
                }
                return items[index];
            }
            set
            {
                if (index < 0 || index >= count)
                {
                    throw new IndexOutOfRangeException("Index is out of range.");
                }
                items[index] = value;
            }
        }

        public void Add(T item)
        {
            if (count >= capacity)
            {
                
                capacity *= 2;
                Array.Resize(ref items, capacity);
            }

            items[count] = item;
            count++;
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= count)
            {
                throw new IndexOutOfRangeException("Index is out of range.");
            }

            for (int i = index; i < count - 1; i++)
            {
                items[i] = items[i + 1];
            }

            count--;
        }
    }

    class Program
    {
        static void Main()
        {
            CustomList<int> myList = new CustomList<int>(5);

            myList.Add(1);
            myList.Add(2);
            myList.Add(3);
            myList.Add(4);
            myList.Add(5);

            Console.WriteLine("Elements in the list:");

            for (int i = 0; i < myList.Count; i++)
            {
                Console.WriteLine($"myList[{i}] = {myList[i]}");
            }

            
            myList[2] = 10;

            Console.WriteLine("\nModified element:");
            Console.WriteLine($"myList[2] = {myList[2]}");

            

            myList.RemoveAt(3);

            Console.WriteLine("\nAfter removing element at index 3:");
            for (int i = 0; i < myList.Count; i++)
            {
                Console.WriteLine($"myList[{i}] = {myList[i]}");
            }
        }
    }

}
