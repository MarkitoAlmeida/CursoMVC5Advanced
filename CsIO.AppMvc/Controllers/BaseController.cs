using CsIO.Business.Notifications;
using System.Web.Mvc;

namespace CsIO.AppMvc.Controllers
{
    public class BaseController : Controller
    {
        private readonly INotification _notification;

        public BaseController(INotification notification)
        {
            _notification = notification;
        }

        protected bool OperacaoValida()
        {
            if (!_notification.TemNotificacao())
                return true;

            var notificacoes = _notification.ObterNotificacoes();
            notificacoes.ForEach(c => ViewData.ModelState.AddModelError(string.Empty, c.Message));
            return false;
        }
    }
}