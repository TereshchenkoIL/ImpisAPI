using System;

namespace ImpisApi.Web.DTO
{
    public class UserDto
    {
        public string Id { get; set; }
        public string DisplayName { get; set; }
        public string Token { get; set; }
        public string Image { get; set; }
        public string Bio { get; set; }
        public bool isAdmin { get; set; }
        public string Username { get; set; }
    }
}