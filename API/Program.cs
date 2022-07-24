using Autofac;
using AutoMapper;
using Autofac.Extensions.DependencyInjection;
using Business.AutoMapper;
using Business.DependencyResolvers.Autofac;
using Core.DependencyResolvers;
using Core.Extensions;
using Core.Utilities.IoC;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(builder => {
    builder.RegisterModule(new AutofacBusinessModule());
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(AuthProfile), typeof(CityProfile),
    typeof(CountryProfile), typeof(HotelImageProfile), typeof(HotelProfile),
    typeof(ReservationProfile), typeof(RoomImageProfile), typeof(RoomProfile), 
    typeof(UserProfile));

builder.Services.AddDependencyResolvers(new ICoreModule[] {
               new CoreModule() });

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(builder => builder.WithOrigins("http://localhost:4220").AllowAnyHeader());

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();