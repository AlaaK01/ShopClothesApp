using Microsoft.Extensions.Options;
using Microsoft.Net.Http.Headers;
using ShopApp.shared.Services;


var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.Configure<MongoDbSettings>(builder.Configuration.GetSection(nameof(MongoDbSettings)));
builder.Services.AddSingleton<IMongoDbSettings>(sp => sp.GetRequiredService<IOptions<MongoDbSettings>>().Value);
builder.Services.AddScoped<IClothesServices, ClothesServices>();
builder.Services.AddScoped<IItemServices, ItemServices>();



// Add services to the container.


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


app.UseCors(Policy => Policy.WithOrigins("http://localhost:5119", "https://localhost:5119")
.AllowAnyMethod().WithHeaders(HeaderNames.ContentType)
);


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

