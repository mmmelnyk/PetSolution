namespace Pet.Services.General.Interfaces
{
  public interface IMerchService
  {
    void AddToCart(string itemId);
    void RemoveFromCart(string itemId);
  }
}