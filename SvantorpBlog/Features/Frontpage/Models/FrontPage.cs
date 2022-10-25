using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Web;
using SvantorpBlog.Features.Common.Models;
using SvantorpBlog.Features.MainMenu.Models;
using SvantorpBlog.Infrastructure.Optimizely;
using System.ComponentModel.DataAnnotations;

namespace SvantorpBlog.Features.Frontpage.Models
{
    [ContentType(
        GUID = "A3A79B9D-2551-4A28-8365-D91E902D283E"
    )]
    public class FrontPage : SitePage
    {
        [Display(
        GroupName = SystemTabNames.Content,
        Order = 1)]
        [CultureSpecific]
        public virtual string Title { get; set; }

        [Display(
            GroupName = SystemTabNames.Content,
            Order = 10)]
        [CultureSpecific]
        [UIHint(UIHint.Image)]
        public virtual ContentReference MainImage { get; set; }

        [Display(
            GroupName = SystemTabNames.Content,
            Order = 100)]
        [CultureSpecific]
        public virtual XhtmlString MainBody { get; set; }

        [Display(
            GroupName = SystemTabNames.Content,
            Order = 200)]
        [CultureSpecific]
        public virtual ContentArea MainArea { get; set; }

        [Display(
            GroupName = GroupNames.Menu,
            Order = 100)]
        public virtual MainMenuBlock Menu { get; set; }
    }
}
