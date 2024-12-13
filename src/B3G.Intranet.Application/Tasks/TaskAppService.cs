using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using B3G.Intranet.CRAs;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Identity;

namespace B3G.Intranet.Tasks
{
    public class TaskAppService :
        CrudAppService<
            TaskItem,
            TaskDto,
            Guid,
            PagedAndSortedResultRequestDto,
            CreateUpdateTaskDto>,
        ITaskAppService
    {

        private readonly IRepository<TaskItem, Guid> _repository;
        private readonly IRepository<EmployeeTask> _employeeTaskRepository;
        private readonly IRepository<IdentityUser, Guid> _userRepository;
        private readonly IRepository<CRA, Guid> _CRARepository;

        public TaskAppService(
            IRepository<TaskItem, Guid> repository,
            IRepository<EmployeeTask> employeeTaskRepository,
            IRepository<IdentityUser, Guid> userRepository,
            IRepository<CRA, Guid> CRARepository
            )
            : base(repository)
        {
            _repository = repository;
            _employeeTaskRepository = employeeTaskRepository;
            _userRepository = userRepository;
            _CRARepository = CRARepository;
        }

        public async Task<List<IdentityUserDto>> GetEmployeesByTaskIdAsync(Guid taskId)
        {
            var employeeTasks = await _employeeTaskRepository.GetListAsync();

            var employeeIds = employeeTasks
                .Where(et => et.TaskId == taskId)
                .Select(et => et.EmployeeId)
                .ToList();

            var users = await _userRepository.GetListAsync(u => employeeIds.Contains(u.Id));

            return ObjectMapper.Map<List<IdentityUser>, List<IdentityUserDto>>(users);
        }

        public async Task AssignTaskToEmployeeAsync(Guid taskId, Guid employeeId)
        {
            await _employeeTaskRepository.InsertAsync(new EmployeeTask
            {
                TaskId = taskId,
                EmployeeId = employeeId
            });
        }

        public async Task CancelTaskByEmployeeAsync(Guid taskId, Guid employeeId)
        {
            var employeeTask = await _employeeTaskRepository.FirstOrDefaultAsync(et => et.TaskId == taskId && et.EmployeeId == employeeId);
            if (employeeTask != null)
            {
                await _employeeTaskRepository.DeleteAsync(employeeTask);
            }
        }

        public async Task<float> GetHoursSpentAsync(Guid taskId)
        {
            var CRAs = await _CRARepository.GetListAsync();

            float TotalTimeSpent = CRAs
                .Where(c => c.TaskId == taskId)
                .Select(c => c.TimeSpent)
                .ToList()
                .Sum();

            return TotalTimeSpent;
        }
    }
}