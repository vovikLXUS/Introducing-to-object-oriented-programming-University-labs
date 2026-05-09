using System;
using System.Collections.Generic;
using System.Text;

namespace Console_Lab_5.models
{
    public class LocalityCollection
    {
        private Locality[] array;

        public LocalityCollection(int size)
        {
            array = new Locality[size];
        }

        // Індексатор
        public Locality this[int index]
        {
            get
            {
                if (index >= 0 && index < array.Length)
                    return array[index];
                throw new IndexOutOfRangeException("Індекс поза межами масиву.");
            }
            set
            {
                if (index >= 0 && index < array.Length)
                    array[index] = value;
                else
                    throw new IndexOutOfRangeException("Індекс поза межами масиву.");
            }
        }

        public int Length => array.Length;
    }
}
