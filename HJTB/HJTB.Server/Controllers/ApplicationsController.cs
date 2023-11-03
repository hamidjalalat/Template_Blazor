using AutoMapper;
using Data;
using Hjx;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewModels.Applications;

namespace Dtx.Security.Server.Controllers
{
    public class ApplicationsController : BaseApiControllerWithDatabase
    {
        public ApplicationsController(IUnitOfWork unitOfWork, AutoMapper.IMapper mapper) : base(unitOfWork)
        {
            Mapper = mapper;
        }

        protected AutoMapper.IMapper Mapper { get; }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Application>>> GetAsync()
        {
            var result = await UnitOfWork.ApplicationRepository.GetAllAsync();

            return Ok(value: result);
        }


        [HttpGet(template: "{id}")]
        public async Task<ActionResult<Result<Application>>> GetAsync(Guid id)
        {
            Result<Application> result = new Result<Application>();

            try
            {
                var foundedEntity = await UnitOfWork.ApplicationRepository.GetByIdAsync(id);

                if (foundedEntity == null)
                {
                    result.Data = null;
                    result.IsSuccessful = false;

                    result.AddErrorMessage
                        ("اطلاعاتی با این مشخصه یافت نشد!");
                }
                else
                {
                    result.Data = foundedEntity;
                    result.IsSuccessful = true;
                }

                return Ok(value: result);
            }
            catch (Exception ex)
            {
                result.Data = null;
                result.IsSuccessful = false;

                result.AddErrorMessage(ex.Message);

                return Ok(value: result);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Result<Application>>> PostAsync(CreateViewModel viewModel)
        {
            Result result = new Result();

            try
            {
                Models.Application newEntity = Mapper.Map<Models.Application>(viewModel);

                await UnitOfWork.ApplicationRepository.InsertAsync(newEntity);

                await UnitOfWork.SaveAsync();
                result.IsSuccessful = true;

                return Ok(value: result);
            }
            catch (Exception ex)
            {
                result.IsSuccessful = false;
                return Ok(value: result);
            }
        }

        [HttpPut]
        public async Task<ActionResult<Result<Application>>> PutAsync(CreateViewModel viewModel)
        {
            Result result = new Result();

            try
            {
                Application application = new Application()
                {
                    Name = viewModel.Name,
                    Description = viewModel.Description,
                    Id = viewModel.Id,
                };

                await UnitOfWork.ApplicationRepository.UpdateAsync(application);

                await UnitOfWork.SaveAsync();

                result.IsSuccessful = true;
                result.AddInformationMessage("Success");

                return Ok(result);
            }
            catch (Exception ex)
            {

                result.IsSuccessful = false;
                result.AddInformationMessage("Error");

                return Ok(result);
            }
        }

        [HttpDelete(template: "{id}")]
        public async Task<Result> DeleteAsync(Guid id)
        {
            Result result = new Result();
            try
            {
                var resultDelete =
                 await UnitOfWork.ApplicationRepository.DeleteByIdAsync(id);

                await UnitOfWork.SaveAsync();

                result.IsSuccessful = true;

                return result;
            }
            catch (Exception ex)
            {
                result.IsSuccessful = false;

                return result;
            }
        }
    }
}
