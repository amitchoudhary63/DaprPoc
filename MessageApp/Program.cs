
using MessageApp.Core;
using MessageApp.Infrastructure;
using MessageApp.Manager;
using Microsoft.AspNetCore.Mvc;

namespace MessageApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDaprClient();
            // Add services to the container.
            builder.Services.AddAuthorization();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped<IMessageManager, MessageManager>();
            builder.Services.AddScoped<IMessageRepository, MessageRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment() || app.Environment.IsProduction()) // IsProduction set true for testing purpose
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapGet("/message", async ([FromServices] IMessageManager messageManager, string messageId) =>
            {
                var result = await messageManager.GetMessageByMessageId(messageId);
                return Results.Ok(result);
            })
      .WithName("GetMessage").WithOpenApi();

            app.MapPost("/message", async ([FromServices] IMessageManager messageManager, MessageModel messageModel) =>
            {
                var result = await messageManager.AddMessage(messageModel);
                return Results.Created($"/message/{messageModel.MessageId}", messageModel);
            })
            .WithName("PostMessage")
            .WithOpenApi();

            app.Run();
        }
    }
}