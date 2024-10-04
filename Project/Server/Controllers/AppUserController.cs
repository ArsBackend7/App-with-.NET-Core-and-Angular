using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Data;
using Server.Entities.Models;

namespace Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AppUserController : ControllerBase
{
    private readonly DataContext _context;

    public AppUserController(DataContext context)
    {
        _context = context;
    }

    [HttpGet]
    [Route("get-app-users", Name = "GetAllAppUsers")]
    public async Task<IActionResult> GetAppUsers()
    {
        var users = await _context.AppUsers.ToListAsync();
        return Ok(users);
    }

    [HttpGet]
    [Route("get-app-user", Name = "GetAppUserById")]
    public async Task<IActionResult> GetAppUser(int appUserId)
    {
        var appUser = await _context.AppUsers.FindAsync(appUserId);

        if (appUser == null)
        {
            return NotFound();
        }

        return Ok(appUser);
    }

    [HttpPost]
    [Route("create-app-user", Name = "CreateAppUser")]
    public async Task<IActionResult> PostAppUser(AppUser appUser)
    {
        await _context.AppUsers.AddAsync(appUser);
        await _context.SaveChangesAsync();
        return CreatedAtRoute("GetAppUserById", new { appUserId = appUser.Id }, appUser);
    }

    [HttpPut]
    [Route("update-app-user", Name = "UpdateAppUser")]
    public async Task<IActionResult> PutAppUser(int appUserId, AppUser appUser)
    {
        if (appUserId != appUser.Id)
        {
            return BadRequest("AppUser ID mismatch.");
        }

        _context.Entry(appUser).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!await AppUserExists(appUserId))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    [HttpDelete]
    [Route("delete-app-user", Name = "DeleteAppUser")]
    public async Task<IActionResult> DeleteAppUser(int appUserId)
    {
        var appUser = await _context.AppUsers.FindAsync(appUserId);
        if (appUser == null)
        {
            return NotFound();
        }

        _context.AppUsers.Remove(appUser);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private async Task<bool> AppUserExists(int id)
    {
        return await _context.AppUsers.AnyAsync(e => e.Id == id);
    }
}
