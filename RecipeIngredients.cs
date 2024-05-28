using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PART_1
{
    internal class RecipeIngredients <T>
    {

        private List<T> items;
        private List<T> initialCopy;

        public RecipeIngredients() {
            
            items = new List<T>();
            initialCopy = new List<T>();
        }

        public void add(T item)
        {
            items.Add(item);
            initialCopy.Add(item);
        }

        public void Update( int index, T newitem)
        {
            items[index] = newitem;
        }

        public void Reset() {
            
            for (int i = 0; i < items.Count; i++)
            {
                items[i] = initialCopy[i];
            }
        }

        public void remove(T item)
        {
            if (items.Contains(item))
            {
                items.Remove(item);
            }
            else
            {
                Console.WriteLine("The item is not found in the list.");
            }
           
        }

        public void display()
        {
            if(items.Count == 0)
            {
                Console.WriteLine("The list is empty.");
            } else
            {
                foreach (T item in items)
                {
                    Console.WriteLine(item);                 
                }
            }
        }

        public T returnValue(int index)
        {
            return items[index];
        }


        public T returnCopyValue(int index)
        {
            return initialCopy[index];
        }

        public int getSize()
        {
            return items.Count;

        }
    }
}
