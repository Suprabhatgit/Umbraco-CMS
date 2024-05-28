using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Web.Common;
using Umbraco.Cms.Web.Common.PublishedModels;
using UmbracoBlogFinal1.App_Code.Models.ViewComponentModels;

namespace UmbracoBlogFinal1.App_Code.ViewComponents
{
    [ViewComponent]
    public class FooterViewComponent: ViewComponent
    {
        private readonly ILogger<FooterViewComponent> logger;
        private readonly UmbracoHelper umbracoHelper;

        public FooterViewComponent(ILogger<FooterViewComponent> logger, UmbracoHelper umbracoHelper)
        {

            this.logger = logger;
            this.umbracoHelper = umbracoHelper;

        }
        public IViewComponentResult Invoke()
        {
            FooterView footerView = new();
            try
            {
                var homePage = umbracoHelper?.ContentAtRoot()?.FirstOrDefault(x => x.IsDocumentType("home") && x.IsVisible()) as Home;
                if (homePage == null) return View(footerView);
                
                foreach(var item in homePage.FooterLinks)
                {
                    footerView.FooterLinks.Add(
                        new FooterLink
                        {
                            Name = item.Name,
                            Url = item.Url,
                            Target=item.Target,
                        });
                }



            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error while processing {nameof(NavBarViewComponent)}");
            }
            return View(footerView);
        }

    }
}
