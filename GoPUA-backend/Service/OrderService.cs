using backend.ImportModel;
using backend.Model;
using backend.Repository.Interface;
using backend.Service.Interface;
using backend.ViewModel;

namespace backend.Service;

public class OrderService : IOrderService
{
    private readonly ActivityService _actService;
    private readonly IOrderRepository _repository;

    public OrderService(IOrderRepository repository, ActivityService actService)
    {
        _repository = repository;
        _actService = actService;
    }
    #region 新增購物車
    public void CreateCart(string account)
    {
        try
        {
            var user = _repository.GetUser(account);
            var usercart = _repository.GetUserCart(user.Id);
            if (usercart == null)
            {
                var createCarModel = new CartModel
                {
                    user_Id = user.Id,
                };
                _repository.CreateCart(createCarModel);
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message.ToString());
        }
    }
    #endregion
    #region 取得登入者的購物車
    public GetCartViewModel GetCart(string account)
    {
        try
        {
            var user = _repository.GetUser(account);
            var usercart = _repository.GetUserCart(user.Id);

            var CarModel = new GetCartViewModel
            {
                Id = usercart.Id,
                user_Id = usercart.user_Id,
                orderList = usercart.orderList,
            };
            return CarModel;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message.ToString());
        }
    }
    #endregion
    #region 刪除購物車
    public void DeleteCart(int user_Id)
    {
        try
        {
            var usercart = _repository.GetUserCart(user_Id);
            if (usercart != null)
            {
                var orders = GetUserOrder(usercart.Id);
                if (orders != null)
                {
                    foreach (var id in orders)
                    {
                        DeleteOrder(id, usercart.Id);
                    }
                }
                _repository.DeleteCart(usercart.Id);
            }
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
            _repository.UpdateCart(updateCarModel);
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
            var ticketAmount = _actService.GetTicket(createOrder.ticket_Id);
            if (createOrder.buyAmount <= ticketAmount.totalAmount)
            {
                var createOrdModel = new OrderModel
                {
                    ticket_Id = createOrder.ticket_Id,
                    buyAmount = createOrder.buyAmount,
                    isBuy = false,
                    cart_Id = createOrder.cart_Id,
                };
                _repository.CreateOrder(createOrdModel);
                UpdateCart(createOrder.cart_Id);
            }
            else
            {
                throw new Exception("目前剩餘票數低於購買票數");
            }
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
            var ticketAmount = _actService.GetTicket(editOrder.ticket_Id);

            if (editOrder.buyAmount <= ticketAmount.totalAmount)
            {
                if (IsCheckout(editOrder.Id))
                {
                    var editOrdModel = new OrderModel
                    {
                        Id = editOrder.Id,
                        ticket_Id = editOrder.ticket_Id,
                        buyAmount = editOrder.buyAmount,
                        cart_Id = editOrder.cart_Id,
                    };
                    _repository.EditOrder(editOrdModel);
                }
                else
                {
                    throw new Exception("已購買的票卷無法編輯");
                }
            }
            else
            {
                throw new Exception("目前剩餘票數低於購買票數");
            }
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
            if (IsCheckout(order_Id))
            {
                _repository.DeleteOrder(order_Id);
                UpdateCart(cart_Id);
            }
            else
            {
                throw new Exception("已購買的票卷無法刪除");
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message.ToString());
        }
    }
    #endregion
    #region 取得單一購物車的所有訂單ID
    public List<int> GetUserOrder(int cart_Id)
    {
        try
        {
            var cartOrder = _repository.GetCartOrder(cart_Id);
            List<int> orders = cartOrder.Select(t => t.Id).ToList();
            return orders;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message.ToString());
        }
    }
    #endregion
    #region 取得單一訂單
    public GetOrderViewModel GetOrder(int order_Id)
    {
        try
        {
            var order = _repository.GetOrder(order_Id);

            var OrdModel = new GetOrderViewModel
            {
                Id = order.Id,
                ticket_Id = order.ticket_Id,
                buyAmount = order.buyAmount,
                isBuy = order.isBuy,
                cart_Id = order.cart_Id,
            };
            return OrdModel;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message.ToString());
        }
    }
    #endregion
    #region 取得單一購物車的所有訂單
    public List<GetOrderViewModel> GetCartOrder(int cart_Id)
    {
        try
        {
            var cartOrder = _repository.GetCartOrder(cart_Id);

            var OrdModel = cartOrder.Select(car => new GetOrderViewModel
            {
                Id = car.Id,
                ticket_Id = car.ticket_Id,
                buyAmount = car.buyAmount,
                isBuy = car.isBuy,
                cart_Id = car.cart_Id,
            }).ToList();
            return OrdModel;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message.ToString());
        }
    }
    #endregion
    #region 結帳
    public void Checkout(CheckoutImportModel checkout)
    {
        try
        {
            var checkoutModel = new OrderModel
            {
                Id = checkout.Id,
                isBuy = true,
                cart_Id = 0,
            };
            _repository.Checkout(checkoutModel);
            UpdateCart(checkout.Id);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message.ToString());
        }
    }
    #endregion
    #region 結帳確認
    public bool IsCheckout(int order_Id)
    {
        try
        {
            var oldorder = _repository.GetOrder(order_Id);
            if (oldorder.isBuy == false)
                return true;
            else
                return false;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message.ToString());
        }
    }
    #endregion
    #region 取得使用者已結帳訂單
    public List<GetOrderViewModel> GetIsBuyOrder(int cart_Id)
    {
        try
        {
            var isbuyorder = _repository.GetIsBuyOrder(cart_Id);

            var OrdModel = isbuyorder.Select(buy => new GetOrderViewModel
            {
                Id = buy.Id,
                ticket_Id = buy.ticket_Id,
                buyAmount = buy.buyAmount,
                isBuy = buy.isBuy,
                cart_Id = buy.cart_Id,
            }).ToList();
            return OrdModel;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message.ToString());
        }
    }
    #endregion
}

