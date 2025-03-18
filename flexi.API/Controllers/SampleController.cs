using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechTalk.DatabaseAccessor.Services;

namespace flexi.API.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class SampleController : ControllerBase
  {
    // private IDatabaseAccessor _databaseAccessor;

    // public SampleController(IDatabaseAccessor databaseAccessor)
    // {
    //   _databaseAccessor = databaseAccessor ?? throw new ArgumentNullException(nameof(databaseAccessor));
    // }

    // [HttpGet]
    // public async Task<IActionResult> Get(){
    //   var sql = @"Select * from sample_table";
    //   var result = await _databaseAccessor.QueryAsync<object>(sql);
    //   return Ok(result);
    // }
  }
}