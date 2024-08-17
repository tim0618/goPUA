using backend.ImportModel;
using backend.Model;
using backend.Repository.Interface;
using backend.Service.Interface;

namespace backend.Service;

public class UserService : IUserService
{
    private readonly Token _token;
    private readonly IUserRepository _repository;

    public UserService(IUserRepository repository, Token token)
    {
        _repository = repository;
        _token = token;
    }
    public void Register(RegisterImportModel register)
    {
        try
        {
            var registerModel = new UserModel
            {
                account = register.account,
                password = register.password,
                email = register.email,
                role = register.role
            };
            _repository.Register(registerModel);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message.ToString());
        }
    }
    public string Login(LoginImportModel login)
    {
        try
        {
            var loginModel = _repository.Login(login);
            loginModel = new UserModel
            {
                Id = loginModel.Id,
                account = loginModel.account,
                password = loginModel.password,
                email = loginModel.email,
                role = loginModel.role
            };
            var usertoken = _token.GenerateToken(loginModel);
            return usertoken;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message.ToString());
        }
    }

}