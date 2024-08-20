using backend.AppDBContext;
using backend.ImportModel;
using backend.Model;
using backend.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace backend.Repository;

public class CartRepository : ICartRepository
{
    private readonly AppDbContext _context;
    public CartRepository(AppDbContext context)
    {
        _context = context;
    }
    public void CreateCart(CartModel Cart)
    {
        _context.Entry(Cart).State = EntityState.Detached;
        _context.Cart.Attach(Cart);

        _context.Cart.Add(Cart);
        _context.SaveChanges();
    }
    public void EditCart(CartModel Cart)
    {
        var CartModel = _context.Cart.AsNoTracking().FirstOrDefault(a => a.Id == Cart.Id);

        if (CartModel != null)
        {
            _context.Entry(CartModel).State = EntityState.Detached;
            _context.Cart.Attach(Cart);

            _context.Cart.Update(Cart);
            _context.SaveChanges();
        }
    }

    public CartModel GetCart(int Id)
    {
        return _context.Cart.AsNoTracking().FirstOrDefault(a => a.Id == Id);
    }
    public void DeleteCart(int Id)
    {
        var CartModel = _context.Cart.AsNoTracking().FirstOrDefault(a => a.Id == Id);

        if (CartModel != null)
        {
            _context.Entry(CartModel).State = EntityState.Detached;
            _context.Cart.Attach(CartModel);

            _context.Cart.Remove(CartModel);
            _context.SaveChanges();
        }
    }
    public void CreateOrder(OrderModel Order)
    {
        _context.Entry(Order).State = EntityState.Detached;
        _context.Order.Attach(Order);

        _context.Order.Add(Order);
        _context.SaveChanges();
    }
    public void EditOrder(OrderModel Order)
    {
        var OrderModel = _context.Order.AsNoTracking().FirstOrDefault(a => a.Id == Order.Id);

        if (OrderModel != null)
        {
            _context.Entry(OrderModel).State = EntityState.Detached;
            _context.Order.Attach(Order);

            _context.Order.Update(Order);
            _context.SaveChanges();
        }
    }

    public OrderModel GetOrder(int Id)
    {
        return _context.Order.AsNoTracking().FirstOrDefault(a => a.Id == Id);
    }
    public void DeleteOrder(int Id)
    {
        var OrderModel = _context.Order.AsNoTracking().FirstOrDefault(a => a.Id == Id);

        if (OrderModel != null)
        {
            _context.Entry(OrderModel).State = EntityState.Detached;
            _context.Order.Attach(OrderModel);

            _context.Order.Remove(OrderModel);
            _context.SaveChanges();
        }
    }
    public List<OrderModel> GetUserOrder(int cart_Id)
    {
        return _context.Order.AsNoTracking().Where(o => o.cart_Id == cart_Id).ToList();
    }
}