using Microsoft.AspNetCore.Mvc;
using Nop.Core;
using Nop.Plugin.Payments.DosQuincenas.Models;
using Nop.Services.Localization;
using Nop.Web.Framework.Components;

namespace Nop.Plugin.Payments.DosQuincenas.Components
{
    [ViewComponent(Name = "DosQuincenas")]
    public class DosQuincenasViewComponent : NopViewComponent
    {
        private readonly DosQuincenasPaymentSettings _dosQuincenasPaymentSettings;
        private readonly ILocalizationService _localizationService;
        private readonly IStoreContext _storeContext;
        private readonly IWorkContext _workContext;

        public DosQuincenasViewComponent(DosQuincenasPaymentSettings dosQuincenasPaymentSettings,
            ILocalizationService localizationService,
            IStoreContext storeContext,
            IWorkContext workContext)
        {
            _dosQuincenasPaymentSettings = dosQuincenasPaymentSettings;
            _localizationService = localizationService;
            _storeContext = storeContext;
            _workContext = workContext;
        }

        public IViewComponentResult Invoke()
        {
            var model = new PaymentInfoModel
            {
                DescriptionText = _localizationService.GetLocalizedSetting(_dosQuincenasPaymentSettings,
                    x => x.DescriptionText, _workContext.WorkingLanguage.Id, _storeContext.CurrentStore.Id)
            };

            return View("~/Plugins/Payments.DosQuincenas/Views/PaymentInfo.cshtml", model);
        }
    }
}