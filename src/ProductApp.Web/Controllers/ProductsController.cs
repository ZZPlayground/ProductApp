using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ProductApp.Web.Models;
using ProductApp.Application.Interfaces;
using System.Threading.Tasks;
using ProductApp.Domain;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ProductApp.Web.Controllers;

public class ProductsController : Controller
{
    private readonly ILogger<ProductsController> _logger;
    private readonly IProductService _productService;

    public ProductsController(ILogger<ProductsController> logger, IProductService service)
    {
        _logger = logger;
        _productService = service;
    }

    // Action to display all products
    public async Task<IActionResult> Index()
    {
        var products = await _productService.GetAllAsync(); // Get all products from service
        return View(products); // Pass the products to the view
    }

    // Action to display a single product by ID
    public async Task<IActionResult> Details(int id)
    {
        var product = await _productService.GetByIdAsync(id); // Get product by ID
        if (product == null)
        {
            return NotFound(); // Return 404 if product is not found
        }
        return View(product); // Pass the product to the view
    }

    // Action to display the form to create a new product
    public IActionResult Create()
    {
        ViewBag.StatusList = new SelectList(new[] { "Active", "Inactive" });
        ViewBag.CategoryList = new SelectList(new[] { "Electronics", "Books", "Clothing" });

        return View(new Product());
    }

    // Action to handle the form submission for creating a new product
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Product product)
    {
        if (ModelState.IsValid) // Check if the model is valid
        {
            await _productService.AddAsync(product); // Call service to add the new product
            return RedirectToAction(nameof(Index)); // Redirect to the list of products after creation
        }

        ViewBag.StatusList = new SelectList(new[] { "Active", "Inactive" });
        ViewBag.CategoryList = new SelectList(new[] { "Electronics", "Books", "Clothing" });

        return View(product); // If invalid, return the same form with the validation errors
    }

    // Action to display the form to edit an existing product
    public async Task<IActionResult> Edit(int id)
    {
        var product = await _productService.GetByIdAsync(id); // Get product by ID
        if (product == null)
        {
            return NotFound(); // Return 404 if product is not found
        }

        ViewBag.StatusList = new SelectList(new[] { "Active", "Inactive" }, product.Status);
        ViewBag.CategoryList = new SelectList(new[] { "Electronics", "Books", "Clothing" }, product.Category);

        return View(product);
    }

    // Action to handle the form submission for updating an existing product
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Product product)
    {
        if (id != product.Id) // Check if the ID matches the product being edited
        {
            return BadRequest(); // Return bad request if IDs don't match
        }

        if (ModelState.IsValid) // Check if the model is valid
        {
            await _productService.UpdateAsync(product); // Call service to update the product
            return RedirectToAction(nameof(Index)); // Redirect to the list of products after updating
        }

        return View(product); // If invalid, return the same form with the validation errors
    }

    // Action to confirm the deletion of a product
    public async Task<IActionResult> Delete(int id)
    {
        var product = await _productService.GetByIdAsync(id); // Get product by ID
        if (product == null)
        {
            return NotFound(); // Return 404 if product is not found
        }

        return View(product); // Pass the product to the view for confirmation
    }

    // Action to handle the deletion of a product
    [HttpPost, ActionName("DeleteConfirmed")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _productService.DeleteAsync(id); // Call service to delete the product
        return RedirectToAction(nameof(Index)); // Redirect to the list of products after deletion
    }
}
