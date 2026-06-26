using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Order.Data.Context;
using Order.Data.Interfaces;
using Order.Domain.Entites;
using Order.Dto.DTO.Request;
using Order.Dto.DTO.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Data.Services
{

    //encapsulation
    public class UserService : IUserInterface
    {

        private readonly OrderDBContext _context;

        private readonly IMapper _mapper;

        // what is the constructor?
        //constuctor is the special member function that is automatically called when an object of a class is created.
        public UserService(OrderDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<UserResponse> Create(UserRequest userRequest)
        {
            if(userRequest == null)
            {
                return null;
            }
            var user = _mapper.Map<User>(userRequest);
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return _mapper.Map<UserResponse>(user);
        }

        public async Task<bool> Delete(int id)
        {
            if (id == 0)
            {
                return false; 
            
            }
            var user= await _context.Users.FindAsync(id);
            if (user == null)
            {return false;
            }   
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<UserResponse>> GetAll()
        {
            var user = await _context.Users
                .AsNoTracking()
                .OrderByDescending(u=>u.Id)
                .ToListAsync();
            return _mapper.Map<IEnumerable<UserResponse>>(user);
        }

        public async Task<UserResponse> GetById(int id)
        {
            var user= await _context.Users.AsNoTracking().FirstOrDefaultAsync(u=>u.Id==id);

            if(user== null)
            {
                return null;
            }
            return _mapper.Map<UserResponse>(user);
        }

        public async Task<UserResponse> Update(int id, UserRequest userRequest)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return null;
            }
            _mapper.Map(userRequest, user);
            await _context.SaveChangesAsync();
            return _mapper.Map<UserResponse>(user);
        }
    }
}
