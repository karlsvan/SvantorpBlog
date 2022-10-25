using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Web;
using SvantorpBlog.Features.Common.Models;
using SvantorpBlog.Infrastructure.Optimizely;
using System.ComponentModel.DataAnnotations;

namespace SvantorpBlog.Features.Theme.Models
{
    [ContentType(
        GUID = "020B698E-C250-4E95-B8DC-B656979ECD85"
    )]
    public class ThemePage : SitePage
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
            GroupName = GroupNames.Menu,
            Order = 100)]
        [CultureSpecific]
        public virtual ContentReference Icon { get; set; }
    }
}
