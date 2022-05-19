using Microsoft.EntityFrameworkCore;
using Netpower.Intern2022.Responsitories;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddDbContext<MyDBContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("stringConection"))
);
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
