namespace Pet.Services.General;
using Pet.Services.General.Interfaces;

  public class EmailService : IEmailService
  {
    public void SendWelcomeEmail(string email, string name)
    {
      Console.WriteLine($"Sending welcome email to {email} with name {name}...");
    }

    public void SendGettingStartedEmail(string email, string name)
    { 
      Console.WriteLine($"Sending getting started email to {email} with name {name}...");
    }
  }
