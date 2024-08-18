using backend.ImportModel;
using backend.Model;

namespace backend.Repository.Interface;

public interface IActivityRepository
{
    void CreateActivity(ActivityModel activity);
    ActivityModel GetActivity(int Id);
    void EditActivity(ActivityModel activity);
    void DeleteActivity(int Id);
}