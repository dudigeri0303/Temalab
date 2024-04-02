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
        //Adatbázis létrehozása
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
            
            builder.Services.AddCors();
            builder.Services.AddAuthorization();

            builder.Services.AddControllers();
            //DbContext hozzáadása
            builder.Services.AddDbContext<DatabaseContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            //Identity api hívások
            builder.Services.AddIdentityApiEndpoints<User>()
                .AddEntityFrameworkStores<DatabaseContext>();

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
             
            var app = builder.Build();

            //Local host portját lehet hogy át kell írni, ha nem ott fut a kliens
            app.UseCors(x => x
                .AllowAnyHeader()
                .AllowAnyMethod()
                .WithOrigins("http://localhost:5173"));
            
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
            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            //Adatbázis létrehozása
            CreateDbIfNotExists(app);

            app.Run();
        }
    }
}
