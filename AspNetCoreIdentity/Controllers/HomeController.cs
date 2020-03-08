using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AspNetCoreIdentity.Models;
using Microsoft.AspNetCore.Authorization;
using System;
using KissLog;

namespace AspNetCoreIdentity.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger _logger;

        public HomeController(ILogger logger)
        {
            _logger = logger;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {

            return View();
        }

        public IActionResult Privacy()
        {
            throw new Exception(message: "errooooou");
            return View();
        }

        [Authorize(Roles = "Admin")]
        //[Authorize(Roles = "PodeExcluir")]
        public IActionResult Secret()
        {
            return View();
        }

        [Authorize(Policy = "PodeExcluir")]
        public IActionResult SecretClaim()
        {
            return View("Index");
        }

        [Authorize(Policy = "PodeEscrever")]
        public IActionResult SecretClaimEscrever()
        {
            return View("Index");
        }

        [Authorize(Policy = "PodeGravar")]
        public IActionResult SecretClaimGravar()
        {
            return View("Index");
        }

        [Extensions.ClaimsAuthorize("Produtos", "Ler")]
        public IActionResult ClaimsCustomLer()
        {
            return View("Index");
        }

        [Route("erro/{id:length(3,3)}")]
        public IActionResult Error(int id)
        {
            var modelError = new ErrorViewModel();

            if (id == 500)
            {
                modelError.ErrorCode = id;
                modelError.Titulo = "Ocorreu um erro!";
                modelError.Mensagem = "Tente novamente mais tarde.";
            }
            else if (id == 404)
            {
                modelError.ErrorCode = id;
                modelError.Titulo = "Página não encontrada!";
                modelError.Mensagem = "A página que você está procurando não existe.";
            }
            else if (id == 403)
            {
                modelError.ErrorCode = id;
                modelError.Titulo = "Acesso negado!";
                modelError.Mensagem = "Você não tem permissão para fazer isso!";
            }
            else
            {
                return StatusCode(500);
            }



            return View("Error", modelError);
        }
    }
}
