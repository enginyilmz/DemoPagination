using MVCPagination.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCPagination.Controllers
{
    public class PaginationController : Controller
    {
        // GET: Pagination
        [HttpGet]
        public ActionResult Index(int? page)
        {
            var dummyItems = Enumerable.Range(1, 150).Select(x => "Item " + x);
            var pager = new Pager(dummyItems.Count(), page);

            var viewModel = new IndexViewModel
            {
                Items = dummyItems.Skip((pager.CurrentPage - 1) * pager.PageSize).Take(pager.PageSize),
                Pager = pager
            };

            return View(viewModel);
        }
    }
}