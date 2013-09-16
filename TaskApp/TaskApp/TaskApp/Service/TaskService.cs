using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskApp.Domain;
using TaskApp.Repository;

namespace TaskApp.Service
{
    public class TaskService : ITaskService
    {

        IRepository<Task> repository;
        
        public TaskService(IRepository<Task> repository)
        {
            this.repository = repository;
        }

        public Boolean addTask(Task task)
        {
            return repository.addEntity(task);
        }
        public Boolean modifyTask(Task task)
        {
            return repository.updateEntity(task);
        }

        public Task getTaskById(int id)
        {
            return repository.getEntity(id);
        }
        public IList<Task> getAllTasks()
        {
            IList<Task> allTasks = new List<Task>();

            foreach(Task item in repository.getAllEntities()) 
            {
                allTasks.Add(item);
            }

            return allTasks;
        }

        public Boolean removeTask(Task task)
        {
            return repository.delete(task);
        }

    }
}