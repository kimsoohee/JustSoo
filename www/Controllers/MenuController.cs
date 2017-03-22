using System.Web.Mvc;
using www.Repository;

namespace www.Controllers
{
    public class MenuController : Controller
    {
        // GET: Menu
        public PartialViewResult Left(string board_type, string board_type_code)
        {
            CodeRepository codeRepositoroy = new CodeRepository();
            ViewBag.board_type_code = board_type_code;
            ViewBag.board_type = board_type;
            return PartialView(codeRepositoroy.FindAll(board_type));
        }
    }
}