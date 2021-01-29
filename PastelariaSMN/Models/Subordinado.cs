namespace PastelariaSMN.Models
{
    public class Subordinado : Usuario
    {
        public bool EGestor { get; set; } = false;
        public Gestor Gestor { get; set; }
        public int IdGestor { get; set; }

        public Subordinado() {
            this.Gestor = new Gestor();
        }
    }
}