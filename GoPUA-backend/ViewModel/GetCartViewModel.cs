using backend.Model;

namespace backend.ViewModel;

public class GetCartViewModel
{
    public int Id { get; set; }
    public int user_Id { get; set; }
    public List<int>? orderList { get; set; }
}