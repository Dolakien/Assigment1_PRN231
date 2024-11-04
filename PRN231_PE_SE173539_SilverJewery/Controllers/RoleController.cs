﻿using BusinessObject.Models;
using Microsoft.AspNetCore.Mvc;
using Repository.Interfaces;

namespace PRN231_PE_SE173539_SilverJewery.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        public readonly IRoleRepo _roleRepo;

        public RoleController(IRoleRepo roleRepo)
        {
            this._roleRepo = roleRepo;
        }


        [HttpGet]
        public IActionResult GetAllRoles()
        {
            return Ok(_roleRepo.GetRoles());
        }

        [HttpGet("{id}")]
        public IActionResult GetRoleById(int id)
        {
            var enitty = _roleRepo.GetRole(id);
            if (enitty == null)
            {
                return NotFound();
            }
            return Ok(enitty);
        }

        [HttpPost("create")]
        public IActionResult CreateRole([FromBody] Role role)
        {
            var Response = _roleRepo.addRole(role);

            if (Response)
            {
                return Ok("Success!");
            }
            else
            {
                return BadRequest("Fail!");
            }
        }

        [HttpPut("update")]
        public IActionResult UpdateRole([FromBody] Role role)
        {
            var Response = _roleRepo.updateRole(role);

            if (Response)
            {
                return Ok("Success!");
            }
            else
            {
                return BadRequest("Fail!");
            }
        }

        [HttpDelete("delete/{id}")]
        public IActionResult RemoveRole(int id)
        {
            var Response = _roleRepo.removeRole(id);

            if (Response)
            {
                return Ok("Success!");
            }
            else
            {
                return BadRequest("Fail!");
            }
        }
    }
}
