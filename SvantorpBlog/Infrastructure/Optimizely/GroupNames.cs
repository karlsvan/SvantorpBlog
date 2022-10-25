using EPiServer.DataAnnotations;
using System.ComponentModel.DataAnnotations;

namespace SvantorpBlog.Infrastructure.Optimizely
{

    [GroupDefinitions()]
    public static class GroupNames
    {
        [Display(Name = "Menu", Order = 35)]
        public const string Menu = "Menu";

        [Display(Name = "Card", Order = 40)]
        public const string Card = "Card";
    }
}
