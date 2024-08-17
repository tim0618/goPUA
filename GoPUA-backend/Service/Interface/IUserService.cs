using backend.ImportModel;
using backend.Model;

namespace backend.Service.Interface;

public interface IUserService
{
    void Register(RegisterImportModel register);
    string Login(LoginImportModel login);
}