using System;
using System.Collections.Generic;


namespace BAI
{
    /*         WCH: het is niet fout om hier al een Stack te gebruiken, maar het kan ook zonder
        wat efficienter is. Implementeer deze manier. TIP: gebruik string
    */
    public class BAI_Afteken1
    {
        private const string BASE27CIJFERS = "-ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        // ***************
        // * OPGAVE 1a/b *
        // ***************
        public static UInt64 Opg1aDecodeBase27(string base27getal)
        {
            UInt64 resultaat = 0;
            int i = 0;
    
            // loopt door de string van links naar rechts
            while (i < base27getal.Length)
            {
                int waarde = BASE27CIJFERS.IndexOf(base27getal[i]);
                resultaat = resultaat * 27 + (UInt64)waarde;
                i++;
            }
    
            return resultaat;
        }

        
        
        /*          WCH:  Ook hier kan het zonder stack, wat efficienter is
            implementeer deze manier. TIP: gebruik string
        */
        public static string Opg1bEncodeBase27(UInt64 base10getal)
        {
            // bijzondere geval voor 0
            if (base10getal == 0UL)
                return "-";

            string resultaat = "";
    
            // blijft delen door 27 tot er niks meer over is
            while (base10getal > 0)
            {
                
                UInt64 rest = base10getal % 27;
                // zet het cijfer vooraan in de string
                resultaat = BASE27CIJFERS[(int)rest] + resultaat;
                // deelt door 27 voor volgende ronde
                base10getal /= 27;
            }
    
            return resultaat;
        }



        // ***************
        // * OPGAVE 2a/b *
        // ***************
        
        /*        WCH: 1. ipv een index te gebruiken kun je ook door de lijst lopen met een foreach
                2. 2 van de 3 tests zijn gefaald, zorg dat alle tests slagen
        */
        public static Stack<UInt64> Opdr2aWoordStack(List<string> woorden)
        {
            Stack<UInt64> stapel = new Stack<UInt64>();
    
            // loopt door alle woorden in de lijst
            foreach (string woord in woorden)
            {
                // zet elk woord om naar een getal
                UInt64 getal = Opg1aDecodeBase27(woord);
                stapel.Push(getal);
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
