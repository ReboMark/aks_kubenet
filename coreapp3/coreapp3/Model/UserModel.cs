using coreapp3.DbModels;

namespace coreapp3.Model
{
    public class UserModel
    {
        public UserModel(dbUsers users)
        {
            Id = users.Id;
            UserId = users.UserId;
            UserName = users.UserName;
            MobileNumber = users.MobileNumber;
            EmailAddress = users.EmailAddress;
        }

        public dbUsers ToDbModel()
        {
            dbUsers model = new dbUsers 
            {
                Id = Id,
                UserId = UserId,
                UserName = UserName,
                MobileNumber = MobileNumber,
                EmailAddress = EmailAddress
            };
            return model;
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string MobileNumber { get; set; }
        public string EmailAddress { get; set; }
    }
}
