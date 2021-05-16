using System;

namespace Pl4nn1ng_P0k3xx.Data
{
    public class User
    {
        public Guid UserId { get; set; }

        public string Name { get; set; }

        public int Point { get; set; }

        public bool IsAdmin { get; set; }

        public bool ShowPoint { get; set; }
    }
}
