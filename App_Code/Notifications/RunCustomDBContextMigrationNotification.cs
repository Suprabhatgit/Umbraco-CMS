using Microsoft.EntityFrameworkCore;
using Serilog.Context;
using Umbraco.Cms.Core.Events;
using Umbraco.Cms.Core.Notifications;
using UmbracoBlogFinal1.App_Code.CustomDBContexts;

namespace UmbracoBlogFinal1.App_Code.Notifications
{
    public class RunCustomDBContextMigrationNotification : INotificationAsyncHandler<UmbracoApplicationStartedNotification>
    {
        private readonly CustomDBContext _customDBContexts;

        public RunCustomDBContextMigrationNotification(CustomDBContext _customDBContexts)
        {
            _customDBContexts = _customDBContexts;
        }

        public async Task HandleAsync(UmbracoApplicationStartedNotification notification, CancellationToken cancellationToken)
        {
            try
            {
                IEnumerable<string> pendingMigrations = _customDBContexts.Database.GetPendingMigrations();

                if (pendingMigrations.Any())
                {
                    _customDBContexts.Database.Migrate();
                }
            } catch (Exception ex)
             
            {
                throw;
                

            }
        }
    }
}
