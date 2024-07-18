namespace StudentMVC.Models.ViewModels
{
    public class AddStudent
    {
        public string Name { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime Birthdate { get; set; }
        public string Email { get; set; } = string.Empty;
    }
}
