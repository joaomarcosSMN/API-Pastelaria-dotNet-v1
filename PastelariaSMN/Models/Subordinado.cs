namespace PastelariaSMN.Models
{
    public class Subordinado : Usuario
    {
        public short IdGestor { get; set; }

        public Subordinado() {
            this.EGestor = false;
            this.Gestor = new Gestor();
        }
    }
}