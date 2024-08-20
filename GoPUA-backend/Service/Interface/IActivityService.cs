using backend.ImportModel;
using backend.Model;

namespace backend.Service.Interface;

public interface IActivityService
{
    void CreateActivity(CreateActivityImportModel createActivity);
    void EditActivity(EditActivityImportModel editActivity);
    void DeleteActivity(DeleteActivityImportModel deleteActivity);
    void CreateTicket(CreateTicketImportModel createActivity);
    void EditTicket(EditTicketImportModel editTicket);
    void DeleteTicket(int ticket_Id, int activity_Id);
}