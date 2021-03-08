using System;
using Microsoft.AspNetCore.Mvc;


namespace PastelariaSMN.Controllers
{
    public class BaseController : ControllerBase
    {
        protected ObjectResult Error(Exception ex)
        {
            return StatusCode(500, "Internal Server Error");
        }
    }
}