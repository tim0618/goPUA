using backend.ImportModel;
using backend.Model;

namespace backend.Service.Interface;

public interface IUserService
{
    void Register(RegisterImportModel register);
    void EditUser(EditUserImportModel editUser);
    void Eradicate(EradicateImportModel eradicate);
    string Login(LoginImportModel login);
    string Logout();
}