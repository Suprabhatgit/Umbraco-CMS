﻿using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Web.Common;
using Umbraco.Cms.Web.Common.PublishedModels;
using UmbracoBlogFinal1.App_Code.Models.ViewComponentModels;

namespace UmbracoBlogFinal1.App_Code.ViewComponents
{
    public class NavBarViewComponent: ViewComponent
    {
        private readonly ILogger<NavBarViewComponent> logger;
        private readonly UmbracoHelper umbracoHelper;

        public NavBarViewComponent(ILogger<NavBarViewComponent> logger, UmbracoHelper umbracoHelper)
        {
            this.logger = logger;
            this.umbracoHelper = umbracoHelper;
        }
        public IViewComponentResult Invoke()
        {
            NavbarView navbarView = new();
            try
            {
                var homePage = umbracoHelper?.ContentAtRoot()?.FirstOrDefault(x => x.IsDocumentType("home") && x.IsVisible()) as Home;
                if (homePage == null) return View(navbarView);

                navbarView.SiteName = homePage?.SiteName;
                navbarView.LogoUrl = homePage?.Logo?.Url();
                foreach (var item in homePage.Children)
                {
                    if (item?.Value<bool>("displayOnNavbar") ?? false)
                    {
                        navbarView.NavbarChildren.Add(
                            new NavbarChild
                            {
                                Name = item.Name,
                                Url = item?.Url()
                            }

                            );
                    }
                }

            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error while processing {nameof(NavBarViewComponent)}");
            }
            return View(navbarView);
        }
    }
}
