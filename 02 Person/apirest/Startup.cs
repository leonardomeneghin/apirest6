using apirest.Services;
using apirest.Services.Implementations;

namespace apirest
{
    public class Startup
    {
        public Startup(IConfiguration configuration) 
        {
            /*Construtor
             * Seta a interface Configuration
             * Recebendo o configuration injetado dentro do construtor, já que na IConfiguration
             * O método é apenas GET
             */
            Configuration = configuration; 
            
        }
        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services) 
        {
            services.AddControllers();
            /*Injeção de dependência do serviço*/
            services.AddScoped<IPersonService, PersonServiceImplementation>();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
        }
        public void Configure(WebApplication app, IWebHostEnvironment enviroment) 
        {
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();
        }
    }
}
