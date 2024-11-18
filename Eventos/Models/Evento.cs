namespace Eventos.Models
{
    internal class Evento
    {
        public String Nome { get; set; }
        public String Local {  get; set; }
        public DateTime Dt_inicio { get; set; }
        public DateTime Dt_termino { get; set; }
        public int Participantes { get; set; }
        public double CustoIngresso { get; set; }

        public int Duracao
        {
            get => Dt_termino.Subtract(Dt_inicio).Days;
            
        }

        public double ValorTotal
        {
            get
            {
                double total = Participantes * CustoIngresso;
                return total;
            }
        }
        
    }
}
