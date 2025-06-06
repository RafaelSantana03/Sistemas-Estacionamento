namespace SistemaEstacionamento
{
    public class Program
    {
        static void Main(string[] args)
        {
            Estacionamento estacionamento = new Estacionamento
            {
               CapacidadeMaxima = 5,
               VeiculosEstacionados = new List<Veiculo>()
               
            };

            estacionamento.AdicionarVeiculo(new Veiculo("MECE123", "Mercedes-Benz", "Preto"));
            estacionamento.AdicionarVeiculo(new Veiculo("BMWI123", "BMW", "Branco"));
            estacionamento.AdicionarVeiculo(new Veiculo("AUDI123", "Audi", "Preo"));
            estacionamento.AdicionarVeiculo(new Veiculo("BYDD123", "BYD", "Azul"));
            estacionamento.AdicionarVeiculo(new Veiculo("VOLV123", "Volvo", "Branco"));

            estacionamento.RemoverVeiculo(estacionamento.VeiculosEstacionados[2].Placa);

            estacionamento.ListarVeiculos();

        }
    }

    public class Veiculo
    {
        public string Placa { get; set; }
        public string Modelo { get; set; }
        public string Cor { get; set; }

        public Veiculo(string placa, string modelo, string cor)
        {
            Placa = placa;
            Modelo = modelo;
            Cor = cor;
        }
    }

    public class Estacionamento
    {
        public Estacionamento()
        {
            List<Veiculo> veiculos = new();
        }
        public int CapacidadeMaxima { get; set; }
        public List<Veiculo> VeiculosEstacionados { get; set; }

        public void AdicionarVeiculo(Veiculo veiculo)
        {
            if (VeiculosEstacionados.Any(v => v.Placa == veiculo.Placa))
            {
                throw new InvalidOperationException("Já existe um veículo com esta placa.");
            }
            if (VeiculosEstacionados.Count < CapacidadeMaxima)
            {
                VeiculosEstacionados.Add(veiculo); // Se a capacidade máxima não foi atingida, adiciona o veículo
            }
            else
            {
                throw new InvalidOperationException("Estacionamento cheio."); // Se a capacidade máxima foi atingida, lança uma exceção
            }
        }
        public void RemoverVeiculo(string placa)
        {
            var veiculo = VeiculosEstacionados.FirstOrDefault(v => v.Placa == placa);
            if (veiculo != null)
            {
                VeiculosEstacionados.Remove(veiculo); // Se o veículo foi encontrado, será removido
            }
            else
            {
                throw new InvalidOperationException("Veículo não encontrado."); // Se o veículo não foi encontrado, lança uma exceção
            }
        }

        public void ListarVeiculos()
        {
            if(VeiculosEstacionados.Count == 0)
            {
                Console.WriteLine("Nenhum veículo encontrado");
            }
            else
            {
                Console.WriteLine($"Veículos Estacionados: {VeiculosEstacionados.Count}");
                foreach (var item in VeiculosEstacionados)
                {
                    Console.WriteLine($"Placa: {item.Placa}, Modelo:{item.Modelo}, Cor:{item.Cor}");
                }
            }
        }
    }
}
