using backend.ImportModel;
using backend.Model;
using backend.Repository.Interface;
using backend.Service.Interface;

namespace backend.Service;

public class TicketService : ITicketService
{
    private readonly ITicketRepository _repository;

    public TicketService(ITicketRepository repository)
    {
        _repository = repository;
    }
    #region 新增票種
    public void CreateTicket(CreateTicketImportModel createTicket)
    {
        try
        {
            var createTicModel = new TicketModel
            {
                name = createTicket.name,
                type = createTicket.type,
                startTime = createTicket.startTime,
                endTime = createTicket.endTime,
                totalAmount = createTicket.totalAmount,
                activity_Id = createTicket.activity_Id

            };
            _repository.CreateTicket(createTicModel);

        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message.ToString());
        }
    }
    #endregion
    #region 編輯票種
    public void EditTicket(EditTicketImportModel editTicket)
    {
        try
        {

            var edit = _repository.GetTicket(editTicket.Id);

            var editActModel = new TicketModel
            {
                Id = editTicket.Id,
                name = editTicket.name,
                type = editTicket.type,
                startTime = editTicket.startTime,
                endTime = editTicket.endTime,
                totalAmount = editTicket.totalAmount,
                activity_Id = editTicket.activity_Id
            };
            _repository.EditTicket(editActModel);

        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message.ToString());
        }
    }
    #endregion
}