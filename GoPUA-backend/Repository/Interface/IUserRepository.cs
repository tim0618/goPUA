using backend.ImportModel;
using backend.Model;

namespace backend.Repository.Interface;

public interface IUserRepository
{
    void Register(UserModel register);
    void EditUser(UserModel user);
    void Eradicate(int Id);
    UserModel Login(LoginImportModel login);
    UserModel AccountCheck(string account);

}