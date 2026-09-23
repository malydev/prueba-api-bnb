using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace ApiPruebaBnb.Api;

public class ApiPrefixDocumentFilter : IDocumentFilter
{
    public void Apply(OpenApiDocument document, DocumentFilterContext context)
    {
        var paths = new OpenApiPaths();
        foreach (var (path, item) in document.Paths)
            paths.Add($"/api{path}", item);

        document.Paths = paths;
    }
}
