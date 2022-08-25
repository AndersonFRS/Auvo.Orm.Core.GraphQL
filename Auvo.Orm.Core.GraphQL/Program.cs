using Auvo.Orm.Core.GraphQL.WebApi.Infrastructure.DBContext;
using Auvo.Orm.Core.GraphQL.WebApi.Infrastructure.ITechEventRepository;
using GraphQL;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<TechEventDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("GraphQLDBConnection")));

builder.Services.AddTransient<ITechEventRepository, TechEventRepository>();

builder.Services.AddSingleton<IDocumentExecuter, DocumentExecuter>();

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
