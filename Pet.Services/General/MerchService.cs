using Pet.Services.General.Interfaces;

namespace Pet.Services.General
{
  public class MerchService : IMerchService
  {
    public void AddToCart(string itemId)
    {
      Console.WriteLine($"Adding item with ID {itemId} to the user's cart...");
    }

    public void RemoveFromCart(string itemId)
    {
      Console.WriteLine($"Removing item with ID {itemId} from the user's cart...");
    }
  }
}