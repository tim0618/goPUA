using backend.ImportModel;
using backend.Model;

namespace backend.Service.Interface;

public interface IActivityService
{
    void CreateActivity(CreateActivityImportModel createActivity);
    void EditActivity(EditActivityImportModel editActivity);
}