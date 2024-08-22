using backend.AppDBContext;
using backend.Model;
using backend.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace backend.Repository;

public class ActivityRepository : IActivityRepository
{
    private readonly AppDbContext _context;
    public ActivityRepository(AppDbContext context)
    {
        _context = context;
    }
    #region 新增活動
    public void CreateActivity(ActivityModel activity)
    {
        _context.Entry(activity).State = EntityState.Detached;
        _context.Activity.Attach(activity);

        _context.Activity.Add(activity);
        _context.SaveChanges();
    }
    #endregion
    #region 編輯活動
    public void EditActivity(ActivityModel activity)
    {
        var activityModel = _context.Activity.AsNoTracking().FirstOrDefault(a => a.Id == activity.Id);

        if (activityModel != null)
        {
            _context.Entry(activityModel).State = EntityState.Detached;
            _context.Activity.Attach(activity);

            _context.Activity.Update(activity);
            _context.SaveChanges();
        }
    }
    #endregion
    #region 取得指定活動
    public ActivityModel GetActivity(int Id)
    {
        return _context.Activity.AsNoTracking().FirstOrDefault(a => a.Id == Id);
    }
    #endregion
    #region 刪除活動
    public void DeleteActivity(int Id)
    {
        var activityModel = _context.Activity.AsNoTracking().FirstOrDefault(a => a.Id == Id);

        if (activityModel != null)
        {
            _context.Entry(activityModel).State = EntityState.Detached;
            _context.Activity.Attach(activityModel);

            _context.Activity.Remove(activityModel);
            _context.SaveChanges();
        }
    }
    #endregion
    #region 取得所有活動
    public List<ActivityModel> GetAllActivity()
    {
        return _context.Activity.AsNoTracking().ToList();
    }
    #endregion
    #region 更新指定活動裡面的票種清單
    public void UpdateActivity(ActivityModel activity)
    {
        var activityModel = _context.Activity.AsNoTracking().FirstOrDefault(a => a.Id == activity.Id);

        if (activityModel != null)
        {
            _context.Entry(activityModel).State = EntityState.Detached;
            _context.Activity.Attach(activity);

            _context.Entry(activity).Property(c => c.ticketList).IsModified = true;
            _context.SaveChanges();
        }
    }
    #endregion
    #region 新增票種
    public void CreateTicket(TicketModel ticket)
    {
        _context.Entry(ticket).State = EntityState.Detached;
        _context.Ticket.Attach(ticket);

        _context.Ticket.Add(ticket);
        _context.SaveChanges();
    }
    #endregion
    #region 編輯票種
    public void EditTicket(TicketModel ticket)
    {
        var ticketmodel = _context.Ticket.AsNoTracking().FirstOrDefault(t => t.Id == ticket.Id);

        if (ticketmodel != null)
        {
            _context.Entry(ticketmodel).State = EntityState.Detached;
            _context.Ticket.Attach(ticket);

            _context.Ticket.Update(ticket);
            _context.SaveChanges();
        }
    }
    #endregion
    #region 取得指定票種
    public TicketModel GetTicket(int Id)
    {
        return _context.Ticket.AsNoTracking().FirstOrDefault(t => t.Id == Id);
    }
    #endregion
    #region 刪除票種
    public void DeleteTicket(int Id)
    {
        var ticketmodel = _context.Ticket.AsNoTracking().FirstOrDefault(t => t.Id == Id);

        if (ticketmodel != null)
        {
            _context.Entry(ticketmodel).State = EntityState.Detached;
            _context.Ticket.Attach(ticketmodel);

            _context.Ticket.Remove(ticketmodel);
            _context.SaveChanges();
        }
    }
    #endregion
    #region 取得單一活動的所有票種
    public List<TicketModel> GetActivityTicket(int activityId)
    {
        return _context.Ticket.AsNoTracking().Where(t => t.activity_Id == activityId).ToList();
    }
    #endregion
}