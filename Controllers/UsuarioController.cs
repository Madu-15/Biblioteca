using Biblioteca.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;


namespace Biblioteca.Controllers
{
    public class UsuarioController : Controller
    {
        public IActionResult ListaDeUsuarios()
        {
            Autenticacao.CheckLogin(this);
            Autenticacao.verificaSeUsuarioEAdmin(this);

            List<Usuario> listagem = new UsuarioService().Listar();
            return View(listagem);
        }

        public IActionResult editarUsuario(int id)
        {
            Autenticacao.CheckLogin(this);
            Autenticacao.verificaSeUsuarioEAdmin(this);

            Usuario user = new UsuarioService().Listar(id);
            return View(user);

        }

        [HttpPost]

        public IActionResult editarUsuario(Usuario userEditado){
 
            userEditado.Senha = Criptografo.TextoCriptografado(userEditado.Senha);
            UsuarioService us = new UsuarioService();
            us.editarUsuario(userEditado);

            return RedirectToAction("ListaDeUsuarios");
        }
       

       
        public IActionResult RegistrarUsuarios(int id)
        {
            //autenticação
            Autenticacao.CheckLogin(this);
            Autenticacao.verificaSeUsuarioEAdmin(this);
            return View();

        }

        [HttpPost]

        public IActionResult RegistrarUsuarios(Usuario novoUser){

            //Autenticação
            //Criptografia de senha
            novoUser.Senha = Criptografo.TextoCriptografado(novoUser.Senha);
            Autenticacao.CheckLogin(this);
            Autenticacao.verificaSeUsuarioEAdmin(this);

            UsuarioService us = new UsuarioService();
            us.incluirUsuario(novoUser);

            return RedirectToAction("ListaDeUsuarios");
        }
     
     public IActionResult ExcluirUsuario(int id){
        Autenticacao.CheckLogin(this);
        Autenticacao.verificaSeUsuarioEAdmin(this);

        UsuarioService us = new UsuarioService();
        us.excluirUsuarios(id);   

         return RedirectToAction("ListaDeUsuarios");
     }

     public IActionResult Sair(){
         HttpContext.Session.Clear();
         return RedirectToAction("Index","Home");
     }

     public IActionResult NeedAdmin(){
         return View();   
        }
  
    }

}