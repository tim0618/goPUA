namespace backend.Model;

public class UserModel
{
    public int Id { get; set; }
    public string account { get; set; }
    public string password { get; set; }
    public string email { get; set; }
    public int role { get; set; }
}