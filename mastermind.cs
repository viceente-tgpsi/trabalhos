using System;
using System.Linq;
class Program
{
    static void Main()
    {
        Console.WriteLine("Masterminds");
        Random rand = new Random();
        int[] segredo = new int[4];
        for (int i = 0; i < 4; i++)
            segredo[i] = rand.Next(1, 9);
        int tentativas = 0;
        while (true)
        {
            tentativas++;
            Console.WriteLine($"\nTentativa {tentativas}");
            int[] palpite = new int[4];
            for (int i = 0; i < 4; i++)
            {
                while (true)
                {
                    Console.Write($"Digite o {i + 1}º dígito (1 a 9): ");
                    string entrada = Console.ReadLine();

                    if (entrada.Length == 1 && char.IsDigit(entrada[0]) && entrada != "0")
                    {
                        palpite[i] = Convert.ToInt16(entrada);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Entrada inválida! Insira apenas um número entre 1 e 9.");
                    }
                }
            }
            int pcerta= palpite.Where((n, i) => n == segredo[i]).Count();
            int perrada = 0;
            foreach (int num in palpite.Distinct())
            {
                int comum = Math.Min(palpite.Count(n => n == num), segredo.Count(n => n == num));
                perrada += comum;
            }
            perrada -= pcerta;
            Console.WriteLine("\nAcertos na posição correta: " + pcerta);
            Console.WriteLine("Números corretos na posição errada: " + perrada);
            if (pcerta == 4)
            {
                Console.WriteLine("\nPARABÉNS! Tu acertaste a sequência completa");
                Console.WriteLine("Total de tentativas: " + tentativas);
                break;
            }
        }
    }
}
