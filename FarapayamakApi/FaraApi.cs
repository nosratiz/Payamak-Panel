using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Web;
using FarapayamakApi.Models;
using Newtonsoft.Json;

namespace FarapayamakApi
{
    public class MessageList
    {
        public Result MyBase { get; set; }

        public List<MessageResult> Data { get; set; }
    }

    public class GetUserNumberList
    {
        public Result MyBase { get; set; }

        public List<UserNumber> Data { get; set; }
    }

    public class FaraApi
    {
        private readonly string _baseApi = "https://rest.payamak-panel.com/api/SendSMS/";

        private static string GetApiPath(string baseApi, string relativePath)
        {
            return $"{baseApi}{relativePath}";
        }

        private static string SendPostRequest(string address, string data)
        {
            try
            {
                using (WebClient client = new WebClient())
                {
                    client.Headers[HttpRequestHeader.ContentType] = "application/json";
                    client.Headers[HttpRequestHeader.Accept] = "application/json";

                    byte[] result = client.UploadData(address, "POST", Encoding.UTF8.GetBytes(data));
                    return Encoding.UTF8.GetString(result);
                }
            }
            catch (Exception ex)
            {
                throw new HttpException(ex.Message);
            }

        }

        public Result SendSms(string userName, string password, string from, string to, string text)
        {
            SendMessage sendMessage = new SendMessage
            {
                username = userName,
                password = password,
                From = from,
                To = to,
                Text = text,
                IsFlash = false
            };

            string res = SendPostRequest(GetApiPath(_baseApi, "SendSMS"), JsonConvert.SerializeObject(sendMessage));

            return JsonConvert.DeserializeObject<Result>(res);
        }

        public Result GetMyCredit(string userName, string password)
        {
            Account account = new Account
            {
                username = userName,
                password = password
            };
            string res = SendPostRequest(GetApiPath(_baseApi, "GetCredit"), JsonConvert.SerializeObject(account));

            return JsonConvert.DeserializeObject<Result>(res);

        }

        public MessageList GetMyMessageList(string userName, string password, int type, int index, int count)
        {
            GetMessageListReq req = new GetMessageListReq
            {
                username = userName,
                password = password,
                location = type,
                index = index,
                count = count,
                from = String.Empty

            };

            string res = SendPostRequest(GetApiPath(_baseApi, "GetMessages"), JsonConvert.SerializeObject(req));

            return JsonConvert.DeserializeObject<MessageList>(res);

        }

        public Result GetMessageStatus(string userName, string password, long recId)
        {
            DeliverRequest deliverRequest = new DeliverRequest
            {
                username = userName,
                password = password,
                RecId = recId
            };

            string res = SendPostRequest(GetApiPath(_baseApi, "GetDeliveries2"), JsonConvert.SerializeObject(deliverRequest));

            return JsonConvert.DeserializeObject<Result>(res);
        }

        public Result GetBasePrice(string userName, string password)
        {
            Account account = new Account { username = userName, password = password };

            string res = SendPostRequest(GetApiPath(_baseApi, "GetBasePrice"), JsonConvert.SerializeObject(account));

            return JsonConvert.DeserializeObject<Result>(res);
        }

        public GetUserNumberList GetUserNumberList(string userName, string password)
        {
            Account account = new Account { username = userName, password = password };

            string res = SendPostRequest(GetApiPath(_baseApi, "GetUserNumbers"), JsonConvert.SerializeObject(account));

            return JsonConvert.DeserializeObject<GetUserNumberList>(res);
        }

        public Result UseBaseService(string userName, string password, string text, string to, int bodyId)
        {
            BaseService baseService = new BaseService
            {
                username = userName,
                password = password,
                text = text,
                to = to,
                bodyId = bodyId
            };
            string res = SendPostRequest(GetApiPath(_baseApi, "BaseServiceNumber"), JsonConvert.SerializeObject(baseService));

            return JsonConvert.DeserializeObject<Result>(res);
        }


    }
}