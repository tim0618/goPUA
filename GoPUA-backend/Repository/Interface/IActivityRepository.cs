using backend.ImportModel;
using backend.Model;

namespace backend.Repository.Interface;

public interface IActivityRepository
{
    void CreateActivity(ActivityModel activity);
    ActivityModel GetActivity(int Id);
    void EditActivity(ActivityModel activity);
    void DeleteActivity(int Id);
    List<ActivityModel> GetAllActivity();
    void UpdateActivity(ActivityModel activity);
    void CreateTicket(TicketModel ticket);
    TicketModel GetTicket(int Id);
    void EditTicket(TicketModel ticket);
    void DeleteTicket(int Id);
    List<TicketModel> GetActivityTicket(int activityId);
}