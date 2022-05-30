using Microsoft.AspNetCore.Mvc;

namespace MyOnlineShop.Models.ViewModels.UI
{
    public class WebApiResult
    {
        public int Status { get; set; } = 200;
        public object? Data { get; set; }
        public string Message { get; set; } = "Success";

        public WebApiResult()
        {
        }
        public WebApiResult(object data)
        {
            Data = data;
        }

    }
}
