﻿using Blogify.Domain.AggregationModels.Post;

namespace Blogify.Domain.Entities;

public class User
{
    public long Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Username { get; set; }
    public string Password { get; private set; }
    public string Email { get; set; }
    public IList<Post> Posts { get; set; }
}