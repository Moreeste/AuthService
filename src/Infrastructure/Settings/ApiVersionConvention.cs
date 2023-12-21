using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace Infrastructure.Settings
{
    public class ApiVersionConvention : IControllerModelConvention
    {
        public void Apply(ControllerModel controller)
        {
            var namespaceController = controller.ControllerType.Namespace;
            var apiVersion = namespaceController?.Split('.').Last().ToLower();
            controller.ApiExplorer.GroupName = apiVersion;
        }
    }
}
