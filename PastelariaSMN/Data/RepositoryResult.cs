namespace PastelariaSMN.Data
{
    public class RepositoryResult<type>
    {
        public type Result {get; set;}

        public bool success { get; set;}

        public string Message {get; set;} 

        public static RepositoryResult<type> Error(string mensagem)
        {
            return new RepositoryResult<type>() 
            {
                success = false,
                Message = mensagem
            };
        }

        public static RepositoryResult<type> Success(type result)
        {
            return new RepositoryResult<type>()
            {
                success = true,
                Result = result
            };
        }
    }
}