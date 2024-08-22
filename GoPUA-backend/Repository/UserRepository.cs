using backend.AppDBContext;
using backend.ImportModel;
using backend.Model;
using backend.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace backend.Repository;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;
    public UserRepository(AppDbContext context)
    {
        _context = context;
    }
    #region 註冊
    public void Register(UserModel register)
    {
        _context.User.Add(register);
        _context.SaveChanges();
    }
    #endregion
    #region 排除帳號重複
    public UserModel AccountCheck(string account)
    {
        return _context.User.AsNoTracking().FirstOrDefault(a => a.account == account);
    }
    #endregion
    #region 編輯會員資料
    public void EditUser(UserModel user)
    {
        var usermodel = _context.User.AsNoTracking().FirstOrDefault(t => t.Id == user.Id);

        if (usermodel != null)
        {
            _context.Entry(usermodel).State = EntityState.Detached;
            _context.User.Attach(user);

            _context.User.Update(user);
            _context.SaveChanges();
        }
    }
    #endregion
    #region 註銷
    public void Eradicate(int Id)
    {
        var userModel = _context.User.AsNoTracking().FirstOrDefault(a => a.Id == Id);

        if (userModel != null)
        {
            _context.Entry(userModel).State = EntityState.Detached;
            _context.User.Attach(userModel);

            _context.User.Remove(userModel);
            _context.SaveChanges();
        }
    }
    #endregion
    #region 登入
    public UserModel Login(LoginImportModel login)
    {
        return _context.User.AsNoTracking().FirstOrDefault(l => l.account == login.account);
    }
    #endregion
}