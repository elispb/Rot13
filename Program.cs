using System;
using System.IO;
using System.Text;

namespace Rot13
{
    class Program
    {
        static void Main(string[] args)
        {
            string textToRot = "";
            Console.WriteLine("Reading File");
            try
            {
                using (StreamReader sr = new StreamReader("Input.txt"))
                {
                    textToRot = sr.ReadToEnd();
                    Console.WriteLine("Text to Rot13: " + textToRot);
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("File could not be read: " + e.Message);
            }
            if (!string.IsNullOrEmpty(textToRot))
            {
                StringBuilder sb = new StringBuilder();
                foreach (char c in textToRot)
                {
                    int j = 0;
                    if (c > 96 && c < 123)
                    {
                        j = c + 13;
                        if (j > 122)
                            j = j - 26;
                        sb.Append((char)j);
                    }
                    else if (c > 64 && c < 91)
                    {
                        j = c + 13;
                        if (j > 90)
                            j = j - 26;
                        sb.Append((char)j);
                    }
                    else
                    {
                        sb.Append(c);
                    }
                }
                Console.WriteLine(sb.ToString());
                StreamWriter sw = new StreamWriter("Output.txt");
                sw.WriteLine(sb.ToString());
                sw.Flush();
                sw.Close();
            }
            else
            {
                Console.WriteLine("No text found");
            }
            Console.ReadLine();
        }
    }
}
