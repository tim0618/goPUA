using backend.ImportModel;
using backend.Model;

namespace backend.Service.Interface;

public interface ITicketService
{
    void CreateTicket(CreateTicketImportModel createActivity);
    void EditTicket(EditTicketImportModel editTicket);
}