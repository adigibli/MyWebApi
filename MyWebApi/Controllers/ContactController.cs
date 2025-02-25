﻿using Microsoft.AspNetCore.Mvc;
using MyWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private List<Contact> contacts = new List<Contact>{
            new Contact{ Id = 1, FirstName="Peter", LastName="Parker", NickName="Spiderman", Place="New York City" },
            new Contact{ Id = 2, FirstName="Tony", LastName="Stark", NickName="Ironman", Place="Long Island" }
            };

        // GET: api/<ContactController>
        [HttpGet]
        public ActionResult<IEnumerable<Contact>> Get()
        {
            return contacts;
        }

        // GET api/<ContactController>/5
        [HttpGet("{id}")]
        public ActionResult<Contact> Get(int id)
        {
            Contact contact = contacts.FirstOrDefault(c => c.Id == id);

            if(contact == null)
            {
                return NotFound(new { Messgae = "Contact has not been found." });
            }

            return Ok(contact);
        }

        // POST api/<ContactController>
        [HttpPost]
        public ActionResult<IEnumerable<Contact>> Post(Contact newContact)
        {
            contacts.Add(newContact);
            return Ok(contacts);
        }

        // PUT api/<ContactController>/5
        [HttpPut("{id}")]
        public ActionResult<IEnumerable<Contact>> Put(int id, Contact updatedContact)
        {
            Contact contact = contacts.FirstOrDefault(c => c.Id == id);

            if (contact == null)
            {
                return NotFound(new { Messgae = "Contact has not been found." });
            }

            contact.NickName = updatedContact.NickName;

            return Ok(contacts);
        }

        // DELETE api/<ContactController>/5
        [HttpDelete("{id}")]
        public ActionResult<IEnumerable<Contact>> Delete(int id)
        {
            Contact contact = contacts.FirstOrDefault(c => c.Id == id);

            if (contact == null)
            {
                return NotFound(new { Messgae = "Contact has not been found." });
            }

            contacts.Remove(contact);

            return Ok(contacts);
        }
    }
}
