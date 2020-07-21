using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Synel.Web.Models;
using Synel.Web.Services;

namespace Synel.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMediator _mediator;

        public HomeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var query = new QueryEmployees();
            return View(new EmployeesViewModel
            {
                Query = query,
                Alert = (string) TempData[nameof(EmployeesViewModel.Alert)],
                Employees = await _mediator.Process(query)
            });
        }

        [HttpPost]
        public async Task<IActionResult> Index(QueryEmployees query)
        {
            return View(new EmployeesViewModel
            {
                Query = query,
                Employees = await _mediator.Process(query),
            });
        }


        [HttpPost]
        public async Task<IActionResult> Import(ImportCsv request)
        {
            var rows = await _mediator.Process(request);
            Alert($"CSV import was successfully processed with {rows} rows!");
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Remove(RemoveEmployee request)
        {
            await _mediator.Process(request);
            Alert("Employee was successfully removed");
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(GetEmployeeById request)
        {
            return View(await _mediator.Process(request));
        }

        public IActionResult Add() => View("Edit");

        [HttpPost]
        public async Task<IActionResult> Save(Employee value)
        {
            await _mediator.Process(new SaveEmployee {Value = value});
            Alert($"Employee was successfully saved");
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() => View(new ErrorViewModel
            {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});

        private void Alert(string text) => TempData[nameof(EmployeesViewModel.Alert)] = text;
    }
}