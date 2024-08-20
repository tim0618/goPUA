using backend.ImportModel;
using backend.Model;
using backend.Repository.Interface;
using backend.Service.Interface;

namespace backend.Service;

public class CartService : ICartService
{
    private readonly ICartRepository _repository;

    public CartService(ICartRepository repository)
    {
        _repository = repository;
    }
    #region 新增購物車
    public void CreateCart(CreateCartImportModel createCart)
    {
        try
        {

            var createCarModel = new CartModel
            {
                user_Id = createCart.user_Id,
                orderList = createCart.orderList,
            };
            _repository.CreateCart(createCarModel);


        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message.ToString());
        }
    }
    #endregion
    #region 編輯購物車
    public void EditCart(EditCartImportModel editCart)
    {
        try
        {

            var editCarModel = new CartModel
            {
                Id = editCart.Id,
                user_Id = editCart.user_Id,
                orderList = editCart.orderList,
            };
            _repository.EditCart(editCarModel);


        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message.ToString());
        }
    }
    #endregion
    #region 刪除購物車
    public void DeleteCart(DeleteCartImportModel deleteCart)
    {
        try
        {
            var orders = GetUserOrder(deleteCart.Id);
            if (orders != null)
            {
                foreach (var id in orders)
                {
                    DeleteOrder(id, deleteCart.Id);
                }
            }
            _repository.DeleteCart(deleteCart.Id);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message.ToString());
        }
    }
    #endregion
    #region 更新購物車裡的訂單
    public void UpdateCart(int Id)
    {
        try
        {
            var orders = GetUserOrder(Id);
            var updateCarModel = new CartModel
            {
                Id = Id,
                orderList = orders,
            };
            _repository.EditCart(updateCarModel);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message.ToString());
        }
    }
    #endregion
    #region 新增訂單
    public void CreateOrder(CreateOrderImportModel createOrder)
    {
        try
        {

            var createOrdModel = new OrderModel
            {
                ticket_Id = createOrder.ticket_Id,
                buyAmount = createOrder.buyAmount,
                isBuy = createOrder.isBuy,
                cart_Id = createOrder.ticket_Id,
            };
            _repository.CreateOrder(createOrdModel);
            UpdateCart(createOrder.cart_Id);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message.ToString());
        }
    }
    #endregion
    #region 編輯訂單
    public void EditOrder(EditOrderImportModel editOrder)
    {
        try
        {

            var editOrdModel = new OrderModel
            {
                Id = editOrder.Id,
                ticket_Id = editOrder.ticket_Id,
                buyAmount = editOrder.buyAmount,
                isBuy = editOrder.isBuy,
                cart_Id = editOrder.ticket_Id,
            };
            _repository.EditOrder(editOrdModel);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message.ToString());
        }
    }
    #endregion
    #region 刪除訂單
    public void DeleteOrder(int order_Id, int cart_Id)
    {
        try
        {
            _repository.DeleteOrder(order_Id);
            UpdateCart(cart_Id);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message.ToString());
        }
    }
    #endregion
    #region 取得購物車內的訂單
    public List<int> GetUserOrder(int cart_Id)
    {
        try
        {
            var cartOrder = _repository.GetUserOrder(cart_Id);
            List<int> orders = cartOrder.Select(t => t.Id).ToList();
            return orders;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message.ToString());
        }
    }
    #endregion

}

