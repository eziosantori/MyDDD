using MediatR;
using MyDDD.Domain.Manutenzioni;
using MyDDD.Domain.Manutenzioni.Events;
using System.Threading;
using System.Threading.Tasks;

namespace MyDDD.Application.Macchine.ManutenzioneAssociata
{

  public class ManutenzioneAssociataDomainEvent: INotificationHandler<ManutenzioneAssociataEvent>
  {
    private readonly IManutenzioniRepository _paymentRepository;

    public ManutenzioneAssociataDomainEvent (IManutenzioniRepository paymentRepository)
    {
      _paymentRepository = paymentRepository;
    }

    public async Task Handle(ManutenzioneAssociataEvent notification, CancellationToken cancellationToken)
    {
      // todo, mandare email...
    }
  }
}
