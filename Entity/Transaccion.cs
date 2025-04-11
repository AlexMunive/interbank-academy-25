namespace Interbank.Entity
{
    public class Transaccion
    {
        public int Id { get; set; }             
        public string Tipo { get; set; } = "";  
        public decimal Monto { get; set; }      
    }
}
