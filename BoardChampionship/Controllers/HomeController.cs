using AutoMapper;
using BoardChampionship.BLL.Services.GameService;
using BoardChampionship.BLL.Services.PlayerService;
using BoardChampionship.BLL.Services.TeamService;
using BoardChampionship.BLL.Services.WinnerService;
using BoardChampionship.DAL.Entities;
using BoardChampionship.DAL.Enums;
using BoardChampionship.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace BoardChampionship.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IMapper _mapper;
    private readonly IPlayerService _playerService;
    private readonly ITeamService _teamService;
    private readonly IGameService _gameService;
    private readonly IWinnerService _winnerService;

    public HomeController(
           ILogger<HomeController> logger,
           IMapper mapper,
           IPlayerService playerService,
           ITeamService teamService,
           IGameService gameService,
           IWinnerService winnerService
        )
    {
        _logger = logger;
        _mapper = mapper;
        _playerService = playerService;
        _teamService = teamService;
        _gameService = gameService;
        _winnerService = winnerService;
    }

    public IActionResult Index()
    {
        var players = _playerService
            .GetPlayers()
            .Select(player => _mapper.Map<PlayerViewModel>(player))
            .ToList();
        var winners = _winnerService
            .GetAll()
            .Select(winner => _mapper.Map<WinnerViewModel>(winner))
            .ToList();
        if (winners != null)
        {
            foreach (var player in players)
            {
                var win = winners.FirstOrDefault(x => x.Name == player.Team.Name);
                if (win != null)
                {
                    player.Winner = win;
                }
            }
        }
        return View(players);
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

    [HttpGet]
    public IActionResult StartGame()
    {
        var listGameNumber = new List<string>
        {
            GamesType.First_Game.ToString(),
            GamesType.Second_Game.ToString(),
            GamesType.Third_Game.ToString(),
        };
        ViewBag.GamesType = listGameNumber;
        var listTeamName = new List<string>();
        foreach (var name in _teamService.GetTeams())
        {
            listTeamName.Add(name.Name);
        }
        ViewBag.TeamName = listTeamName;
        return View();
    }

    [HttpPost]
    public IActionResult StartGame(GameViewModel model)
    {
        if (ModelState.IsValid)
        {
            var entity = _mapper.Map<Game>(model);
            entity.TeamId = _teamService.GetByName(model.Team).Id;
            _gameService.StartGame(entity);
            if (model.GamesNumber == GamesType.Third_Game)
            {
                var team = _teamService.GetTeam(entity.TeamId);
                var winner = _gameService.DetermineTheWinner(team);
                if (winner)
                {
                    var winnerEntity = new Winner
                    {
                        WinnerTeamId = team.Id,
                        Name = team.Name
                    };
                    _winnerService.Add(winnerEntity);
                }
                else
                {
                    var gameName = _gameService.GetGames()
                                               .Where(x => x.TeamId == team.Id)
                                               .First()
                                               .Name;
                    var secondTeamList = _gameService.GetGames()
                                                     .Where(x => x.Name == gameName)
                                                     .ToList();
                    var secondTeamId = secondTeamList.Where(x => x.TeamId != team.Id)
                                                     .First()
                                                     .TeamId;
                    var secondTeam = _teamService.GetTeam(secondTeamId);
                    var winnerEntity = new Winner
                    {
                        WinnerTeamId = secondTeam.Id,
                        Name = secondTeam.Name
                    };
                    _winnerService.Add(winnerEntity);
                }
            }
        }
        return RedirectToAction("StartGame");
    }

    [HttpGet]
    public IActionResult PlayFinal()
    {
        var teams = _winnerService.GetAll();
        var finalTeams = new List<string>();
        foreach (var team in teams)
        {
            finalTeams.Add(team.Name);
        }
        ViewBag.TeamName = finalTeams;
        return View();
    }

    [HttpPost]
    public IActionResult PlayFinal(GameViewModel model)
    {
        if (ModelState.IsValid)
        {
            var team = _teamService.GetByName(model.Team);
            var winner = new Winner
            {
                Name = team.Name,
                WinnerTeamId = team.Id
            };
            _winnerService.Add(winner);
        }
        return RedirectToAction("PlayFinal");
    }

    public IActionResult AbsoluteWinner()
    {
        var winner = _winnerService.GetAll()
                                   .Select(x => x.Name)
                                   .GroupBy(x => x)
                                   .Where(group => group.Count() > 1)
                                   .Select(y => new AbsoluteWinnerViewModel{ Team = y.Key, Wins = y.Count() })
                                   .ToList();
        
        return View(winner);
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