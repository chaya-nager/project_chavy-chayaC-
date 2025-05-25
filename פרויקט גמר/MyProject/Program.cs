using Common.Dto;
using Repository.Entities;
using Repository.Interfaces;
using Repository.Repositories;
using Service.Interfaces;
using Service.Services;
using Mock;
using Microsoft.AspNetCore.Http.Features;
internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        //הגדרת התלויות
        builder.Services.AddScoped<IService<WorkoutVideoDto>, WorkoutVideoService>();
        builder.Services.AddScoped<IRepository<WorkoutVideo>, WorkoutVideoRepository>();
        builder.Services.AddScoped<IService<UserWorkoutPlanDto>, UserWorkoutPlanService>();
        builder.Services.AddScoped<IRepository<UserWorkoutPlan>, UserWorkoutPlanRepository>();
        builder.Services.AddScoped<IService<UserDto>, UserService>();
        builder.Services.AddScoped<IRepository<User>, UserRepository>();
        builder.Services.AddDbContext<IContext, Database>();
        builder.Services.AddAutoMapper(typeof(MyMapper));
        //thissssss
        builder.Services.AddDbContext<IContext, Database>();

        //builder.Services.Configure<FormOptions>(options =>
        //{
        //    options.MultipartBodyLengthLimit = 100_000_000; // 100MB
        //});
        //builder.WebHost.ConfigureKestrel(serverOptions =>
        //{
        //    serverOptions.Limits.MaxRequestBodySize = 50 * 1024 * 1024; // 50 MB
        //});
        builder.WebHost.ConfigureKestrel(serverOptions =>
        {
            serverOptions.Limits.MaxRequestBodySize = 100L * 1024 * 1024 * 1024; // למשל 1GB
        });
        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}