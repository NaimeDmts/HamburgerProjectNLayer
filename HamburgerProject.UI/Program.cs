using HamburgerProject.BLL.Abstractions;
using HamburgerProject.BLL.Concrete;
using HamburgerProject.DATA.Concrete;
using HamburgerProject.UI.AutoMapper;
using HamburgerProjet.DAL.Abstractions;
using HamburgerProjet.DAL.Concrete;
using HamburgerProjet.DAL.Contexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace HamburgerProject.UI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            //"Data Source=DESKTOP-EI4I1FN\\MSSQLSERVER2019;User ID=sa;Password=1702;Database=HamburgerDB;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False"
            var conn = builder.Configuration.GetConnectionString("DefaultConnectionEv");
            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(conn);
        
                options.UseLazyLoadingProxies();

            });
            builder.Services.AddIdentity<AppUser,AppRole>(options =>
            {
                //Password
                options.Password.RequireDigit = false;//En az bir rakam
                options.Password.RequiredLength = 3;//Minimum uzunluk
                options.Password.RequireLowercase = false;//en az bir küçük harf
                options.Password.RequireUppercase = false;//en az bir büyük
                options.Password.RequireNonAlphanumeric = false;//en az bir sembol

                //User
                options.User.RequireUniqueEmail = true;//Eposta adresi benzersiz olmalý.
                options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";

                //SignIn
                options.SignIn.RequireConfirmedEmail = false;//Eposta onayý gerekli olsun mu
                options.SignIn.RequireConfirmedPhoneNumber = false;//Telefon onayý
                options.SignIn.RequireConfirmedAccount = false;
            }).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders().AddRoles<AppRole>();

            builder.Services.AddScoped<ISiparisRepo, SiparisRepo>();
            builder.Services.AddTransient<IBaseRepo<Menu>, MenuRepo>();
            builder.Services.AddTransient<ISiparisMalzemeRepo, SiparisMalzemeRepo>();
            builder.Services.AddScoped<IEkstraMalzemeRepo, EkstraMalzemeRepo>();

            builder.Services.AddScoped<ISiparisService, SiparisService>();
            builder.Services.AddTransient<IMenuService, MenuService>();
            builder.Services.AddScoped<IEkstraMalzemeService, EkstraMalzemeService>();
            builder.Services.AddTransient<IUserService, UserService>();


            // builder.Services.AddAutoMapper(typeof(Mapping));
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}