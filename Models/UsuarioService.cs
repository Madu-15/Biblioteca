namespace Biblioteca.Models
{
    public class UsuarioService
    {
        public void incluirUsuario(Usuario user){
          
          using(BibliotecaContext bc = new BibliotecaContext()){
              
              bc.Usuarios.Add(user);
              bc.SaveChanges();

          }
        }

        public void editarUsuario(Usuario user){
             using(BibliotecaContext bc = new BibliotecaContext()){
              
              Usuario u = bc.Usuarios.Find(user.id);

              u.Login = user.Login;
              u.Nome = user.Nome;
              u.Senha = user.Senha;
              u.Tipo = user.Tipo;
              bc.SaveChanges();

          }
        
        }
    }
}