using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ParcialSoftware.Data;


using ParcialSoftware.Helpers;

namespace ParcialSoftware.Controllers
{
    public class TicketsController : Controller
    {
        private readonly DataContext _context;
        private readonly ICombosHelper _combosHelper;


        public TicketsController(DataContext context, ICombosHelper combosHelper)
        {
            _context = context;
            _combosHelper = combosHelper;

        }
        public async Task<IActionResult> Ticket()
        {
            Ticket obj = new Ticket();
            obj.Id = 100;
            obj.Name = "Mauro";
            obj.Document = "12334";
            obj.Date = null;
            obj.WasUsed = true;
            return View(obj);
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Tickets
                .Include(p => p.TicketEntrances)
                .ThenInclude(pc => pc.Entrance)
                .ToListAsync());
        }
        
         
    }
}
