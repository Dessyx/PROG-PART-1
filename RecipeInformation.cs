using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeAPP
{
    //------------------------------------------------------------
    //                  Recipe Information Class
    internal class RecipeInformation<T>
    {
        private List<T> items;
        private List<T> initialCopy;

        //-------------------------------------
        //Default instructor
        public RecipeInformation()
        {
            items = new List<T>();
            initialCopy = new List<T>();
        }

        //-------------------------------------
        public void add(T item)  // adds an item
        {
            items.Add(item);
            initialCopy.Add(item);
        }

        //-------------------------------------
        public void Update(int index, T newitem)  // updates to the new item
        {
            items[index] = newitem;
        }

        //-------------------------------------
        public void Reset()
        {  // resets the item to the old value

            for (int i = 0; i < items.Count; i++)
            {
                items[i] = initialCopy[i];
            }
        }

        //-------------------------------------
        public void remove(T item)  // removes the item form the list
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

        //--------------------------------------
        public void display()
        {
            if (items.Count == 0)
            {
                Console.WriteLine("The list is empty.");
            }
            else
            {
                foreach (T item in items)
                {
                    Console.WriteLine(item);
                }
            }
        }

        //--------------------------------------
        public T returnValue(int index)  // returns the value at the index
        {
            return items[index];
        }

        //--------------------------------------
        public T returnCopyValue(int index)  // returns the original value
        {
            return initialCopy[index];
        }

        //--------------------------------------
        public int getSize()  // gets the size of the array
        {
            return items.Count;

        }

        //--------------------------------------
        public List<T> getItems()
        {
            return items;
        }

    }
} //-------------------------<<< End Of File >>>---------------------------
