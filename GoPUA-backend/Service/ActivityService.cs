using backend.ImportModel;
using backend.Model;
using backend.Repository.Interface;
using backend.Service.Interface;

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
            _repository.EditActivity(updateActModel);
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
    #region 取得活動的票種
    public List<int> GetSameTicket(int activity_Id)
    {
        try
        {
            var actTicket = _repository.GetSameTicket(activity_Id);
            List<int> tickets = actTicket.Select(t => t.Id).ToList();
            return tickets;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message.ToString());
        }
    }
    #endregion

}

