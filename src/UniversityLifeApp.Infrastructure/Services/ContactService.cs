using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniveristyLifeApp.Models.v1.Cities.UpdateCity;
using UniveristyLifeApp.Models.v1.Contact.AddContact;
using UniveristyLifeApp.Models.v1.Contact.DeleteContact;
using UniveristyLifeApp.Models.v1.Contact.GetContact;
using UniversityLifeApp.Application.Core;
using UniversityLifeApp.Application.CQRS.v1.Contact.Commands.CreateContact;
using UniversityLifeApp.Application.Interfaces;
using UniversityLifeApp.Domain.Entities;
using UniversityLifeApp.Domain.Enums;
using UniversityLifeApp.Infrastructure.Data;

namespace UniversityLifeApp.Infrastructure.Services
{
    public class ContactService : IContactService
    {
        private readonly ApplicationContext _context;

        public ContactService(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<ApiResult<CreateContactResponse>> CreateContact(CreateContactCommand request)
        {
            Contact contact = new Contact()
            {
                FullName = request.Request.FullName,
                Email = request.Request.Email,
                Country = request.Request.Country,
                Comment = request.Request.Comment,
                Phone = request.Request.Phone,
                ContactStatusId = (int)ContactStatusEnum.Active
            };
            await _context.Contacts.AddAsync(contact);
            await _context.SaveChangesAsync();
            var response = new CreateContactResponse()
            {
                Phone = contact.Phone,
                Comment = contact.Comment,
                Country = contact.Country,
                Email = contact.Email,
                FullName = contact.FullName,
            };
            return ApiResult<CreateContactResponse>.OK(response);
        }

        public async Task<ApiResult<DeleteContactResponse>> DeleteContact(int contactId)
        {
            var contact = await _context.Contacts.Where(x => x.Id == contactId).FirstOrDefaultAsync();
            contact.ContactStatusId = (int)ContactStatusEnum.DeActive;
            await _context.SaveChangesAsync();
            var response = new DeleteContactResponse()
            {
                Id = contact.Id,
            };
            return ApiResult<DeleteContactResponse>.OK(response);

        }

        public async Task<ApiResult<List<GetContactResponse>>> GetContact()
        {
            var contact = await _context.Contacts.Where(x => x.ContactStatusId == 10).Select(x => new GetContactResponse
            {
                Comment = x.Comment,
                Email = x.Email,
                Country = x.Country,
                FullName = x.FullName,
                Phone = x.Phone,
                CreateAt = x.CreateAt,
                UpdateAt = x.UpdateAt,
                ContactId = x.Id
                
            }).ToListAsync();
            
        return ApiResult<List<GetContactResponse>>.OK(contact);
        }
    }
}
