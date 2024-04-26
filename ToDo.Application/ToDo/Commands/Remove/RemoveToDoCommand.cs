using MediatR;

public class RemoveToDoCommand : IRequest
{
    public int Id { get; set; }
}