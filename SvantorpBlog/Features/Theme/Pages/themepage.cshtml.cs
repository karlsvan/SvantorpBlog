using EPiServer;
using EPiServer.Web.Mvc;
using SvantorpBlog.Features.Article.Models;
using SvantorpBlog.Features.Common.Models;
using SvantorpBlog.Features.Layout.Models;
using SvantorpBlog.Features.Theme.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SvantorpBlog.Features.Theme.Pages
{
    public class ThemepageModel : RazorPageModel<ThemePage>, ILayoutPage
    {
        public IContentLoader _loader { get; set; }

        [BindProperty(SupportsGet = true)]
        public List<ArticlePage> childPages { get; set; }
        public ThemepageModel(IContentLoader loader)
        {
            _loader = loader;
        }

        public void OnGet()
        {
            childPages = _loader.GetChildren<ArticlePage>(CurrentContent.ContentLink).ToList();
        }
    }
}
