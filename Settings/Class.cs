namespace ProductService.Settings
{
    public class AuthenticationSettings
    {
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public string SecretForKey { get; set; }
    }
}
