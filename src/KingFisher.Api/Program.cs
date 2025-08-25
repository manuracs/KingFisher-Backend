using Asp.Versioning;
using Asp.Versioning.ApiExplorer;
using FluentValidation;
using FluentValidation.AspNetCore;
using KingFisher.Api;
using KingFisher.Api.Extensions;
using KingFisher.Application.Handlers.Common.Responses;
using KingFisher.ServiceRegistrations;

var builder = ApiApplicationBuilderExtensions.CreateWebApplicationBuilder(args);


var presentationAssembly = typeof(WeatherForecast).Assembly;

builder.Services.AddControllers()
	.AddApplicationPart(presentationAssembly);

builder.Services.AddHealthChecks()
	.AddSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")!);

builder.Services.ConfigureServices(builder.Configuration);
builder.Services.AddDbContextServices(builder.Configuration);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
	options.CustomSchemaIds(type => type.FullName);
});
builder.Services.ConfigureOptions<ConfigureSwaggerOptions>();

builder.Services.AddApiVersioning(options =>
{
	options.DefaultApiVersion = new ApiVersion(1);
	options.AssumeDefaultVersionWhenUnspecified = true;
	options.ReportApiVersions = true;
	options.ApiVersionReader = new UrlSegmentApiVersionReader();
})
.AddMvc()
.AddApiExplorer(options =>
{
	options.GroupNameFormat = "'v'VVV";
	options.SubstituteApiVersionInUrl = true;
});

builder.Services.AddValidatorsFromAssemblyContaining<BaseResponse>();
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	var provider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();

	app.UseSwagger();
	app.UseSwaggerUI(options =>
	{
		for (int index = 0; index < provider.ApiVersionDescriptions.Count; index++)
		{
			ApiVersionDescription? description = provider.ApiVersionDescriptions[index];
			options.SwaggerEndpoint(
				$"/swagger/{description.GroupName}/swagger.json",
				description.GroupName.ToUpperInvariant());
		}
	});
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

await app.MigrateSQLServerDbContextAsync(builder.Environment).ConfigureAwait(false);

await app.RunAsync().ConfigureAwait(false);
