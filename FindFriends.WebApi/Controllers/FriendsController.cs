using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using FindFriends.Application.Interfaces;
using FindFriends.Domain.Entities;

namespace FindFriends.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class FriendsController : Controller
    {
        private readonly IFriendAppService _friendApp;        

        public FriendsController(IFriendAppService friendApp)
        {
            _friendApp = friendApp;            
        }

        [Route("Add")]
        [HttpPost]
        [Authorize]
        public IActionResult Add([FromBody] Friend friend)
        {
            try
            {
                _friendApp.Add_CheckingDuplicatesLatitudeLongitude(friend);                
                return Ok(friend);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("GetById/{id?}")]
        [Authorize]
        public IActionResult GetById(int id)
        {
            var friend = _friendApp.GetById(id);
            if (friend == null)
            {
                return NotFound("Id not found");
            }
            return Ok(friend);
        }

        [Route("GetAll")]  
        [Authorize]
        public IActionResult GetAll()
        {
            var friendsList = _friendApp.GetAll();
            if (friendsList == null)
            {
                return NotFound("Not found");
            }
            return Ok(friendsList);
        }


        [Route("Update")]
        [HttpPut]
        [Authorize]
        public IActionResult Update([FromBody] Friend friend)
        {
            try
            {
                _friendApp.Update(friend);
                return Ok($"Friend {friend.Id} updated");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }            
        }


        [Route("Delete/{id?}")]
        [HttpDelete]
        [Authorize]
        public IActionResult Delete(int id)
        {
            try
            {
                _friendApp.Remove(id);
                return Ok($"Friend {id} deleted");
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }            
        }

        [Route("GetNearbyFriends/{friendname?}")]
        [Authorize]
        public IActionResult GetNearbyFriends(string friendname)
        {
            IEnumerable<Friend> friendsList = _friendApp.GetNearbyFriends(friendname);
            if (friendsList == null)
            {
                return NotFound("Friend not found");
            }
            return Ok(friendsList);
        }

    }
}
