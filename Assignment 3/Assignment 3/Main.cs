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

            a.AddFile("/You");
            a.AddFile("/Hello/Are");
            a.AddFile("/Hello/There/General/A");
            a.AddFile("/Hello/There/Kenobi/Bold");

            a.PrintFileSystem();

            // Testing adding directory
            bool test = a.AddDirectory("/Hello/There/Meme");
            Console.WriteLine("Testing adding directory : You : " + test);
            a.PrintFileSystem();

            // Testing adding file
            test = a.AddFile("/Hello/General/Prequel/One");
            Console.WriteLine("Testing adding file : You : " + test);
            a.PrintFileSystem();

            // Testing remove file that is valid 
            test = a.RemoveFile("/You");
            Console.WriteLine("Testing remove file : You : " + test);
            a.PrintFileSystem();

            // Testing remove directory that is valid 
             test = a.RemoveDirectory("/Hello/There/Meme");
            Console.WriteLine("Testing remove Directory : Meme : " + test);
            a.PrintFileSystem();

            // Testing remove file that is not valid 
            test = a.RemoveFile("/it");
            Console.WriteLine("Testing remove invalid file : it : " + test);
            a.PrintFileSystem();

            // Testing to remove directory that is not valid
            test = a.RemoveDirectory("/Hello/Mike");
            Console.WriteLine("Testing remove invalid Directory : Mike : " + test);
            a.PrintFileSystem();

            // Testing to add file that is not valid
            test = a.AddFile("/Bye/There");
            Console.WriteLine("Testing add invalid file : There : " + test);
            a.PrintFileSystem();

            Console.ReadKey();
        }
    }
}