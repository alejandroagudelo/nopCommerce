using Microsoft.AspNetCore.Mvc;
using Nop.Core;
using Nop.Plugin.Payments.ConsignacionBancaria.Models;
using Nop.Services.Localization;
using Nop.Web.Framework.Components;

namespace Nop.Plugin.Payments.ConsignacionBancaria.Components
{
    [ViewComponent(Name = "ConsignacionBancaria")]
    public class ConsignacionBancariaViewComponent : NopViewComponent
    {
        private readonly ConsignacionBancariaPaymentSettings _consignacionBancariaPaymentSettings;
        private readonly ILocalizationService _localizationService;
        private readonly IStoreContext _storeContext;
        private readonly IWorkContext _workContext;

        public ConsignacionBancariaViewComponent(ConsignacionBancariaPaymentSettings consignacionBancariaPaymentSettings,
            ILocalizationService localizationService,
            IStoreContext storeContext,
            IWorkContext workContext)
        {
            _consignacionBancariaPaymentSettings = consignacionBancariaPaymentSettings;
            _localizationService = localizationService;
            _storeContext = storeContext;
            _workContext = workContext;
        }

        public IViewComponentResult Invoke()
        {
            var model = new PaymentInfoModel
            {
                DescriptionText = _localizationService.GetLocalizedSetting(_consignacionBancariaPaymentSettings,
                    x => x.DescriptionText, _workContext.WorkingLanguage.Id, _storeContext.CurrentStore.Id)
            };

            return View("~/Plugins/Payments.ConsignacionBancaria/Views/PaymentInfo.cshtml", model);
        }
    }
}