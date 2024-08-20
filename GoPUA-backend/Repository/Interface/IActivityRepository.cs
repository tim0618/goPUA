using backend.ImportModel;
using backend.Model;

namespace backend.Repository.Interface;

public interface IActivityRepository
{
    void CreateActivity(ActivityModel activity);
    ActivityModel GetActivity(int Id);
    void EditActivity(ActivityModel activity);
    void DeleteActivity(int Id);
    void CreateTicket(TicketModel ticket);
    TicketModel GetTicket(int Id);
    void EditTicket(TicketModel ticket);
    void DeleteTicket(int Id);
    List<TicketModel> GetSameTicket(int activityId);
}