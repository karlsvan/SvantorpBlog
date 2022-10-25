using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;

namespace OtherProject.Infrastructure.Display
{
    public class FeatureViewLocationExpander : IViewLocationExpander
    {
        private readonly string FeatureFolderName = "Features";
        private readonly string ShareFolderName = "Shared";

        public IEnumerable<string> ExpandViewLocations(ViewLocationExpanderContext context,
            IEnumerable<string> viewLocations)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (viewLocations == null)
            {
                throw new ArgumentNullException(nameof(viewLocations));
            }

            var paths = new List<string>();

            if (context.ViewName.StartsWith("DisplayTemplates")) {
                paths.Add("/Features/Shared/{0}.cshtml");
            }

            string viewName = context.ViewName;

            if(context.ActionContext is ControllerContext controllerContext 
                && controllerContext.ActionDescriptor.ControllerName != null
                && !viewName.Contains("/"))
            {
                viewName = controllerContext.ActionDescriptor.ControllerTypeInfo.Name + "/" + viewName;
            }

            if(context.ActionContext is ViewContext viewContext)
            {
                paths.AddRange(GetViewPaths(viewName, viewContext.ExecutingFilePath));
            } else
            {
                paths.AddRange(GetViewPaths(viewName));
            }

            return viewLocations.Union(paths);

        }

        private IEnumerable<string> GetViewPaths(string viewName, string callerPath = null)
        {

            var modelName = GetModelName(viewName);

            var modelTypes = Assembly.GetExecutingAssembly()
                    .GetTypes()
                    .Where(type => type.IsClass && type.Name.Equals(modelName) && type.Namespace.Contains(FeatureFolderName))
                    .ToList();

            var featureNames = modelTypes
                .Select(m => m.Namespace
                    .Split(".")
                    .Last())
                .ToList();

            var viewTypes = GetFeatureViewTypes(featureNames);

            if (!viewTypes.Any())
            {
                viewTypes = GetSharedViewTypes(viewName);
            }

            IEnumerable<string> viewPaths;


            if (viewTypes.Count() > 1)
            {
                var specificView = viewName.Split("/").Last();

                var commonPath = viewTypes
                    .Select(viewType => "/" + string.Join("/", viewType.Name.Split("_").SkipLast(1)) + "/")
                    .First();

                viewPaths = new List<string> {
                    commonPath+modelName+".cshtml",
                    commonPath+featureNames.First()+".cshtml",
                    commonPath+specificView+".cshtml"
                };

                viewPaths = viewPaths.Concat(viewTypes
                    .Where(v => v.Name.EndsWith(specificView))
                    .Select(v => "/"+string.Join("/", v.Name.Split("_")) + ".cshtml"))
                    .Reverse(); //Reverse to prioritize most specific views
                

            } else
            {
                viewPaths = viewTypes
                    .Select(viewType => "/" + string.Join("/", viewType.Name.Split("_")) + ".cshtml");
            }

            if (callerPath != null) //add path of view that invoked this view
            {
                var localPath = string.Join("/", callerPath.Split("/").SkipLast(1)) + "/" + viewName + ".cshtml";
                viewPaths = viewPaths.Append(localPath);
            }

            return viewPaths;
        }

        private string GetModelName(string viewName)
        {
            var splitView = viewName.Split("/");
            if (splitView.Length > 1)
            {
                return splitView[^2];
            } else if (splitView.Length == 1)
            {
                return viewName;
            }
            return viewName;
        }

        private IEnumerable<Type> GetSharedViewTypes(string viewName)
        {
            var sharedViewTypes = Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(type => type.Name.StartsWith(FeatureFolderName+"_"+ShareFolderName) && typeof(RazorPage).IsAssignableFrom(type));
            var sharedView = sharedViewTypes
                .Where(type => type.Name.ToLower().EndsWith(viewName.ToLower()))
                .ToList();
            return sharedView;
        }

        private IEnumerable<Type> GetFeatureViewTypes(IEnumerable<string> featureNames)
        {
            return Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(type => type.Name.StartsWith(FeatureFolderName) && typeof(RazorPage).IsAssignableFrom(type))
                .Where(type =>
                {
                    var feature = type.Name.Split("_")[1];
                    return featureNames.Any(f => string.Equals(f, feature));
                })
                .ToList();

        }
    }
}