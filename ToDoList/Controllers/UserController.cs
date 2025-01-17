﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.DTO.UserDTO;
using Repository.UserRepository;

namespace ToDoList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        //User Controller
        private readonly IUserRepository _UserRepo;
        public UserController(IUserRepository UserRepo)
        {
            _UserRepo=UserRepo; 
        }
        //Get All Uers data 
        [HttpGet]
        [Route("GetAllUsers")]
        public async Task<List<UserDTOALL>> GetAllUsers()
        {
            try
            {
               var user=await  _UserRepo.GetAllUsers();
                return user;

            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        // Get By ID User
        [HttpGet]
        [Route("GetByID")]
        public async Task<List<GetByIDDTO>>GetByID(int id)
        {
            try
            {
                var user = await _UserRepo.GetUserBYId(id);
                return user;

            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        //Update User 
        [HttpPut]
        [Route("UpdateUser")]
        public async Task<IActionResult>UpdateUser(UpdateUerDTO user)
        {
            if(ModelState.IsValid)
            {
               await _UserRepo.UpdateUser(user);
                return Ok();
            }
            else { return BadRequest(); }   
        }

        //Delete User
        [HttpDelete]
        [Route("DeleteUser")]
        public async Task<IActionResult>DeleteUser(int id)
        {
            try
            {
               await _UserRepo.DeleteUser(id);
                return Ok();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        
        //ADD User
        [HttpPost]
        [Route("AddUserDTO")]
        public async Task<IActionResult>AddUser(AddUserDTO user)
        {
            if(ModelState.IsValid)
            {
               await _UserRepo.AddUser(user);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpGet]
        [Route("GetAllTaskByID")]
        public async Task<List<UserTaskDTO>>GetAllTaskByID(int id)
        {
            try
            {
                var result=await _UserRepo.GetAllTaskByID(id);

                return result;

            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
