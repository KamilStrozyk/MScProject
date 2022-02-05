using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MScProject.Database.Repositories;
using MScProject.Database.Repositories.Interfaces;
using MScProject.Services.Services;
using MScProject.Services.Services.Interfaces;

namespace MScProject.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args)
                .Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((_, services) =>
                        services.AddScoped<IPhotoService, PhotoService>()
                            .AddScoped<ITaskService, TaskService>()
                            .AddScoped<ITaskListService, TaskListService>()
                            .AddScoped<ITaskListRepository,TaskListRepository>()
                            .AddScoped<ITaskRepository,TaskRepository>()
                            .AddScoped<IPhotoRepository,PhotoRepository>())
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }
}