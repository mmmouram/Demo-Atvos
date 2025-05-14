namespace BackEnd.Models
{
    public class OrderClient
    {
        // These fields are read-only for editing on the client side but are returned for display
        public string CNPJ { get; set; }
        public string CorporateName { get; set; }
    }
}
