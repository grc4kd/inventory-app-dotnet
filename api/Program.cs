using api;

var AllowSpecificOrigins = "_AllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// create a named policy to allow requests from 4200 to api
// TODO: add port for angular to config
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: AllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("https://localhost");
                      });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// use interface / DI for ...

// we all make mistakes, it is part of what makes us human
// TODO: find a better opportunity for DI
//builder.Services.AddScoped<IInventory, Inventory>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(AllowSpecificOrigins);

app.UseAuthorization();

// set specific ports for this API
app.Urls.Add("http://localhost:4300"); 
app.Urls.Add("https://localhost:4301");

app.MapControllers();

app.Run();
