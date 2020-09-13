using System;
using System.ComponentModel;

namespace Fraction
{
    class Program
    {
        static void Main(string[] args)
        {
            bool endApp = false;

            Console.WriteLine("Fraction operations\r");

            while (!endApp)
            {
                Console.WriteLine("Input first fraction:");
                
                string n1 = Console.ReadLine();
                int cleanN1;

                while (!int.TryParse(n1, out cleanN1))
                {
                    Console.Write("This is not valid input. Please input an integer value: ");
                    n1 = Console.ReadLine();
                }

                string d1 = Console.ReadLine();
                int cleanD1;

                while (!int.TryParse(d1, out cleanD1) || cleanD1 == 0)
                {
                    Console.Write("This is not valid input. Please input an integer not zero value: ");
                    d1 = Console.ReadLine();
                }

                Console.WriteLine("Input second fraction:");

                string n2 = Console.ReadLine();
                int cleanN2;

                while (!int.TryParse(n2, out cleanN2))
                {
                    Console.Write("This is not valid input. Please input an integer value: ");
                    n2 = Console.ReadLine();
                }

                string d2 = Console.ReadLine();
                int cleanD2;

                while (!int.TryParse(d2, out cleanD2) || cleanD2 == 0)
                {
                    Console.Write("This is not valid input. Please input an integer not zero value: ");
                    d2 = Console.ReadLine();
                }

                Fraction a = new Fraction(cleanN1, cleanD1);
                Fraction b = new Fraction(cleanN2, cleanD2);

                Console.WriteLine("Choose an operator from the following list:");
                Console.WriteLine("\ta - Addition");
                Console.WriteLine("\ts - Subtraction");
                Console.WriteLine("\tm - Multiplication");
                Console.WriteLine("\td - Division");
                Console.Write("Choose option ");

                string op = Console.ReadLine();
                string result = "";

                Fraction c;

                switch (op)
                {
                    case "a":
                        c = Fraction.Addition(a, b);
                        result = a.Output() + "+" + b.Output() + "=" + c.Output();
                        break;
                    case "s":
                        c = Fraction.Subtraction(a, b);
                        result = a.Output() + "-" + b.Output() + "=" + c.Output();
                        break;
		    case "d":
                        c = Fraction.Division(a, b);
                        result = a.Output() + "/" + b.Output() + "=" + c.Output();
                        break;
                    case "m":
                        c = Fraction.Multiplication(a, b);
                        result = a.Output() + "*" + b.Output() + "=" + c.Output();
                        break;
                    default:
                        break;
                }

                if (string.IsNullOrEmpty(result))
                {
                    Console.WriteLine("This operation will result in a mathematical error.\n");
                }
                else Console.WriteLine("Result of operations: " + result);

                Console.WriteLine("------------------------\n");

                Console.Write("Press 'n' and Enter to close the app, or press any other key and Enter to continue: ");
                if (Console.ReadLine() == "n") endApp = true;

                Console.WriteLine("\n");
            }
            return;
        }
    }
    class Fraction
    {
        public double c = 0;
        public double z = 0;

        public Fraction(int c, int z)
        {
            this.c = c;
            this.z = z;

        }

        public string Output()
        {
            return "(" + c.ToString() + "/" + z.ToString() + ")";
        }

        public static Fraction Addition(Fraction a, Fraction b)
        {
            Fraction t = new Fraction(1, 1);
            t.c = a.c * b.z + a.z * b.c;
            t.z = a.z * b.z;
            Fraction.SetFormat(t);
            return t;

        }
        public static Fraction Subtraction(Fraction a, Fraction b)
        {
            Fraction t = new Fraction(1, 1);
            t.c = a.c * b.z - a.z * b.c;
            t.z = a.z * b.z;
            Fraction.SetFormat(t);
            return t;

        }
        public static Fraction Multiplication(Fraction a, Fraction b)
        {
            Fraction t = new Fraction(1, 1);
            t.c = a.c * b.c;
            t.z = a.z * b.z;
            Fraction.SetFormat(t);
            return t;

        }
        public static Fraction Division(Fraction a, Fraction b)
        {
            Fraction t = new Fraction(1, 1);
            t.c = a.c * b.z;
            t.z = a.z * b.c;
            Fraction.SetFormat(t);
            return t;
        }
        
        public static Fraction SetFormat(Fraction a)
        {

            double max = 0;

            if (a.c > a.z)
                max = Math.Abs(a.z);
            else
                max = Math.Abs(a.c);

            for (double i = max; i >= 2; i--)
            {

                if ((a.c % i == 0) && (a.z % i == 0))
                {
                    a.c /= i;
                    a.z /= i;
                }

            }
            if ((a.z < 0))
            {
                a.c = -1 * (a.c);
                a.z = Math.Abs(a.z);
            }
            return (a);
        }
    }
}
