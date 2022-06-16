using coreapp3.DbMigration;
using coreapp3.DbModels;
using coreapp3.Model;
using MediatR;

namespace coreapp3.Handlers
{
    public class CreateUserCommand : IRequest<ActionResponseModel>
    {
        public dbUsers model { get; set; }
        public CreateUserCommand(dbUsers _model)
        {
            model = _model;
        }
    }
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, ActionResponseModel>
    {
        private readonly AuthContext dbContext;
        public CreateUserCommandHandler(AuthContext _dbContext)
        {
            dbContext = _dbContext;
        }
        public async Task<ActionResponseModel> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            ActionResponseModel res = new ActionResponseModel();

            var exists = dbContext.Users.Where(x => x.UserName == request.model.UserName).Count() > 0;
            if (!exists)
            {
                dbContext.Users.Add(request.model);
                dbContext.SaveChanges();
                res.Status = 201;
                res.Message = "Successfuly Created New User";
                res.Success = true;
            }
            else
            {
                res.Status = 400;
                res.Message = "User Already Exists";
                res.Success = false;
            }

            return res;
        }
    }
}
