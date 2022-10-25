using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Web;
using SvantorpBlog.Features.Common.Models;
using System.ComponentModel.DataAnnotations;

namespace SvantorpBlog.Features.Article.Models
{
    [ContentType(
        GUID = "ACDA4103-D02B-4EB3-87AF-D4504287E567"
    )]
    public class ArticlePage : SitePage
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


    }
}
