using BackendCalculationService.Services;
using BackendCalculationService.Notifications;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSignalR();
builder.Services.AddSingleton<WorkbookStorageService>();
builder.Services.AddSingleton<ExcelCalculationService>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseAuthorization();
app.MapControllers();
app.MapHub<CalculationHub>("/notifications");

app.Run();