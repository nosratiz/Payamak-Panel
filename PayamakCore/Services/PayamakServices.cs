using System;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PayamakCore.Dto;
using PayamakCore.Interface;

namespace PayamakCore.Services;

public class PayamakServices : IPayamakServices
{
    private readonly IHttpClientFactory _httpClientFactory;

    public PayamakServices(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }


    public async Task<ResultDto> SendSms(MessageDto sendMessage, CancellationToken cancellationToken = default)
        => await SendRequest<ResultDto>("SendSms", JsonConvert.SerializeObject(sendMessage), cancellationToken).ConfigureAwait(false);
    
    
    public async Task<ResultDto> GetMyCredit(AccountDto account, CancellationToken cancellationToken = default)
    => await SendRequest<ResultDto>("GetCredit", JsonConvert.SerializeObject(account), cancellationToken).ConfigureAwait(false);

    
    public async Task<MessageListDto> GetMyMessageList(MyMessageRequestDto req, CancellationToken cancellationToken = default)
    =>await SendRequest<MessageListDto>("GetMessages", JsonConvert.SerializeObject(req), cancellationToken)
        .ConfigureAwait(false);

    
    public async Task<ResultDto> GetMessageStatus(DeliverRequestDto deliverRequest, CancellationToken cancellationToken = default)
    => await SendRequest<ResultDto>("GetMessageStatus", JsonConvert.SerializeObject(deliverRequest), cancellationToken)
        .ConfigureAwait(false);
 
    
    public async Task<ResultDto> GetBasePrice(AccountDto account, CancellationToken cancellationToken = default)
    => await SendRequest<ResultDto>("GetBasePrice", JsonConvert.SerializeObject(account), cancellationToken)
        .ConfigureAwait(false);

    public async Task<GetUserNumberList> GetUserNumberList(AccountDto account, CancellationToken cancellationToken = default)
    => await SendRequest<GetUserNumberList>("GetUserNumbers", JsonConvert.SerializeObject(account), cancellationToken)
        .ConfigureAwait(false);

  
    public async Task<ResultDto> GetBaseService(BaseService baseService, CancellationToken cancellationToken = default)
    =>await SendRequest<ResultDto>("BaseServiceNumber", JsonConvert.SerializeObject(baseService), cancellationToken)
        .ConfigureAwait(false);

    private async Task<T> SendRequest<T>(string relativeUrl, string data, CancellationToken cancellationToken)
    {
        try
        {
            var client = _httpClientFactory.CreateClient("payamak");

            var request = new HttpRequestMessage(HttpMethod.Post, relativeUrl)
            {
                Content = new StringContent(data, Encoding.UTF8, "application/json")
            };

            var response = await client.SendAsync(request, cancellationToken).ConfigureAwait(false);

            var responseBody = await response.Content.ReadAsStringAsync().ConfigureAwait(false);


            return JsonConvert.DeserializeObject<T>(responseBody);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message, e);
        }
    }
}