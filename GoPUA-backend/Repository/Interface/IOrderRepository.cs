using backend.ImportModel;
using backend.Model;

namespace backend.Repository.Interface;

public interface IOrderRepository
{
    void CreateCart(CartModel cart);
    CartModel GetCart(int Id);
    void UpdateCart(CartModel cart);
    void DeleteCart(int Id);
    void CreateOrder(OrderModel order);
    OrderModel GetOrder(int Id);
    void EditOrder(OrderModel order);
    void DeleteOrder(int Id);
    List<OrderModel> GetCartOrder(int cart_Id);
    CartModel GetUserCart(int user_Id);
    UserModel GetUser(string account);
    void Checkout(OrderModel checkout);
    List<OrderModel> GetIsBuyOrder(int cart_Id);
}