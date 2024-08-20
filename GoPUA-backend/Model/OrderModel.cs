namespace backend.Model;

public class OrderModel
{
    public int Id { get; set; }
    public int ticket_Id { get; set; }
    public int buyAmount { get; set; }
    public int isBuy { get; set; }
    public int cart_Id { get; set; }
}