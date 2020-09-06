using MessageAPI.Model;
using MessageAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace MessageAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly MessageContext _context;

        public MessageController(MessageContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Message>> Get()
        {
            return _context.Messages;
        }
    }
}
