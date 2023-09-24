using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers;
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ApplicationDbContext _db;
    public HomeController(ILogger<HomeController> logger, ApplicationDbContext db)
    {
        _db = db;
        _logger = logger;
    }


    public IActionResult Index()
    {
        IEnumerable<ToDo> todo_En = _db.ToDos;
        ICollection<ToDo> todo_Co = _db.ToDos.ToList();
        IList<ToDo> todo_Li = _db.ToDos.ToList();

        
        foreach(ToDo todo in todo_Co)
        {
            _logger.Log(LogLevel.Information, "Collection - " + todo.Item);
        }
        foreach (ToDo todo in todo_Li)
        {
            _logger.Log(LogLevel.Information, "List - " + todo.Item);
        }
        foreach (ToDo todo in todo_En)
        {
            _logger.Log(LogLevel.Information, "Enumrable - " + todo.Item);
        }

        // Short all
        var shortedTodo_En = todo_En.Where(x => x.Item.Contains("a")).OrderBy(x => x.Id);
        var shortedTodo_Co = todo_Co.ToList();
        var shortedTodo_Li = todo_Li.ToList();

        // what you can't do with IEnumerable
        ToDo todo_new = new() { Id = 10, Item = "Hello" };
        todo_Co.Add(todo_new);
        todo_Li.Add(todo_new);
        todo_Co.Remove(todo_new);
        todo_Li.Remove(todo_new);

        // what you can't do with ICollection
        todo_Li.Insert(3, todo_new);
        todo_Li.RemoveAt(3);


        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
