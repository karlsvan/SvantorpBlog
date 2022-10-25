using EPiServer;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SvantorpBlog.Features.Common.Models;
using SvantorpBlog.Features.Frontpage.Models;
using SvantorpBlog.Features.Layout.Models;
using System;

namespace SvantorpBlog.Features.Frontpage.Pages
{
    public class FrontpageModel : RazorPageModel<FrontPage>, ILayoutPage
    {
        public IContentLoader _loader { get; set; }
        public FrontpageModel(IContentLoader loader)
        {
            _loader = loader;
        }

        public PageResult OnGet()
        {
            return Page();
        }
    }
}
