namespace StockControlApi.Models
{
    public class UserResponse
    {
        public Guid Id { get; set; }
        public string Login { get; set; }
        public string Token { get; set; }
    }
}
