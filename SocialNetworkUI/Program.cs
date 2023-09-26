using SocialNetworkBackground.BLL.Models;
using SocialNetworkBackground.BLL.Services;
using SocialNetworkUI.Alert;

public class Program
{
    public static UserService userService = new UserService();
    public static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Регистрация пользователя");
            
            Console.Write("Введите имя:");
            var firstName = Console.ReadLine();

            Console.Write("Введите фамилию:");
            var lastName = Console.ReadLine();

            Console.Write("Введите E-Mail:");
            var email = Console.ReadLine();

            Console.Write("Введите пароль:");
            var password = Console.ReadLine();

            var registrationData = new UserRegistrationData()
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Password = password
            };

            try
            {
                userService.Register(registrationData);
                Alert.Success("Регистрация выполнена");
            }
            catch (Exception ex)
            {
                Alert.Error(ex.Message);
            }
        }  
    }
}