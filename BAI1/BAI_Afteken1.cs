using System;
using System.Collections.Generic;


namespace BAI
{
    public class BAI_Afteken1
    {
        private const string BASE27CIJFERS = "-ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        // ***************
        // * OPGAVE 1a/b *
        // ***************
        public static UInt64 Opg1aDecodeBase27(string base27getal)
        {
            UInt64 resultaat = 0;
            // zet de hele string in een keer in een stack
            Stack<char> stapel = new Stack<char>(base27getal);
            // Macht van 27 die we bijhouden (start bij 1 = 27^0)
            UInt64 macht = 1;
            
            // zolang er nog tekens in de stack zitten
            while (stapel.Count > 0)
            {
                char c = stapel.Pop(); // haalt v bovenste van de stack
                int waarde = BASE27CIJFERS.IndexOf(c);

                if (waarde < 0)
                    throw new ArgumentException("Ongeldig teken in base-27 getal");
                resultaat += (UInt64)waarde * macht;
                macht *= 27; //  is keer 27
            }

            return resultaat;
        }

        public static string Opg1bEncodeBase27(UInt64 base10getal)
        {
            if (base10getal == 0UL)
                return "-"; // 

            Stack<char> stapel = new Stack<char>();

            // Zolang er nog waarde over is
            while (base10getal > 0)
            {
                UInt64 rest = base10getal % 27;      // neem de rest
                stapel.Push(BASE27CIJFERS[(int)rest]); // push corresponderend teken
                base10getal /= 27;                   // deel door 27
            }

            // maakt string door alles van de stack af te poppen
            return string.Concat(stapel);
        }



        // ***************
        // * OPGAVE 2a/b *
        // ***************
        public static Stack<UInt64> Opdr2aWoordStack(List<string> woorden)
        {
            Stack<UInt64> stapel = new Stack<UInt64>();
    
            // begin bij het laatste woord in de lijst
            int index = woorden.Count - 1;
            while (index >= 0)
            {
                // pakt het woord en zet om naar getal
                UInt64 getal = Opg1aDecodeBase27(woorden[index]);
                stapel.Push(getal);
                index--;
            }
    
            return stapel;
        }
        public static Queue<string> Opdr2bKorteWoordenQueue(Stack<UInt64> woordstack)
        {
            Queue<string> rij = new Queue<string>();
            // zolang er nog getallen in de stack zitten
            while (woordstack.Count > 0)
            {
                // pakt het bovenste getal van de stack
                UInt64 getal = woordstack.Pop();
        
                // checkt of het getal 3 cijfers of minder heeft in base-27
                // 27^3 = 19683, dus alles onder 19683 heeft max 3 cijfers
                if (getal < 19683)
                {
                    // zet t om naar base-27 woord en doet t in de rij
                    string woord = Opg1bEncodeBase27(getal);
                    rij.Enqueue(woord);
                }
            }
            return rij;
        }

        static void Main(string[] args)
        {
            Console.WriteLine();
            Console.WriteLine("=== Opdracht 1a : Decode base-27 ===");
            Console.WriteLine($"BAI    => {Opg1aDecodeBase27("BAI")}");         // 1494
            Console.WriteLine($"HBO-ICT => {Opg1aDecodeBase27("HBO-ICT")}");    // 3136040003
            Console.WriteLine($"BINGO  => {Opg1aDecodeBase27("BINGO")}");       // 1250439
            Console.WriteLine();

            Console.WriteLine();
            Console.WriteLine("=== Opdracht 1b : Encode base-27 ===");
            Console.WriteLine($"1494       => {Opg1bEncodeBase27(1494)}");          // "BAI"
            Console.WriteLine($"3136040003 => {Opg1bEncodeBase27(3136040003)}");    // "HBO-ICT"
            Console.WriteLine($"1250439   => {Opg1bEncodeBase27(1250439)}");        // BINGO
            Console.WriteLine();

            Console.WriteLine("=== Opdracht 2 : Stack / Queue - korte woorden ===");
            string[] woordarray = {"CONCEPT", "OK", "BLAUW", "TOEN", "IS",
                "HBOICT", "GEEL", "DIT", "GOED", "NIEUW"};
            List<string> woorden = new List<string>(woordarray);
            Stack<UInt64> stack = Opdr2aWoordStack(woorden);
            Queue<string> queue = Opdr2bKorteWoordenQueue(stack);

            foreach (string kortwoord in queue)
            {
                Console.Write(kortwoord + " ");                             // Zou "DIT IS OK" moeten opleveren
            }
            Console.WriteLine();
        }
    }
}
