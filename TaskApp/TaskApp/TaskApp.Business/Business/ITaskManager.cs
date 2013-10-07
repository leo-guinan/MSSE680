using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskApp.Domain;
namespace TaskApp.Business
{
    public interface ITaskManager
    {
        Boolean addTask(String name, String notes, String description, DateTime dateCreated, DateTime dueDate, int priority, int estimateTime, String estimateType);
        Boolean modifyTask(String name, String notes, String description, DateTime dateCreated, DateTime dueDate, int priority, int estimateTime, String estimateType, int taskId);
        IList<Task> getAllTasks();


    }
}
