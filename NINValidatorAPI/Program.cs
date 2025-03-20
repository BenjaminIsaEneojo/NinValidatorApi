using NINValidatorAPI.Repositories;
using NINValidatorAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Services
builder.Services.AddSingleton<NinInfoService>();
builder.Services.AddSingleton<INinInfoRepository, InMemoryNinInfoRepository>();
builder.Services.AddSingleton<INinInfoService, NinInfoService>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
