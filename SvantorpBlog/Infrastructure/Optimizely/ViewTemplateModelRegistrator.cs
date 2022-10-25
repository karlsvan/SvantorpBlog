using EPiServer.DataAbstraction;
using EPiServer.Framework.Web;
using EPiServer.ServiceLocation;
using EPiServer.Web;
using EPiServer.Web.Mvc;
using SvantorpBlog.Features.Article.Models;
using SvantorpBlog.Features.Frontpage.Models;
using SvantorpBlog.Features.MainMenu.Models;
using SvantorpBlog.Features.Theme.Models;
using System;

namespace SvantorpBlog.Infrastructure.Optimizely
{
    [ServiceConfiguration(typeof(IViewTemplateModelRegistrator))]
    public class ViewTemplateModelRegistrator : IViewTemplateModelRegistrator
    {
        public static void OnTemplateResolved(object sender, TemplateResolverEventArgs args)
        {
        }

        public void Register(TemplateModelCollection viewTemplateModelRegistrator)
        {
            viewTemplateModelRegistrator.Add(typeof(ThemePage), new TemplateModel
            {
                Name = "ThemeMenuItem",
                AvailableWithoutTag = false,
                Path = $"~/Features/Theme/Pages/themeMenuItem.cshtml",
                Tags = new[] { GroupNames.Menu }
            });

            viewTemplateModelRegistrator.Add(typeof(ArticlePage), new TemplateModel
            {
                Name = "ArticleCard",
                AvailableWithoutTag = false,
                Path = $"~/Features/Article/Pages/articleCard.cshtml",
                Tags = new[] { GroupNames.Card }
            });
        }
    }
}
