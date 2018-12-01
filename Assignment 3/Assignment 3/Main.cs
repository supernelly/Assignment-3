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
            a.AddDirectory("/Hello/android");
            a.AddDirectory("/Hello/there");
            a.AddDirectory("/ok");
            a.AddDirectory("/ok/then");
            a.AddFile("/abc");
            a.AddFile("/Hello/lolwhat");
            a.AddFile("/Hello/okso");

            bool check = a.AddFile("/Hello/okso");
            if (check)
                Console.WriteLine("okso added");
            else
                Console.WriteLine("okso failed");

            check = a.AddFile("/Hello/pippin/frodo");
            if (check)
                Console.WriteLine("frodo added");
            else
                Console.WriteLine("frodo failed");


            //a.AddFile("/Hello/android/samwise");
            //a.AddFile("/ok/gandalf");
            //a.AddFile("/ok/then/saruman");
            //a.PrintFileSystem();
          
            Console.ReadKey();
        }
    }
}