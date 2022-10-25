using EPiServer;
using EPiServer.Web.Mvc;
using SvantorpBlog.Features.Article.Models;
using SvantorpBlog.Features.Common.Models;
using SvantorpBlog.Features.Layout.Models;

namespace SvantorpBlog.Features.Article.Pages
{
    public class ArticlepageModel : RazorPageModel<ArticlePage>, ILayoutPage
    {
        public IContentLoader _loader { get; set; }
        public ArticlepageModel(IContentLoader loader)
        {
            _loader = loader;
        }

        public void OnGet()
        {
        }
    }
}
