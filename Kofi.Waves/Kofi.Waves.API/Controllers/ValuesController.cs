using System;
using Microsoft.AspNetCore.Mvc;

namespace Kofi.Waves.API.Controllers
{
    [Route("/")]
    public class TestController : Controller
    {
        [HttpGet]
        public IActionResult Get([FromQuery] string board)
        {
            //TODO: work out how to properly handle 9 +'s in query string
            const string emptyBoard = "?board=+++++++++";

            if (Request.QueryString.Value == emptyBoard)
            {
                return GenerateMove("         ");
            }

            return board == null &&
                   Request.QueryString.Value == string.Empty
                    ? BadRequest($"try using query string {emptyBoard}")
                    : GenerateMove(board);
        }

        private IActionResult GenerateMove(string board)
        {
            try
            {
                var validated = new Board(board);
                var nextMove = new MiniMax().BestNextMove(validated);
                var played = validated.AddPiece(Player.Us, nextMove);

                return Ok(played.Squares);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}