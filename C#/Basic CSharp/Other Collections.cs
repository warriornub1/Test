using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 

namespace Basic_CSharp
{
    public class Other_Collections
    {
        Stack<string> nameStack = new Stack<string>();
        Queue<string> stringQueue = new Queue<string>();
        SortedList<int, string> sortedList = new SortedList<int, string>();

        public Other_Collections()
        {
            nameStack.Push("Code Monkey");
            nameStack.Push("Iron Man");
            nameStack.Push("Spider-Man");

            stringQueue.Enqueue("Code Monkey");
            stringQueue.Enqueue("Iron Man");
            stringQueue.Enqueue("Spider-Man");

            var result = nameStack.Pop();
            var result1 = stringQueue.Dequeue();



            sortedList.Add(3, "Three");
            sortedList.Add(1, "One");
            sortedList.Add(2, "Two");

            sortedList.Remove(1);
            bool containsKey = sortedList.ContainsKey(2); // true
            bool containsValue = sortedList.ContainsValue("Two"); // true


            // Keys are automatically sorted
            foreach (var item in sortedList)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }

        }
    }
}
