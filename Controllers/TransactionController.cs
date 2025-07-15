using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using orcamento_pessoal_api.Helpers;

namespace orcamento_pessoal_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class TransactionController : ControllerBase
    {
        [HttpGet("getAll")]
        public IActionResult GetTransactions()
        {
            // This is a placeholder for the actual transaction retrieval logic.
            // In a real application, you would retrieve transactions from a database or service.
            if (!User.IsInRole("Admin"))
            {
                return Forbid(); // Return 403 Forbidden if the user is not an Admin
            }

            var userName = User.Identity.Name;

            var transactions = new List<string>
            {
                $"Transaction 1 - $50.00 by {userName}",
                "Transaction 2 - $75.00",
                "Transaction 3 - $100.00"
            };

            return Ok(transactions);
        }

        [HttpGet("salt")]
        [AllowAnonymous]
        public IActionResult SaltTest()
        {
            var salt = SenhaHelper.GenerateSalt();
            return Ok(salt);
        }

        [HttpGet("hash")]
        [AllowAnonymous]
        public IActionResult HashTest()
        {
            // var salt = SenhaHelper.GenerateSalt();
            var salt = "o7TZ/BULGn2FTRuJbAWXjw==";
            var hash = SenhaHelper.GenerateHash("1q2w3e4r", salt);

            var result = new
            {
                Salt = salt,
                Hash = hash
            };

            return Ok(result);
        }
    }
}