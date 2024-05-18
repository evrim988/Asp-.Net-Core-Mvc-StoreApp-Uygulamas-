using Entities.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.Abstract;
using System.ComponentModel;

namespace StoreApp.Pages
{
    public class CartModel : PageModel
    {
        private readonly IServiceManager _manager;

        public Cart Card { get; set; }

        public string ReturnUrl { get; set; } = "/";

        public CartModel(IServiceManager manager, Cart cartService)
        {
            _manager = manager;
            Card = cartService;
        }


        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
           
        }

        public IActionResult OnPost(int Id, string returnUrl)
        {
            var model = _manager.ProductService.GetProductById(Id, false);
            if (model != null)
                Card.AddItem(model, 1);
            return RedirectToPage( new {returnUrl = returnUrl} );
        }

        public IActionResult OnPostRemove(int Id)
        {
            Card.RemoveLine(Card.Lines.FirstOrDefault(s => s.ProductId == Id).Product);
            return Page();
        }
    }
}
