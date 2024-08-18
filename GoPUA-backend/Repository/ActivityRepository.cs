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
        _context.Activity.Add(activity);
        _context.SaveChanges();
    }
    public void EditActivity(ActivityModel activity)
    {
        _context.Activity.Update(activity);
        _context.SaveChanges();
    }
    public ActivityModel GetActivity(int Id)
    {
        return _context.Activity.AsNoTracking().FirstOrDefault(a => a.Id == Id);
    }
    public void DeleteActivity(int Id)
    {
        var activity = _context.Activity.Where(activity => activity.Id == Id).FirstOrDefault();

        if (activity != null)
        {
            _context.Activity.Remove(activity);
            _context.SaveChanges();
        }
    }
}