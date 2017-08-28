using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using AzureAdApp.Services;
using AzureAdApp.Utils;
using Microsoft.IdentityModel.Clients.ActiveDirectory;

namespace AzureAdApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly AzureService _azureService;

        public HomeController()
        {
            _azureService = new AzureService();
        }

        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public async Task<ActionResult> Users()
        {
            try
            {
                var users = await _azureService.GetUsersAsync();

                return View(users);
            }
            catch (AzureServiceException e)
            {
                return View("Error", model: e.Message);
            }
            catch (Exception e)
            {
                return View("Error");
            }                        
        }

        [Authorize]
        public async Task<ActionResult> UserGroups(string userId)
        {
            try
            {
                var groups = await _azureService.GetUserGroupsAsync(userId);

                return PartialView("UserGroups", groups);
            }
            catch (AzureServiceException e)
            {
                return PartialView("_ErrorPartial", e.Message);
            }
            catch (Exception e)
            {
                return PartialView("_ErrorPartial");
            }            
        }
    }
}