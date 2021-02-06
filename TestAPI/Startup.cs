using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace TestAPI {

  public class Startup {

    public void ConfigureServices(IServiceCollection services) {
      services.AddMvc(options => options.EnableEndpointRouting = false);
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
      if (env.IsDevelopment()) {
        app.UseDeveloperExceptionPage();
      }
      else {
        app.UseExceptionHandler();
      }

      app.UseStatusCodePages();
      app.UseCors(builder => {
        builder.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();
      });
      app.UseMvc();
    }
  }
}