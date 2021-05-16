using System;
using System.Collections.Generic;

namespace Pl4nn1ng_P0k3xx.Data
{
    public class Planning
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public List<User> Users { get; set; } = new List<User>();
    }
}
