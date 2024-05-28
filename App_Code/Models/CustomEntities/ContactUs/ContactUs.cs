namespace UmbracoBlogFinal1.App_Code.Models.CustomEntities.ContactUs
{
    public class ContactUs
    {
        public int Id { get; set; }
        public string? FullName { get; set; }
        public required string Email { get; set; }

        public required string Subject { get; set; }
        public required string Message {  get; set; }
    }
}
