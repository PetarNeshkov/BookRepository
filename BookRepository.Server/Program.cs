using BookRepository.Api.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddDatabase(builder.Configuration)
    .AddEndpointsApiExplorer()
    .AddApplicationServices()
    .AddValidators()
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
    .UseAuthorization();


app.MapControllers();

app.Run();
