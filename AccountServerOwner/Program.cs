using AccountServerOwner.Extension;
using Microsoft.AspNetCore.HttpOverrides;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.ConfigureCors();
builder.Services.ConfigureIISIntegration();

builder.Services.ConfigureLoggerService(); //logging services

builder.Services.ConfigureMySqlContext(builder.Configuration); // mysql services from extenstion

builder.Services.ConfigureRepositoryWrapper(); // repository wrapper service that will do the sql query 

builder.Services.AddAutoMapper(typeof(Program));// automapper to map dto to the 

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Logging.AddLog4Net("C:\\Users\\imper\\source\\repos\\AccountServerOwner\\AccountServerOwner\\log4net.config");

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}
if (app.Environment.IsDevelopment())//why no braces at the first time in codemaze????????
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseHsts();
}

app.UseStaticFiles();

app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.All
});

app.UseCors("CorsPolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
