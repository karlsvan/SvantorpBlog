using EPiServer.Web.Mvc;
using Microsoft.AspNetCore.Mvc;
using SvantorpBlog.Features.MainMenu.Models;

namespace SvantorpBlog.Features.MainMenu.Components
{
    public class MainMenuComponent : BlockComponent<MainMenuBlock>
    {
        protected override IViewComponentResult InvokeComponent(MainMenuBlock currentContent)
        {
            return View("/Features/MainMenu/Components/MainMenu.cshtml", currentContent);
        }
    }
}
