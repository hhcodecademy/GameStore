using GameStore.DAL.Data;
using GameStore.DAL.Models;

namespace GameStore.UI.Extentions
{
    public static class IdentityExtention
    {
        public static void AddIdentityExt(this IServiceCollection services) {


            services.AddIdentity<AppUser, AppRole>(opts =>
            {

                opts.Password.RequireDigit = true;
                opts.Password.RequireLowercase = false;
                opts.Password.RequireNonAlphanumeric = false;
                opts.Password.RequireUppercase = false;
                opts.Password.RequiredLength = 6;

                opts.User.AllowedUserNameCharacters = "bcdefghijklmnopqrstuvwxyz";


            }).AddEntityFrameworkStores<GameDbContext>();
        }
    }
}
