using coreapp3.DbMigration;
using coreapp3.Model;
using MediatR;

namespace coreapp3.Handlers
{
    public class GetUserQuery : IRequest<ActionResponseModel>
    {
        public int Id { get; set; }
        public GetUserQuery(int _Id)
        {
            Id = _Id;
        }
    }
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, ActionResponseModel>
    {
        private readonly AuthContext dbContext;
        public GetUserQueryHandler(AuthContext _dbContext)
        {
            dbContext = _dbContext;
        }
        public async Task<ActionResponseModel> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            ActionResponseModel res = new ActionResponseModel();
            var user = dbContext.Users.Where(x => x.Id == request.Id).FirstOrDefault();
            if (user != null)
            {
                res.Status = 200;
                res.Message = $"Query Successful. User - {user.UserName}";
                res.Success = true;
            }
            else
            {
                res.Status = 404;
                res.Message = "User Doesn't Exists";
                res.Success = false;
            }
            return res;
        }
    }
}
