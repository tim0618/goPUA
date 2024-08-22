using backend.ImportModel;
using backend.Model;
using backend.Repository.Interface;
using backend.Service.Interface;
using backend.ViewModel;

namespace backend.Service;

public class ActivityService : IActivityService
{
    private readonly IActivityRepository _repository;

    public ActivityService(IActivityRepository repository)
    {
        _repository = repository;
    }
    #region 新增活動
    public void CreateActivity(CreateActivityImportModel createActivity)
    {
        try
        {
            string formattedDateTime = DateTime.Now.ToString("yyyyMMddHHmmss");
            var FileName = createActivity.areaImg != null ?
              formattedDateTime + "_" + Guid.NewGuid().ToString() + Path.GetExtension(createActivity.areaImg.FileName) :
              null;
            var folderPath = Path.Combine("C:\\AreaImages");
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            var createActModel = new ActivityModel
            {
                name = createActivity.name,
                place = createActivity.place,
                type = createActivity.type,
                startSale = createActivity.startSale,
                endSale = createActivity.endSale,
                startAct = createActivity.startAct,
                endAct = createActivity.endAct,
                startTime = createActivity.startTime,
                endTime = createActivity.endTime,
                hoster = createActivity.hoster,
                content = createActivity.content,
                areaImg = FileName,
                ticketList = null
            };
            _repository.CreateActivity(createActModel);

            if (FileName != null)
            {
                var path = Path.Combine(folderPath, FileName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    createActivity.areaImg.CopyTo(stream);
                }
            }

        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message.ToString());
        }
    }
    #endregion
    #region 編輯活動
    public void EditActivity(EditActivityImportModel editActivity)
    {
        try
        {
            string formattedDateTime = DateTime.Now.ToString("yyyyMMddHHmmss");
            var FileName = editActivity.areaImg != null ?
              formattedDateTime + "_" + Guid.NewGuid().ToString() + Path.GetExtension(editActivity.areaImg.FileName) :
              null;
            var folderPath = Path.Combine("C:\\AreaImages");
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            var tickets = GetSameTicket(editActivity.Id);

            var editActModel = new ActivityModel
            {
                Id = editActivity.Id,
                name = editActivity.name,
                place = editActivity.place,
                type = editActivity.type,
                startSale = editActivity.startSale,
                endSale = editActivity.endSale,
                startAct = editActivity.startAct,
                endAct = editActivity.endAct,
                startTime = editActivity.startTime,
                endTime = editActivity.endTime,
                hoster = editActivity.hoster,
                content = editActivity.content,
                areaImg = FileName,
                ticketList = tickets
            };
            _repository.EditActivity(editActModel);

            if (FileName != null)
            {
                var path = Path.Combine(folderPath, FileName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    editActivity.areaImg.CopyTo(stream);
                }
            }

        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message.ToString());
        }
    }
    #endregion
    #region 刪除活動
    public void DeleteActivity(DeleteActivityImportModel deleteActivity)
    {
        try
        {
            var tickets = GetSameTicket(deleteActivity.Id);
            if (tickets != null)
            {
                foreach (var Id in tickets)
                {
                    DeleteTicket(Id, deleteActivity.Id);
                }
            }
            _repository.DeleteActivity(deleteActivity.Id);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message.ToString());
        }
    }
    #endregion
    #region 取得所有活動
    public List<GetActivityViewModel> GetAllActivity()
    {
        try
        {
            var allactivity = _repository.GetAllActivity();

            var ActModel = allactivity.Select(act => new GetActivityViewModel
            {
                Id = act.Id,
                name = act.name,
                place = act.place,
                type = act.type,
                startSale = act.startSale,
                endSale = act.endSale,
                startAct = act.startAct,
                endAct = act.endAct,
                startTime = act.startTime,
                endTime = act.endTime,
                hoster = act.hoster,
                content = act.content,
                areaImg = act.areaImg,
                ticketList = act.ticketList
            }).ToList();
            return ActModel;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message.ToString());
        }
    }
    #endregion
    #region 取得單一活動
    public GetActivityViewModel GetActivity(int activity_Id)
    {
        try
        {
            var activity = _repository.GetActivity(activity_Id);

            var ActModel = new GetActivityViewModel
            {
                Id = activity.Id,
                name = activity.name,
                place = activity.place,
                type = activity.type,
                startSale = activity.startSale,
                endSale = activity.endSale,
                startAct = activity.startAct,
                endAct = activity.endAct,
                startTime = activity.startTime,
                endTime = activity.endTime,
                hoster = activity.hoster,
                content = activity.content,
                areaImg = activity.areaImg,
                ticketList = activity.ticketList
            };
            return ActModel;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message.ToString());
        }
    }
    #endregion
    #region 更新活動的票種
    public void UpdateActivity(int Id)
    {
        try
        {
            var tickets = GetSameTicket(Id);
            var updateActModel = new ActivityModel
            {
                Id = Id,
                ticketList = tickets,
            };
            _repository.UpdateActivity(updateActModel);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message.ToString());
        }
    }
    #endregion
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
            UpdateActivity(createTicket.activity_Id);
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
            var editTicModel = new TicketModel
            {
                Id = editTicket.Id,
                name = editTicket.name,
                type = editTicket.type,
                startTime = editTicket.startTime,
                endTime = editTicket.endTime,
                totalAmount = editTicket.totalAmount,
                activity_Id = editTicket.activity_Id
            };
            _repository.EditTicket(editTicModel);

        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message.ToString());
        }
    }
    #endregion
    #region 刪除票種
    public void DeleteTicket(int ticket_Id, int activity_Id)
    {
        try
        {
            _repository.DeleteTicket(ticket_Id);
            UpdateActivity(activity_Id);

        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message.ToString());
        }
    }
    #endregion
    #region 取得單一活動的所有票種ID
    public List<int> GetSameTicket(int activity_Id)
    {
        try
        {
            var actTicket = _repository.GetActivityTicket(activity_Id);
            List<int> tickets = actTicket.Select(t => t.Id).ToList();
            return tickets;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message.ToString());
        }
    }
    #endregion
    #region 取得單一票種
    public GetTicketViewModel GetTicket(int ticket_Id)
    {
        try
        {
            var ticket = _repository.GetTicket(ticket_Id);

            var TicModel = new GetTicketViewModel
            {
                Id = ticket.Id,
                name = ticket.name,
                type = ticket.type,
                startTime = ticket.startTime,
                endTime = ticket.endTime,
                totalAmount = ticket.totalAmount,
                activity_Id = ticket.activity_Id,
            };
            return TicModel;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message.ToString());
        }
    }
    #endregion
    #region 取得單一活動的所有票種
    public List<GetTicketViewModel> GetActivityTicket(int activity_Id)
    {
        try
        {
            var actTicket = _repository.GetActivityTicket(activity_Id);

            var TicModel = actTicket.Select(act => new GetTicketViewModel
            {
                Id = act.Id,
                name = act.name,
                type = act.type,
                startTime = act.startTime,
                endTime = act.endTime,
                totalAmount = act.totalAmount,
                activity_Id = act.activity_Id,
            }).ToList();
            return TicModel;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message.ToString());
        }
    }
    #endregion
}

