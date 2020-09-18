using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Retails.Data;
using Retails.Models;

namespace Retails.Controllers
{
    public class DeliveryToCustomersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DeliveryToCustomersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DeliveryToCustomers
        public async Task<IActionResult> Index()
        {
            var del = _context.DeliveryToCustomers.Include(s => s.Supplier).Include(c => c.Customer);
            return View(await del.ToListAsync());
        }

        // GET: DeliveryToCustomers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deliveryToCustomer = await _context.DeliveryToCustomers
                .SingleOrDefaultAsync(m => m.ID == id);
            if (deliveryToCustomer == null)
            {
                return NotFound();
            }

            return View(deliveryToCustomer);
        }

        // GET: DeliveryToCustomers/Create
        public IActionResult Create()
        {
            ViewBag.Supplier = new SelectList(_context.Suppliers.ToList(), "ID", "Name");
            ViewBag.Customer = new SelectList(_context.Customers.ToList(), "ID", "Name");
            return View();
        }

        // POST: DeliveryToCustomers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,DeliveryDate,Price,SupplierID,CustomerID")] DeliveryToCustomer deliveryToCustomer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(deliveryToCustomer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(deliveryToCustomer);
        }

        // GET: DeliveryToCustomers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            ViewBag.Supplier = new SelectList(_context.Suppliers.ToList(), "ID", "Name");
            ViewBag.Customer = new SelectList(_context.Customers.ToList(), "ID", "Name");
            var deliveryToCustomer = await _context.DeliveryToCustomers.SingleOrDefaultAsync(m => m.ID == id);
            if (deliveryToCustomer == null)
            {
                return NotFound();
            }
            return View(deliveryToCustomer);
        }

        // POST: DeliveryToCustomers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,DeliveryDate,Price,SupplierID,CustomerID")] DeliveryToCustomer deliveryToCustomer)
        {
            if (id != deliveryToCustomer.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(deliveryToCustomer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DeliveryToCustomerExists(deliveryToCustomer.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(deliveryToCustomer);
        }

        // GET: DeliveryToCustomers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deliveryToCustomer = await _context.DeliveryToCustomers
                .SingleOrDefaultAsync(m => m.ID == id);
            if (deliveryToCustomer == null)
            {
                return NotFound();
            }

            return View(deliveryToCustomer);
        }

        // POST: DeliveryToCustomers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var deliveryToCustomer = await _context.DeliveryToCustomers.SingleOrDefaultAsync(m => m.ID == id);
            _context.DeliveryToCustomers.Remove(deliveryToCustomer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DeliveryToCustomerExists(int id)
        {
            return _context.DeliveryToCustomers.Any(e => e.ID == id);
        }
    }
}
