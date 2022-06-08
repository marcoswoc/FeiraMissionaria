using FeiraMissionaria.WebApi.Core.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddFeiraMissionariaDbContext(builder.Configuration);
builder.Services.AddFeiraMissionariaIdentity();
builder.Services.AddFeiraMissionariaAuthentication(builder.Configuration);
builder.Services.AddFeiraMissionariaSwagger();
builder.Services.AddFeiraMissionariaRepositories();
builder.Services.AddFeiraMissionariaAutomapper();
builder.Services.AddFeiraMissionariaApplications();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
