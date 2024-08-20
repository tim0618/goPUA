using backend.AppDBContext;
using backend.ImportModel;
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
    public void CreateActivity(ActivityModel activity)
    {
        _context.Entry(activity).State = EntityState.Detached;
        _context.Activity.Attach(activity);

        _context.Activity.Add(activity);
        _context.SaveChanges();
    }
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

    public ActivityModel GetActivity(int Id)
    {
        return _context.Activity.AsNoTracking().FirstOrDefault(a => a.Id == Id);
    }
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
    public void CreateTicket(TicketModel ticket)
    {
        _context.Entry(ticket).State = EntityState.Detached;
        _context.Ticket.Attach(ticket);

        _context.Ticket.Add(ticket);
        _context.SaveChanges();
    }
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
    public TicketModel GetTicket(int Id)
    {
        return _context.Ticket.AsNoTracking().FirstOrDefault(t => t.Id == Id);
    }
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
    public List<TicketModel> GetSameTicket(int activityId)
    {
        return _context.Ticket.AsNoTracking().Where(t => t.activity_Id == activityId).ToList();
    }

}