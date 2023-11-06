using System.Collections;
using System.Collections.Generic;

namespace G04_230702
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyStack<string> stack = new MyStack<string>();
            stack.Push("Sandro");
            stack.Push("Vaja");
            stack.Push("Gocha");
            stack.Push("Gio");
            stack.Push("Nikola");
            
            foreach (string item in stack)
            {
                Console.WriteLine(item);
            }
            stack.Clear();
        }
    }
}