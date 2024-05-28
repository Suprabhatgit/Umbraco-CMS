using Microsoft.CodeAnalysis.CSharp.Syntax;
using Umbraco.Cms.Core.Notifications;
using UmbracoBlogFinal1.App_Code.Notifications;

namespace UmbracoBlogFinal1.App_Code.Composers
{
    public static partial class UmbracoBuilder
    {
        public static IUmbracoBuilder AddCustomNotificationServices(this IUmbracoBuilder builder)
        {
            builder.AddNotificationAsyncHandler<UmbracoApplicationStartedNotification, RunCustomDBContextMigrationNotification>();
            return builder;


        }
    }
}
