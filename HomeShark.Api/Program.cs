using HomeShark.Core.Contracts.Repositories;
using HomeShark.Core.Contracts.UnitOfWorks;
using HomeShark.Core.Models;
using HomeShark.Persistence;
using HomeShark.Persistence.Repositories;
using HomeShark.Persistence.UnitOfWorks;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddScoped<IRepository<Agent>, AgentRepository>();
builder.Services.AddScoped<IAgentUow, AgentUow>();
builder.Services.AddDbContextPool<HomeSharkContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();