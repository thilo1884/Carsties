using Microsoft.AspNetCore.Mvc;
using MongoDB.Entities;
using SearchService.Models;

namespace SearchService;

[ApiController]
[Route("api/search")]
public class SearchController : ControllerBase
{
    //in this case we dont need to inject the DB Mongo
    //becuse it is a static class

    //mongodb-entities.com/wiki/Entities-Update.html

    [HttpGet]
    public async Task<ActionResult<List<Item>>> SearchItems(string searchTerm, 
         int pageNumber = 1, int pageSize = 4)    
    {
        var query = DB.PagedSearch<Item>(); // Create the query

        query.Sort(x => x.Ascending(a => a.Make));

        if (!string.IsNullOrEmpty(searchTerm))
        {
            query.Match(Search.Full, searchTerm).SortByTextScore();
        }

        query.PageNumber(pageNumber);
        query.PageSize(pageSize);

        var result = await query.ExecuteAsync();

        // returns a anonymus object
        return Ok(new
        {
            results = result.Results,
            pageCount = result.PageCount,
            totalCount = result.TotalCount
        });
    }
}
