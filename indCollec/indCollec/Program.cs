using System;
using System.Collections.Generic;

namespace indCollec
{
    class Program
    {
        static void Main(string[] args)
        {
            InfixToPrefix cl = new InfixToPrefix();
            Console.WriteLine("Введите выражение(каждый символ через пробел)");
            string infix = Console.ReadLine();
            string[] mas = infix.Split(' ');
            Stack<string> s = new Stack<string>();
            List<string> list = new List<string>();
            int n;
            foreach (string c in mas)
            {
                if (int.TryParse(c.ToString(), out n))
                {
                    list.Add(c);
                }
                if (c == "(")
                {
                    s.Push(c);
                }
                if (c == ")")
                {
                    while (s.Count != 0 && s.Peek() != "(")
                    {
                        list.Add(s.Pop());
                    }
                    s.Pop();
                }
                if (cl.Operator(c) == true)
                {
                    while (s.Count != 0 && cl.Priority(s.Peek()) >= cl.Priority(c))
                    {
                        list.Add(s.Pop());
                    }
                    s.Push(c);
                }
            }
            while (s.Count != 0)
            {
                list.Add(s.Pop());
            }
            for (int i = 0; i < list.Count; i++)
            {
                Console.Write("{0}", list[i]);
            }

            Console.ReadLine();
        }

        
        
    }

}
