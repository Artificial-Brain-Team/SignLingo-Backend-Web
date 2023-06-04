
using SignLingo.Infrastructure;
using SignLingo.Infrastructure.Context;
using SignLingo.Infrastructure.Models;

public class AnswerMySQLInfrastructure : IAnswerInfrastructure
{
    private SignLingoDbContext _signLingoDbContext;

    public AnswerMySQLInfrastructure(SignLingoDbContext signLingoDbContext)
    {
        _signLingoDbContext = signLingoDbContext;
    }

    public List<Answer> GetAll()
    {
        return _signLingoDbContext.Answers.ToList();
    }

}