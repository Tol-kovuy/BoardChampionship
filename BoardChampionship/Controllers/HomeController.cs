using AutoMapper;
using BoardChampionship.BLL.Services.PlayerService;
using BoardChampionship.BLL.Services.TeamService;
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
    private readonly ITeamService _teamService;

    public HomeController(
          ILogger<HomeController> logger,
          IMapper mapper,
          IPlayerService playerService,
          ITeamService teamService
        )
    {
        _logger = logger;
        _mapper = mapper;
        _playerService = playerService;
        _teamService = teamService;
    }

    public IActionResult Index()
    {
        var players = _playerService
            .GetPlayers()
            .ToList();
        var playersModel = new List<PlayerViewModel>();
        foreach (var player in players)
        {
            var team = _teamService.GetTeam(player.TeamId);
            player.Team = team;
            var playerModel = _mapper.Map<PlayerViewModel>(player);
            playersModel.Add(playerModel);
        }
        return View(playersModel);
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
            _playerService.AddPlayer(player);
            return RedirectToAction("Index");
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
        var team = _teamService.GetTeam(player.TeamId);
        _teamService.RemoveTeam(team);
        return RedirectToAction("Index");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}