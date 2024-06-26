﻿using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.AuthDTOs;
public class UserRegisterRequest
{
    [Required, EmailAddress]
    public string Email { get; set; } = string.Empty;
    [Required]
    public string Username { get; set; } = string.Empty;
    [Required]
    public string Password { get; set; } = string.Empty;
}
