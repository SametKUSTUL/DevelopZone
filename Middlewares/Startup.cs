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
             * Configure methodunda middlewareler çaðýrýlýr.
             * Middleware lerin tetiklenme sýralamasý önemlidir.
             * Middleware ler Use anahtar kelimesi ile baþlar.
             * 
             * ASP .Net frameworkunda 4 adet hazýr middleware vardýr.
             * 1- Run
             * Run kendinden sonra gelen middleware i tetiklemez ve pipeline burada kesilir. Bu iþleme short circuit denir.
             * 
             * 2- Use
             * Standart middleware kullaným mekanizmasýdýr.
             * invoke ile bir sonraki middleware tetiklenmelidir. Tetiklenmezse çalýþmaz.
             * 
             * 3- Map
             * Middleware i talep gönderen path'e göre filtrelemek isteyebiliriz. Bu zamanlarda Map kullanýlýr.
             * 
             * 4- MapWhen 
             * Map methodunun geliþtirilmiþidir. Map ile sadece path e göre filtreleme yapýlýrken MapWhen metodu ile requestin herhangi bir özelliðine göre filtreleme yapýlabilir.
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
