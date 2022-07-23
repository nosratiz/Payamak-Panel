using System.Threading;
using System.Threading.Tasks;
using PayamakCore.Dto;

namespace PayamakCore.Interface;

public interface IPayamakServices
{
    Task<ResultDto> SendSms(MessageDto sendMessage, CancellationToken cancellationToken = default);
    Task<ResultDto> GetMyCredit(AccountDto account,CancellationToken cancellationToken = default);
    Task<MessageListDto> GetMyMessageList(MyMessageRequestDto req,CancellationToken cancellationToken = default);
    
    Task<ResultDto> GetMessageStatus(DeliverRequestDto deliverRequest,CancellationToken cancellationToken = default);

    Task<ResultDto> GetBasePrice(AccountDto account,CancellationToken cancellationToken = default);
    
    Task<GetUserNumberList> GetUserNumberList(AccountDto account,CancellationToken cancellationToken = default);

    Task<ResultDto> GetBaseService(BaseService baseService,CancellationToken cancellationToken = default);

}

