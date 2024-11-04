using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Garrafa___01_11_2024
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Garrafa garrafa = new Garrafa(1000, "Agua");

            bool continuar = true;

            while (continuar)
            {
                Console.WriteLine("\nMenu:");
                Console.WriteLine("1. Abrir garrafa");
                Console.WriteLine("2. Fechar garrafa");
                Console.WriteLine("3. Beber da garrafa");
                Console.WriteLine("4. Encher a garrafa");
                Console.WriteLine("5. Lavar a garrafa");
                Console.WriteLine("6. Reciclar a garrafa");
                Console.WriteLine("7. Mostrar informações da garrafa");
                Console.WriteLine("8. Sair");
                Console.Write("Escolha uma opção: ");
                int opcao = int.Parse(Console.ReadLine());

                try
                {
                    switch (opcao)
                    {
                        case 1:
                            garrafa.Abrir();
                            break;
                        case 2:
                            garrafa.Fechar();
                            break;
                        case 3:
                            Console.Write("Quantos mililitros deseja beber? ");
                            float quantidadeBeber = float.Parse(Console.ReadLine());
                            garrafa.Beber(quantidadeBeber);
                            break;
                        case 4:
                            Console.Write("Quantos mililitros deseja encher? ");
                            float quantidadeEncher = float.Parse(Console.ReadLine());
                            garrafa.Encher(quantidadeEncher);
                            break;
                        case 5:
                            garrafa.Lavar();
                            break;
                        case 6:
                            Console.Write("Qual o novo volume máximo da garrafa? ");
                            float novoVolumeMaximo = float.Parse(Console.ReadLine());
                            garrafa.Reciclar(novoVolumeMaximo, garrafa.VolumeMax);
                            break;
                        case 7:
                            Console.WriteLine($"Volume máximo: {garrafa.VolumeMax}ml, Líquido contido: {garrafa.LiquidoContido}ml, Quantidade atual: {garrafa.QuantidadeAtual}ml, Estado: {garrafa.Estado}, Quantidade de usos: {garrafa.QuantidadeUsos}");
                            break;
                        case 8:
                            continuar = false;
                            break;
                        default:
                            Console.WriteLine("Opção inválida. Tente novamente.");
                            break;
                    }
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine($"Erro: {ex.Message}");
                }

            }
        }
    }
}
