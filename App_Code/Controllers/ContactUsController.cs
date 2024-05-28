using Microsoft.AspNetCore.Mvc;
using Serilog.Context;
using Umbraco.Cms.Persistence.EFCore.Scoping;
using Umbraco.Cms.Web.Common.Controllers;
using UmbracoBlogFinal1.App_Code.CustomDBContexts;
using UmbracoBlogFinal1.App_Code.Models.CustomEntities.ContactUs;



namespace UmbracoBlogFinal1.App_Code.Controllers
{
    public class ContactUsController : UmbracoApiController
    {
        private readonly IEFCoreScopeProvider<CustomDBContext> _efCoreScopeProvider;
        public ContactUsController(IEFCoreScopeProvider<CustomDBContext> efCoreScopeProvider)
        => _efCoreScopeProvider = efCoreScopeProvider;
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            using IEfCoreScope<CustomDBContext> scope = _efCoreScopeProvider.CreateScope();
            IEnumerable<ContactUs> feedback = await scope.ExecuteWithContextAsync(async db => db.ContactUs.ToArray());
            scope.Complete();
            return Ok(feedback);
        }
        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            using IEfCoreScope<CustomDBContext> scope = _efCoreScopeProvider.CreateScope();
            ContactUs?feedbacks=await scope.ExecuteWithContextAsync(async db=> db.ContactUs.FirstOrDefault(x=>x.Id==id));
            scope.Complete();

            return Ok(feedbacks);
        }
        [HttpPost]
        public async Task Insert(ContactUs feedback)
        {
            using IEfCoreScope<CustomDBContext> scope = _efCoreScopeProvider.CreateScope();
            await scope.ExecuteWithContextAsync<Task>(async db =>
            {
                db.ContactUs.Add(feedback);
                await db.SaveChangesAsync();
            });
            scope.Complete();
        }
    }
}
