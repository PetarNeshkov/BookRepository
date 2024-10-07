using BookRepository.Api.Infrastructure.Extensions;
using OJS.Services.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddDatabase(builder.Configuration)
    .AddEndpointsApiExplorer()
    .AddApplicationServices()
    .AddValidators()
    .AddAutoMapperConfigurations<Program>()
    .AddSwaggerGen()
    .AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app
    .MigrateDatabase(builder.Configuration)
    .UseHttpsRedirection()
    .UseAnyCors()
    .UseRouting()
    .UseAutoMapper()
    .UseAuthorization();


app.MapControllers();

app.Run();
