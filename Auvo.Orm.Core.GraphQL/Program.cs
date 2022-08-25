using Auvo.Orm.Core.GraphQL.WebApi.GraphqlCore;
using Auvo.Orm.Core.GraphQL.WebApi.Infrastructure.DBContext;
using Auvo.Orm.Core.GraphQL.WebApi.Infrastructure.ITechEventRepository;
using GraphQL;
using GraphQL.MicrosoftDI;
using GraphQL.Types;
using Microsoft.EntityFrameworkCore;
using System.Web.Http.Dependencies;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();

builder.Services.AddScoped<ISchema, TechEventSchema>();

//builder.Services.AddSingleton<ISchema, TechEventSchema>(services => new TechEventSchema(new SelfActivatingServiceProvider(services)));


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<TechEventDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("GraphQLDBConnection")));


//builder.Services.AddTransient<ITechEventRepository, TechEventRepository>();

builder.Services.AddTransient<ITechEventRepository, TechEventRepository>();



builder.Services.AddScoped<IDocumentExecuter, DocumentExecuter>();

builder.Services.AddScoped<TechEventInfoType>();
builder.Services.AddScoped<ParticipantType>();
builder.Services.AddScoped<TechEventQuery>();
builder.Services.AddScoped<TechEventInputType>();
builder.Services.AddScoped<TechEventMutation>();






var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// make sure all our schemas registered to route
//app.UseGraphQL<ISchema>();

app.Run();
