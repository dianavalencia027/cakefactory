using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace cakefactory.API.Helpers
{
    public interface ICombosHelper
    {
        IEnumerable<SelectListItem> GetCombosDocumentTypes();

        IEnumerable<SelectListItem> GetComboPersonalizations();

        IEnumerable<SelectListItem> GetComboProductTypes();
    }
}
