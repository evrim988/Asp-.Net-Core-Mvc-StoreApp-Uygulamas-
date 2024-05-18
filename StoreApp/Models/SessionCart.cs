using Entities.Entities;
using StoreApp.Infastructure.Extensions;
using System.Text.Json.Serialization;

namespace StoreApp.Models;

public class SessionCart : Cart
{
    [JsonIgnore]
    public ISession Session { get; set; }

    public static Cart GetCart(IServiceProvider services)
    {
        var session = services.GetRequiredService<IHttpContextAccessor>().HttpContext?.Session;
        var cart = session.GetJson<SessionCart>("cart") ?? new SessionCart();
        cart.Session = session;
        return cart;
    }

    public override void AddItem(Entities.Entities.Product model, int quantity)
    {
        base.AddItem(model, quantity);
        Session.SetSession<SessionCart>("cart", this);
    }

    public override void Clear()
    {
        base.Clear();
        Session.Remove("cart");
    }

    public override void RemoveLine(Entities.Entities.Product model)
    {
        base.RemoveLine(model);
        Session.SetSession<SessionCart>("cart", this);
    }
}
