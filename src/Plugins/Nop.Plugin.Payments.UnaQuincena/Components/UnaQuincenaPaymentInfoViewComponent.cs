using Microsoft.AspNetCore.Mvc;
using Nop.Core;
using Nop.Plugin.Payments.UnaQuincena.Models;
using Nop.Services.Localization;
using Nop.Web.Framework.Components;

namespace Nop.Plugin.Payments.UnaQuincena.Components
{
    [ViewComponent(Name = "UnaQuincena")]
    public class UnaQuincenaViewComponent : NopViewComponent
    {
        private readonly UnaQuincenaPaymentSettings _unaQuincenaPaymentSettings;
        private readonly ILocalizationService _localizationService;
        private readonly IStoreContext _storeContext;
        private readonly IWorkContext _workContext;

        public UnaQuincenaViewComponent(UnaQuincenaPaymentSettings unaQuincenaPaymentSettings,
            ILocalizationService localizationService,
            IStoreContext storeContext,
            IWorkContext workContext)
        {
            _unaQuincenaPaymentSettings = unaQuincenaPaymentSettings;
            _localizationService = localizationService;
            _storeContext = storeContext;
            _workContext = workContext;
        }

        public IViewComponentResult Invoke()
        {
            var model = new PaymentInfoModel
            {
                DescriptionText = _localizationService.GetLocalizedSetting(_unaQuincenaPaymentSettings,
                    x => x.DescriptionText, _workContext.WorkingLanguage.Id, _storeContext.CurrentStore.Id)
            };

            return View("~/Plugins/Payments.UnaQuincena/Views/PaymentInfo.cshtml", model);
        }
    }
}