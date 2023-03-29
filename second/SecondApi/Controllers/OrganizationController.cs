using Application.Service;
using Microsoft.AspNetCore.Mvc;

namespace SecondApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrganizationController : ControllerBase
    {
        private readonly IOrganizationService organizationService;

        public OrganizationController(IOrganizationService organizationService)
        {
            this.organizationService = organizationService;
        }
        [HttpGet]
        public async Task<IActionResult> Get(int id) =>
            Ok(await organizationService.GetOrganizationService(id));
    }
}
