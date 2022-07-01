using ModelJSON;

namespace Model
{
    public class User : BaseObject
    {
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string lang { get; set; }
        override public string ToString()
        {
            return $"{id},{name},{email},{lang}";
        }
        public static implicit operator User(UserJSON item)
        {
            return new User { id = item.id, name = item.name, email = item.email, lang = item.lang };
        }

    }

    public class UserList : ObservableList<User>
    {
        public static implicit operator UserList(UsersJSON json)
        {
            UserList list = new UserList();
            foreach (UserJSON user in json.ToList())
                list.Add(user);
            return list;
        }
    }
}
