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
    [Route("get-app-users")]
    public async Task<IActionResult> GetAppUsers()
    {
        List<AppUser> users = await _context.AppUsers.ToListAsync();
        return Ok(users);
    }

    [HttpGet]
    [Route("get-app-user")]
    public async Task<IActionResult> GetAppUser(int appUserId)
    {
        AppUser? appUser = await _context.AppUsers.FindAsync(appUserId);

        return appUser == null ? NotFound() : Ok(appUser);
    }

    [HttpPost]
    [Route("create-app-user")]
    public async Task<IActionResult> PostAppUser(AppUser appUser)
    {
        _ = await _context.AppUsers.AddAsync(appUser);
        _ = await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetAppUser), new { appUserId = appUser.Id }, appUser);
    }

    [HttpPut]
    [Route("update-app-user")]
    public async Task<IActionResult> PutAppUser(int appUserId, AppUser appUser)
    {
        if (appUserId != appUser.Id)
        {
            return BadRequest("AppUser ID mismatch.");
        }

        _context.Entry(appUser).State = EntityState.Modified;

        try
        {
            _ = await _context.SaveChangesAsync();
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
    [Route("delete-app-user")]
    public async Task<IActionResult> DeleteAppUser(int appUserId)
    {
        AppUser? appUser = await _context.AppUsers.FindAsync(appUserId);
        if (appUser == null)
        {
            return NotFound();
        }

        _ = _context.AppUsers.Remove(appUser);
        _ = await _context.SaveChangesAsync();

        return NoContent();
    }

    private async Task<bool> AppUserExists(int id)
    {
        return await _context.AppUsers.AnyAsync(e => e.Id == id);
    }
}
