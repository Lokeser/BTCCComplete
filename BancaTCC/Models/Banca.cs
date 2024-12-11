namespace BancaTCC.Models
{
    public class Banca
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFim { get; set; }
        public string Resultado { get; set; }
        public string Observacoes { get; set; }

        public int TrabalhoId { get; set; }
        public Trabalho Trabalho { get; set; }
        public ICollection<MembroExterior> MembrosExternos { get; set; }
    }

}
