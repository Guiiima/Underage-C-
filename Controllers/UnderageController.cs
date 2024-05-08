using Microsoft.AspNetCore.Mvc;
using Underage.models;
using Underage.data;
using Microsoft.EntityFrameworkCore;

using System;
using System.Net;
using System.Net.Mail;

namespace Underage.Controllers;

[ApiController]
[Route("/underage")]
public class UnderageController : ControllerBase
{
    private UnderageDbContext _context;

    public UnderageController(UnderageDbContext context) {
        _context = context;
    }

      [HttpGet]
        [Route("all")]
        public async Task<ActionResult<IEnumerable<DadosPessoais>>> GetUnderage()
        {
            if (_context is null || _context.DadosPessoais is null)
                return NotFound();

            var underages = await _context.DadosPessoais.ToListAsync();
            return Ok(underages);
        }
        [HttpPost]
        [Route("new")]
        public async Task<ActionResult<DadosPessoais>> PostEvent([FromBody] DadosPessoais dados)
        {
            if (_context is null || _context.DadosPessoais is null)
                return NotFound();

            _context.DadosPessoais.Add(dados);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUnderage), new { id = dados.Id }, dados);
        }

        [HttpPost]
        [Route("key")]
        public ActionResult AccessKey([FromBody] Key key) {
            Console.WriteLine(key.chave);
            string remetenteEmail = "luanpozzobon@hotmail.com";
            string remetenteSenha = "jllasjduxqknvxif";
            string destinatarioEmail = "guilhermeh000@hotmail.com";

            var smtpClient = new SmtpClient("smtp-mail.outlook.com") {
                Port = 587,
                Credentials = new NetworkCredential(remetenteEmail, remetenteSenha),
                EnableSsl = true,
            };

            var message = new MailMessage(remetenteEmail, destinatarioEmail) {
                Subject = "Nova Chave de Acesso",
                Body = key.chave
            };

            try {
                smtpClient.Send(message);
                return Ok();
            } catch (Exception e) {
                return StatusCode(500);
            }
        }
}
