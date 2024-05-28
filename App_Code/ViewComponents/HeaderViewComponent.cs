using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.Web;
using UmbracoBlogFinal1.App_Code.Models.ViewComponentModels;

namespace UmbracoBlogFinal1.App_Code.ViewComponents
{
	[ViewComponent]
	public class HeaderViewComponent:ViewComponent
	{
        private readonly ILogger<HeaderViewComponent> logger;
		private readonly IUmbracoContextAccessor context;
		public HeaderViewComponent(ILogger<HeaderViewComponent>logger, IUmbracoContextAccessor context)
        {
            this.logger = logger;
			this.context = context;

		}
        public IViewComponentResult Invoke()
        {
			HeaderView headerView = new();
			try
            {
				var content = context?.GetRequiredUmbracoContext().PublishedRequest?.PublishedContent;
                if (content == null) return View(headerView);

				headerView.Title = content?.Value<string>("title");
				headerView.SubTitle = content?.Value<string>("subTitle");
				headerView.ImageUrl = content?.Value<IPublishedContent>("pageBanner")?.Url();

			}
            catch (Exception ex)
            {
				logger.LogError(ex, $"Error while processing {nameof(HeaderViewComponent)}");
			}
            return View(headerView);
        }

    }
}
