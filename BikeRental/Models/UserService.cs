// importa lista generica e operacoes de consulta linq
using System.Collections.Generic;
using System.Linq;

// importa o modelo user
using BikeRental.Models;

namespace BikeRental.Services
{
    // classe estatica para gerenciar usuarios em memoria
    public static class UserService
    {
        // lista de usuarios que funciona como "banco de dados" temporario
        private static List<User> usuarios = new List<User>();

        // contador para gerar ids unicos automaticamente
        private static int idCounter = 1;

        // adiciona um novo usuario com id unico e insere na lista
        public static void Adicionar(User usuario)
        {
            usuario.Id = idCounter++;
            usuarios.Add(usuario);
        }

        // verifica se o email ja existe na lista
        public static bool EmailExiste(string email)
        {
            return usuarios.Any(u => u.Email == email);
        }

        // retorna uma nova lista com todos os usuarios
        public static List<User> ListarTodos()
        {
            return usuarios.ToList();
        }

        // remove um usuario com base no id
        public static void Deletar(int id)
        {
            var user = usuarios.FirstOrDefault(u => u.Id == id);
            if (user != null)
                usuarios.Remove(user);
        }

        // atualiza um usuario existente com novos dados
        public static void Atualizar(User userAtualizado)
        {
            var index = usuarios.FindIndex(u => u.Id == userAtualizado.Id);
            if (index != -1)
                usuarios[index] = userAtualizado;
        }
    }
}
