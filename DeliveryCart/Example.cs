using System;
using System.Threading.Tasks;
using DeliveryCart.Models;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace DeliveryCart
{
    internal class Example
    {
        private static void Main()
        {
            Execute().Wait();
        }

        static async Task Execute()
        {
            var apiKey = System.Environment.GetEnvironmentVariable("SENDGRID_APIKEY");
            var client = new SendGridClient(apiKey);
            var msg = new SendGridMessage()
            {
                From = new EmailAddress("sethu55sri@gmail.com", "DX Team"),
                Subject = "Order Details",
                PlainTextContent = "Order Placed Successfully!",
                HtmlContent = "<strong>Hello, Email!</strong>"
            };
            msg.AddTo(new EmailAddress(Deliverymodel., "Test User"));
            var response = await client.SendEmailAsync(msg);
        }
    }
}