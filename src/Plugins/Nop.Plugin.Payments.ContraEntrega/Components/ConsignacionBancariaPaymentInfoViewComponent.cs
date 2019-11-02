using Microsoft.AspNetCore.Mvc;
using Nop.Core;
using Nop.Plugin.Payments.ContraEntrega.Models;
using Nop.Plugin.Payments.ContraEntrega;
using Nop.Services.Localization;
using Nop.Web.Framework.Components;

namespace Nop.Plugin.Payments.ContraEntrega.Components
{
    [ViewComponent(Name = "ContraEntrega")]
    public class ContraEntregaViewComponent : NopViewComponent
    {
        private readonly ContraEntregaPaymentSettings _ContraEntregaPaymentSettings;
        private readonly ILocalizationService _localizationService;
        private readonly IStoreContext _storeContext;
        private readonly IWorkContext _workContext;

        public ContraEntregaViewComponent(ContraEntregaPaymentSettings ContraEntregaPaymentSettings,
            ILocalizationService localizationService,
            IStoreContext storeContext,
            IWorkContext workContext)
        {
            _ContraEntregaPaymentSettings = ContraEntregaPaymentSettings;
            _localizationService = localizationService;
            _storeContext = storeContext;
            _workContext = workContext;
        }

        public IViewComponentResult Invoke()
        {
            var model = new PaymentInfoModel
            {
                DescriptionText = _localizationService.GetLocalizedSetting(_ContraEntregaPaymentSettings,
                    x => x.DescriptionText, _workContext.WorkingLanguage.Id, _storeContext.CurrentStore.Id)
            };

            return View("~/Plugins/Payments.ContraEntrega/Views/PaymentInfo.cshtml", model);
        }
    }
}