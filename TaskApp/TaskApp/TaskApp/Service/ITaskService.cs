using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskApp.Domain;

namespace TaskApp.Service
{
    public interface ITaskService
    {
        Boolean addTask(Task task);
        Boolean modifyTask(Task task);
        Task getTaskById(int id);
        List<Task> getAllTasks();
        Boolean removeTask(Task task);
        List<Task> getAllTasksByPriority();
        List<Task> getAllTasksByDateCreated();
        List<Task> getAllTasksByDueDate();

    }
}