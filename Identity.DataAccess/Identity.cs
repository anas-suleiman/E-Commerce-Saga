﻿namespace Identity.DataAccess
{
    public partial class Identity
    {
        public int Id { get; set; }
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
