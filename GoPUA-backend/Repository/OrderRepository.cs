using backend.AppDBContext;
using backend.Model;
using backend.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace backend.Repository;

public class OrderRepository : IOrderRepository
{
    private readonly AppDbContext _context;
    public OrderRepository(AppDbContext context)
    {
        _context = context;
    }
    #region 新增購物車
    public void CreateCart(CartModel cart)
    {
        _context.Entry(cart).State = EntityState.Detached;
        _context.Cart.Attach(cart);

        _context.Cart.Add(cart);
        _context.SaveChanges();
    }
    #endregion
    #region 更新購物車
    public void UpdateCart(CartModel cart)
    {
        var cartModel = _context.Cart.AsNoTracking().FirstOrDefault(a => a.Id == cart.Id);

        if (cartModel != null)
        {
            _context.Entry(cartModel).State = EntityState.Detached;
            _context.Cart.Attach(cart);

            _context.Entry(cart).Property(c => c.orderList).IsModified = true;
            _context.SaveChanges();
        }
    }
    #endregion
    #region 取得登入者購物車
    public CartModel GetCart(int Id)
    {
        return _context.Cart.AsNoTracking().FirstOrDefault(a => a.Id == Id);
    }
    public void DeleteCart(int Id)
    {
        var cartModel = _context.Cart.AsNoTracking().FirstOrDefault(a => a.Id == Id);

        if (cartModel != null)
        {
            _context.Entry(cartModel).State = EntityState.Detached;
            _context.Cart.Attach(cartModel);

            _context.Cart.Remove(cartModel);
            _context.SaveChanges();
        }
    }
    #endregion
    #region 新增訂單
    public void CreateOrder(OrderModel Order)
    {
        _context.Entry(Order).State = EntityState.Detached;
        _context.Order.Attach(Order);

        _context.Order.Add(Order);
        _context.SaveChanges();
    }
    #endregion
    #region 編輯訂單
    public void EditOrder(OrderModel order)
    {
        var orderModel = _context.Order.AsNoTracking().FirstOrDefault(a => a.Id == order.Id);

        if (orderModel != null)
        {
            _context.Entry(orderModel).State = EntityState.Detached;
            _context.Order.Attach(order);

            _context.Order.Update(order);
            _context.SaveChanges();
        }
    }
    #endregion
    #region 取得單一訂單
    public OrderModel GetOrder(int Id)
    {
        return _context.Order.AsNoTracking().FirstOrDefault(a => a.Id == Id);
    }
    #endregion
    #region 刪除訂單
    public void DeleteOrder(int Id)
    {
        var orderModel = _context.Order.AsNoTracking().FirstOrDefault(a => a.Id == Id);

        if (orderModel != null)
        {
            _context.Entry(orderModel).State = EntityState.Detached;
            _context.Order.Attach(orderModel);

            _context.Order.Remove(orderModel);
            _context.SaveChanges();
        }
    }
    #endregion
    #region 取得單一購物車內的訂單
    public List<OrderModel> GetCartOrder(int cart_Id)
    {
        return _context.Order.AsNoTracking().Where(o => o.cart_Id == cart_Id).ToList();
    }
    #endregion
    #region 取得使用者的購物車
    public CartModel GetUserCart(int user_Id)
    {
        return _context.Cart.AsNoTracking().FirstOrDefault(u => u.user_Id == user_Id);
    }
    #endregion
    #region 取得使用者的ID
    public UserModel GetUser(string account)
    {
        return _context.User.AsNoTracking().FirstOrDefault(u => u.account == account);
    }
    #endregion
    #region 結帳
    public void Checkout(OrderModel checkout)
    {
        var checkoutModel = _context.Order.AsNoTracking().FirstOrDefault(a => a.Id == checkout.Id);

        if (checkoutModel != null)
        {
            _context.Entry(checkoutModel).State = EntityState.Detached;
            _context.Order.Attach(checkout);

            _context.Entry(checkout).Property(c => c.isBuy).IsModified = true;
            _context.Entry(checkout).Property(c => c.cart_Id).IsModified = true;
            _context.SaveChanges();
        }
    }
    #endregion
    #region 取得使用者已結帳訂單
    public List<OrderModel> GetIsBuyOrder(int cart_Id)
    {
        var orderList = _context.Order.AsNoTracking();

        orderList = orderList.Where(s => s.cart_Id == cart_Id);
        orderList = orderList.Where(s => s.isBuy == true);

        var isbuyorder = orderList.ToList();
        return isbuyorder;
    }
    #endregion

}