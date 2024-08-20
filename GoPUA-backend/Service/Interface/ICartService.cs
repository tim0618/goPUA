using backend.ImportModel;
using backend.Model;

namespace backend.Service.Interface;

public interface ICartService
{
    void CreateCart(CreateCartImportModel createCart);
    void EditCart(EditCartImportModel editCart);
    void DeleteCart(DeleteCartImportModel deleteCart);
    void CreateOrder(CreateOrderImportModel createOrder);
    void EditOrder(EditOrderImportModel editOrder);
    void DeleteOrder(int order_Id, int cart_Id);
}