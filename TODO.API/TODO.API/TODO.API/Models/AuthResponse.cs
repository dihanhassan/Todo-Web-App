namespace TODO.API.Models
{
    public class AuthResponse
    {
        public int StatusCode { get; set; }
        public string StatusMessage { get; set; }

        public Login Login { get; set; }
        
    }
}
