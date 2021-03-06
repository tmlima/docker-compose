﻿using MessageAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace MessageAPI.Models
{
    public class MessageContext : DbContext
    {
        public MessageContext(DbContextOptions<MessageContext> options) : base(options)
        {

        }

        public DbSet<Message> Messages { get; set; }
    }
}
