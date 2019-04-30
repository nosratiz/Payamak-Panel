# payamak
payamak Service use for Send Message

# Installation

First you need to create Account in payamak-panel.com 

and after that you Can Use this Servie for Your App 

You Can Download  Rest Documentation [Here](http://payamak-panel.com/Files/webservice-rest.pdf)

 # Usage
 
 For Send Sms 
 
``` C#

  FaraApi fara = new FaraApi();

 Result result = fara.SendSms("UserName","Password","From","TO","your Message");
  
  ```
  
  # Result APi 
  
  this class Use For Get Result Of Api 
  
  ``` C#
     public class Result
    {
        public string Value { get; set; }

        public int RetStatus { get; set; }

        public string StrRetStatus { get; set; }

    }
    
  ```
    
    
    
    
 # Message List    
 For Get List Of Message You Send Or Recived
    
  ``` C#
    
     MessageList messagelist = fara.GetMyMessageList("UserName", "Password",Type,index,Count);

                foreach (var item in messagelist.Data)
                {
                    Console.WriteLine($"{item.Body}{Environment.NewLine}");
                }              
   ```
   
  # Template Message 
  
  first you Need to Define Your Template Message In Farapayamak Panel after That You Can Use This Method for Send Template Message
  
  ``` C#
  
   Result result = fara.UseBaseService("userName", "Password", "name;lastname;1398/02/07", "to", bodyId);
  
  ```
