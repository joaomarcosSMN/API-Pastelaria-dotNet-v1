namespace PastelariaSMN.Infra
{
    public class EmailSettings
    {
        public string SMTPEmail { get; private set; }
        public string SMTPPassword { get; private set; }
        public int SMTPPort { get; private set; }
        public string SMTPHostname { get; private set; }
        public bool SMTPEnableSs1 {get; private set; }
        public bool EmailIsBodyHtml {get; private set; }
    }
}