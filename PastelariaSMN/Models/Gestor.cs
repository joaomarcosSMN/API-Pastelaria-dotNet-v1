namespace PastelariaSMN.Models
{
    public class Gestor : Usuario
    {
        // public new bool EGestor { get; set; } = true;

        public Gestor()
        {
            this.EGestor = true;
            this.Gestor = null;
        }

    }
}