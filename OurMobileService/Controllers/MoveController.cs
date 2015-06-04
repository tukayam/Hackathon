using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using OurMobileService.Models;
using System;
using OurMobileService.App_Start;
using System.Collections.Generic;

namespace OurMobileService.Controllers
{
    public class MoveController : ApiController
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
        }

        // GET api/move/{user}
        public IEnumerable<Move> GetMovesForUser(Guid userIdentifier)
        {
            return (from m in APIContext.Moves
                    where m.UserID == userIdentifier && m.Time > DateTime.Now.AddHours(-1)
                    select m);
        }


        public Move GetMostRecentMoveForUser(Guid userIdentifier)
        {
            return (from m in APIContext.Moves
                    where m.UserID == userIdentifier
                    orderby m.Time descending
                    select m).FirstOrDefault();
        }

        // POST api/move
        public async Task<IHttpActionResult> AddMove(Guid userId, int X, int Y, string floorID, string buildingID, string zoneId)
        {
            var move = new Move()
            {
                UserID = userId,
                X = X,
                Y = Y,
                FloorID = floorID,
                BuildingID = buildingID,
                ZoneID = zoneId
            };

            APIContext.Moves.Add(move);

            return CreatedAtRoute("api", new { userId = move.UserID }, move);
        }
    }
}