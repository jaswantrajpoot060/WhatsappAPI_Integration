using WhatsappAPI_Integration.Models;
using WhatsappAPI_Integration.Services;

namespace WhatsappAPI_Integration
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var Configuration = builder.Configuration;
            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.Configure<WhatsAppApi>(Configuration.GetSection("WhatsAppApi"));
            builder.Services.Configure<TwilioSettings>(Configuration.GetSection("Twilio"));

            builder.Services.AddHttpClient<WhatsAppService>();
            builder.Services.AddScoped<TwilioWhatsAppService>();
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
}
