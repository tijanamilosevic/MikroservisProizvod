﻿using AutoMapper;
using Data;
using Domen;
using FluentValidation;
using MikroServisProizvod.Application.BaseDtos;
using MikroServisProizvod.Application.DefaultServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MikroServisProizvod.Implementation.ServiceImplementations
{
    public class BaseAddService<TEntity, TDto> : BaseMapperService<TEntity,TDto>,IAddService<TDto>
        where TEntity : BaseEntity
        where TDto : BaseDto
    {
        private readonly IValidator<TDto> Validator;
        public BaseAddService(IGenericRepository<TEntity> genericRepository, IMapper mapper, IValidator<TDto> validator) : base(genericRepository, mapper)
        {
            Validator = validator;
        }

        public virtual TDto Add(TDto dto)
        {
            var validationResult = Validator.Validate(dto);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors.Select(x => new FluentValidation.Results.ValidationFailure(x.PropertyName,x.ErrorMessage)));
            }

            var mappedEntity = Mapper.Map<TEntity>(dto);

            GenericRepository.Add(mappedEntity);

            dto.Id = mappedEntity.Id;

            return dto;
        }
    }
}