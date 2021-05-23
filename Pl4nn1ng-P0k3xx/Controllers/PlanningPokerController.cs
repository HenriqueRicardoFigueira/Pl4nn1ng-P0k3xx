using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Pl4nn1ng_P0k3xx.Data;
using Pl4nn1ng_P0k3xx.Hubs;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Pl4nn1ng_P0k3xx.Controllers
{
    [Route("planningPoker")]
    [ApiController]
    public class PlanningPokerController : ControllerBase
    {
        private readonly IPlanningRepository planningRepository;
        private readonly IHubContext<PlanningPokerHub> hub;

        public PlanningPokerController(IPlanningRepository planningRepository, IHubContext<PlanningPokerHub> hub)
        {
            this.planningRepository = planningRepository;
            this.hub = hub;
        }

        [HttpPost("boards")]
        public async Task<IActionResult> Post([FromBody] Planning planning)
        {
            var boardId = Guid.NewGuid();
            planning.Id = boardId;

            var isCreated = await planningRepository.AddBoard(planning);
            if (isCreated)
            {
                return Ok(boardId);
            }

            return NotFound();
        }

        [HttpPost("boards/{boardId}")]
        public async Task<IActionResult> UpdateUsersPoint(Guid boardId)
        {
            var isAdded = await planningRepository.ClearUsersPoint(boardId);
            await hub.Clients.Group(boardId.ToString())
                .SendAsync("UsersAdded", await planningRepository.GetUsersFromBoard(boardId));
            if (isAdded)
            {
                return Ok(isAdded);
            }
            return NotFound();
        }

        [HttpPost("boards/{boardId}/{state}")]
        public async Task<IActionResult> UpdateUsersPointVisibility(Guid boardId, bool state)
        {
            var isToggled = await planningRepository.TogglePoints(boardId, state);
            await hub.Clients.Group(boardId.ToString())
                .SendAsync("UsersAdded", await planningRepository.GetUsersFromBoard(boardId));
            if (isToggled)
            {
                return Ok(isToggled);
            }
            return NotFound();
        }

        [HttpPost("boards/{boardId}/user")]
        public async Task<IActionResult> AddUser(Guid planningId, User user)
        {
            user.UserId = Guid.NewGuid();
            var havePlayers = await planningRepository.GetUsersFromBoard(planningId);
            if (!havePlayers.Any())
                user.IsAdmin = true;
            var isAdded = await planningRepository.AddUserToBoard(user.BoardId, user);
            await hub.Clients.Group(planningId.ToString())
                .SendAsync("UsersAdded", await planningRepository.GetUsersFromBoard(planningId));
            if (isAdded)
            {
                return Ok(user.UserId);
            }
            return NotFound();
        }

        [HttpPut("boards/{boardId}/user")]
        public async Task<IActionResult> UpdateUser(Guid boardId, User user)
        {
            var isUpdated = await planningRepository.UpdateUserPoint(boardId, user.UserId, user.Point);
            await hub.Clients.Group(boardId.ToString())
                .SendAsync("UsersAdded", await planningRepository.GetUsersFromBoard(boardId));

            return Ok(isUpdated);
        }

        [HttpGet("boards/{boardId}/users")]
        public async Task<IActionResult> GetUsers(Guid boardId)
        {
            var users = await planningRepository.GetUsersFromBoard(boardId);
          
            return Ok(users);
        }

        [HttpGet("boards/{boardId}/users/{userId}")]
        public async Task<IActionResult> GetUser(Guid boardId, Guid userId)
        {
            var users = await planningRepository.GetUsersFromBoard(boardId);
            var user = users.FirstOrDefault(u => u.UserId == userId);
            return Ok(user);
        }
       
    
    }

   

}
