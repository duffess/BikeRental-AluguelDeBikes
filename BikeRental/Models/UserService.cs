using System.Collections.Generic;
using System.Linq;
using BikeRental.Models;

namespace BikeRental.Services
{
    public static class UserService
    {
        private static List<User> usuarios = new List<User>();
        private static int idCounter = 1;

        public static void Adicionar(User usuario)
        {
            usuario.Id = idCounter++;
            usuarios.Add(usuario);
        }

        public static bool EmailExiste(string email)
        {
            return usuarios.Any(u => u.Email == email);
        }

        public static List<User> ListarTodos()
        {
            return usuarios.ToList();
        }

        public static void Deletar(int id)
        {
            var user = usuarios.FirstOrDefault(u => u.Id == id);
            if (user != null)
                usuarios.Remove(user);
        }

        public static void Atualizar(User userAtualizado)
        {
            var index = usuarios.FindIndex(u => u.Id == userAtualizado.Id);
            if (index != -1)
                usuarios[index] = userAtualizado;
        }
    }
}
