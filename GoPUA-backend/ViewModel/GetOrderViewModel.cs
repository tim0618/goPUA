using backend.Model;

namespace backend.ViewModel;

public class GetOrderViewModel
{
    public int Id { get; set; }
    public int ticket_Id { get; set; }
    public int buyAmount { get; set; }
    public bool isBuy { get; set; }
    public int cart_Id { get; set; }
}