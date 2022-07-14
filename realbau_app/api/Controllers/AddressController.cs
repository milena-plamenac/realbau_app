using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using realbau_app.api.Models;
using realbau_app.api.Repositories.Interfaces;
using System.Net;
using System.Net.Mail;

namespace realbau_app.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private IAddressRepository addressRepository;

        public AddressController(IAddressRepository addressRepository)
        {
            this.addressRepository = addressRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<AddressDetails>> GetAddresses()
        {
            return await this.addressRepository.GetAddresses();
        }

        [HttpGet("{id}")]
        public async Task<AddressDetails> GetAddress(int id)
        {
            return await this.addressRepository.GetAddressById(id);
        }


        [HttpGet("{city}/{tzip}/{street}/{housenumber}/{subnumber}/{unit}")]
        public async Task<AddressDetails> GetAddress(string city, string tzip, string street, int housenumber, string subnumber, int unit)
        {
            return await this.addressRepository.GetAddressByInfo(city, tzip, street, housenumber, subnumber, unit);
        }

        [HttpPost]
        public async Task<AddressDB> Insert([FromBody] AddressDB address)
        {
            return await this.addressRepository.Insert(address);
        }


        [HttpGet("{city}/{tzip}/{street}/{housenumber}/{subnumber}/{unit}/{newrnc}")]
        public async Task<int> CheckRnc(string city, string tzip, string street, int housenumber, string subnumber, int unit, int newrnc)
        {
            return await this.addressRepository.CheckAddressRnc(city, tzip, street, housenumber, subnumber, unit, newrnc);
        }

        //[HttpPost]
        //public async Task<int> SendMail([FromBody] EmailData emailData)
        //{
        //    try
        //    {
        //        MailMessage message = new MailMessage();
        //        SmtpClient smtp = new SmtpClient();
        //        message.From = new MailAddress("");
        //        message.To.Add(new MailAddress("ToMailAddress"));
        //        message.Subject = "Test";
        //        message.IsBodyHtml = true; //to make message body as html  
        //        message.Body = "Hello";
        //        smtp.Port = 587;
        //        smtp.Host = "smtp.gmail.com"; //for gmail host  
        //        smtp.EnableSsl = true;
        //        smtp.UseDefaultCredentials = false;
        //        smtp.Credentials = new NetworkCredential("FromMailAddress", "password");
        //        smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
        //        smtp.Send(message);

        //        return 1;
        //    }
        //    catch (Exception) {
        //        return 0;

        //    }
        //}

    }
}
