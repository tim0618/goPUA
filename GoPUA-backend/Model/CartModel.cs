namespace backend.Model;

public class CartModel
{
    public int Id { get; set; }
    public int user_Id { get; set; }
    public List<int>? orderList { get; set; }
}