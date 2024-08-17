using backend.AppDBContext;
using backend.ImportModel;
using backend.Model;
using backend.Repository.Interface;

namespace backend.Repository;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;
    public UserRepository(AppDbContext context)
    {
        _context = context;
    }
    public void Register(UserModel register)
    {
        _context.User.Add(register);
        _context.SaveChanges();
    }
    public UserModel Login(LoginImportModel login)
    {
        var loginUser = _context.User.Where(l => l.account == login.account).FirstOrDefault();
        return loginUser;
    }
}