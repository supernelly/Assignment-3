using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_3
{
    class Node
    {
        private string directory;
        private List<string> file;
        private Node leftMostChild;
        private Node rightSibling;

        public string Directory
        {
            set
            { directory = value; }
            get
            { return directory; }
        }
        public List<string> File
        {
            set
            { file = value; }
            get
            { return file; }
        }
        public Node Left
        {
            set
            { leftMostChild = value; }
            get
            { return leftMostChild; }
        }
        public Node Right
        {
            set
            { rightSibling = value; }
            get
            { return rightSibling; }
        }
        public Node(string dir, List<string> f, Node left, Node right)
        {
            directory = dir;
            file = f;
            leftMostChild = left;
            rightSibling = right;
        }
    }
    
    public class FileSystem
    {
        private Node root;
        private int fileCount;
        // Creates a file system with a root directory
        public FileSystem()
        {
            root = new Node("/", null, null, null);
            fileCount = 0;
        }

        public List<string> parseAddress(string address)
        {
            List<string> location = new List<string>();
            string temp = "";
            bool runOnce = true;

            foreach (char c in address)
            {
                if (c == '/')
                {
                    if (runOnce == true)
                    {
                        location.Add("/");
                        runOnce = false;
                    }
                    else
                       location.Add(temp);
                    temp = "";
                }
                else
                    temp += c;
            }
            location.Add(temp);

            return location;
        }
        
        // Adds a file at the given address
        // Returns false if the file already exists or the path is undefined; true otherwise
        public bool AddFile(string address)
        {
            List<string> parsedAddress = parseAddress(address);

            if (parsedAddress[0] != root.Directory)
                return false;
            else
            {
                if (parsedAddress.Count == 2) // If address is the root
                {
                    if (root.File == null) // If there is no files
                    {
                        root.File = new List<string>();
                        fileCount++;
                    }
                    root.File.Add(parsedAddress[1]);
                    return true;
                }
                else // If address isn't the root
                {
                    Node current = root.Left;

                    for (int i = 1; i < (parsedAddress.Count - 1); i++)
                    {
                        while (current != null)
                        {
                            if (parsedAddress[i] == current.Directory)
                            {
                                if (i < (parsedAddress.Count - 3))
                                    current = current.Left;
                                break;
                            }
                            current = current.Right;
                        }
                    }

                    if (current == null)
                        return false;

                    if (current.File == null)
                        current.File = new List<string>();

                    current.File.Add(parsedAddress.Last());
                    fileCount++;
                    return true;
                }
            }
        }

        // Removes the file at the given address
        // Returns false if the file is not found or the path is undefined; true otherwise
        public bool RemoveFile(string address)
        {
            List<string> parsedAddress = parseAddress(address);

            if (parsedAddress[0] != root.Directory)
                return false;
            else
            {
                if (parsedAddress.Count == 2) // If address is the root
                {
                    if (root.File == null) // If there is no files
                        return false;
                    else
                    {
                        foreach (string file in root.File)
                        {
                            string fileName = parsedAddress.Last();

                            if (file == fileName)
                            {
                                root.File.Remove(file);
                                fileCount--;
                                return true;
                            }
                        }
                    }
                    return false; // Couldn't remove file
                }
                else // If address isn't the root
                {
                    Node current = root.Left;

                    for (int i = 1; i < (parsedAddress.Count - 1); i++)
                    {
                        while (current != null)
                        {
                            if (parsedAddress[i] == current.Directory)
                            {
                                if (i < (parsedAddress.Count - 3))
                                    current = current.Left;
                                break;
                            }
                            current = current.Right;
                        }
                    }

                    if (current == null)
                        return false;

                    if (current.File != null)
                    {
                        current.File.Remove(parsedAddress.Last());
                        fileCount--;
                        return true;
                    }
                    return false; // Couldn't remove file

                }
            }
        }
        
        // Adds a directory at the given address
        // Returns false if the directory already exists or the path is undefined; true otherwise
        public bool AddDirectory(string address)
        {
            List<string> parsedAddress = parseAddress(address);

            Node current = root.Left;

            if (parsedAddress[0] != root.Directory)
                return false;
            else
            {
                if (parsedAddress.Count == 2) // If address is the root
                {
                    if (current == null)
                    {
                        root.Left = new Node(parsedAddress.Last(), null, null, null);
                        return true;
                    }
                }
                else if (current == null)
                    return false;

                for (int i = 1; i < (parsedAddress.Count - 1); i++)
                {
                    while (current != null)
                    {
                        if (parsedAddress[i] == current.Directory)
                        {
                            if (i < (parsedAddress.Count - 3))
                                current = current.Left;
                            else
                                break;
                        }

                        if (i >= (parsedAddress.Count - 3))
                            break;

                        current = current.Right;
                    }
                }

                string newDirectory = parsedAddress.Last();

                if (current.Left == null) // If there is no subdirectories
                {
                    current.Left = new Node(newDirectory, null, null, null);
                    return true;
                }
                else
                {
                    Node currentDir = current.Left;

                    while (currentDir != null)
                    {
                        if (currentDir.Directory == newDirectory) // Checking if directory name in use
                            return false;

                        if (currentDir.Right == null)
                        {
                            currentDir.Right = new Node(newDirectory, null, null, null);
                            return true;
                        }
                        currentDir = currentDir.Right;
                    }
                }
                return false;
            }
        }

        // Removes the directory (and its subdirectories) at the given address
        // Returns false if the directory is not found or the path is undefined; true otherwise
        public bool RemoveDirectory(string address)
        {
            List<string> parsedAddress = parseAddress(address);

            Node current = root.Left;

            if (parsedAddress[0] != root.Directory)
                return false;
            else
            {
                string directoryName = parsedAddress.Last();
                Node previous = null;

                if (parsedAddress.Count == 2) // If address is the root
                {
                    if (current != null)
                    {
                        while (current != null)
                        {
                            if (directoryName == current.Directory)
                            {
                                if (previous != null)
                                    previous.Right = current.Right;
                                else
                                    root.Left = current.Right;
                                return true;
                            }
                            previous = current;
                            current = current.Right;
                        }
                        previous = null;
                        return false;
                    }
                }
                else if (current == null)
                    return false;

                for (int i = 1; i < (parsedAddress.Count - 1); i++)
                {
                    while (current != null)
                    {
                        if (parsedAddress[i] == current.Directory)
                        {
                            if (i < (parsedAddress.Count - 3))
                                current = current.Left;
                            else
                                break;
                        }

                        if (i >= (parsedAddress.Count - 3))
                            break;

                        current = current.Right;
                    }
                }

                Node currentDir = current.Left;

                while (currentDir != null) // This loop goes to the directory to be removed
                {
                    if (currentDir.Directory == directoryName)
                        break;
                    previous = currentDir;
                    currentDir = currentDir.Right;
                }

                if (previous == null)
                    current.Left = current.Right;
                else
                    previous.Right = current.Right;

                return true;
            }
        }
        
        // Returns the number of files in the file system
        public int NumberFiles()
        {
            return fileCount;
        }

        // Prints the directories in a pre-order fashion along with their files
        public void PrintFileSystem()
        {
            void Traverse(Node current, bool a)
            {
                Console.WriteLine(current.Directory);

                if (current.File != null)
                {
                    foreach (string file in current.File)
                        Console.WriteLine("  ./" + file);
                }

                if (current.Left != null)
                    Traverse(current.Left, false);
                else if (current.Right != null)
                    Traverse(current.Right, false)
                else if (a == true)
                    Console.WriteLine("reeeeeeeeeeeeeeeeee");

            }

            Traverse(root, true);

        }
    }
}