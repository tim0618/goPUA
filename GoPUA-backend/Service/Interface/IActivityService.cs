using backend.ImportModel;
using backend.Model;
using backend.ViewModel;

namespace backend.Service.Interface;

public interface IActivityService
{
    void CreateActivity(CreateActivityImportModel createActivity);
    void EditActivity(EditActivityImportModel editActivity);
    void DeleteActivity(DeleteActivityImportModel deleteActivity);
    List<GetActivityViewModel> GetAllActivity();
    GetActivityViewModel GetActivity(int Id);
    void CreateTicket(CreateTicketImportModel createActivity);
    void EditTicket(EditTicketImportModel editTicket);
    void DeleteTicket(int ticket_Id, int activity_Id);
    GetTicketViewModel GetTicket(int Id);
    List<GetTicketViewModel> GetActivityTicket(int activity_Id);

}