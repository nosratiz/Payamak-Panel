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

    public class FaraApi
    {
        private readonly string _sendMessageApiPath = "https://rest.payamak-panel.com/api/SendSMS/SendSMS";

        private readonly string _deliveryStatusApiPath = "https://rest.payamak-panel.com/api/SendSMS/GetDeliveries2";

        private readonly string _getListOfMessageApiPath = "https://rest.payamak-panel.com/api/SendSMS/GetMessages";

        private readonly string _getCreditApiPath = "https://rest.payamak-panel.com/api/SendSMS/GetCredit";


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
                UserName = userName,
                Password = password,
                From = from,
                To = to,
                Text = text,
                IsFlash = false
            };

            string res = SendPostRequest(_sendMessageApiPath, JsonConvert.SerializeObject(sendMessage));

            return JsonConvert.DeserializeObject<Result>(res);
        }


        public Result GetMyCredit(string userName, string password)
        {
            Account account = new Account
            {
                UserName = userName,
                Password = password
            };
            string res = SendPostRequest(_getCreditApiPath, JsonConvert.SerializeObject(account));

            return JsonConvert.DeserializeObject<Result>(res);

        }

        public MessageList GetMyMessageList(string userName, string password, int type, int index, int count)
        {
            GetMessageListReq req = new GetMessageListReq
            {
                UserName = userName,
                Password = password,
                Location = type,
                Index = index,
                Count = count,

            };

            string res = SendPostRequest(_getListOfMessageApiPath, JsonConvert.SerializeObject(req));

            return JsonConvert.DeserializeObject<MessageList>(res);

        }

        public Result GetMessageStatus(string userName, string password, long recId)
        {
            DeliverRequest deliverRequest = new DeliverRequest
            {
                UserName = userName,
                Password = password,
                RecId = recId
            };

            string res = SendPostRequest(_deliveryStatusApiPath, JsonConvert.SerializeObject(deliverRequest));

            return JsonConvert.DeserializeObject<Result>(res);
        }













    }
}