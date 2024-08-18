using backend.ImportModel;
using backend.Model;

namespace backend.Repository.Interface;

public interface ITicketRepository
{
    void CreateTicket(TicketModel ticket);
    TicketModel GetTicket(int Id);
    void EditTicket(TicketModel ticket);
}