using System.IdentityModel.Tokens.Jwt;
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
    #region 註冊帳號
    public void Register(RegisterImportModel register)
    {
        try
        {
            if (AccountCheck(register.account))
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
            else
            {
                throw new Exception("帳號已被註冊");
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message.ToString());
        }
    }
    #endregion
    #region 排除重複帳號
    public bool AccountCheck(string Account)
    {
        try
        {
            var oldaccount = _repository.AccountCheck(Account);
            if (oldaccount == null)
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
    #region 編輯會員資料
    public void EditUser(EditUserImportModel editUser)
    {
        try
        {
            var editUseModel = new UserModel
            {
                Id = editUser.Id,
                account = editUser.account,
                password = editUser.password,
                email = editUser.email,
            };
            _repository.EditUser(editUseModel);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message.ToString());
        }
    }
    #endregion

    #region 刪除帳號
    public void Eradicate(EradicateImportModel eradicate)
    {
        try
        {
            _repository.Eradicate(eradicate.Id);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message.ToString());
        }
    }
    #endregion
    #region 登入
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
    #endregion
    public string Logout()
    {
        try
        {
            var expiredToken = new JwtSecurityTokenHandler().WriteToken(new JwtSecurityToken(
                       expires: DateTime.UtcNow.AddSeconds(-1)));

            return expiredToken;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message.ToString());
        }
    }

}