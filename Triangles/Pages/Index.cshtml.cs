using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Triangles.Models;
using Triangles.Services;
using Triangles.Validation;

namespace Triangles.Pages;

public class IndexModel : PageModel
{
    [BindProperty]
    public int SideA { get; set; }
    [BindProperty]
    public int SideB { get; set; }
    [BindProperty]
    public int SideC { get; set; }
    public Triangle myTriangle { get; set; }
    private readonly TriangleDrawer _drawer = new TriangleDrawer();
    private TriangleValidator _validate = new TriangleValidator();
    public string errorMessage;

    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
    }

    // When a triangle is submitted
    public IActionResult OnPost()
    {
        // If each side passes the server side validation, then create a triangle object, and draw triangle
        if(_validate.ValidateSides(SideA, SideB, SideC))
        {
            myTriangle = new Triangle(SideA, SideB, SideC);
            _drawer.DrawTriangle(myTriangle.SideA, myTriangle.SideB, myTriangle.SideC, myTriangle.AngleA, myTriangle.AngleB, myTriangle.AngleC);
        }
        else
        {
            errorMessage = "This is not a valid triangle";
        }

        return Page();
    }
}

