using System.Collections.Generic;

namespace CsIO.Business.Notifications
{
    public interface INotification
    {
        bool TemNotificacao();
        List<Notificacao> ObterNotificacoes();
        void Handle(Notificacao notificacao);
    }
}
