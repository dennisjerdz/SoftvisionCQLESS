using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CognizantQLESS.Core.Models;
using CognizantQLESS.DAL;
using CognizantQLESS.Core.Constants;
using Microsoft.AspNetCore.Authorization;

namespace CognizantQLESS.Site.Controllers
{
    [Authorize(Roles = Constants.ROLE_ADMIN)]
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Route("Admin/")]
        [Route("Admin/TransportCards")]
        [Route("Admin/Index")]
        public async Task<IActionResult> TransportCards()
        {
            return View(await _context.TransportCards.ToListAsync());
        }
        
        public async Task<IActionResult> TransportCardDetails(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transportCard = await _context.TransportCards
                .FirstOrDefaultAsync(m => m.TransportCardId == id);
            if (transportCard == null)
            {
                return NotFound();
            }

            return View(transportCard);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> TransportCardCreate()
        {
            var transportCard = new TransportCard();
            transportCard.Load = 100;
            transportCard.PurchaseDate = DateTime.Now;

            if (ModelState.IsValid)
            {
                _context.Add(transportCard);
                await _context.SaveChangesAsync();

                // transfer to trigger
                transportCard.SerialNumber = transportCard.GenerateSerialNumber();
                await _context.SaveChangesAsync();

                return RedirectToAction("TransportCards");
            }
            return RedirectToAction("TransportCards");
        }

        public async Task<IActionResult> TransportCardDelete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transportCard = await _context.TransportCards
                .FirstOrDefaultAsync(m => m.TransportCardId == id);
            if (transportCard == null)
            {
                return NotFound();
            }

            return View(transportCard);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> TransportCardDeleteConfirmed(int id)
        {
            var transportCard = await _context.TransportCards.FindAsync(id);
            _context.TransportCards.Remove(transportCard);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TransportCardExists(int id)
        {
            return _context.TransportCards.Any(e => e.TransportCardId == id);
        }
    }
}
