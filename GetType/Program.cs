using System;
using System.Reflection.Metadata.Ecma335;

namespace GetType
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("Введите что угодно: ");
                string x = Console.ReadLine();
                string type = "";
                GetType (ref type, x);
                Console.WriteLine($"{x} is {type}\n");
            }
        }
        static string GetType(ref string type, string x)
        {
            long number = 0;
            bool integer;
            try
            {
                number = Convert.ToInt64(x);
                integer = true;
            }
            catch
            {
                try
                {
                    Convert.ToUInt64(x);
                    return type = "uint64";
                }
                catch
                {
                    try
                    {
                        Convert.ToDouble(x);
                        return type = "double";
                    }
                    catch
                    {
                        integer = false;
                    }
                }
            }
            if (integer == true)
            {
                switch(true)
                {
                    case true when number <= 255 && number >= 0:
                        return type = "byte";

                    case true when number <= 127 && number >= -128:
                        return type = "sbyte";

                    case true when number <= 32767 && number >= -32768:
                        return type = "int16";

                    case true when number <= 65535 && number >= 0:
                        return type = "uint16";

                    case true when number <= 2147483647 && number >= -2147483648:
                        return type = "int32";

                    case true when number <= 4294967295 && number >= 0:
                        return type = "uint32";

                    case true when number <= 9223372036854775807 && number >= -9223372036854775808:
                        return type = "int64";
                }
            }
            else
            {
                switch (true)
                {
                    case true when x.Length > 1:
                        return type = "string";

                    case true when x.Length == 1:
                        return type = "char";
                }
            }
            return type;
        }
    }
}
