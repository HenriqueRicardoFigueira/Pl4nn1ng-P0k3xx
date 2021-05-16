using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pl4nn1ng_P0k3xx.Data
{
    public interface IPlanningRepository
    {
        Task<bool> AddBoard(Planning planning);

        Task<bool> AddUserToBoard(Guid boardId, User user);

        Task<List<User>> GetUsersFromBoard(Guid boardId);

        Task<bool> ClearUsersPoint(Guid boardId);

        Task<bool> TogglePoints(Guid boardId, bool state);

    }
}
