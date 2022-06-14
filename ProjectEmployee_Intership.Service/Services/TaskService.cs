using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProjectEmployee_intership.Database;
using ProjectEmployee_Intership.Core.Entities;
using ProjectEmployee_Intership.Core.Models.Dto;
using ProjectEmployee_Intership.Core.Models.Request;
using ProjectEmployee_Intership.Service.Interfaces;

namespace ProjectEmployee_Intership.Service.Services
{
    public class TaskService : ITaskService
    {
        private readonly ProjectUserContext _context;
        private readonly IMapper _mapper;

        public TaskService(ProjectUserContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public async Task<TasksDto> AddNewTask(AddTaskRequest request)
        {
            try
            {
                var newTask = _mapper.Map<Tasks>(request);
                if (newTask == null)
                {
                    throw new ArgumentException("Can not add task!");
                }
                var userExist = await _context.Users.FirstOrDefaultAsync(u => u.Id == request.UserId && !u.IsDeleted);
                if (userExist == null)
                    throw new ArgumentException("User doesn't exist!");
                newTask.Users.Add(userExist);
                _context.Tasks.Add(newTask);
                await _context.SaveChangesAsync();
                return _mapper.Map<TasksDto>(newTask);
            }
            catch (Exception ex)
            {

                throw new ArgumentException(ex.Message);
            }
           

        }

        public async Task<TasksDto> AssingTaskToUser(int userId, int projectId, int taskId)
        {
            try
            {
                var userExist = await _context.Users.FirstOrDefaultAsync(x => x.Id == userId && !x.IsDeleted);
                var userOnProject = await _context.Projects.FirstOrDefaultAsync(x => x.Users.Contains(userExist) && x.Id==projectId && !x.IsDeleted);
                var task = await _context.Tasks.FirstOrDefaultAsync(x=>!x.IsDeleted && x.Id==taskId);
                userExist.Tasks.Add(task);
                await _context.SaveChangesAsync();
                return _mapper.Map<TasksDto>(task);
            }
            catch (Exception ex)
            {

                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<TasksDto> DeleteTask(int id)
        {
            try
            {
                var task = await _context.Tasks.FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted);
                if (task == null)
                {
                    throw new ArgumentException("Task doesn't exist!");
                }
                task.IsDeleted = true;
                await _context.SaveChangesAsync();
                return _mapper.Map<TasksDto>(task);

            }
            catch (Exception ex)
            {

                throw new ArgumentException(ex.Message);
            }
            
        }

        public async Task<TasksDto> FinishTask(int id)
        {
            try
            {
                var task = await _context.Tasks.FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted);
                task.IsFinished = true;
                await _context.SaveChangesAsync();
                return _mapper.Map<TasksDto>(task);
                
            }
            catch (Exception ex)
            {

                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<List<TasksDto>> GetAllTasks()
        {
            try
            {
                var tasks = await _context.Tasks.Include(x => x.Project).Include(x => x.Users).Where(x=>!x.IsDeleted).ToListAsync();
                if (tasks == null)
                {
                    throw new ArgumentException("Tasks doesn't exists!");
                }
                return _mapper.Map<List<TasksDto>>(tasks);
            }
            catch (Exception ex)
            {

                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<List<TasksDto>> GetAllTasksByParamaters(GetTaskRequest search)
        {
            try
            {
                var tasks = _context.Tasks.Include(x => x.Project).Include(x => x.Users).
                    AsQueryable();
                if (!string.IsNullOrWhiteSpace(search.Name))
                {
                    search.Name = search.Name.Trim();
                    tasks = tasks.Where(x => x.Name == search.Name);
                }
                if (!string.IsNullOrWhiteSpace(search.Description))
                {
                    search.Description=search.Description.Trim();
                    tasks = tasks.Where(x => x.Description == search.Description);
                }
                if (!string.IsNullOrWhiteSpace(search.DeadLine.ToString()))
                {
                    tasks=tasks.Where(x=>x.DeadLine == search.DeadLine);
                }
                if (!string.IsNullOrWhiteSpace(search.IsFinished.ToString()))
                {
                    tasks = tasks.Where(x => x.IsFinished == search.IsFinished);
                }
                if (!string.IsNullOrWhiteSpace(search.UserId.ToString()))
                {
                    tasks = tasks.Where(x => x.Users.Any(x=>x.Id == search.UserId));
                }
                if (!string.IsNullOrWhiteSpace(search.EmployeeId.ToString()))
                {
                    tasks = tasks.Where(x => x.Employees.Any(x=>x.Id == search.EmployeeId));
                }
                var pageNumber=search.PageNumber ?? 1;
                var pageSize = search.PageSize ?? 5;
                var listTasks = await tasks.Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToListAsync();
                return _mapper.Map<List<TasksDto>>(listTasks);
            }

            catch (Exception ex)
            {

                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<TasksDto> GetTaskById(int id)
        {
            try
            {
                var task = await _context.Tasks.FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted);
                if (task == null)
                {
                    throw new ArgumentException("Task doesn't exist!");
                }
                return _mapper.Map<TasksDto>(task);
            }
            catch (Exception)
            {

                throw new ArgumentException("Task doesn't exist");
            }
        }

        public async Task<TasksDto> UpdateTask(AddTaskRequest request, int id)
        {
            try
            {
                var entity=_mapper.Map<Task>(request);
                var task = await _context.Tasks.FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted);
                _mapper.Map(entity, task);
                await _context.SaveChangesAsync();
                return _mapper.Map<TasksDto>(task);
            }
            catch (Exception ex)
            {

                throw new ArgumentException(ex.Message);
            }
        }
        private async Task<bool> UserDoesExist(AddTaskRequest request)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == request.UserId&& !x.IsDeleted);
            if (user == null)
            {
                
                throw new ArgumentException("User does't exist!");
                return false;
            }
            var userProject = await _context.Projects.Include(x => x.Users).FirstOrDefaultAsync(x => x.Id == request.ProjectId && x.Users.Contains(user) && !x.IsDeleted);
            if (userProject == null)
            {
                throw new ArgumentException($"User doesn't exist on this project");
                return false;
            }
            return true;
        }
    }
}
