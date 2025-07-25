namespace Api.Domain.Dtos.Veiculo
{
    public class VeiculoDtoUpdateResult
    {
        public string Placa { get; set; }
        public string Modelo { get; set; }
        public string Marca { get; set; }
        public int Ano { get; set; }
        public string Cor { get; set; }
        public DateTime UpdateAt { get; set; }
    }
}