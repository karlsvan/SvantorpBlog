using EPiServer;
using SvantorpBlog.Features.Frontpage.Models;
using SvantorpBlog.Features.Layout.Models;

namespace SvantorpBlog.Features.Common.Models
{
    public interface ILayoutPage
    {
        IContentLoader _loader { get; set; }
        LayoutModel GetLayout()
        {
            var layout = new LayoutModel();
            layout.Menu = _loader.Get<FrontPage>(EPiServer.Core.ContentReference.StartPage).Menu;

            return layout;
        }
    }
}
