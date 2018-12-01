/*
 *  Assignment 3 - File System 
 * 
 *  By: Nelson Su and Brandon Kwakye-Longdon
 * 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_3
{
    public static class Driver
    {
        public static void Main()
        {
            //for testing purposes
            FileSystem a = new FileSystem();
            a.AddDirectory("/Hello");
            a.AddDirectory("/Hello/There");
            a.AddDirectory("/Hello/General");
            a.AddDirectory("/Hello/There/Kenobi");
            a.AddDirectory("/Hello/General/Prequel");
            a.AddDirectory("/Hello/There/Meme");

            a.AddFile("/You");
            a.AddFile("/Hello/Are");
            a.AddFile("/Hello/There/General/A");
            a.AddFile("/Hello/There/Kenobi/Bold");
            a.AddFile("/Hello/General/Prequel/One");

            a.PrintFileSystem();
            Console.ReadKey();
        }
    }
}