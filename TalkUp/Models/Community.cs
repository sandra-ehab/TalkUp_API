using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using TalkUp.Models;
using Microsoft.AspNetCore.OpenApi;
using Microsoft.AspNetCore.Http.HttpResults;

namespace TalkUp.Models;

[Table("Community")]
[Index("CommunityId", Name = "IX_Community")]
public partial class Community
{
    [Key]
    [Column("Community_ID")]
    public int CommunityId { get; set; }

    [Column("User_ID")]
    public int UserId { get; set; }

    [Column("Post_ID")]
    public int PostId { get; set; }

    public string? Contant { get; set; }

    public int? Likes { get; set; }

    [ForeignKey("PostId")]
    [InverseProperty("Communities")]
    public virtual Post Post { get; set; } = null!;

    [ForeignKey("UserId")]
    [InverseProperty("Communities")]
    public virtual User User { get; set; } = null!;
}


public static class CommunityEndpoints
{
	public static void MapCommunityEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Community").WithTags(nameof(Community));

        group.MapGet("/", async (TalkUpContext db) =>
        {
            return await db.Communities.ToListAsync();
        })
        .WithName("GetAllCommunitys")
        .WithOpenApi();

        group.MapGet("/{id}", async Task<Results<Ok<Community>, NotFound>> (int communityid, TalkUpContext db) =>
        {
            return await db.Communities.AsNoTracking()
                .FirstOrDefaultAsync(model => model.CommunityId == communityid)
                is Community model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetCommunityById")
        .WithOpenApi();

        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int communityid, Community community, TalkUpContext db) =>
        {
            var affected = await db.Communities
                .Where(model => model.CommunityId == communityid)
                .ExecuteUpdateAsync(setters => setters
                  .SetProperty(m => m.CommunityId, community.CommunityId)
                  .SetProperty(m => m.UserId, community.UserId)
                  .SetProperty(m => m.PostId, community.PostId)
                  .SetProperty(m => m.Contant, community.Contant)
                  .SetProperty(m => m.Likes, community.Likes)
                );

            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdateCommunity")
        .WithOpenApi();

        group.MapPost("/", async (Community community, TalkUpContext db) =>
        {
            db.Communities.Add(community);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/Community/{community.CommunityId}",community);
        })
        .WithName("CreateCommunity")
        .WithOpenApi();

        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int communityid, TalkUpContext db) =>
        {
            var affected = await db.Communities
                .Where(model => model.CommunityId == communityid)
                .ExecuteDeleteAsync();

            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeleteCommunity")
        .WithOpenApi();
    }
}