namespace WebApi.Domain.Foundations;

public interface IActualizer
{
    public Task ActualizeById( int id );
}