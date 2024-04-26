using MediatR;
using ToDo.Application.ViewModel;

public class UpdateToDoCommand : IRequest<ToDoViewModel>
{
    public int Id { get; set; }
    public string Title { get; set; }
    public bool IsCompleted { get; set; }
}