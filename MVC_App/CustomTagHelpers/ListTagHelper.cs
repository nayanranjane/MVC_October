using Microsoft.AspNetCore.Razor.TagHelpers;
using Coditas.Ecomm.Entities;
using Coditas.Ecomm.DataAccess.Models;
using System.Reflection;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace MVC_App.CustomTagHelpers
{
    public class ListGenerator: TagHelper
    {
        public IEnumerable<Category> Categories { get; set; }

        public IEnumerable<Object> objects { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "List";
            // Start and End Tag
            // <list-generator></list-generator>
            output.TagMode = TagMode.StartTagAndEndTag;
            //  List<string> columnNames = new List<string>();
            PropertyInfo[] myPropertyInfo;
            var table = "<table class='table table-bordered table-striped table-dark'>";
            foreach (var item in objects)
            {
          
                var type = item.GetType();
                table += "<tr>";
                myPropertyInfo = type.GetProperties();
                foreach(var pi in myPropertyInfo)
                {
                    table += $"<td>{pi.GetValue(item)}</td>";
                    
                }
                table += "/<tr>";
            }

        

            table += "</table>";


            output.PreContent.SetHtmlContent(table);
        }
    }
}
