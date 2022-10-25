using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using SvantorpBlog.Features.Theme.Models;
using System.ComponentModel.DataAnnotations;

namespace SvantorpBlog.Features.MainMenu.Models
{
    [ContentType(
        GUID = "B07C7E79-9EE9-487F-B416-7881345F51E6"
    )]
    public class MainMenuBlock : BlockData
    {
        [Display(
            GroupName = SystemTabNames.Content,
            Order = 100)]
        [CultureSpecific]
        [AllowedTypes(new[] { typeof(ThemePage) })]
        public virtual ContentArea Pages { get; set; }

        [ScaffoldColumn(false)]
        public virtual LinkItemCollection Links { get; set; }
    }
}
