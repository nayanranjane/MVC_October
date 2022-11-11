using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;


namespace MVC_App.CustomFilters
{
    public class AppExceptionAttribute : IExceptionFilter
    {


        private IModelMetadataProvider modelMetadataProvider;

        public AppExceptionAttribute(IModelMetadataProvider modelMetadataProvider)
        {
            this.modelMetadataProvider = modelMetadataProvider;
        }

        public void OnException(ExceptionContext context)
        {
            // Seting the exception handle as true to inform to the pipelin
            // fot the exception is handled

            context.ExceptionHandled = true;
            // Retrive the exception Message
            string errorMessage= context.Exception.Message;

            // Create the viewResult Instance
            ViewResult viewResult = new ViewResult();
            viewResult.ViewName = "Error";

            ViewDataDictionary viewData = new ViewDataDictionary(modelMetadataProvider, context.ModelState);

            viewData["Controller"] = context.RouteData.Values["controller"].ToString();
            viewData["Action"] = context.RouteData.Values["action"].ToString();
            viewData["ErrorMessage"] = errorMessage;


            viewResult.ViewData = viewData;
            context.Result = viewResult;


        }
    }
}
