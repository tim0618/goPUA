using backend.ImportModel;
using backend.Model;

namespace backend.Repository.Interface;

public interface IUserRepository
{
    void Register(UserModel register);
    UserModel Login(LoginImportModel login);

}