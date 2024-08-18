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
                ticket_Id = null
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

            var edit = _repository.GetActivity(editActivity.Id);
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
                ticket_Id = editActivity.ticket_Id
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
            _repository.DeleteActivity(deleteActivity.Id);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message.ToString());
        }
    }
    #endregion
}

