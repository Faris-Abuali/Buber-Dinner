using BuberDinner.Api;
// using BuberDinner.Api.Filters;
using BuberDinner.Application;
using BuberDinner.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// -- Add services to the container.
{
    builder.Services
        .AddPresentation()
        .AddApplication()
        .AddInfrastructure(builder.Configuration);
    
    // builder.Services.AddControllers(options => 
    //     options.Filters.Add<ErrorHandlingFilterAttribute>());
}

// // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
// builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();

var app = builder.Build();

// // Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
//     app.UseSwagger();
//     app.UseSwaggerUI();
// }


{
    // -- Request Pipeline - Middleware
    // app.UseMiddleware<ErrorHandlingMiddleware>();

    /***
     * UseExceptionHandler:
     * Adds a middleware to the pipeline that will
     * 1. catch exceptions,
     * 2. log them,
     * 3. reset the request path,
     * 4. and re-execute the request.
     *
     * The request will not be re-executed if the response has already started.
     */
    app.UseExceptionHandler("/error");
    
    // app.Map("/error", (HttpContext HttpContext) => 
    // {
    //     var exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;
    //     
    //     return Results.Problem();
    // });
    app.UseHttpsRedirection();

    // app.UseAuthorization();

    app.MapControllers();

    app.Run();
}