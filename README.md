# payamak
payamak service use for send message

# Installation

First, you need to create an account at payamak-panel.com 

and after that, you can use this service for your app 

You can download the rest documentation [Here](http://payamak-panel.com/Files/webservice-rest.pdf)


```C#

Install-Package PayamakPanel.Core

```

 # Registration
 ``` C#
 
 builder.Services.AddPayamakService();
 
 ```

 # Usage
 
 For Send Sms 
 
``` C#

private readonly IPayamakServices _payamakServices;

public Controller(IPayamakServices payamakServices)
{
 _payamakServices = payamakServices;
}


public async Task sendmessage()
{
   var result=  await _payamakServices.SendSms(new MessageDto{
            From = "your line number",
            To = "you phone number",
            Text = "کد فعال سازی حساب کاربری شما برای عملیات تغییر یا فراموشی رمزعبور 82234 است.",
            username = "username",
            password = "password"
            ,IsFlash = false
        });
}



  
  ```
  
  # Result APi 
  
  this class Use For Get Result Of Api 
  
  ``` C#
     public class ResultDto
    {
        public string Value { get; set; }

        public int RetStatus { get; set; }

        public string StrRetStatus { get; set; }

    }
    
  ```
  
  
  # Major Changes 
  
  1-All methods support CancellationToken 
  
  2-Add Retry policy behind the scene
  
  3-Support asynchronous http call
  
  4-Improve performance
    
    
    

