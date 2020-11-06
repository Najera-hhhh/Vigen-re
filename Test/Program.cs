using System;
using Encryp;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Console.WriteLine("Digite el text:");
            string clave = Console.ReadLine();

            Console.WriteLine("Digite el text:");
            string text = Console.ReadLine();*/

            Davici decrypt = new Davici();

            Console.WriteLine(decrypt.TextEncrypt("PIKACHU","Sometimes later becomes never. Do it now."));
        }
    }
}
