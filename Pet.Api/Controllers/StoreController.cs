namespace Pet.Api.Controllers;
using Microsoft.AspNetCore.Mvc;
using Pet.Services.General.Interfaces;
using Hangfire;

[ApiController]
[Route("api/[controller]")]
public class StoreController : ControllerBase
{

  [HttpPost("add-to-cart")]
  public async Task<IActionResult> AddToCart(string itemId)
  {
    var jobId = BackgroundJob.Enqueue<IEmailService>(x => x.SendWelcomeEmail("kolanio757@gmail.com", "Kola"));
    Console.WriteLine($"Job ID: {jobId}");
    return Ok();
  }

  [HttpDelete("remove-from-cart")]
  public async Task<IActionResult> RemoveFromCart(string itemId)
  {
    RecurringJob.AddOrUpdate<IMerchService>("remove-items", x => x.RemoveFromCart(itemId), Cron.Minutely);
    return Ok();
  }

  [HttpPut("update-cart")]
  public async Task<IActionResult> UpdateCart(string itemId, int quantity)
  {
    // Get cart
    var jobId = BackgroundJob.Schedule<IMaintenanceService>(x => x.SyncInventory(), TimeSpan.FromSeconds(10));
    Console.WriteLine($"Delayed Job ID: {jobId}");
    return Accepted();
  }
}