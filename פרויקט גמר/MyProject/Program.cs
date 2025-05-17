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
        builder.Services.AddScoped<IService<Common.Dto.WorkoutVideoDto>, WorkoutVideoService>();
        builder.Services.AddScoped<IRepository<Repository.Entities.WorkoutVideo>, WorkoutVideoRepository>();
        builder.Services.AddAutoMapper(typeof(MyMapper));
        //thissssss
        builder.Services.AddDbContext<IContext, Database>();

        builder.Services.Configure<FormOptions>(options =>
        {
            options.MultipartBodyLengthLimit = 100_000_000; // 100MB
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