using CommonFiles;
using Microsoft.EntityFrameworkCore;
using Order.Data.Context;
using Order.Data.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<OrderDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DBConnection")));

// Add services to the container.


// it will handle your dependency scope
builder.Services.RegisterServices(typeof(UserService).Assembly.FullName);



//Register Automapper profiles
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
//swagger service
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();


var deployDatabaseChanges= app.Configuration.GetValue<bool>("DisployDatabaseChanges");
if (deployDatabaseChanges)
{
    MigrationManager.UpdateDatabase<OrderDBContext>(app);
}

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
