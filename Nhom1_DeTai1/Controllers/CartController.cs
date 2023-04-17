using Microsoft.AspNetCore.Mvc;
using Nhom1_DeTai1.Models.ViewModels;
using Nhom1_DeTai1.Models;
using Nhom1_DeTai1.Infrastructure;
using Nhom1_DeTai1.Data;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Nhom1_DeTai1.Controllers
{
    [Authorize(Roles = "Customer")]
    public class CartController : Controller
    {
        private readonly Nhom1_DeTai1Context _context;

        public CartController(Nhom1_DeTai1Context context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart") ?? new List<CartItem>();

            CartViewModel cartVM = new()
            {
                CartItems = cart,
                GrandTotal = cart.Sum(x => x.Quantity * x.Price)
            };

            return View(cartVM);
        }

        public IActionResult Checkout()
        {
            return View();
        }

        public IActionResult SaveOrder(IFormCollection fc)
        {
            List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart");
            
            // Save Invoice
            Invoice invoice = new Invoice();
            invoice.CustomerFirstName = fc["CustomerFirstName"];
            invoice.CustomerLastName = fc["CustomerLastName"];
            invoice.CustomerAddress = fc["CustomerAddress"];
            _context.Invoice.Add(invoice);
            _context.SaveChanges();

            // Save Invoice Detail
            foreach (CartItem item in cart)
            {
                InvoiceDetail invoiceDetail = new InvoiceDetail();
                invoiceDetail.InvoiceId = invoice.InvoiceId;
                invoiceDetail.Quantity = item.Quantity;
                invoiceDetail.Price = item.Price;
                invoiceDetail.Image= item.Image;
                invoiceDetail.ProductId = item.ProductId;
                _context.InvoiceDetail.Add(invoiceDetail);
                _context.SaveChanges();
            }

            HttpContext.Session.Remove("Cart");

            return View();
        }

        public async Task<IActionResult> Add(int id)
        {
            Product product = await _context.Product.FindAsync(id);

            List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart") ?? new List<CartItem>();

            CartItem cartItem = cart.Where(c => c.ProductId == id).FirstOrDefault();

            if (cartItem == null)
            {
                cart.Add(new CartItem(product));
            }
            else
            {
                cartItem.Quantity += 1;
            }

            HttpContext.Session.SetJson("Cart", cart);

            TempData["Success"] = "The product has been added!";

            return Redirect(Request.Headers["Referer"].ToString());
        }

        public async Task<IActionResult> Decrease(int id)
        {
            List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart");

            CartItem cartItem = cart.Where(c => c.ProductId == id).FirstOrDefault();

            if (cartItem.Quantity > 1)
            {
                --cartItem.Quantity;
            }
            else
            {
                cart.RemoveAll(p => p.ProductId == id);
            }

            if (cart.Count == 0)
            {
                HttpContext.Session.Remove("Cart");
            }
            else
            {
                HttpContext.Session.SetJson("Cart", cart);
            }

            TempData["Success"] = "The product has been removed!";

            return RedirectToAction("Index");
        }
        public async Task<IActionResult> UpdateQuan(int id, int val_update)
        {
            Product product = await _context.Product.FindAsync(id);

            List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart") ?? new List<CartItem>();

            CartItem cartItem = cart.Where(c => c.ProductId == id).FirstOrDefault();

                cartItem.Quantity += val_update;

            HttpContext.Session.SetJson("Cart", cart);

            TempData["Success"] = "The product has been added!";

            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Remove(int id)
        {
            List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart");

            cart.RemoveAll(p => p.ProductId == id);

            if (cart.Count == 0)
            {
                HttpContext.Session.Remove("Cart");
            }
            else
            {
                HttpContext.Session.SetJson("Cart", cart);
            }

            TempData["Success"] = "The product has been removed!";

            return RedirectToAction("Index");
        }

        public IActionResult Clear()
        {
            HttpContext.Session.Remove("Cart");

            return RedirectToAction("Index");
        }
    }
}
