using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using TemalabBackEnd.Models.EntityFrameworkModel.DbModels;
using TemalabBackEnd.Models.EntityFrameworkModel.EntityModels;

namespace BackendAPI
{
    public class Program
    {
        //Adatb�zis l�trehoz�sa
        private static void CreateDbIfNotExists(IHost host)
        {
            var services = host.Services;
            try
            {
                var scope = services.CreateScope();
                var context = scope.ServiceProvider.GetRequiredService<DatabaseContext>();
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
                DbInit.Init(context, userManager);
            }
            catch (Exception ex)
            {
                var logger = services.GetRequiredService<ILogger<Program>>();
                logger.LogError(ex, "An error occurred creating the DB.");
            }
        }

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            //Controllerek hozz�ad�sa
            builder.Services.AddControllers();
            //DbContext hozz�ad�sa
            builder.Services.AddDbContext<DatabaseContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            
            builder.Services.AddAuthorization();
            //Identity api h�v�sok
            builder.Services.AddIdentityApiEndpoints<User>()
                .AddEntityFrameworkStores<DatabaseContext>();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigins", builder => builder.AllowAnyOrigin());
            });

            //Elvileg ezzel m�k�dnie k�ne annak, hogy bizonyos api h�v�sokat csak
            //Bel�pve lehet megcsin�lni. ez viszont nem m�k�dik.
            builder.Services.AddSwaggerGen(options =>
                {
                    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                    {
                        In = ParameterLocation.Header,
                        Name = "Authorization",
                        Type = SecuritySchemeType.ApiKey
                    });
                    options.OperationFilter<SecurityRequirementsOperationFilter>();
                });

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            
            var app = builder.Build();

            app.UseDeveloperExceptionPage();
            app.UseRouting();

            app.MapControllers();
            app.MapIdentityApi<User>();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            //app.UseHttpsRedirection();

            app.UseCors("AllowAllOrigins");

            app.UseAuthorization();

            //Adatb�zis l�trehoz�sa
            CreateDbIfNotExists(app);

            app.Run();
        }
    }
}
