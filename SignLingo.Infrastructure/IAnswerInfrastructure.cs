using SignLingo.Infrastructure.Models;

namespace SignLingo.Infrastructure;

public interface IAnswerInfrastructure
{
    List<Answer> GetAll();
}