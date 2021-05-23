﻿using Pl4nn1ng_P0k3xx.Data;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Pl4nn1ng_P0k3xx
{
    public class PlanningRepository : IPlanningRepository
    {
        private readonly IDatabase database;

        public PlanningRepository(ConnectionMultiplexer redis)
        {
            database = redis.GetDatabase();
        }

        public async Task<bool> AddBoard(Planning planning)
        {
            var isDone = await database.StringSetAsync(planning.Id.ToString(), JsonSerializer.Serialize(planning));

            return isDone;
        }

        public async Task<bool> AddUserToBoard(Guid boardId, User user)
        {
            var data = await database.StringGetAsync(boardId.ToString());

            if (data.IsNullOrEmpty)
            {
                return false;
            }

            var board = JsonSerializer.Deserialize<Planning>(data);
            board.Users.Add(user);

            return await AddBoard(board);
        }
        
        public async Task<bool> UpdateUserPoint(Guid boardId, Guid userId, int point)
        {
            var data = await database.StringGetAsync(boardId.ToString());
            var board = JsonSerializer.Deserialize<Planning>(data);
            var user = board.Users.FirstOrDefault(u => u.UserId == userId);
            if (user != null)
            {
                user.Point = point;
            }

            return await AddBoard(board);
        }

        public async Task<List<User>> GetUsersFromBoard(Guid boardId)
        {
            var data = await database.StringGetAsync(boardId.ToString());

            if (data.IsNullOrEmpty)
            {
                return new List<User>();
            }

            var board = JsonSerializer.Deserialize<Planning>(data);

            return board.Users;
        }

        public async Task<bool> ClearUsersPoint(Guid boardId)
        {
            var data = await database.StringGetAsync(boardId.ToString());

            if (data.IsNullOrEmpty)
            {
                return false;
            }

            var board = JsonSerializer.Deserialize<Planning>(data);
            board.Users.ForEach(u => u.Point = 0);

            return await AddBoard(board);
        }

        public async Task<bool> TogglePoints(Guid boardId, bool state)
        {
            var data = await database.StringGetAsync(boardId.ToString());

            if (data.IsNullOrEmpty)
            {
                return false;
            }

            var board = JsonSerializer.Deserialize<Planning>(data);
            board.Users.ForEach(u => u.ShowPoint = state);

            return await AddBoard(board);
        }

        public async Task<bool> teste()
        {
            var t = true;
            return t;
        }
    }
}
