using API_schedule.Filters;
using API_schedule.DAO;
using API_schedule.DAO.Impl;
using API_schedule.DAO.Config;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services
    .AddControllers(options => {
        options.Filters.Add(typeof(CustomExceptionFilterAttribute));
    })
    .AddNewtonsoftJson(options => {
        options.UseMemberCasing();
    });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors((setup) => {
    setup.AddPolicy("default", (options) =>
    {
        options.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin();
    });
});

builder.Services.AddSingleton<DBRepository>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddSingleton<IScheduleRepository, ScheduleRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("default");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
