using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Identity;

namespace B3G.Intranet.Tasks
{
    public interface ITaskAppService :
        ICrudAppService<
                TaskDto,
                Guid,
                PagedAndSortedResultRequestDto,
                CreateUpdateTaskDto>
    {
        Task<List<IdentityUserDto>> GetEmployeesByTaskIdAsync(Guid taskItemId);
        Task AssignTaskToEmployeeAsync(Guid taskId, Guid employeeId);
        Task CancelTaskByEmployeeAsync(Guid taskId, Guid employeeId);
        Task<float> GetHoursSpentAsync(Guid taskId);
    }
}