using System.Collections.Generic;
using System.Linq;

namespace CsIO.Business.Notifications
{
    public class Notification : INotification
    {
        private List<Notificacao> _notificacoes;

        public Notification()
        {
            _notificacoes = new List<Notificacao>();
        }

        public void Handle(Notificacao notificacao)
        {
            _notificacoes.Add(notificacao);
        }

        public List<Notificacao> ObterNotificacoes()
        {
            return _notificacoes;
        }

        public bool TemNotificacao()
        {
            return _notificacoes.Any();
        }
    }
}
