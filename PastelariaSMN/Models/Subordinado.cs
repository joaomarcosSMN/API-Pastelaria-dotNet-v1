namespace PastelariaSMN.Models
{
    public class Subordinado : Usuario
    {
        // public new bool EGestor { get; set; } = false;
        // public Gestor Gestor { get; set; }
        public int IdGestor { get; set; }

        public Subordinado() {
            this.EGestor = false;
            this.Gestor = new Gestor();
        }
    }
}