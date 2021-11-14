using System;
using System.IO;
using CopyDirectory.Models;

namespace CopyDirectory
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Please enter the link of the source folder: ");
            string inputSource = Console.ReadLine();
            var MovePath = new DirectoryInfo(inputSource);
            Console.Write("Please enter the link to the location you want to copy: ");
            string inputTarget = Console.ReadLine();
            var CurrentDirectory = new DirectoryInfo(inputTarget);
            CopyToDirectory.CopyAll(MovePath, CurrentDirectory);
        }
    }
}
