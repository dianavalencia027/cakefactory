using cakefactory.API.Data.Entities;
using cakefactory.API.Models;
using System;
using System.Threading.Tasks;

namespace cakefactory.API.Helpers
{
    public interface IConverterHelper
    {
        Task<User> ToUserAsync(UserViewModel model, Guid imageId, bool isNew);

        UserViewModel ToUserViewModel(User user);
    }
}
