﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Cafe_Repo
{
    class Program
    {
        static void Main(string[] args)
        {
            UI ui = new UI();
            Console.Title = "Cafe Menu Editor";
            ui.Run();
        }
    }
}
