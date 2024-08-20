using backend.ImportModel;
using backend.Model;

namespace backend.Repository.Interface;

public interface ICartRepository
{
    void CreateCart(CartModel Cart);
    CartModel GetCart(int Id);
    void EditCart(CartModel Cart);
    void DeleteCart(int Id);
    void CreateOrder(OrderModel Order);
    OrderModel GetOrder(int Id);
    void EditOrder(OrderModel Order);
    void DeleteOrder(int Id);
    List<OrderModel> GetUserOrder(int cart_Id);

}