﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MmsApi.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public bool IsAdmin { get; set; }
    }
}