namespace UmbracoBlogFinal1.App_Code.Models.ViewComponentModels
{
    public class FooterView
    {
        public List<FooterLink>? FooterLinks { get; set; }=new List<FooterLink>();

    }
    public class FooterLink
    {
        public string? Name { get; set; }
        public string? Url { get; set; }
        public string? Target { get; set; }
    }
}
