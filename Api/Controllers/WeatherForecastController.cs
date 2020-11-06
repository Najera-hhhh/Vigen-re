using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Api.Dtos;
using Api.Entities;
using AutoMapper;
using Encryp;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Pokecrypt.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [EnableCors("Testing")]
    public class WeatherForecastController : ControllerBase
    {


        private readonly IMapper _mapper;
        public WeatherForecastController(IMapper mapper)
        {
            this._mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get(int id)
        {
            Encryps encryps = new Encryps()
            {
                Text = id.ToString(),
                Encript = "",
                Lenguaje = "",
                Clave = ""
            };

            return Ok(encryps);
        }


        [HttpGet]
        public IActionResult EncryptGet([FromQuery] EncrypRequestDto request)
        {

            Encryps encryps = new Encryps()
            {
                Text = "0",
                Encript = "",
                Lenguaje = "",
                Clave = ""
            };

            return Ok(encryps);
        }

        [HttpPost]
        public IActionResult Post(EncrypRequestDto EncrypsDto)
        {
            Davici encrip = new Davici ();
            var final = _mapper.Map<EncrypRequestDto, Encryps>(EncrypsDto);
            final.Encript = encrip.TextEncrypt(EncrypsDto.Clave,EncrypsDto.Text);
            return Ok(final);
        }

        [HttpPost("/products3")]
        public IActionResult PostDescrypt(EncrypRequestDto EncrypsDto)
        {
            Davici encrip = new Davici ();
            var final = _mapper.Map<EncrypRequestDto, Encryps>(EncrypsDto);
            final.Encript = encrip.TextDecrypt(EncrypsDto.Clave,EncrypsDto.Text);
            return Ok(final);
        }

        private string GetItems(string filter)
        {
            var url = filter;
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "application/json";
            request.Accept = "application/json";

            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    using (Stream strReader = response.GetResponseStream())
                    {
                        if (strReader == null) return "error";
                        using (StreamReader objReader = new StreamReader(strReader))
                        {
                            string responseBody = objReader.ReadToEnd();
                            // Do something with responseBody
                            return responseBody;
                        }
                    }
                }
            }
            catch (WebException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return "error";
        }
    }
}
