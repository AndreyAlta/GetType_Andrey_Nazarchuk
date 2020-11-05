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
                object input = Console.ReadLine();
                string type = "";
                GetType (ref type, input);
                Console.WriteLine($"{input} is {type}\n");
            }
        }
        static object GetType(ref string type, object input)
        {
            long number = 0;
            bool integer;
            try
            {
                number = Convert.ToInt64(input);
                integer = true;
            }
            catch
            {
                try
                {
                    Convert.ToUInt64(input);
                    return type = "uint64";
                }
                catch
                {
                    try
                    {
                        Convert.ToDouble(input);
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
                string str= Convert.ToString(input);
                switch (true)
                {
                    case true when str.Length > 1:
                        return type = "string";

                    case true when str.Length == 1:
                        return type = "char";
                }
            }
            return type;
        }
    }
}
