using coreapp3.DbMigration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using MediatR;
using coreapp3.Handlers;

var builder = WebApplication.CreateBuilder(args);

// Configuration and Connection String
var optionBuilder = new DbContextOptionsBuilder();

var connectionString = builder.Configuration.GetSection("app_db");
optionBuilder.UseSqlServer(connectionString.Value);

// Add services to the container.
builder.Services.AddDbContext<AuthContext>(x => x.UseSqlServer(connectionString.Value));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(typeof(CreateUserCommandHandler));
builder.Services.AddMediatR(typeof(GetUserQueryHandler));

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
