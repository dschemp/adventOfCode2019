using System;
using System.Linq;

namespace AdventOfCode
{
    class Program
    {
        static string input = "1,12,2,3,1,1,2,3,1,3,4,3,1,5,0,3,2,1,13,19,1,9,19,23,2,13,23,27,2,27,13,31,2,31,10,35,1,6,35,39,1,5,39,43,1,10,43,47,1,5,47,51,1,13,51,55,2,55,9,59,1,6,59,63,1,13,63,67,1,6,67,71,1,71,10,75,2,13,75,79,1,5,79,83,2,83,6,87,1,6,87,91,1,91,13,95,1,95,13,99,2,99,13,103,1,103,5,107,2,107,10,111,1,5,111,115,1,2,115,119,1,119,6,0,99,2,0,14,0";
        //static string input = "1,9,10,3,2,3,11,0,99,30,40,50";

        static void Main(string[] args)
        {
            int[] mem = input.Split(',').Select(int.Parse).ToArray();
            run(ref mem);
            Console.WriteLine(mem[0]);
        }

        static void run(ref int[] mem)
        {
            int opcode, ptr = 0;
            
            while ((opcode = mem[ptr]) != 99)
            {
                int ptr_n1 = mem[ptr + 1], ptr_n2 = mem[ptr + 2], ptr_m = mem[ptr + 3];
                Console.WriteLine($"Opcode: {opcode} - n1: {ptr_n1} | n2: {ptr_n2} | m: {ptr_m}");
                
                if (opcode == 1)
                {
                    operate(ref mem, ptr_n1, ptr_n2, ptr_m, (x, y) => x + y);
                }
                else if (opcode == 2)
                {
                    operate(ref mem, ptr_n1, ptr_n2, ptr_m, (x, y) => x * y);
                }

                ptr += 4;
            }
        }

        static void operate(ref int[] mem, int n1, int n2, int m, Func<int, int, int> func)
        {
            mem[m] = func(mem[n1], mem[n2]);
        }
    }
}
