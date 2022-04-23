using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ParcialSoftware.Data;

namespace ParcialSoftware.Helpers
{
    public class CombosHelper :ICombosHelper
    {
        private readonly DataContext _context;

        public CombosHelper(DataContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<SelectListItem>> GetComboEntrancesAsync()
        {
            List<SelectListItem> list = await _context.Entrances.Select(x => new SelectListItem
            {
                
                Value = x.Id.ToString()
            }).ToListAsync();

            list.Insert(0, new SelectListItem
            {
                Text = "[Seleccione una entrada...]",
                Value = "0"
            });

            return list;

        }
       
        
    }
}
