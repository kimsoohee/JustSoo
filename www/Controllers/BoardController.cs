using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;
using www.Models;
using www.Models.Entities;
using www.Repository;

namespace www.Controllers
{
    public class BoardController : Controller
    {
        BoardRepository boardRepository = new BoardRepository();

        public ActionResult Read(string board_type, string board_type_code, int id = 0)
        {
            ViewBag.board_type = board_type;
            ViewBag.board_type_code = board_type_code;

            ReadModel model = new ReadModel();
            model.latest_list = boardRepository.FindAll(board_type, board_type_code).ToList();

            if (id == 0)
            {
                if (model.latest_list.Count > 0)
                {
                    model.board = model.latest_list.First();
                }
            }
            else
            {
                model.board = boardRepository.FindByID(id);
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult Write(string board_type, string board_type_code, int id = 0)

        {
            ViewBag.board_type = board_type;
            ViewBag.board_type_code = board_type_code;

            ReadModel model = new ReadModel();
            model.board = new BoardEntity();

            if (id > 0)
            {
                model.board = boardRepository.FindByID(id);
            }
            return View(model);
        }

        [HttpPost]
        [ValidateInput(false)]
        public RedirectToRouteResult Write(WriteModel model)
        {
            if (model.board_seq > 0)
            {
                boardRepository.Update(model);
            }
            else
            {
                boardRepository.Add(model);
            }


            return new RedirectToRouteResult(
                new RouteValueDictionary {
                    { "action", "Read" },
                    { "controller", "Board" },
                    { "board_type", model.board_type },
                    { "board_type_code", model.board_type_code }
                });
        }

        public JsonResult Remove(int board_seq)
        {
            JsonModel model = new JsonModel();
            boardRepository.Remove(board_seq);
            model.result = 0;
            return Json(model, JsonRequestBehavior.AllowGet);
        }
    }
}