using DataAccessLayer.Entity;

namespace DataAccessLayer.Commens.Helpers;
public static class Validator
{
    public static bool IsExist(this Trainer trainer, IEnumerable<Trainer> trainers)
        => trainers.Any(c => c.Brand == trainer.Brand && c.ImageUrl == trainer.ImageUrl);
    public static bool IsExist(User user, IEnumerable<User> users)
    {
        return users.Any(c => c.Email == user.Email && c.UserName == user.UserName);
    }
}