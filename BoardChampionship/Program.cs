using BoardChampionship;
using BoardChampionship.BLL.Services.GameService;
using BoardChampionship.BLL.Services.PlayerService;
using BoardChampionship.BLL.Services.TeamService;
using BoardChampionship.BLL.Services.WinnerService;
using BoardChampionship.DAL;
using BoardChampionship.DAL.Entities;
using BoardChampionship.DAL.Repositories.GameRepository;
using BoardChampionship.DAL.Repositories.PlayerRepository;
using BoardChampionship.DAL.Repositories.TeamRepository;
using BoardChampionship.DAL.Repositories.WinnerRepostory;
using Microsoft.EntityFrameworkCore;
using System;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllersWithViews();
        var connectionString = builder.Configuration.GetConnectionString("SQLLocalConnection");
        builder.Services.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlServer(connectionString);
            options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

        });
        builder.Services.AddScoped<IBaseRepository<Player>, PlayerRepository>();
        builder.Services.AddScoped<ITeamRepository, TeamRepository>();
        builder.Services.AddScoped<IGameRepository, GameRepository>();
        builder.Services.AddScoped<WinnerRepository, WinnerRepository>();
        builder.Services.AddScoped<IPlayerService, PlayerService>();
        builder.Services.AddScoped<ITeamService, TeamService>();
        builder.Services.AddScoped<IGameService, GameService>();
        builder.Services.AddScoped<IWinnerService, WinnerService>();
        builder.Services.AddAutoMapper(typeof(MapperProfile));

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

        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}