using EPiServer;
using EPiServer.Core;
using EPiServer.Web.Mvc;
using Microsoft.AspNetCore.Mvc;
using SvantorpBlog.Features.Frontpage.Models;
using SvantorpBlog.Features.MainMenu.Models;
using SvantorpBlog.Features.Layout.Models;


namespace SvantorpBlog.Features.Common.Pages
{
    public class SitePageModel<T> : RazorPageModel<T> where T : PageData
    {
        private IContentLoader _loader;
        public SitePageModel(
            IContentLoader loader)
        {
            _loader = loader;
            Layout = new();
            Layout.Menu = _loader.Get<FrontPage>(ContentReference.StartPage).Menu;
        }

        [BindProperty(SupportsGet = true)]
        public LayoutModel Layout { get; set; }
    }
}
