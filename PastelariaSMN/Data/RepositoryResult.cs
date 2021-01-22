namespace PastelariaSMN.Data
{
    public class RepositoryResult<type>
    {
        public type Result {get; set;}

        public bool sucess { get; set;}

        public string Message {get; set;} 

        public static RepositoryResult<type> Error(string mensagem)
        {
            return new RepositoryResult<type>() 
            {
                sucess = false,
                Message = mensagem
            };
        }

        public static RepositoryResult<type> Sucess(type result)
        {
            return new RepositoryResult<type>()
            {
                sucess = true,
                Result = result
            };
        }
    }
}