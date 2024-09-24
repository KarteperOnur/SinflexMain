using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Sinflex.DAL.Context;
using Sinflex.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sinflex.IOC.DependencyResolvers
{
    public static class IdentityService
    {
        public static IServiceCollection AddIdentityService(this IServiceCollection services)
        {
            services.AddIdentity<AppUser, AppUserRole>()
                    .AddEntityFrameworkStores<SinflexContext>()
                    .AddDefaultTokenProviders();//todo: Token oluşturmak için bu sağlayıcıya ihtiyaıcımız bulunmaktadır.

            services.Configure<IdentityOptions>(x =>
            {
                x.Password.RequireDigit = true; //en az 1 rakam zorunluluğu
                x.Password.RequireNonAlphanumeric = true;//en az 1 sayı ve numara hariç karakter zorunluluğu
                x.Password.RequireUppercase = true;//en az 1 büyük harf zorunluluğu  
                x.Password.RequireLowercase = true;//en az 1 küçük harf zorunluluğu 
                x.Password.RequiredLength = 8; //Minimum şifre uzunluğu
            });

            services.ConfigureApplicationCookie(cookie =>
            {
                cookie.LoginPath = new PathString("/Security/Login");
                cookie.AccessDeniedPath = new PathString("/Security/Denied");
                cookie.Cookie = new CookieBuilder { Name = "SinflexCookie" };
                cookie.SlidingExpiration = true;
                cookie.ExpireTimeSpan = TimeSpan.FromHours(1);
            });

            return services;
        }
    }
}
