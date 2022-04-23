using Microsoft.AspNetCore.Mvc.Rendering;

namespace ParcialSoftware.Helpers
{
    public interface ICombosHelper
    {
        public interface ICombosHelper
        {
            Task<IEnumerable<SelectListItem>> GetComboEntrancesAsync();

            Task<IEnumerable<SelectListItem>> GetComboTicketsAsync();
        }
    }
}
