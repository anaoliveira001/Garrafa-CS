using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Garrafa___01_11_2024
{
    internal class Garrafa
    {
        public static readonly int FECHADA = 1;
        public static readonly int ABERTA = 2;
        public static readonly int DESGASTA = 3;

        private float volumeMax;
        private string liquidoContido;
        private float quantidadeAtual;
        private int estado;
        private int quantidadeUsos;

        public Garrafa(float volumeMax, string liquidoContido)
        {
            this.VolumeMax = volumeMax;
            this.LiquidoContido = liquidoContido;
            this.QuantidadeAtual = 0; // enquanto inciado a Zero não conseguia encher
            this.Estado = Garrafa.FECHADA;
            this.QuantidadeUsos = 0;
        }
        public float VolumeMax
        {
            get { return this.volumeMax;
            }
            set {
                this.volumeMax = value;
            }
        }

        public string LiquidoContido
        {
            get
            {
                return this.liquidoContido;
            }
            set
            {
                this.liquidoContido = value;
            }
        }

        public float QuantidadeAtual
        {
            get
            {
                return this.quantidadeAtual;
            }
            set
            {
                this.quantidadeAtual = value;
            }
        }

        public int Estado
        {
            get
            {
                return this.estado;
            }
            set
            {
                this.estado = value;
            }
        }

        public int QuantidadeUsos {

            get
            {
                return this.quantidadeUsos;
            }
            set
            {
                this.quantidadeUsos = value;
            }
        }


       public void Abrir()
        {
            this.estado = Garrafa.ABERTA; //char
            Console.WriteLine("Abrindo");
        }

        public void Fechar()
        {
            this.estado = Garrafa.FECHADA; //fechado char
            Console.WriteLine("Fechando");
        }

        public float Beber(float quantidade)
        {
            if (this.Estado == Garrafa.FECHADA)
                throw new InvalidOperationException("A garrafa está fechada.");

            if (this.quantidadeAtual < quantidade)
                throw new InvalidOperationException("Não há líquido suficiente.");

            this.quantidadeAtual -= quantidade;
            this.quantidadeUsos++;
            Desgastar();
            Console.WriteLine($"Você bebeu {quantidade}ml de água.\nFalta: {this.quantidadeAtual}ml ");
            return this.quantidadeAtual;
        }

        public void Encher(float quantidade)
        {
            if (this.Estado == DESGASTA)
            {
                Console.WriteLine("Garrafa danificada. Faça a reciclcagem primeiro!");
                return;
            }

            if (this.Estado == Garrafa.FECHADA)
                throw new InvalidOperationException("A garrafa está fechada.");

            if (this.quantidadeAtual + quantidade > this.VolumeMax)
            {
                float qtVertido = this.VolumeMax - this.quantidadeAtual;
                this.QuantidadeAtual = this.volumeMax;
                Console.WriteLine($"A garrafa foi cheia com {qtVertido} ml.");
            }
            else
            {
                this.quantidadeAtual += quantidade;
                Console.WriteLine($"Foi colocado {quantidade}ml. A garrafa possui {this.quantidadeAtual}");

            }
            this.quantidadeUsos++;
            Desgastar();
        }

        public void Lavar() // ? 
        {
            this.quantidadeAtual = 0;
            //this.liquidoContido = "";
            Console.WriteLine("A garrafa foi lavada");
        }

        public void Desgastar()
        {
            if (this.quantidadeUsos >= 10)
            {
                this.quantidadeAtual = 0;
                this.Estado = Garrafa.DESGASTA;
                Console.WriteLine("A garrafa está desgastada. Recicle-a.");
            }
        }

        public void Reciclar(float novoVolumeMaximo, float volumeMaximo)
        {
            volumeMaximo = novoVolumeMaximo;
            this.quantidadeAtual = 0;
            this.quantidadeUsos = 0;
            this.Estado = Garrafa.FECHADA;
            Console.WriteLine("A garrafa foi reciclada.");
        }
    }
}

