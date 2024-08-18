using backend.AppDBContext;
using backend.ImportModel;
using backend.Model;
using backend.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace backend.Repository;

public class TicketRepository : ITicketRepository
{
    private readonly AppDbContext _context;
    public TicketRepository(AppDbContext context)
    {
        _context = context;
    }
    public void CreateTicket(TicketModel ticket)
    {
        _context.Ticket.Add(ticket);
        _context.SaveChanges();
    }
    public void EditTicket(TicketModel ticket)
    {
        _context.Ticket.Update(ticket);
        _context.SaveChanges();
    }
    public TicketModel GetTicket(int Id)
    {
        return _context.Ticket.AsNoTracking().FirstOrDefault(t => t.Id == Id);
    }

}