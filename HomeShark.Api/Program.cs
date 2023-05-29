using HomeShark.Api.Conventions;
using HomeShark.Core.Contracts.Services;
using HomeShark.Core.Dtos.MappingProfiles;
using HomeShark.Persistence;
using HomeShark.Services;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers(options => { options.Conventions.Add(new PluralizeControllerModelConvention()); });
builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddMvc().AddNewtonsoftJson(options => { options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore; });
builder.Services.AddDbContextPool<HomeSharkContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IAgentService, AgentService>();
builder.Services.AddAutoMapper(typeof(AddAgentRequestProfile), typeof(UpdateAgentRequestProfile));
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