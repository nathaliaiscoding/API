using System.Collections.Generic;
using System.Linq;
using UsuariosAPI.Models;


namespace UsuariosAPI.Service
{
    public static class EditUsers
    {

        static List<User> Users { get; }
        static int nextId = 2;

        static EditUsers()
        {
            Users = new List<User>
        {
            new User {UserId = 1, UserFirstName = "Nathalia", UserLastName = "Laudano", UserAge = 29}
        };
        }

        public static List<User> GetAll() => Users;

        public static User Get(int id) => Users.FirstOrDefault(u => u.UserId == id);

        public static void Add(User user)
        {
            user.UserId = nextId++;
            Users.Add(user);
        }

        public static void Delete(int id)
        {
            var user = Get(id);
            if (user is null)
                return;

            Users.Remove(user);
        }

        public static void Update(User user)
        {
            var index = Users.FindIndex(u => u.UserId == user.UserId);

            if (index == -1)
                return;

            Users[index] = user;
        }
    }

}
