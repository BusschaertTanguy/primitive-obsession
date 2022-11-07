namespace Application.Common.Commands;

public interface ICommandHandler<in T>
{
    Task Handle(T command);
}