using System;
using cakefactory.API.Data.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace cakefactory.API.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;

        public SeedDb(DataContext context)
        {
            _context = context;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckProductsTypeAsync();
            await CheckDocumentTypesAsync();
            await CheckPersonalizationsAsync();
        }

        private async Task CheckPersonalizationsAsync()
        {
            if (!_context.DocumentTypes.Any())
            {
                _context.Personalizations.Add(new Personalization { PersoName = "Fotoponqué" });
                _context.Personalizations.Add(new Personalization { PersoName = "Torta en 3D" });
                _context.Personalizations.Add(new Personalization { PersoName = "Motivos Varios" });
                await _context.SaveChangesAsync();
            }
        }

        private async Task CheckDocumentTypesAsync()
        {
            if (!_context.DocumentTypes.Any())
            {
                _context.DocumentTypes.Add(new DocumentType { Description = "Cédula" });
                _context.DocumentTypes.Add(new DocumentType { Description = "Cédula de Extranjería" });
                _context.DocumentTypes.Add(new DocumentType { Description = "NIT" });
                _context.DocumentTypes.Add(new DocumentType { Description = "Pasaporte" });
                await _context.SaveChangesAsync();
            }
        }

        private async Task CheckProductsTypeAsync()
        {
            if (!_context.ProductTypes.Any())
            {
                _context.ProductTypes.Add(new ProductType { Description = "Tortas Tradicionales" });
                _context.ProductTypes.Add(new ProductType { Description = "Tortas Refrigeradas" });
                _context.ProductTypes.Add(new ProductType { Description = "Cupcakes" });
                await _context.SaveChangesAsync();
            }
        }
    }
   
}
