using System;

namespace ReservaCadeira
{
    class Program
    {
        static void Main(string[] args)
        {
            var reservaCadeira = new Cinema(5);
            reservaCadeira.SalaLotadaEvent += OnSalaLotada;
            reservaCadeira.ReservarCadeira();
            reservaCadeira.ReservarCadeira();
            reservaCadeira.ReservarCadeira();
            reservaCadeira.ReservarCadeira();
        }

        static void OnSalaLotada(object? sender, EventArgs e)
        {
            Console.WriteLine("Sala lotada!");
        }
    }

    public class Cinema
    {
        public Cinema(int qtdCadeiras)
        {
            QtdCadeiras = qtdCadeiras;
        }

        public int QtdCadeiras { get; set; }
        private int CadeirasEmUso = 0;

        public void ReservarCadeira()
        {
            CadeirasEmUso = CadeirasEmUso + 2;
            if(CadeirasEmUso > QtdCadeiras)
            {
                OnSalaLotada(EventArgs.Empty);
            }
            else
            {
                Console.WriteLine("Cadeira reservada com sucesso!");
            }
        }

        public event EventHandler? SalaLotadaEvent;

        public void OnSalaLotada(EventArgs e)
        {
            EventHandler? handler = SalaLotadaEvent;
            handler?.Invoke(this, e);
        }
    }
}
