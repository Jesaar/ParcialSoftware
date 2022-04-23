using ParcialSoftware.Data;
using ParcialSoftware.Helpers;

namespace ParcialSoftware.Controllers
{
    public class EntranceController
    {
        private readonly DataContext _context;
        private readonly ICombosHelper _combosHelper;

        public EntranceController(DataContext context,ICombosHelper combosHelper)
        {
             _context = context;
             _combosHelper = combosHelper;
        }
    }
}
