using AutoMapper;
using BoardChampionship.BLL.Services.PlayerService;
using BoardChampionship.DAL.Entities;
using BoardChampionship.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BoardChampionship.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IMapper _mapper;
    private readonly IPlayerService _playerService;

    public HomeController(
          ILogger<HomeController> logger,
          IMapper mapper,
          IPlayerService playerService
        )
    {
        _logger = logger;
        _mapper = mapper;
        _playerService = playerService;
    }

    public IActionResult Index()
    {
        var players = _playerService
            .GetPlayers()
            .Select(player => _mapper.Map<PlayerViewModel>(player))
            .ToList();
        return View(players);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [HttpGet]
    public IActionResult AddNewPlayer()
    {
        return View();
    }

    [HttpPost]
    public IActionResult AddNewPlayer(PlayerViewModel model)
    {
        if (ModelState.IsValid)
        {
            var player = _mapper.Map<Player>(model);
            var create = _playerService.AddPlayer(player);
            if (create)
            {
                ViewBag.Player = "Player was added";
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Player = $"The player witn nickname {model.NickName} already exist";
            }
        }
        return View();
    }

    public IActionResult Delete(int id)
    {
        var player = _playerService.GetPlayer(id);
        if (player == null)
        {
            return View("Error");
        }
        _playerService.RemovePlayer(player.Id);
        return RedirectToAction("Index");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}