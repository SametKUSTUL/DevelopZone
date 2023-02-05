using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Middlewares
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Middlewares", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            /*
             * Configure methodunda middlewareler �a��r�l�r.
             * Middleware lerin tetiklenme s�ralamas� �nemlidir.
             * Middleware ler Use anahtar kelimesi ile ba�lar.
             * 
             * ASP .Net frameworkunda 4 adet haz�r middleware vard�r.
             * 1- Run
             * Run kendinden sonra gelen middleware i tetiklemez ve pipeline burada kesilir. Bu i�leme short circuit denir.
             * 
             * 2- Use
             * Standart middleware kullan�m mekanizmas�d�r.
             * invoke ile bir sonraki middleware tetiklenmelidir. Tetiklenmezse �al��maz.
             * 
             * 3- Map
             * Middleware i talep g�nderen path'e g�re filtrelemek isteyebiliriz. Bu zamanlarda Map kullan�l�r.
             * 
             * 4- MapWhen 
             * Map methodunun geli�tirilmi�idir. Map ile sadece path e g�re filtreleme yap�l�rken MapWhen metodu ile requestin herhangi bir �zelli�ine g�re filtreleme yap�labilir.
             */
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Middlewares v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
