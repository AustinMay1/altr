using altr_server.data;
using altr_server.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<DbCtx>(options => options
.UseNpgsql(builder.Configuration.GetConnectionString("AltrDB"))
.EnableDetailedErrors()
);

builder.Services.AddScoped<IUserRepo, UserRepo>();
builder.Services.AddScoped<ICommunityRepo, CommunityRepo>();
builder.Services.AddScoped<IPostRepo, PostRepo>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
