using backend.ImportModel;
using backend.Model;
using backend.ViewModel;

namespace backend.Service.Interface;

public interface IOrderService
{
    void CreateOrder(CreateOrderImportModel createOrder);
    void EditOrder(EditOrderImportModel editOrder);
    void DeleteOrder(int order_Id, int cart_Id);
    void Checkout(CheckoutImportModel checkout);
    GetOrderViewModel GetOrder(int order_Id);
    List<GetOrderViewModel> GetCartOrder(int cart_Id);
    List<GetOrderViewModel> GetIsBuyOrder(int cart_Id);
}