using cakefactory.API.Data.Entities;
using cakefactory.API.Helpers;
using cakefactory.Common.Enums;
using System.Linq;
using System.Threading.Tasks;

namespace cakefactory.API.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;
        private readonly IUserHelper _userHelper;

        public SeedDb(DataContext context, IUserHelper userHelper)
        {
            _context = context;
            _userHelper = userHelper;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckProductsTypeAsync();
            await CheckDocumentTypesAsync();
            await CheckPersonalizationsAsync();
            await CheckRolesAsycn();
            await CheckUserAsync("32568974", "Diana", "Valencia", "diana@yopmail.com", "312 871 88 89", "Calle Falsa 123", UserType.Admin);
            await CheckUserAsync("43896523", "Bibiana", "Restrepo", "bibiana@yopmail.com", "318 123 56 89", "Carrera 74 # 89-74", UserType.User);
            await CheckUserAsync("98563124", "Andres", "Monsalve", "andres@yopmail.com", "317 856 23 14", "Calle 78 #45 14", UserType.User);
            await CheckUserAsync("78963587", "Diego", "Cañas", "diego@yopmail.com", "311 567 89 42", "Calle Falsa 123", UserType.User);
        }

        private async Task CheckUserAsync(string document, string firstName, string lastName, string email, string phoneNumber, string address, UserType userType)
        {
            User user = await _userHelper.GetUserAsync(email);
            if (user == null)
            {
                user = new User
                {
                    Address = address,
                    Document = document,
                    DocumentType = _context.DocumentTypes.FirstOrDefault(x => x.Description == "Cédula"),
                    Email = email,
                    FirstName = firstName,
                    LastName = lastName,
                    PhoneNumber = phoneNumber,
                    UserName = email,
                    UserType = userType
                };

                await _userHelper.AddUserAsync(user, "123456");
                await _userHelper.AddUserToRoleAsync(user, userType.ToString());
            }
        }

        private async Task CheckRolesAsycn()
        {
            await _userHelper.CheckRoleAsync(UserType.Admin.ToString());
            await _userHelper.CheckRoleAsync(UserType.User.ToString());
        }

        private async Task CheckPersonalizationsAsync()
        {
            if (!_context.Personalizations.Any())
            {
                _context.Personalizations.Add(new Personalization { Description = "Fotoponqué" });
                _context.Personalizations.Add(new Personalization { Description = "Torta en 3D" });
                _context.Personalizations.Add(new Personalization { Description = "Motivos Varios" });
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
